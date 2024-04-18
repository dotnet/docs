---
title: "LINQ and file directories (C#)"
description: These C# LINQ resources for file system operations are not used to change the contents of the files or folders.
ms.date: 04/19/2024
---
# How to: use LINQ to query files and directories

Many file system operations are essentially queries and are therefore well suited to the LINQ approach.

The queries in this section are non-destructive. They are not used to change the contents of the original files or folders. This follows the rule that queries should not cause any side-effects. In general, any code (including queries that perform create / update / delete operators) that modifies source data should be kept separate from the code that just queries the data.

There is some complexity involved in creating a data source that accurately represents the contents of the file system and handles exceptions gracefully. The examples in this section create a snapshot collection of <xref:System.IO.FileInfo> objects that represents all the files under a specified root folder and all its subfolders. The actual state of each <xref:System.IO.FileInfo> may change in the time between when you begin and end executing a query. For example, you can create a list of <xref:System.IO.FileInfo> objects to use as a data source. If you try to access the `Length` property in a query, the <xref:System.IO.FileInfo> object will try to access the file system to update the value of `Length`. If the file no longer exists, you will get a <xref:System.IO.FileNotFoundException> in your query, even though you are not querying the file system directly. Some queries in this section use a separate method that consumes these particular exceptions in certain cases. Another option is to keep your data source updated dynamically by using the <xref:System.IO.FileSystemWatcher>.

## How to query for files with a specified attribute or name

This example shows how to find all files that have a specified file name extension (for example ".txt") in a specified directory tree. It also shows how to return either the newest or oldest file in the tree based on the creation time.:

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="FindFilesByExtension":::

## How to group files by extension

This example shows how LINQ can be used to perform advanced grouping and sorting operations on lists of files or folders. It also shows how to page output in the console window by using the <xref:System.Linq.Enumerable.Skip%2A> and <xref:System.Linq.Enumerable.Take%2A> methods.

The following query shows how to group the contents of a specified directory tree by the file name extension.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="GroupFilesByExtension":::

The output from this program can be long, depending on the details of the local file system and what the `startFolder` is set to. To enable viewing of all results, this example shows how to page through results. The same techniques can be applied to Windows and Web applications. Notice that because the code pages the items in a group, a nested `foreach` loop is required. There is also some additional logic to compute the current position in the list, and to enable the user to stop paging and exit the program. In this particular case, the paging query is run against the cached results from the original query. In other contexts, such as LINQ to SQL, such caching is not required.

## How to query for the total number of bytes in a set of folders

This example shows how to retrieve the total number of bytes used by all the files in a specified folder and all its subfolders.

The <xref:System.Linq.Enumerable.Sum%2A> method adds the values of all the items selected in the `select` clause. You can easily modify this query to retrieve the biggest or smallest file in the specified directory tree by calling the <xref:System.Linq.Enumerable.Min%2A> or <xref:System.Linq.Enumerable.Max%2A> method instead of <xref:System.Linq.Enumerable.Sum%2A>.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="QueryByFileSize":::

If you only have to count the number of bytes in a specified directory tree, you can do this more efficiently without creating a LINQ query, which incurs the overhead of creating the list collection as a data source. The usefulness of the LINQ approach increases as the query becomes more complex, or when you have to run multiple queries against the same data source.

The query calls out to a separate method to obtain the file length. It does this in order to consume the possible exception that will be raised if the file was deleted on another thread after the <xref:System.IO.FileInfo> object was created in the call to `GetFiles`. Even though the <xref:System.IO.FileInfo> object has already been created, the exception can occur because a <xref:System.IO.FileInfo> object will try to refresh its <xref:System.IO.FileInfo.Length%2A> property with the most current length the first time the property is accessed. By putting this operation in a try-catch block outside the query, the code follows the rule of avoiding operations in queries that can cause side-effects. In general, great care must be taken when you consume exceptions to make sure that an application is not left in an unknown state.

This example extends the previous example to do the following:

- How to retrieve the size in bytes of the largest file.
- How to retrieve the size in bytes of the smallest file.
- How to retrieve the <xref:System.IO.FileInfo> object largest or smallest file from one or more folders under a specified root folder.
- How to retrieve a sequence such as the 10 largest files.
- How to order files into groups based on their file size in bytes, ignoring files that are less than a specified size.

The following example contains five separate queries that show how to query and group files, depending on their file size in bytes. You can easily modify these examples to base the query on some other property of the <xref:System.IO.FileInfo> object.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="MoreQueriesOnFileSizes":::

To return one or more complete <xref:System.IO.FileInfo> objects, the query first must examine each one in the data source, and then sort them by the value of their Length property. Then it can return the single one or the sequence with the greatest lengths. Use <xref:System.Linq.Enumerable.First%2A> to return the first element in a list. Use <xref:System.Linq.Enumerable.Take%2A> to return the first n number of elements. Specify a descending sort order to put the smallest elements at the start of the list.

The query calls out to a separate method to obtain the file size in bytes in order to consume the possible exception that will be raised in the case where a file was deleted on another thread in the time period since the <xref:System.IO.FileInfo> object was created in the call to `GetFiles`. Even through the <xref:System.IO.FileInfo> object has already been created, the exception can occur because a <xref:System.IO.FileInfo> object will try to refresh its <xref:System.IO.FileInfo.Length%2A> property by using the most current size in bytes the first time the property is accessed. By putting this operation in a try-catch block outside the query, we follow the rule of avoiding operations in queries that can cause side-effects. In general, great care must be taken when consuming exceptions, to make sure that an application is not left in an unknown state.

## How to query for duplicate files in a directory tree

Sometimes files that have the same name may be located in more than one folder. For example, under the Visual Studio installation folder, several folders have a readme.htm file. This example shows how to query for such duplicate file names under a specified root folder. The second example shows how to query for files whose size and LastWrite times also match.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/DuplicateFileQuery.cs" id="QueryDuplicateNames":::

The first query uses a simple key to determine a match; this finds files that have the same name but whose contents might be different. The second query uses a compound key to match against three properties of the <xref:System.IO.FileInfo> object. This query is much more likely to find files that have the same name and similar or identical content.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/DuplicateFileQuery.cs" id="QueryDuplicateFileInfo":::

## How to query the contents of text files in a folder

This example shows how to query over all the files in a specified directory tree, open each file, and inspect its contents. This type of technique could be used to create indexes or reverse indexes of the contents of a directory tree. A simple string search is performed in this example. However, more complex types of pattern matching can be performed with a regular expression.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/DuplicateFileQuery.cs" id="QueryTextContent":::

## How to compare the contents of two folders

This example demonstrates three ways to compare two file listings:

- By querying for a Boolean value that specifies whether the two file lists are identical.
- By querying for the intersection to retrieve the files that are in both folders.
- By querying for the set difference to retrieve the files that are in one folder but not the other.

> [!NOTE]
> The techniques shown here can be adapted to compare sequences of objects of any type.
  
The `FileComparer` class shown here demonstrates how to use a custom comparer class together with the Standard Query Operators. The class is not intended for use in real-world scenarios. It just uses the name and length in bytes of each file to determine whether the contents of each folder are identical or not. In a real-world scenario, you should modify this comparer to perform a more rigorous equality check.

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/CompareDirectoryContents.cs" id="QueryDuplicateFileInfo":::

## How to reorder the fields of a delimited file

A comma-separated value (CSV) file is a text file that is often used to store spreadsheet data or other tabular data that is represented by rows and columns. By using the <xref:System.String.Split%2A> method to separate the fields, it is very easy to query and manipulate CSV files by using LINQ. In fact, the same technique can be used to reorder the parts of any structured line of text; it is not limited to CSV files.

In the following example, assume that the three columns represent students' "last name," "first name", and "ID." The fields are in alphabetical order based on the students' last names. The query produces a new sequence in which the ID column appears first, followed by a second column that combines the student's first name and last name. The lines are reordered according to the ID field. The results are saved into a new file and the original data is not modified.

Copy the following lines into a plain text file that is named spreadsheet1.csv. Save the file in your project folder.

:::code language="txt" source="./snippets/spreadsheet1.csv":::

Here's the code:

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="UpdateFileContent":::

## How to split a file into many files by using groups

This example shows one way to merge the contents of two files and then create a set of new files that organize the data in a new way.

Copy these names into a text file that is named names1.txt and save it in your project folder:

:::code language="txt" source="./snippets/names1.txt":::

Copy these names into a text file that is named names2.txt and save it in your project folder: Note that the two files have some names in common.

:::code language="txt" source="./snippets/names2.txt":::

The following code does the stuff:

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="SplitFileIntoGroups":::

The program writes a separate file for each group in the same folder as the data files.

## How to join content from dissimilar files

This example shows how to join data from two comma-delimited files that share a common value that is used as a matching key. This technique can be useful if you have to combine data from two spreadsheets, or from a spreadsheet and from a file that has another format, into a new file. You can modify the example to work with any kind of structured text.

Copy the following lines into a file that is named *scores.csv* and save it to your project folder. The file represents spreadsheet data. Column 1 is the student's ID, and columns 2 through 5 are test scores.

:::code language="txt" source="./snippets/scores.csv":::

Copy the following lines into a file that is named *names.csv* and save it to your project folder. The file represents a spreadsheet that contains the student's last name, first name, and student ID.

:::code language="txt" source="./snippets/names.csv":::

Join content from dissimilar files that contain related information. File names.csv contains the student name plus an ID number. File scores.csv contains the ID and a set of four test scores. The following query joins the scores to the student names by using ID as a matching key. The code follows:

:::code language="csharp" source="./snippets/HowToFilesAndDirectories/Program.cs" id="JoinDissimilarFiles":::

## How to compute column values in a CSV text file

This example shows how to perform aggregate computations such as Sum, Average, Min, and Max on the columns of a .csv file. The example principles that are shown here can be applied to other types of structured text.

Copy the following lines into a file that is named scores.csv and save it in your project folder. Assume that the first column represents a student ID, and subsequent columns represent scores from four exams.

:::code language="txt" source="./snippets/scores.csv":::


```csharp
class SumColumns
{
    static void Main(string[] args)
    {
        string[] lines = System.IO.File.ReadAllLines(@"../../../scores.csv");

        // Specifies the column to compute.
        int exam = 3;

        // Spreadsheet format:
        // Student ID    Exam#1  Exam#2  Exam#3  Exam#4
        // 111,          97,     92,     81,     60

        // Add one to exam to skip over the first column,
        // which holds the student ID.
        SingleColumn(lines, exam + 1);
        Console.WriteLine();
        MultiColumns(lines);

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }

    static void SingleColumn(IEnumerable<string> strs, int examNum)
    {
        Console.WriteLine("Single Column Query:");

        // Parameter examNum specifies the column to
        // run the calculations on. This value could be
        // passed in dynamically at run time.

        // Variable columnQuery is an IEnumerable<int>.
        // The following query performs two steps:
        // 1) use Split to break each row (a string) into an array
        //    of strings,
        // 2) convert the element at position examNum to an int
        //    and select it.
        var columnQuery =
            from line in strs
            let elements = line.Split(',')
            select Convert.ToInt32(elements[examNum]);

        // Execute the query and cache the results to improve
        // performance. This is helpful only with very large files.
        var results = columnQuery.ToList();

        // Perform aggregate calculations Average, Max, and
        // Min on the column specified by examNum.
        double average = results.Average();
        int max = results.Max();
        int min = results.Min();

        Console.WriteLine("Exam #{0}: Average:{1:##.##} High Score:{2} Low Score:{3}",
                 examNum, average, max, min);
    }

    static void MultiColumns(IEnumerable<string> strs)
    {
        Console.WriteLine("Multi Column Query:");

        // Create a query, multiColQuery. Explicit typing is used
        // to make clear that, when executed, multiColQuery produces
        // nested sequences. However, you get the same results by
        // using 'var'.

        // The multiColQuery query performs the following steps:
        // 1) use Split to break each row (a string) into an array
        //    of strings,
        // 2) use Skip to skip the "Student ID" column, and store the
        //    rest of the row in scores.
        // 3) convert each score in the current row from a string to
        //    an int, and select that entire sequence as one row
        //    in the results.
        IEnumerable<IEnumerable<int>> multiColQuery =
            from line in strs
            let elements = line.Split(',')
            let scores = elements.Skip(1)
            select (from str in scores
                    select Convert.ToInt32(str));

        // Execute the query and cache the results to improve
        // performance.
        // ToArray could be used instead of ToList.
        var results = multiColQuery.ToList();

        // Find out how many columns you have in results.
        int columnCount = results[0].Count();

        // Perform aggregate calculations Average, Max, and
        // Min on each column.
        // Perform one iteration of the loop for each column
        // of scores.
        // You can use a for loop instead of a foreach loop
        // because you already executed the multiColQuery
        // query by calling ToList.
        for (int column = 0; column < columnCount; column++)
        {
            var results2 = from row in results
                           select row.ElementAt(column);
            double average = results2.Average();
            int max = results2.Max();
            int min = results2.Min();

            // Add one to column because the first exam is Exam #1,
            // not Exam #0.
            Console.WriteLine("Exam #{0} Average: {1:##.##} High Score: {2} Low Score: {3}",
                          column + 1, average, max, min);
        }
    }
}
/* Output:
    Single Column Query:
    Exam #4: Average:76.92 High Score:94 Low Score:39

    Multi Column Query:
    Exam #1 Average: 86.08 High Score: 99 Low Score: 35
    Exam #2 Average: 86.42 High Score: 94 Low Score: 72
    Exam #3 Average: 84.75 High Score: 91 Low Score: 65
    Exam #4 Average: 76.92 High Score: 94 Low Score: 39
 */
```

The query works by using the <xref:System.String.Split%2A> method to convert each line of text into an array. Each array element represents a column. Finally, the text in each column is converted to its numeric representation. If your file is a tab-separated file, just update the argument in the `Split` method to `\t`.
  