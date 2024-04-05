module currentassem

// <Snippet4>
type Example = class end

// Get the version of the current assembly.
let assem = typeof<Example>.Assembly
let assemName = assem.GetName()
let ver = assemName.Version
printfn $"{assemName.Name}, Version {ver}"
// </Snippet4>