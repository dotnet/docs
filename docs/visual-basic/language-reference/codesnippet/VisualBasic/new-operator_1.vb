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