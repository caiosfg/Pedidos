using System;
using Pedidos.API.Models.DTOs;
using Pedidos.API.Models;

namespace Pedidos.API.Mappers;

public static class PedidosMapper
{
    public static Pedido ToPedidos(this PedidosCreateDto pedidosCreate) {
        return new Pedido
        {
            nameclient = pedidosCreate.nameclient,
            product = pedidosCreate.product,
            amount = pedidosCreate.amount,
            price = pedidosCreate.price
        };
    }
    public static Pedido ToPedidos(this PedidosUpdateDto pedidosUpdate) {
        return new Pedido
        {
            id = pedidosUpdate.id,
            nameclient = pedidosUpdate.nameclient,
            product = pedidosUpdate.product,
            amount = pedidosUpdate.amount,
            price = pedidosUpdate.price
        };
    }
    public static PedidosReadDto ToPedidosReadDto(this Pedido pedidos) {
        return new PedidosReadDto
        {
            id = pedidos.id,
            nameclient = pedidos.nameclient,
            product = pedidos.product,
            amount = pedidos.amount,
            price = pedidos.price
        };
    }
}
