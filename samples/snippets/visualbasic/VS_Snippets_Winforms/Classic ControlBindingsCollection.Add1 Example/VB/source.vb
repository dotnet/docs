Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected textBox1 As TextBox    
    
' <Snippet1>
    Private Sub BindTextBoxProperties()
        ' Clear the collection before adding new Binding objects.
        textBox1.DataBindings.Clear()
        
        ' Create a DataTable containing Color objects.
        Dim t As DataTable = MakeTable()
        
        ' Bind the Text, BackColor, and ForeColor properties
        ' to columns in the DataTable. 
        textBox1.DataBindings.Add("Text", t, "Text")
        textBox1.DataBindings.Add("BackColor", t, "BackColor")
        textBox1.DataBindings.Add("ForeColor", t, "ForeColor")
    End Sub    
    
    Private Function MakeTable() As DataTable
        ' Create a DataTable with three columns.
        ' Two of the columns contain Color objects. 
        
        Dim t As New DataTable("Control")
        t.Columns.Add("BackColor", GetType(Color))
        t.Columns.Add("ForeColor", GetType(Color))
        t.Columns.Add("Text")
        
        ' Add three rows to the table.
        Dim r As DataRow
        
        r = t.NewRow()
        r("BackColor") = Color.Blue
        r("ForeColor") = Color.Yellow
        r("Text") = "Yellow on Blue"
        t.Rows.Add(r)
        
        r = t.NewRow()
        r("BackColor") = Color.White
        r("ForeColor") = Color.Green
        r("Text") = "Green on white"
        t.Rows.Add(r)
        
        r = t.NewRow()
        r("BackColor") = Color.Orange
        r("ForeColor") = Color.Black
        r("Text") = "Black on Orange"
        t.Rows.Add(r)
        
        Return t
    End Function
' </Snippet1>

End Class
