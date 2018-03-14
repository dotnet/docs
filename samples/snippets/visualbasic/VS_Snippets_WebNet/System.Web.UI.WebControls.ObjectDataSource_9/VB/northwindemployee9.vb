' <snippet2>
Imports System
Imports System.Collections
Imports System.Data
Imports System.Web.UI.WebControls

Namespace Samples.AspNet.VB
'
' EmployeeLogic is a stateless business object that encapsulates 
' the operations you can perform on a NorthwindEmployee object.
'
Public Class EmployeeLogic
   
   ' Returns a collection of NorthwindEmployee objects.
   Public Shared Function GetAllEmployees() As ICollection
      Dim data As New ArrayList()
      
      data.Add(New NorthwindEmployee(1, "Nancy", "Davolio", "507 - 20th Ave. E. Apt. 2A"))
      data.Add(New NorthwindEmployee(2, "Andrew", "Fuller", "908 W. Capital Way"))
      data.Add(New NorthwindEmployee(3, "Janet", "Leverling", "722 Moss Bay Blvd."))
      data.Add(New NorthwindEmployee(4, "Margaret", "Peacock", "4110 Old Redmond Rd."))
      data.Add(New NorthwindEmployee(5, "Steven", "Buchanan", "14 Garrett Hill"))
      data.Add(New NorthwindEmployee(6, "Michael", "Suyama", "Coventry House Miner Rd."))
      data.Add(New NorthwindEmployee(7, "Robert", "King", "Edgeham Hollow Winchester Way"))
      
      Return data
   End Function 'GetAllEmployees
   
   
   Public Shared Function GetEmployee(anID As Object) As NorthwindEmployee
      Dim data As ArrayList = CType(GetAllEmployees(), ArrayList)
      Dim empID As Integer = Int32.Parse(anID.ToString())
      Return CType(data(empID),NorthwindEmployee)   
   End Function 'GetEmployee
   
   
   ' To support basic filtering, the employees cannot
   ' be returned as an array of objects, rather as a 
   ' DataSet of the raw data values. 
   Public Shared Function GetAllEmployeesAsDataSet() As DataSet
      Dim employees As ICollection = GetAllEmployees()
      
      Dim ds As New DataSet("Table")
      
      ' Create the schema of the DataTable.
      Dim dt As New DataTable()
      Dim dc As DataColumn
      dc = New DataColumn("EmpID", GetType(Integer))
      dt.Columns.Add(dc)
      dc = New DataColumn("FullName", GetType(String))
      dt.Columns.Add(dc)
      dc = New DataColumn("Address", GetType(String))
      dt.Columns.Add(dc)
      
      ' Add rows to the DataTable.
      Dim row As DataRow
      Dim ne As NorthwindEmployee
      For Each ne In employees         
         row = dt.NewRow()
         row("EmpID") = ne.EmpID
         row("FullName") = ne.FullName
         row("Address") = ne.Address
         dt.Rows.Add(row)
      Next
      ' Add the complete DataTable to the DataSet.
      ds.Tables.Add(dt)
      
      Return ds
   End Function 'GetAllEmployeesAsDataSet
      
End Class 'EmployeeLogic 


Public Class NorthwindEmployee
   
   Public Sub New(anID As Integer, aFirstName As String, aLastName As String, anAddress As String)
      ID = anID
      Me.aFirstName = aFirstName
      Me.aLastName = aLastName
      Me.aAddress = anAddress
   End Sub 'New
   
   Private ID As Object   
   Public ReadOnly Property EmpID() As String
      Get
         Return ID.ToString()
      End Get
   End Property 

   Private aLastName As String   
   Public Property LastName() As String
      Get
         Return aLastName
      End Get
      Set
         aLastName = value
      End Set
   End Property 

   Private aFirstName As String   
   Public Property FirstName() As String
      Get
         Return aFirstName
      End Get
      Set
         aFirstName = value
      End Set
   End Property 
   
   Public ReadOnly Property FullName() As String
      Get
         Return FirstName & " " & LastName
      End Get
   End Property 
  
   Private aAddress As String  
   Public Property Address() As String
      Get
         Return aAddress
      End Get
      Set
         aAddress = value
      End Set
   End Property 
   
End Class 'NorthwindEmployee
End Namespace
' </snippet2>