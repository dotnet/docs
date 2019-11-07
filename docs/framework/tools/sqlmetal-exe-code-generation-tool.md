---
title: "SqlMetal.exe (Code Generation Tool)"
ms.date: "03/30/2017"
helpviewer_keywords: 
  - "SQLMetal [LINQ to SQL]"
  - "code generation tool"
  - "SQLMetal.exe"
  - "LINQ to SQL, serialization"
  - "LINQ to SQL, DBML files"
  - "LINQ to SQL, SQLMetal"
ms.assetid: 819e5a96-7646-4fdb-b14b-fe31221b0614
---
# SqlMetal.exe (Code Generation Tool)
The SqlMetal command-line tool generates code and mapping for the [!INCLUDE[vbtecdlinq](../../../includes/vbtecdlinq-md.md)] component of the .NET Framework. By applying options that appear later in this topic, you can instruct SqlMetal to perform several different actions that include the following:  
  
- From a database, generate source code and mapping attributes or a mapping file.  
  
- From a database, generate an intermediate database markup language (.dbml) file for customization.  
  
- From a .dbml file, generate code and mapping attributes or a mapping file.  
  
 This tool is automatically installed with Visual Studio. By default, the file is located at `drive`:\Program Files\Microsoft SDKs\Windows\v`n.nn`\bin. If you do not install Visual Studio, you can also get the SQLMetal file by downloading the [Windows SDK](https://go.microsoft.com/fwlink/?LinkId=142225).  
  
> [!NOTE]
> Developers who use Visual Studio can also use the Object Relational Designer to generate entity classes. The command-line approach scales well for large databases. Because SqlMetal is a command-line tool, you can use it in a build process.  
  
 To run the tool, use the Developer Command Prompt for Visual Studio (or the Visual Studio Command Prompt in Windows 7). For more information, see [Command Prompts](developer-command-prompt-for-vs.md).At the command prompt, type the following:  
  
## Syntax  
  
```console  
sqlmetal [options] [<input file>]  
```  
  
## Options  
 To view the most current option list, type `sqlmetal /?` at a command prompt from the installed location.  
  
 **Connection Options**  
  
|Option|Description|  
|------------|-----------------|  
|**/server:** *\<name>*|Specifies database server name.|  
|**/database:** *\<name>*|Specifies database catalog on server.|  
|**/user:** *\<name>*|Specifies logon user id. Default value: Use Windows authentication.|  
|**/password:** *\<password>*|Specifies logon password. Default value: Use Windows authentication.|  
|**/conn:** *\<connection string>*|Specifies database connection string. Cannot be used with **/server**, **/database**, **/user**, or **/password** options.<br /><br /> Do not include the file name in the connection string. Instead, add the file name to the command line as the input file. For example, the following line specifies "c:\northwnd.mdf" as the input file: **sqlmetal /code:"c:\northwind.cs" /language:csharp "c:\northwnd.mdf"**.|  
|**/timeout:** *\<seconds>*|Specifies time-out value when SqlMetal accesses the database. Default value: 0 (that is, no time limit).|  
  
 **Extraction options**  
  
|Option|Description|  
|------------|-----------------|  
|**/views**|Extracts database views.|  
|**/functions**|Extracts database functions.|  
|**/sprocs**|Extracts stored procedures.|  
  
 **Output options**  
  
|Option|Description|  
|------------|-----------------|  
|**/dbml** *[:file]*|Sends output as .dbml. Cannot be used with **/map** option.|  
|**/code** *[:file]*|Sends output as source code. Cannot be used with **/dbml** option.|  
|**/map** *[:file]*|Generates an XML mapping file instead of attributes. Cannot be used with **/dbml** option.|  
  
 **Miscellaneous**  
  
|Option|Description|  
|------------|-----------------|  
|**/language:** *\<language>*|Specifies source code language.<br /><br /> Valid *\<language>*: vb, csharp.<br /><br /> Default value: Derived from extension on code file name.|  
|**/namespace:** *\<name>*|Specifies namespace of the generated code. Default value: no namespace.|  
|**/context:** *\<type>*|Specifies name of data context class. Default value: Derived from database name.|  
|**/entitybase:** *\<type>*|Specifies the base class of the entity classes in the generated code. Default value: Entities have no base class.|  
|**/pluralize**|Automatically pluralizes or singularizes class and member names.<br /><br /> This option is available only in the U.S. English version.|  
|**/serialization:** *\<option>*|Generates serializable classes.<br /><br /> Valid *\<option>*: None, Unidirectional. Default value: None.<br /><br /> For more information, see [Serialization](../data/adonet/sql/linq/serialization.md).|  
  
 **Input File**  
  
|Option|Description|  
|------------|-----------------|  
|**\<input file>**|Specifies a SQL Server Express .mdf file, a SQL Server Compact 3.5 .sdf file, or a .dbml intermediate file.|  
  
## Remarks  
 SqlMetal functionality actually involves two steps:  
  
- Extracting the metadata of the database into a .dbml file.  
  
- Generating a code output file.  
  
     By using the appropriate command-line options, you can produce Visual Basic or C# source code, or you can produce an XML mapping file.  
  
 To extract the metadata from an .mdf file, you must specify the name of the .mdf file after all other options.  
  
 If no **/server** is specified, **localhost/sqlexpress** is assumed.  
  
 Microsoft SQL Server 2005 throws an exception if one or more of the following conditions are true:  
  
- SqlMetal tries to extract a stored procedure that calls itself.  
  
- The nesting level of a stored procedure, function, or view exceeds 32.  
  
     SqlMetal catches this exception and reports it as a warning.  
  
 To specify an input file name, add the name to the command line as the input file. Including the file name in the connection string (using the **/conn** option) is not supported.  
  
## Examples  
 Generate a .dbml file that includes extracted SQL metadata:  
  
 **sqlmetal /server:myserver /database:northwind /dbml:mymeta.dbml**  
  
 Generate a .dbml file that includes extracted SQL metadata from an .mdf file by using SQL Server Express:  
  
 **sqlmetal /dbml:mymeta.dbml mydbfile.mdf**  
  
 Generate a .dbml file that includes extracted SQL metadata from SQL Server Express:  
  
 **sqlmetal /server:.\sqlexpress /dbml:mymeta.dbml /database:northwind**  
  
 Generate source code from a .dbml metadata file:  
  
 **sqlmetal /namespace:nwind /code:nwind.cs /language:csharp mymetal.dbml**  
  
 Generate source code from SQL metadata directly:  
  
 **sqlmetal /server:myserver /database:northwind /namespace:nwind /code:nwind.cs /language:csharp**  
  
> [!NOTE]
> When you use the **/pluralize** option with the Northwind sample database, note the following behavior. When SqlMetal makes row-type names for tables, the table names are singular. When it makes <xref:System.Data.Linq.DataContext> properties for tables, the table names are plural. Coincidentally, the tables in the Northwind sample database are already plural. Therefore, you do not see that part working. Although it is common practice to name database tables singular, it is also a common practice in .NET to name collections plural.  
  
## See also

- [How to: Generate the Object Model in Visual Basic or C#](../data/adonet/sql/linq/how-to-generate-the-object-model-in-visual-basic-or-csharp.md)
- [Code Generation in LINQ to SQL](../data/adonet/sql/linq/code-generation-in-linq-to-sql.md)
- [External Mapping](../data/adonet/sql/linq/external-mapping.md)
