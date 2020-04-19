using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RabbitMQHelper;
using System.Configuration;
using RabbitMQ.Client.Events;

namespace RabbitMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnection connection = RabbitMQConnectionHelp.GetConnection();
            SenSimpleQueueMessage(connection);
            connection.Close();
            Console.ReadKey(); 
        } 
        public static void SenSimpleQueueMessage(IConnection connection)
        {
            string QueueName = ConfigurationManager.AppSettings["SimpleQueue"] ?? "" + Guid.NewGuid().ToString();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            for (int i = 0; i < 50; i++)
            {
                string message = "test send" + i;
                channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message)); //生产消息 
                Console.WriteLine($"Send:{message}");
            }
            connection.Close();

        }

        public static void SenWorkQueueMessage(IConnection connection)
        {
            string QueueName = ConfigurationManager.AppSettings["WorkQueue"] ?? "" + Guid.NewGuid().ToString();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            for (int i = 0; i < 50; i++)
            {
                string message = "test send" + i;
                channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message)); //生产消息 
                Console.WriteLine($"Send:{message}");
            }
            connection.Close();

        }

        public static void SendRoundQueueMessage(IConnection connection)
        {
            string QueueName = ConfigurationManager.AppSettings["RoundQueue"] ?? "" + Guid.NewGuid().ToString();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            for (int i = 0; i < 50; i++)
            {
                string message = "test send" + i;
                channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message)); //生产消息 
                Console.WriteLine($"Send:{message}");
            }
            connection.Close();

        }

        public static void SenFairQueueMessage(IConnection connection)
        {
            string QueueName = ConfigurationManager.AppSettings["FairQueue"] ?? "" + Guid.NewGuid().ToString();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            for (int i = 0; i < 50; i++)
            {
                string message = "test send" + i;
                channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message)); //生产消息 
                Console.WriteLine($"Send:{message}");
            }
            connection.Close();

        }

        public static void SendTxQueueMessage(IConnection connection)
        {
            string QueueName = ConfigurationManager.AppSettings["TxQueue"] ?? "" + Guid.NewGuid().ToString();
            IModel channel = connection.CreateModel();
            channel.QueueDeclare(QueueName, false, false, false, null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.DeliveryMode = 2;
            for (int i = 0; i < 50; i++)
            {
                string message = "test send" + i;
                channel.BasicPublish("", QueueName, null, Encoding.UTF8.GetBytes(message)); //生产消息 
                Console.WriteLine($"Send:{message}");
            }
            connection.Close();

        }

       
    }
}
