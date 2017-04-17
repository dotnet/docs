'<Snippet1>
' Example for the Exception( ) constructor.
Imports System
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Derive an exception with a predefined message.
    Class NotEvenException
        Inherits Exception
           
        Public Sub New( )
            MyBase.New( _
                "The argument to a function requiring " & _
                "even input is not divisible by 2." )
        End Sub ' New
    End Class ' NotEvenException

    Module NewExceptionDemo
       
        Sub Main( )
            Console.WriteLine( _
                "This example of the Exception( ) constructor " & _
                "generates the following output." )
            Console.WriteLine( vbCrLf & _
                "Here, an exception is thrown using the " & vbCrLf & _
                "parameterless constructor of the base class." & _
                vbCrLf )

            CalcHalf( 12 )
            CalcHalf( 15 )
              
            Console.WriteLine(vbCrLf & _
                "Here, an exception is thrown using the " & vbCrLf & _
                "parameterless constructor of a derived class." & _
                vbCrLf )

            CalcHalf2( 24 )
            CalcHalf2( 27 )
        End Sub ' Main
           
        ' Half throws a base exception if the input is not even.
        Function Half( input As Integer ) As Integer

            If input Mod 2 <> 0 Then
                Throw New Exception( )
            Else
                Return input / 2
            End If
        End Function ' Half
            
        ' Half2 throws a derived exception if the input is not even.
        Function Half2( input As Integer ) As Integer

            If input Mod 2 <> 0 Then
                Throw New NotEvenException( )
            Else
                Return input / 2
            End If
        End Function ' Half2
            
        ' CalcHalf calls Half and catches any thrown exceptions.
        Sub CalcHalf( input As Integer )

            Try
                Dim halfInput As Integer = Half( input )
                Console.WriteLine( _
                    "Half of {0} is {1}.", input, halfInput )

            Catch ex As Exception
                Console.WriteLine( ex.ToString( ) )
            End Try
        End Sub ' CalcHalf
           
        ' CalcHalf2 calls Half2 and catches any thrown exceptions.
        Sub CalcHalf2( input As Integer )

            Try
                Dim halfInput As Integer = Half2( input )
                Console.WriteLine( _
                    "Half of {0} is {1}.", input, halfInput )

            Catch ex As Exception
                Console.WriteLine( ex.ToString( ) )
            End Try
        End Sub ' CalcHalf2

    End Module ' NewExceptionDemo
End Namespace ' NDP_UE_VB

' This example of the Exception( ) constructor generates the following output.
' 
' Here, an exception is thrown using the
' parameterless constructor of the base class.
' 
' Half of 12 is 6.
' System.Exception: Exception of type System.Exception was thrown.
'    at NDP_UE_VB.NewExceptionDemo.Half(Int32 input)
'    at NDP_UE_VB.NewExceptionDemo.CalcHalf(Int32 input)
' 
' Here, an exception is thrown using the
' parameterless constructor of a derived class.
' 
' Half of 24 is 12.
' NDP_UE_VB.NotEvenException: The argument to a function requiring even input i
' s not divisible by 2.
'    at NDP_UE_VB.NewExceptionDemo.Half2(Int32 input)
'    at NDP_UE_VB.NewExceptionDemo.CalcHalf2(Int32 input)
'</Snippet1>