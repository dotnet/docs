Imports System.Linq
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Diagnostics


Class Samples1

  Dim orders As New List(Of Order)
  Dim customers As New List(Of Customer)
  Dim WithEvents Form1 As Form
  Dim WithEvents ToolStripMenuItem1 As ToolStripMenuItem
  Dim WithEvents MainMenuStrip As MenuStrip

  '<Snippet1>
  Dim collection As System.Diagnostics. 
         InstanceDataCollectionCollection
  '</Snippet1>

  '<Snippet2>
  ' Here is a comment.
  '</Snippet2>

  '<Snippet3>
  Sub Main()
    For Each argument As String In My.Application.CommandLineArgs
      ' Add code here to use the string variable.
    Next
  End Sub
  '</Snippet3>

  Sub ConstantsSample()
    '<Snippet4>
    MsgBox("hello" & vbCrLf & "goodbye")
    '</Snippet4>
  End Sub


  Sub StringBuilderSample()
    '<Snippet5>
    Dim longString As New System.Text.StringBuilder
    For count As Integer = 1 To 1000
      longString.Append(count)
    Next
    '</Snippet5>
  End Sub

  '<Snippet6>
  Public Sub GetQuery()
    Dim filterValue = "London"
    Dim query = From customer In customers 
                Where customer.Country = filterValue
  End Sub
  '</Snippet6>

  '<Snippet7>
  Public Sub Form1_Load() Handles Form1.Load
  End Sub
  '</Snippet7>

  Sub ArraySamples()
    '<Snippet8>
    Dim letters1 As String() = {"a", "b", "c"}
    '</Snippet8>
    '<Snippet9>
    Dim letters2() As String = New String() {"a", "b", "c"}
    '</Snippet9>
    '<Snippet10>
    Dim letters3() As String = {"a", "b", "c"}
    '</Snippet10>
    '<Snippet11>
    Dim letters4 As String() = {"a", "b", "c"}
    '</Snippet11>
    '<Snippet12>
    Dim letters5() As String = {"a", "b", "c"}
    '</Snippet12>
    '<Snippet13>
    Dim letters6(2) As String
    letters6(0) = "a"
    letters6(1) = "b"
    letters6(2) = "c"
    '</Snippet13>
  End Sub

  Sub WithSample()
    Dim orderLog As New EventLog()
    '<Snippet15>
    With orderLog
      .Log = "Application"
      .Source = "Application Name"
      .MachineName = "Computer Name"
    End With
    '</Snippet15>
  End Sub

  Sub InferenceSamples()
    Dim names As New List(Of String)
    '<Snippet16>
    For count = 0 To 2
      MsgBox(names(count))
    Next
    '</Snippet16>
    '<Snippet17>
    For Each name In names
      MsgBox(name)
    Next
    '</Snippet17>
  End Sub

  Sub ExceptionHandlingSample()
    '<Snippet18>
    Dim conn As New SqlConnection("connection string")
    Try
      Conn.Open()
    Catch ex As SqlException

    Finally
      Conn.Close()
    End Try
    '</Snippet18>

    '<Snippet19>
    Using redPen As New Pen(color.Red)
      ' Insert code here.
    End Using
    '</Snippet19>

  End Sub

  Sub AndAlsoOrElseSample()
    Dim testCondition = False
    Dim nullableObject As String = Nothing
    Dim testValue = ""

    '<Snippet20>
    ' Avoid a null reference exception. If the left side of the AndAlso 
    ' operator is False, the right side is not evaluated and a null 
    ' exception is not thrown.
    If nullableObject IsNot Nothing AndAlso nullableObject = testValue Then

    End If

    ' Avoid an unnecessary resource-intensive operation. If the left side
    ' of the OrElse operator is True, the right side is not evaluated and 
    ' a resource-intensive operation is not called.
    If testCondition OrElse ResourceIntensiveOperation() Then

    End If
    '</Snippet20>
  End Sub

  Function ResourceIntensiveOperation() As Boolean
    Return True
  End Function


  Sub NewObjectsSamples()
    '<Snippet21>
    Dim employees As New List(Of String)
    '</Snippet21>

    '<Snippet22>
    Dim employees2 As List(Of String) = New List(Of String)
    '</Snippet22>

    '<Snippet23> 
    Dim orderLog As New EventLog With { 
        .Log = "Application", 
        .Source = "Application Name", 
        .MachineName = "Computer Name"}
    '</Snippet23>
  End Sub

  '<Snippet24> 
  Private Sub ToolStripMenuItem1_Click() Handles ToolStripMenuItem1.Click
  End Sub
  '</Snippet24>

  Sub ToolStripMenuSample()
    '<Snippet25> 
    Dim closeItem As New ToolStripMenuItem( 
        "Close", Nothing, AddressOf ToolStripMenuItem1_Click)
    Me.MainMenuStrip.Items.Add(closeItem)
    '</Snippet25>
  End Sub

  '<Snippet26>
  Public Event SampleEvent As EventHandler(Of SampleEventArgs)
  ' or
  Public Event SampleEvent(ByVal source As Object, 
                            ByVal e As SampleEventArgs)
  '</Snippet26>

  '<Snippet27> 
  Private Function GetHtmlDocument( 
      ByVal items As IEnumerable(Of XElement)) As String

    Dim htmlDoc = <html>
                    <body>
                      <table border="0" cellspacing="2">
                        <%= 
                          From item In items 
                          Select <tr>
                                   <td style="width:480">
                                     <%= item.<title>.Value %>
                                   </td>
                                   <td><%= item.<pubDate>.Value %></td>
                                 </tr> 
                        %>
                      </table>
                    </body>
                  </html>

    Return htmlDoc.ToString()
  End Function
  '</Snippet27>

  Sub LINQSamples()
    '<Snippet28>
    Dim seattleCustomers = From cust In customers 
                           Where cust.City = "Seattle"
    '</Snippet28>
    '<Snippet29>
    Dim customerOrders = From customer In customers 
                         Join order In orders 
                           On customer.CustomerID Equals order.CustomerID 
                         Select Customer = customer, Order = order
    '</Snippet29>
    '<Snippet30> 
    Dim customerOrders2 = From cust In customers 
                          Join ord In orders
                            On cust.CustomerID Equals ord.CustomerID 
                          Select CustomerName = cust.Name, 
                                 OrderID = ord.ID
    '</Snippet30>
    '<Snippet31>
    Dim customerList = From cust In customers
    '</Snippet31>
    '<Snippet32>
    Dim newyorkCustomers = From cust In customers 
                           Where cust.City = "New York" 
                           Select cust.LastName, cust.CompanyName
    '</Snippet32>
    '<Snippet33>
    Dim newyorkCustomers2 = From cust In customers 
                            Where cust.City = "New York" 
                            Order By cust.LastName
    '</Snippet33>
    '<Snippet34>
    Dim customerList2 = From cust In customers 
                        Join order In orders 
                          On cust.CustomerID Equals order.CustomerID 
                        Select cust, order
    '</Snippet34>
  End Sub
End Class

Class Customer
  Public LastName As String
  Public Name As String
  Public Country As String
  Public City As String
  Public CompanyName As String
  Public CustomerID As String
  Public State As String
  Public Orders As List(Of Order)
  Public Subscriber As Boolean
End Class

Class Order
  Public ID As Integer
  Public CustomerID As String
  Public Total As Double
  Public OrderDate As DateTime
End Class

Class WhatHappenedEventArgs
  Inherits EventArgs
End Class
