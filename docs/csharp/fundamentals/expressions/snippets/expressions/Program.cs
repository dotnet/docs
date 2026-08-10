// <ParenthesesClarity>
int score = 80;
int bonus = 15;
int threshold = 90;
bool eligible = true;

// Without parentheses: || binds less tightly than &&, so this reads as:
//   eligible && (score + bonus > threshold) || bonus > 20
bool result1 = eligible && score + bonus > threshold || bonus > 20;

// With parentheses: forces the || to combine two complete conditions
bool result2 = (eligible && score + bonus > threshold) || bonus > 20;

Console.WriteLine(result1); // => True
Console.WriteLine(result2); // => True

// Parentheses can also change the result:
bool isAdmin = false;
bool isOwner = true;

// Without: && binds tighter, so: isAdmin && (isOwner || true)
bool access1 = isAdmin && isOwner || true;
// With: forces the || to run first
bool access2 = isAdmin && (isOwner || true);

Console.WriteLine(access1); // => True   (true || anything is true)
Console.WriteLine(access2); // => False  (false && anything is false)
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
