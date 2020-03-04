'<Snippet6>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
'</Snippet6>
'<Snippet10>
Imports System.Runtime.Serialization.Formatters.Soap
'</Snippet10>

Public Class Form1
    '<Snippet7>
    Const FileName As String = "..\..\SavedLoan.bin"
    '</Snippet7>

    '<Snippet8>
    Private WithEvents TestLoan As New LoanClass.Loan(10000.0, 0.075, 36, "Neil Black")

    Private Sub Form1_Load() Handles MyBase.Load
        If File.Exists(FileName) Then
            Dim TestFileStream As Stream = File.OpenRead(FileName)
            Dim deserializer As New BinaryFormatter
            TestLoan = CType(deserializer.Deserialize(TestFileStream), LoanClass.Loan)
            TestFileStream.Close()
        End If

        AddHandler TestLoan.PropertyChanged, AddressOf Me.CustomerPropertyChanged

        TextBox1.Text = TestLoan.LoanAmount.ToString
        TextBox2.Text = TestLoan.InterestRate.ToString
        TextBox3.Text = TestLoan.Term.ToString
        TextBox4.Text = TestLoan.Customer
    End Sub
    '</Snippet8>

    '<Snippet9>
    Private Sub Form1_FormClosing() Handles MyBase.FormClosing
        TestLoan.LoanAmount = CDbl(TextBox1.Text)
        TestLoan.InterestRate = CDbl(TextBox2.Text)
        TestLoan.Term = CInt(TextBox3.Text)
        TestLoan.Customer = TextBox4.Text

        Dim TestFileStream As Stream = File.Create(FileName)
        Dim serializer As New BinaryFormatter
        serializer.Serialize(TestFileStream, TestLoan)
        TestFileStream.Close()
    End Sub
    '</Snippet9>

    Public Sub CustomerPropertyChanged(
          ByVal sender As Object,
          ByVal e As System.ComponentModel.PropertyChangedEventArgs
        ) Handles TestLoan.PropertyChanged

        MsgBox(e.PropertyName & " has been changed.")
    End Sub
End Class

Public Class Form2
    Inherits Form

    Private TextBox1 As New TextBox
    Private TextBox2 As New TextBox
    Private TextBox3 As New TextBox
    Private TextBox4 As New TextBox

    '<Snippet2>
    Private WithEvents TestLoan As New LoanClass.Loan(10000.0, 0.075, 36, "Neil Black")

    Private Sub Form1_Load() Handles MyBase.Load
        TextBox1.Text = TestLoan.LoanAmount.ToString
        TextBox2.Text = TestLoan.InterestRate.ToString
        TextBox3.Text = TestLoan.Term.ToString
        TextBox4.Text = TestLoan.Customer
    End Sub
    '</Snippet2>

    '<Snippet3>
    Public Sub CustomerPropertyChanged(
          ByVal sender As Object,
          ByVal e As System.ComponentModel.PropertyChangedEventArgs
        ) Handles TestLoan.PropertyChanged

        MsgBox(e.PropertyName & " has been changed.")
    End Sub
    '</Snippet3>
End Class


Public Class Form3
    Inherits Form

    Const FileName As String = "..\..\SavedLoan.xml"

    Private TextBox1 As New TextBox
    Private TextBox2 As New TextBox
    Private TextBox3 As New TextBox
    Private TextBox4 As New TextBox


    Private WithEvents TestLoan As New LoanClass.Loan(10000.0, 0.075, 36, "Neil Black")

    Private Sub Form1_Load() Handles MyBase.Load
        If File.Exists(FileName) Then
            Dim TestFileStream As Stream = File.OpenRead(FileName)
            '<Snippet11>
            Dim deserializer As New SoapFormatter
            '</Snippet11>
            TestLoan = CType(deserializer.Deserialize(TestFileStream), LoanClass.Loan)
            TestFileStream.Close()
        End If

        AddHandler TestLoan.PropertyChanged, AddressOf Me.CustomerPropertyChanged

        TextBox1.Text = TestLoan.LoanAmount.ToString
        TextBox2.Text = TestLoan.InterestRate.ToString
        TextBox3.Text = TestLoan.Term.ToString
        TextBox4.Text = TestLoan.Customer
    End Sub

    Private Sub Form1_FormClosing() Handles MyBase.FormClosing
        TestLoan.LoanAmount = CDbl(TextBox1.Text)
        TestLoan.InterestRate = CDbl(TextBox2.Text)
        TestLoan.Term = CInt(TextBox3.Text)
        TestLoan.Customer = TextBox4.Text

        Dim TestFileStream As Stream = File.Create(FileName)
        '<Snippet12>
        Dim serializer As New SoapFormatter
        '</Snippet12>
        serializer.Serialize(TestFileStream, TestLoan)
        TestFileStream.Close()
    End Sub

    Public Sub CustomerPropertyChanged(
          ByVal sender As Object,
          ByVal e As System.ComponentModel.PropertyChangedEventArgs
        ) Handles TestLoan.PropertyChanged

        MsgBox(e.PropertyName & " has been changed.")
    End Sub
End Class