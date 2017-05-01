' <Snippet1>
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization



Public Class Enterprises
    Private mywineries() As Winery
    Private mycompanies() As VacationCompany
    ' Sets the Form property to qualified, and specifies the Namespace. 
    
    <XmlArray(Form := XmlSchemaForm.Qualified, _
        ElementName := "Company", _
        Namespace := "http://www.cohowinery.com")> _
    Public Property Wineries() As Winery()
        
        Get
            Return mywineries
        End Get
        Set
            mywineries = value
        End Set
    End Property 
    
    <XmlArray(Form := XmlSchemaForm.Qualified, _
        ElementName := "Company", _
        Namespace := "http://www.treyresearch.com")> _ 
    Public Property Companies() As VacationCompany()
        
        Get
            Return mycompanies
        End Get
        Set
            mycompanies = value
        End Set
    End Property
End Class 'Enterprises
 
Public Class Winery
    Public Name As String
End Class 'Winery


Public Class VacationCompany
    Public Name As String
End Class 'VacationCompany


Public Class Run
    
    Public Shared Sub Main()
        Dim test As New Run()
        test.WriteEnterprises("MyEnterprises.xml")
    End Sub 'Main
    
    
    Public Sub WriteEnterprises(filename As String)
        ' Creates an instance of the XmlSerializer class.
        Dim mySerializer As New XmlSerializer(GetType(Enterprises))
        ' Writing a file requires a TextWriter.
        Dim writer As New StreamWriter(filename)
        
        ' Creates an instance of the XmlSerializerNamespaces class.
        Dim ns As New XmlSerializerNamespaces()
        
        ' Adds namespaces and prefixes for the XML document instance.
        ns.Add("winery", "http://www.cohowinery.com")
        ns.Add("vacationCompany", "http://www.treyresearch.com")
        
        ' Creates an instance of the class that will be serialized.
        Dim myEnterprises As New Enterprises()
        
        ' Creates objects and adds to the array. 
        Dim w1 As New Winery()
        w1.Name = "cohowinery"
        Dim myWinery(0) As Winery
        myWinery(0) = w1
        myEnterprises.Wineries = myWinery
        
        Dim com1 As New VacationCompany()
        com1.Name = "adventure-works"
        Dim myCompany(0) As VacationCompany
        myCompany(0) = com1
        myEnterprises.Companies = myCompany
        
        ' Serializes the class, and closes the TextWriter.
        mySerializer.Serialize(writer, myEnterprises, ns)
        writer.Close()
    End Sub 'WriteEnterprises
    
    
    Public Sub ReadEnterprises(filename As String)
        Dim mySerializer As New XmlSerializer(GetType(Enterprises))
        Dim fs As New FileStream(filename, FileMode.Open)
        Dim myEnterprises As Enterprises = CType(mySerializer.Deserialize(fs), Enterprises)
        
        Dim i As Integer
        For i = 0 To myEnterprises.Wineries.Length - 1
            Console.WriteLine(myEnterprises.Wineries(i).Name)
        Next i
        For i = 0 To myEnterprises.Companies.Length - 1
            Console.WriteLine(myEnterprises.Companies(i).Name)
        Next i
    End Sub 'ReadEnterprises
End Class 'Run
' </Snippet1>
