using System.Threading;
using System.Threading.Tasks;

namespace Mauve.Patterns.Behavioral
{
    public interface IMediator
    {
        void Send<T>(T request) where T : IRequest;
        TOut Send<TRequest, TOut>(TRequest request) where TRequest : IRequest<TOut>;
        Task Send<T>(T request, CancellationToken cancellationToken) where T : IRequest;
        Task<TOut> Send<TRequest, TOut>(TRequest request, CancellationToken cancellationToken) where TRequest : IRequest<TOut>;
    }
}
