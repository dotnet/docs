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