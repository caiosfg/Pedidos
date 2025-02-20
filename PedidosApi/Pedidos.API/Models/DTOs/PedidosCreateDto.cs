using System;
using System.ComponentModel.DataAnnotations;

namespace Pedidos.API.Models.DTOs;

public class PedidosCreateDto
{
    [Required]
    [MaxLength(30)]
    public string NameClient { get; set; } = string.Empty;

    [Required]
    [MaxLength(30)]
    public string Product { get; set; }  = string.Empty;

    [Required]
    public int Amount { get; set; }
    
    [Required]
    public float Price { get; set; }
}
