using System;

namespace Pedidos.API.Models.DTOs;

public class PedidosReadDto
{
    public int id { get; set; }
    public string nameclient { get; set; } = string.Empty;
    public string product { get; set; } = string.Empty;
    public int amount { get; set; }
    public float price { get; set; }
}
