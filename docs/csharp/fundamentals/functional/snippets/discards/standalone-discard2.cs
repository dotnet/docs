using System;

public class DiscardOrVariable
{
   public static void DiscardVariables()
   {
      int value = 3;
      ShowValue(value);
   }

   // <VariableIdentifier>
   private static void ShowValue(int _)
   {
      byte[] arr = [0, 0, 1, 2];
      _ = BitConverter.ToInt32(arr, 0);
      Console.WriteLine(_);
   }
    // The example displays the following output:
    //       33619968
    // </VariableIdentifier>

    /*
    // <VariableTypeInference>
    private static bool RoundTrips(int _)
    {
       string value = _.ToString();
       int newValue = 0;
       _ = Int32.TryParse(value, out newValue);
       return _ == newValue;
    }
    // The example displays the following compiler error:
    //      error CS0029: Cannot implicitly convert type 'bool' to 'int'
    // </VariableTypeInference>
    
    */
}
