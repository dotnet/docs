// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// <ArrayDeclarations>
int[] anArrayOfIntegers;
string[,,] threeDimensionalStringArray;
// </ArrayDeclarations>

// <ArrayInitializers>
int[] fiveIntegers = new int[5];
string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
// </ArrayInitializers>

// <ImplicitInitializer>
var implicitType = new[] { 1, 2, 3 };
        
char c = 'c';
short s1 = 0;
short s2 = -0;
short s3 = 1;
short s4 = -1;

// common type is "int"
var commonType = new[] { s1, s2, s3, s4, c, 1 }; 
// </ImplicitInitializer>