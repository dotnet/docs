        ' Create a new instance of a Car.
        Dim theCar As New Car()
        theCar.Accelerate(30)
        theCar.Accelerate(20)
        theCar.Accelerate(-5)

        Debug.WriteLine(theCar.Speed.ToString)
        ' Output: 45