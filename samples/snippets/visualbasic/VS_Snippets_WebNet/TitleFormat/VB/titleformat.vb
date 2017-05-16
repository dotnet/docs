Imports System.Web.UI.WebControls

Namespace PageLoadExample
   Class Class1
      Dim Calendar1 as new Calendar()
      ' <snippet1>
      Private Sub Page_Load(sender As Object, e As System.EventArgs)
         ' Change the title format of Calendar1.
         Calendar1.TitleFormat = TitleFormat.Month
      End Sub 'Page_Load
      ' </snippet1>
   End Class
End Namespace