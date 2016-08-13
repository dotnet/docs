
    // This code implements a simple click counter. Every time
    // the user clicks the form, the state increments by 1
    // and the form's text is changed to display the new state.

    open System.Windows.Forms
    open System.Drawing
    open Microsoft.FSharp.Core

    let form = new Form(Text = "F# Windows Form",
                        Visible = true,
                        TopMost = true)

    let initialState = 0
               
    form.Click
    |> Event.scan (fun state _ -> state + 1) initialState
    |> Event.add (fun state -> form.Text <- state.ToString() )