'<Snippet1>
' Example for the Exception.HResult property.
Imports System
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Create the derived exception class.
    Class SecondLevelException
        Inherits Exception

        Private Const SecondLevelHResult As Integer = &H81234567
       
        ' Set HResult for this exception, and include it in 
        ' the exception message.
        Public Sub New(message As String, inner As Exception)

            MyBase.New( String.Format( "(HRESULT:0x{1:X8}) {0}", _
                message, SecondLevelHResult ), inner )
            HResult = SecondLevelHResult
        End Sub ' New
    End Class ' SecondLevelException

    Module HResultDemo
       
        Sub Main()
            Console.WriteLine( _
                "This example of Exception.HResult " & _
                "generates the following output." & vbCrLf )
              
            ' This function forces a division by 0 and throws 
            ' a second exception.
            Try
                Try
                    Dim zero As Integer = 0
                    Dim ecks As Integer = 1 \ zero

                Catch ex As Exception
                    Throw New SecondLevelException( _
                        "Forced a division by 0 and threw " & _
                        "a second exception.", ex )
                End Try
              
            Catch ex As Exception
                Console.WriteLine( ex.ToString( ) )
            End Try
        End Sub ' Main

    End Module ' HResultDemo
End Namespace ' NDP_UE_VB

' This example of Exception.HResult generates the following output.
' 
' NDP_UE_VB.SecondLevelException: (HRESULT:0x81234567) Forced a division by 0 a
' nd threw a second exception. ---> System.DivideByZeroException: Attempted to
' divide by zero.
'    at NDP_UE_VB.HResultDemo.Main()
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.HResultDemo.Main()
'</Snippet1>