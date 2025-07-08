module pattern2
// <Snippet13>
open System
open System.Text
open System.Text.RegularExpressions

// Create a StringBuilder object with 4 successive occurrences
// of each character in the English alphabet.
let sb = StringBuilder()

for char in 'a' .. 'z' do
    sb.Append(char, 4) |> ignore

// Create a parallel string object.
let sbString = string sb
// Determine where each new character sequence begins.
let pattern = @"(\w)\1+"
let matches = Regex.Matches(sbString, pattern)

// Uppercase the first occurrence of the sequence, and separate it
// from the previous sequence by an underscore character.
for i = matches.Count - 1 downto 0 do
    let m = matches[i]
    sb[m.Index] <- Char.ToUpper sb[m.Index]

    if m.Index > 0 then
        sb.Insert(m.Index, "_") |> ignore

// Display the resulting string.
let sbString2 = string sb

for line = 0 to (sbString2.Length - 1) / 80 do
    let nChars =
        if line * 80 + 79 <= sbString2.Length then
            80
        else
            sbString2.Length - line * 80

    printfn $"{sbString2.Substring(line * 80, nChars)}"


// The example displays the following output:
//    Aaaa_Bbbb_Cccc_Dddd_Eeee_Ffff_Gggg_Hhhh_Iiii_Jjjj_Kkkk_Llll_Mmmm_Nnnn_Oooo_Pppp_
//    Qqqq_Rrrr_Ssss_Tttt_Uuuu_Vvvv_Wwww_Xxxx_Yyyy_Zzzz
// </Snippet13>
