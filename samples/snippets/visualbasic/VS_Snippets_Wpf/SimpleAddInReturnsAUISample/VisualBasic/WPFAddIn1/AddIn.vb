'<SnippetAddInCode>

Imports System.AddIn ' AddInAttribute
Imports System.Windows ' FrameworkElement

Imports AddInViews ' IWPFAddInView

Namespace WPFAddIn1
	''' <summary>
	''' Add-In implementation
	''' </summary>
	<AddIn("WPF Add-In 1")>
	Public Class WPFAddIn
        Implements IWPFAddInView
        Public Function GetAddInUI() As FrameworkElement Implements IWPFAddInView.GetAddInUI
            ' Return add-in UI
            Return New AddInUI()
        End Function
	End Class
End Namespace
'</SnippetAddInCode>