string s = "The answer is " + 5.ToString();
// Outputs: "The answer is 5"
Console.WriteLine(s);

Type type = 12345.GetType();
// Outputs: "System.Int32"
Console.WriteLine(type);

var x = 123_456;
string s2 = "I can use an underscore as a digit separator: " + x;
// Outputs: "I can use an underscore as a digit separator: 
Console.WriteLine(s2);

var b = 0b1010_1011_1100_1110_1111;
string s3 = "I can specify bit patterns: " + b.ToString();
// Outputs: "I can specify bit patterns: 703727
Console.WriteLine(s3);
