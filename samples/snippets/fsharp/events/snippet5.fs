
    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)
    form.MouseClick
        |> Event.merge(form.MouseDoubleClick)
        |> Event.add ( fun evArgs ->
            form.BackColor <- System.Drawing.Color.FromArgb(
                evArgs.X, evArgs.Y, evArgs.X ^^^ evArgs.Y) )