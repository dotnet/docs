'<Snippet1>
' Example for the Exception.GetBaseException method.
Imports System
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Define two derived exceptions to demonstrate nested exceptions.
    Class SecondLevelException
        Inherits Exception
           
        Public Sub New( message As String, inner As Exception )
            MyBase.New( message, inner )
        End Sub ' New
    End Class ' SecondLevelException

    Class ThirdLevelException
        Inherits Exception
           
        Public Sub New( message As String, inner As Exception )
            MyBase.New( message, inner )
        End Sub ' New
    End Class ' ThirdLevelException

    Class NestedExceptions
       
        Public Shared Sub Main( )
            Console.WriteLine( _
                "This example of Exception.GetBaseException " & _
                "generates the following output." )
            Console.WriteLine( vbCrLf & _
                "The program forces a division by 0, then throws " & _
                "the exception " & vbCrLf & "twice more, using " & _
                "a different derived exception each time:" & vbCrLf )
              
            Try
                ' This sub calls another that forces a division by 0.
                Rethrow()

            Catch ex As Exception
                Dim current As Exception
                 
                Console.WriteLine( _
                    "Unwind the nested exceptions using the " & _
                    "InnerException property:" & vbCrLf )
                 
                ' This code unwinds the nested exceptions using the 
                ' InnerException property.
                current = ex
                While Not ( current Is Nothing )
                    Console.WriteLine( current.ToString( ) )
                    Console.WriteLine( )
                    current = current.InnerException
                End While
                 
                ' Display the innermost exception.
                Console.WriteLine( _
                    "Display the base exception using the " & _
                    "GetBaseException method:" & vbCrLf )
                Console.WriteLine( _
                    ex.GetBaseException( ).ToString( ) )
            End Try
        End Sub ' Main
           
        ' This sub catches the exception from the called sub
        ' DivideBy0( ) and throws another in response.
        Shared Sub Rethrow( )
            Try
                DivideBy0( )

            Catch ex As Exception
                Throw New ThirdLevelException( _
                    "Caught the second exception and " & _
                    "threw a third in response.", ex )
            End Try
        End Sub ' Rethrow
           
        ' This sub forces a division by 0 and throws a second 
        ' exception.
        Shared Sub DivideBy0( )
            Try
                Dim zero As Integer = 0
                Dim ecks As Integer = 1 \ zero

            Catch ex As Exception
                Throw New SecondLevelException( _
                    "Forced a division by 0 and threw " & _
                    "a second exception.", ex )
            End Try
        End Sub ' DivideBy0
    End Class ' NestedExceptions
End Namespace ' NDP_UE_VB

' This example of Exception.GetBaseException generates the following output.
' 
' The program forces a division by 0, then throws the exception
' twice more, using a different derived exception each time:
' 
' Unwind the nested exceptions using the InnerException property:
' 
' NDP_UE_VB.ThirdLevelException: Caught the second exception and threw a third
' in response. ---> NDP_UE_VB.SecondLevelException: Forced a division by 0 and
' threw a second exception. ---> System.DivideByZeroException: Attempted to div
' ide by zero.
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
'    at NDP_UE_VB.NestedExceptions.Rethrow()
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.NestedExceptions.Rethrow()
'    at NDP_UE_VB.NestedExceptions.Main()
' 
' NDP_UE_VB.SecondLevelException: Forced a division by 0 and threw a second exc
' eption. ---> System.DivideByZeroException: Attempted to divide by zero.
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
'    --- End of inner exception stack trace ---
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
'    at NDP_UE_VB.NestedExceptions.Rethrow()
' 
' System.DivideByZeroException: Attempted to divide by zero.
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
' 
' Display the base exception using the GetBaseException method:
' 
' System.DivideByZeroException: Attempted to divide by zero.
'    at NDP_UE_VB.NestedExceptions.DivideBy0()
'</Snippet1>