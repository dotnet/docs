 Private Sub RejectChangesInDataSet()
     ' Instantiate the derived DataSet.
     Dim derivedData As DerivedDataSet
     derivedData = New DerivedDataSet()

    ' Insert code to change values.

    ' Invoke the RejectChanges method in the derived class.
    derivedData.RejectDataSetChanges()
 End Sub
    
 Public Class DerivedDataSet
     Inherits System.Data.DataSet
      
     Public Sub RejectDataSetChanges()
         ' Invoke the RejectChanges method.
         Me.RejectChanges()
     End Sub
  End Class