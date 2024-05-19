type Car =
    { Make: string
      Model: string
      mutable Odometer: int }

let myCar =
    { Make = "Fabrikam"
      Model = "Coupe"
      Odometer = 108112 }

myCar.Odometer <- myCar.Odometer + 21
