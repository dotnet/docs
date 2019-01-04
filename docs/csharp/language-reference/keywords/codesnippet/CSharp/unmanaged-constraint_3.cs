// example of same boilerplate code being reused for different unmanaged type routines

int Hash(Point point) { ... } 
int Hash(TimeSpan timeSpan) { ... } 

// To prevent this type of scenario the language will be introducing a new constraint: unmanaged:


void Hash<T>(T value) where T : unmanaged
{
    ...
}

/*This constraint can only be met by types which fit into the unmanaged type definition in the C# language spec. 
Another way of looking at it is that a type satisfies the unmanaged constraint if it can also be used as a pointer.
*/

Hash(new Point()); // Okay 
Hash(42); // Okay
Hash("hello") // Error: Type string does not satisfy the unmanaged constraint

/*Type parameters with the unmanaged constraint can use all the features available to unmanaged types: 
pointers, fixed, etc ...*/


void Hash<T>(T value) where T : unmanaged
{
    // Okay
    fixed (T* p = &value) 
    { 
        ...
    }
}
/*This constraint will also make it possible to have efficient conversions between structured data and streams of bytes. 
This is an operation that is common in networking stacks and serialization layers:*/

Span<byte> Convert<T>(ref T value) where T : unmanaged 
{
    ...
}

