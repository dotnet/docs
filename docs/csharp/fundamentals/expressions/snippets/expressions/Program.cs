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

// <StepByStep>
int a = 6;
int b = 2;
int c = 3;

// Step 1: / has higher precedence than +, so evaluate a / b first → 3
// Step 2: add the result to c → 3 + 3 = 6
int result = a / b + c;   // (6 / 2) + 3 = 6
Console.WriteLine(result); // => 6
// </StepByStep>

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

// ?. short-circuits on null: returns null without accessing .Length
string? maybeNull = null;
int? length = maybeNull?.Length;   // length is null; no NullReferenceException
Console.WriteLine(length.HasValue); // => False
// </ShortCircuit>
