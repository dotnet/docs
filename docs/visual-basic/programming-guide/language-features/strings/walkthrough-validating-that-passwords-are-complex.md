---
description: "Learn more about: Walkthrough: Validating That Passwords Are Complex (Visual Basic)"
title: "Validating Passwords Complexity"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "String data type [Visual Basic], validation"
ms.assetid: 5d9a918f-6c1f-41a3-a019-b5c2b8ce0381
---
# Walkthrough: Validating That Passwords Are Complex (Visual Basic)

This method checks for some strong-password characteristics and updates a string parameter with information about which checks the password fails.  
  
 Passwords can be used in a secure system to authorize a user. However, the passwords must be difficult for unauthorized users to guess. Attackers can use a *dictionary attack* program, which iterates through all of the words in a dictionary (or multiple dictionaries in different languages) and tests whether any of the words work as a user's password. Weak passwords such as "Yankees" or "Mustang" can be guessed quickly. Stronger passwords, such as "?You'L1N3vaFiNdMeyeP@sSWerd!", are much less likely to be guessed. A password-protected system should ensure that users choose strong passwords.  
  
 A strong password is complex (containing a mixture of uppercase, lowercase, numeric, and special characters) and is not a word. This example demonstrates how to verify complexity.  
  
## Example  
  
### Code  

 [!code-vb[VbVbcnRegEx#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnRegEx/VB/Class1.vb#1)]  
  
## Compile the code  

 Call this method by passing the string that contains that password.  
  
 This example requires:  
  
- Access to the members of the <xref:System.Text.RegularExpressions> namespace. Add an `Imports` statement if you are not fully qualifying member names in your code. For more information, see [Imports Statement (.NET Namespace and Type)](../../../language-reference/statements/imports-statement-net-namespace-and-type.md).  
  
## Security  

 If you're moving the password across a network, you need to use a secure method for transferring data. For more information, see [ASP.NET Web Application Security](/previous-versions/aspnet/330a99hc(v=vs.100)).
  
 You can improve the accuracy of the `ValidatePassword` function by adding additional complexity checks:  
  
- Compare the password and its substrings against the user's name, user identifier, and an application-defined dictionary. In addition, treat visually similar characters as equivalent when performing the comparisons. For example, treat the letters "l" and "e" as equivalent to the numerals "1" and "3".  
  
- If there is only one uppercase character, make sure it is not the password's first character.  
  
- Make sure that the last two characters of the password are letter characters.  
  
- Do not allow passwords in which all the symbols are entered from the keyboard's top row.  
  
## See also

- <xref:System.Text.RegularExpressions.Regex>
- [ASP.NET Web Application Security](/previous-versions/aspnet/330a99hc(v=vs.100))
