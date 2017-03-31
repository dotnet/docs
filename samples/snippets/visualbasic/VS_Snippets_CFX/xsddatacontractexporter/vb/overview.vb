 '<snippet0>
Imports System
Imports System.Collections
Imports System.Xml
Imports System.Runtime.Serialization
Imports System.Xml.Schema

Public Class Program
    Public Shared Sub Main() 
        Try
            ExportXSD()
        Catch exc As Exception
            Console.WriteLine("Message: {0} StackTrace:{1}", exc.Message, exc.StackTrace)
        Finally
            Console.ReadLine()
        End Try
    
    End Sub 
    
    
    '<snippet1>
    Shared Sub ExportXSD() 

        Dim exporter As New XsdDataContractExporter()

        ' Use the ExportOptions to add the Possessions type to the 
        ' collection of KnownTypes. 
        Dim eOptions As New ExportOptions()
        eOptions.KnownTypes.Add(GetType(Possessions))        
        exporter.Options = eOptions

        If exporter.CanExport(GetType(Employee)) Then
            exporter.Export(GetType(Employee))
            Console.WriteLine("number of schemas: {0}", exporter.Schemas.Count)
            Console.WriteLine()
            Dim mySchemas As XmlSchemaSet = exporter.Schemas
            
            Dim XmlNameValue As XmlQualifiedName = _
               exporter.GetRootElementName(GetType(Employee))
            Dim EmployeeNameSpace As String = XmlNameValue.Namespace
            
            Dim schema As XmlSchema
            For Each schema In  mySchemas.Schemas(EmployeeNameSpace)
                schema.Write(Console.Out)
            Next schema
        End If
    
    End Sub 
    
    '</snippet1>
    
    '<snippet2>
    Shared Sub GetXmlElementName() 
        Dim myExporter As New XsdDataContractExporter()
        Dim xmlElementName As XmlQualifiedName = myExporter. _
            GetRootElementName(GetType(Employee))
        Console.WriteLine("Namespace: {0}", xmlElementName.Namespace)
        Console.WriteLine("Name: {0}", xmlElementName.Name)
        Console.WriteLine("IsEmpty: {0}", xmlElementName.IsEmpty)
    
    End Sub 
    '</snippet2>
    
    <DataContract([Namespace] := "www.Contoso.com/Examples/")>  _
    Public Class Employee

        <DataMember()>  _
        Public EmployeeName As String
        <DataMember()>  _
        Private ID As String
        ' This member may return a Possessions type.
        <DataMember> _
        public Miscellaneous As Hashtable 

    End Class 

    <DataContract> _
    Public Class Possessions

        <DataMember> _
        Public ItemName As String
    End Class

End Class
'</snippet0>