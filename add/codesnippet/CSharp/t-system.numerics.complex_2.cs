      Complex value = new Complex(Double.MinValue/2, Double.MinValue/2);
      Complex value2 = Complex.Exp(Complex.Log(value));
      Console.WriteLine("{0} \n{1} \nEqual: {2}", value, value2, 
                                                  value == value2);
      // The example displays the following output:
      //    (-8.98846567431158E+307, -8.98846567431158E+307)
      //    (-8.98846567431161E+307, -8.98846567431161E+307)
      //    Equal: False