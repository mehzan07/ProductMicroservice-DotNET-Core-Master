using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMicroservice.RabbitMQMessaging.Options
{
        public class RabbitMqConfig
        {
            public string Hostname { get; set; }

            public string QueueName { get; set; }

            public string UserName { get; set; }

            public string Password { get; set; }
           public bool Enabled { get; set; }
    }
    }

