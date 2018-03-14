' TimeZoneNotFoundException
Option Strict On

' <Snippet4>
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap
' </Snippet4>

<Assembly: CLSCompliant(True)>
Class TestTimeZoneExceptions
   Public Shared Sub Main()
      Dim test As New TestTimeZoneExceptions()
      test.HandleInnerException()
   End Sub   
   
   ' <Snippet1>
   Private Sub HandleInnerException()
      Dim timeZoneName As String = "Any Standard Time"
      Dim tz As TimeZoneInfo
      Try
         tz = RetrieveTimeZone(timeZoneName)
         Console.WriteLine("The time zone display name is {0}.", tz.DisplayName)
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("{0} thrown by application", e.GetType().Name)
         Console.WriteLine("   Message: {0}", e.Message)
         If e.InnerException IsNot Nothing Then
            Console.WriteLine("   Inner Exception Information:")
            Dim innerEx As Exception = e.InnerException
            Do
               Console.WriteLine("      {0}: {1}", innerEx.GetType().Name, innerEx.Message)
               innerEx = innerEx.InnerException
            Loop While innerEx IsNot Nothing
         End If            
      End Try   
   End Sub
   
   Private Function RetrieveTimeZone(tzName As String) As TimeZoneInfo
      Try
         Return TimeZoneInfo.FindSystemTimeZoneById(tzName)
      Catch ex1 As TimeZoneNotFoundException
         Throw New TimeZoneNotFoundException( _
               String.Format("The time zone '{0}' cannot be found.", tzName), _
               ex1) 
      Catch ex2 As InvalidTimeZoneException
         Throw New InvalidTimeZoneException( _
               String.Format("The time zone {0} contains invalid data.", tzName), _
               ex2) 
      End Try      
   End Function
   ' </Snippet1>
   
   ' <Snippet2>
   Private Sub SerializeException()
      ' Generate exception object so that it can be serialized
      Try
         Console.WriteLine("Attempting to load a non-existent time zone")
         Dim tZone As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Imaginary Time Zone")
         ' Serialize time zone so it can be loaded by main routine
         Dim tZoneString As String = tZone.ToSerializedString()
         Dim fs As New StreamWriter("TimeZoneNotFound.dat")
         fs.Write(tZoneString)
         fs.Close()
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("A {0} has been thrown.", e.GetType().Name)
         ' Create a new exception with an inner exception
         Dim serializedException As New TimeZoneNotFoundException( _
                                 "Attempting to load a non-existent time zone", _
                                 e)
         ' Serialize the exception to a file
         Dim exceptionFormatter As IFormatter  = New SoapFormatter()
         Dim exceptionStream As Stream = New FileStream("tzNotFound.xml", FileMode.Create) 
         exceptionFormatter.Serialize(exceptionStream, serializedException)
         exceptionStream.Close()
         Console.WriteLine("Serialized the exception object.")
      End Try
   End Sub   
   ' </Snippet2>
 
    ' <Snippet3>
   Private Sub DeserializeException
      Dim timeZone As TimeZoneInfo
      Try
         Console.WriteLine("Attempting to load a non-existent time zone again")
         timeZone = TimeZoneInfo.FindSystemTimeZoneById("Imaginary Time Zone")
      Catch e As TimeZoneNotFoundException            
         Try
            ' Attempt to deserialize time zone to throw FileNotFoundException
            Dim reader As New StreamReader("TimeZoneInfo.dat")
            Dim contents As String = reader.ReadToEnd()
            reader.Close
            timeZone = TimeZoneInfo.FromSerializedString(contents)
            Console.WriteLine(timeZone.Id)
         Catch eInner As FileNotFoundException
            Console.WriteLine(eInner.GetType().Name)
            ' file not found, therefore object not serialized: 
            ' deserialize original exception information
            Console.WriteLine("Deserializing the original exception.")
            Dim exceptionStream As New FileStream("tzNotFound.xml", FileMode.Open)
            Dim exceptionFormatter As IFormatter = New SoapFormatter()
            Dim serializedException As TimeZoneNotFoundException = _
                DirectCast(exceptionFormatter.Deserialize(exceptionStream), TimeZoneNotFoundException)
            Console.WriteLine("Original error message: {0}", serializedException.Message)    
         End Try
      End Try              
   End Sub 
   ' </Snippet3>         
End Class
