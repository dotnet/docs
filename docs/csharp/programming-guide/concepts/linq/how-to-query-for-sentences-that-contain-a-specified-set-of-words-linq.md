---
title: "How to: Query for Sentences that Contain a Specified Set of Words (LINQ) (C#)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
ms.assetid: 0724b429-4b87-4d26-a7b1-409358f3fc20
caps.latest.revision: 3
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Query for Sentences that Contain a Specified Set of Words (LINQ) (C#)
This example shows how to find sentences in a text file that contain matches for each of a specified set of words. Although the array of search terms is hard-coded in this example, it could also be populated dynamically at runtime. In this example, the query returns the sentences that contain the words "Historically," "data," and "integrated."  
  
## Example  
  
```csharp  
class FindSentences  
{  
    static void Main()  
    {  
        string text = @"Historically, the world of data and the world of objects " +  
        @"have not been well integrated. Programmers work in C# or Visual Basic " +  
        @"and also in SQL or XQuery. On the one side are concepts such as classes, " +  
        @"objects, fields, inheritance, and .NET Framework APIs. On the other side " +  
        @"are tables, columns, rows, nodes, and separate languages for dealing with " +  
        @"them. Data types often require translation between the two worlds; there are " +  
        @"different standard functions. Because the object world has no notion of query, a " +  
        @"query can only be represented as a string without compile-time type checking or " +  
        @"IntelliSense support in the IDE. Transferring data from SQL tables or XML trees to " +  
        @"objects in memory is often tedious and error-prone.";  
  
        // Split the text block into an array of sentences.  
        string[] sentences = text.Split(new char[] { '.', '?', '!' });  
  
        // Define the search terms. This list could also be dynamically populated at runtime.  
        string[] wordsToMatch = { "Historically", "data", "integrated" };  
  
        // Find sentences that contain all the terms in the wordsToMatch array.  
        // Note that the number of terms to match is not specified at compile time.  
        var sentenceQuery = from sentence in sentences  
                            let w = sentence.Split(new char[] { '.', '?', '!', ' ', ';', ':', ',' },  
                                                    StringSplitOptions.RemoveEmptyEntries)  
                            where w.Distinct().Intersect(wordsToMatch).Count() == wordsToMatch.Count()  
                            select sentence;  
  
        // Execute the query. Note that you can explicitly type  
        // the iteration variable here even though sentenceQuery  
        // was implicitly typed.   
        foreach (string str in sentenceQuery)  
        {  
            Console.WriteLine(str);  
        }  
  
        // Keep the console window open in debug mode.  
        Console.WriteLine("Press any key to exit");  
        Console.ReadKey();  
    }  
}  
/* Output:  
Historically, the world of data and the world of objects have not been well integrated  
*/  
```  
  
 The query works by first splitting the text into sentences, and then splitting the sentences into an array of strings that hold each word. For each of these arrays, the <xref:System.Linq.Enumerable.Distinct%2A> method removes all duplicate words, and then the query performs an <xref:System.Linq.Enumerable.Intersect%2A> operation on the word array and the `wordsToMatch` array. If the count of the intersection is the same as the count of the `wordsToMatch` array, all words were found in the words and the original sentence is returned.  
  
 In the call to <xref:System.String.Split%2A>, the punctuation marks are used as separators in order to remove them from the string. If you did not do this, for example you could have a string "Historically," that would not match "Historically" in the `wordsToMatch` array. You may have to use additional separators, depending on the types of punctuation found in the source text.  
  
## Compiling the Code  
 Create a project that targets the .NET Framework  version 3.5 or higher, with a reference to System.Core.dll and `using` directives for the System.Linq and System.IO namespaces.  
  
## See Also  
 [LINQ and Strings (C#)](../../../../csharp/programming-guide/concepts/linq/linq-and-strings.md)
