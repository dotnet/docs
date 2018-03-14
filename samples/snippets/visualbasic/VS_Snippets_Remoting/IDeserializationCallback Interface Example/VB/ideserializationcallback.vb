'<snippet1>
Imports System
Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization

' This class is serializable and will have its OnDeserialization method
' called after each instance of this class is deserialized.
<Serializable()> Class Circle
   Implements IDeserializationCallback
   Private m_radius As Double

   ' To reduce the size of the serialization stream, the field below is 
   ' not serialized. This field is calculated when an object is constructed
   ' or after an instance of this class is deserialized.
   <NonSerialized()> Public m_area As Double

   Public Sub New(ByVal radius As Double)
      m_radius = radius
      m_area = Math.PI * radius * radius
   End Sub

   Private Sub OnDeserialization(ByVal sender As Object) _
      Implements IDeserializationCallback.OnDeserialization
      ' After being deserialized, initialize the m_area field 
      ' using the deserialized m_radius value.
      m_area = Math.PI * m_radius * m_radius
   End Sub

   Public Overrides Function ToString() As String
      Return String.Format("radius={0}, area={1}", m_radius, m_area)
   End Function
End Class


Class Class1
   <STAThread()> Shared Sub Main()
      Serialize()
      Deserialize()
   End Sub

   Shared Sub Serialize()
      Dim c As New Circle(10)
      Console.WriteLine("Object being serialized: " + c.ToString())

      ' To serialize the Circle, you must first open a stream for 
      ' writing. Use a file stream here.
      Dim fs As New FileStream("DataFile.dat", FileMode.Create)

      ' Construct a BinaryFormatter and use it 
      ' to serialize the data to the stream.
      Dim formatter As New BinaryFormatter
      Try
         formatter.Serialize(fs, c)
      Catch e As SerializationException
         Console.WriteLine("Failed to serialize. Reason: " + e.Message)
         Throw
      Finally
         fs.Close()
      End Try
   End Sub


   Shared Sub Deserialize()
      ' Declare the Circle reference
      Dim c As Circle = Nothing

      ' Open the file containing the data that you want to deserialize.
      Dim fs As New FileStream("DataFile.dat", FileMode.Open)
      Try
         Dim formatter As New BinaryFormatter

         ' Deserialize the Circle from the file and 
         ' assign the reference to the local variable.
         c = CType(formatter.Deserialize(fs), Circle)
      Catch e As SerializationException
         Console.WriteLine("Failed to deserialize. Reason: " + e.Message)
         Throw
      Finally
         fs.Close()
      End Try

      ' To prove that the Circle deserialized correctly, display its area.
      Console.WriteLine("Object being deserialized: " + c.ToString())
   End Sub
End Class
'</snippet1>