---
name: ".NET breaking change"
about: Report a change in .NET that breaks something that worked in a previous version
  (intended mostly for product-team use)
title: ''
labels: ''
assignees: ''

---

<!--
	This issue template is for use in creating issues that document breaking changes. This template can be used to create an issue:

	- By Microsoft product team members who are documenting a breaking change.

	- By Microsoft customers who are experiencing a compatibility issue between .NET Framework and .NET Core or between versions of .NET Core.

	Text in brackets is a placeholder; replace the text with the requested information and remove the brackets before submitting the issue.

	Also, remove this comment before submitting the issue.
-->

## <!-- Change title -->

<!-- Brief description of the change -->

### Version introduced

<!-- Version in which the breaking change first occurred (for example, 3.0 for .NET Core 3.0) -->

### Old behavior

### New behavior

### Reason for change

### Recommended action

<!--
	Suggested steps if user is affected go here:
	- Possible workarounds
	- Example of code changes to handle change
-->

### Category

<!-- Choose a category from one of the following: -->

- [ ] ASP.NET Core
- [ ] C#
- [ ] Code analysis
- [ ] Core .NET libraries
- [ ] Cryptography
- [ ] Data
- [ ] Debugger
- [ ] Deployment
- [ ] Globalization
- [ ] Interop
- [ ] JIT
- [ ] LINQ
- [ ] Managed Extensibility Framework (MEF)
- [ ] MSBuild
- [ ] Networking
- [ ] Printing
- [ ] SDK
- [ ] Security
- [ ] Serialization
- [ ] Visual Basic
- [ ] Windows Forms
- [ ] Windows Presentation Foundation (WPF)
- [ ] XML, XSLT

### Affected APIs

<!-- If no APIs are affected, this should read:
     "Not detectable via API analysis"

  If affected APIs are identifiable, include a link for each. The link takes the form:

  `[friendly description of API](link to API on docs.microsoft.com)`

  For example, `[String.IndexOf(String)](https://docs.microsoft.com/dotnet/api/system.string.indexof#System_String_IndexOf_System_String_)

  For methods, if all overloads are affected, link to the general overloaded method page. For example:

  <https://docs.microsoft.com/dotnet/api/system.string.indexof>

  Otherwise, link to the individual method overload. For example:

  <https://docs.microsoft.com/dotnet/api/system.string.indexof#System_String_IndexOf_System_String_>
-->

Finally, please remember to email a link to this breaking change issue to [.NET Breaking Change Notifications](mailto:dotnetbcn@microsoft.com).

<!-- Do not modify anything below this line -->

---
#### Issue metadata

* Issue type: breaking-change
