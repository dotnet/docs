' Visual Basic .NET Document
Option Strict On

Module Example
   Public Sub Main()
      SetRegistryKey()
      Console.WriteLine(IsStringLegacyCompareMode())
      MsgBox("Press any key...")
      Console.WriteLine(IsStringLegacyCompareMode())
      MsgBox("Press any key...")
      Console.WriteLine(IsStringLegacyCompareMode())
   End Sub
   
   Private Sub SetRegistryKey()
      ' <Snippet16>
      Dim lm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
      ' Open the NETFramework key
      Dim nf As Microsoft.Win32.RegistryKey = lm.CreateSubKey("Software\Microsoft\.NETFramework")
      ' Set the value to 1. This overwrites any existing setting.
      nf.SetValue("String_LegacyCompareMode", 1, _
                  Microsoft.Win32.RegistryValueKind.DWord)
      ' </Snippet16>
   End Sub
   
   ' <Snippet17>
   Private Function IsStringLegacyCompareMode() As Boolean
      Dim lm As Microsoft.Win32.RegistryKey = Microsoft.Win32.Registry.LocalMachine
      ' Open the NETFramework key
      Dim nf As Microsoft.Win32.RegistryKey = lm.OpenSubKey("Software\Microsoft\.NETFramework")
      If nf Is Nothing Then Return False
         
      ' Get the String_LegacyCompareMode setting.
      Return CBool(nf.GetValue("String_LegacyCompareMode", 0))
   End Function
   ' </Snippet17>
End Module

