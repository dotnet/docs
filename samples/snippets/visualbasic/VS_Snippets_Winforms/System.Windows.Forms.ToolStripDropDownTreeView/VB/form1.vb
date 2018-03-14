 '<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Security.Permissions

Public Class Form1
   Inherits Form
   
   Public Sub New()
      Dim treeCombo As New MyTreeViewCombo()
        treeCombo.MyTreeView.Nodes.Add("one")
        treeCombo.MyTreeView.Nodes.Add("two")
        treeCombo.MyTreeView.Nodes.Add("three")
      Me.Controls.Add(treeCombo)
   End Sub
   
   <STAThread()>  _
   Shared Sub Main()
      Application.EnableVisualStyles()
      Application.SetCompatibleTextRenderingDefault(False)
      Application.Run(New Form1())
   End Sub

    <SecurityPermissionAttribute( _
         SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.UnmanagedCode)> _
   Public Class MyTreeViewCombo
        Inherits ComboBox

        Private treeViewHost As ToolStripControlHost
        Private Shadows dropDown As ToolStripDropDown

        Public Sub New()

            Dim treeView As New TreeView()
            treeView.BorderStyle = BorderStyle.None
            treeViewHost = New ToolStripControlHost(treeView)
            dropDown = New ToolStripDropDown()
            dropDown.Items.Add(treeViewHost)
        End Sub

        Public ReadOnly Property MyTreeView() As TreeView
            Get
                Return treeViewHost.Control '
            End Get
        End Property

        Private Sub ShowDropDown()
            If Not (dropDown Is Nothing) Then
                treeViewHost.Width = DropDownWidth
                treeViewHost.Height = DropDownHeight
                dropDown.Show(Me, 0, Me.Height)
            End If
        End Sub

        Private Const WM_USER As Integer = &H400
        Private Const WM_REFLECT As Integer = WM_USER + &H1C00
        Private Const WM_COMMAND As Integer = &H111
        Private Const CBN_DROPDOWN As Integer = 7

        Public Shared Function HIWORD(ByVal n As Integer) As Integer
            Return (n >> 16) And &HFFFF
        End Function

        Protected Overrides Sub WndProc(ByRef m As Message)
            If m.Msg = WM_REFLECT + WM_COMMAND Then
                If HIWORD(CType(m.WParam, Integer)) = CBN_DROPDOWN Then
                    ShowDropDown()
                    Return
                End If
            End If
            MyBase.WndProc(m)
        End Sub

        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (dropDown Is Nothing) Then
                    dropDown.Dispose()
                    dropDown = Nothing
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub
    End Class
End Class
'</Snippet1>