open System.Windows.Forms

let form = new Form(Text = "Test Form", Width = 400, Height = 400)
let syncContext = System.Threading.SynchronizationContext()
let button1 = new Button(Text = "Start")
let label1 = new Label(Text = "", Height = 200, Width = 200,
                       Top = button1.Height + 10)
form.Controls.AddRange([| button1; label1 |] )

let async1(syncContext, form : System.Windows.Forms.Form) =
    async {
        let label1 = form.Controls.[1]
        // Do something.
        do! Async.Sleep(10000)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text + sprintf "Something [%s] [%d]" threadName threadNumber

        // Switch to the UI thread and update the UI.
        do! Async.SwitchToContext(syncContext)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text + sprintf "Here [%s] [%d]" threadName threadNumber

        // Switch back to the thread pool.
        do! Async.SwitchToThreadPool()
        // Do something.
        do! Async.Sleep(10000)
        let threadName = System.Threading.Thread.CurrentThread.Name
        let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
        label1.Text <- label1.Text +
                       sprintf "Switched to thread pool [%s] [%d]" threadName threadNumber
    }

let buttonClick(sender:obj, args) =
    let button = sender :?> Button
    Async.Start(async1(syncContext, button.Parent :?> Form))
    let threadName = System.Threading.Thread.CurrentThread.Name
    let threadNumber = System.Threading.Thread.CurrentThread.ManagedThreadId
    button.Parent.Text <- sprintf "Started asynchronous workflow [%s] [%d]" threadName threadNumber
    ()

button1.Click.AddHandler(fun sender args -> buttonClick(sender, args))
Application.Run(form)