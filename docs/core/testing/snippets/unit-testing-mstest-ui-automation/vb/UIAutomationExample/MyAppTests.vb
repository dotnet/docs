' <WindowTestClass>
Imports System.Diagnostics
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Windows.UIAutomation

<STATestClass>
Public NotInheritable Class MyAppTests
    Inherits WindowTest

    Protected Overrides Function CreateProcessStartInfo() As ProcessStartInfo
        Return New ProcessStartInfo("C:\MyApp\MyApp.exe")
    End Function
End Class
' </WindowTestClass>
