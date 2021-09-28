---
description: "Learn more about: Input Character Set (Entity SQL)"
title: "Input Character Set (Entity SQL)"
ms.date: "03/30/2017"
ms.assetid: 13d291d3-e6bc-4719-b953-758b61a590b6
---
# Input Character Set (Entity SQL)

Entity SQL accepts UNICODE characters encoded in UTF-16.

 String literals can contain any UTF-16 character enclosed in single quotes. For example, N'文字列リテラル'. When string literals are compared, the original UTF-16 values are used. For example, N'ABC' is different in Japanese and Latin codepages.

 Comments can contain any UTF-16 character.

 Escaped identifiers can contain any UTF-16 character enclosed in square brackets. For example, [エスケープされた識別子]. The comparison of UTF-16 escaped identifiers is case insensitive. Entity SQL treats versions of letters that appear the same but are from different code pages as different characters. For example, [ABC] is equivalent to [abc] if the corresponding characters are from the same code page. However, if the same two identifiers are from different code pages, they are not equivalent.

 White space is any UTF-16 white space character.

 A newline is any normalized UTF-16 newline character. For example, '\n' and '\r\n' are considered newline characters, but '\r' is not a newline character.

 Keywords, expressions, and punctuation can be any UTF-16 character that normalizes to Latin. For example, SELECT in a Japanese codepage is a valid keyword.

 Keywords, expressions, and punctuation can only be Latin characters. `SELECT` in a Japanese codepage is not a keyword. +, -, \*, /, =, (, ), ‘, [, ] and any other language construct not quoted here can only be Latin characters.

 Simple identifiers can only be Latin characters. This avoids ambiguity during comparison, because original values are compared. For example, ABC would be different in Japanese and Latin codepages.

## See also

- [Entity SQL Overview](entity-sql-overview.md)
