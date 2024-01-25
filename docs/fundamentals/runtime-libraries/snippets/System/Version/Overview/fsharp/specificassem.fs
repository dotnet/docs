module specificassem

// <Snippet3>
open System.Reflection

// Get the version of a specific assembly.
let filename = @".\StringLibrary.dll"
let assem = Assembly.ReflectionOnlyLoadFrom filename
let assemName = assem.GetName()
let ver = assemName.Version
printfn $"{assemName.Name}, Version {ver}"
// </Snippet3>