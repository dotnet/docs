'<Snippet3>
' Sample for Exception( String, Exception ) constructor.
Imports System
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Derive an exception with a specifiable message and inner exception.
    Class LogTableOverflowException
        Inherits Exception

        Private Const overflowMessage As String = _
            "The log table has overflowed."
           
        Public Sub New( )
            MyBase.New( overflowMessage )
        End Sub ' New
           
        Public Sub New( auxMessage As String )
            MyBase.New( String.Format( "{0} - {1}", _
                overflowMessage, auxMessage ) )
        End Sub ' New
           
        Public Sub New( auxMessage As String, inner As Exception )
            MyBase.New( String.Format( "{0} - {1}", _
                overflowMessage, auxMessage ), inner )
        End Sub ' New
    End Class ' LogTableOverflowException

    Class LogTable
       
        Public Sub New( numElements As Integer )
            logArea = New String( numElements ) { }
            elemInUse = 0
        End Sub ' New
           
        Protected logArea( ) As String
        Protected elemInUse As Integer
           
        ' The AddRecord method throws a derived exception 
        ' if the array bounds exception is caught.
        Public Function AddRecord( newRecord As String ) As Integer

            Try
                Dim curElement as Integer = elemInUse
                logArea( elemInUse ) = newRecord
                elemInUse += 1
                Return curElement

            Catch ex As Exception
                Throw New LogTableOverflowException( String.Format( _
                    "Record ""{0}"" was not logged.", newRecord ), ex )
            End Try
        End Function ' AddRecord
        End Class ' LogTable

        Module OverflowDemo
           
        ' Create a log table and force an overflow.
        Sub Main()
            Dim log As New LogTable(4)
              
            Console.WriteLine( _
                "This example of the Exception( String, Exception )" & _
                vbCrLf & "constructor generates the following output." )
            Console.WriteLine( vbCrLf & _
                "Example of a derived exception " & vbCrLf & _
                "that references an inner exception:" & vbCrLf )
            Try
                Dim count As Integer = 0
                 
                Do
                    log.AddRecord( _
                        String.Format( _
                            "Log record number {0}", count ) )
                    count += 1
                Loop

            Catch ex As Exception
                Console.WriteLine( ex.ToString( ) )
            End Try
        End Sub ' Main

    End Module ' OverflowDemo
End Namespace ' NDP_UE_VB

' This example of the Exception( String, Exception )
' constructor generates the following output.
' 
' Example of a derived exception
' that references an inner exception:
' 
' NDP_UE_VB.LogTableOverflowException: The log table has overflowed. - Record "
' Log record number 5" was not logged. ---> System.IndexOutOfRangeException: In
' dex was outside the bounds of the array.
'    at NDP_UE_VB.LogTable.AddRecord(String newRecord)
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.LogTable.AddRecord(String newRecord)
'    at NDP_UE_VB.OverflowDemo.Main()
'</Snippet3>