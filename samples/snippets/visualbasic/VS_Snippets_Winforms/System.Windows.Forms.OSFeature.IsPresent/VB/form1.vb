'<Snippet1>
Imports System
Imports System.Drawing
Imports System.ComponentModel
Imports System.Windows.Forms
'</Snippet1>

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Shared Sub Main(args as String())
        Application.EnableVisualStyles()

        Application.Run(new Form1())
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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

    Friend Shared ReadOnly Property GetInstance() As Form1
        Get
            If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                SyncLock m_SyncObject
                    If m_DefaultInstance Is Nothing OrElse m_DefaultInstance.IsDisposed() Then
                        m_DefaultInstance = New Form1
                    End If
                End SyncLock
            End If
            Return m_DefaultInstance
        End Get
    End Property

    Private Shared m_DefaultInstance As Form1
    Private Shared m_SyncObject As New Object
#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox(GetCaretWidth)
    End Sub
    '<Snippet2>
    ' Gets the caret width based upon the operating system or default value.
    Private Function GetCaretWidth() As Integer

        ' Check to see if the operating system supports the caret width metric. 
        If OSFeature.IsPresent(SystemParameter.CaretWidthMetric) Then

            ' If the operating system supports this metric,
            ' return the value for the caret width metric. 

            Return SystemInformation.CaretWidth
        Else

            ' If the operating system does not support this metric,
            ' return a custom default value for the caret width.

            Return 1
        End If
    End Function
    '</Snippet2>

End Class
