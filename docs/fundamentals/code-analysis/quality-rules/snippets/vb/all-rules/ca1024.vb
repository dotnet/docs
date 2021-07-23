Imports System.Globalization

Namespace ca1024
    ' <snippet1>
    Public Class Appointment
        Shared nextAppointmentID As Long
        Shared discountScale As Double() = {5.0, 10.0, 33.0}
        Private customerName As String
        Private customerID As Long
        Private [when] As Date

        ' Static constructor.
        Shared Sub New()
            ' Initializes the static variable for Next appointment ID.
        End Sub

        ' This method violates the rule, but should not be a property.
        ' This method has an observable side effect. 
        ' Calling the method twice in succession creates different results.
        Public Shared Function GetNextAvailableID() As Long
            nextAppointmentID += 1
            Return nextAppointmentID - 1
        End Function

        ' This method violates the rule, but should not be a property.
        ' This method performs a time-consuming operation. 
        ' This method returns an array.
        Public Function GetCustomerHistory() As Appointment()
            ' Connect to a database to get the customer's appointment history.
            Return LoadHistoryFromDB(customerID)
        End Function

        ' This method violates the rule, but should not be a property.
        ' This method is static but returns a mutable object.
        Public Shared Function GetDiscountScaleForUpdate() As Double()
            Return discountScale
        End Function

        ' This method violates the rule, but should not be a property.
        ' This method performs a conversion.
        Public Function GetWeekDayString() As String
            Return DateTimeFormatInfo.CurrentInfo.GetDayName([when].DayOfWeek)
        End Function

        ' These methods violate the rule and should be properties.
        ' They each set or return a piece of the current object's state.

        Public Function GetWeekDay() As DayOfWeek
            Return [when].DayOfWeek
        End Function

        Public Sub SetCustomerName(customerName As String)
            Me.customerName = customerName
        End Sub

        Public Function GetCustomerName() As String
            Return customerName
        End Function

        Public Sub SetCustomerID(customerID As Long)
            Me.customerID = customerID
        End Sub

        Public Function GetCustomerID() As Long
            Return customerID
        End Function

        Public Sub SetScheduleTime([when] As Date)
            Me.[when] = [when]
        End Sub

        Public Function GetScheduleTime() As Date
            Return [when]
        End Function

        ' Time-consuming method that is called by GetCustomerHistory.
        Private Function LoadHistoryFromDB(customerID As Long) As Appointment()
            Dim records As ArrayList = New ArrayList()
            Return CType(records.ToArray(), Appointment())
        End Function
    End Class

    ' </snippet1>
End Namespace
