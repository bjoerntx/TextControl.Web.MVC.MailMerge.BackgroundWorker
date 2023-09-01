using System.Threading;
using System.Threading.Tasks;

namespace BackgroundTask.MailMerge
{
    public interface IWorker
    {
        Task DoWork(CancellationToken cancellationToken);
    }
}