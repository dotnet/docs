using System;

class Program
{
   static void Main()
   {
      // <Snippet1>
      const string DisableCachingName = @"TestSwitch.LocalAppContext.DisableCaching";
      const string DontEnableSchUseStrongCryptoName = @"Switch.System.Net.DontEnableSchUseStrongCrypto";
      AppContext.SetSwitch(DisableCachingName, true);
      AppContext.SetSwitch(DontEnableSchUseStrongCryptoName, true);
      // </Snippet1>
   }
}
