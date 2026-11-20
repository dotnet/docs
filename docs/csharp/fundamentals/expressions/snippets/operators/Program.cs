// <ArithmeticOps>
int apples = 10;
int oranges = 3;

Console.WriteLine(apples + oranges);  // => 13  (addition)
Console.WriteLine(apples - oranges);  // => 7   (subtraction)
Console.WriteLine(apples * oranges);  // => 30  (multiplication)
Console.WriteLine(apples / oranges);  // => 3   (integer division: truncates toward zero)
Console.WriteLine(apples % oranges);  // => 1   (remainder)

// Integer division always truncates toward zero — the fractional part is discarded
int result = 7 / 2;
Console.WriteLine(result); // => 3, not 3.5

// Truncation applies to negative results too: -7 / 2 is -3, not -4
int negResult = -7 / 2;
Console.WriteLine(negResult); // => -3

// To get a decimal result, at least one operand must be a double or float
double precise = 7.0 / 2;
Console.WriteLine(precise); // => 3.5

// Remainder with negative operands: the sign of the result matches the dividend
Console.WriteLine(-7 % 3);  // => -1  (-7 = 3 × -2 + (-1))
Console.WriteLine(7 % -3);  // => 1   ( 7 = -3 × -2 + 1)
// </ArithmeticOps>

// <UnaryOps>
int temperature = 20;
int windChill = -5;

int heatIndex = +temperature;   // unary +: value unchanged (rarely needed)
int coldFactor = -windChill;    // unary -: negates the value → 5

Console.WriteLine(heatIndex);   // => 20
Console.WriteLine(coldFactor);  // => 5

bool isRaining = false;
bool isSunny = !isRaining;     // logical NOT: flips true/false
Console.WriteLine(isSunny);    // => True
// </UnaryOps>

// <IncrementDecrement>
int counter = 5;

// Prefix: increment first, then use the new value
int a = ++counter;
Console.WriteLine(a);       // => 6
Console.WriteLine(counter); // => 6

// Postfix: use the current value first, then increment
int b = counter++;
Console.WriteLine(b);       // => 6  (value before increment)
Console.WriteLine(counter); // => 7  (incremented after)

// Decrement works the same way
int score = 10;
Console.WriteLine(score--); // => 10 (current value; score becomes 9)
Console.WriteLine(score);   // => 9
// </IncrementDecrement>

// <RelationalOps>
int speed = 75;
int limit = 60;

Console.WriteLine(speed > limit);   // => True   (greater than)
Console.WriteLine(speed < limit);   // => False  (less than)
Console.WriteLine(speed >= limit);  // => True   (greater than or equal)
Console.WriteLine(speed <= limit);  // => False  (less than or equal)

// Relational operators work on all numeric types and char
// char comparison uses the character's numeric Unicode code point, not alphabetical position
// 'B' (U+0042, value 66) is less than 'A' (U+0041, value 65)? No — 'A' (65) < 'B' (66)
char grade = 'B';
Console.WriteLine(grade >= 'A' && grade <= 'C'); // => True  ('A'=65 <= 'B'=66 <= 'C'=67)
// </RelationalOps>

// <EqualityOps>
int expected = 42;
int actual = 42;

Console.WriteLine(actual == expected);  // => True   (values are equal)
Console.WriteLine(actual != expected);  // => False  (true when values are not equal)

string name = "Alice";
Console.WriteLine(name == "Alice");  // => True   (string content matches)
Console.WriteLine(name == "alice");  // => False  (case-sensitive)

int x = 5;
Console.WriteLine(x == 10);  // => False
// </EqualityOps>

// <LogicalOps>
int age = 20;
bool hasTicket = true;

// && (AND): both sides must be true
bool canEnter = age >= 18 && hasTicket;
Console.WriteLine(canEnter); // => True

// || (OR): at least one side must be true
bool freeEntry = age < 5 || age >= 65;
Console.WriteLine(freeEntry); // => False

// Short-circuit: right side is skipped when the result is already determined
// Here, items.Count is never called if items is null
List<string>? items = null;
bool hasItems = items != null && items.Count > 0;
Console.WriteLine(hasItems); // => False  (short-circuits; no NullReferenceException)
// </LogicalOps>

// <ConditionalOp>
int temperature2 = 35;

// condition ? value-when-true : value-when-false
string weather = temperature2 > 30 ? "hot" : "comfortable";
Console.WriteLine(weather); // => hot

// Only the matching branch evaluates — the other branch is never run
int divisor = 0;
// The division 10 / divisor is never evaluated because divisor == 0 is true
int safe = divisor == 0 ? -1 : 10 / divisor;
Console.WriteLine(safe); // => -1
// </ConditionalOp>

// <AssignmentOps>
int level = 1;
level = 5;          // simple assignment: replaces the value
Console.WriteLine(level); // => 5

// Compound assignment: short form of binary operation + assignment
int hp = 100;
hp += 20;   // same as: hp = hp + 20
Console.WriteLine(hp); // => 120
hp -= 10;   // same as: hp = hp - 10
Console.WriteLine(hp); // => 110
hp *= 2;    // same as: hp = hp * 2
Console.WriteLine(hp); // => 220
hp /= 3;    // same as: hp = hp / 3 (integer division)
Console.WriteLine(hp); // => 73
hp %= 7;    // same as: hp = hp % 7
Console.WriteLine(hp); // => 3
// </AssignmentOps>

// <AssignmentChain>
// Assignment is right-associative: evaluated right to left
int a2, b2, c2;
a2 = b2 = c2 = 0;     // c2 = 0 first, then b2 = 0, then a2 = 0
Console.WriteLine($"{a2} {b2} {c2}"); // => 0 0 0

// Compound assignment evaluates the left side once and converts back to the LHS type
byte small = 200;
small += 10;  // equivalent to: small = (byte)(small + 10); result is 210
Console.WriteLine(small); // => 210
// </AssignmentChain>
