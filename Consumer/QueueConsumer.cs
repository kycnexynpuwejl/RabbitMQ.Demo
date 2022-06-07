using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer;

public static class QueueConsumer
{
    public static void Consume(IModel channel)
    {
        channel.QueueDeclare("demo-queue",durable: true, exclusive: false, autoDelete: false, arguments: null);

        EventingBasicConsumer consumer = new(channel);
        consumer.Received += (_, e) =>
        {
            byte[] body = e.Body.ToArray();
            string message = Encoding.UTF8.GetString(body);
            Console.WriteLine(message);
        };

        channel.BasicConsume("demo-queue", true, consumer);
        Console.ReadLine();
    }
}