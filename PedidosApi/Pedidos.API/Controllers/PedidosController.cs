using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.API.Mappers;
using Pedidos.API.Models.DTOs;
using Pedidos.API.Repositories;

namespace Pedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosRepository _pedidosRepository;

        public PedidosController(IPedidosRepository pedidosRepository)
        {
            _pedidosRepository = pedidosRepository;
        }

        [HttpPost]
        public async Task<IActionResult>CreatePedidos(PedidosCreateDto pedidosCreateDto) {
            try
            {
                var pedidos = await _pedidosRepository.CreatePedidoAsync(pedidosCreateDto.ToPedidos());

                return CreatedAtRoute(nameof(GetPedidosByIdAsync), new {Id = pedidos.Id}, pedidos.ToPedidosReadDto());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetPedidosByIdAsync")]
        public async Task<IActionResult> GetPedidosByIdAsync(int id)
        {
            try
            {
                var pedidos = await _pedidosRepository.GetPedidosByIdAsync(id);
                
                if(pedidos == null){
                    return NotFound("Pedido com id " + id + " nao encontrado!");
                }
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePedidoAsync (int id, PedidosUpdateDto pedidosUpdateDto)
        {
            try
            {
                if (id != pedidosUpdateDto.Id)
                {
                    return BadRequest("Ids nao coincide");
                }
                var existingPedido = await _pedidosRepository.GetPedidosByIdAsync(id);
                if (existingPedido == null)
                {
                    return NotFound("Pedido com id " + id + " nao encontrado");
                }
                await _pedidosRepository.UpdatePedidoAsync(pedidosUpdateDto.ToPedidos());
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePedidoAsync(int id)
        {
            try
            {
                var existingPedido = await _pedidosRepository.GetPedidosByIdAsync(id);
                if (existingPedido == null)
                {
                    return NotFound("Pedido com id " + id + " nao encontrado");
                }
                await _pedidosRepository.DeletePedidoAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllPedidosAsync()
        {
            try
            {
                var pedidos = await _pedidosRepository.GetAllPedidosAsync();
                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
