module fontlink1

// <Snippet2>
open System
open Microsoft.Win32

let valueName = "Lucida Console"
let newFont = "simsun.ttc,SimSun"

let key =
    Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\FontLink\SystemLink", true)
if isNull key then
    printfn "Font linking is not enabled."
else
    // Determine if the font is a base font.
    let names = key.GetValueNames()

    let (fonts, kind, toAdd) =
        if names |> Array.exists (fun s -> s.Equals(valueName, StringComparison.OrdinalIgnoreCase)) then
            // Get the value's type.
            let kind = key.GetValueKind(valueName)

            // Type should be RegistryValueKind.MultiString, but we can't be sure.
            let fonts =
                match kind with
                | RegistryValueKind.String -> [| key.GetValue(valueName) :?> string |]
                | RegistryValueKind.MultiString -> (key.GetValue(valueName) :?> string array)
                | _ -> [||]

            // Determine whether SimSun is a linked font.
            let toAdd =
                not (fonts |> Array.exists (fun s -> s.IndexOf("SimSun", StringComparison.OrdinalIgnoreCase) >= 0))

            (fonts, kind, toAdd)
        else
            // Font is not a base font.
            ([||], RegistryValueKind.Unknown, true)

    if toAdd then
        // Font is not a linked font.
        let newFonts = Array.append fonts [| newFont |]

        // Change REG_SZ to REG_MULTI_SZ.
        if kind = RegistryValueKind.String then key.DeleteValue(valueName, false)

        key.SetValue(valueName, newFonts, RegistryValueKind.MultiString)
        printfn "SimSun added to the list of linked fonts."
    else
        printfn "Font is already linked."


if not (isNull key) then key.Close()

// </Snippet2>
