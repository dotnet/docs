// Uncomment when union member providers are available in the compiler:

// <MemberProvider>
// [System.Runtime.CompilerServices.Union]
// public record class Outcome<T> : Outcome<T>.IUnionMembers
// {
//     private readonly object? _value;
//
//     private Outcome(object? value) => _value = value;
//
//     public interface IUnionMembers
//     {
//         static Outcome<T> Create(T? value) => new(value);
//         static Outcome<T> Create(Exception? value) => new(value);
//         object? Value { get; }
//     }
//
//     object? IUnionMembers.Value => _value;
// }
// </MemberProvider>

// <MemberProviderExample>
// public static class MemberProviderScenario
// {
//     public static void Run()
//     {
//         Outcome<string> ok = "success";
//         var msg = ok switch
//         {
//             string s => $"OK: {s}",
//             Exception e => $"Error: {e.Message}",
//         };
//         Console.WriteLine(msg);
//     }
// }
// </MemberProviderExample>
