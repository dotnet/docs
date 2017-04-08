
Imports System
Imports System.ComponentModel
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.Design.WebControls
Imports System.Drawing

Namespace Examples.AspNet
' <snippet3>
     ' Create a class that uses the StyledTableDesigner
     ' class to display its contents at design time.
    <Designer("Examples.AspNet.Design.StyledTableDesigner", "TableDesigner")> _
    Public Class StyledTable
      Inherits Table 
        

        Private tableStyle As Style = New Style()
        
        Public Sub New()
           tableStyle.BackColor = Color.LightBlue
           tableStyle.BorderColor = Color.Black
           
           CellSpacing = 4
           CellPadding = 0
           GridLines = GridLines.None
           BorderWidth = Unit.Point(1)
           Width = Unit.Percentage(100)
           Height = Unit.Percentage(100)

        End Sub
    End Class
' </snippet3> 
End Namespace
