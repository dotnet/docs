If (Context.IsEnabled)
 
   Dim I As Integer
   For I = 0 To DS.Tables("Categories").Rows.Count - 1
 
     Trace.Write("ProductCategory",DS.Tables("Categories").Rows(I)(0).ToString())
   Next
 End If
   