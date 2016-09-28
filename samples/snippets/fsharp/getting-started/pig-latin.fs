namespace ClassLibraryDemo

module PigLatin =
    let toPigLatin (word: string) =
        let isVowel (c: char) =
            match c with
            | 'a' | 'e' | 'i' |'o' |'u'
            | 'A' | 'E' | 'I' | 'O' | 'U' -> true
            |_ -> false
        
        let chars = word.ToCharArray()
        
        if isVowel chars.[0] then
            word + "yay"
        else
            System.String.Concat(chars.[1..]) + string(chars.[0]) + "ay"