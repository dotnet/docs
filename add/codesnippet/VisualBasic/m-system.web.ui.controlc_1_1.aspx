    ' Create a method that enuberates through a 
    ' button's ControlCollection in a thread-safe manner.  
    Public Sub ListControlCollection(sender As Object, e As EventArgs)
       Dim myEnumerator As IEnumerator = myButton.Controls.GetEnumerator()

       ' Check the IsSynchronized property. If False,
       ' use the SyncRoot method to get an object that 
       ' allows the enumeration of all controls to be 
       ' thread safe.
       If myButton.Controls.IsSynchronized = False Then
         SyncLock myButton.Controls.SyncRoot
           While (myEnumerator.MoveNext())
    
           Dim myObject As Object  = myEnumerator.Current
               
             Dim childControl As LiteralControl = CType(myEnumerator.Current, LiteralControl)
             Response.Write("<b><br /> This is the  text of the child Control  </b>: " & _
                            childControl.Text)
           End While
          msgReadOnly.Text = myButton.Controls.IsReadOnly.ToString()
          
          End SyncLock
       End If       
     End Sub