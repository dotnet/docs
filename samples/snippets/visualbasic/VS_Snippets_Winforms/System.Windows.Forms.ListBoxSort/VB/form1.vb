'<snippet1>

Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SortByLengthListBox1 = New SortByLengthListBox
        Me.SuspendLayout()
        Me.Button1.Location = New System.Drawing.Point(64, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(176, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click me for list sorted by length"
        Me.SortByLengthListBox1.Items.AddRange(New Object() {"System", _
            "System.Windows.Forms", "System.Xml", _
            "System.Net", "System.Drawing", "System.IO"})
        Me.SortByLengthListBox1.Location = New System.Drawing.Point(72, 48)
        Me.SortByLengthListBox1.Name = "SortByLengthListBox1"
        Me.SortByLengthListBox1.Size = New System.Drawing.Size(120, 95)
        Me.SortByLengthListBox1.TabIndex = 1
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.SortByLengthListBox1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Sort Example"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SortByLengthListBox1 As SortByLengthListBox

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click

        ' Set the Sorted property to True to raise the overridden Sort
        ' method.
        SortByLengthListBox1.Sorted = True
    End Sub
End Class

' This class inherits from ListBox and implements a different 
' sorting method. Sort will be called by setting the class's Sorted
' property to True.
Public Class SortByLengthListBox
    Inherits ListBox

    Public Sub New()
        MyBase.New()
    End Sub

    ' Overrides the parent class Sort to perform a simple
    ' bubble sort on the length of the string contained in each item.
    Protected Overrides Sub Sort()
        If (Items.Count > 1) Then

            Dim swapped As Boolean

            Do
                Dim counter As Integer = Items.Count - 1
                swapped = False
                While (counter > 0)

                    ' Compare the items' length.
                    If Items(counter).ToString.Length < _
                       Items(counter - 1).ToString.Length Then

                        ' If true, swap the items.
                        Dim temp As Object = Items(counter)
                        Items(counter) = Items(counter - 1)
                        Items(counter - 1) = temp
                        swapped = True

                    End If
                    ' Decrement the counter.
                    counter -= 1
                End While
            Loop While (swapped = True)
        End If
    End Sub

End Class
'</snippet1>
