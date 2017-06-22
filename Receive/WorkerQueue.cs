using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Receive
{
    public class WorkerQueue
    {
        public void ConsumerReceiver()
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "ali", Password = "ali", VirtualHost = "/" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "task_queue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);

                    Console.WriteLine(" [x] Done");
                };

                channel.BasicConsume(queue: "task_queue", noAck: true, consumer: consumer);

                Console.ReadLine();
            }
        }
    }
}
