type MyClassBase2(x: int) =
    let mutable z = x * x

    do
        for i in 1..z do
            printf "%d " i


type MyClassDerived2(y: int) =
    inherit MyClassBase2(y * 2)

    do
        for i in 1..y do
            printf "%d " i
