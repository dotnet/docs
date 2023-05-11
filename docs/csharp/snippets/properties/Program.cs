var initOnly = new VersionNinePoint1.Person();

// <SnippetInitialize>
var person = new VersionNinePoint2.Person("John");
person = new VersionNinePoint2.Person{ FirstName = "John"};
// Error CS9035: Required member `Person.FirstName` must be set:
//person = new VersionNinePoint2.Person();
// </SnippetInitialize>


