      Dim value As New Complex(Double.MinValue/2, Double.MinValue/2)
      Dim value2 As Complex = Complex.Exp(Complex.Log(value))
      Console.WriteLine("{0} {3}{1} {3}Equal: {2}", value, value2, 
                                                    value = value2,
                                                    vbCrLf)
      ' The example displays the following output:
      '    (-8.98846567431158E+307, -8.98846567431158E+307)
      '    (-8.98846567431161E+307, -8.98846567431161E+307)
      '    Equal: False