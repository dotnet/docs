---
Your magic stuff
---

# NET Core version history

Version numbers for the .NET Core are challenging because .NET Core SDK and .NET Core Runtime release on different cadences. Because of this, we can do only two of the following three things:

1. Release independently, specifically allowing tools, C# and VB to advance faster than the .NET Core Runtime.
2. Maintain alignment in version numbers between .NET Core SDK and .NET Core Runtime.
3. Use semantic versioning for both the .NET Core SDK and .NET Core Runtime.

2.0.0 forced version alignment and this proceeded smoothly for one release. In December 2017 .NET Core SDK had a feature release, with no corresponding release in the .NET Core Runtime. The team chose goals 1 and 3, losing alignment between the .NET Core Runtime and SDK and resulted in a several .NET Core SDK 2.1.x versions that were released before .NET Core Runtime 2.1. Since the SDK is not forwards compatible, these 2.1.x SDK versions could not target .NET Core Runtime 2.1. The team responded to the considerable confusion this caused by switching to goals 1 and 2, abandoning semantic versioning as described in [.NET Core versioning]([[ index.md]]).

Because the timing of the decision to abandon semantic versioning was made between , there were transitional releases in the 2.1.10x and 2.1.20x version number ranges that can also not target .NET Core Runtime 2.1. 

The first two digits of the version numbers realign with the 2.1.0 version of the .NET Core Runtime and the 2.1.300 version of the .NET Core SDK.

Evaluating [releases.json](https://github.com/dotnet/core/blob/master/release-notes/releases.json) yields the following. [[Who can help fill in the missing C# versions?]]

| Date       | .NET Core SDK(4) | .NET Core Runtimes | Contains C# | Contains VB | Notes |
|------------|------------------|--------------------|-------------|-------------|-------|
| 2017-03-07 | 1.0.1            | 1.0.4,1.1.1        | 7.0         | 15.0        |       |
| 2017-05-09 | 1.0.4            | 1.0.5, 1.1.2       |             |             |       |
| 2017-09-21 | 1.1.4            | 1.0.7, 1.1.4       |             |             |       |
| 2017-11-14 | 1.1.7            | 1.0.8, 1.1.5       |             |             |       |
| 2017-11-14 | 1.1.7            | 1.0.9, 1.1.6       |             |             |       |
| 2018-03-13 | 1.1.8            | 1.0.10, 1.1.7      |             |             |       |
| 2018-04-17 | 1.1.9            | 1.0.11, 1.1.8      |             |             |       |
| 2017-08-14 | 2.0.0            | 2.0.0              | 7.1         |             |       |
| 2017-11-14 | 2.0.3            | 2.0.3              | 7.1         | 15.1        |       |
| 2017-12-04 | 2.1.2            | 2.0.3              | 7.1         | 15.1        | (1)   |
| 2018-01-09 | 2.1.4            | 2.0.5              | 7.1         | 15.1        | (1)   |
| 2018-03-13 | 2.1.100          | 2.0.5              | 7.2         | 15.2        | (1,2) |
| 2018-03-13 | 2.1.101          | 2.0.6              | 7.2         | 15.2        | (1,2) |
| 2018-03-19 | 2.1.102          | 2.0.6              | 7.2         | 15.2        | (1,2) |
| 2018-03-22 | 2.1.103          | 2.0.6              | 7.2         | 15.2        | (1,2) |
| 2018-04-04 | 2.1.104          | 2.0.6              | 7.2         | 15.2        | (1,2) |
| 2018-04-27 | 2.1.105          | 2.0.7              | 7.2         | 15.2        | (1,2) |
| 2018-05-08 | 2.1.200          | 2.0.8              | 7.2         | 15.2        | (1,2) |
| 2018-05-21 | 2.1.201          | 2.0.8              | 7.2         | 15.2        | (1,2) |
| 2018-05-30 | 2.1.300          | 2.1.0              | 7.3         | 15.3        | (3)   |

(1) These versions of .NET Core SDK 2.1.x cannot build apps targeting .NET Core Runtime 2.1.x
(2) The new version number scheme was decided at the start of 2018. However, there were two feature level releases before .NET Core Runtime 2.10 released. Thus, 2.1.10x and 2.20x represent a transition period. 
(3) The .NET Core 2.1 release represents unification of version numbers on the new scheme
(4) A nightly build of the .NET Core SDK appeared with the version number starting with 15. This must be manually removed from the machine. 