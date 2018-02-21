---
title: "Using Regular Expressions with the MaskedTextBox Control in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "strings [Visual Basic], regular expressions"
  - "strings [Visual Basic], masked edit"
ms.assetid: 2a048fb0-7053-487d-b2c5-ffa5e22ed6f9
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# Using Regular Expressions with the MaskedTextBox Control in Visual Basic
This example demonstrates how to convert simple regular expressions to work with the <xref:System.Windows.Forms.MaskedTextBox> control.  
  
## Description of the Masking Language  
 The standard <xref:System.Windows.Forms.MaskedTextBox> masking language is based on the one used by the `Masked Edit` control in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] 6.0 and should be familiar to users migrating from that platform.  
  
 The <xref:System.Windows.Forms.MaskedTextBox.Mask%2A> property of the <xref:System.Windows.Forms.MaskedTextBox> control specifies what input mask to use. The mask must be a string composed of one or more of the masking elements from the following table.  
  
|Masking element|Description|Regular expression element|  
|---------------------|-----------------|--------------------------------|  
|0|Any single digit between 0 and 9. Entry required.|\d|  
|9|Digit or space. Entry optional.|[ \d]?|  
|#|Digit or space. Entry optional. If this position is left blank in the mask, it will be rendered as a space. Plus (+) and minus (-) signs are allowed.|[ \d+-]?|  
|L|ASCII letter. Entry required.|[a-zA-Z]|  
|?|ASCII letter. Entry optional.|[a-zA-Z]?|  
|&|Character. Entry required.|[\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo}]|  
|C|Character. Entry optional.|[\p{Ll}\p{Lu}\p{Lt}\p{Lm}\p{Lo}]?|  
|A|Alphanumeric. Entry optional.|\W|  
|.|Culture-appropriate decimal placeholder.|Not available.|  
|,|Culture-appropriate thousands placeholder.|Not available.|  
|:|Culture-appropriate time separator.|Not available.|  
|/|Culture-appropriate date separator.|Not available.|  
|$|Culture-appropriate currency symbol.|Not available.|  
|\<|Converts all characters that follow to lowercase.|Not available.|  
|>|Converts all characters that follow to uppercase.|Not available.|  
|&#124;|Undoes a previous shift up or shift down.|Not available.|  
|\|Escapes a mask character, turning it into a literal. "\\\\" is the escape sequence for a backslash.|\|  
|All other characters.|Literals. All non-mask elements will appear as themselves within <xref:System.Windows.Forms.MaskedTextBox>.|All other characters.|  
  
 The decimal (.), thousandths (,), time (:), date (/), and currency ($) symbols default to displaying those symbols as defined by the application's culture. You can force them to display symbols for another culture by using the <xref:System.Windows.Forms.MaskedTextBox.FormatProvider%2A> property.  
  
## Regular Expressions and Masks  
 Although you can use regular expressions and masks to validate user input, they are not completely equivalent. Regular expressions can express more complex patterns than masks, but masks can express the same information more succinctly and in a culturally relevant format.  
  
 The following table compares four regular expressions and the equivalent mask for each.  
  
|Regular Expression|Mask|Notes|  
|------------------------|----------|-----------|  
|`\d{2}/\d{2}/\d{4}`|`00/00/0000`|The `/` character in the mask is a logical date separator, and it will appear to the user as the date separator appropriate to the application's current culture.|  
|`\d{2}-[A-Z][a-z]{2}-\d{4}`|`00->L<LL-0000`|A date (day, month abbreviation, and year) in United States format in which the three-letter month abbreviation is displayed with an initial uppercase letter followed by two lowercase letters.|  
|`(\(\d{3}\)-)?\d{3}-d{4}`|`(999)-000-0000`|United States phone number, area code optional. If the user does not wish to enter the optional characters, she can either enter spaces or place the mouse pointer directly at the position in the mask represented by the first 0.|  
|`$\d{6}.00`|`$999,999.00`|A currency value in the range of 0 to 999999. The currency, thousandth, and decimal characters will be replaced at run-time with their culture-specific equivalents.|  
  
## See Also  
 <xref:System.Windows.Forms.MaskedTextBox.Mask%2A>  
 <xref:System.Windows.Forms.MaskedTextBox>  
 [Validating Strings in Visual Basic](../../../../visual-basic/programming-guide/language-features/strings/validating-strings.md)  
 [MaskedTextBox Control](../../../../framework/winforms/controls/maskedtextbox-control-windows-forms.md)
