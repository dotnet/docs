module pattern3
// <Snippet14>
open System
open System.Text

// Create a StringBuilder object with 4 successive occurrences
// of each character in the English alphabet.
let sb = StringBuilder()

for char in 'a' .. 'z' do
    sb.Append(char, 4) |> ignore

// Iterate the text to determine when a new character sequence occurs.
let mutable position = 0
let mutable current = '\u0000'

while position <= sb.Length - 1 do
    if sb[position] <> current then
        current <- sb[position]
        sb[position] <- Char.ToUpper sb[position]

        if position > 0 then
            sb.Insert(position, "_") |> ignore

        position <- position + 2

    else
        position <- position + 1

// Display the resulting string.
let sbString = string sb

for line = 0 to (sbString.Length - 1) / 80 do
    let nChars =
        if line * 80 + 79 <= sbString.Length then
            80
        else
            sbString.Length - line * 80

    printfn $"{sbString.Substring(line * 80, nChars)}"

// The example displays the following output:
//    Aaaa_Bbbb_Cccc_Dddd_Eeee_Ffff_Gggg_Hhhh_Iiii_Jjjj_Kkkk_Llll_Mmmm_Nnnn_Oooo_Pppp_
//    Qqqq_Rrrr_Ssss_Tttt_Uuuu_Vvvv_Wwww_Xxxx_Yyyy_Zzzz
// </Snippet14>
