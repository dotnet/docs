
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection.AntiPatterns
{
    class Program
    {
        static void Main()
        {
            // Uncomment individual methods below to see anti-patterns in action:
            // TransientDisposablesWithoutDispose();
            // DeadLockWithFactories();
            // CaptiveDependency();
            // ScopedServiceBecomesSingleton();
        }

        static void TransientDisposablesWithoutDispose()
        {
            var services = new ServiceCollection();
            services.AddTransient<SomethingDisposable>();
            using ServiceProvider serviceProvider =
                services.BuildServiceProvider();

            for (int i = 0; i < 1000; ++ i)
            {
                _ = serviceProvider.GetRequiredService<SomethingDisposable>();
            }

            serviceProvider.Dispose();
        }

        static void DeadLockWithFactories()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Foo>(implementationFactory: provider =>
            {
                Bar bar = GetBarAsync(provider).Result;
                return new Foo(bar);
            });

            services.AddSingleton<Bar>();

            using ServiceProvider serviceProvider =
                services.BuildServiceProvider();
            _ = serviceProvider.GetRequiredService<Foo>();
        }

        static async Task<Bar> GetBarAsync(IServiceProvider serviceProvider)
        {
            await Task.Delay(1000);

            return serviceProvider.GetRequiredService<Bar>();
        }

        static void CaptiveDependency()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Foo>();
            services.AddScoped<Bar>();

            // using ServiceProvider serviceProvider = services.BuildServiceProvider();
            using ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);

            _ = serviceProvider.GetRequiredService<Foo>();
        }

        static void ScopedServiceBecomesSingleton()
        {
            var services = new ServiceCollection();
            services.AddScoped<Bar>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);
            using (IServiceScope scope = serviceProvider.CreateScope())
            {
                // Correctly scoped resolution
                Bar correct = scope.ServiceProvider.GetRequiredService<Bar>();
            }

            // This makes the scoped service a singleton, as it is not within a scope
            Bar avoid = serviceProvider.GetRequiredService<Bar>();
        }
    }

    public class Foo
    {
        public Foo(Bar bar)
        {
        }
    }

    public class Bar
    {
    }

    public class SomethingDisposable : IDisposable
    {
        void IDisposable.Dispose() => Console.WriteLine("Disposed");
    }
}
