// <ParenthesesClarity>
int a = 3;
int b = 4;
int c = 2;

// Without parentheses: relies on knowing that & binds tighter than |
bool result1 = a > 1 | b > 1 & c > 1;   // evaluated as: a > 1 | (b > 1 & c > 1)

// With parentheses: intent is explicit
bool result2 = (a > 1 | b > 1) & c > 1; // parentheses force | before &

Console.WriteLine(result1); // => True
Console.WriteLine(result2); // => True  (same result here, but intent is unambiguous)
// </ParenthesesClarity>

// <ShortCircuit>
string? text = null;

// Safe: second condition runs only when text is not null
bool hasContent = text != null && text.Length > 0;
Console.WriteLine(hasContent); // => False  (short-circuits after null check; no NullReferenceException)

text = "hello";
hasContent = text != null && text.Length > 0;
Console.WriteLine(hasContent); // => True

// || short-circuits on true: right side is never evaluated when left side is true
string word = "hello";
bool anyMatch = word.StartsWith("h") || word.StartsWith("x");
Console.WriteLine(anyMatch); // => True  (right side never evaluated)
// </ShortCircuit>
