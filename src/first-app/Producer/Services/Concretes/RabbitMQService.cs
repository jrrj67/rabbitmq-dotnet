using System.Text;
using Producer.Services.Interfaces;
using RabbitMQ.Client;

namespace Producer.Services.Concretes;

/// <summary>
/// Service for encapsulating RabbitMQ factory, connection and channel.
/// </summary>
public class RabbitMQService : IRabbitMQService
{
    private readonly IConnectionFactory _factory;
    private readonly IConnection _connection;
    public IModel Channel { get; private set; }

    public RabbitMQService()
    {
        _factory = new ConnectionFactory() { HostName = "localhost" };     

        _connection = _factory.CreateConnection();

        Channel = _connection.CreateModel();
    }

    public void Dispose()
    {
        if (Channel is not null) Channel.Dispose();

        if (_connection is not null) _connection.Dispose();
    }
}