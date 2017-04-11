// <Snippet1>
using System;

static class ValidationHelper 
{
   public static void NotNull(object argument, string parameterName) 
   {
      if (argument == null) throw new ArgumentNullException(parameterName, 
                                                            "The parameter cannot be null.");
   }
}

public class Example
{
   public void Execute(string value) 
   {
      ValidationHelper.NotNull(value, "value");
      
      // Body of method goes here.
   }
}
// </Snippet1>