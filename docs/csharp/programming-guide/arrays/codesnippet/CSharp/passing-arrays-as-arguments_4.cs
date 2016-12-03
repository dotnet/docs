class ArrayClass
{
    static void PrintArray(string[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            System.Console.Write(arr[i] + "{0}", i < arr.Length - 1 ? " " : "");
        }
        System.Console.WriteLine();
    }

    static void ChangeArray(string[] arr)
    {
        // The following attempt to reverse the array does not persist when
        // the method returns, because arr is a value parameter.
        arr = (arr.Reverse()).ToArray();
        // The following statement displays Sat as the first element in the array.
        System.Console.WriteLine("arr[0] is {0} in ChangeArray.", arr[0]);
    }

    static void ChangeArrayElements(string[] arr)
    {
        // The following assignments change the value of individual array 
        // elements. 
        arr[0] = "Sat";
        arr[1] = "Fri";
        arr[2] = "Thu";
        // The following statement again displays Sat as the first element
        // in the array arr, inside the called method.
        System.Console.WriteLine("arr[0] is {0} in ChangeArrayElements.", arr[0]);
    }

    static void Main()
    {
        // Declare and initialize an array.
        string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

        // Pass the array as an argument to PrintArray.
        PrintArray(weekDays);

        // ChangeArray tries to change the array by assigning something new
        // to the array in the method. 
        ChangeArray(weekDays);

        // Print the array again, to verify that it has not been changed.
        System.Console.WriteLine("Array weekDays after the call to ChangeArray:");
        PrintArray(weekDays);
        System.Console.WriteLine();

        // ChangeArrayElements assigns new values to individual array
        // elements.
        ChangeArrayElements(weekDays);

        // The changes to individual elements persist after the method returns.
        // Print the array, to verify that it has been changed.
        System.Console.WriteLine("Array weekDays after the call to ChangeArrayElements:");
        PrintArray(weekDays);
    }
}
// Output: 
// Sun Mon Tue Wed Thu Fri Sat
// arr[0] is Sat in ChangeArray.
// Array weekDays after the call to ChangeArray:
// Sun Mon Tue Wed Thu Fri Sat
// 
// arr[0] is Sat in ChangeArrayElements.
// Array weekDays after the call to ChangeArrayElements:
// Sat Fri Thu Wed Thu Fri Sat