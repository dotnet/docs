Imports Microsoft.Win32

Public Module GetDotNetVersion
   Public Sub Main()
      Get45PlusFromRegistry()
   End Sub

   Private Sub Get45PlusFromRegistry()
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
   Private Function CheckFor45PlusVersion(releaseKey As Integer) As String
      If releaseKey >= 460798 Then
         Return "4.7 or later"
      Else If releaseKey >= 394802 Then
         Return "4.6.2 or later"
      Else If releaseKey >= 394254 Then 
         Return "4.6.1"
      Else If releaseKey >= 393295 Then
         Return "4.6"
      Else If releaseKey >= 379893 Then
         Return "4.5.2"
      Else If releaseKey >= 378675 Then
         Return "4.5.1"
      Else If releaseKey >= 378389 Then
         Return "4.5"
      End If
      ' This code should never execute. A non-null release key should mean
      ' that 4.5 or later is installed.
    	Return "No 4.5 or later version detected"
   End Function
End Module   
' The example displays output like the following:
'       .NET Framework Version: 4.6.1

