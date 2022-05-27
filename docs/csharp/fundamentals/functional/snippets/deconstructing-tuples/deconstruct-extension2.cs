using System;

public class ExampleNullableEx
{
    public static void Main()
    {
        // <NullableExample>
        DateTime? questionableDateTime = default;
        var (hasValue, value) = questionableDateTime;
        Console.WriteLine(
            $"{{ HasValue = {hasValue}, Value = {value} }}");

        questionableDateTime = DateTime.Now;
        (hasValue, value) = questionableDateTime;
        Console.WriteLine(
            $"{{ HasValue = {hasValue}, Value = {value} }}");

        // Example outputs:
        // { HasValue = False, Value = 1/1/0001 12:00:00 AM }
        // { HasValue = True, Value = 11/10/2021 6:11:45 PM }
        // </NullableExample>
    }
}


// <NullableExtensions>
public static class NullableExtensions
{
    public static void Deconstruct<T>(
        this T? nullable,
        out bool hasValue,
        out T value) where T : struct
    {
        hasValue = nullable.HasValue;
        value = nullable.GetValueOrDefault();
    }
}
// </NullableExtensions>
