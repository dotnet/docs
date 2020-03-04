//<snippet1>
// This example demonstrates the Console.WindowLeft and
//                               Console.WindowTop properties.
open System
open System.Text
open System.IO

[<EntryPoint>]
let main argv =
    let m1 = 
        "1) Press the cursor keys to move the console window.\n" + 
        "2) Press any key to begin. When you're finished...\n" + 
        "3) Press the Escape key to quit."
    let g1 = "+----";
    let g2 = "|    ";
    let sbG1 = StringBuilder()
    let sbG2 = StringBuilder()


    let saveBufferWidth = Console.BufferWidth
    let saveBufferHeight = Console.BufferHeight
    let saveWindowHeight = Console.WindowHeight
    let saveWindowWidth = Console.WindowWidth
    let saveCursorVisible = Console.CursorVisible

    try
        try
            Console.Clear()
            Console.WriteLine(m1)
            Console.ReadKey(true) |> ignore

            // Set the smallest possible window size before setting the buffer size.
            Console.SetWindowSize(1, 1)
            Console.SetBufferSize(80, 80)
            Console.SetWindowSize(40, 20)

            // Create grid lines to fit the buffer. (The buffer width is 80, but
            // this same technique could be used with an arbitrary buffer width.)
            // for y = 0 to (Console.BufferWidth / g1.Length - 1)
            for _ in 1..(Console.BufferWidth / g1.Length) do
                (sbG1.Append(g1)) |> ignore
                (sbG2.Append(g2)) |> ignore

            sbG1.Append(g1, 0, Console.BufferWidth % g1.Length) |> ignore
            sbG2.Append(g2, 0, Console.BufferWidth % g2.Length) |> ignore
            let grid1 = sbG1.ToString()
            let grid2 = sbG2.ToString()

            Console.CursorVisible <- false
            Console.Clear()
            for y in 0..(Console.BufferHeight - 1) do
                if (y % 3 = 0) then
                    Console.Write(grid1)
                else
                    Console.Write(grid2)

            Console.SetWindowPosition(0, 0)

            let interactiveKeySequence = 
                Seq.initInfinite (fun _ -> (Console.ReadKey(true)).Key)
                |> Seq.takeWhile (fun key -> key <> ConsoleKey.Escape)

            for key in interactiveKeySequence do
                match key with
                | ConsoleKey.LeftArrow ->
                    if Console.WindowLeft > 0
                    then Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop)
                | ConsoleKey.UpArrow ->
                    if Console.WindowTop > 0
                    then Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop - 1)
                | ConsoleKey.RightArrow ->
                    if Console.WindowLeft < (Console.BufferWidth - Console.WindowWidth)
                    then Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop)
                | ConsoleKey.DownArrow ->
                    if Console.WindowTop < (Console.BufferHeight - Console.WindowHeight)
                    then Console.SetWindowPosition(Console.WindowLeft, Console.WindowTop + 1)
                | _ -> 
                    ()
            0
        with 
        | :? IOException as ex -> printf "%s" ex.Message; 1
    finally
        Console.Clear()
        Console.SetWindowSize(1, 1)
        Console.SetBufferSize(saveBufferWidth, saveBufferHeight)
        Console.SetWindowSize(saveWindowWidth, saveWindowHeight)
        Console.CursorVisible <- saveCursorVisible
//</snippet1>
