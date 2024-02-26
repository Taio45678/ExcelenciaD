using ExcelenciaD_API.Data;
using ExcelenciaD_API.Models;
using ExcelenciaD_API.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
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

        public ClientesController(ILogger<ClientesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            var customers = CustomerStore.customerList;
            return Ok(customers);
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var customer = CustomerStore.customerList.FirstOrDefault(e => e.Id == id);
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
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CustomerStore.customerList.Any(e => e.Name.ToLower() == customerDto.Name.ToLower()))
            {
                ModelState.AddModelError("Error", "El cliente con ese nombre ya existe");
                return BadRequest(ModelState);
            }

            if (customerDto == null)
            {
                return BadRequest(customerDto);
            }

            if (customerDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            customerDto.Id = CustomerStore.customerList.OrderByDescending(e => e.Id).FirstOrDefault()?.Id + 1 ?? 1;
            CustomerStore.customerList.Add(customerDto);

            return CreatedAtRoute("GetCustomer", new { id = customerDto.Id }, customerDto);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerDto customerDto)
        {
            if (id <= 0 || id != customerDto.Id)
            {
                return BadRequest("ID de cliente no válido o no coincide con el cliente proporcionado.");
            }

            var existingCustomer = CustomerStore.customerList.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            // Actualizar los datos del cliente existente
            existingCustomer.Name = customerDto.Name;

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int id, [FromBody] JsonPatchDocument<CustomerDto> patchDto)
        {
            if (patchDto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            var existingCustomer = CustomerStore.customerList.FirstOrDefault(c => c.Id == id);
            if (existingCustomer == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            var customerDto = new CustomerDto
            {
                Id = existingCustomer.Id,
                Name = existingCustomer.Name
            };

            patchDto.ApplyTo(customerDto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingCustomer.Name = customerDto.Name;

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

            var customerToRemove = CustomerStore.customerList.FirstOrDefault(c => c.Id == id);
            if (customerToRemove == null)
            {
                return NotFound("Cliente no encontrado.");
            }

            CustomerStore.customerList.Remove(customerToRemove);

            return NoContent();
        }
    }
}
