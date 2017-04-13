
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
'''This sample demonstrates how to apply non-storyboard animations to a property.
'''To animate in markup, you must use storyboards.
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Shapes
Imports System.Windows.Controls

Namespace Microsoft.Samples.Animation.LocalAnimations

    
    ' Displays the sample.
    Public Class app
    	Inherits Application
        
	Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
            MyBase.OnStartup(e)
            CreateAndShowMainWindow()
        End Sub
        
        Private Sub CreateAndShowMainWindow()
        
            ' Create the application's main window.
            Dim sViewer As New SampleViewer()
            MainWindow = sViewer
            sViewer.Show()
        End Sub        
        

    End Class
    
    Public Class SampleViewer
    	Inherits Window
    
    
        Public Sub New()
        
            Dim tControl As New TabControl()
            Dim tItem As New TabItem()
            tItem.Header = "Local Animation Example"
            Dim contentFrame As New Frame()
            contentFrame.Content = New LocalAnimationExample()
            tItem.Content = contentFrame
            tControl.Items.Add(tItem)
            tItem = New TabItem()
            tItem.Header = "Interactive Animation Example"
            contentFrame = New Frame()
            contentFrame.Content = New InteractiveAnimationExample()
            tItem.Content = contentFrame
            tControl.Items.Add(tItem)
            
            Me.Content = tControl
            Me.Title = "Local Animations Example"
        
        End Sub
    
    End Class  

    ' Starts the application.
    Public NotInheritable Class EntryClass

        Public Shared Sub Main()
            Dim app As New app()
            app.Run()
        End Sub
    End Class
End Namespace
