open System.Windows.Forms

let bufferData = Array.zeroCreate<byte> 100000000

let async1 (label:System.Windows.Forms.Label) filename =
     Async.StartWithContinuations(
         async {
            label.Text <- "Operation started."
            use outputFile = System.IO.File.Create(filename)
            do! outputFile.AsyncWrite(bufferData)
            },
         (fun _ -> label.Text <- "Operation completed."),
         (fun _ -> label.Text <- "Operation failed."),
         (fun _ -> label.Text <- "Operation canceled."))



let form = new Form(Text = "Test Form")
let button1 = new Button(Text = "Start")
let button2 = new Button(Text = "Start Invalid", Top = button1.Height + 10)
let button3 = new Button(Text = "Cancel", Top = 2 * button1.Height + 20)
let label1 = new Label(Text = "", Width = 200, Top = 3 * button1.Height + 30)
form.Controls.AddRange [| button1; button2; button3; label1 |]
button1.Click.Add(fun args -> async1 label1 "longoutput.dat")
// Try an invalid filename to test the error case.
button2.Click.Add(fun args -> async1 label1 "|invalid.dat")
button3.Click.Add(fun args -> Async.CancelDefaultToken())
Application.Run(form)