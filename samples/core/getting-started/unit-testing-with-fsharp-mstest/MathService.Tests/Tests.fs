namespace MathService.Tests

open System
open Microsoft.VisualStudio.TestTools.UnitTesting
open MathService

[<TestClass>]
type TestClass () =

    [<TestMethod>]
    member this.TestMethodPassing() =
        Assert.IsTrue(true)

    //[<TestMethod>]
    // member this.FailEveryTime() = Assert.IsTrue(false)

    [<TestMethod>]
    member this.TestEvenSequence() = 
        let expected = Seq.empty<int> |> Seq.toList
        let actual = MyMath.sumOfSquares [2; 4; 6; 8; 10]
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member public this.SumOnesAndEvens() =
        let expected = [1; 1; 1; 1]
        let actual = MyMath.sumOfSquares [2; 1; 4; 1; 6; 1; 8; 1; 10]
        Assert.AreEqual(expected, actual)

    [<TestMethod>]
    member public this.TestSquaresOfOdds() =
        let expected = [1; 9; 25; 49; 81]
        let actual = MyMath.sumOfSquares [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        Assert.AreEqual(expected, actual)
