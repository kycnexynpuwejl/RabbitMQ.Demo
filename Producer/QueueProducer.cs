using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace Producer;

public static class QueueProducer
{
    public static void Publish(IModel channel)
    {
        channel.QueueDeclare(
            "demo-queue",
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
        int count = 0;

        while (true)
        {
            var message = new { Name = "Producer", Message = "Hello!", Count = count};
            byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            channel.BasicPublish("", "demo-queue", null, body);
            count++;
            Thread.Sleep(1000);
        }
    }
}