using System;
using Pedidos.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Pedidos.API.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {}
    public DbSet<Pedido> Pedido { get; set; }
}
