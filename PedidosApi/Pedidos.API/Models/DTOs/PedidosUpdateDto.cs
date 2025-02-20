using System;
using System.ComponentModel.DataAnnotations;


namespace Pedidos.API.Models.DTOs;

public class PedidosUpdateDto
{
    public int id { get; set; }

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
