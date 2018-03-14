' <Snippet1>
Imports System
Imports System.Runtime.Remoting.Metadata
Imports System.Runtime.Remoting.MetadataServices


Public Class Test
   
   Class TestClass
      Private [integer] As Integer
      Public dFloatingPoint As Double = 3.1999
      
      Public Property Int() As Integer
         Get
            Return [integer]
         End Get
         Set
            [integer] = value
         End Set
      End Property
       
      Public Sub Print()
         Console.WriteLine("The double is equal to {0}.", dFloatingPoint)
      End Sub 'Print
   End Class 'TestClass
  
   
   Public Shared Sub Main()
      Dim types(4) As Type
      
      Dim s As [String] = "a"
      Dim i As Integer = - 5
      Dim d As Double = 3.1415
      Dim tc As New TestClass()
      
      types(0) = s.GetType()
      types(1) = i.GetType()
      types(2) = d.GetType()
      types(3) = tc.GetType()
      
      MetaData.ConvertTypesToSchemaToFile(types, SdlType.Wsdl, "test.xml")
   End Sub 'Main

End Class 'Test
' </Snippet1>