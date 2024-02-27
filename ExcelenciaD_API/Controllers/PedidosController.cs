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
    public class PedidosController : ControllerBase
    {
        private readonly ILogger<PedidosController> _logger;
        private readonly AplicationDbContext _db;

        public PedidosController(ILogger<PedidosController> logger, AplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Pedido>> GetPedidos()
        {
            var pedidos = _db.Pedidos.Include(p => p.Customer).ToList();
            return Ok(pedidos);
        }

        [HttpGet("{id:int}", Name = "GetPedido")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Pedido> GetPedido(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            var pedido = _db.Pedidos.Include(p => p.Customer).FirstOrDefault(e => e.Id == id);
            if (pedido == null)
            {
                _logger.LogWarning($"No se encontró el pedido con ID: {id}");
                return NotFound();
            }

            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<Pedido> CreatePedido([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid || pedido.CustomerId == null)
            {
                return BadRequest(ModelState);
            }

            
            var customer = _db.Customers.FirstOrDefault(c => c.Id == pedido.CustomerId);
            if (customer == null)
            {
                return BadRequest("No se encontró el cliente asociado al pedido.");
            }

            pedido.CustomerId = customer.Id; 
            _db.Pedidos.Add(pedido);
            _db.SaveChanges();

            
            return CreatedAtRoute("GetPedido", new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePedido(int id, [FromBody] Pedido pedido)
        {
            if (id <= 0 || id != pedido.Id)
            {
                return BadRequest("ID de pedido no válido o no coincide con el pedido proporcionado.");
            }

            var existingPedido = _db.Pedidos.FirstOrDefault(p => p.Id == id);
            if (existingPedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            existingPedido.Detalles = pedido.Detalles;
            existingPedido.CustomerId = pedido.CustomerId;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePedido(int id, [FromBody] JsonPatchDocument<Pedido> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío.");
            }

            var existingPedido = _db.Pedidos.FirstOrDefault(p => p.Id == id);
            if (existingPedido == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            var pedidoToPatch = new Pedido
            {
                Id = existingPedido.Id,
                Detalles = existingPedido.Detalles,
                CustomerId = existingPedido.CustomerId
            };

            patchDocument.ApplyTo(pedidoToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingPedido.Detalles = pedidoToPatch.Detalles;
            existingPedido.CustomerId = pedidoToPatch.CustomerId;

            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePedido(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID de pedido no válido.");
            }

            var pedidoToRemove = _db.Pedidos.FirstOrDefault(p => p.Id == id);
            if (pedidoToRemove == null)
            {
                return NotFound("Pedido no encontrado.");
            }

            _db.Pedidos.Remove(pedidoToRemove);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
