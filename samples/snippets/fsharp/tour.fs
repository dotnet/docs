// This sample will guide you through elements of the F# language.
//
// *******************************************************************************************************
//   To execute the code in F# Interactive, highlight a section of code and press Alt-Enter or right-click 
//   and select "Execute in Interactive".  You can open the F# Interactive Window from the "View" menu. 
// *******************************************************************************************************
//
// For more about F#, see:
//     http://fsharp.org
//     https://docs.microsoft.com/dotnet/fsharp/
//
// To see this tutorial in documentation form, see:
//     https://docs.microsoft.com/dotnet/fsharp/tour
//
// To learn more about applied F# programming, use
//     http://fsharp.org/guides/enterprise/
//     http://fsharp.org/guides/cloud/
//     http://fsharp.org/guides/web/
//     http://fsharp.org/guides/data-science/
//
// To install the Visual F# Power Tools, use
//     'Tools' --> 'Extensions and Updates' --> `Online` and search
//
// For additional templates to use with F#, see the 'Online Templates' in Visual Studio, 
//     'New Project' --> 'Online Templates'

// F# supports three kinds of comments:

//  1. Double-slash comments.  These are used in most situations.
(*  2. ML-style Block comments.  These aren't used that often. *)
/// 3. Triple-slash comments.  These are used for documenting functions, types, and so on.
///    They will appear as text when you hover over something which is decorated with these comments.
///
///    They also support .NET-style XML comments, which allow you to generate reference documentation,
///    and they also allow editors (such as Visual Studio) to extract information from them.
///    To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/xml-documentation


// Open namespaces using the 'open' keyword.
//
// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/import-declarations-the-open-keyword
open System


/// Modules are the primary way to organize functions and values in F#. This module contains some
/// basic values involving basic numeric values computed in a few different ways.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/modules
module IntegersAndNumbers = 

    /// This is a sample integer.
    let sampleInteger = 176

    /// This is a sample floating point number.
    let sampleDouble = 4.1

    /// This computed a new number by some arithmetic.  Numeric types are converted using
    /// functions 'int', 'double' and so on.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4 + int sampleDouble

    /// This is a list of the numbers from 0 to 99.
    let sampleNumbers = [ 0 .. 99 ]

    /// This is a list of all tuples containing all the numbers from 0 to 99 and their squares.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // The next line prints a list that includes tuples, using an interpolated string.
    printfn $"The table of squares from 0 to 99 is:\n{sampleTableOfSquares}"


/// Values in F# are immutable by default.  They cannot be changed
/// in the course of a program's execution unless explicitly marked as mutable.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/values/index#why-immutable
module Immutability =

    /// Binding a value to a name via 'let' makes it immutable.
    ///
    /// The second line of code compiles, but 'number' from that point onward will shadow the previous definition.
    /// There is no way to access the previous definition of 'number' due to shadowing.
    let number = 2
    // let number = 3

    /// A mutable binding.  This is required to be able to mutate the value of 'otherNumber'.
    let mutable otherNumber = 2

    printfn $"'otherNumber' is {otherNumber}"

    // When mutating a value, use '<-' to assign a new value.
    //
    // Note that '=' is not the same as this.  Outside binding values via 'let', '=' is used to test equality.
    otherNumber <- otherNumber + 1

    printfn $"'otherNumber' changed to be {otherNumber}" 


/// Much of F# programming consists of defining functions that transform input data to produce
/// useful results.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/functions/
module BasicFunctions = 

    /// You use 'let' to define a function. This one accepts an integer argument and returns an integer. 
    /// Parentheses are optional for function arguments, except for when you use an explicit type annotation.
    let sampleFunction1 x = x*x + 3

    /// Apply the function, naming the function return result using 'let'. 
    /// The variable type is inferred from the function return type.
    let result1 = sampleFunction1 4573

    // This line uses '%d' to print the result as an integer. This is type-safe.
    // If 'result1' were not of type 'int', then the line would fail to compile.
    printfn $"The result of squaring the integer 4573 and adding 3 is %d{result1}"

    /// When needed, annotate the type of a parameter name using '(argument:type)'.  Parentheses are required.
    let sampleFunction2 (x:int) = 2*x*x - x/5 + 3

    let result2 = sampleFunction2 (7 + 4)
    printfn $"The result of applying the 2nd sample function to (7 + 4) is %d{result2}"

    /// Conditionals use if/then/elif/else.
    ///
    /// Note that F# uses white space indentation-aware syntax, similar to languages like Python.
    let sampleFunction3 x = 
        if x < 100.0 then 
            2.0*x*x - x/5.0 + 3.0
        else 
            2.0*x*x + x/5.0 - 37.0

    let result3 = sampleFunction3 (6.5 + 4.5)

    // This line uses '%f' to print the result as a float.  As with '%d' above, this is type-safe.
    printfn $"The result of applying the 3rd sample function to (6.5 + 4.5) is %f{result3}"


/// Booleans are fundamental data types in F#.  Here are some examples of Booleans and conditional logic.
///
/// To learn more, see: 
///     https://docs.microsoft.com/dotnet/fsharp/language-reference/primitive-types
///     and
///     https://docs.microsoft.com/dotnet/fsharp/language-reference/symbol-and-operator-reference/boolean-operators
module Booleans =

    /// Booleans values are 'true' and 'false'.
    let boolean1 = true
    let boolean2 = false

    /// Operators on booleans are 'not', '&&' and '||'.
    let boolean3 = not boolean1 && (boolean2 || false)

    // This line uses '%b'to print a boolean value.  This is type-safe.
    printfn $"The expression 'not boolean1 && (boolean2 || false)' is %b{boolean3}"


/// Strings are fundamental data types in F#.  Here are some examples of Strings and basic String manipulation.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/strings
module StringManipulation = 

    /// Strings use double quotes.
    let string1 = "Hello"
    let string2  = "world"

    /// Strings can also use @ to create a verbatim string literal.
    /// This will ignore escape characters such as '\', '\n', '\t', etc.
    let string3 = @"C:\Program Files\"

    /// String literals can also use triple-quotes.
    let string4 = """The computer said "hello world" when I told it to!"""

    /// String concatenation is normally done with the '+' operator.
    let helloWorld = string1 + " " + string2 

    // This line uses '%s' to print a string value.  This is type-safe.
    printfn "%s" helloWorld

    /// Substrings use the indexer notation.  This line extracts the first 7 characters as a substring.
    /// Note that like many languages, Strings are zero-indexed in F#.
    let substring = helloWorld[0..6]
    printfn $"{substring}"


/// Tuples are simple combinations of data values into a combined value.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/tuples
module Tuples =

    /// A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    /// A function that swaps the order of two values in a tuple. 
    ///
    /// F# Type Inference will automatically generalize the function to have a generic type,
    /// meaning that it will work with any type.
    let swapElems (a, b) = (b, a)

    printfn $"The result of swapping (1, 2) is {(swapElems (1,2))}"

    /// A tuple consisting of an integer, a string,
    /// and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.1415)

    printfn $"tuple1: {tuple1}\ttuple2: {tuple2}"

    /// Tuples are normally objects, but they can also be represented as structs.
    ///
    /// These interoperate completely with structs in C# and Visual Basic.NET; however,
    /// struct tuples are not implicitly convertible with object tuples (often called reference tuples).
    ///
    /// The second line below will fail to compile because of this.  Uncomment it to see what happens.
    let sampleStructTuple = struct (1, 2)
    //let thisWillNotCompile: (int*int) = struct (1, 2)

    // Although you can
    let convertFromStructTuple (struct(a, b)) = (a, b)
    let convertToStructTuple (a, b) = struct(a, b)

    printfn $"Struct Tuple: {sampleStructTuple}\nReference tuple made from the Struct Tuple: {(sampleStructTuple |> convertFromStructTuple)}"


/// The F# pipe operators ('|>', '<|', etc.) and F# composition operators ('>>', '<<')
/// are used extensively when processing data.  These operators are themselves functions
/// which make use of Partial Application.
///
/// To learn more about these operators, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/functions/#function-composition-and-pipelining
/// To learn more about Partial Application, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/functions/#partial-application-of-arguments
module PipelinesAndComposition =

    /// Squares a value.
    let square x = x * x

    /// Adds 1 to a value.
    let addOne x = x + 1

    /// Tests if an integer value is odd via modulo.
    ///
    /// '<>' is a binary comparison operator that means "not equal to".
    let isOdd x = x % 2 <> 0

    /// A list of 5 numbers.  More on lists later.
    let numbers = [ 1; 2; 3; 4; 5 ]

    /// Given a list of integers, it filters out the even numbers,
    /// squares the resulting odds, and adds 1 to the squared odds.
    let squareOddValuesAndAddOne values = 
        let odds = List.filter isOdd values
        let squares = List.map square odds
        let result = List.map addOne squares
        result

    printfn $"processing {numbers} through 'squareOddValuesAndAddOne' produces: {squareOddValuesAndAddOne numbers}"
    
    /// A shorter way to write 'squareOddValuesAndAddOne' is to nest each
    /// sub-result into the function calls themselves.
    ///
    /// This makes the function much shorter, but it's difficult to see the
    /// order in which the data is processed.
    let squareOddValuesAndAddOneNested values = 
        List.map addOne (List.map square (List.filter isOdd values))

    printfn $"processing {numbers} through 'squareOddValuesAndAddOneNested' produces: {squareOddValuesAndAddOneNested numbers}"

    /// A preferred way to write 'squareOddValuesAndAddOne' is to use F# pipe operators.
    /// This allows you to avoid creating intermediate results, but is much more readable
    /// than nesting function calls like 'squareOddValuesAndAddOneNested'
    let squareOddValuesAndAddOnePipeline values =
        values
        |> List.filter isOdd
        |> List.map square
        |> List.map addOne

    printfn $"processing {numbers} through 'squareOddValuesAndAddOnePipeline' produces: {squareOddValuesAndAddOnePipeline numbers}"

    /// You can shorten 'squareOddValuesAndAddOnePipeline' by moving the second `List.map` call
    /// into the first, using a Lambda Function.
    ///
    /// Note that pipelines are also being used inside the lambda function.  F# pipe operators
    /// can be used for single values as well.  This makes them very powerful for processing data.
    let squareOddValuesAndAddOneShorterPipeline values =
        values
        |> List.filter isOdd
        |> List.map(fun x -> x |> square |> addOne)

    printfn $"processing {numbers} through 'squareOddValuesAndAddOneShorterPipeline' produces: {squareOddValuesAndAddOneShorterPipeline numbers}"

    /// Lastly, you can eliminate the need to explicitly take 'values' in as a parameter by using '>>'
    /// to compose the two core operations: filtering out even numbers, then squaring and adding one.
    /// Likewise, the 'fun x -> ...' bit of the lambda expression is also not needed, because 'x' is simply
    /// being defined in that scope so that it can be passed to a functional pipeline.  Thus, '>>' can be used
    /// there as well.
    ///
    /// The result of 'squareOddValuesAndAddOneComposition' is itself another function which takes a
    /// list of integers as its input.  If you execute 'squareOddValuesAndAddOneComposition' with a list
    /// of integers, you'll notice that it produces the same results as previous functions.
    ///
    /// This is using what is known as function composition.  This is possible because functions in F#
    /// use Partial Application and the input and output types of each data processing operation match
    /// the signatures of the functions we're using.
    let squareOddValuesAndAddOneComposition =
        List.filter isOdd >> List.map (square >> addOne)

    printfn $"processing {numbers} through 'squareOddValuesAndAddOneComposition' produces: {squareOddValuesAndAddOneComposition numbers}"


/// Lists are ordered, immutable, singly-linked lists.  They are eager in their evaluation.
/// 
/// This module shows various ways to generate lists and process lists with some functions
/// in the 'List' module in the F# Core Library.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/lists
module Lists =

    /// Lists are defined using [ ... ].  This is an empty list.
    let list1 = [ ]  

    /// This is a list with 3 elements.  ';' is used to separate elements on the same line.
    let list2 = [ 1; 2; 3 ]

    /// You can also separate elements by placing them on their own lines.
    let list3 = [
        1
        2
        3
    ]

    /// This is a list of integers from 1 to 1000
    let numberList = [ 1 .. 1000 ]  

    /// Lists can also be generated by computations. This is a list containing 
    /// all the days of the year.
    ///
    /// 'yield' is used for on-demand evaluation. More on this later in Sequences.
    let daysList = 
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2017, month) do 
                  yield System.DateTime(2017, month, day) ]

    // Print the first 5 elements of 'daysList' using 'List.take'.
    printfn $"The first 5 days of 2017 are: {daysList |> List.take 5}"

    /// Computations can include conditionals.  This is a list containing the tuples
    /// which are the coordinates of the black squares on a chess board.
    let blackSquares = 
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do 
                  if (i+j) % 2 = 1 then 
                      yield (i, j) ]

    /// Lists can be transformed using 'List.map' and other functional programming combinators.
    /// This definition produces a new list by squaring the numbers in numberList, using the pipeline 
    /// operator to pass an argument to List.map.
    let squares = 
        numberList 
        |> List.map (fun x -> x*x) 

    /// There are many other list combinations. The following computes the sum of the squares of the 
    /// numbers divisible by 3.
    let sumOfSquares = 
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)

    printfn $"The sum of the squares of numbers up to 1000 that are divisible by 3 is: %d{sumOfSquares}"


/// Arrays are fixed-size, mutable collections of elements of the same type.
///
/// Although they are similar to Lists (they support enumeration and have similar combinators for data processing),
/// they are generally faster and support fast random access.  This comes at the cost of being less safe by being mutable.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/arrays
module Arrays =

    /// This is The empty array.  Note that the syntax is similar to that of Lists, but uses `[| ... |]` instead.
    let array1 = [| |]

    /// Arrays are specified using the same range of constructs as lists.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    /// This is an array of numbers from 1 to 1000.
    let array3 = [| 1 .. 1000 |]

    /// This is an array containing only the words "hello" and "world".
    let array4 = 
        [| for word in array2 do
               if word.Contains("l") then 
                   yield word |]

    /// This is an array initialized by index and containing the even numbers from 0 to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2) 

    /// Sub-arrays are extracted using slicing notation.
    let evenNumbersSlice = evenNumbers[0..500]

    /// You can loop over arrays and lists using 'for' loops.
    for word in array4 do 
        printfn $"word: {word}"

    // You can modify the contents of an array element by using the left arrow assignment operator.
    //
    // To learn more about this operator, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/values/index#mutable-variables
    array2[1] <- "WORLD!"

    /// You can transform arrays using 'Array.map' and other functional programming operations.
    /// The following calculates the sum of the lengths of the words that start with 'h'.
    ///
    /// Note that in this case, similar to Lists, array2 is not mutated by Array.filter.
    let sumOfLengthsOfWords = 
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)

    printfn $"The sum of the lengths of the words in Array 2 is: %d{sumOfLengthsOfWords}"


/// Sequences are a logical series of elements, all of the same type.  These are a more general type than Lists and Arrays.
///
/// Sequences are evaluated on-demand and are re-evaluated each time they are iterated. 
/// An F# sequence is an alias for a .NET System.Collections.Generic.IEnumerable<'T>.
///
/// Sequence processing functions can be applied to Lists and Arrays as well.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/sequences
module Sequences = 

    /// This is the empty sequence.
    let seq1 = Seq.empty

    /// This a sequence of values.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }

    /// This is an on-demand sequence from 1 to 1000.
    let numbersSeq = seq { 1 .. 1000 }

    /// This is a sequence producing the words "hello" and "world"
    let seq3 = 
        seq { for word in seq2 do
                  if word.Contains("l") then 
                      yield word }

    /// This is a sequence producing the even numbers up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2) 

    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This example uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    /// This example shows the first 100 elements of the random walk.
    let first100ValuesOfRandomWalk = 
        randomWalk 5.0 
        |> Seq.truncate 100
        |> Seq.toList

    printfn $"First 100 elements of a random walk: {first100ValuesOfRandomWalk}"


/// Recursive functions can call themselves. In F#, functions are only recursive
/// when declared using 'let rec'.
///
/// Recursion is the preferred way to process sequences or collections in F#.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/functions/index#recursive-functions
module RecursiveFunctions = 
              
    /// This example shows a recursive function that computes the factorial of an 
    /// integer. It uses 'let rec' to define a recursive function.
    let rec factorial n = 
        if n = 0 then 1 else n * factorial (n-1)

    printfn $"Factorial of 6 is: %d{factorial 6}"

    /// Computes the greatest common factor of two integers.
    ///
    /// Since all of the recursive calls are tail calls,
    /// the compiler will turn the function into a loop,
    /// which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    printfn $"The Greatest Common Factor of 300 and 620 is %d{greatestCommonFactor 300 620}"

    /// This example computes the sum of a list of integers using recursion.
    ///
    /// '::' is used to split a list into the head and tail of the list,
    /// the head being the first element and the tail being the rest of the list.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    /// This makes 'sumList' tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys
    
    /// This invokes the tail recursive helper function, providing '0' as a seed accumulator.
    /// An approach like this is common in F#.
    let sumListTailRecursive xs = sumListTailRecHelper 0 xs

    let oneThroughTen = [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]

    printfn $"The sum 1-10 is %d{sumListTailRecursive oneThroughTen}"


/// Records are an aggregate of named values, with optional members (such as methods).
/// They are immutable and have structural equality semantics.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/records
module RecordTypes = 

    /// This example shows how to define a new record type.  
    type ContactCard = 
        { Name     : string
          Phone    : string
          Verified : bool }
              
    /// This example shows how to instantiate a record type.
    let contact1 = 
        { Name = "Alf" 
          Phone = "(206) 555-0157" 
          Verified = false }

    /// You can also do this on the same line with ';' separators.
    let contactOnSameLine = { Name = "Alf"; Phone = "(206) 555-0157"; Verified = false }

    /// This example shows how to use "copy-and-update" on record values. It creates 
    /// a new record value that is a copy of contact1, but has different values for 
    /// the 'Phone' and 'Verified' fields.
    ///
    /// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/copy-and-update-record-expressions
    let contact2 = 
        { contact1 with 
            Phone = "(206) 555-0112"
            Verified = true }

    /// This example shows how to write a function that processes a record value.
    /// It converts a 'ContactCard' object to a string.
    let showContactCard (c: ContactCard) = 
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")

    printfn $"Alf's Contact Card: {showContactCard contact1}"

    /// This is an example of a Record with a member.
    type ContactCardAlternate =
        { Name     : string
          Phone    : string
          Address  : string
          Verified : bool }

        /// Members can implement object-oriented members.
        member this.PrintedContactCard =
            this.Name + " Phone: " + this.Phone + (if not this.Verified then " (unverified)" else "") + this.Address

    let contactAlternate = 
        { Name = "Alf" 
          Phone = "(206) 555-0157" 
          Verified = false 
          Address = "111 Alf Street" }
   
    // Members are accessed via the '.' operator on an instantiated type.
    printfn $"Alf's alternate contact card is {contactAlternate.PrintedContactCard}"

    /// Records can also be represented as structs via the 'Struct' attribute.
    /// This is helpful in situations where the performance of structs outweighs
    /// the flexibility of reference types.
    [<Struct>]
    type ContactCardStruct = 
        { Name     : string
          Phone    : string
          Verified : bool }


/// Discriminated Unions (DU for short) are values which could be a number of named forms or cases.
/// Data stored in DUs can be one of several distinct values.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/discriminated-unions
module DiscriminatedUnions = 

    /// The following represents the suit of a playing card.
    type Suit = 
        | Hearts 
        | Clubs 
        | Diamonds 
        | Spades

    /// A Discriminated Union can also be used to represent the rank of a playing card.
    type Rank = 
        /// Represents the rank of cards 2 .. 10
        | Value of int
        | Ace
        | King
        | Queen
        | Jack

        /// Discriminated Unions can also implement object-oriented members.
        static member GetAllRanks() = 
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]
                                   
    /// This is a record type that combines a Suit and a Rank.
    /// It's common to use both Records and Discriminated Unions when representing data.
    type Card = { Suit: Suit; Rank: Rank }
              
    /// This computes a list representing all the cards in the deck.
    let fullDeck = 
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do 
                  yield { Suit=suit; Rank=rank } ]

    /// This example converts a 'Card' object to a string.
    let showPlayingCard (c: Card) = 
        let rankString = 
            match c.Rank with 
            | Ace -> "Ace"
            | King -> "King"
            | Queen -> "Queen"
            | Jack -> "Jack"
            | Value n -> string n
        let suitString = 
            match c.Suit with 
            | Clubs -> "clubs"
            | Diamonds -> "diamonds"
            | Spades -> "spades"
            | Hearts -> "hearts"
        rankString  + " of " + suitString

    /// This example prints all the cards in a playing deck.
    let printAllCards() = 
        for card in fullDeck do 
            printfn $"{showPlayingCard card}"

    // Single-case DUs are often used for domain modeling.  This can buy you extra type safety
    // over primitive types such as strings and ints.
    //
    // Single-case DUs cannot be implicitly converted to or from the type they wrap.
    // For example, a function which takes in an Address cannot accept a string as that input,
    // or vice versa.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // You can easily instantiate a single-case DU as follows.
    let address = Address "111 Alf Way"
    let name = Name "Alf"
    let ssn = SSN 1234567890

    /// When you need the value, you can unwrap the underlying value with a simple function.
    let unwrapAddress (Address a) = a
    let unwrapName (Name n) = n
    let unwrapSSN (SSN s) = s

    // Printing single-case DUs is simple with unwrapping functions.
    printfn $"Address: {address |> unwrapAddress}, Name: {name |> unwrapName}, and SSN: {ssn |> unwrapSSN}"

    /// Discriminated Unions also support recursive definitions.
    ///
    /// This represents a Binary Search Tree, with one case being the Empty tree,
    /// and the other being a Node with a value and two subtrees.
    ///
    /// Note 'T here is a type parameter, indicating that 'BST' is a generic type.
    /// More on generics later.
    type BST<'T> =
        | Empty
        | Node of value:'T * left: BST<'T> * right: BST<'T>

    /// Check if an item exists in the binary search tree.
    /// Searches recursively using Pattern Matching.  Returns true if it exists; otherwise, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Check the left subtree.
            else (exists item right) // Check the right subtree.

    /// Inserts an item in the Binary Search Tree.
    /// Finds the place to insert recursively using Pattern Matching, then inserts a new node.
    /// If the item is already present, it does not insert anything.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // No need to insert, it already exists; return the node.
            elif item < x then Node(x, insert item left, right) // Call into left subtree.
            else Node(x, left, insert item right) // Call into right subtree.

    /// Discriminated Unions can also be represented as structs via the 'Struct' attribute.
    /// This is helpful in situations where the performance of structs outweighs
    /// the flexibility of reference types.
    ///
    /// However, there are two important things to know when doing this:
    ///     1. A struct DU cannot be recursively-defined.
    ///     2. A struct DU must have unique names for each of its cases.
    [<Struct>]
    type Shape =
        | Circle of radius: float
        | Square of side: float
        | Triangle of height: float * width: float


/// Pattern Matching is a feature of F# that allows you to utilize Patterns,
/// which are a way to compare data with a logical structure or structures, 
/// decompose data into constituent parts, or extract information from data in various ways.
/// You can then dispatch on the "shape" of a pattern via Pattern Matching.
/// 
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/pattern-matching
module PatternMatching =

    /// A record for a person's first and last name
    type Person = {
        First : string
        Last  : string
    }

    /// A Discriminated Union of 3 different kinds of employees
    type Employee =
        | Engineer of engineer: Person
        | Manager of manager: Person * reports: List<Employee>
        | Executive of executive: Person * reports: List<Employee> * assistant: Employee

    /// Count everyone underneath the employee in the management hierarchy,
    /// including the employee. The matches bind names to the properties 
    /// of the cases so that those names can be used inside the match branches.
    /// Note that the names used for binding do not need to be the same as the 
    /// names given in the DU definition above.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(person) ->
                0
            | Manager(person, reports) ->
                reports |> List.sumBy countReports
            | Executive(person, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant

    /// Find all managers/executives named "Dave" who do not have any reports.
    /// This uses the 'function' shorthand to as a lambda expression.
    let findDaveWithOpenPosition(emps : List<Employee>) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] matches an empty list.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' is a wildcard pattern that matches anything.
                                     // This handles the "or else" case.

    /// You can also use the shorthand function construct for pattern matching, 
    /// which is useful when you're writing functions which make use of Partial Application.
    let private parseHelper (f: string -> bool * 'T) = f >> function
        | (true, item) -> Some item
        | (false, _) -> None

    let parseDateTimeOffset = parseHelper DateTimeOffset.TryParse

    let result = parseDateTimeOffset "1970-01-01"
    match result with
    | Some dto -> printfn "It parsed!"
    | None -> printfn "It didn't parse!"

    // Define some more functions which parse with the helper function.
    let parseInt = parseHelper Int32.TryParse
    let parseDouble = parseHelper Double.TryParse
    let parseTimeSpan = parseHelper TimeSpan.TryParse

    // Active Patterns are another powerful construct to use with pattern matching.
    // They allow you to partition input data into custom forms, decomposing them at the pattern match call site. 
    //
    // To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/active-patterns
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    /// Pattern Matching via 'function' keyword and Active Patterns often looks like this.
    let printParseResult = function
        | Int x -> printfn $"%d{x}"
        | Double x -> printfn $"%f{x}"
        | Date d -> printfn $"%O{d}"
        | TimeSpan t -> printfn $"%O{t}"
        | _ -> printfn "Nothing was parse-able!"

    // Call the printer with some different values to parse.
    printParseResult "12"
    printParseResult "12.045"
    printParseResult "12/28/2016"
    printParseResult "9:01PM"
    printParseResult "banana!"


/// Option values are any kind of value tagged with either 'Some' or 'None'.
/// They are used extensively in F# code to represent the cases where many other
/// languages would use null references.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/options
module OptionValues = 

    /// First, define a zip code defined via Single-case Discriminated Union.
    type ZipCode = ZipCode of string

    /// Next, define a type where the ZipCode is optional.
    type Customer = { ZipCode: ZipCode option }

    /// Next, define an interface type that represents an object to compute the shipping zone for the customer's zip code, 
    /// given implementations for the 'getState' and 'getShippingZone' abstract methods.
    type IShippingCalculator =
        abstract GetState : ZipCode -> string option
        abstract GetShippingZone : string -> int

    /// Next, calculate a shipping zone for a customer using a calculator instance.
    /// This uses combinators in the Option module to allow a functional pipeline for
    /// transforming data with Optionals.
    let CustomerShippingZone (calculator: IShippingCalculator, customer: Customer) =
        customer.ZipCode 
        |> Option.bind calculator.GetState 
        |> Option.map calculator.GetShippingZone


/// Units of measure are a way to annotate primitive numeric types in a type-safe way.
/// You can then perform type-safe arithmetic on these values.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/units-of-measure
module UnitsOfMeasure = 

    /// First, open a collection of common unit names
    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    /// Define a unitized constant
    let sampleValue1 = 1600.0<meter>          

    /// Next, define a new unit type
    [<Measure>]
    type mile =
        /// Conversion factor mile to meter.
        static member asMeter = 1609.34<meter/mile>

    /// Define a unitized constant
    let sampleValue2  = 500.0<mile>          

    /// Compute  metric-system constant
    let sampleValue3 = sampleValue2 * mile.asMeter   

    // Values using Units of Measure can be used just like the primitive numeric type for things like printing.
    printfn $"After a %f{sampleValue1} race I would walk %f{sampleValue2} miles which would be %f{sampleValue3} meters"


/// Classes are a way of defining new object types in F#, and support standard Object-oriented constructs.
/// They can have a variety of members (methods, properties, events, etc.)
///
/// To learn more about Classes, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/classes
///
/// To learn more about Members, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/members
module DefiningClasses = 

    /// A simple two-dimensional Vector class.
    ///
    /// The class's constructor is on the first line,
    /// and takes two arguments: dx and dy, both of type 'double'.
    type Vector2D(dx : double, dy : double) =

        /// This internal field stores the length of the vector, computed when the 
        /// object is constructed
        let length = sqrt (dx*dx + dy*dy)

        // 'this' specifies a name for the object's self-identifier.
        // In instance methods, it must appear before the member name.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        /// This member is a method.  The previous members were properties.
        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)
    
    /// This is how you instantiate the Vector2D class.
    let vector1 = Vector2D(3.0, 4.0)

    /// Get a new scaled vector object, without modifying the original object.
    let vector2 = vector1.Scale(10.0)

    printfn $"Length of vector1: %f{vector1.Length}\nLength of vector2: %f{vector2.Length}"


/// Generic classes allow types to be defined with respect to a set of type parameters.
/// In the following, 'T is the type parameter for the class.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/generics/
module DefiningGenericClasses = 

    type StateTracker<'T>(initialElement: 'T) = 

        /// This internal field store the states in a list.
        let mutable states = [ initialElement ]

        /// Add a new element to the list of states.
        member this.UpdateState newState = 
            states <- newState :: states  // use the '<-' operator to mutate the value.

        /// Get the entire list of historical states.
        member this.History = states

        /// Get the latest state.
        member this.Current = states.Head

    /// An 'int' instance of the state tracker class. Note that the type parameter is inferred.
    let tracker = StateTracker 10

    // Add a state
    tracker.UpdateState 17


/// Interfaces are object types with only 'abstract' members.
/// Object types and object expressions can implement interfaces.
///
/// To learn more, see: https://docs.microsoft.com/dotnet/fsharp/language-reference/interfaces
module ImplementingInterfaces =

    /// This is a type that implements IDisposable.
    type ReadFile() =

        let file = new System.IO.StreamReader("readme.txt")

        member this.ReadLine() = file.ReadLine()

        // This is the implementation of IDisposable members.
        interface System.IDisposable with
            member this.Dispose() = file.Close()


    /// This is an object that implements IDisposable via an Object Expression
    /// Unlike other languages such as C# or Java, a new type definition is not needed 
    /// to implement an interface.
    let interfaceImplementation =
        { new System.IDisposable with
            member this.Dispose() = printfn "disposed" }


/// The FSharp.Core library defines a range of parallel processing functions.  Here
/// you use some functions for parallel processing over arrays.
///
/// To learn more, see: https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-arraymodule-parallel.html
module ParallelArrayProgramming =
              
    /// First, an array of inputs.
    let oneBigArray = [| 0 .. 100000 |]
    
    // Next, define a functions that does some CPU intensive computation.
    let rec computeSomeFunction x = 
        if x <= 2 then 1 
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)
       
    // Next, do a parallel map over a large input array.
    let computeResults() = 
        oneBigArray 
        |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    // Next, print the results.
    printfn $"Parallel computation results: {computeResults}"