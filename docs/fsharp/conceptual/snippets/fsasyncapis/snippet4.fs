
open System.Windows.Forms

let bufferData = Array.zeroCreate<byte> 100000000

let asyncChild filename =
        async {
            printfn "Child job start: %s" filename
            use outputFile = System.IO.File.Create(filename)
            do! outputFile.AsyncWrite(bufferData)
            printfn "Child job end: %s " filename
        }

let asyncParent =
        async {
            printfn "Parent job start."
            let! childAsync1 = Async.StartChild(asyncChild "longoutput1.dat")
            let! childAsync2 = Async.StartChild(asyncChild "longoutput2.dat")
            let! result1 = childAsync1
            let! result2 = childAsync2
            printfn "Parent job end."
        }
      

let form = new Form(Text = "Test Form")
let button = new Button(Text = "Start")
form.Controls.Add(button)
button.Click.Add(fun args -> Async.Start(asyncParent)
                             printfn "Completed execution." )
Application.Run(form)