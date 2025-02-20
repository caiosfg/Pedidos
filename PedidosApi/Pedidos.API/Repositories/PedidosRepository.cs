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
            "INSERT INTO pedido (nameclient, product, amount, price) VALUES (@nameclient, @product, @amount, @price);select lastval();",
            pedido
        );
        pedido.id = createdId;

        return pedido;
    }

    public  async Task DeletePedidoAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "DELETE FROM pedido WHERE id = @id",
            new {id}
        );
    }

    public async Task<IEnumerable<Pedido>> GetAllPedidosAsync()
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryAsync<Pedido>(
            "SELECT * FROM pedido"
        );
    }

    public async Task<Pedido?> GetPedidosByIdAsync(int id)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        return await connection.QueryFirstOrDefaultAsync<Pedido>("SELECT * FROM pedido where id = @id", new { id });
    }

    public async Task<Pedido> UpdatePedidoAsync(Pedido pedidos)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        await connection.ExecuteAsync(
            "UPDATE pedido SET nameclient = @nameclient, product = @product, amount = @amount, price = @price WHERE id = @id",
            pedidos
        );

        return pedidos;
    }
}
