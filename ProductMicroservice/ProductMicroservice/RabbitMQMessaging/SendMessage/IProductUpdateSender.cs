using System;
using ProductMicroservice.Models;

namespace ProductMicroservice.RabbitMQMessaging.Sendmesage
{
    public interface IProductUpdateSender
    {
            void SendProduct(Product product);
    }
}
