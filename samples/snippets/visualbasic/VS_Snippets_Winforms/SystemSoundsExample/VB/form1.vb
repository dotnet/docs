Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Media
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
    Private components As System.ComponentModel.Container = Nothing
       
    Public Sub New()
        InitializeComponent()
    End Sub 'New
        
    Public Sub PlayAsterisk()
        '<Snippet1>
        ' Plays the sound associated with the Asterisk system event.
        SystemSounds.Asterisk.Play()
        '</Snippet1>                        
    End Sub 'PlayAsterisk     
    
    Public Sub PlayBeep()
        '<Snippet2>
        ' Plays the sound associated with the Beep system event.
        SystemSounds.Beep.Play()
        '</Snippet2>                        
    End Sub 'PlayBeep     
    
    Public Sub PlayExclamation()
        '<Snippet3>
        ' Plays the sound associated with the Exclamation system event.
        SystemSounds.Exclamation.Play()
        '</Snippet3>                        
    End Sub 'PlayExclamation     
    
    Public Sub PlayHand()
        '<Snippet4>
        ' Plays the sound associated with the Hand system event.
        SystemSounds.Hand.Play()
        '</Snippet4>                        
    End Sub 'PlayHand     
    
    Public Sub PlayQuestion()
        '<Snippet5>
        ' Plays the sound associated with the Question system event.
        SystemSounds.Question.Play()
        '</Snippet5>      
    End Sub 'PlayQuestion                   
    
    #Region "Windows Form Designer generated code"
    
    '/ <summary>
    '/ Required method for Designer support - do not modify
    '/ the contents of this method with the code editor.
    '/ </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Size = New System.Drawing.Size(300, 300)
        Me.Text = "Form1"
    End Sub 'InitializeComponent
    
    #End Region    
    
    <STAThread()>  _
    Shared Sub Main()
        Application.Run(New Form1())
    End Sub 'Main
End Class 'Form1