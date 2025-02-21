package com.example.pedidosapp.services

import com.example.pedidosapp.repository.PedidoDto
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET;
import retrofit2.http.POST

interface PedidoService {

    @GET("api/Pedidos")
    fun getPedidos(): Response<List<PedidoDto>>
}