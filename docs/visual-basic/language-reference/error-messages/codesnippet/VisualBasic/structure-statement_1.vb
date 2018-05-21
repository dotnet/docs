    Public Structure employee
        ' Public members, accessible from throughout declaration region.
        Public firstName As String
        Public middleName As String
        Public lastName As String
        ' Friend members, accessible from anywhere within the same assembly.
        Friend employeeNumber As Integer
        Friend workPhone As Long
        ' Private members, accessible only from within the structure itself.
        Private homePhone As Long
        Private level As Integer
        Private salary As Double
        Private bonus As Double
        ' Procedure member, which can access structure's private members.
        Friend Sub calculateBonus(ByVal rate As Single)
            bonus = salary * CDbl(rate)
        End Sub
        ' Property member to return employee's eligibility.
        Friend ReadOnly Property eligible() As Boolean
            Get
                Return level >= 25
            End Get
        End Property
        ' Event member, raised when business phone number has changed.
        Public Event changedWorkPhone(ByVal newPhone As Long)
    End Structure