using RefSafety;

var i = EscapeScopes.OuterMethod();
Console.WriteLine(i);

ref int value = ref (new EscapeScopes().RetrieveIndexRef());
Console.WriteLine(value);

// <RefAssignment>
int anInteger = 42; // assignment.
ref int location = ref anInteger; // ref assignment.
ref int sameLocation = ref location; // ref assignment

Console.WriteLine(location); // output: 42

sameLocation = 19; // assignment

Console.WriteLine(anInteger); // output: 19
// </RefAssignment>