---
title: "LINQ and strings (C#)"
description: LINQ can query and transform strings and collections of strings. You can combine LINQ queries with C# string functions and regular expressions.
ms.date: 07/20/2015
ms.assetid: dbe2d657-b3f3-487e-b645-21fb2d71cd7b
---
# LINQ and strings (C#)

LINQ can be used to query and transform strings and collections of strings. It can be especially useful with semi-structured data in text files. LINQ queries can be combined with traditional string functions and regular expressions. For example, you can use the <xref:System.String.Split%2A?displayProperty=nameWithType> or <xref:System.Text.RegularExpressions.Regex.Split%2A?displayProperty=nameWithType> method to create an array of strings that you can then query or modify by using LINQ. You can use the <xref:System.Text.RegularExpressions.Regex.IsMatch%2A?displayProperty=nameWithType> method in the `where` clause of a LINQ query. And you can use LINQ to query or modify the <xref:System.Text.RegularExpressions.MatchCollection> results returned by a regular expression.

You can also use the techniques described in this section to transform semi-structured text data to XML. For more information, see [How to generate XML from CSV files](../../../../standard/linq/generate-xml-csv-files.md).

The examples in this section fall into two categories:

## Querying a block of text

You can query, analyze, and modify text blocks by splitting them into a queryable array of smaller strings by using the <xref:System.String.Split%2A?displayProperty=nameWithType> method or the <xref:System.Text.RegularExpressions.Regex.Split%2A?displayProperty=nameWithType> method. You can split the source text into words, sentences, paragraphs, pages, or any other criteria, and then perform additional splits if they are required in your query.

- [How to count occurrences of a word in a string (LINQ) (C#)](how-to-count-occurrences-of-a-word-in-a-string-linq.md)  
  Shows how to use LINQ for simple querying over text.

- [How to query for sentences that contain a specified set of words (LINQ) (C#)](how-to-query-for-sentences-that-contain-a-specified-set-of-words-linq.md)

  Shows how to split text files on arbitrary boundaries and how to perform queries against each part.

- [How to query for characters in a string (LINQ) (C#)](how-to-query-for-characters-in-a-string-linq.md)

  Demonstrates that a string is a queryable type.

- [How to combine LINQ queries with regular expressions (C#)](how-to-combine-linq-queries-with-regular-expressions.md)

  Shows how to use regular expressions in LINQ queries for complex pattern matching on filtered query results.

## Querying semi-structured data in text format

Many different types of text files consist of a series of lines, often with similar formatting, such as tab- or comma-delimited files or fixed-length lines. After you read such a text file into memory, you can use LINQ to query and/or modify the lines. LINQ queries also simplify the task of combining data from multiple sources.

- [How to find the set difference between two lists (LINQ) (C#)](how-to-find-the-set-difference-between-two-lists-linq.md)

  Shows how to find all the strings that are present in one list but not the other.

- [How to sort or filter text data by any word or field (LINQ) (C#)](how-to-sort-or-filter-text-data-by-any-word-or-field-linq.md)

  Shows how to sort text lines based on any word or field.

- [How to reorder the fields of a delimited file (LINQ) (C#)](how-to-reorder-the-fields-of-a-delimited-file-linq.md)

  Shows how to reorder fields in a line in a .csv file.

- [How to combine and compare string collections (LINQ) (C#)](how-to-combine-and-compare-string-collections-linq.md)

  Shows how to combine string lists in various ways.

- [How to populate object collections from multiple sources (LINQ) (C#)](how-to-populate-object-collections-from-multiple-sources-linq.md)

  Shows how to create object collections by using multiple text files as data sources.

- [How to join content from dissimilar files (LINQ) (C#)](how-to-join-content-from-dissimilar-files-linq.md)
  
  Shows how to combine strings in two lists into a single string by using a matching key.

- [How to split a file into many files by using groups (LINQ) (C#)](how-to-split-a-file-into-many-files-by-using-groups-linq.md)
  
  Shows how to create new files by using a single file as a data source.

- [How to compute column values in a CSV text file (LINQ) (C#)](how-to-compute-column-values-in-a-csv-text-file-linq.md)
  
  Shows how to perform mathematical computations on text data in .csv files.

## See also

- [Language-Integrated Query (LINQ) (C#)](index.md)
- [How to generate XML from CSV files](../../../../standard/linq/generate-xml-csv-files.md)
