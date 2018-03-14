Module Module3

    Sub Main()
        ' Create an instance of the class, with 1 as the value of 
        ' the property.
        Dim lambdaScopeDemoInstance = 
            New LambdaScopeDemoClass With {.Prop = 1}

        ' Variable aDel will be bound to the nested lambda expression  
        ' returned by the call to functionWithNestedLambda.
        ' The value 2 is sent in for parameter level1.
        Dim aDel As aDelegate = 
            lambdaScopeDemoInstance.functionWithNestedLambda(2)

        ' Now the returned lambda expression is called, with 4 as the 
        ' value of parameter level3.
        Console.WriteLine("First value returned by aDel:   " & aDel(4))

        ' Change a few values to verify that the lambda expression has 
        ' access to the variables, not just their original values.
        lambdaScopeDemoInstance.aField = 20
        lambdaScopeDemoInstance.Prop = 30
        Console.WriteLine("Second value returned by aDel: " & aDel(40))
    End Sub

    Delegate Function aDelegate(
        ByVal delParameter As Integer) As Integer

    Public Class LambdaScopeDemoClass
        Public aField As Integer = 6
        Dim aProp As Integer

        Property Prop() As Integer
            Get
                Return aProp
            End Get
            Set(ByVal value As Integer)
                aProp = value
            End Set
        End Property

        Public Function functionWithNestedLambda(
            ByVal level1 As Integer) As aDelegate

            Dim localVar As Integer = 5

            ' When the nested lambda expression is executed the first 
            ' time, as aDel from Main, the variables have these values:
            ' level1 = 2
            ' level2 = 3, after aLambda is called in the Return statement
            ' level3 = 4, after aDel is called in Main
            ' locarVar = 5
            ' aField = 6
            ' aProp = 1
            ' The second time it is executed, two values have changed:
            ' aField = 20
            ' aProp = 30
            ' level3 = 40
            Dim aLambda = Function(level2 As Integer) _
                              Function(level3 As Integer) _
                                  level1 + level2 + level3 + localVar +
                                    aField + aProp

            ' The function returns the nested lambda, with 3 as the 
            ' value of parameter level2.
            Return aLambda(3)
        End Function

    End Class
End Module