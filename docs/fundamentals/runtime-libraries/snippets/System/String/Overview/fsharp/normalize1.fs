module normalize1.fs
// <Snippet14>
open System
open System.IO
open System.Text

do
    use sw = new StreamWriter(@".\TestNorm1.txt")

    let showBytes (str: string) =
        let mutable result = ""
        for ch in str do
            result <- result + $"{uint16 ch:X4} "
        result.Trim()
    
    let testForEquality (words: string[]) =
        for ctr = 0 to words.Length - 2 do
            for ctr2 = ctr + 1 to words.Length - 1 do
                sw.WriteLine("{0} ({1}) = {2} ({3}): {4}",
                            words[ctr], showBytes(words[ctr]),
                            words[ctr2], showBytes(words[ctr2]),
                            words[ctr].Equals(words[ctr2], StringComparison.Ordinal))

    let normalizeStrings nf (words: string[]) =
        for i = 0 to words.Length - 1 do
            if not (words[i].IsNormalized nf) then
                words[i] <- words[i].Normalize nf
        words

    // Define three versions of the same word.
    let s1 = "sống"        // create word with U+1ED1
    let s2 = "s\u00F4\u0301ng"
    let s3 = "so\u0302\u0301ng"

    testForEquality [| s1; s2; s3 |]
    sw.WriteLine()

    // Normalize and compare strings using each normalization form.
    for formName in Enum.GetNames typeof<NormalizationForm> do
        sw.WriteLine("Normalization {0}:\n", formName)
        let nf = Enum.Parse(typeof<NormalizationForm>, formName) :?> NormalizationForm
        let sn = normalizeStrings nf [| s1; s2; s3|]
        testForEquality sn
        sw.WriteLine "\n"

// The example displays the following output:
//       sống (0073 1ED1 006E 0067) = sống (0073 00F4 0301 006E 0067): False
//       sống (0073 1ED1 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
//       sống (0073 00F4 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): False
//
//       Normalization FormC:
//
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//
//
//       Normalization FormD:
//
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//
//
//       Normalization FormKC:
//
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//       sống (0073 1ED1 006E 0067) = sống (0073 1ED1 006E 0067): True
//
//
//       Normalization FormKD:
//
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
//       sống (0073 006F 0302 0301 006E 0067) = sống (0073 006F 0302 0301 006E 0067): True
// </Snippet14>
