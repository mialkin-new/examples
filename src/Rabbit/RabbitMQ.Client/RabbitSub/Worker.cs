using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace RabbitSub
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEventConsumer _eventConsumer;

        public Worker(ILogger<Worker> logger, IEventConsumer eventConsumer)
        {
            _logger = logger;
            _eventConsumer = eventConsumer;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Start consuming");
            await _eventConsumer.StartConsuming();
        }
    }
}