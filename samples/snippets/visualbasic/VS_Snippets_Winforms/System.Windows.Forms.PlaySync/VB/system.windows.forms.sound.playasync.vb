Imports System
Imports System.Drawing
Imports System.Media
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form
 Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

End Sub
 'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerNonUserCode()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        Me.Text = "Form1"
    End Sub

    Friend Shared Readonly Property GetInstance as Form1
        Get
        	if m_DefaultInstance is nothing OrElse m_DefaultInstance.IsDisposed() Then
				SyncLock m_SyncObject
					if m_DefaultInstance is nothing OrElse m_DefaultInstance.IsDisposed() Then
						m_DefaultInstance = new Form1
					end if
				End SyncLock
			End If
			return m_DefaultInstance
        End Get
    End Property

    Private Shared m_DefaultInstance as Form1
    Private Shared m_SyncObject as new Object

'<Snippet1>
Private WithEvents Player As New SoundPlayer

Sub LoadSoundAsync()
    ' Note: You may need to change the location specified based on
    ' the location of the sound to be played.
    Me.Player.SoundLocation = "http://www.tailspintoys.com/sounds/stop.wav"
    Me.Player.LoadAsync ()
End Sub

Private Sub PlayWhenLoaded(ByVal sender As Object, ByVal e As _
    System.ComponentModel.AsyncCompletedEventArgs) Handles _
    Player.LoadCompleted
    If Me.Player.IsLoadCompleted = True Then
            Me.Player.PlaySync()
    End If
End Sub
'</Snippet1>

 <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class