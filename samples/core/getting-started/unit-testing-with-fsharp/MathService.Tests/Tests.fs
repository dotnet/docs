module Tests

open System
open Xunit

open MathService

[<Fact>]
let ``My test`` () =
    Assert.True(true)

//[<Fact>]
//let ``Fail every time`` () = Assert.True(false)

[<Fact>]
let ``SquaresOfOdds works`` () =
    let expected = [1; 9; 25; 49; 81]
    let actual = MyMath.sumOfSquares [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    Assert.Equal(expected, actual)
