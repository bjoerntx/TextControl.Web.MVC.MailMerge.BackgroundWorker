using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.MailMerge
{
    public class DerivedGeneratorPrinter : BackgroundService
    {
        private readonly IWorker worker;

        public DerivedGeneratorPrinter(IWorker worker)
        {
            this.worker = worker;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await worker.DoWork(stoppingToken);    
        }
    }
}
