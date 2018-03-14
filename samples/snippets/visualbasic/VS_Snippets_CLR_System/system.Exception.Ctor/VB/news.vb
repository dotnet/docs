 '<Snippet2>
' Example for the Exception( String ) constructor( String ).
Imports System
Imports Microsoft.VisualBasic

Namespace NDP_UE_VB

    ' Derive an exception with a specifiable message.
    Class NotEvenException
        Inherits Exception

        Private Const notEvenMessage As String = _
            "The argument to a function requiring " & _
            "even input is not divisible by 2."
           
        Public Sub New()
            MyBase.New(notEvenMessage)
        End Sub ' New
           
        Public Sub New(auxMessage As String)
            MyBase.New(String.Format("{0} - {1}", _
                auxMessage, notEvenMessage))
        End Sub ' New
    End Class ' NotEvenException

    Module NewSExceptionDemo
       
        Sub Main()
            Console.WriteLine( _
                "This example of the Exception( String )" & vbCrLf & _
                "constructor generates the following output." )
            Console.WriteLine( vbCrLf & _
                "Here, an exception is thrown using the " & vbCrLf & _
                "constructor of the base class." & vbCrLf )

            CalcHalf(18)
            CalcHalf(21)
              
            Console.WriteLine(vbCrLf & _
                "Here, an exception is thrown using the " & vbCrLf & _
                "constructor of a derived class." & vbCrLf )

            CalcHalf2(30)
            CalcHalf2(33)
        End Sub ' Main
           
        ' Half throws a base exception if the input is not even.
        Function Half(input As Integer) As Integer

            If input Mod 2 <> 0 Then
                Throw New Exception( String.Format( _
                    "The argument {0} is not divisible by 2.", _
                    input ) )
            Else
                Return input / 2
            End If
        End Function ' Half
            
        ' Half2 throws a derived exception if the input is not even.
        Function Half2(input As Integer) As Integer

            If input Mod 2 <> 0 Then
                Throw New NotEvenException( _
                    String.Format( "Invalid argument: {0}", input ) )
            Else
                Return input / 2
            End If
        End Function ' Half2
            
        ' CalcHalf calls Half and catches any thrown exceptions.
        Sub CalcHalf(input As Integer)

            Try
                Dim halfInput As Integer = Half(input)
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

    End Module ' NewSExceptionDemo
End Namespace ' NDP_UE_VB

' This example of the Exception( String )
' constructor generates the following output.
' 
' Here, an exception is thrown using the
' constructor of the base class.
' 
' Half of 18 is 9.
' System.Exception: The argument 21 is not divisible by 2.
'    at NDP_UE_VB.NewSExceptionDemo.Half(Int32 input)
'    at NDP_UE_VB.NewSExceptionDemo.CalcHalf(Int32 input)
' 
' Here, an exception is thrown using the
' constructor of a derived class.
' 
' Half of 30 is 15.
' NDP_UE_VB.NotEvenException: Invalid argument: 33 - The argument to a function
'  requiring even input is not divisible by 2.
'    at NDP_UE_VB.NewSExceptionDemo.Half2(Int32 input)
'    at NDP_UE_VB.NewSExceptionDemo.CalcHalf2(Int32 input)
'</Snippet2>