// Nested record field copy and update
type SteeringWheel = { Type: string }
type CarInterior = { Steering: SteeringWheel; Seats: int }
type Car = { Interior: CarInterior; ExteriorColor: string option }

let myCar = { 
    Interior = { 
        Steering = { Type = "wheel" }
        Seats = 4 
    }
    ExteriorColor = Some "red" 
}

// Before F# 8
let beforeThisFeature x = 
    { x with Interior = { x.Interior with 
                            Steering = {x.Interior.Steering with Type = "yoke"}
                            Seats = 5
                        }
    }

// With F# 8
let withTheFeature x = { x with Interior.Steering.Type = "yoke"; Interior.Seats = 5 }

let updatedCar1 = beforeThisFeature myCar
let updatedCar2 = withTheFeature myCar

printfn "Before: %A" updatedCar1
printfn "After: %A" updatedCar2

// Works for anonymous records too
let alsoWorksForAnonymous (x:Car) = {| x with Interior.Seats = 7; Price = 99_999 |}
let anonResult = alsoWorksForAnonymous myCar
printfn "Anonymous: %A" anonResult
