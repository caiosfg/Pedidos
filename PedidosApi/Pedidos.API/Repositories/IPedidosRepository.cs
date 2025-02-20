using System;

namespace Pedidos.API.Repositories;

public interface IPedidosRepository
{
    Task<Pedidos> CreatePedidoAsync(Pedidos pedidos);
    Task<Pedidos> UpdatePedidoAsync(Pedidos pedidos);
    Task DeletePedidoAsync(int id);
    Task<IEnumerable<Pedidos>> GetAllPedidosAsync();
    Task<Pedidos?> GetPedidosByIdAsync(int id);
}
