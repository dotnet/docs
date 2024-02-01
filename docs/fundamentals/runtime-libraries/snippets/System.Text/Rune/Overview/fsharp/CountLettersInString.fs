open System
open System.Text

// <SnippetBadExample>
// THE FOLLOWING METHOD SHOWS INCORRECT CODE.
// DO NOT DO THIS IN A PRODUCTION APPLICATION.
let countLettersBadExample (s: string) =
    let mutable letterCount = 0

    for ch in s do
        if Char.IsLetter ch then
            letterCount <- letterCount + 1
    
    letterCount

// </SnippetBadExample>

// <SnippetGoodExample>
let countLetters (s: string) =
    let mutable letterCount = 0

    for rune in s.EnumerateRunes() do
        if Rune.IsLetter rune then
            letterCount <- letterCount + 1

    letterCount

// </SnippetGoodExample>