---
title: "Connection Strings in ADO.NET"
ms.date: "03/30/2017"
ms.assetid: 745c5f95-2f02-4674-b378-6d51a7ec2490
---
# Connection Strings in ADO.NET

A connection string contains initialization information that is passed as a parameter from a data provider to a data source. The data provider accepts the connection string via the <xref:System.Data.Common.DbConnection.ConnectionString?displayProperty=nameWithType> property, whose setter parses it and ensures the syntax is correct and the keywords are supported.
The <xref:System.Data.Common.DbConnection.Open?displayProperty=nameWithType> method passes the parsed connection parameters to the data source, which performs further validation and establishes a connection.

A connection string is a semicolon-delimited list of key/value parameter pairs:
  
	keyword1=value; keyword2=value;
  
Keywords are not case-sensitive. Values, however, may be case-sensitive, depending on the data source. Both keywords and values may contain [whitespace characters](https://en.wikipedia.org/wiki/Whitespace_character#Unicode), although leading and trailing whitespace is ignored in keywords and unquoted values.

If a value contains the semicolon, [Unicode control characters](https://en.wikipedia.org/wiki/Unicode_control_characters), leading or trailing whitespace it must be enclosed in single or double quotation marks, e.g.:

	Keyword=" whitespace  ";
	Keyword='special;character';

The enclosing character may not occur within the value it encloses. Therefore, a value containing single quotation marks can be enclosed only in double quotation marks and vice versa:

	Keyword='double"quotation;mark';
	Keyword="single'quotation;mark";

The quotation marks themselves, as well as the equals sign, do not require escaping, so the following connection strings are valid:

	Keyword=no "escaping" 'required';
	Keyword=a=b=c

Since each value is read till the next semicolon or the end of string, the value in the latter example is `a=b=c`, and the final semicolon is optional.

Although all connection strings share the same syntax described above, the set of recognised keywords depends on the provider and has evolved over the years from earlier APIs such as *ODBC*. The *.NET Framework* data provider for *SQL Server* (`SqlClient`) supports many keywords from older APIs but is generally more flexible and accepts synonyms for many of the common connection-string keywords.

Spelling errors can cause problems. For example, `Integrated Security=true` is valid, whereas `IntegratedSecurity=true` causes an error. In addition, connection strings manually constructed at run-time from unvalidated user input are vulnerable to string-injection attacks, jeopardizing security at the data source. To address these problems, *ADO.NET* 2.0 introduced new [connection-string builders](../../../../docs/framework/data/adonet/connection-string-builders.md) for each *.NET Framework* data provider. They expose parameters as strongly-typed properties, enabling connection strings to be validated before submission to the data source.

## In This Section  
 [Connection String Builders](../../../../docs/framework/data/adonet/connection-string-builders.md)  
 Demonstrates how to use the `ConnectionStringBuilder` classes to construct valid connection strings at run time.
  
 [Connection Strings and Configuration Files](../../../../docs/framework/data/adonet/connection-strings-and-configuration-files.md)  
 Demonstrates how to store and retrieve connection strings in configuration files.
  
 [Connection String Syntax](../../../../docs/framework/data/adonet/connection-string-syntax.md)  
 Describes how to configure provider-specific connection strings for `SqlClient`, `OracleClient`, `OleDb`, and `Odbc`.
  
 [Protecting Connection Information](../../../../docs/framework/data/adonet/protecting-connection-information.md)  
 Demonstrates techniques for protecting information used to connect to a data source.
  
## See Also  
 [Connecting to a Data Source](/cpp/data/odbc/connecting-to-a-data-source)  
 [ADO.NET Managed Providers and DataSet Developer Center](https://go.microsoft.com/fwlink/?LinkId=217917)
