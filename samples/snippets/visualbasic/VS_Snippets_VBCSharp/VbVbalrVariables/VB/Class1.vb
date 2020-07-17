'********************************************************************    
Imports System.Windows.Forms


'********************************************************************    
Public Class Class1


  '********************************************************************    
  Sub TestVariables()


    '********************************************************************    
    '<Snippet2>
    Dim p As Object = New System.Windows.Forms.Label
    Dim q As System.Windows.Forms.Label = New System.Windows.Forms.Label
    Dim j, k As Integer
    ' The following statement generates a compiler error.
    j = p.Left
    ' The following statement retrieves the left edge of the label 
    ' in pixels.
    k = q.Left
    '</Snippet2>


    Dim applesSold As Integer

    '********************************************************************    
    '<Snippet1>
    ' The following statement assigns the value 10 to the variable.
    applesSold = 10
    ' The following statement increments the variable.
    applesSold = applesSold + 1
    ' The variable now holds the value 11.
    '</Snippet1>
  End Sub
End Class
