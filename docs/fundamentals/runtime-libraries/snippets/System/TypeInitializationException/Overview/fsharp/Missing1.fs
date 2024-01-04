module Missing1

open Missing1a
// <Snippet2>
open System

type Person(fName, lName) =
    static let infoModule = InfoModule DateTime.UtcNow
    
    do infoModule.Increment() |> ignore
   
    override _.ToString() =
        $"{fName} {lName}"
let p = Person("John", "Doe")

printfn $"{p}"
// The example displays the following output if missing1a.dll is renamed or removed:
//    Unhandled Exception: System.TypeInitializationException: 
//       The type initializer for 'Person' threw an exception. ---> 
//       System.IO.FileNotFoundException: Could not load file or assembly 
//       'Missing1a, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' 
//       or one of its dependencies. The system cannot find the file specified.
//       at Person..cctor()
//       --- End of inner exception stack trace ---
//       at Person..ctor(String fName, String lName)
//       at Example.Main()
// </Snippet2>