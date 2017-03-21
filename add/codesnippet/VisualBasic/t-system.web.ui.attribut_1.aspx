  Dim myAttributeCollection As AttributeCollection = Nothing 

  Sub Page_Load(sender As Object, e As EventArgs)
      myAttributeCollection = New AttributeCollection(ViewState)
      Response.Write("<h3> AttributeCollection.AttributeCollection Sample </h3>")
      If Not IsPostBack Then
         myAttributeCollection.Add("Color", "Color.Red")
         myAttributeCollection.Add("BackColor", "Color.blue")
         Response.Write("Attribute Collection count before PostBack = " & _
myAttributeCollection.Count.ToString())
         Response.Write("<br /><u><h4>Enumerating Attributes for " & _
                                 "CustomControl before PostBack</h4></u>")
         Dim keys As IEnumerator = myAttributeCollection.Keys.GetEnumerator()
         Dim i As Integer = 1
         Dim key As String
         While keys.MoveNext()
            key = CType(keys.Current, String)
            Response.Write(i.ToString() + ". " + key + "=" + myAttributeCollection(key) + "<br />")
            i += 1
         End While
      Else
         Response.Write("Attribute Collection  count after PostBack = " + _
                                    myAttributeCollection.Count.ToString())
         Response.Write("<br /><u><h4>Enumerating Attributes for " + _
                                 "CustomControl after PostBack</h4></u>")
         Dim keys As IEnumerator = myAttributeCollection.Keys.GetEnumerator()
         Dim i As Integer = 1
         Dim key As String
         While keys.MoveNext()
            key = CType(keys.Current, String)
            Response.Write(i.ToString() + ". " + key + "=" + myAttributeCollection(key) + "<br />")
            i += 1
         End While
      End If
   End Sub