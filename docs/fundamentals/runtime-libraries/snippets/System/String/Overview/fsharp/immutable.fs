module immutable.fs
// <Snippet15>
open System
open System.IO
open System.Text

do
    let rnd = Random()

    let mutable str = String.Empty
    use sw = new StreamWriter(@".\StringFile.txt", false, Encoding.Unicode)
    for _ = 0 to 1000 do
        str <- str + (rnd.Next(1, 0x0530) |> char |> string)
        if str.Length % 60 = 0 then
            str <- str + Environment.NewLine
    sw.Write str
// </Snippet15>
