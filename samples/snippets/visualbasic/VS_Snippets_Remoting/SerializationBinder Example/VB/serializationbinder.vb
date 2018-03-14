'<snippet1>
Imports System
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Reflection
Imports System.Security.Permissions

Class App
   <STAThread()> Shared Sub Main()
      Serialize()
      Deserialize()
   End Sub


   Shared Sub Serialize()
      ' To serialize the objects, you must first open a stream for writing. 
      ' Use a file stream here.
      Dim fs As New FileStream("DataFile.dat", FileMode.Create)

      Try
         ' Construct a BinaryFormatter and use it 
         ' to serialize the data to the stream.
         Dim formatter As New BinaryFormatter

         ' Construct a Version1Type object and serialize it.
         Dim obj As New Version1Type
         obj.x = 123
         formatter.Serialize(fs, obj)
      Catch e As SerializationException
         Console.WriteLine("Failed to serialize. Reason: " & e.Message)
         Throw
      Finally
         fs.Close()
      End Try
   End Sub


   Shared Sub Deserialize()
      ' Declare the Version2Type reference.
      Dim obj As Version2Type = Nothing

      ' Open the file containing the data that you want to deserialize.
      Dim fs As New FileStream("DataFile.dat", FileMode.Open)
      Try
         ' Construct a BinaryFormatter and use it 
         ' to deserialize the data from the stream.
         Dim formatter As New BinaryFormatter

         ' Construct an instance of the 
         ' Version1ToVersion2TypeSerialiationBinder type.
         ' This Binder type can deserialize a Version1Type  
         ' object to a Version2Type object.
         formatter.Binder = New Version1ToVersion2DeserializationBinder

         obj = DirectCast(formatter.Deserialize(fs), Version2Type)
      Catch e As SerializationException
         Console.WriteLine("Failed to deserialize. Reason: " & e.Message)
         Throw
      Finally
         fs.Close()
      End Try

      ' To prove that a Version2Type object was deserialized, 
      ' display the object's type and fields to the console.
      Console.WriteLine("Type of object deserialized: {0}", obj.GetType())
      Console.WriteLine("x = {0}, name = {1}", obj.x, obj.name)
   End Sub
End Class


<Serializable()> Class Version1Type
   Public x As Int32
End Class


<Serializable()> Class Version2Type
   Implements ISerializable
   Public x As Int32
   Public name As String

   ' The security attribute demands that code that calls  
   ' this method have permission to perform serialization.
   <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
   Private Sub GetObjectData(ByVal info As SerializationInfo, _
         ByVal context As StreamingContext) Implements ISerializable.GetObjectData
      info.AddValue("x", x)
      info.AddValue("name", name)
   End Sub

   ' The security attribute demands that code that calls  
   ' this method have permission to perform serialization.
   <SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter:=True)> _
   Private Sub New(ByVal info As SerializationInfo, _
         ByVal context As StreamingContext)
      x = info.GetInt32("x")
      Try
         name = info.GetString("name")
      Catch e As SerializationException
         ' The "name" field was not serialized because 
         ' Version1Type did not contain this field.
         ' Set this field to a reasonable default value.
         name = "Reasonable default value"
      End Try
   End Sub
End Class


NotInheritable Class Version1ToVersion2DeserializationBinder
   Inherits SerializationBinder
   Public Overrides Function BindToType(ByVal assemblyName As String, _
         ByVal typeName As String) As Type

      Dim typeToDeserialize As Type = Nothing

      ' For each assemblyName/typeName that you want to deserialize
      ' to a different type, set typeToDeserialize to the desired type.
      Dim assemVer1 As String = [Assembly].GetExecutingAssembly().FullName
      Dim typeVer1 As String = GetType(Version1Type).FullName

      If assemblyName = assemVer1 And typeName = typeVer1 Then
         ' To use a type from a different assembly version, 
         ' change the version number.
         ' To do this, uncomment the following code.
         ' assemblyName = assemblyName.Replace("1.0.0.0", "2.0.0.0")

         ' To use a different type from the same assembly, 
         ' change the type name.
         typeName = typeName.Replace("Version1Type", "Version2Type")
      End If

      ' The following code returns the type.
      typeToDeserialize = Type.GetType(String.Format("{0}, {1}", typeName, _
                                       assemblyName))

      Return typeToDeserialize
   End Function
End Class
'</snippet1>
