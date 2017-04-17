Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeOwnerDrawnListBox()
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

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        Me.SuspendLayout()
        '
        'ListBox1
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)

        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    '<snippet1>
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

    Private Sub InitializeOwnerDrawnListBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox

        ' Set the location and size.
        ListBox1.Location = New Point(20, 20)
        ListBox1.Size = New Size(240, 240)

        ' Populate the ListBox.ObjectCollection property 
        ' with several strings, using the AddRange method.
        Me.ListBox1.Items.AddRange(New Object() _
            {"System.Windows.Forms", "System.Drawing", "System.Xml", _
            "System.Net", "System.Runtime.Remoting", "System.Web"})

        ' Turn off the scrollbar.
        ListBox1.ScrollAlwaysVisible = False

        ' Set the border style to a single, flat border.
        ListBox1.BorderStyle = BorderStyle.FixedSingle

        ' Set the DrawMode property to the OwnerDrawVariable value. 
        ' This means the MeasureItem and DrawItem events must be 
        ' handled.
        ListBox1.DrawMode = DrawMode.OwnerDrawVariable
        Me.Controls.Add(Me.ListBox1)
    End Sub


    ' Handle the DrawItem event for an owner-drawn ListBox.
    Private Sub ListBox1_DrawItem(ByVal sender As Object, _
        ByVal e As DrawItemEventArgs) Handles ListBox1.DrawItem

        ' If the item is the selected item, then draw the rectangle filled in
        ' blue. The item is selected when a bitwise And of the State property
        ' and the DrawItemState.Selected property is true. 
        If (e.State And DrawItemState.Selected = DrawItemState.Selected) Then
            e.Graphics.FillRectangle(Brushes.CornflowerBlue, e.Bounds)
        Else
            ' Otherwise, draw the rectangle filled in beige.
            e.Graphics.FillRectangle(Brushes.Beige, e.Bounds)
        End If

        ' Draw a rectangle in blue around each item.
        e.Graphics.DrawRectangle(Pens.Blue, e.Bounds)

        ' Draw the text in the item.
        e.Graphics.DrawString(Me.ListBox1.Items(e.Index), Me.Font, _
            Brushes.Black, e.Bounds.X, e.Bounds.Y)

        ' Draw the focus rectangle around the selected item.
        e.DrawFocusRectangle()
    End Sub

    ' Handle the MeasureItem event for an owner-drawn ListBox.
    Private Sub ListBox1_MeasureItem(ByVal sender As Object, _
        ByVal e As MeasureItemEventArgs) Handles ListBox1.MeasureItem

        ' Cast the sender object back to ListBox type.
        Dim theListBox As ListBox = CType(sender, ListBox)

        ' Get the string contained in each item.
        Dim itemString As String = CType(theListBox.Items(e.Index), String)

        ' Split the string at the " . "  character.
        Dim resultStrings() As String = itemString.Split(".")

        ' If the string contains more than one period, increase the 
        ' height by ten pixels; otherwise, increase the height by 
        ' five pixels.
        If (resultStrings.Length > 2) Then
            e.ItemHeight += 10
        Else
            e.ItemHeight += 5
        End If

    End Sub

    '</snippet1>

    <System.STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub



End Class
