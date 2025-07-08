module Example8

// <Snippet8>
open System
open System.Reflection

[<assembly: AssemblyVersion("2.0.0.0")>]
do ()

AppContext.SetSwitch("StringLibrary.DoNotUseCultureSensitiveComparison",true)

module StringLibrary =
    let substringStartsAt (fullString: string) (substr: string) =
        match AppContext.TryGetSwitch "StringLibrary.DoNotUseCultureSensitiveComparison" with 
        | true, true -> fullString.IndexOf(substr, StringComparison.Ordinal)
        | _ -> fullString.IndexOf(substr, StringComparison.CurrentCulture)

// </Snippet8>