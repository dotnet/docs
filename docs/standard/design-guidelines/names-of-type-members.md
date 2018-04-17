---
title: "Names of Type Members"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "events [.NET Framework], names"
  - "methods [.NET Framework], names"
  - "type members"
  - "properties [.NET Framework], names"
  - "fields, names"
  - "field names"
  - "names [.NET Framework], type members"
  - "members [.NET Framework], type"
ms.assetid: af5a0903-36af-4c2a-b848-cf959affeaa5
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Names of Type Members
Types are made of members: methods, properties, events, constructors, and fields. The following sections describe guidelines for naming type members.  
  
## Names of Methods  
 Because methods are the means of taking action, the design guidelines require that method names be verbs or verb phrases. Following this guideline also serves to distinguish method names from property and type names, which are noun or adjective phrases.  
  
 **✓ DO** give methods names that are verbs or verb phrases.  
  
```  
public class String {  
    public int CompareTo(...);  
    public string[] Split(...);  
    public string Trim();  
}  
```  
  
## Names of Properties  
 Unlike other members, properties should be given noun phrase or adjective names. That is because a property refers to data, and the name of the property reflects that. PascalCasing is always used for property names.  
  
 **✓ DO** name properties using a noun, noun phrase, or adjective.  
  
 **X DO NOT** have properties that match the name of "Get" methods as in the following example:  
  
 `public string TextWriter { get {...} set {...} }`  
 `public string GetTextWriter(int value) { ... }`  
  
 This pattern typically indicates that the property should really be a method.  
  
 **✓ DO** name collection properties with a plural phrase describing the items in the collection instead of using a singular phrase followed by "List" or "Collection."  
  
 **✓ DO** name Boolean properties with an affirmative phrase (`CanSeek` instead of `CantSeek`). Optionally, you can also prefix Boolean properties with "Is," "Can," or "Has," but only where it adds value.  
  
 **✓ CONSIDER** giving a property the same name as its type.  
  
 For example, the following property correctly gets and sets an enum value named `Color`, so the property is named `Color`:  
  
```  
public enum Color {...}  
public class Control {  
    public Color Color { get {...} set {...} }  
}  
```  
  
## Names of Events  
 Events always refer to some action, either one that is happening or one that has occurred. Therefore, as with methods, events are named with verbs, and verb tense is used to indicate the time when the event is raised.  
  
 **✓ DO** name events with a verb or a verb phrase.  
  
 Examples include `Clicked`, `Painting`, `DroppedDown`, and so on.  
  
 **✓ DO** give events names with a concept of before and after, using the present and past tenses.  
  
 For example, a close event that is raised before a window is closed would be called `Closing`, and one that is raised after the window is closed would be called `Closed`.  
  
 **X DO NOT** use "Before" or "After" prefixes or postfixes to indicate pre- and post-events. Use present and past tenses as just described.  
  
 **✓ DO** name event handlers (delegates used as types of events) with the "EventHandler" suffix, as shown in the following example:  
  
 `public delegate void ClickedEventHandler(object sender, ClickedEventArgs e);`  
  
 **✓ DO** use two parameters named `sender` and `e` in event handlers.  
  
 The sender parameter represents the object that raised the event. The sender parameter is typically of type `object`, even if it is possible to employ a more specific type.  
  
 **✓ DO** name event argument classes with the "EventArgs" suffix.  
  
## Names of Fields  
 The field-naming guidelines apply to static public and protected fields. Internal and private fields are not covered by guidelines, and public or protected instance fields are not allowed by the [member design guidelines](../../../docs/standard/design-guidelines/member.md).  
  
 **✓ DO** use PascalCasing in field names.  
  
 **✓ DO** name fields using a noun, noun phrase, or adjective.  
  
 **X DO NOT** use a prefix for field names.  
  
 For example, do not use "g_" or "s_" to indicate static fields.  
  
 *Portions © 2005, 2009 Microsoft Corporation. All rights reserved.*  
  
 *Reprinted by permission of Pearson Education, Inc. from [Framework Design Guidelines: Conventions, Idioms, and Patterns for Reusable .NET Libraries, 2nd Edition](https://www.informit.com/store/framework-design-guidelines-conventions-idioms-and-9780321545619) by Krzysztof Cwalina and Brad Abrams, published Oct 22, 2008 by Addison-Wesley Professional as part of the Microsoft Windows Development Series.*  
  
## See Also  
 [Framework Design Guidelines](../../../docs/standard/design-guidelines/index.md)  
 [Naming Guidelines](../../../docs/standard/design-guidelines/naming-guidelines.md)
