open System.IO

let openFile filename =
    try
        let file = File.Open(filename, FileMode.Create)
        Some(file)
    with ex ->
        eprintf "An exception occurred with message %s" ex.Message
        None
