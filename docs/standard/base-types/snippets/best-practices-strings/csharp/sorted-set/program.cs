#!/usr/bin/dotnet run

// Words to sort
string[] values= [ "able", "ångström", "apple", "Æble",
                    "Windows", "Visual Studio" ];

//
// Potentially incorrect code - behavior might vary based on locale.
//
SortedSet<string> mySet = [.. values]; // No comparer specified

List<string> list = [.. values];
list.Sort(); // No comparer specified

//
// Corrected code - uses ordinal sorting; doesn't vary by locale.
//
SortedSet<string> mySet2 = new(values ,StringComparer.Ordinal);

List<string> list2 = [.. values];
list2.Sort(StringComparer.Ordinal);
