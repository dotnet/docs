Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Security.Permissions
<assembly: SecurityPermission(SecurityAction.RequestMinimum, Execution := True)>

'<snippet1>
' The constructor names the method that returns an array 
' of types that can be used during deserialization.
<KnownTypeAttribute("KnownTypes"), DataContract()>  _
Public Class Employee
    Public Sub New(ByVal newFName As String, ByVal newLName As String) 
        FirstName = newFName
        LastName = newLName
    
    End Sub 'New
    <DataMember()>  _
    Friend FirstName As String
    <DataMember()>  _
    Friend LastName As String
    <DataMember()>  _
    Friend id As Integer
    <DataMember()>  _
    Friend Boss As Manager
    
    ' This method returns the array of known types.
    Shared Function KnownTypes() As Type() 
        Return New Type() {GetType(Manager), GetType(Employee)}
    
    End Function 
End Class 

<DataContract()>  _
Public Class Manager
    Inherits Employee
    
    ' Call the base class's constructor.
    Public Sub New(ByVal newFName As String, ByVal newLName As String) 
        MyBase.New(newFName, newLName)
    
    End Sub 
    
    <DataMember()>  _
    Friend Reports() As Employee
End Class 

Class Program

    Public Shared Sub Main() 
        Try
            Serialize("person1.xml")
            Deserialize("person1.xml")
        Catch se As SerializationException
            Console.WriteLine("{0}: {1}", se.Message, se.StackTrace)
        Finally
            Console.WriteLine("Press Enter to exit....")
            Console.ReadLine()
        End Try
    
    End Sub 
    
    Shared Sub Serialize(ByVal path As String) 
        Dim emp As New Employee("John", "Peoples")
        emp.id = 3001
        Dim theBoss As New Manager("Michiyo", "Sato")
        theBoss.id = 41
        emp.Boss = theBoss

        Dim ser As New DataContractSerializer(GetType(Employee))
        
        Dim fs As New FileStream(path, FileMode.OpenOrCreate)
        ser.WriteObject(fs, emp)
        fs.Close()
    
    End Sub 
    
    Shared Sub Deserialize(ByVal path As String) 
        Dim ser As New DataContractSerializer(GetType(Employee))
        Dim fs As New FileStream(path, FileMode.Open)
        Dim p As Employee = CType(ser.ReadObject(fs), Employee)
        
        Console.WriteLine("{0} {1}, id:{2}", p.FirstName, p.LastName, p.id)
        fs.Close()
    
    End Sub 
End Class 
'</snippet1>