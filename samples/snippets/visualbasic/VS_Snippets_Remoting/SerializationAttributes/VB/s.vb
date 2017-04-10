' <Snippet1>
Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap




Public Class Test
   
   Public Shared Sub Main()
      
      ' Creates a new TestSimpleObject object.
      Dim obj As New TestSimpleObject()
      
      Console.WriteLine("Before serialization the object contains: ")
      obj.Print()
      
      ' Opens a file and serializes the object into it in binary format.
      Dim stream As Stream = File.Open("data.xml", FileMode.Create)
      Dim formatter As New SoapFormatter()
      


      formatter.Serialize(stream, obj)
      stream.Close()
      
      ' Empties obj.
      obj = Nothing
      
      ' Opens file "data.xml" and deserializes the object from it.
      stream = File.Open("data.xml", FileMode.Open)
      formatter = New SoapFormatter()



      obj = CType(formatter.Deserialize(stream), TestSimpleObject)
      stream.Close()
      
      Console.WriteLine("")
      Console.WriteLine("After deserialization the object contains: ")
      obj.Print()

   End Sub 'Main

End Class 'Test


' A test object that needs to be serialized.
<Serializable()> Public Class TestSimpleObject
   
   Public member1 As Integer
   Public member2 As String
   Public member3 As String
   Public member4 As Double
   
   ' A member that is not serialized.
   <NonSerialized()> Public member5 As String  
  
   
   Public Sub New()     
      member1 = 11
      member2 = "hello"
      member3 = "hello"
      member4 = 3.14159265
      member5 = "hello world!"
   End Sub 'New
      
   
   Public Sub Print()      
      Console.WriteLine("member1 = '{0}'", member1)
      Console.WriteLine("member2 = '{0}'", member2)
      Console.WriteLine("member3 = '{0}'", member3)
      Console.WriteLine("member4 = '{0}'", member4)
      Console.WriteLine("member5 = '{0}'", member5)
   End Sub 'Print

End Class 'TestSimpleObject
' </Snippet1>