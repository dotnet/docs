  Class employee
      ' Only code inside class employee can change the value of hireDateValue.
      Private hireDateValue As Date
      ' Any code that can access class employee can read property dateHired.
      Public ReadOnly Property dateHired() As Date
          Get
              Return hireDateValue
          End Get
      End Property
  End Class