// <Types>
type SteeringWheel = { Type: string }
type CarInterior = { Steering: SteeringWheel; Seats: int }
type Car = { Interior: CarInterior; ExteriorColor: string option }
// </Types>

let myCar = { 
    Interior = { 
        Steering = { Type = "wheel" }
        Seats = 4 
    }
    ExteriorColor = Some "red" 
}

// <Before>
let beforeThisFeature x = 
    { x with Interior = { x.Interior with 
                            Steering = {x.Interior.Steering with Type = "yoke"}
                            Seats = 5
                        }
    }
// </Before>

// <After>
let withTheFeature x = { x with Interior.Steering.Type = "yoke"; Interior.Seats = 5 }
// </After>

let updatedCar1 = beforeThisFeature myCar
let updatedCar2 = withTheFeature myCar

printfn "Before: %A" updatedCar1
printfn "After: %A" updatedCar2

// <Anonymous>
let alsoWorksForAnonymous (x:Car) = {| x with Interior.Seats = 7; Price = 99_999 |}
// </Anonymous>
let anonResult = alsoWorksForAnonymous myCar
printfn "Anonymous: %A" anonResult
