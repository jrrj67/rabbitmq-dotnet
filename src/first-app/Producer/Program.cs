using System.Text;
using Producer.Services.Concretes;
using Producer.Services.Interfaces;

using IRabbitMQService rabbitService = new RabbitMQService();

var channel = rabbitService.Channel;

var queueName = "letterbox";

channel.QueueDeclare(
    queue: queueName,
    durable: false,
    exclusive: false,
    autoDelete: false,
    arguments: null);

var message = "Hello from RabbitMQ.";

var body = Encoding.UTF8.GetBytes(message);

channel.BasicPublish("", queueName, true, null, body);

Console.WriteLine($"Published message: {message}");
