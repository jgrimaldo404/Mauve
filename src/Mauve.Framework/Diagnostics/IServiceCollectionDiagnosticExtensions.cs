using Microsoft.Extensions.DependencyInjection;

namespace Mauve.Diagnostics
{
    public static class IServiceCollectionDiagnosticExtensions
    {
        /// <summary>
        /// Enables diagnostics.
        /// </summary>
        /// <param name="services">The service collection which is enabling diagnostics.</param>
        /// <returns></returns>
        public static IServiceCollection UseDiagnostics(this IServiceCollection services)
        {
            DiagnosticService.EnableDiagnostics();
            return services;
        }
    }
}
