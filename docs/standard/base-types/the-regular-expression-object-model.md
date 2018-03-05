---
title: "The Regular Expression Object Model"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "searching with regular expressions, backreferences"
  - "Regex class"
  - "Match class"
  - "pattern-matching with regular expressions, backreferences"
  - ".NET Framework regular expressions, classes"
  - "CaptureCollection class"
  - "Group class"
  - "characters [.NET Framework], backreferences"
  - "substrings"
  - ".NET Framework regular expressions, backreferences"
  - "searching with regular expressions, classes"
  - "backreferences"
  - "Capture class"
  - "repeating groups of characters"
  - "MatchCollection class"
  - "parsing text with regular expressions, backreferences"
  - "regular expressions [.NET Framework]"
  - "characters [.NET Framework], regular expressions"
  - "classes [.NET Framework], regular expression"
  - "regular expressions [.NET Framework], classes"
  - "characters [.NET Framework], metacharacters"
  - "metacharacters, regular expression classes"
  - "metacharacters, backreferences"
  - "parsing text with regular expressions, classes"
  - "regular expressions [.NET Framework], backreferences"
  - "strings [.NET Framework], regular expressions"
  - "pattern-matching with regular expressions, classes"
  - "GroupCollection class"
ms.assetid: 49a21470-64ca-4b5a-a889-8e24e3c0af7e
caps.latest.revision: 26
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# The Regular Expression Object Model
<a name="introduction"></a> This topic describes the object model used in working with .NET regular expressions. It contains the following sections:  
  
-   [The Regular Expression Engine](#Engine)  
  
-   [The MatchCollection and Match Objects](#Match_and_MCollection)  
  
-   [The Group Collection](#GroupCollection)  
  
-   [The Captured Group](#the_captured_group)  
  
-   [The Capture Collection](#CaptureCollection)  
  
-   [The Individual Capture](#the_individual_capture)  
  
<a name="Engine"></a>   
## The Regular Expression Engine  
 The regular expression engine in .NET is represented by the <xref:System.Text.RegularExpressions.Regex> class. The regular expression engine is responsible for parsing and compiling a regular expression, and for performing operations that match the regular expression pattern with an input string. The engine is the central component in the .NET regular expression object model.  
  
 You can use the regular expression engine in either of two ways:  
  
-   By calling the static methods of the <xref:System.Text.RegularExpressions.Regex> class. The method parameters include the input string and the regular expression pattern. The regular expression engine caches regular expressions that are used in static method calls, so repeated calls to static regular expression methods that use the same regular expression offer relatively good performance.  
  
-   By instantiating a <xref:System.Text.RegularExpressions.Regex> object, by passing a regular expression to the class constructor. In this case, the <xref:System.Text.RegularExpressions.Regex> object is immutable (read-only) and represents a regular expression engine that is tightly coupled with a single regular expression. Because regular expressions used by <xref:System.Text.RegularExpressions.Regex> instances are not cached, you should not instantiate a <xref:System.Text.RegularExpressions.Regex> object multiple times with the same regular expression.  
  
 You can call the methods of the <xref:System.Text.RegularExpressions.Regex> class to perform the following operations:  
  
-   Determine whether a string matches a regular expression pattern.  
  
-   Extract a single match or the first match.  
  
-   Extract all matches.  
  
-   Replace a matched substring.  
  
-   Split a single string into an array of strings.  
  
 These operations are described in the following sections.  
  
### Matching a Regular Expression Pattern  
 The <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method returns `true` if the string matches the pattern, or `false` if it does not. The <xref:System.Text.RegularExpressions.Regex.IsMatch%2A> method is often used to validate string input. For example, the following code ensures that a string matches a valid social security number in the United States.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#1](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/validate1.cs#1)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/validate1.vb#1)]  
  
 The regular expression pattern `^\d{3}-\d{2}-\d{4}$` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Match the beginning of the input string.|  
|`\d{3}`|Match three decimal digits.|  
|`-`|Match a hyphen.|  
|`\d{2}`|Match two decimal digits.|  
|`-`|Match a hyphen.|  
|`\d{4}`|Match four decimal digits.|  
|`$`|Match the end of the input string.|  
  
### Extracting a Single Match or the First Match  
 The <xref:System.Text.RegularExpressions.Regex.Match%2A?displayProperty=nameWithType> method returns a <xref:System.Text.RegularExpressions.Match> object that contains information about the first substring that matches a regular expression pattern. If the `Match.Success` property returns `true`, indicating that a match was found, you can retrieve information about subsequent matches by calling the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method. These method calls can continue until the `Match.Success` property returns `false`. For example, the following code uses the <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%29?displayProperty=nameWithType> method to find the first occurrence of a duplicated word in a string. It then calls the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method to find any additional occurrences. The example examines the `Match.Success` property after each method call to determine whether the current match was successful and whether a call to the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method should follow.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#2](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/match1.cs#2)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/match1.vb#2)]  
  
 The regular expression pattern `\b(\w+)\W+(\1)\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match on a word boundary.|  
|`(\w+)`|Match one or more word characters. This is the first capturing group.|  
|`\W+`|Match one or more non-word characters.|  
|`(\1)`|Match the first captured string. This is the second capturing group.|  
|`\b`|End the match on a word boundary.|  
  
### Extracting All Matches  
 The <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method returns a <xref:System.Text.RegularExpressions.MatchCollection> object that contains information about all matches that the regular expression engine found in the input string. For example, the previous example could be rewritten to call the <xref:System.Text.RegularExpressions.Regex.Matches%2A> method instead of the <xref:System.Text.RegularExpressions.Regex.Match%2A> and <xref:System.Text.RegularExpressions.Match.NextMatch%2A> methods.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#3](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/matches1.cs#3)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/matches1.vb#3)]  
  
### Replacing a Matched Substring  
 The <xref:System.Text.RegularExpressions.Regex.Replace%2A?displayProperty=nameWithType> method replaces each substring that matches the regular expression pattern with a specified string or regular expression pattern, and returns the entire input string with replacements. For example, the following code adds a U.S. currency symbol before a decimal number in a string.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#4](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/replace1.cs#4)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/replace1.vb#4)]  
  
 The regular expression pattern `\b\d+\.\d{2}\b` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`\d+`|Match one or more decimal digits.|  
|`\.`|Match a period.|  
|`\d{2}`|Match two decimal digits.|  
|`\b`|End the match at a word boundary.|  
  
 The replacement pattern `$$$&` is interpreted as shown in the following table.  
  
|Pattern|Replacement string|  
|-------------|------------------------|  
|`$$`|The dollar sign ($) character.|  
|`$&`|The entire matched substring.|  
  
### Splitting a Single String into an Array of Strings  
 The <xref:System.Text.RegularExpressions.Regex.Split%2A?displayProperty=nameWithType> method splits the input string at the positions defined by a regular expression match. For example, the following code places the items in a numbered list into a string array.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#5](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/split1.cs#5)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/split1.vb#5)]  
  
 The regular expression pattern `\b\d{1,2}\.\s` is interpreted as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`\d{1,2}`|Match one or two decimal digits.|  
|`\.`|Match a period.|  
|`\s`|Match a white-space character.|  
  
<a name="Match_and_MCollection"></a>   
## The MatchCollection and Match Objects  
 Regex methods return two objects that are part of the regular expression object model: the <xref:System.Text.RegularExpressions.MatchCollection> object, and the <xref:System.Text.RegularExpressions.Match> object.  
  
<a name="the_match_collection"></a>   
### The Match Collection  
 The <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method returns a <xref:System.Text.RegularExpressions.MatchCollection> object that contains <xref:System.Text.RegularExpressions.Match> objects that represent all the matches that the regular expression engine found, in the order in which they occur in the input string. If there are no matches, the method returns a <xref:System.Text.RegularExpressions.MatchCollection> object with no members. The <xref:System.Text.RegularExpressions.MatchCollection.Item%2A?displayProperty=nameWithType> property lets you access individual members of the collection by index, from zero to one less than the value of the <xref:System.Text.RegularExpressions.MatchCollection.Count%2A?displayProperty=nameWithType> property. <xref:System.Text.RegularExpressions.MatchCollection.Item%2A> is the collection's indexer (in C#) and default property (in Visual Basic).  
  
 By default, the call to the <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method uses lazy evaluation to populate the <xref:System.Text.RegularExpressions.MatchCollection> object. Access to properties that require a fully populated collection, such as the <xref:System.Text.RegularExpressions.MatchCollection.Count%2A?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.MatchCollection.Item%2A?displayProperty=nameWithType> properties, may involve a performance penalty. As a result, we recommend that you access the collection by using the <xref:System.Collections.IEnumerator> object that is returned by the <xref:System.Text.RegularExpressions.MatchCollection.GetEnumerator%2A?displayProperty=nameWithType> method. Individual languages provide constructs, such as `For``Each` in Visual Basic and `foreach` in C#, that wrap the collection's <xref:System.Collections.IEnumerator> interface.  
  
 The following example uses the <xref:System.Text.RegularExpressions.Regex.Matches%28System.String%29?displayProperty=nameWithType> method to populate a <xref:System.Text.RegularExpressions.MatchCollection> object with all the matches found in an input string. The example enumerates the collection, copies the matches to a string array, and records the character positions in an integer array.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#6](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/matchcollection1.cs#6)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/matchcollection1.vb#6)]  
  
<a name="the_match"></a>   
### The Match  
 The <xref:System.Text.RegularExpressions.Match> class represents the result of a single regular expression match. You can access <xref:System.Text.RegularExpressions.Match> objects in two ways:  
  
-   By retrieving them from the <xref:System.Text.RegularExpressions.MatchCollection> object that is returned by the <xref:System.Text.RegularExpressions.Regex.Matches%2A?displayProperty=nameWithType> method. To retrieve individual <xref:System.Text.RegularExpressions.Match> objects, iterate the collection by using a `foreach` (in C#) or `For Each`...`Next` (in Visual Basic) construct, or use the <xref:System.Text.RegularExpressions.MatchCollection.Item%2A?displayProperty=nameWithType> property to retrieve a specific <xref:System.Text.RegularExpressions.Match> object either by index or by name. You can also retrieve individual <xref:System.Text.RegularExpressions.Match> objects from the collection by iterating the collection by index, from zero to one less that the number of objects in the collection. However, this method does not take advantage of lazy evaluation, because it accesses the <xref:System.Text.RegularExpressions.MatchCollection.Count%2A?displayProperty=nameWithType> property.  
  
     The following example retrieves individual <xref:System.Text.RegularExpressions.Match> objects from a <xref:System.Text.RegularExpressions.MatchCollection> object by iterating the collection using the `foreach` or `For Each`...`Next` construct. The regular expression simply matches the string "abc" in the input string.  
  
     [!code-csharp[Conceptual.RegularExpressions.ObjectModel#7](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/match2.cs#7)]
     [!code-vb[Conceptual.RegularExpressions.ObjectModel#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/match2.vb#7)]  
  
-   By calling the <xref:System.Text.RegularExpressions.Regex.Match%2A?displayProperty=nameWithType> method, which returns a <xref:System.Text.RegularExpressions.Match> object that represents the first match in a string or a portion of a string. You can determine whether the match has been found by retrieving the value of the `Match.Success` property. To retrieve <xref:System.Text.RegularExpressions.Match> objects that represent subsequent matches, call the <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method repeatedly, until the `Success` property of the returned <xref:System.Text.RegularExpressions.Match> object is `false`.  
  
     The following example uses the <xref:System.Text.RegularExpressions.Regex.Match%28System.String%2CSystem.String%29?displayProperty=nameWithType> and <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> methods to match the string "abc" in the input string.  
  
     [!code-csharp[Conceptual.RegularExpressions.ObjectModel#8](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/match3.cs#8)]
     [!code-vb[Conceptual.RegularExpressions.ObjectModel#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/match3.vb#8)]  
  
 Two properties of the <xref:System.Text.RegularExpressions.Match> class return collection objects:  
  
-   The <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property returns a <xref:System.Text.RegularExpressions.GroupCollection> object that contains information about the substrings that match capturing groups in the regular expression pattern.  
  
-   The `Match.Captures` property returns a <xref:System.Text.RegularExpressions.CaptureCollection> object that is of limited use. The collection is not populated for a <xref:System.Text.RegularExpressions.Match> object whose `Success` property is `false`. Otherwise, it contains a single <xref:System.Text.RegularExpressions.Capture> object that has the same information as the <xref:System.Text.RegularExpressions.Match> object.  
  
 For more information about these objects, see [The Group Collection](#GroupCollection) and [The Capture Collection](#CaptureCollection) sections later in this topic.  
  
 Two additional properties of the <xref:System.Text.RegularExpressions.Match> class provide information about the match. The `Match.Value` property returns the substring in the input string that matches the regular expression pattern. The `Match.Index` property returns the zero-based starting position of the matched string in the input string.  
  
 The <xref:System.Text.RegularExpressions.Match> class also has two pattern-matching methods:  
  
-   The <xref:System.Text.RegularExpressions.Match.NextMatch%2A?displayProperty=nameWithType> method finds the match after the match represented by the current <xref:System.Text.RegularExpressions.Match> object, and returns a <xref:System.Text.RegularExpressions.Match> object that represents that match.  
  
-   The <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method performs a specified replacement operation on the matched string and returns the result.  
  
 The following example uses the <xref:System.Text.RegularExpressions.Match.Result%2A?displayProperty=nameWithType> method to prepend a $ symbol and a space before every number that includes two fractional digits.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#9](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/result1.cs#9)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/result1.vb#9)]  
  
 The regular expression pattern `\b\d+(,\d{3})*\.\d{2}\b` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`\d+`|Match one or more decimal digits.|  
|`(,\d{3})*`|Match zero or more occurrences of a comma followed by three decimal digits.|  
|`\.`|Match the decimal point character.|  
|`\d{2}`|Match two decimal digits.|  
|`\b`|End the match at a word boundary.|  
  
 The replacement pattern `$$ $&` indicates that the matched substring should be replaced by a dollar sign ($) symbol (the `$$` pattern), a space, and the value of the match (the `$&` pattern).  
  
 [Back to top](#introduction)  
  
<a name="GroupCollection"></a>   
## The Group Collection  
 The <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property returns a <xref:System.Text.RegularExpressions.GroupCollection> object that contains <xref:System.Text.RegularExpressions.Group> objects that represent captured groups in a single match. The first <xref:System.Text.RegularExpressions.Group> object in the collection (at index 0) represents the entire match. Each object that follows represents the results of a single capturing group.  
  
 You can retrieve individual <xref:System.Text.RegularExpressions.Group> objects in the collection by using the <xref:System.Text.RegularExpressions.GroupCollection.Item%2A?displayProperty=nameWithType> property. You can retrieve unnamed groups by their ordinal position in the collection, and retrieve named groups either by name or by ordinal position. Unnamed captures appear first in the collection, and are indexed from left to right in the order in which they appear in the regular expression pattern. Named captures are indexed after unnamed captures, from left to right in the order in which they appear in the regular expression pattern. To determine what numbered groups are available in the collection returned for a particular regular expression matching method, you can call the instance <xref:System.Text.RegularExpressions.Regex.GetGroupNumbers%2A?displayProperty=nameWithType> method. To determine what named groups are available in the collection, you can call the instance <xref:System.Text.RegularExpressions.Regex.GetGroupNames%2A?displayProperty=nameWithType> method. Both methods are particularly useful in general-purpose routines that analyze the matches found by any regular expression.  
  
 The <xref:System.Text.RegularExpressions.GroupCollection.Item%2A?displayProperty=nameWithType> property is the indexer of the collection in C# and the collection object's default property in Visual Basic. This means that individual <xref:System.Text.RegularExpressions.Group> objects can be accessed by index (or by name, in the case of named groups) as follows:  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#13](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/groupsyntax1.cs#13)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#13](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/groupsyntax1.vb#13)]  
  
 The following example defines a regular expression that uses grouping constructs to capture the month, day, and year of a date.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#10](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/groupcollection1.cs#10)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#10](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/groupcollection1.vb#10)]  
  
 The regular expression pattern `\b(\w+)\s(\d{1,2}),\s(\d{4})\b` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\b`|Begin the match at a word boundary.|  
|`(\w+)`|Match one or more word characters. This is the first capturing group.|  
|`\s`|Match a white-space character.|  
|`(\d{1,2})`|Match one or two decimal digits. This is the second capturing group.|  
|`,`|Match a comma.|  
|`\s`|Match a white-space character.|  
|`(\d{4})`|Match four decimal digits. This is the third capturing group.|  
|`\b`|End the match on a word boundary.|  
  
 [Back to top](#introduction)  
  
<a name="the_captured_group"></a>   
## The Captured Group  
 The <xref:System.Text.RegularExpressions.Group> class represents the result from a single capturing group. Group objects that represent the capturing groups defined in a regular expression are returned by the <xref:System.Text.RegularExpressions.GroupCollection.Item%2A> property of the <xref:System.Text.RegularExpressions.GroupCollection> object returned by the <xref:System.Text.RegularExpressions.Match.Groups%2A?displayProperty=nameWithType> property. The <xref:System.Text.RegularExpressions.GroupCollection.Item%2A> property is the indexer (in C#) and the default property (in Visual Basic) of the <xref:System.Text.RegularExpressions.Group> class. You can also retrieve individual members by iterating the collection using the `foreach` or `For``Each` construct. For an example, see the previous section.  
  
 The following example uses nested grouping constructs to capture substrings into groups. The regular expression pattern `(a(b))c` matches the string "abc". It assigns the substring "ab" to the first capturing group, and the substring "b" to the second capturing group.  
  
 [!code-csharp[RegularExpressions.Classes#6](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Classes/cs/Example.cs#6)]
 [!code-vb[RegularExpressions.Classes#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Classes/vb/Example.vb#6)]  
  
 The following example uses named grouping constructs to capture substrings from a string that contains data in the format "DATANAME:VALUE", which the regular expression splits at the colon (:).  
  
 [!code-csharp[RegularExpressions.Classes#8](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Classes/cs/Example.cs#8)]
 [!code-vb[RegularExpressions.Classes#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Classes/vb/Example.vb#8)]  
  
 The regular expression pattern `^(?<name>\w+):(?<value>\w+)` is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`^`|Begin the match at the beginning of the input string.|  
|`(?<name>\w+)`|Match one or more word characters. The name of this capturing group is `name`.|  
|`:`|Match a colon.|  
|`(?<value>\w+)`|Match one or more word characters. The name of this capturing group is `value`.|  
  
 The properties of the <xref:System.Text.RegularExpressions.Group> class provide information about the captured group: The `Group.Value` property contains the captured substring, the `Group.Index` property indicates the starting position of the captured group in the input text, the `Group.Length` property contains the length of the captured text, and the `Group.Success` property indicates whether a substring matched the pattern defined by the capturing group.  
  
 Applying quantifiers to a group (for more information, see [Quantifiers](../../../docs/standard/base-types/quantifiers-in-regular-expressions.md)) modifies the relationship of one capture per capturing group in two ways:  
  
-   If the `*` or `*?` quantifier (which specifies zero or more matches) is applied to a group, a capturing group may not have a match in the input string. When there is no captured text, the properties of the <xref:System.Text.RegularExpressions.Group> object are set as shown in the following table.  
  
    |Group property|Value|  
    |--------------------|-----------|  
    |`Success`|`false`|  
    |`Value`|<xref:System.String.Empty?displayProperty=nameWithType>|  
    |`Length`|0|  
  
     The following example provides an illustration. In the regular expression pattern `aaa(bbb)*ccc`, the first capturing group (the substring "bbb") can be matched zero or more times. Because the input string "aaaccc" matches the pattern, the capturing group does not have a match.  
  
     [!code-csharp[Conceptual.RegularExpressions.ObjectModel#11](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/nocapture1.cs#11)]
     [!code-vb[Conceptual.RegularExpressions.ObjectModel#11](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/nocapture1.vb#11)]  
  
-   Quantifiers can match multiple occurrences of a pattern that is defined by a capturing group. In this case, the `Value` and `Length` properties of a <xref:System.Text.RegularExpressions.Group> object contain information only about the last captured substring. For example, the following regular expression matches a single sentence that ends in a period. It uses two grouping constructs: The first captures individual words along with a white-space character; the second captures individual words. As the output from the example shows, although the regular expression succeeds in capturing an entire sentence, the second capturing group captures only the last word.  
  
     [!code-csharp[Conceptual.RegularExpressions.ObjectModel#12](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/lastcapture1.cs#12)]
     [!code-vb[Conceptual.RegularExpressions.ObjectModel#12](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/lastcapture1.vb#12)]  
  
 [Back to top](#introduction)  
  
<a name="CaptureCollection"></a>   
## The Capture Collection  
 The <xref:System.Text.RegularExpressions.Group> object contains information only about the last capture. However, the entire set of captures made by a capturing group is still available from the <xref:System.Text.RegularExpressions.CaptureCollection> object that is returned by the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> property. Each member of the collection is a <xref:System.Text.RegularExpressions.Capture> object that represents a capture made by that capturing group, in the order in which they were captured (and, therefore, in the order in which the captured strings were matched from left to right in the input string). You can retrieve individual <xref:System.Text.RegularExpressions.Capture> objects from the collection in either of two ways:  
  
-   By iterating through the collection using a construct such as `foreach` (in C#) or `For``Each` (in Visual Basic).  
  
-   By using the <xref:System.Text.RegularExpressions.CaptureCollection.Item%2A?displayProperty=nameWithType> property to retrieve a specific object by index. The <xref:System.Text.RegularExpressions.CaptureCollection.Item%2A> property is the <xref:System.Text.RegularExpressions.CaptureCollection> object's default property (in Visual Basic) or indexer (in C#).  
  
 If a quantifier is not applied to a capturing group, the <xref:System.Text.RegularExpressions.CaptureCollection> object contains a single <xref:System.Text.RegularExpressions.Capture> object that is of little interest, because it provides information about the same match as its <xref:System.Text.RegularExpressions.Group> object. If a quantifier is applied to a capturing group, the <xref:System.Text.RegularExpressions.CaptureCollection> object contains all captures made by the capturing group, and the last member of the collection represents the same capture as the <xref:System.Text.RegularExpressions.Group> object.  
  
 For example, if you use the regular expression pattern `((a(b))c)+` (where the + quantifier specifies one or more matches) to capture matches from the string "abcabcabc", the <xref:System.Text.RegularExpressions.CaptureCollection> object for each <xref:System.Text.RegularExpressions.Group> object contains three members.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#14](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/capturecollection1.cs#14)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#14](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/capturecollection1.vb#14)]  
  
 The following example uses the regular expression `(Abc)+` to find one or more consecutive runs of the string "Abc" in the string "XYZAbcAbcAbcXYZAbcAb". The example illustrates the use of the <xref:System.Text.RegularExpressions.Group.Captures%2A?displayProperty=nameWithType> property to return multiple groups of captured substrings.  
  
 [!code-csharp[RegularExpressions.Classes#5](../../../samples/snippets/csharp/VS_Snippets_CLR/RegularExpressions.Classes/cs/Example.cs#5)]
 [!code-vb[RegularExpressions.Classes#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/RegularExpressions.Classes/vb/Example.vb#5)]  
  
 [Back to top](#introduction)  
  
<a name="the_individual_capture"></a>   
## The Individual Capture  
 The <xref:System.Text.RegularExpressions.Capture> class contains the results from a single subexpression capture. The <xref:System.Text.RegularExpressions.Capture.Value%2A?displayProperty=nameWithType> property contains the matched text, and the <xref:System.Text.RegularExpressions.Capture.Index%2A?displayProperty=nameWithType> property indicates the zero-based position in the input string at which the matched substring begins.  
  
 The following example parses an input string for the temperature of selected cities. A comma (",") is used to separate a city and its temperature, and a semicolon (";") is used to separate each city's data. The entire input string represents a single match. In the regular expression pattern `((\w+(\s\w+)*),(\d+);)+`, which is used to parse the string, the city name is assigned to the second capturing group, and the temperature is assigned to the fourth capturing group.  
  
 [!code-csharp[Conceptual.RegularExpressions.ObjectModel#16](../../../samples/snippets/csharp/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/cs/capture1.cs#16)]
 [!code-vb[Conceptual.RegularExpressions.ObjectModel#16](../../../samples/snippets/visualbasic/VS_Snippets_CLR/conceptual.regularexpressions.objectmodel/vb/capture1.vb#16)]  
  
 The regular expression is defined as shown in the following table.  
  
|Pattern|Description|  
|-------------|-----------------|  
|`\w+`|Match one or more word characters.|  
|`(\s\w+)*`|Match zero or more occurrences of a white-space character followed by one or more word characters. This pattern matches multi-word city names. This is the third capturing group.|  
|`(\w+(\s\w+)*)`|Match one or more word characters followed by zero or more occurrences of a white-space character and one or more word characters. This is the second capturing group.|  
|`,`|Match a comma.|  
|`(\d+)`|Match one or more digits. This is the fourth capturing group.|  
|`;`|Match a semicolon.|  
|`((\w+(\s\w+)*),(\d+);)+`|Match the pattern of a word followed by any additional words followed by a comma, one or more digits, and a semicolon, one or more times. This is the first capturing group.|  
  
## See Also  
 <xref:System.Text.RegularExpressions>  
 [.NET Regular Expressions](../../../docs/standard/base-types/regular-expressions.md)  
 [Regular Expression Language - Quick Reference](../../../docs/standard/base-types/regular-expression-language-quick-reference.md)
