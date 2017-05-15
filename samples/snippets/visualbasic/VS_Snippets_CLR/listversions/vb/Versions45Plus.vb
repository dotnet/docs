' <snippet5>
Imports Microsoft.Win32

Public Class GetDotNetVersion
   Public Shared Sub Get45PlusFromRegistry()
      Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"
   	Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)
   		If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing 
   			Console.WriteLine(".NET Framework Version: " + CheckFor45PlusVersion(ndpKey.GetValue("Release")))
         Else 
            Console.WriteLine(".NET Framework Version 4.5 or later is not detected.")
         End If 
   	End Using
   End Sub

   ' Checking the version using >= will enable forward compatibility.
   Private Shared Function CheckFor45PlusVersion(releaseKey As Integer) As String
      If releaseKey >= 394802
         Return "4.6.2 or later"
      Else If releaseKey >= 394254 
         Return "4.6.1"
      Else If releaseKey >= 393295
         Return "4.6"
      Else If releaseKey >= 379893
         Return "4.5.2"
      Else If releaseKey >= 378675
         Return "4.5.1"
      Else If releaseKey >= 378389
   	   Return "4.5"
      End If
   	' This code should never execute. A non-null release key should mean
   	' that 4.5 or later is installed.
   	Return "No 4.5 or later version detected"
   End Function
End Class   
' Calling the GetDotNetVersion.Get45PlusFromRegistry method produces 
' output like the following:
'       .NET Framework Version: 4.6.1
' </snippet5>

Public Module Example
   Public Sub Main()
      GetDotNetVersion.Get45PlusFromRegistry()
   End Sub
End Module
