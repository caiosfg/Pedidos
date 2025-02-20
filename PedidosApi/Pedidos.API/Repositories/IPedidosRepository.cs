using System;

namespace Pedidos.API.Repositories;
using Pedidos.API.Models;

public interface IPedidosRepository
{
    Task<Pedido> CreatePedidoAsync(Pedido pedido);
    Task<Pedido> UpdatePedidoAsync(Pedido pedido);
    Task DeletePedidoAsync(int id);
    Task<IEnumerable<Pedido>> GetAllPedidosAsync();
    Task<Pedido> GetPedidosByIdAsync(int id);
}
