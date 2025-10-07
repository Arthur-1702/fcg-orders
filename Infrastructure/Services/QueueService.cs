using Application.Interfaces;
using Azure.Storage.Queues;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace Infrastructure.Services
{
    public class QueueService : IQueueService
    {
        private readonly QueueClient _paymentsQueueClient;
        private readonly QueueClient _notificationsQueueClient;

        public QueueService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AzureStorage");
            _paymentsQueueClient = new QueueClient(connectionString, "payments");
            _notificationsQueueClient = new QueueClient(connectionString, "notifications");
        }

        public async Task PublishOrderAsync(int orderId)
        {
            var messageText = orderId.ToString();

            // Converte a string para bytes em UTF-8 e envia como BinaryData
            var messageBytes = Encoding.UTF8.GetBytes(messageText);
            string base64Message = Convert.ToBase64String(messageBytes);
            await _paymentsQueueClient.SendMessageAsync(base64Message);
        }

        public async Task PublishNotificationAsync(int orderId)
        {

            var messageText = orderId.ToString();

            // Converte a string para bytes em UTF-8 e envia como BinaryData
            var messageBytes = Encoding.UTF8.GetBytes(messageText);
            string base64Message = Convert.ToBase64String(messageBytes);
            await _notificationsQueueClient.SendMessageAsync(new BinaryData(base64Message));

        }
    }
}