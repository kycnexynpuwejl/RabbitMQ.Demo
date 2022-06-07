using Producer;
using RabbitMQ.Client;

ConnectionFactory factory = new()
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

QueueProducer.Publish(channel);