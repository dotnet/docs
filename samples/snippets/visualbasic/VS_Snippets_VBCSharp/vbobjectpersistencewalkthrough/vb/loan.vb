Namespace UnSerialized
    '<Snippet1>
    Public Class Loan
        Implements System.ComponentModel.INotifyPropertyChanged

        Public Property LoanAmount As Double
        Public Property InterestRate As Double
        Public Property Term As Integer

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

        Public Sub New(ByVal loanAmount As Double,
                       ByVal interestRate As Double,
                       ByVal term As Integer,
                       ByVal customer As String)

            Me.LoanAmount = loanAmount
            Me.InterestRate = interestRate
            Me.Term = term
            p_Customer = customer
        End Sub
    End Class
    '</Snippet1>
End Namespace

Namespace LoanClass
    '<Snippet4>
    <Serializable()>
    Public Class Loan
        '</Snippet4>
        Implements System.ComponentModel.INotifyPropertyChanged

        Public Property LoanAmount As Double
        Public Property InterestRate As Double
        Public Property Term As Integer

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

        '<Snippet5>
        <NonSerialized()>
        Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler _
          Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        '</Snippet5>

        Public Sub New(ByVal loanAmount As Double,
                       ByVal interestRate As Double,
                       ByVal term As Integer,
                       ByVal customer As String)

            Me.LoanAmount = loanAmount
            Me.InterestRate = interestRate
            Me.Term = term
            p_Customer = customer
        End Sub
    End Class
End Namespace


