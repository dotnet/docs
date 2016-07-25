
// This object expression specifies a System.Object but overrides the
// ToString method.
let obj1 = { new System.Object() with member x.ToString() = "F#" }
printfn "%A" obj1 

// This object expression implements the IFormattable interface.
let Delimiter(delim1 : string, delim2 : string ) = { new System.IFormattable with
                member x.ToString(format : string, provider : System.IFormatProvider) =
                  if format = "D" then delim1 + x.ToString() + delim2
                  else x.ToString()
           }
           
let obj2 = Delimiter("{","}");

printfn "%A" (System.String.Format("{0:D}", obj2))

// This object expression implements multiple interfaces.
type IFirst =
  abstract F : unit -> unit
  abstract G : unit -> unit
  
type ISecond =
  inherit IFirst
  abstract H : unit -> unit
  abstract J : unit -> unit

// This object expression implements an interface chain.
let Implementer() = { new ISecond with
                         member this.H() = ()
                         member this.J() = ()
                       interface IFirst with
                         member this.F() = ()
                         member this.G() = ()
                    }