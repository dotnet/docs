Imports System.Diagnostics

Namespace Global.Microsoft.VisualStudio.TestTools.UnitTesting.Windows.UIAutomation

    ' Build-only fallback until the MSTest 4.5 preview packages are publicly available.
    Public MustInherit Class WindowTest

        Protected MustOverride Function CreateProcessStartInfo() As ProcessStartInfo

    End Class

End Namespace
