<h1 align="center">
    <a href="/">
        <img src="./assets/logo.png" alt="Criador de Pedidos" width="30" height="24">
            Pedidos
    </a>
</h1>
<p align="center">Criador de Pedidos.</p>

<p align="center">
    <img src="https://img.shields.io/badge/9.0-7F66B3?logo=.net"/>
</p>


## Requisitos
1.Execute o comando abaixo para subir o banco:
> docker compose up

2. Acesse o caminho do projeto :
> .\PedidosApi\Pedidos.API\

3. suba as migrations : 
> dotnet ef database update

4. suba a aplicacão: 
> dotnet run

## Documentacao
Swagger :
> http://localhost:5018/index.html

Open Api:  
> http://localhost:5018/openapi/v1.json