 Private Sub ClearAllBindings()
     Dim c As Control
     For Each c In  groupBox1.Controls
         c.DataBindings.Clear()
     Next c
 End Sub