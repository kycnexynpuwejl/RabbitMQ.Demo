using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

var factory = new ConnectionFactory
{
    Uri = new Uri("amqp://guest:guest@localhost:5672")
};

using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
channel.QueueDeclare("demo-queue",durable: true, exclusive: false, autoDelete: false, arguments: null);

var message = new {Name = "Producer", Message = "Hello!"};
byte[] body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

channel.BasicPublish("", "demo-queue", null, body);