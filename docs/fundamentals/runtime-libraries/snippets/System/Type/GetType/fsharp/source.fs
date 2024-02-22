module source

open System
open System.Reflection

do
    let test = "System.Collections.Generic.Dictionary`2[System.String,[MyNamespace.MyType, MyAssembly]]"
    //<Snippet1>
    let t =
        Type.GetType(test,
            (fun aName ->
                if aName.Name = "MyAssembly" then
                    Assembly.LoadFrom @".\MyPath\v5.0\MyAssembly.dll"
                else null),
            fun assem name ignr ->
                if assem = null then
                    Type.GetType(name, false, ignr)
                else
                    assem.GetType(name, false, ignr))
    //</Snippet1>
    printfn $"{t}"

    let test = "System.Collections.Generic.Dictionary`2[[YourNamespace.YourType, YourAssembly, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null], [MyNamespace.MyType, MyAssembly]]"
    //<Snippet2>
    let t2 =
        Type.GetType(test,
            (fun aName ->
                if aName.Name = "MyAssembly" then
                    Assembly.LoadFrom @".\MyPath\v5.0\MyAssembly.dll"
                else Assembly.Load aName),
            (fun assem name ignr ->
                if assem = null then
                    Type.GetType(name, false, ignr)
                else
                    assem.GetType(name, false, ignr)), true)
    //</Snippet2>
    printfn $"{t2}"
