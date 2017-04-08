using System;

public class Class1
{
   public static void Main()
   {

   }

   private static void SetRegistryKey()
   {
      // <Snippet16>
      Microsoft.Win32.RegistryKey lm = Microsoft.Win32.Registry.LocalMachine;
      // Open the NETFramework key
      Microsoft.Win32.RegistryKey nf = lm.CreateSubKey(@"Software\Microsoft\.NETFramework");
      // Set the value to 1. This overwrites any existing setting.
      nf.SetValue("String_LegacyCompareMode", 1, 
                  Microsoft.Win32.RegistryValueKind.DWord);
      // </Snippet16>
   }
   
   // <Snippet17>
   private static bool IsStringLegacyCompareMode()
   {
      Microsoft.Win32.RegistryKey lm = Microsoft.Win32.Registry.LocalMachine;
      // Open the NETFramework key
      Microsoft.Win32.RegistryKey nf = lm.OpenSubKey(@"Software\Microsoft\.NETFramework");
      if (nf == null) return false;
         
      // Get the String_LegacyCompareMode setting.
      return (bool) nf.GetValue("String_LegacyCompareMode", 0);
   }
   // </Snippet17>

}
