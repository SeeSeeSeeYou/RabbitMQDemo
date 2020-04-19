using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQHelper
{
    public class RabbitMQConnectionHelp
    {
        private static ConnectionFactory factory;
        private static IConnection connection;
        private static readonly string UserName = ConfigurationManager.AppSettings["UserName"] ?? "";
        private static readonly string PassWord = ConfigurationManager.AppSettings["PassWord"] ?? "";
        private static readonly string HostName = ConfigurationManager.AppSettings["HostName"] ?? "";
        private static readonly int Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
        private static readonly string VirtualHost = ConfigurationManager.AppSettings["VirtualHost"] ?? "";

        /// <summary>
        /// 单例获取
        /// </summary>
        public static ConnectionFactory Instance()
        {
            if (factory == null)
            {
                //创建一个新的Factory 
                factory = new ConnectionFactory
                {
                    HostName = HostName,
                    Port = Port,
                    UserName = UserName,
                    Password = PassWord,
                    VirtualHost = VirtualHost
                };
            } 
            return factory;
        }

        /// <summary>
        /// 单例连接获取
        /// </summary>
        public static IConnection GetConnection()
        { 
            if (connection == null)
            { 
                factory = new ConnectionFactory
                {
                    HostName = HostName,
                    Port = Port,
                    UserName = UserName,
                    Password = PassWord,
                    VirtualHost = VirtualHost
                };
                connection = factory.CreateConnection();
            } 
            return connection;
        }
    }
}
