' Visual Basic .NET Document
Option Strict On

' <Snippet11>
Imports System.Globalization
Imports System.Threading

Public Class Info : Inherits MarshalByRefObject
   Public Sub ShowCurrentCulture()
      Console.WriteLine("Culture of {0} in application domain {1}: {2}",
                        Thread.CurrentThread.Name,
                        AppDomain.CurrentDomain.FriendlyName,
                        CultureInfo.CurrentCulture.Name)
   End Sub
End Class

Module Example2
    Public Sub S1()
        Dim inf As New Info()
        ' Set the current culture to Dutch (Netherlands).
        Thread.CurrentThread.Name = "MainThread"
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("nl-NL")
        inf.ShowCurrentCulture()

        ' Create a new application domain.
        Dim ad As AppDomain = AppDomain.CreateDomain("Domain2")
        Dim inf2 As Info = CType(ad.CreateInstanceAndUnwrap(GetType(Info).Assembly.FullName, "Info"),
                          Info)
        inf2.ShowCurrentCulture()
    End Sub
End Module
' This example displays the following output:
'       Culture of MainThread in application domain Example.exe: nl-NL
'       Culture of MainThread in application domain Domain2: nl-NL
' </Snippet11>
