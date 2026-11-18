//<ImplicitConversion>
// Implicit conversion. A long can
// hold any value an int can hold, and more!
int num = 2147483647;
long bigNum = num;
//</ImplicitConversion>

// <ConversionToBase>
Derived d = new Derived();

// Always OK.
Base b = d;
// </ConversionToBase>

// <ExplicitConversion>
double x = 1234.7;
int a;
// Cast double to int.
a = (int)x;
Console.WriteLine(a);
// Output: 1234
// </ExplicitConversion>

//<ExplicitDerivedCast>
// Create a new derived type.
Giraffe g = new Giraffe();

// Implicit conversion to base type is safe.
Animal anAnimal = g;

// Explicit conversion is required to cast back
// to derived type. Note: This will compile but will
// throw an exception at run time if the right-side
// object is not in fact a Giraffe.
Giraffe g2 = (Giraffe)anAnimal;
// </ExplicitDerivedCast>

// <UnsafeCast>
Animal anotherAnimal = new Mammal();
Reptile r = (Reptile)anotherAnimal; // InvalidCastException at run time
//</UnsafeCast>


public class B {}

public class C : B {}


public class Animal { }

class Reptile : Animal { }
class Mammal : Animal { }

public class Giraffe : Animal {}

public class Base { }

public class Derived : Base { }

