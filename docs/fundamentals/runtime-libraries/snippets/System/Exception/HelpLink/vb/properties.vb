'<Snippet1>
' Example for the Exception.HelpLink, Exception.Source,
' Exception.StackTrace, and Exception.TargetSite properties.
Namespace NDP_UE_VB

    ' Derive an exception; the constructor sets the HelpLink and 
    ' Source properties.
    Class LogTableOverflowException
        Inherits Exception

        Private Const overflowMessage As String = _
            "The log table has overflowed."
           
        Public Sub New( auxMessage As String, inner As Exception )
            MyBase.New( String.Format( "{0} - {1}", _
                overflowMessage, auxMessage ), inner )

            Me.HelpLink = "https://docs.microsoft.com"
            Me.Source = "Exception_Class_Samples"

        End Sub
    End Class

    Class LogTable
       
        Public Sub New(numElements As Integer)
            logArea = New String(numElements) {}
            elemInUse = 0
        End Sub
           
        Protected logArea() As String
        Protected elemInUse As Integer
           
        ' The AddRecord method throws a derived exception if 
        ' the array bounds exception is caught.
        Public Function AddRecord( newRecord As String ) As Integer

            Try
                Dim curElement as Integer = elemInUse
                logArea( elemInUse ) = newRecord
                elemInUse += 1
                Return curElement

            Catch ex As Exception
                Throw New LogTableOverflowException( _
                    String.Format( "Record ""{0}"" was not logged.", _
                        newRecord ), ex )
            End Try
        End Function ' AddRecord
    End Class

    Module OverflowDemo
       
        ' Create a log table and force an overflow.
        Sub Main( )
            Dim log As New LogTable( 4 )
              
            Console.WriteLine( "This example of " & vbCrLf & _
                "   Exception.Message, " & vbCrLf & _
                "   Exception.HelpLink, " & vbCrLf & _
                "   Exception.Source, " & vbCrLf & _
                "   Exception.StackTrace, and " & vbCrLf & _
                "   Exception.TargetSite " & vbCrLf & _
                "generates the following output." )
              
            Try
                Dim count As Integer = 0
                 
                Do
                    log.AddRecord( _
                        String.Format( "Log record number {0}", count ) )
                    count += 1
                Loop

            Catch ex As Exception
                Console.WriteLine( vbCrLf & _
                    "Message ---" & vbCrLf & ex.Message )
                Console.WriteLine( vbCrLf & _
                    "HelpLink ---" & vbCrLf & ex.HelpLink )
                Console.WriteLine( vbCrLf & _
                    "Source ---" & vbCrLf & ex.Source )
                Console.WriteLine( vbCrLf & _
                    "StackTrace ---" & vbCrLf & ex.StackTrace )
                Console.WriteLine( vbCrLf & "TargetSite ---" & _
                    vbCrLf & ex.TargetSite.ToString( ) )
            End Try
        End Sub

    End Module ' OverflowDemo
End Namespace ' NDP_UE_VB

' This example of
'    Exception.Message,
'    Exception.HelpLink,
'    Exception.Source,
'    Exception.StackTrace, and
'    Exception.TargetSite
' generates the following output.
' 
' Message ---
' The log table has overflowed. - Record "Log record number 5" was not logged.
' 
' HelpLink ---
' https://docs.microsoft.com
' 
' Source ---
' Exception_Class_Samples
' 
' StackTrace ---
'    at NDP_UE_VB.LogTable.AddRecord(String newRecord)
'    at NDP_UE_VB.OverflowDemo.Main()
' 
' TargetSite ---
' Int32 AddRecord(System.String)
'</Snippet1>