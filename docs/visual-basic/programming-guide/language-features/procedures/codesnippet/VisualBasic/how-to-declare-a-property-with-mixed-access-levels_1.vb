  Public Class employee
      Private salaryValue As Double
      Protected Property salary() As Double
          Get
              Return salaryValue
          End Get
          Private Set(ByVal value As Double)
              salaryValue = value
          End Set
      End Property
  End Class