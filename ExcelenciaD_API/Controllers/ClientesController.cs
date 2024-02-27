using ExcelenciaD_API.Data;
using ExcelenciaD_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExcelenciaD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> _logger;
        private readonly AplicationDbContext _db;

        public ClientesController(ILogger<ClientesController> logger, AplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

         [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers()
        {
            var customers = _db.Customers
                .Include(c => c.Pedidos) // Incluir la relación de pedidos
                .ToList();

            return Ok(customers);
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Customer> GetCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var customer = _db.Customers
                .Include(c => c.Pedidos) 
                .FirstOrDefault(e => e.Id == id);

            if (customer == null)
            {
                _logger.LogWarning($"No se encontró el cliente con ID: {id}");
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Customer> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_db.Customers.Any(e => e.Name.ToLower() == customer.Name.ToLower()))
            {
                ModelState.AddModelError("Error", "El cliente con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (customer == null)
            {
                return BadRequest(customer);
            }

            if (customer.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            _db.Customers.Add(customer);
            _db.SaveChanges();

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id <= 0 || id != customer.Id)
            {
                return BadRequest("ID de cliente no válido o no coincide con el cliente proporcionado.");
            }

            var existingCustomer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.LastName = customer.LastName;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.Country = customer.Country;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int id, [FromBody] JsonPatchDocument<Customer> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            var existingCustomer = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            var customerToPatch = new Customer
            {
                Id = existingCustomer.Id,
                Name = existingCustomer.Name,
                LastName = existingCustomer.LastName,
                Email = existingCustomer.Email,
                Phone = existingCustomer.Phone,
                Address = existingCustomer.Address,
                City = existingCustomer.City,
                Country = existingCustomer.Country
            };

            patchDocument.ApplyTo(customerToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingCustomer.Name = customerToPatch.Name;
            existingCustomer.LastName = customerToPatch.LastName;
            existingCustomer.Email = customerToPatch.Email;
            existingCustomer.Phone = customerToPatch.Phone;
            existingCustomer.Address = customerToPatch.Address;
            existingCustomer.City = customerToPatch.City;
            existingCustomer.Country = customerToPatch.Country;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomer(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de cliente no válido.");
            }

            var customerToRemove = _db.Customers.FirstOrDefault(c => c.Id == id);
            if (customerToRemove == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            _db.Customers.Remove(customerToRemove);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
