// <Snippet10>
module Example

open System.IO
open System.Runtime.Versioning

[<assembly: TargetFramework(".NETFramework,Version=v4.6.2")>]
do ()

Path.GetDirectoryName "file://c/temp/dirlist.txt"
|> printfn "%s"


// The example displays the following output:
//    Unhandled Exception: System.ArgumentException: The path is not of a legal form.
//       at System.IO.Path.NewNormalizePathLimitedChecks(String path, Int32 maxPathLength, Boolean expandShortPaths)
//       at System.IO.Path.NormalizePath(String path, Boolean fullCheck, Int32 maxPathLength, Boolean expandShortPaths)
//       at System.IO.Path.InternalGetDirectoryName(String path)
//       at <StartupCode$ForConsumers1>.$Example.main@()
// </Snippet10>
