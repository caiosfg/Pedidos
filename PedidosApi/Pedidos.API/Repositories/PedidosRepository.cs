using System;
using Dapper;
using Npgsql;
using Pedidos.API.Models;

namespace Pedidos.API.Repositories;

public class PedidosRepository : IPedidosRepository
{
    private readonly string _connectionString = "";

    private readonly IConfiguration _config;

    public PedidosRepository(IConfiguration config){
        _config = config;
        _connectionString = _config.GetConnectionString("DefaultConnection");
    }
    public async Task<Pedidos> CreatePedidoAsync(Pedidos pedidos)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var createdId = await connection.ExecuteScalarAsync<int>(
            "INSERT INTO pedidos (NameClient, Product, Amount, Price) VALUES (@NameClient, @Product, @Amount, @Price);select lastval();",
            pedidos
        );
        pedidos.Id = createdId;

        return pedidos;
    }

    public  async Task DeletePedidoAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "DELETE * FROM pedidos WHERE Id = @Id",
            new {id}
        );
    }

    public async Task<IEnumerable<Pedidos>> GetAllPedidosAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryAsync<Pedidos>(
            "SELECT * FROM Pedidos"
        );
    }

    public async Task<Pedidos?> GetPedidosByIdAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryAsync<Pedidos>(
            "SELECT * FROM Pedidos"
        );
    }

    public async Task<Pedidos> UpdatePedidoAsync(Pedidos pedidos)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "UPDATE pedidos SET NameClient = @NameClient, Product = @Product, Amount = @Amount, Price = @Price WHERE Id = @Id",
            pedidos
        );

        return pedidos;
    }
}
