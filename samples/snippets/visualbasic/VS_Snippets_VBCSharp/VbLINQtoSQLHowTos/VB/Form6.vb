﻿Public Class Form6

    Private Sub Form6_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '<Snippet13>
        Dim db As New northwindDataContext
        Dim msg = ""

        Dim londonCustomerCount = Aggregate cust In db.Customers
                                  Where cust.City = "London"
                                  Into Count()
        msg &= "Count of London Customers: " & londonCustomerCount & vbCrLf

        Dim averageOrderCount = Aggregate cust In db.Customers
                                Where cust.City = "London"
                                Into Average(cust.Orders.Count)
        msg &= "Average number of Orders per customer: " &
               averageOrderCount & vbCrLf

        Dim venezuelaTotalOrders = Aggregate cust In db.Customers
                                   Where cust.Country = "Venezuela"
                                   Into Sum(cust.Orders.Count)
        msg &= "Total number of orders from Customers in Venezuela: " &
               venezuelaTotalOrders & vbCrLf

        MsgBox(msg)

        Dim averageCustomersByCity = From cust In db.Customers
                                     Group By cust.City
                                     Into Average(cust.Orders.Count)
                                     Order By Average

        DataGridView1.DataSource = averageCustomersByCity

        'Another way to grab the count and sum

        londonCustomerCount = (From cust in db.Customers
                               Where cust.City = "London").Count()

        venezuelaTotalOrders = (From cust in db.Customers
                                Where cust.Country = "Venezuela"
                                Select cust.Orders).Sum()
        '</Snippet13>
    End Sub
End Class
