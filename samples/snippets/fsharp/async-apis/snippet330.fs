open System.Windows.Forms

let bufferData = Array.zeroCreate<byte> 100000000

let async1 =
     async {
       use outputFile = System.IO.File.Create("longoutput.dat")
       do! outputFile.AsyncWrite(bufferData)
     }


let form = new Form(Text = "Test Form")
let button = new Button(Text = "Start")
form.Controls.Add(button)
button.Click.Add(fun args -> let task = Async.StartAsTask(async1)
                             printfn "Do some other work..."
                             task.Wait()
                             printfn "done")
Application.Run(form)