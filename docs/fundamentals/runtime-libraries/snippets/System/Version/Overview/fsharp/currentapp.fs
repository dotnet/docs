module currentapp

// <Snippet5>
open System.Reflection

// Get the version of the executing assembly (that is, this assembly).
let assem = Assembly.GetEntryAssembly()
let assemName = assem.GetName()
let ver = assemName.Version
printfn $"Application {assemName.Name}, Version {ver}"
// </Snippet5>