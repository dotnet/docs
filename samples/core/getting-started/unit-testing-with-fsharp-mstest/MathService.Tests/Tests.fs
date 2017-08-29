namespace MathService.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open MathService

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing () =
        Assert.IsTrue(true);


    //[<TestMethod>]
    //member this.FailEveryTime() = Assert.IsTrue(false)

    [<TestMethod>]
    member this.SquaresOfOdds() =
        let expected = [1; 9; 25; 49; 81]
        let actual = MyMath.sumOfSquares [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        Assert.Equals(expected, actual)
