using System;

namespace Pedidos.API.Models.DTOs;

public class PedidosReadDto
{
    public int Id { get; set; }
    public string NameClient { get; set; } = string.Empty;
    public string Product { get; set; } = string.Empty;
    public int Amount { get; set; }
    public float Price { get; set; }
}
