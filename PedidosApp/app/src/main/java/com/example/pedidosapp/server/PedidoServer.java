package com.example.pedidosapp.server;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public interface PedidoServer {
    Retrofit retrofit = new Retrofit.Builder()
            .baseUrl("http://localhost:5018/")
            .addConverterFactory(GsonConverterFactory.create())
            .build();

    PedidoServer service = retrofit.create(PedidoServer.class);
}
