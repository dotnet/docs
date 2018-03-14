 '<Snippet2>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Design
Imports System.Data
Imports System.Windows.Forms

<System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
Public Class ToolboxCategoryNamesControl
    Inherits System.Windows.Forms.UserControl
    Private toolboxService As System.Drawing.Design.IToolboxService
    Private categoryNames As System.Drawing.Design.CategoryNameCollection

    Public Sub New()
        Me.BackColor = System.Drawing.Color.Beige
        Me.Name = "Category Names Display Control"
        Me.Size = New System.Drawing.Size(264, 200)
    End Sub

    ' Obtain or reset IToolboxService reference on each siting of control.
    Public Overrides Property Site() As System.ComponentModel.ISite
        Get
            Return MyBase.Site
        End Get
        Set(ByVal Value As System.ComponentModel.ISite)
            MyBase.Site = Value

            ' If the component was sited, attempt to obtain 
            ' an IToolboxService instance.
            If (MyBase.Site IsNot Nothing) Then
                toolboxService = CType(Me.GetService(GetType(IToolboxService)), IToolboxService)
                ' If an IToolboxService was located, update the category list.
                If (toolboxService IsNot Nothing) Then
                    categoryNames = toolboxService.CategoryNames
                End If
            Else
                toolboxService = Nothing
            End If
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If (categoryNames IsNot Nothing) Then
            e.Graphics.DrawString("IToolboxService category names list:", New Font("Arial", 9), Brushes.Black, 10, 10)

            '<Snippet1>                
            ' categoryNames is a CategoryNameCollection obtained from 
            ' the IToolboxService. CategoryNameCollection is a read-only 
            ' string collection.                                
            ' Output each category name in the CategoryNameCollection.                                                
            Dim i As Integer
            For i = 0 To categoryNames.Count - 1
                e.Graphics.DrawString(categoryNames(i), New Font("Arial", 8), Brushes.Black, 10, 24 + 10 * i)
            Next i
            '</Snippet1>
        End If
    End Sub

End Class
'</Snippet2>