// <Snippet1>
using namespace System;

void PrintValues(array<Object^>^myArr);
void PrintValues(array<int>^myArr);
void main()
{
	// Creates and initializes a new int array and a new Object array.
	array<int>^myIntArray = { 1,2,3,4,5 };
	array<Object^>^myObjArray = { 26,27,28,29,30 };

	// Prints the initial values of both arrays.
	Console::WriteLine("Initially:");
	Console::Write("int array:   ");
	PrintValues(myIntArray);
	Console::Write("Object array:");
	PrintValues(myObjArray);

	// Copies the first two elements from the int array to the Object array.
	System::Array::Copy(myIntArray, myObjArray, 2);

	// Prints the values of the modified arrays.
	Console::WriteLine("\nAfter copying the first two elements of the int array to the Object array:");
	Console::Write("int array:   ");
	PrintValues(myIntArray);
	Console::Write("Object array:");
	PrintValues(myObjArray);

	// Copies the last two elements from the Object array to the int array.
	System::Array::Copy(myObjArray, myObjArray->GetUpperBound(0) - 1, myIntArray, myIntArray->GetUpperBound(0) - 1, 2);

	// Prints the values of the modified arrays.
	Console::WriteLine("\nAfter copying the last two elements of the Object array to the int array:");
	Console::Write("int array:   ");
	PrintValues(myIntArray);
	Console::Write("Object array:");
	PrintValues(myObjArray);
}

void PrintValues(array<Object^>^myArr)
{
	for (int i = 0; i < myArr->Length; i++)
	{
		Console::Write("\t{0}", myArr[i]);

	}
	Console::WriteLine();
}

void PrintValues(array<int>^myArr)
{
	for (int i = 0; i < myArr->Length; i++)
	{
		Console::Write("\t{0}", myArr[i]);

	}
	Console::WriteLine();
}


/*
This code produces the following output.

Initially:
int array:       1    2    3    4    5
Object array:    26    27    28    29    30
After copying the first two elements of the int array to the Object array:
int array:       1    2    3    4    5
Object array:    1    2    28    29    30
After copying the last two elements of the Object array to the int array:
int array:       1    2    3    29    30
Object array:    1    2    28    29    30
*/
// </Snippet1>