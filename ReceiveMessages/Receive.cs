﻿using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmartBoardService.Utils;

namespace ReceiveMessages
{
    public class ReceiveTasks
    {
        public void StartListening()
        {
            var log = new LogWriter();
            //var customerRepository = new CustomerRepository(log);
            //var productRepository = new ProductRepository(log);
            //var ordersRepository = new OrdersRepository(log, customerRepository);
            //var business = new OrderServiceBusiness(ordersRepository, log, productRepository);

            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "tasks",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            log.LogWrite(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                log.LogWrite($" [x] Received {message}");

                //var listOrderDTO = JsonSerializer.Deserialize<List<OrderDTO>>(message);

                //await business.SaveOrders(listOrderDTO);
            };

            channel.BasicConsume(queue: "tasks",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}