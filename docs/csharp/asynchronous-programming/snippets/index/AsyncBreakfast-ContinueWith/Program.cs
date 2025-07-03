using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncBreakfastContinueWith
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    class Program
    {
        static Task Main(string[] args)
        {
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");

            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamUsingContinueWith(2);

            var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            return ProcessTasksUsingContinueWith(breakfastTasks, eggsTask, baconTask, toastTask)
                .ContinueWith(_ =>
                {
                    Juice oj = PourOJ();
                    Console.WriteLine("oj is ready");
                    Console.WriteLine("Breakfast is ready!");
                });
        }

        static Task ProcessTasksUsingContinueWith(List<Task> breakfastTasks, Task<Egg> eggsTask, Task<Bacon> baconTask, Task<Toast> toastTask)
        {
            return Task.WhenAny(breakfastTasks)
                .ContinueWith(finishedTaskContainer =>
                {
                    var finishedTask = finishedTaskContainer.Result;
                    if (finishedTask == eggsTask)
                    {
                        Console.WriteLine("eggs are ready");
                    }
                    else if (finishedTask == baconTask)
                    {
                        Console.WriteLine("bacon is ready");
                    }
                    else if (finishedTask == toastTask)
                    {
                        Console.WriteLine("toast is ready");
                    }
                    
                    breakfastTasks.Remove(finishedTask);
                    
                    // Continue processing remaining tasks if any
                    if (breakfastTasks.Count > 0)
                    {
                        return ProcessTasksUsingContinueWith(breakfastTasks, eggsTask, baconTask, toastTask);
                    }
                    else
                    {
                        return Task.CompletedTask;
                    }
                }).Unwrap();
        }

        static Task<Toast> MakeToastWithButterAndJamUsingContinueWith(int number)
        {
            return ToastBreadAsync(number)
                .ContinueWith(toastTask =>
                {
                    var toast = toastTask.Result;
                    ApplyButter(toast);
                    ApplyJam(toast);
                    return toast;
                });
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}