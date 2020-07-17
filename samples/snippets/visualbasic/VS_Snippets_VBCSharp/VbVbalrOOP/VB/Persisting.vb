' Need a reference to System.Runtime.Serialization.Formatters.Soap
' And System.Xml
' <snippet83>
Imports System.Runtime.Serialization.Formatters.Soap
' </snippet83>
' <snippet80>
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
' </snippet80>

Class Classcb0a091708d54578ad2b3764ccf6167f
    ' cb0a0917-08d5-4578-ad2b-3764ccf6167f
    ' Walkthrough: Persisting an Object in Visual Basic

    Class Form77
        Inherits Form

        Dim TextBox1 As New TextBox
        Dim TextBox2 As New TextBox
        Dim TextBox3 As New TextBox
        Dim TextBox4 As New TextBox

        ' <snippet77>
        Private TestLoan As New LoanClass.Loan
        Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load

            TextBox1.Text = TestLoan.LoanAmount.ToString
            TextBox2.Text = TestLoan.InterestRate.ToString
            TextBox3.Text = TestLoan.Term.ToString
            TextBox4.Text = TestLoan.Customer
        End Sub
        ' </snippet77>

    End Class

    Class Form81
        Inherits Form

        Dim TextBox1 As New TextBox
        Dim TextBox2 As New TextBox
        Dim TextBox3 As New TextBox
        Dim TextBox4 As New TextBox


        ' <snippet119>
        Const FileName As String = "SavedLoan.bin"
        ' </snippet119>

        ' <snippet81>
        Private WithEvents TestLoan As Loans.Loan

        Private Sub Form1_Load() Handles MyBase.Load
            AddHandler TestLoan.PropertyChanged, AddressOf Me.CustomerPropertyChanged

            If File.Exists(FileName) Then
                Dim TestFileStream As Stream = File.OpenRead(FileName)
                Dim deserializer As New BinaryFormatter
                TestLoan = CType(deserializer.Deserialize(TestFileStream), Loans.Loan)
                TestFileStream.Close()
            End If
            TextBox1.Text = TestLoan.LoanAmount.ToString
            TextBox2.Text = TestLoan.InterestRate.ToString
            TextBox3.Text = TestLoan.Term.ToString
            TextBox4.Text = TestLoan.Customer
        End Sub
        ' </snippet81>

        ' <snippet82>
        Private Sub Form1_Closing() Handles MyBase.Closing
            TestLoan.LoanAmount = CType(TextBox1.Text, Double)
            TestLoan.InterestRate = CType(TextBox2.Text, Double)
            TestLoan.Term = CType(TextBox3.Text, Integer)
            TestLoan.Customer = TextBox4.Text

            Dim TestFileStream As Stream = File.Create(FileName)
            Dim serializer As New BinaryFormatter
            serializer.Serialize(TestFileStream, TestLoan)
            TestFileStream.Close()
        End Sub
        ' </snippet82>

        ' <snippet122>
        Public Sub CustomerPropertyChanged(
            ByVal sender As Object,
            ByVal e As System.ComponentModel.PropertyChangedEventArgs
            ) Handles TestLoan.PropertyChanged

            MsgBox(e.PropertyName & " has been changed.")
        End Sub

        ' </snippet122>
    End Class


    Class LoanClass
        Class Class78
            ' <snippet78>
            <Serializable()>
            Public Class Loan
                ' </snippet78>
                Implements System.ComponentModel.INotifyPropertyChanged

                ' <snippet79>
                <NonSerialized()>
                Public Customer As String
                ' </snippet79>

                ' <snippet123>
                <NonSerialized()>
                Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler _
                  Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
                ' </snippet123>
            End Class
        End Class

        <Serializable()> Public Class Loan
            ' <snippet76>
            Public LoanAmount As Double = 10000.0
            Public InterestRate As Double = 7.5
            Public Term As Integer = 36
            Public Customer As String
            ' </snippet76>
        End Class
    End Class

    Class Loans
        ' <snippet121>
        Public Class Loan
            Implements System.ComponentModel.INotifyPropertyChanged

            Public Property LoanAmount As Double = 10000.0
            Public Property InterestRate As Double = 7.5
            Public Property Term As Integer = 36

            Private p_Customer As String
            Public Property Customer As String
                Get
                    Return p_Customer
                End Get
                Set(ByVal value As String)
                    p_Customer = value
                    RaiseEvent PropertyChanged(Me,
                      New System.ComponentModel.PropertyChangedEventArgs("Customer"))
                End Set
            End Property

            Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler _
              Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        End Class
        ' </snippet121>
    End Class


    Public Sub Method84()
        ' <snippet84>
        Dim deserializer As New BinaryFormatter
        ' </snippet84>
        ' <snippet118>
        Dim serializer As New BinaryFormatter
        ' </snippet118>
    End Sub

    Public Sub Method85()
        ' <snippet85>
        Dim deserializer As New SoapFormatter
        ' </snippet85>

        ' <snippet86>
        Dim serializer As New SoapFormatter
        ' </snippet86>
    End Sub

End Class
