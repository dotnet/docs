# Versioning in C#

As a developer who has created .NET libraries for either personal or public use,
you've most likely found yourself in situations where you need to maintain backwards compatibility between versions of your library.

A new version of your library is source compatible with a previous version if code that depends on the previous version can, when recompiled, work with the new version. 
In contrast, a new version of your library is binary compatible if an application that depended on the old version can, without recompilation, work with the new version.

Lucky for you C# has features to ensure that as a class evolves over time, through the addition of new members, other classes that derive from it still keep working as intended.
This is achieved through the use of the `virtual`, `override` and `new` keywords.

## virtual

_*TODO*: Explain virtual keyword with code sample_

## override

_*TODO*: Explain override keyword with code sample, make reference to previous code sample_

## new

_*TODO*: Explain new keyword with code sample, explain how it ties into previous sample code_
