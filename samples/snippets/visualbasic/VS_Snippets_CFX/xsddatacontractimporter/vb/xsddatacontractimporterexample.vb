 '<snippet0>
Imports System
Imports System.CodeDom.Compiler
Imports System.CodeDom
Imports System.Runtime.Serialization
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Globalization

Class Program
   
    Shared Sub Main(ByVal args() As String) 
        Try
            Dim schemas As XmlSchemaSet = Export()
            Dim ccu As CodeCompileUnit = Import(schemas)
            CompileCode(ccu, "Person.cs")
            CompileCode(ccu, "Person.vb")
        Catch exc As Exception
            Console.WriteLine("{0}: {1}", exc.Message, exc.StackTrace)
        Finally
            Console.WriteLine("Press <Enter> to end....")
            Console.ReadLine()
        End Try
    
    End Sub 
    
    Shared Function Export() As XmlSchemaSet 
        Dim ex As New XsdDataContractExporter()
        ex.Export(GetType(Person))
        Return ex.Schemas
    End Function
    '<snippet3>    
    '<snippet2>
    Shared Function Import(ByVal schemas As XmlSchemaSet) As CodeCompileUnit 

        Dim imp As New XsdDataContractImporter()
       ' The EnableDataBinding option adds a RaisePropertyChanged method to
       ' the generated code. The GenerateInternal causes code access to be
       ' set to internal.
       Dim iOptions As New ImportOptions()
       iOptions.EnableDataBinding = true
       iOptions.GenerateInternal = true
       imp.Options = IOptions

        If imp.CanImport(schemas) Then
            imp.Import(schemas)
            Return imp.CodeCompileUnit
        Else
            Return Nothing
        End If
    End Function
    '</snippet2>
    '</snippet3>

    '<snippet1> 
    Shared Sub CompileCode(ByVal ccu As CodeCompileUnit, ByVal sourceName As String) 
        Dim provider As CodeDomProvider = Nothing
        Dim sourceFile As New FileInfo(sourceName)
        ' Select the code provider based on the input file extension, either C# or Visual Basic.
        If sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".CS" Then
            provider = New Microsoft.CSharp.CSharpCodeProvider()
        ElseIf sourceFile.Extension.ToUpper(CultureInfo.InvariantCulture) = ".VB" Then
            provider = New Microsoft.VisualBasic.VBCodeProvider()
        Else
            Console.WriteLine("Source file must have a .cs or .vb extension")
        End If
        If Not (provider Is Nothing) Then
            Dim options As New CodeGeneratorOptions()
            ' Set code formatting options to your preference. 
            options.BlankLinesBetweenMembers = True
            options.BracingStyle = "C"
            
            Dim sw As New StreamWriter(sourceName)
            provider.GenerateCodeFromCompileUnit(ccu, sw, options)
            sw.Close()
        End If
    
    End Sub
    '</snippet1> 
End Class

<DataContract()>  _
Public Class Person
    <DataMember()>  _
    Public FirstName As String
    
    <DataMember()>  _
    Public LastName As String
    
    
    Public Sub New(ByVal newFName As String, ByVal newLName As String) 
        FirstName = newFName
        LastName = newLName
    
    End Sub 
End Class 
'</snippet0>