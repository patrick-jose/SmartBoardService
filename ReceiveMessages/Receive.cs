using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SmartBoardService.Data.DTOs;
using SmartBoardService.Data.Repositories;
using SmartBoardService.Utils;

namespace ReceiveMessages
{
    public interface IReceive
    {
        void StartListening();
    }

    public class Receive : IReceive
    {
        public void StartListening()
        {
            var log = new LogWriter();
            var userDTO = new UserDTO();
            var taskDTO = new TaskDTO();
            var statusHistoryDTO = new StatusHistoryDTO();
            var sectionDTO = new SectionDTO();
            var commentDTO = new CommentDTO();
            var boardDTO = new BoardDTO();

            var db = new DbConnection(log);

            var userRepository = new UserRepository(log, db);
            var statusHistoryRepository = new StatusHistoryRepository(log, db);
            var commentRepository = new CommentRepository(log, db);
            var taskRepository = new TaskRepository(log, db);
            var boardRepository = new BoardRepository(log, db);
            var sectionRepository = new SectionRepository(log, db);

            var factory = new ConnectionFactory
            {
                Uri = new Uri(@"amqp://guest:guest@localhost:5672/"),
                NetworkRecoveryInterval = TimeSpan.FromSeconds(10),
                AutomaticRecoveryEnabled = true
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "SmartBoard",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            log.LogWrite(" [*] Waiting for messages.");

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                if (ea.BasicProperties.Headers != null)
                {
                    var elementString = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["ELEMENT"]);
                    var transactionTypeString = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["TRANSACTIONTYPE"]);
                    var multipleString = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["MULTIPLE"]);

                    var header = new Header()
                    {
                        Element = (ElementEnum)Enum.Parse(typeof(ElementEnum), elementString),
                        TransactionType = (TransactionTypeEnum)Enum.Parse(typeof(TransactionTypeEnum), transactionTypeString),
                        Multiple = Convert.ToBoolean(multipleString)
                    };

                    var body = ea.Body.ToArray();

                    Console.WriteLine(" [*] Received message -- " + Encoding.UTF8.GetString(body));

                    switch (header.Element)
                    {
                        case ElementEnum.TASK:
                            if (header.Multiple)
                                taskRepository.UpdateTasksAsync(JsonSerializer.Deserialize<List<TaskDTO>>(Encoding.UTF8.GetString(body)));
                            else
                            {
                                if (header.TransactionType == TransactionTypeEnum.UPDATE)
                                    taskRepository.UpdateTaskAsync(JsonSerializer.Deserialize<TaskDTO>(Encoding.UTF8.GetString(body)));
                                else
                                    taskRepository.InsertTaskAsync(JsonSerializer.Deserialize<TaskDTO>(Encoding.UTF8.GetString(body)));
                            }
                            break;
                        case ElementEnum.SECTION:
                            if (header.Multiple)
                                sectionRepository.UpdateSectionsAsync(JsonSerializer.Deserialize<List<SectionDTO>>(Encoding.UTF8.GetString(body)));
                            else
                            {
                                Console.WriteLine(JsonSerializer.Deserialize<SectionDTO>(Encoding.UTF8.GetString(body)).Name);
                                if (header.TransactionType == TransactionTypeEnum.UPDATE)
                                    sectionRepository.UpdateSectionAsync(JsonSerializer.Deserialize<SectionDTO>(Encoding.UTF8.GetString(body)));
                                else
                                    sectionRepository.InsertSectionAsync(JsonSerializer.Deserialize<SectionDTO>(Encoding.UTF8.GetString(body)));
                            }
                            break;
                        case ElementEnum.COMMENT:
                            commentRepository.InsertCommentAsync(JsonSerializer.Deserialize<CommentDTO>(Encoding.UTF8.GetString(body)));
                            break;
                        case ElementEnum.STATUSHISTORY:
                            statusHistoryRepository.InsertStatusHistoryAsync(JsonSerializer.Deserialize<StatusHistoryDTO>(Encoding.UTF8.GetString(body)));
                            break;
                        case ElementEnum.USER:
                            if (header.TransactionType == TransactionTypeEnum.UPDATE)
                                userRepository.UpdateUserAsync(JsonSerializer.Deserialize<UserDTO>(Encoding.UTF8.GetString(body)));
                            else
                                userRepository.InsertUserAsync(JsonSerializer.Deserialize<UserDTO>(Encoding.UTF8.GetString(body)));
                            break;
                        case ElementEnum.BOARD:
                            if (header.TransactionType == TransactionTypeEnum.UPDATE)
                                boardRepository.UpdateBoardAsync(JsonSerializer.Deserialize<BoardDTO>(Encoding.UTF8.GetString(body)));
                            else
                                boardRepository.InsertBoardAsync(JsonSerializer.Deserialize<BoardDTO>(Encoding.UTF8.GetString(body)));
                            break;
                    }
                }
            };

            channel.BasicConsume(queue: "SmartBoard",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to finish process.");
            Console.ReadLine();
        }
    }
}