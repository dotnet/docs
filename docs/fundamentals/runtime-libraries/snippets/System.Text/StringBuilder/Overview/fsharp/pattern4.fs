module pattern4
// <Snippet15>
open System.Text
open System.Text.RegularExpressions

// Create a StringBuilder object with 4 successive occurrences
// of each character in the English alphabet.
let sb = StringBuilder()

for char in 'a' .. 'z' do
    sb.Append(char, 4) |> ignore

// Convert it to a string.
let sbString = string sb

// Use a regex to uppercase the first occurrence of the sequence,
// and separate it from the previous sequence by an underscore.
let pattern = @"(\w)(\1+)"

let sbStringReplaced =
    Regex.Replace(
        sbString,
        pattern,
        fun m ->
            (if m.Index > 0 then "_" else "")
            + m.Groups[ 1 ].Value.ToUpper()
            + m.Groups[2].Value
    )

// Display the resulting string.
for line = 0 to (sbStringReplaced.Length - 1) / 80 do
    let nChars =
        if line * 80 + 79 <= sbStringReplaced.Length then
            80
        else
            sbStringReplaced.Length - line * 80

    printfn $"{sbStringReplaced.Substring(line * 80, nChars)}"

// The example displays the following output:
//    Aaaa_Bbbb_Cccc_Dddd_Eeee_Ffff_Gggg_Hhhh_Iiii_Jjjj_Kkkk_Llll_Mmmm_Nnnn_Oooo_Pppp_
//    Qqqq_Rrrr_Ssss_Tttt_Uuuu_Vvvv_Wwww_Xxxx_Yyyy_Zzzz
// </Snippet15>
