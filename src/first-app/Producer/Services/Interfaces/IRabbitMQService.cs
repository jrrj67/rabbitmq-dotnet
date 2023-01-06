using RabbitMQ.Client;

namespace Producer.Services.Interfaces;

/// <summary>
/// Interface for encapsulating RabbitMQ factory, connection and channel.
/// </summary>
public interface IRabbitMQService : IDisposable 
{
    IModel Channel { get; }
}