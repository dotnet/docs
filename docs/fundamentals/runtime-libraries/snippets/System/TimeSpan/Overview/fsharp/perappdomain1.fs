module perappdomain1

// <Snippet1>
open System

let appSetup = AppDomainSetup()
appSetup.SetCompatibilitySwitches [| "NetFx40_TimeSpanLegacyFormatMode" |]
let legacyDomain = AppDomain.CreateDomain("legacyDomain", null, appSetup)
legacyDomain.ExecuteAssembly "ShowTimeSpan.exe" |> ignore
// </Snippet1>