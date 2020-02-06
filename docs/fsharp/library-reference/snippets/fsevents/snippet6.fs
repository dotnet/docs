
    open System.Windows.Forms
    open System.Drawing

    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)

    let graphics = BufferedGraphicsManager.Current.Allocate(form.CreateGraphics(), 
                                    new Rectangle( 0, 0, form.Width, form.Height ))
    let whitePen = new Pen(Color.White)

    form.MouseClick
        |> Event.pairwise
        |> Event.add ( fun (evArgs1, evArgs2) ->
            graphics.Graphics.DrawLine(whitePen, evArgs1.X, evArgs1.Y, evArgs2.X, evArgs2.Y)
            form.Refresh())

    form.Paint
        |> Event.add(fun evArgs -> graphics.Render(evArgs.Graphics))