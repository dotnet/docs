type ArrayContainer(start, finish) =
    let internalArray = [| start .. finish |]
    member this.RangeSeq = Seq.readonly internalArray
    member this.RangeArray = internalArray

let newArray = new ArrayContainer(1, 10)
let rangeSeq = newArray.RangeSeq
let rangeArray = newArray.RangeArray

// These lines produce an error:
//let myArray = rangeSeq :> int array
//myArray[0] <- 0

// The following line does not produce an error.
// It does not preserve encapsulation.
rangeArray[0] <- 0