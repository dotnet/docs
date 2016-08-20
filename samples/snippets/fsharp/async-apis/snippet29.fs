open System.Windows.Forms
open System.Drawing

let form = new Form(Text = "Test Form", Width = 400, Height = 400)
let syncContext = System.Threading.SynchronizationContext()

let pen = Pens.Black
let graphics = form.CreateGraphics()

let mutable x0 = 0
let mutable y0 = 0
let mutable isDrawing = false

form.MouseMove.AddHandler(fun _ mouseEventArgs ->
    if (isDrawing) then
        graphics.DrawLine(pen, x0, y0, mouseEventArgs.X, mouseEventArgs.Y)
    x0 <- mouseEventArgs.X
    y0 <- mouseEventArgs.Y)

form.MouseDown.AddHandler(fun _ _ -> isDrawing <- true)

form.MouseUp.AddHandler(fun _ _ -> isDrawing <- false)

Application.Run(form)