using System;

namespace ExprBodied;

// <Snippet1>
public class ChangedEventArgs : EventArgs
{
   public required int NewValue { get; init; }
}

public class ObservableNum(int _value)
{
   public event EventHandler<ChangedEventArgs> ChangedGeneric = default!;

   public event EventHandler Changed
   {
      // Note that, while this is syntactically valid, it won't work as expected because it's creating a new delegate object with each call.
      add => ChangedGeneric += (sender, args) => value(sender, args);
      remove => ChangedGeneric -= (sender, args) => value(sender, args);
   }

   public int Value
   {
      get => _value;
      set => ChangedGeneric?.Invoke(this, new() { NewValue = (_value = value) });
   }
}
// </Snippet1>

public class ExpressionExample
{
   public static void Main()
   {
      void PrintingHandler(object? sender, object? args)
         => Console.WriteLine((args as ChangedEventArgs)?.NewValue);
      ObservableNum num = new(2);
      num.Changed += PrintingHandler;
      num.Value = 3;
      num.Changed -= PrintingHandler;
      num.Value = 1; // Still prints!
   }
}
