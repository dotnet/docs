' Visual Basic .NET Document
Option Strict On

' <Snippet6>
Imports System.Collections
Imports System.Drawing
Imports System.IO
Imports System.Resources
Imports System.Runtime.Serialization.Formatters.Binary

Module Example
   Public Sub Main()
      Dim rdr As New ResourceReader(".\ContactResources.resources")  
      Dim dict As IDictionaryEnumerator = rdr.GetEnumerator()
      Do While dict.MoveNext()
         Console.WriteLine("Resource Name: {0}", dict.Key)
         Try
            Console.WriteLine("   Value: {0}", dict.Value)
         Catch e As FileNotFoundException
            Console.WriteLine("   Exception: A file cannot be found.")
            DisplayResourceInfo(rdr, CStr(dict.Key), False)
         Catch e As FormatException
            Console.WriteLine("   Exception: Corrupted data.")
            DisplayResourceInfo(rdr, CStr(dict.Key), True)
         Catch e As TypeLoadException
            Console.WriteLine("   Exception: Cannot load the data type.")
            DisplayResourceInfo(rdr, CStr(dict.Key), False)   
         End Try
      Loop 
   End Sub

   Private Sub DisplayResourceInfo(rr As ResourceReader, 
                                   key As String, loaded As Boolean)
      Dim dataType As String = Nothing
      Dim data() As Byte = Nothing
      rr.GetResourceData(key, dataType, data)
            
      ' Display the data type.
      Console.WriteLine("   Data Type: {0}", dataType)
      ' Display the bytes that form the available data.      
      Console.Write("   Data: ")
      Dim lines As Integer = 0
      For Each dataItem In data
         lines += 1
         Console.Write("{0:X2} ", dataItem)
         If lines Mod 25 = 0 Then Console.Write("{0}         ", vbCrLf)
      Next
      Console.WriteLine()
      ' Try to recreate current state of  data.
      ' Do: Bitmap, DateTimeTZI
      Select Case dataType   
         ' Handle internally serialized string data (ResourceTypeCode members).
         Case "ResourceTypeCode.String"
            Dim reader As New BinaryReader(New MemoryStream(data))
            Dim binData As String = reader.ReadString()
            Console.WriteLine("   Recreated Value: {0}", binData)
         Case "ResourceTypeCode.Int32"
            Console.WriteLine("   Recreated Value: {0}", 
                              BitConverter.ToInt32(data, 0))
         Case "ResourceTypeCode.Boolean"
            Console.WriteLine("   Recreated Value: {0}", 
                              BitConverter.ToBoolean(data, 0))
         ' .jpeg image stored as a stream.
         Case "ResourceTypeCode.Stream"  
            Const OFFSET As Integer = 4
            Dim size As Integer = BitConverter.ToInt32(data, 0)
            Dim value As New Bitmap(New MemoryStream(data, OFFSET, size))
            Console.WriteLine("   Recreated Value: {0}", value) 
         ' Our only other type is DateTimeTZI.
         Case Else
            ' No point in deserializing data if the type is unavailable.
            If dataType.Contains("DateTimeTZI") And loaded Then 
               Dim binFmt As New BinaryFormatter()
               Dim value As Object = binFmt.Deserialize(New MemoryStream(data))
               Console.WriteLine("   Recreated Value: {0}", value)
            End If    
      End Select
      Console.WriteLine()
   End Sub
End Module
' </Snippet6>
