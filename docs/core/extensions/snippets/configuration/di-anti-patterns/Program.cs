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

        // <TransientDisposable>
        static void TransientDisposablesWithoutDispose()
        {
            var services = new ServiceCollection();
            services.AddTransient<ExampleDisposable>();
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            for (int i = 0; i < 1000; ++ i)
            {
                _ = serviceProvider.GetRequiredService<ExampleDisposable>();
            }

            // serviceProvider.Dispose();
        }
        // </TransientDisposable>

        // <AsyncDeadlockOne>
        static void DeadLockWithAsyncFactory()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Foo>(implementationFactory: provider =>
            {
                Bar bar = GetBarAsync(provider).Result;
                return new Foo(bar);
            });

            services.AddSingleton<Bar>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            _ = serviceProvider.GetRequiredService<Foo>();
        }
        // </AsyncDeadlockOne>

        // <AsyncDeadlockTwo>
        static async Task<Bar> GetBarAsync(IServiceProvider serviceProvider)
        {
            // Emulate asynchronous work operation
            await Task.Delay(1000);

            return serviceProvider.GetRequiredService<Bar>();
        }
        // </AsyncDeadlockTwo>

        // <CaptiveDependency>
        static void CaptiveDependency()
        {
            var services = new ServiceCollection();
            services.AddSingleton<Foo>();
            services.AddScoped<Bar>();

            using ServiceProvider serviceProvider = services.BuildServiceProvider();
            // Enable scope validation
            // using ServiceProvider serviceProvider = services.BuildServiceProvider(validateScopes: true);

            _ = serviceProvider.GetRequiredService<Foo>();
        }
        // </CaptiveDependency>

        // <ScopedServiceBecomesSingleton>
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

            // Not within a scope, becomes a singleton
            Bar avoid = serviceProvider.GetRequiredService<Bar>();
        }
        // </ScopedServiceBecomesSingleton>
    }
}
