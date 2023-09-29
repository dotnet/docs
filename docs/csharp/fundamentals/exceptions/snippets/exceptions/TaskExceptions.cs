namespace exceptions;

class KitchenHelpers
{
    public class Toast { }

    // <TaskExceptions>
    // Non-async, task-returning method.
    // Within this method, any thrown exceptions emerge synchronously.
    public static Task<Toast> ToastBreadAsync(int slices, int toastTime)
    {
        if (slices is < 1 or > 4)
        {
            throw new ArgumentException(
                "You must specify between 1 and 4 slices of bread.",
                nameof(slices));
        }

        if (toastTime < 1)
        {
            throw new ArgumentException(
                "Toast time is too short.", nameof(toastTime));
        }

        return ToastBreadAsyncCore(slices, toastTime);

        // Local async function.
        // Within this function, any thrown exceptions are stored in the task.
        static async Task<Toast> ToastBreadAsyncCore(int slices, int time)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            // Start toasting.
            await Task.Delay(time);

            if (time > 2_000)
            {
                throw new InvalidOperationException("The toaster is on fire!");
            }

            Console.WriteLine("Toast is ready!");

            return new Toast();
        }
    }
    // </TaskExceptions>
}
