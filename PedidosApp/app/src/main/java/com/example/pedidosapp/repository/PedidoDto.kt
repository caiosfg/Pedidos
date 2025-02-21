package com.example.pedidosapp.repository

data class PedidoDto(
    val id: Int,
    val nameclient: String,
    val product: String,
    val amount: Int,
    val price: Float
)