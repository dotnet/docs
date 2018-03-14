'<Snippet1>
' If compiling with the Visual Basic compiler (vbc.exe) from the command
' prompt, be sure to add the following switch:
'    /reference:System.Runtime.Serialization.Formatters.Soap.dll 
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Soap
Imports System.Security.Permissions

 ' Define a serializable derived exception class.
 <Serializable()>  _
 Class SecondLevelException
     Inherits Exception

     ' This public constructor is used by class instantiators.
     Public Sub New( message As String, inner As Exception )
         MyBase.New( message, inner )

         HelpLink = "http://MSDN.Microsoft.com"
         Source = "Exception_Class_Samples"
     End Sub

     ' This protected constructor is used for deserialization.
     Protected Sub New( info As SerializationInfo, _
         context As StreamingContext )
             MyBase.New( info, context )
     End Sub

     ' GetObjectData performs a custom serialization.
     <SecurityPermissionAttribute(SecurityAction.Demand, _
                                  SerializationFormatter:=True)> _
     Overrides Sub GetObjectData( info As SerializationInfo, _
         context As StreamingContext)

         ' Change the case of two properties, and then use the
         ' method of the base class.
         HelpLink = HelpLink.ToLower()
         Source = Source.ToUpperInvariant()

         MyBase.GetObjectData(info, context)
     End Sub
 End Class

 Module SerializationDemo

     Sub Main()
         Console.WriteLine( _
             "This example of the Exception constructor " & _
             "and Exception.GetObjectData " & vbCrLf & _
             "with SerializationInfo and StreamingContext " & _
             "parameters generates " & vbCrLf & _
             "the following output." & vbCrLf )

         ' This code forces a division by 0 and catches the
         ' resulting exception.
         Try
             Try
                 Dim zero As Integer = 0
                 Dim ecks As Integer = 1 \ zero

             ' Create a new exception to throw again.
             Catch ex As Exception

                 Dim newExcept As New SecondLevelException( _
                     "Forced a division by 0 and threw " & _
                     "another exception.", ex )

                 Console.WriteLine( _
                     "Forced a division by 0, caught the " & _
                     "resulting exception, " & vbCrLf & _
                     "and created a derived exception:" & vbCrLf )
                 Console.WriteLine( "HelpLink: {0}", _
                     newExcept.HelpLink )
                 Console.WriteLine( "Source:   {0}", _
                     newExcept.Source )

                 ' This FileStream is used for the serialization.
                 Dim stream As New FileStream( _
                     "NewException.dat", FileMode.Create )

                 ' Serialize the derived exception.
                 Try
                     Dim formatter As New SoapFormatter( Nothing, _
                         New StreamingContext( _
                             StreamingContextStates.File ) )
                     formatter.Serialize( stream, newExcept )

                     ' Rewind the stream and deserialize the
                     ' exception.
                     stream.Position = 0
                     Dim deserExcept As SecondLevelException = _
                         CType( formatter.Deserialize( stream ), _
                             SecondLevelException )

                     Console.WriteLine( vbCrLf & _
                         "Serialized the exception, and then " & _
                         "deserialized the resulting stream " & _
                         "into a " & vbCrLf & "new exception. " & _
                         "The deserialization changed the case " & _
                         "of certain properties:" & vbCrLf )

                     ' Throw the deserialized exception again.
                     Throw deserExcept

                 Catch se As SerializationException
                     Console.WriteLine( "Failed to serialize: {0}", _
                         se.ToString( ) )

                 Finally
                     stream.Close( )
                 End Try
             End Try
         Catch ex As Exception
             Console.WriteLine( "HelpLink: {0}", ex.HelpLink )
             Console.WriteLine( "Source:   {0}", ex.Source )

             Console.WriteLine( )
             Console.WriteLine( ex.ToString( ) )
         End Try
     End Sub
 End Module
' This example displays the following output:
' 
' Forced a division by 0, caught the resulting exception,
' and created a derived exception:
' 
' HelpLink: http://MSDN.Microsoft.com
' Source:   Exception_Class_Samples
' 
' Serialized the exception, and then deserialized the resulting stream into a
' new exception. The deserialization changed the case of certain properties:
' 
' HelpLink: http://msdn.microsoft.com
' Source:   EXCEPTION_CLASS_SAMPLES
' 
' NDP_UE_VB.SecondLevelException: Forced a division by 0 and threw another exce
' ption. ---> System.DivideByZeroException: Attempted to divide by zero.
'    at NDP_UE_VB.SerializationDemo.Main()
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.SerializationDemo.Main()
'</Snippet1>