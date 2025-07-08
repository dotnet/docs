// <Snippet2>
using Microsoft.Win32;
using System;

public class Example
{
   public static void Main()
   {
      string valueName = "Lucida Console";
      string newFont = "simsun.ttc,SimSun";
      string[] fonts = null;
      RegistryValueKind kind = 0;
      bool toAdd;

      RegistryKey key = Registry.LocalMachine.OpenSubKey(
                 @"Software\Microsoft\Windows NT\CurrentVersion\FontLink\SystemLink",
                 true);
      if (key == null) {
         Console.WriteLine("Font linking is not enabled.");
      }
      else {
         // Determine if the font is a base font.
         string[] names = key.GetValueNames();
         if (Array.Exists(names, s => s.Equals(valueName,
                                      StringComparison.OrdinalIgnoreCase))) {
            // Get the value's type.
            kind = key.GetValueKind(valueName);

            // Type should be RegistryValueKind.MultiString, but we can't be sure.
            switch (kind) {
               case RegistryValueKind.String:
                  fonts = new string[] { (string) key.GetValue(valueName) };
                  break;
               case RegistryValueKind.MultiString:
                  fonts = (string[]) key.GetValue(valueName);
                  break;
               case RegistryValueKind.None:
                  // Do nothing.
                  fonts = new string[] { };
                  break;
            }
            // Determine whether SimSun is a linked font.
            if (Array.FindIndex(fonts, s =>s.IndexOf("SimSun",
                                       StringComparison.OrdinalIgnoreCase) >=0) >= 0) {
               Console.WriteLine("Font is already linked.");
               toAdd = false;
            }
            else {
               // Font is not a linked font.
               toAdd = true;
            }
         }
         else {
            // Font is not a base font.
            toAdd = true;
            fonts = new string[] { };
         }

         if (toAdd) {
            Array.Resize(ref fonts, fonts.Length + 1);
            fonts[fonts.GetUpperBound(0)] = newFont;
            // Change REG_SZ to REG_MULTI_SZ.
            if (kind == RegistryValueKind.String)
               key.DeleteValue(valueName, false);

            key.SetValue(valueName, fonts, RegistryValueKind.MultiString);
            Console.WriteLine("SimSun added to the list of linked fonts.");
         }
      }

      if (key != null) key.Close();
   }
}
// </Snippet2>
