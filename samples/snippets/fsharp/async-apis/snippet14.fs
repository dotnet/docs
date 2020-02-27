open System.Windows.Forms
open System.IO

let filename = "longoutput.dat"

if File.Exists(filename) then File.Delete(filename)
let watcher = new FileSystemWatcher(Directory.GetCurrentDirectory(), filename, NotifyFilter = NotifyFilters.LastWrite)
watcher.Changed.Add <| fun args -> printfn "The file %s is changed." args.Name
watcher.EnableRaisingEvents <- true

let form = new Form(Text = "Test Form")
let buttonSpacing = 5
let button1 = new Button(Text = "Start")
let button2 = new Button(Text = "Start Invalid", Top = button1.Height + buttonSpacing)
let label1 = new Label(Text = "", Width = 200, Top = 3 * (button1.Height + buttonSpacing))
let label2 = new Label(Text = "", Width = 200, Top = 4 * (button1.Height + buttonSpacing))

form.Controls.AddRange [| button1; button2; label1 |]

let bufferData = Array.zeroCreate<byte> 100000000

let async1 filename =
    async {
        printfn "Creating file %s." filename
        use outputFile = File.Create(filename)
        printfn "Attempting to write to file %s." filename
        do! outputFile.AsyncWrite(bufferData)
    }

let async2 filename =
    async {
        printfn "Waiting for file system watcher notification."
        // If you omit the call to AwaitEvent, an exception is thrown that indicates that the
        // file is locked.
        let! _args = Async.AwaitEvent(watcher.Changed)
        printfn "Attempting to open and read file %s." filename
        use inputFile = File.OpenRead(filename)
        let! buffer = inputFile.AsyncRead(100000000)
        printfn "Successfully read file %s." filename
        return buffer
    }

button1.Click.Add <| fun _ ->
    // Start these as tasks simultaneously.
    async1 filename |> Async.StartAsTask |> ignore
    async2 filename |> Async.StartAsTask |> ignore

button2.Click.Add <| fun _ ->
    async1 filename |> Async.StartAsTask |> ignore
    async2 "longoutputX.dat" |> Async.StartAsTask |> ignore

Application.Run(form)