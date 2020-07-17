

' * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
Module Module1

    Sub Main()
        '<Snippet11>
        ' For customer1, call the constructor that takes no arguments.
        Dim customer1 As New Customer()

        ' For customer2, call the constructor that takes the name of the 
        ' customer as an argument.
        Dim customer2 As New Customer("Blue Yonder Airlines")

        ' For customer3, declare an instance of Customer in the first line 
        ' and instantiate it in the second.
        Dim customer3 As Customer
        customer3 = New Customer()

        ' With Option Infer set to On, the following declaration declares
        ' and instantiates a new instance of Customer.
        Dim customer4 = New Customer("Coho Winery")
        '</Snippet11>


        '<Snippet12>
        Dim intArray1() As Integer
        intArray1 = New Integer() {1, 2, 3, 4}

        Dim intArray2() As Integer = {5, 6}

        ' The following example requires that Option Infer be set to On.
        Dim intArray3() = New Integer() {6, 7, 8}
        '</Snippet12>



    End Sub

End Module

Class Customer
    Public Sub New()
        _name = "unknown"
    End Sub
    Public Sub New(ByVal value As String)
        _name = value
    End Sub

    Private _name As String
    Property Name() As String
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property
End Class
