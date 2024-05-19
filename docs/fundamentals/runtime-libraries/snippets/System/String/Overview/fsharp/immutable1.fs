module immutable1.fs
// <Snippet16>
open System
open System.IO
open System.Text

do
    let rnd = Random()
    let sb = StringBuilder()
    use sw = new StreamWriter(@".\StringFile.txt", false, Encoding.Unicode)

    for _ = 0 to 1000 do
        sb.Append(rnd.Next(1, 0x0530) |> char) |> ignore
        if sb.Length % 60 = 0 then
            sb.AppendLine() |> ignore
    sw.Write(string sb)
// </Snippet16>
