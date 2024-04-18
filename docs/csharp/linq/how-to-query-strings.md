---
title: "LINQ and strings (C#)"
description: You can query a string as a sequence of characters in LINQ. This topic contains several examples you can use or modify to suit your needs.
ms.topic: how-to
ms.date: 04/19/2024
---
# How to: use LINQ to query strings

Introduction to talk about strings as a sequence of characters

## How to query for characters in a string

Because the <xref:System.String> class implements the generic <xref:System.Collections.Generic.IEnumerable%601> interface, any string can be queried as a sequence of characters. However, this is not a common use of LINQ. For complex pattern matching operations, use the <xref:System.Text.RegularExpressions.Regex> class.

The following example queries a string to determine the number of numeric digits it contains. Note that the query is "reused" after it is executed the first time. This is possible because the query itself does not store any actual results.

:::code language="csharp" source="./snippets/HowToStrings/Program.cs" id="CharsInAString":::

## How to count occurrences of a word in a string

This example shows how to use a LINQ query to count the occurrences of a specified word in a string. Note that to perform the count, first the <xref:System.String.Split%2A> method is called to create an array of words. There is a performance cost to the <xref:System.String.Split%2A> method. If the only operation on the string is to count the words, you should consider using the <xref:System.Text.RegularExpressions.Regex.Matches%2A> or <xref:System.String.IndexOf%2A> methods instead. However, if performance is not a critical issue, or you have already split the sentence in order to perform other types of queries over it, then it makes sense to use LINQ to count the words or phrases as well.

:::code language="csharp" source="./snippets/HowToStrings/Program.cs" id="CountWordsInAString":::

## How to sort or filter text data by any word or field

The following example shows how to sort lines of structured text, such as comma-separated values, by any field in the line. The field may be dynamically specified at run time. Assume that the fields in scores.csv represent a student's ID number, followed by a series of four test scores.

Copy the scores.csv data and save it to your solution folder.

:::code language="txt" source="./snippets/HowToFilesAndDirectories/scores.csv":::

The code is here:

:::code language="csharp" source="./snippets/HowToStrings/Program.cs" id="SortStrings":::

## How to query for sentences that contain a specified set of words

This example shows how to find sentences in a text file that contain matches for each of a specified set of words. Although the array of search terms is hard-coded in this example, it could also be populated dynamically at run time. In this example, the query returns the sentences that contain the words "Historically," "data," and "integrated."

:::code language="csharp" source="./snippets/HowToStrings/Program.cs" id="FindSentences":::

The query works by first splitting the text into sentences, and then splitting the sentences into an array of strings that hold each word. For each of these arrays, the <xref:System.Linq.Enumerable.Distinct%2A> method removes all duplicate words, and then the query performs an <xref:System.Linq.Enumerable.Intersect%2A> operation on the word array and the `wordsToMatch` array. If the count of the intersection is the same as the count of the `wordsToMatch` array, all words were found in the words and the original sentence is returned.

In the call to <xref:System.String.Split%2A>, the punctuation marks are used as separators in order to remove them from the string. If you did not do this, for example you could have a string "Historically," that would not match "Historically" in the `wordsToMatch` array. You may have to use additional separators, depending on the types of punctuation found in the source text.

## How to combine LINQ queries with regular expressions

This example shows how to use the <xref:System.Text.RegularExpressions.Regex> class to create a regular expression for more complex matching in text strings. The LINQ query makes it easy to filter on exactly the files that you want to search with the regular expression, and to shape the results.

:::code language="csharp" source="./snippets/HowToStrings/Program.cs" id="QueryWithRegEx":::

Note that you can also query the <xref:System.Text.RegularExpressions.MatchCollection> object that is returned by a `RegEx` search. In this example only the value of each match is produced in the results. However, it is also possible to use LINQ to perform all kinds of filtering, sorting, and grouping on that collection. Because <xref:System.Text.RegularExpressions.MatchCollection> is a non-generic <xref:System.Collections.IEnumerable> collection, you have to explicitly state the type of the range variable in the query.
