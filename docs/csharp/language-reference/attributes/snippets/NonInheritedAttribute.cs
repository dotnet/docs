namespace attributes;

// <SnippetNonInherited>
[AttributeUsage(AttributeTargets.Class, Inherited = false)]
class NonInheritedAttribute : Attribute { }

[NonInherited]
class BClass { }

class DClass : BClass { }
// </SnippetNonInherited>
