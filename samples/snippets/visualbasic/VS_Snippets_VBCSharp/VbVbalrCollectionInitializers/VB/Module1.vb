Option Strict On

Imports System.Runtime.CompilerServices
Imports System.Collections.Generic

Module Module1

    Class MenuOption
        Public Index As Integer
        Public Description As String
    End Class

    <Extension()>
    Sub Add(ByVal list As List(Of MenuOption),
            ByVal index As Integer,
            ByVal description As String)

        list.Add(New MenuOption With {.Index = index, .Description = description})
    End Sub

    Sub Main()

        '<Snippet1>
        ' Create an array of type String().
        Dim winterMonths = {"December", "January", "February"}

        ' Create an array of type Integer()
        Dim numbers = {1, 2, 3, 4, 5}

        ' Create a list of menu options. (Requires an extension method
        ' named Add for List(Of MenuOption)
        Dim menuOptions = New List(Of MenuOption) From {{1, "Home"},
                                                        {2, "Products"},
                                                        {3, "News"},
                                                        {4, "Contact Us"}}
        '</Snippet1>
    End Sub

    Sub Snippets()

        '<Snippet2>
        Dim names As New List(Of String) From {"Christa", "Brian", "Tim"}
        '</Snippet2>

        '<Snippet3>
        Dim numbers = New Integer() {1, 2, 4, 8}
        Dim doubles = {1.5, 2, 9.9, 18}
        '</Snippet3>

        '<Snippet4>
        Dim values As Double() = {1, 2, 3, 4, 5, 6}
        '</Snippet4>

        '<Snippet5>
        Dim days = New Dictionary(Of Integer, String) From
            {{0, "Sunday"}, {1, "Monday"}}
        '</Snippet5>
    End Sub

    Sub Snippets2()
        '<Snippet6>
        Dim days = New Dictionary(Of Integer, String)
        days.Add(0, "Sunday")
        days.Add(1, "Monday")
        '</Snippet6>

        '<Snippet7>
        Dim grid = {{1, 2}, {3, 4}}
        '</Snippet7>

        '<Snippet11>
        Dim values = {({1, 2}), ({3, 4, 5})}
        '</Snippet11>

        '<Snippet8>
        Dim a = {{1, 2.0}, {3, 4}, {5, 6}, {7, 8}}
        '</Snippet8>

        '<Snippet9>
        Dim customers = New List(Of Customer) From
            {
                New Customer("City Power & Light", "http://www.cpandl.com/"),
                New Customer("Wide World Importers", "http://www.wideworldimporters.com/"),
                New Customer("Lucerne Publishing", "http://www.lucernepublishing.com/")
            }
        '</Snippet9>
    End Sub

    Sub Snippets3()
        '<Snippet10>
        Dim customers = New List(Of Customer) 
        customers.Add(New Customer("City Power & Light", "http://www.cpandl.com/"))
        customers.Add(New Customer("Wide World Importers", "http://www.wideworldimporters.com/"))
        customers.Add(New Customer("Lucerne Publishing", "http://www.lucernepublishing.com/"))
        '</Snippet10>

        '<Snippet12>
        Dim actions As Action() = {AddressOf Action1, AddressOf Action2}
        '</Snippet12>
    End Sub

    Sub Action1()

    End Sub

    Sub Action2()

    End Sub

    Class Customer
        Public Name As String
        Public PublicUrl As String
        Public Sub New(ByVal companyName As String,
                       ByVal companyUrl As String)
            Name = companyName
            PublicUrl = companyUrl
        End Sub
    End Class

    '<Snippet13>
    Public Class AppMenu
        Public Property Items As List(Of String) =
            New List(Of String) From {"Home", "About", "Contact"}
    End Class
    '</Snippet13>

End Module
