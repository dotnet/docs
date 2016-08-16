
    open System.Windows.Forms
    open System.Drawing
    open Microsoft.FSharp.Core

    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)

    let button = new Button(Text = "Button",
                            Visible = true,
                            Left = 100,
                            Width = 50,
                            Top = 100,
                            Height = 20)

    form.Controls.Add(button)
    let originalColor = button.BackColor
    let mutable xOff, yOff = (0, 0)

    let (|Down|Up|) (evArgs:MouseEventArgs) =
        match evArgs.Button with
        | MouseButtons.Left 
        | MouseButtons.Right 
        | MouseButtons.Middle -> Down(evArgs)
        | _ -> Up

    button.MouseDown 
    |> Event.add(fun evArgs ->
        xOff <- evArgs.X
        yOff <- evArgs.Y)

    form.MouseMove
    |> Event.map (fun evArgs -> (evArgs.X, evArgs.Y))
    |> Event.add (fun (x, y) -> form.Text <- sprintf "(%d, %d)" x y)

    let (dragButton, noDragButton) = Event.split (|Down|Up|) button.MouseMove

    // Move the button, and change its color if the user uses the
    // right or middle mouse button.
    dragButton |> Event.add ( fun evArgs ->
        match evArgs.Button with
        | MouseButtons.Left ->
            button.BackColor <- originalColor
        | MouseButtons.Right ->
            button.BackColor <- Color.Red
        | MouseButtons.Middle ->
            button.BackColor <- Color.Blue
        | _ -> ()
        button.Left <- button.Left + evArgs.X - xOff
        button.Top <- button.Top + evArgs.Y - yOff
        button.Refresh())

    // Restore the button's original color when the mouse is moved after
    // the release of the button.
    noDragButton |> Event.add ( fun () -> 
        button.BackColor <- originalColor)