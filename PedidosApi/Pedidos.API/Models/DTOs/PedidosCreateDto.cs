using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.API.Models.DTOs;

public class PedidosCreateDto
{
    [Required]
    [MaxLength(30)]
    public string nameclient { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string product { get; set; }  = string.Empty;

    [Required]
    public int amount { get; set; }
    
    [Required]
    public float price { get; set; }
}
