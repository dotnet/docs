Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

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
    'It can be modified Imports the Windows Form Designer.  
    'Do not modify it Imports the code editor.
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
#End Region

#Region "DataGridViewContentAlignment"
    Dim songsDataGridView As New DataGridView()

    ' The below example shows how to change the alignment of columns of data.  The example requires a form with 
    ' a DataGridView named songsDataGridView that is populated with some data.
    '<snippet1>
    Private Sub ChangeColumnAlignment()
        songsDataGridView.Columns("Title").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        songsDataGridView.Columns("Title").Name = DataGridViewContentAlignment.BottomCenter.ToString()

        songsDataGridView.Columns("Artist").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        songsDataGridView.Columns("Artist").Name = DataGridViewContentAlignment.BottomLeft.ToString()

        songsDataGridView.Columns("Album").DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight
        songsDataGridView.Columns("Album").Name = DataGridViewContentAlignment.BottomRight.ToString()

        songsDataGridView.Columns("Release Date").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        songsDataGridView.Columns("Release Date").Name = DataGridViewContentAlignment.MiddleCenter.ToString()

        songsDataGridView.Columns("Track").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
        songsDataGridView.Columns("Track").Name = DataGridViewContentAlignment.MiddleLeft.ToString()
    End Sub
    '</snippet1>
#End Region

    <STAThreadAttribute()> _
    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

End Class
