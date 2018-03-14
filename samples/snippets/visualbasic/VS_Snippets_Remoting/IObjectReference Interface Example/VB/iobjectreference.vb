'<snippet1>
Imports System
Imports System.Web
Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Runtime.Serialization
Imports System.Security.Permissions


' There should be only one instance of this type per AppDomain.
<Serializable()> _
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Public NotInheritable Class Singleton
   Implements ISerializable

   ' This is the one instance of this type.
   Private Shared ReadOnly theOneObject As New Singleton

   ' Here are the instance fields.
   Private someString As String
   private someNumber As Int32

   ' Private constructor allowing this type to construct the Singleton.
   Private Sub New()
      ' Do whatever is necessary to initialize the Singleton.
      someString = "This is a string field"
      someNumber = 123
   End Sub

   ' A method returning a reference to the Singleton.
   Public Shared Function GetSingleton() As Singleton
      Return theOneObject
   End Function

   ' A method called when serializing a Singleton.
   <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
   Private Sub GetObjectData(ByVal info As SerializationInfo, _
      ByVal context As StreamingContext) _
      Implements ISerializable.GetObjectData

      ' Instead of serializing this object, we will  
      ' serialize a SingletonSerializationHelp instead.
      info.SetType(GetType(SingletonSerializationHelper))
      ' No other values need to be added.
   End Sub

   ' Note: ISerializable's special constructor is not necessary 
   ' because it is never called.
End Class


<Serializable()> _
<PermissionSet(SecurityAction.Demand, Name:="FullTrust")> _
Friend NotInheritable Class SingletonSerializationHelper
   Implements IObjectReference
   ' This object has no fields (although it could).

   ' GetRealObject is called after this object is deserialized.
   <SecurityPermissionAttribute(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)> _
   Public Function GetRealObject(ByVal context As StreamingContext) As Object Implements IObjectReference.GetRealObject
      ' When deserialiing this object, return a reference to 
      ' the Singleton object instead.
      Return Singleton.GetSingleton()
   End Function
End Class


Class App
   <STAThread()> Shared Sub Main()
      Dim fs As New FileStream("DataFile.dat", FileMode.Create)

      Try
         ' Construct a BinaryFormatter and use it 
         ' to serialize the data to the stream.
         Dim formatter As New BinaryFormatter

         ' Create an array with multiple elements refering to 
         ' the one Singleton object.
         Dim a1() As Singleton = {Singleton.GetSingleton(), Singleton.GetSingleton()}

         ' This displays "True".
         Console.WriteLine("Do both array elements refer to the same object? " & _
            Object.ReferenceEquals(a1(0), a1(1)))

         ' Serialize the array elements.
         formatter.Serialize(fs, a1)

         ' Deserialize the array elements.
         fs.Position = 0
         Dim a2() As Singleton = DirectCast(formatter.Deserialize(fs), Singleton())

         ' This displays "True".
         Console.WriteLine("Do both array elements refer to the same object? " & _
            Object.ReferenceEquals(a2(0), a2(1)))

         ' This displays "True".
         Console.WriteLine("Do all array elements refer to the same object? " & _
            Object.ReferenceEquals(a1(0), a2(0)))
      Catch e As SerializationException
         Console.WriteLine("Failed to serialize. Reason: " & e.Message)
         Throw
      Finally
         fs.Close()
      End Try
   End Sub
End Class
'</snippet1>