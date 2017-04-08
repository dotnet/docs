'<snippet1>
' This example demonstrates the PlatformID enumeration.
Imports System

Class Sample
   Public Shared Sub Main()
      Dim msg1 As String = "This is a Windows operating system."
      Dim msg2 As String = "This is a Unix operating system."
      Dim msg3 As String = "ERROR: This platform identifier is invalid."
      
      ' Assume this example is run on a Windows operating system.
      Dim os As OperatingSystem = Environment.OSVersion
      Dim pid As PlatformID = os.Platform
      Select Case pid
         Case PlatformID.Win32NT, PlatformID.Win32S, _
              PlatformID.Win32Windows, PlatformID.WinCE
            Console.WriteLine(msg1)
         Case PlatformID.Unix
            Console.WriteLine(msg2)
         Case Else
            Console.WriteLine(msg3)
      End Select
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'This is a Windows operating system.
'
'</snippet1>