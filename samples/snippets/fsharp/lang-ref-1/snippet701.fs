open System

// Pass a null value to a .NET method.
let ParseDateTime (str: string) =
    let (success, res) =
        DateTime.TryParse(str, null, System.Globalization.DateTimeStyles.AssumeUniversal)

    if success then Some(res) else None
