Option Strict On
Option Explicit On
Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Linq
Imports System.Text
Imports System.Threading

Class Order
    Public Overrides Function ToString() As String
        Return "Order"
    End Function
End Class

Class Orders
    Public Sub New(ByVal numOrders As Integer)
    End Sub

    Public Sub New(ByVal custID As String)
    End Sub

    Public OrderData As Order()
End Class

Class IntroSnippets
    Private Shared _displayOrders As Boolean = True

    Public Shared Sub Test()

        '<snippet1>
        ' Initialize by using default Lazy<T> constructor. The 
        'Orders array itself is not created yet.
        Dim _orders As Lazy(Of Orders) = New Lazy(Of Orders)()
        '</snippet1>
    End Sub

    Public Shared Sub DisplayOrders(ByVal orders As Order())
    End Sub

    Public Shared Sub Test2()
        '<snippet2>
        ' Initialize by invoking a specific constructor on Order 
        ' when Value property is accessed
        Dim _orders As Lazy(Of Orders) = New Lazy(Of Orders)(Function() New Orders(100))
        '</snippet2>


        '<snippet3>
        ' We need to create the array only if _displayOrders is true
        If _displayOrders = True Then
            DisplayOrders(_orders.Value.OrderData)
        Else
            ' Don't waste resources getting order data.
        End If
        '</snippet3>

        '<snippet4>
        _orders = New Lazy(Of Orders)(Function() New Orders(10))
        '</snippet4>
    End Sub
End Class


'<snippet5>
Class Customer
    Private _orders As Lazy(Of Orders)
    Public Shared CustomerID As String
    Public Sub New(ByVal id As String)
        CustomerID = id
        _orders = New Lazy(Of Orders)(Function()
                                          ' You can specify additional 
                                          ' initialization steps here
                                          Return New Orders(CustomerID)
                                      End Function)

    End Sub
    Public ReadOnly Property MyOrders As Orders

        Get
            Return _orders.Value
        End Get

    End Property

End Class
'</snippet5>

Class TestClass

    '<snippet6>
    <ThreadStatic()>
    Shared counter As Integer
    '</snippet6>

    '<snippet7>
    Dim betterCounter As ThreadLocal(Of Integer) = New ThreadLocal(Of Integer)(Function() 1)
    '</snippet7>
End Class

Class DataInitializedFromDb

    Private _count As Integer
    Public Sub New(ByVal reader As SqlDataReader)

    End Sub
    Public Property Count As Integer
        Get
            Return _count
        End Get
        Set(ByVal value As Integer)
            _count = value
        End Set
    End Property
End Class

Class LazyProgram
    Public Shared Sub Main()
        LazyAndThreadLocal()
        TestEnsureInitialized()

        Console.WriteLine("Press any key to exit")
        Console.ReadKey()
    End Sub

    Private Shared Sub LazyAndThreadLocal()
        '<snippet8>
        ' Initialize the integer to the managed thread id of the 
        ' first thread that accesses the Value property.
        Dim number As Lazy(Of Integer) = New Lazy(Of Integer)(Function()
                                                                  Return Thread.CurrentThread.ManagedThreadId
                                                              End Function)

        Dim t1 As New Thread(Sub()
                                 Console.WriteLine("number on t1 = {0} threadID = {1}",
                                                   number.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t1.Start()

        Dim t2 As New Thread(Sub()
                                 Console.WriteLine("number on t2 = {0} threadID = {1}",
                                                   number.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t2.Start()

        Dim t3 As New Thread(Sub()
                                 Console.WriteLine("number on t3 = {0} threadID = {1}",
                                                   number.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t3.Start()

        ' Ensure that thread IDs are not recycled if the 
        ' first thread completes before the last one starts.
        t1.Join()
        t2.Join()
        t3.Join()

        ' Sample Output:
        '       number on t1 = 11 ThreadID = 11
        '       number on t3 = 11 ThreadID = 13
        '       number on t2 = 11 ThreadID = 12
        '       Press any key to exit.
        '</snippet8>

        '<snippet9>
        ' Initialize the integer to the managed thread id on a per-thread basis.
        Dim threadLocalNumber As New ThreadLocal(Of Integer)(Function() Thread.CurrentThread.ManagedThreadId)
        Dim t4 As New Thread(Sub()
                                 Console.WriteLine("number on t4 = {0} threadID = {1}",
                                                   threadLocalNumber.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t4.Start()

        Dim t5 As New Thread(Sub()
                                 Console.WriteLine("number on t5 = {0} threadID = {1}",
                                                   threadLocalNumber.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t5.Start()

        Dim t6 As New Thread(Sub()
                                 Console.WriteLine("number on t6 = {0} threadID = {1}",
                                                   threadLocalNumber.Value, Thread.CurrentThread.ManagedThreadId)
                             End Sub)
        t6.Start()

        ' Ensure that thread IDs are not recycled if the 
        ' first thread completes before the last one starts.
        t4.Join()
        t5.Join()
        t6.Join()

        'Sample(Output)
        '      threadLocalNumber on t4 = 14 ThreadID = 14 
        '      threadLocalNumber on t5 = 15 ThreadID = 15
        '      threadLocalNumber on t6 = 16 ThreadID = 16 
        '</snippet9>
    End Sub

    Private Shared Sub TestEnsureInitialized()

        Dim _orders(100) As Order
        Dim displayOrderInfo As Boolean = True

        '<snippet10>
        ' Assume that _orders contains null values, and
        ' we only need to initialize them if displayOrderInfo is true
        If displayOrderInfo = True Then


            For i As Integer = 0 To _orders.Length
                ' Lazily initialize the orders without wrapping them in a Lazy(Of T)
                LazyInitializer.EnsureInitialized(_orders(i), Function()
                                                                  ' Returns the value that will be placed in the ref parameter.
                                                                  Return GetOrderForIndex(i)
                                                              End Function)
            Next
        End If
        '</snippet10>

        For Each v As Order In _orders
            Console.WriteLine(v.ToString())
        Next
    End Sub

    ' Dummy Method for snippet 10
    Shared Function GetOrderForIndex(ByVal slot As Integer) As Order
        Return New Order()
    End Function


End Class