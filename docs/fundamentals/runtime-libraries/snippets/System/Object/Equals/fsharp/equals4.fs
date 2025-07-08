module equals4

// <Snippet1>
[<Struct; CustomEquality; NoComparison>]
type Complex =
    val mutable re: double
    val mutable im: double

    override this.Equals(obj) =
        match obj with 
        | :? Complex as c when c = this -> true
        | _ -> false 

    override this.GetHashCode() =
        (this.re, this.im).GetHashCode()

    override this.ToString() =
        $"({this.re}, {this.im})"

    static member op_Equality (x: Complex, y: Complex) =
        x.re = y.re && x.im = y.im

    static member op_Inequality (x: Complex, y: Complex) =
        x = y |> not

let mutable cmplx1 = Complex()
let mutable cmplx2 = Complex()

cmplx1.re <- 4.0
cmplx1.im <- 1.0

cmplx2.re <- 2.0
cmplx2.im <- 1.0

printfn $"{cmplx1} <> {cmplx2}: {cmplx1 <> cmplx2}"
printfn $"{cmplx1} = {cmplx2}: {cmplx1.Equals cmplx2}"

cmplx2.re <- 4.0

printfn $"{cmplx1} = {cmplx2}: {cmplx1 = cmplx2}"
printfn $"{cmplx1} = {cmplx2}: {cmplx1.Equals cmplx2}"

// The example displays the following output:
//       (4, 1) <> (2, 1): True
//       (4, 1) = (2, 1): False
//       (4, 1) = (4, 1): True
//       (4, 1) = (4, 1): True
// </Snippet1>