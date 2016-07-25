
    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)
    form.MouseMove
        |> Event.map (fun evArgs -> (evArgs.X, evArgs.Y))
        |> Event.add ( fun (x, y) ->
            form.BackColor <- System.Drawing.Color.FromArgb(
                x, y, x ^^^ y) )