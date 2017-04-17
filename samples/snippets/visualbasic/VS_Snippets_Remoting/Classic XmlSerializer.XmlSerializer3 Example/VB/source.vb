' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization



' This defines the object that will be serialized.
Public Class Teacher
    Public Name As String
    
    Public Sub New()
    End Sub 'New 
    ' Note that the Info field returns an array of objects.
    ' Any object can be added to the array by adding the
    ' object type to the array passed to the extraTypes argument. 
    <XmlArray(ElementName := "ExtraInfo", IsNullable := True)> _
    Public Info() As Object
    Public PhoneInfo As Phone
End Class 'Teacher


' This defines one of the extra types to be included.
Public Class Address
    Public City As String
    
    Public Sub New()
    End Sub 'New
    
    Public Sub New(city As String)
        me.City = city
    End Sub 'New
End Class 'Address
 

' Another extra type to include.
Public Class Phone
    Public PhoneNumber As String
    
    Public Sub New()
    End Sub 'New
    
    Public Sub New(phoneNumber As String)
        me.PhoneNumber = phoneNumber
    End Sub 'New
End Class 'Phone


' Another type, derived from Phone.
Public Class InternationalPhone
    Inherits Phone
    Public CountryCode As String
    
    
    Public Sub New()
    End Sub 'New
     
    Public Sub New(countryCode As String)
        me.CountryCode = countryCode
    End Sub 'New
End Class 'InternationalPhone


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.SerializeObject("Teacher.xml")
        test.DeserializeObject("Teacher.xml")
    End Sub 'Main
    
    
    Private Sub SerializeObject(filename As String)
        ' Writing the file requires a TextWriter.
        Dim myStreamWriter As New StreamWriter(filename)
        
        ' Create a Type array.
        Dim extraTypes(2) As Type
        extraTypes(0) = GetType(Address)
        extraTypes(1) = GetType(Phone)
        extraTypes(2) = GetType(InternationalPhone)
        
        ' Create the XmlSerializer instance.
        Dim mySerializer As New XmlSerializer(GetType(Teacher), extraTypes)
        
        Dim teacher As New Teacher()
        teacher.Name = "Mike"
        ' Add extra types to the Teacher object.
        Dim info(1) As Object
        info(0) = New Address("Springville")
        info(1) = New Phone("555-0100")
        
        teacher.Info = info
        
        teacher.PhoneInfo = New InternationalPhone("000")
        
        mySerializer.Serialize(myStreamWriter, teacher)
        myStreamWriter.Close()
    End Sub 'SerializeObject
    
    
    Private Sub DeserializeObject(filename As String)
        ' Create a Type array.
        Dim extraTypes(2) As Type
        extraTypes(0) = GetType(Address)
        extraTypes(1) = GetType(Phone)
        extraTypes(2) = GetType(InternationalPhone)
        
        ' Create the XmlSerializer instance.
        Dim mySerializer As New XmlSerializer(GetType(Teacher), extraTypes)
        
        ' Reading a file requires a FileStream.
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim teacher As Teacher = CType(mySerializer.Deserialize(fs), Teacher)
        
        ' Read the extra information.
        Dim a As Address = CType(teacher.Info(0), Address)
        Dim p As Phone = CType(teacher.Info(1), Phone)
        Dim Ip As InternationalPhone = CType(teacher.PhoneInfo, InternationalPhone)
        
        Console.WriteLine(teacher.Name)
        Console.WriteLine(a.City)
        Console.WriteLine(p.PhoneNumber)
        Console.WriteLine(Ip.CountryCode)
    End Sub 'DeserializeObject
End Class 'Run
' </Snippet1>
