using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.MailMerge
{
    public class BackgroundGenerator : IHostedService
    {
        private readonly ILogger<BackgroundGenerator> logger;
        private readonly IWorker worker;

        public BackgroundGenerator(ILogger<BackgroundGenerator> logger,
            IWorker worker)
        {
            this.logger = logger;
            this.worker = worker;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await worker.DoWork(cancellationToken);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            logger.LogInformation("Generator worker stopping");
            return Task.CompletedTask;
        }
    }
}
