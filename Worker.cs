using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using tx_wp_api;

namespace BackgroundTask.MailMerge
{
	public class Worker : IWorker
	{
		private readonly ILogger<Worker> logger;
		//private int number = 0;

		public Worker(ILogger<Worker> logger)
		{
			this.logger = logger;
		}

		public async Task DoWork(CancellationToken cancellationToken)
		{
			while (!cancellationToken.IsCancellationRequested)
			{
				ProcessingRequest request = new ProcessingRequest(null);

				if (request.Id == null)
				{
					logger.LogInformation("No request found in queue");
					await Task.Delay(1000, cancellationToken);
					continue;
				}
				else
				{
					TextControlProcessing.Merge(request);
					logger.LogInformation("Request found - executing worker");
				}

			}
		}
	}
}
