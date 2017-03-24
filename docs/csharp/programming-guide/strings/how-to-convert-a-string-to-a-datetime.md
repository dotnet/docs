---
title: "How to: Convert a String to a DateTime (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "strings [C#], converting to DateTIme"
ms.assetid: 88abef11-3a06-4b49-8dd2-61ed0e876fc3
caps.latest.revision: 21
author: "BillWagner"
ms.author: "wiwagn"

translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# How to: Convert a String to a DateTime (C# Programming Guide)
It is common for programs to enable users to enter dates as string values. To convert a string-based date to a <xref:System.DateTime?displayProperty=fullName> object, you can use the <xref:System.Convert.ToDateTime%28System.String%29?displayProperty=fullName> method or the <xref:System.DateTime.Parse%28System.String%29?displayProperty=fullName> static method, as shown in the following example.  
  
 **Culture**.  Different cultures in the world write date strings in different ways.  For example, in the US 01/20/2008 is January 20th, 2008.  In France this will throw an InvalidFormatException. This is because France reads date-times as Day/Month/Year, and in the US it is Month/Day/Year.  
  
 Consequently, a string like 20/01/2008 will parse to January 20th, 2008 in France, and then throw an InvalidFormatException in the US.  
  
 To determine your current culture settings, you can use System.Globalization.CultureInfo.CurrentCulture.  
  
 See the example below for a simple example of converting a string to dateTime.  
  
 For more examples of date strings, see <xref:System.Convert.ToDateTime%28System.String%29?displayProperty=fullName>.  
  
```csharp  
string dateTime = "01/08/2008 14:50:50.42";  
            DateTime dt = Convert.ToDateTime(dateTime);  
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}, Hour: {3}, Minute: {4}, Second: {5}, Millisecond: {6}",  
                              dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);  
            // Specify exactly how to interpret the string.  
            IFormatProvider culture = new System.Globalization.CultureInfo("fr-FR", true);  
  
            // Alternate choice: If the string has been input by an end user, you might    
            // want to format it according to the current culture:   
            // IFormatProvider culture = System.Threading.Thread.CurrentThread.CurrentCulture;  
            DateTime dt2 = DateTime.Parse(dateTime, culture, System.Globalization.DateTimeStyles.AssumeLocal);  
            Console.WriteLine("Year: {0}, Month: {1}, Day: {2}, Hour: {3}, Minute: {4}, Second: {5}, Millisecond: {6}",  
                              dt2.Year, dt2.Month, dt2.Day, dt2.Hour, dt2.Minute, dt2.Second, dt2.Millisecond  
/* Output (assuming first culture is en-US and second is fr-FR):  
    Year: 2008, Month: 1, Day: 8, Hour: 14, Minute: 50, Second: 50, Millisecond: 420  
Year: 2008, Month: 8, Day: 1, Hour: 14, Minute: 50, Second: 50, Millisecond: 420  
Press any key to continue . . .  
 */  
```  
  
## Example  
 [!code-cs[csProgGuideStrings#13](../../../csharp/programming-guide/strings/codesnippet/CSharp/how-to-convert-a-string-to-a-datetime_1.cs)]  
  
## See Also  
 [Strings](../../../csharp/programming-guide/strings/index.md)