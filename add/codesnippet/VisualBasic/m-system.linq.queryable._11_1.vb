        Dim numbers As New List(Of Single)(New Single() {43.68F, 1.25F, 583.7F, 6.5F})

        Dim sum As Single = numbers.AsQueryable().Sum()

        MsgBox("The sum of the numbers is " & sum)

        ' This code produces the following output:

        ' The sum of the numbers is 635.13.
