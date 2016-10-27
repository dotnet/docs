// The following is a modified version of the F# Tutorial script that comes in F# templates for Visual Studio.


// ---------------------------------------------------------------
//         Integers and basic functions
// ---------------------------------------------------------------

module Integers =

    let sampleInteger = 176

    // Do some arithmetic starting with the first integer.
    let sampleInteger2 = (sampleInteger/4 + 5 - 7) * 4

    // A list of the numbers from 0 to 99.
    let sampleNumbers = [ 0 .. 99 ]

    // A list of all tuples containing all the numbers from 0 to 99 and their squares.
    let sampleTableOfSquares = [ for i in 0 .. 99 -> (i, i*i) ]

    // The next line prints a list that includes tuples, using %A for generic printing.
    printfn "The table of squares from 0 to 99 is:\n%A" sampleTableOfSquares


module BasicFunctions =

    // Use 'let' to define a function that accepts an integer argument
    // and returns an integer.
    let func1 x = x*x + 3

    // Parenthesis are optional for function arguments.
    let func1a (x) = x*x + 3

    // Apply the function, naming the function return result using 'let'.
    // The variable type is inferred from the function return type.
    let result1 = func1 4573
    printfn "The result of squaring the integer 4573 and adding 3 is %d" result1

    // When needed, annotate the type of a parameter name using '(argument:type)'.
    let func2 (x:int) = 2*x*x - x/5 + 3

    let result2 = func2 (7 + 4)
    printfn "The result of applying the 1st sample function to (7 + 4) is %d" result2

    // Use `if..else` expression to define the body of the function.
    let func3 x =
        if x < 100.0 then
            2.0*x*x - x/5.0 + 3.0
        else
            2.0*x*x + x/5.0 - 37.0

    let result3 = func3 (6.5 + 4.5)
    printfn "The result of applying the 2nd sample function to (6.5 + 4.5) is %f" result3



// ---------------------------------------------------------------
//         Booleans
// ---------------------------------------------------------------

module SomeBooleanValues =

    let boolean1 = true
    let boolean2 = false

    let boolean3 = not boolean1 && (boolean2 || false)

    printfn "The expression 'not boolean1 && (boolean2 || false)' is %A" boolean3



// ---------------------------------------------------------------
//         Strings
// ---------------------------------------------------------------

module StringManipulation =

    let string1 = "Hello"
    let string2  = "world"

    // Use @ to create a verbatim string literal.
    let string3 = @"c:\Program Files\"

    // Using a triple-quote string literal.
    let string4 = """He said "hello world" after you did"""

    // concatenate the two strings with a space in between.
    let helloWorld = string1 + " " + string2
    printfn "%s" helloWorld

    // A string formed by taking the first 7 characters of one of the result strings.
    let substring = helloWorld.[0..6]
    printfn "%s" substring



// ---------------------------------------------------------------
//         Tuples (ordered sets of values)
// ---------------------------------------------------------------

module Tuples =

    // A simple tuple of integers.
    let tuple1 = (1, 2, 3)

    // A function that swaps the order of two values in a tuple.
    // Type Inference will automatically generalize he function to have a generic type.
    let swapElems (a, b) = (b, a)

    printfn "The result of swapping (1, 2) is %A" (swapElems (1,2))

    // A tuple consisting of an integer, a string,
    // and a double-precision floating point number.
    let tuple2 = (1, "fred", 3.1415)

    printfn "tuple1: %A    tuple2: %A" tuple1 tuple2


// ---------------------------------------------------------------
//         Lists and list processing
// ---------------------------------------------------------------

module Lists =

    // An empty list.
    let list1 = [ ]

    // A list of 3 elements.
    let list2 = [ 1; 2; 3 ]

    // A new list with '42' added to the beginning.
    let list3 = 42 :: list2

    // A list of integers from 1 to 1000.
    let numberList = [ 1 .. 1000 ]

    // Generate a list containing all the days of the year,
    // using list comprehension syntax.
    let daysList =
        [ for month in 1 .. 12 do
              for day in 1 .. System.DateTime.DaysInMonth(2012, month) do
                  yield System.DateTime(2012, month, day) ]

    // A list containing the tuples which are
    // the coordinates of the black squares on a chess board.
    let blackSquares =
        [ for i in 0 .. 7 do
              for j in 0 .. 7 do
                  if (i+j) % 2 = 1 then
                      yield (i, j) ]

    // Square the numbers in numberList,
    // using the pipeline operator to pass an argument to List.map.
    let squares =
        numberList
        |> List.map (fun x -> x*x)

    // Computes the sum of the squares of the numbers divisible by 3.
    let sumOfSquares =
        numberList
        |> List.filter (fun x -> x % 3 = 0)
        |> List.sumBy (fun x -> x * x)



// ---------------------------------------------------------------
//         Classes
// ---------------------------------------------------------------

module DefiningClasses =

    // The class's constructor takes two arguments: dx and dy, both of type 'float'.
    type Vector2D(dx : float, dy : float) =
        // The length of the vector, computed when the object is constructed.
        // Note that this function is not accessible outside the Vector2d type.
        let length = sqrt (dx*dx + dy*dy)

        // 'this' specifies a name for the object's self identifier.
        // In instance methods, it must appear before the member name.
        member this.DX = dx

        member this.DY = dy

        member this.Length = length

        member this.Scale(k) = Vector2D(k * this.DX, k * this.DY)

    // An instance of the Vector2D class.
    let vector1 = Vector2D(3.0, 4.0)

    // Get a new scaled vector object, without modifying the original object.
    let vector2 = vector1.Scale(10.0)

    printfn "Length of vector1: %f\nLength of vector2: %f" vector1.Length vector2.Length



// ---------------------------------------------------------------
//         Generic classes
// ---------------------------------------------------------------

module DefiningGenericClasses =

    type StateTracker<'T>(initialElement: 'T) = // 'T is the type parameter for the class.

        // Store the states in a list.
        let mutable states = [ initialElement ]

        // Add a new element to the list of states.
        member this.UpdateState newState =
            states <- newState :: states  // Use the '<-' operator to mutate the value.

        // Get the entire list of historical states.
        member this.History = states

        // Get the latest state.
        member this.Current = states.Head

    // An 'int' instance of the state tracker class
    // Note that the type parameter is inferred.
    let tracker = StateTracker 10

    // Add a state.
    tracker.UpdateState 17



// ---------------------------------------------------------------
//         Implementing interfaces
// ---------------------------------------------------------------

// Type that implements IDisposable.
type ReadFile() =

    let file = new System.IO.StreamReader("readme.txt")

    member this.ReadLine() = file.ReadLine()

    // This class's implementation of IDisposable members.
    interface System.IDisposable with
        member this.Dispose() = file.Close()



// ---------------------------------------------------------------
//         Arrays
// ---------------------------------------------------------------

module Arrays =

    // An empty array.
    let array1 = [| |]

    // An array with 6 elements.
    let array2 = [| "hello"; "world"; "and"; "hello"; "world"; "again" |]

    // An array containing the values 1 through 100,
    // using generator syntax.
    let array3 = [| 1 .. 1000 |]

    // An array containing only the words "hello" and "world",
    // using array comprehension syntax.
    let array4 = [| for word in array2 do
                        if word.Contains("l") then
                            yield word |]

    // An array initialized by index and containing the even numbers from 0 to 2000.
    let evenNumbers = Array.init 1001 (fun n -> n * 2)

    // Sub-array extracted using slicing notation.
    let evenNumbersSlice = evenNumbers.[0..500]

    for word in array4 do
        printfn "word: %s" word

    // Modify an array element using the left arrow assignment operator.
    array2.[1] <- "WORLD!"

    // Calculates the sum of the lengths of the words that start with 'h'.
    let sumOfLengthsOfWords =
        array2
        |> Array.filter (fun x -> x.StartsWith "h")
        |> Array.sumBy (fun x -> x.Length)



// ---------------------------------------------------------------
//         Sequences
// ---------------------------------------------------------------

module Sequences =

    // Sequences are evaluated on-demand and are re-evaluated each time they are iterated.
    // An F# sequence is an instance of a System.Collections.Generic.IEnumerable<'T>,
    // so Seq functions can be applied to Lists and Arrays as well.

    // An empty sequence.
    let seq1 = Seq.empty

    // A sequence with 6 elements, generated using an seq expression.
    let seq2 =
        seq { yield "hello"; yield "world"; 
              yield "and"; yield "hello"; 
              yield "world"; yield "again" }

    // A sequence with values 1 through 100, using generator syntax in an seq expression.
    let numbersSeq = seq { 1 .. 1000 }

    // Another array containing only the words "hello" and "world".
    let seq3 =
        seq { for word in seq2 do
                  if word.Contains("l") then
                      yield word }

    let evenNumbers = Seq.init 1001 (fun n -> n * 2)

    let rnd = System.Random()

    // An infinite sequence which is a random walk.
    // Use yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    let first100ValuesOfRandomWalk =
        randomWalk 5.0
        |> Seq.truncate 100
        |> Seq.toList



// ---------------------------------------------------------------
//         Recursive functions
// ---------------------------------------------------------------

module RecursiveFunctions  =

    // Compute the factorial of an integer. Use 'let rec' to define a recursive function.
    let rec factorial n =
        if n = 0 then 1 else n * factorial (n-1)

    // Computes the greatest common factor of two integers.
    //
    // Since all of the recursive calls are tail calls,
    // the compiler will turn the function into a loop,
    // which improves performance and reduces memory consumption.
    let rec greatestCommonFactor a b =
        if a = 0 then b
        elif a < b then greatestCommonFactor a (b - a)
        else greatestCommonFactor (a - b) b

    // Computes the sum of a list of integers using recursion.
    let rec sumList xs =
        match xs with
        | []    -> 0
        | y::ys -> y + sumList ys

    // Make the function tail recursive, using a helper function with a result accumulator.
    let rec private sumListTailRecHelper accumulator xs =
        match xs with
        | []    -> accumulator
        | y::ys -> sumListTailRecHelper (accumulator+y) ys

    let sumListTailRecursive xs = sumListTailRecHelper 0 xs



// ---------------------------------------------------------------
//         Record types
// ---------------------------------------------------------------

module RecordTypes =

    // Define a record type.
    type ContactCard =
        { Name     : string;
          Phone    : string;
          Verified : bool }

    let contact1 = { Name = "Alf" ; Phone = "(206) 555-0157" ; Verified = false }

    // Create a new record that is a copy of contact1,
    // but has different values for the 'Phone' and 'Verified' fields.
    let contact2 = { contact1 with Phone = "(206) 555-0112"; Verified = true }

    // Converts a 'ContactCard' object to a string.
    let showCard c =
        c.Name + " Phone: " + c.Phone + (if not c.Verified then " (unverified)" else "")



// ---------------------------------------------------------------
//         Union types
// ---------------------------------------------------------------

module UnionTypes =

    // Represents the suit of a playing card.
    type Suit =
        | Hearts
        | Clubs
        | Diamonds
        | Spades

    // Represents the rank of a playing card.
    type Rank =
        // Represents the rank of cards 2 .. 10.
        | Value of int
        | Ace
        | King
        | Queen
        | Jack
        static member GetAllRanks() =
            [ yield Ace
              for i in 2 .. 10 do yield Value i
              yield Jack
              yield Queen
              yield King ]

    type Card =  { Suit: Suit; Rank: Rank }

    // Returns a list representing all the cards in the deck.
    let fullDeck =
        [ for suit in [ Hearts; Diamonds; Clubs; Spades] do
              for rank in Rank.GetAllRanks() do
                  yield { Suit=suit; Rank=rank } ]

    // Converts a 'Card' object to a string.
    let showCard c =
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

    let printAllCards() =
        for card in fullDeck do
            printfn "%s" (showCard card)

    // Use single-case Unions for domain modeling.
    type Address = Address of string
    type Name = Name of string
    type SSN = SSN of int

    // Represent a Binary Search Tree:
    //
    // First case is the empty tree (or subtree).
    //
    // Second case is is an AVL Node, containing data and the
    // left and right subtrees.
    type 'T BST =
        | Empty
        | Node of 'T * 'T BST * 'T BST // Data, left subtree, and right subtree

    /// Check if an item exists in the binary search tree.
    /// Searches recursively.  Returns true if it exists; otherwise, false.
    let rec exists item bst =
        match bst with
        | Empty -> false
        | Node (x, left, right) ->
            if item = x then true
            elif item < x then (exists item left) // Check the left subtree.
            else (exists item right) // Check the right subtree.

    /// Inserts an item in the Binary Search Tree.
    /// Finds the place to insert recursively, then inserts a new node.
    /// If the item is already present, it does not insert anything.
    let rec insert item bst =
        match bst with
        | Empty -> Node(item, Empty, Empty)
        | Node(x, left, right) as node ->
            if item = x then node // No need to insert, it already exists; return the node.
            elif item < x then Node(x, insert item left, right) // Call into left subtree.
            else Node(x, left, insert item right) // Call into right subtree.

// ---------------------------------------------------------------
//         Option types
// ---------------------------------------------------------------

module OptionTypes =
    // Option values are any kind of value tagged with either 'Some' or 'None'.
    // They are used extensively in F# code to represent the cases where many other
    // languages would use null references.

    type Customer = { ZipCode : decimal option }

    // Abstract class that computes the shipping zone for the customer's zip code,
    // given implementations for the 'getState' and 'getShippingZone' abstract methods.
    [<AbstractClass>]
    type ShippingCalculator =
        abstract GetState : decimal -> string option
        abstract GetShippingZone : string -> int

        // Return the shipping zone corresponding to the customer's ZIP code.
        // Customer may not yet have a ZIP code or the ZIP code may be invalid.
        member this.CustomerShippingZone(customer : Customer) =
            customer.ZipCode 
            |> Option.bind this.GetState 
            |> Option.map this.GetShippingZone


// ---------------------------------------------------------------
//         Pattern matching
// ---------------------------------------------------------------

module PatternMatching =

    // A record for a person's first and last name
    type Person = {
        First : string
        Last  : string
    }

    // Define a discriminated union of 3 different kinds of employees
    type Employee =
        | Engineer  of Person
        | Manager   of Person * list<Employee> // Manager has a list of reports.
        | Executive of Person * list<Employee> * Employee // Executive has an assistant.

    // Count everyone underneath the employee in the management hierarchy,
    // including the employee.
    let rec countReports(emp : Employee) =
        1 + match emp with
            | Engineer(id) ->
                0
            | Manager(id, reports) ->
                reports |> List.sumBy countReports
            | Executive(id, reports, assistant) ->
                (reports |> List.sumBy countReports) + countReports assistant


    // Find all managers/executives named "Dave" who do not have any reports.
    // This uses the 'function' shorthand as a lambda expression.
    let rec findDaveWithOpenPosition(emps : Employee list) =
        emps
        |> List.filter(function
                       | Manager({First = "Dave"}, []) -> true // [] matches an empty list.
                       | Executive({First = "Dave"}, [], _) -> true
                       | _ -> false) // '_' is a wildcard pattern that matches anything
                                     // this handles the "or else" case.

    open System

    // Use the shorthand and partial application.
    let private parseHelper f = f >> function
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

    // Define some active patterns which partition input Data
    // based on the parse functions.
    let (|Int|_|) = parseInt
    let (|Double|_|) = parseDouble
    let (|Date|_|) = parseDateTimeOffset
    let (|TimeSpan|_|) = parseTimeSpan

    let parse = function
        | Int x -> printfn "%d" x
        | Double x -> printfn "%f" x
        | Date d -> printfn "%s" (d.ToString())
        | TimeSpan t -> printfn "%s" (t.ToString())
        | _ -> printfn "Nothing was parse-able!"

// ---------------------------------------------------------------
//         Units of measure
// ---------------------------------------------------------------

module UnitsOfMeasure =

    // Code can be annotated with units of measure
    // when using F# arithmetic over numeric types.

    open Microsoft.FSharp.Data.UnitSystems.SI.UnitNames

    [<Measure>]
    type mile =
        // Conversion factor mile to meter: meter is defined in SI.UnitNames.
        static member asMeter = 1609.<meter/mile>

    let d  = 50.<mile>          // Distance expressed using imperial units
    let d2 = d * mile.asMeter   // Same distance expressed using metric system

    printfn "%A = %A" d d2
    // let error = d + d2       // Compile error: units of measure do not match



// ---------------------------------------------------------------
//         Parallel array programming
// ---------------------------------------------------------------

module ParallelArrayProgramming =

    let oneBigArray = [| 0 .. 100000 |]

    // Do some CPU intensive computation.
    let rec computeSomeFunction x =
        if x <= 2 then 1
        else computeSomeFunction (x - 1) + computeSomeFunction (x - 2)

    // Do a parallel map over a large input array
    let computeResults() = oneBigArray |> Array.Parallel.map (fun x -> computeSomeFunction (x % 20))

    printfn "Parallel computation results: %A" (computeResults())



// ---------------------------------------------------------------
//         Using events
// ---------------------------------------------------------------

module Events =

    open System

    // create instance of Event object that consists of subscription point (event.Publish) and event trigger (event.Trigger)
    let simpleEvent = new Event<int>()

    // add handler
    simpleEvent.Publish.Add(
        fun x -> printfn "this is handler was added with Publish.Add: %d" x)

    // trigger event
    simpleEvent.Trigger(5)

    // create instance of Event that follows standard .NET convention: (sender, EventArgs)
    let eventForDelegateType = new Event<EventHandler, EventArgs>()

    // add handler
    eventForDelegateType.Publish.AddHandler(
        EventHandler(fun _ _ -> printfn "this is handler was added with Publish.AddHandler"))

    // trigger event (note that sender argument should be set)
    eventForDelegateType.Trigger(null, EventArgs.Empty)