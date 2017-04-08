'<snippet1>
Imports System.IO
Imports System.Collections
Imports System.Runtime.Serialization

' Note: When building this code, you must reference the
' System.Runtime.Serialization.Formatters.Soap.dll assembly.
Imports System.Runtime.Serialization.Formatters.Soap


Module App

   Sub Main()
      Serialize()
      Deserialize()
   End Sub

   Sub Serialize()
      ' Create a hashtable of values that will eventually be serialized.
      Dim addresses As New Hashtable
      addresses.Add("Jeff", "123 Main Street, Redmond, WA 98052")
      addresses.Add("Fred", "987 Pine Road, Phila., PA 19116")
      addresses.Add("Mary", "PO Box 112233, Palo Alto, CA 94301")

      ' To serialize the hashtable (and its key/value pairs), 
      ' you must first open a stream for writing.
      ' Use a file stream here.
      Dim fs As New FileStream("DataFile.soap", FileMode.Create)

      ' Construct a SoapFormatter and use it 
      ' to serialize the data to the stream.
      Dim formatter As New SoapFormatter
      Try
         formatter.Serialize(fs, addresses)
      Catch e As SerializationException
         Console.WriteLine("Failed to serialize. Reason: " & e.Message)
         Throw
      Finally
         fs.Close()
      End Try
   End Sub


   Sub Deserialize()
      ' Declare the hashtable reference.
      Dim addresses As Hashtable = Nothing

      ' Open the file containing the data that you want to deserialize.
      Dim fs As New FileStream("DataFile.soap", FileMode.Open)
      Try
         Dim formatter As New SoapFormatter

         ' Deserialize the hashtable from the file and 
         ' assign the reference to the local variable.
         addresses = DirectCast(formatter.Deserialize(fs), Hashtable)
      Catch e As SerializationException
         Console.WriteLine("Failed to deserialize. Reason: " & e.Message)
         Throw
      Finally
         fs.Close()
      End Try

      ' To prove that the table deserialized correctly, 
      ' display the key/value pairs to the console.
      Dim de As DictionaryEntry
      For Each de In addresses
         Console.WriteLine("{0} lives at {1}.", de.Key, de.Value)
      Next
   End Sub
End Module
'</snippet1>