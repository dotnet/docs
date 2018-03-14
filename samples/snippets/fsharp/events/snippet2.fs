// When the mouse button is down, the form changes color
// as the mouse pointer is moved.

let form = new Form(Text = "F# Windows Form",
                    Visible = true,
                    TopMost = true)
form.MouseMove
    |> Event.choose(fun evArgs ->
        if (evArgs.Button <> MouseButtons.None) then
            Some( evArgs.X, evArgs.Y)
        else None)

    |> Event.add ( fun (x, y) ->
        form.BackColor <- System.Drawing.Color.FromArgb(
            x, y, x ^^^ y) )