using Dimitri.ACT.Consumer;
using Dimitri.ACT.Consumer.Events;
using MassTransit;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;
        var newEntryQueue = configuration.GetSection("MassTransit")["NewEntryQueue"] ?? string.Empty;
        var server = configuration.GetSection("MassTransit")["Server"] ?? string.Empty;
        var user = configuration.GetSection("MassTransit")["User"] ?? string.Empty;
        var password = configuration.GetSection("MassTransit")["Password"] ?? string.Empty;

        services.AddHostedService<Worker>();

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(server, "/", h =>
                {
                    h.Username(user);
                    h.Password(password);
                });

                cfg.ReceiveEndpoint(newEntryQueue, e =>
                {
                    e.Consumer<NewEntryEvent>();
                });

                cfg.ConfigureEndpoints(context);
            });

            x.AddConsumer<NewEntryEvent>();
        });
    })
    .Build();

host.Run();