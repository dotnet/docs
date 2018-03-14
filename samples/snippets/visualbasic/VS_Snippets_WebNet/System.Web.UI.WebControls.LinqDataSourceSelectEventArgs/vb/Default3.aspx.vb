Imports System.Data.Linq
Imports System.Linq

'<Snippet3>
Partial Class Default3
    Inherits System.Web.UI.Page

    Dim citiesArray() As String = _
    { _
        "Atlanta", _
        "Charlotte", _
        "Denver", _
        "New York", _
        "San Francisco" _
    }


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
    End Sub

    
    Protected Sub LinqDataSource_Selecting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.LinqDataSourceSelectEventArgs) Handles LinqDataSource1.Selecting
        Dim cities = From city In citiesArray _
                     Where city > "B" _
                     Select city
        e.Result = cities
        ' Or we could set e.Result = citiesArray to return all rows.
    End Sub
    
End Class
'</Snippet3>
