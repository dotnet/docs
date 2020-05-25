Imports System.Collections.ObjectModel
Imports System.AddIn.Hosting
Imports System.Windows

Imports HostViews

Namespace Host
	Partial Public Class MainWindow
		Inherits Window
		Private wpfAddInHostView As IWPFAddInHostView

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub fileExitMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Me.Close()
		End Sub

		Private Sub loadAddInUIMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            '<SnippetGetUICode>
            ' Get add-in pipeline folder (the folder in which this application was launched from)
            Dim appPath As String = Environment.CurrentDirectory

            ' Rebuild visual add-in pipeline
            Dim warnings() As String = AddInStore.Rebuild(appPath)
            If warnings.Length > 0 Then
                Dim msg As String = "Could not rebuild pipeline:"
                For Each warning As String In warnings
                    msg &= vbLf & warning
                Next warning
                MessageBox.Show(msg)
                Return
            End If

            ' Activate add-in with Internet zone security isolation
            Dim addInTokens As Collection(Of AddInToken) = AddInStore.FindAddIns(GetType(IWPFAddInHostView), appPath)
            Dim wpfAddInToken As AddInToken = addInTokens(0)
            Me.wpfAddInHostView = wpfAddInToken.Activate(Of IWPFAddInHostView)(AddInSecurityLevel.Internet)

            ' Get and display add-in UI
            Dim addInUI As FrameworkElement = Me.wpfAddInHostView.GetAddInUI()
            Me.addInUIHostGrid.Children.Add(addInUI)
            '</SnippetGetUICode>
		End Sub

		Private Sub unloadAddInUIMenuItem_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Stop displyaing add-in UI
			Me.addInUIHostGrid.Children.Clear()

			' Unload add-in
			Dim addInController As AddInController = AddInController.GetAddInController(Me.wpfAddInHostView)
			addInController.Shutdown()
		End Sub
	End Class
End Namespace
'</SnippetHostAppMainWindowCodeBehind>
