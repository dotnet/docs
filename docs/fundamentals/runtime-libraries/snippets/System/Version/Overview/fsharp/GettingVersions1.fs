module GettingVersions1

open System

let getOsVersion () =
    // <Snippet1>
    // Get the operating system version.
    let os = Environment.OSVersion
    let ver = os.Version
    printfn $"Operating System: {os.VersionString} ({ver})"
    // </Snippet1>

let getClrVersion () =
    // <Snippet2>
    // Get the common language runtime version.
    let ver = Environment.Version
    printfn $"CLR Version {ver}"
    // </Snippet2>

getOsVersion ()
printfn ""      
getClrVersion ()