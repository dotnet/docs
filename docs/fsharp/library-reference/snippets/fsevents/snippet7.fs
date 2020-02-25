
    open System.Windows.Forms
    open System.Drawing

    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)

    let (event1, event2) =
        form.MouseMove 
        |> Event.partition (fun evArgs -> evArgs.X > 100)

    event1 |> Event.add ( fun evArgs ->
        form.BackColor <- System.Drawing.Color.FromArgb(
            evArgs.X, evArgs.Y, evArgs.X ^^^ evArgs.Y))
    event2 |> Event.add ( fun evArgs ->
        form.BackColor <- System.Drawing.Color.FromArgb(
            evArgs.Y, evArgs.X, evArgs.Y ^^^ evArgs.X))