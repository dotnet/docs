type MyClass2(dataIn) as self =
    let data = dataIn
    do self.PrintMessage()

    member this.PrintMessage() =
        printf "Creating MyClass2 with Data %d" data
