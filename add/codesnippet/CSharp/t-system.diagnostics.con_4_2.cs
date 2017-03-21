using System;
using System.Diagnostics.Contracts;

static class ValidationHelper 
{
   [ContractArgumentValidator]
   public static void NotNull(object argument, string parameterName) 
   {
      if (argument == null) throw new ArgumentNullException(parameterName, 
                                                            "The parameter cannot be null.");
      Contract.EndContractBlock();
   }
}