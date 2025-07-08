namespace snippet1
open System
open System.Globalization

//<snippet1>
// The Temperature class stores the temperature as a Double
// and delegates most of the functionality to the Double
// implementation.
type Temperature() =
    member val Value = 0. with get, set

    member this.Celsius
        with get () = (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.

    // Parses the temperature from a string in the form
    // [ws][sign]digits['F|'C][ws]
    static member Parse(s: string, styles: NumberStyles, provider: IFormatProvider) =
        let temp = Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles, provider)
        elif s.TrimEnd(null).EndsWith "'C" then
            temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles, provider)
        else
            temp.Value <- Double.Parse(s, styles, provider)
        temp

    interface IComparable with
        // IComparable.CompareTo implementation.
        member this.CompareTo(obj: obj) =
            match obj with 
            | null -> 1
            | :? Temperature as temp ->
                this.Value.CompareTo temp.Value
            | _ ->
                invalidArg "obj" "object is not a Temperature"

    interface IFormattable with
        // IFormattable.ToString implementation.
        member this.ToString(format: string, provider: IFormatProvider) =
            match format with
            | "F" ->
                $"{this.Value}'F"
            | "C" ->
                $"{this.Celsius}'C"
            | _ ->
                this.Value.ToString(format, provider)
//</snippet1>

namespace snippet2
open System

//<snippet2>
type Temperature() =
    static member MinValue =
        Double.MinValue

    static member MaxValue =
        Double.MaxValue

    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
//</snippet2>

namespace snippet3
open System

//<snippet3>
type Temperature() =
    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
    
    // IComparable.CompareTo implementation.
    interface IComparable with
        member this.CompareTo(obj: obj) =
            match obj with
            | null -> 1
            | :? Temperature as temp ->
                this.Value.CompareTo temp.Value
            | _ ->
                invalidArg "obj" "object is not a Temperature"
//</snippet3>

namespace snippet4
open System

//<snippet4>
type Temperature() =
    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.

    // IFormattable.ToString implementation.
    interface IFormattable with
        // IFormattable.ToString implementation.
        member this.ToString(format: string, provider: IFormatProvider) =
            match format with
            | "F" ->
                $"{this.Value}'F"
            | "C" ->
                $"{this.Celsius}'C"
            | _ ->
                this.Value.ToString(format, provider)
//</snippet4>
    
namespace snippet5
open System
    
//<snippet5>
type Temperature() =
    // Parses the temperature from a string in form
    // [ws][sign]digits['F|'C][ws]
    static member Parse(s: string) =
        let temp = Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2) )
        elif s.TrimEnd(null).EndsWith "'C" then
            temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2) )
        else
            temp.Value <- Double.Parse s
        temp

    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
//</snippet5>

namespace snippet6
open System

//<snippet6>
type Temperature() =
    // Parses the temperature from a string in form
    // [ws][sign]digits['F|'C][ws]
    static member Parse(s: string, provider: IFormatProvider) =
        let temp = new Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), provider)
        elif s.TrimEnd(null).EndsWith "'C" then
            temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), provider)
        else
            temp.Value <- Double.Parse(s, provider)
        temp

    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
//</snippet6>

namespace snippet7
open System
open System.Globalization

//<snippet7>
type Temperature() =
    // Parses the temperature from a string in form
    // [ws][sign]digits['F|'C][ws]
    static member Parse(s: string, styles: NumberStyles) =
        let temp = Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles)
        elif s.TrimEnd(null).EndsWith "'C" then
            temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles)
        else
            temp.Value <- Double.Parse(s, styles)
        temp

    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
//</snippet7>

namespace snippet8  
open System
open System.Globalization

//<snippet8>
type Temperature() =
    // Parses the temperature from a string in form
    // [ws][sign]digits['F|'C][ws]
    static member Parse(s: string, styles: NumberStyles, provider: IFormatProvider) =
        let temp = Temperature()

        if s.TrimEnd(null).EndsWith "'F" then
            temp.Value <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles, provider)
        elif s.TrimEnd(null).EndsWith "'C" then
            temp.Celsius <- Double.Parse(s.Remove(s.LastIndexOf '\'', 2), styles, provider)
        else
            temp.Value <- Double.Parse(s, styles, provider)
        temp

    member val Value = 0. with get, set

    member this.Celsius
        with get () =
            (this.Value - 32.) / 1.8
        and set (value) =
            this.Value <- 1.8 * value + 32.
//</snippet8>