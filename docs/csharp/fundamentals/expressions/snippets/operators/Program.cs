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

// To get a decimal result, at least one operand must be a double or float
double precise = 7.0 / 2;
Console.WriteLine(precise); // => 3.5
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
char grade = 'B';
Console.WriteLine(grade >= 'A' && grade <= 'C'); // => True
// </RelationalOps>

// <EqualityOps>
int expected = 42;
int actual = 42;

Console.WriteLine(actual == expected);  // => True   (values match)
Console.WriteLine(actual != expected);  // => False  (values differ)

string name = "Alice";
Console.WriteLine(name == "Alice");  // => True   (string content matches)
Console.WriteLine(name == "alice");  // => False  (case-sensitive)

// A common mistake: assignment (=) instead of equality (==)
// The following line assigns 10 to x, not a comparison:
//   bool wrong = (x = 10);  // compiler error: can't convert int to bool directly
// Use == to compare
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

// Nested ?: is possible but use sparingly — an if/else is often clearer
int points = 85;
string grade2 = points >= 90 ? "A" : points >= 70 ? "B" : "C";
Console.WriteLine(grade2); // => B
// </ConditionalOp>

// <AssignmentOps>
int level = 1;
level = 5;          // simple assignment: replaces the value
Console.WriteLine(level); // => 5

// Compound assignment: short form of binary operation + assignment
int hp = 100;
hp += 20;   // same as: hp = hp + 20
hp -= 10;   // same as: hp = hp - 10
hp *= 2;    // same as: hp = hp * 2
hp /= 3;    // same as: hp = hp / 3 (integer division)
hp %= 7;    // same as: hp = hp % 7

// Trace: 100 +20→ 120 -10→ 110 *2→ 220 /3→ 73 (integer division) %7→ 3
Console.WriteLine(hp); // => 3
// </AssignmentOps>

// <AssignmentChain>
// Assignment is right-associative: evaluated right to left
int a2, b2, c2;
a2 = b2 = c2 = 0;     // c2 = 0 first, then b2 = 0, then a2 = 0
Console.WriteLine($"{a2} {b2} {c2}"); // => 0 0 0

// Compound assignment evaluates the left side once and converts back to the LHS type
byte small = 200;
small += 10;  // equivalent to: small = (byte)(small + 10); result wraps to 210
Console.WriteLine(small); // => 210
// </AssignmentChain>
