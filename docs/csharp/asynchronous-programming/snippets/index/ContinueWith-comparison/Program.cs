using System;
using System.Threading.Tasks;

namespace ContinueWithComparison
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("=== ContinueWith approach ===");
            await MakeBreakfastWithContinueWith();
            
            Console.WriteLine("\n=== async/await approach ===");
            await MakeBreakfastWithAsyncAwait();
        }

        // Using ContinueWith - demonstrates the complexity when chaining operations
        static Task MakeBreakfastWithContinueWith()
        {
            return StartCookingEggsAsync()
                .ContinueWith(eggsTask =>
                {
                    var eggs = eggsTask.Result;
                    Console.WriteLine("Eggs ready, starting bacon...");
                    return StartCookingBaconAsync();
                })
                .Unwrap()
                .ContinueWith(baconTask =>
                {
                    var bacon = baconTask.Result;
                    Console.WriteLine("Bacon ready, starting toast...");
                    return StartToastingBreadAsync();
                })
                .Unwrap()
                .ContinueWith(toastTask =>
                {
                    var toast = toastTask.Result;
                    Console.WriteLine("Toast ready, applying butter...");
                    return ApplyButterAsync(toast);
                })
                .Unwrap()
                .ContinueWith(butteredToastTask =>
                {
                    var butteredToast = butteredToastTask.Result;
                    Console.WriteLine("Butter applied, applying jam...");
                    return ApplyJamAsync(butteredToast);
                })
                .Unwrap()
                .ContinueWith(finalToastTask =>
                {
                    var finalToast = finalToastTask.Result;
                    Console.WriteLine("Breakfast completed with ContinueWith!");
                });
        }

        // Using async/await - much cleaner and easier to read
        static async Task MakeBreakfastWithAsyncAwait()
        {
            var eggs = await StartCookingEggsAsync();
            Console.WriteLine("Eggs ready, starting bacon...");
            
            var bacon = await StartCookingBaconAsync();
            Console.WriteLine("Bacon ready, starting toast...");
            
            var toast = await StartToastingBreadAsync();
            Console.WriteLine("Toast ready, applying butter...");
            
            var butteredToast = await ApplyButterAsync(toast);
            Console.WriteLine("Butter applied, applying jam...");
            
            var finalToast = await ApplyJamAsync(butteredToast);
            Console.WriteLine("Breakfast completed with async/await!");
        }

        static async Task<object> StartCookingEggsAsync()
        {
            Console.WriteLine("Starting to cook eggs...");
            await Task.Delay(1000);
            return new { Item = "Eggs" };
        }

        static async Task<object> StartCookingBaconAsync()
        {
            Console.WriteLine("Starting to cook bacon...");
            await Task.Delay(1000);
            return new { Item = "Bacon" };
        }

        static async Task<object> StartToastingBreadAsync()
        {
            Console.WriteLine("Starting to toast bread...");
            await Task.Delay(1000);
            return new { Item = "Toast" };
        }

        static async Task<object> ApplyButterAsync(object toast)
        {
            Console.WriteLine("Applying butter...");
            await Task.Delay(500);
            return new { Item = "Buttered Toast" };
        }

        static async Task<object> ApplyJamAsync(object butteredToast)
        {
            Console.WriteLine("Applying jam...");
            await Task.Delay(500);
            return new { Item = "Completed Toast" };
        }
    }
}