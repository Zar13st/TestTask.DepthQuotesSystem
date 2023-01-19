﻿using NATS.Client;
using TestTask.DepthQuotesSystem.Communication.Interface;
using TestTask.DepthQuotesSystem.Communication.Nats;
using TestTask.DepthQuotesSystem.Messages;
using TestTask.DepthQuotesSystem.OrderBook.BusinessLogic;
using TestTask.DepthQuotesSystem.OrderBook.BusinessLogic.Imp;
using TestTask.DepthQuotesSystem.OrderBook.MessageHandlers;

namespace TestTask.DepthQuotesSystem.OrderBook;

public static class DependencyInjectionExtensions
{
    public static void AddNutsMessageBus(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHandler<OrderBookUpdate>, OrderBookUpdateHandler>();
        services.AddSingleton<NatsConsumer>();

        services.AddTransient<IBus, NatsPublisher>();

        services.AddNatsClient(configureOptions: options =>
        {
            options.Url = configuration["MESSAGEBUS_CONNECTION_STRING"];
        });
    }

    public static void AddBusinessLogic(this IServiceCollection services)
    {
        services.AddScoped<IOrderBookService, OrderBookService>();
    }
}