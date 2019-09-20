---
title: "How to: Join Content from Dissimilar Files (LINQ) (Visual Basic)"
ms.date: 06/27/2018
ms.assetid: e7530857-c467-41ea-9730-84e6b1065a4d
---
# How to: Join Content from Dissimilar Files (LINQ) (Visual Basic)

This example shows how to join data from two comma-delimited files that share a common value that is used as a matching key. This technique can be useful if you have to combine data from two spreadsheets, or from a spreadsheet and from a file that has another format, into a new file. You can modify the example to work with any kind of structured text.  
  
## To create the data files
  
1. Copy the following lines into a file that is named scores.csv and save it to your project folder. The file represents spreadsheet data. Column 1 is the student's ID, and columns 2 through 5 are test scores.  
  
    ```csv  
    111, 97, 92, 81, 60  
    112, 75, 84, 91, 39  
    113, 88, 94, 65, 91  
    114, 97, 89, 85, 82  
    115, 35, 72, 91, 70  
    116, 99, 86, 90, 94  
    117, 93, 92, 80, 87  
    118, 92, 90, 83, 78  
    119, 68, 79, 88, 92  
    120, 99, 82, 81, 79  
    121, 96, 85, 91, 60  
    122, 94, 92, 91, 91  
    ```  
  
2. Copy the following lines into a file that is named names.csv and save it to your project folder. The file represents a spreadsheet that contains the student's last name, first name, and student ID.  
  
    ```csv  
    Omelchenko,Svetlana,111  
    O'Donnell,Claire,112  
    Mortensen,Sven,113  
    Garcia,Cesar,114  
    Garcia,Debra,115  
    Fakhouri,Fadi,116  
    Feng,Hanying,117  
    Garcia,Hugo,118  
    Tucker,Lance,119  
    Adams,Terry,120  
    Zabokritski,Eugene,121  
    Tucker,Michael,122  
    ```  
  
## Example  

```vb
Imports System.Collections.Generic
Imports System.Linq

Class JoinStrings  
  
    Shared Sub Main()  
  
        ' Join content from spreadsheet files that contain  
        ' related information. names.csv contains the student name  
        ' plus an ID number. scores.csv contains the ID and a   
        ' set of four test scores. The following query joins  
        ' the scores to the student names by using ID as a  
        ' matching key.  
  
        Dim names As String() = System.IO.File.ReadAllLines("../../../names.csv")  
        Dim scores As String() = System.IO.File.ReadAllLines("../../../scores.csv")  
  
        ' Name:    Last[0],       First[1],  ID[2],     Grade Level[3]  
        '          Omelchenko,    Svetlana,  111,       2  
        ' Score:   StudentID[0],  Exam1[1]   Exam2[2],  Exam3[3],  Exam4[4]  
        '          111,           97,        92,        81,        60  
  
        ' This query joins two dissimilar spreadsheets based on common ID value.  
        ' Multiple from clauses are used instead of a join clause  
        ' in order to store results of id.Split.  
        Dim scoreQuery1 = From name In names   
                         Let n = name.Split(New Char() {","})   
                            From id In scores   
                            Let n2 = id.Split(New Char() {","})   
                            Where Convert.ToInt32(n(2)) = Convert.ToInt32(n2(0))
                            Select n(0) & "," & n2(1) & "," & n2(2) & "," & n2(3) & "," &  n2(4)
  
        ' Pass a query variable to a Sub and execute it there.  
        ' The query itself is unchanged.  
        OutputQueryResults(scoreQuery1, "Merge two spreadsheets:")  
  
        ' Keep console window open in debug mode.  
        Console.WriteLine("Press any key to exit.")  
        Console.ReadKey()  
    End Sub  
  
    Shared Sub OutputQueryResults(ByVal query As IEnumerable(Of String), ByVal message As String)  
  
        Console.WriteLine(System.Environment.NewLine & message)  
        For Each item As String In query  
            Console.WriteLine(item)  
        Next  
        Console.WriteLine(query.Count & " total names in list")  
  
    End Sub  
End Class  
' Output:  
' Merge two spreadsheets:
' Omelchenko, 97, 92, 81, 60
' O'Donnell, 75, 84, 91, 39
' Mortensen, 88, 94, 65, 91
' Garcia, 97, 89, 85, 82
' Garcia, 35, 72, 91, 70
' Fakhouri, 99, 86, 90, 94
' Feng, 93, 92, 80, 87
' Garcia, 92, 90, 83, 78
' Tucker, 68, 79, 88, 92
' Adams, 99, 82, 81, 79
' Zabokritski, 96, 85, 91, 60
' Tucker, 94, 92, 91, 91
' 12 total names in list 
```  

## See also

- [LINQ and Strings (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-and-strings.md)
- [LINQ and File Directories (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/linq-and-file-directories.md)
