using System;
using Pedidos.API.Models.DTOs;
using Pedidos.API.Models;

namespace Pedidos.API.Mappers;

public static class PedidosMapper
{
    public static Pedidos ToPedidos(this PedidosCreateDto pedidosCreate) {
        return new Pedidos
        {
            NameClient = pedidosCreate.NameClient,
            Product = pedidosCreate.Product,
            Amount = pedidosCreate.Amount,
            Price = pedidosCreate.Price
        };
    }
    public static Pedidos ToPedidos(this PedidosUpdateDto pedidosUpdate) {
        return new Pedidos
        {
            Id = pedidosUpdate.Id,
            NameClient = pedidosUpdate.NameClient,
            Product = pedidosUpdate.Product,
            Amount = pedidosUpdate.Amount,
            Price = pedidosUpdate.Price
        };
    }
    public static PedidosReadDto ToPedidosReadDto(this Pedidos pedidos) {
        return new PedidosReadDto
        {
            Id = pedidos.Id,
            NameClient = pedidos.NameClient,
            Product = pedidos.Product,
            Amount = pedidos.Amount,
            Price = pedidos.Price
        };
    }
}
