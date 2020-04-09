' <snippet5>
Imports System.Collections.Generic
Imports SimpleMVVM.Model

Namespace SimpleMVVM.ViewModel

    Public Class CustomerViewModel
        Inherits ViewModelBase

        Private _customers As List(Of Customer)
        Private _currentCustomer As Customer
        Private _repository As CustomerRepository
        Private _updateCustomerCommand As RelayCommand

        Public Sub New()
            _repository = New CustomerRepository()
            _customers = _repository.GetCustomers()

            WireCommands()
        End Sub

        Private Sub WireCommands()
            UpdateCustomerCommand = New RelayCommand(AddressOf UpdateCustomer)
        End Sub

        Public Property UpdateCustomerCommand() As RelayCommand
            Get
                Return _updateCustomerCommand
            End Get
            Private Set(value As RelayCommand)
                _updateCustomerCommand = value
            End Set
        End Property

        Public Property Customers() As List(Of Customer)
            Get
                Return _customers
            End Get
            Set(value As List(Of Customer))
                _customers = value
            End Set
        End Property

        Public Property CurrentCustomer() As Customer
            Get
                Return _currentCustomer
            End Get
            Set(value As Customer)
                If _currentCustomer.Equals(value) Then
                    _currentCustomer = value
                    OnPropertyChanged("CurrentCustomer")
                    UpdateCustomerCommand.IsEnabled = True
                End If
            End Set
        End Property

        Public Sub UpdateCustomer()
            _repository.UpdateCustomer(CurrentCustomer)
        End Sub
    End Class
End Namespace
' </snippet5>

