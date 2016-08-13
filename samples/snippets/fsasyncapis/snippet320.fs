

    open System.Windows.Forms

    let bufferData = Array.zeroCreate<byte> 100000000

    let async1 (button : Button) =
         async {
           button.Text <- "Busy"
           button.Enabled <- false
           let context = System.Threading.SynchronizationContext.Current
           do! Async.SwitchToThreadPool()
           use outputFile = System.IO.File.Create("longoutput.dat")
           do! outputFile.AsyncWrite(bufferData)
           do! Async.SwitchToContext(context)
           button.Text <- "Start"
           button.Enabled <- true
         }


    let form = new Form(Text = "Test Form")
    let button = new Button(Text = "Start")
    form.Controls.Add(button)
    button.Click.Add(fun args -> Async.StartImmediate(async1 button))
    Application.Run(form)