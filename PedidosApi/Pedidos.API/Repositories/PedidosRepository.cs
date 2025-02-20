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
    public async Task<Pedido> CreatePedidoAsync(Pedido pedido)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var createdId = await connection.ExecuteScalarAsync<int>(
            "INSERT INTO Pedido (NameClient, Product, Amount, Price) VALUES (@NameClient, @Product, @Amount, @Price);select lastval();",
            pedido
        );
        pedido.Id = createdId;

        return pedido;
    }

    public  async Task DeletePedidoAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "DELETE * FROM Pedido WHERE Id = @Id",
            new {id}
        );
    }

    public async Task<IEnumerable<Pedido>> GetAllPedidosAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryAsync<Pedido>(
            "SELECT * FROM Pedido"
        );
    }

    public async Task<Pedido?> GetPedidosByIdAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return (Pedido?)await connection.QueryAsync<Pedido>(
            "SELECT * FROM Pedido"
        );
    }

    public async Task<Pedido> UpdatePedidoAsync(Pedido pedidos)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "UPDATE Pedido SET NameClient = @NameClient, Product = @Product, Amount = @Amount, Price = @Price WHERE Id = @Id",
            pedidos
        );

        return pedidos;
    }
}
