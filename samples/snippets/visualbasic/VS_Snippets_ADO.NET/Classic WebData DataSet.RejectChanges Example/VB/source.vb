Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
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
' </Snippet1>
End Class 'Form1 



