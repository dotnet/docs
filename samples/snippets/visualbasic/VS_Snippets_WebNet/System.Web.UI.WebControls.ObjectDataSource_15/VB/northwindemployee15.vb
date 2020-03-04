 ' <snippet2>
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB
  Public Class EmployeeLogic
    
    
    Public Sub New() 
        Throw New NotSupportedException("Initialize data.")
    
    End Sub
    
    
    Public Sub New(ByVal data As String) 
        _data = data
    
    End Sub
    
    Private _data As String
    
    
    ' Returns a collection of NorthwindEmployee objects.
    Public Function GetAllEmployees() As ICollection 
        Dim al As New ArrayList()
        al.Add(_data)
        Return al
    
    End Function 'GetAllEmployees
  End Class
End Namespace ' Samples.AspNet.VB
' </snippet2>