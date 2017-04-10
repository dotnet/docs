 ' <snippet2>
Imports System
Imports System.Collections
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB

  Public Class EmployeeLogic
    
    
    Public Sub New() 
        MyClass.New(DateTime.Now)
    
    End Sub 'New
    
    
    Public Sub New(ByVal creationTime As DateTime) 
        _creationTime = creationTime
    
    End Sub 'New
    
    Private _creationTime As DateTime
    
    
    ' Returns a collection of NorthwindEmployee objects.
    Public Function GetCreateTime() As ICollection 
        Dim al As New ArrayList()
        
        ' Returns creation time for this example.      
        al.Add("The business object that you are using was created at " + _creationTime)
        
        Return al
    
    End Function 'GetCreateTime
  End Class 'EmployeeLogic
End Namespace ' Samples.AspNet.VB
' </snippet2>