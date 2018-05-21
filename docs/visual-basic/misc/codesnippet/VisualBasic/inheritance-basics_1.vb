    Const BonusRate As Decimal = 1.45D
    Const PayRate As Decimal = 14.75D

    Class Payroll
        Overridable Function PayEmployee( 
            ByVal HoursWorked As Decimal, 
            ByVal PayRate As Decimal) As Decimal

            PayEmployee = HoursWorked * PayRate
        End Function
    End Class

    Class BonusPayroll
        Inherits Payroll
        Overrides Function PayEmployee( 
            ByVal HoursWorked As Decimal, 
            ByVal PayRate As Decimal) As Decimal

            ' The following code calls the original method in the base 
            ' class, and then modifies the returned value.
            PayEmployee = MyBase.PayEmployee(HoursWorked, PayRate) * BonusRate
        End Function
    End Class

    Sub RunPayroll()
        Dim PayrollItem As Payroll = New Payroll
        Dim BonusPayrollItem As New BonusPayroll
        Dim HoursWorked As Decimal = 40

        MsgBox("Normal pay is: " & 
            PayrollItem.PayEmployee(HoursWorked, PayRate))
        MsgBox("Pay with bonus is: " & 
            BonusPayrollItem.PayEmployee(HoursWorked, PayRate))
    End Sub