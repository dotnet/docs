---
title: "How to: Create a File or Folder (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "folders [C#]"
  - "creating files [C#]"
  - "files [C#]"
  - "creating folders [C#]"
ms.assetid: 4582ee2d-d72d-4687-bcb9-08d336c62c25
caps.latest.revision: 22
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Create a File or Folder (C# Programming Guide)
You can programmatically create a folder on your computer, create a subfolder, create a file in the subfolder, and write data to the file.  
  
## Example  
 [!code-csharp[csFilesandFolders#10](../../../csharp/programming-guide/file-system/codesnippet/CSharp/how-to-create-a-file-or-folder_1.cs)]  
  
 If the folder already exists, <xref:System.IO.Directory.CreateDirectory%2A> does nothing, and no exception is thrown. However, <xref:System.IO.File.Create%2A?displayProperty=nameWithType> replaces an existing file with a new file. The example uses an `if`-`else` statement to prevent an existing file from being replaced.  
  
 By making the following changes in the example, you can specify different outcomes based on whether a file with a certain name already exists. If such a file doesn't exist, the code creates one. If such a file exists, the code appends data to that file.  
  
-   Specify a non-random file name.  
  
    ```csharp  
    // Comment out the following line.  
    //string fileName = System.IO.Path.GetRandomFileName();  
  
    // Replace that line with the following assignment.  
    string fileName = "MyNewFile.txt";  
    ```  
  
-   Replace the `if`-`else` statement with the `using` statement in the following code.  
  
    ```csharp  
    using (System.IO.FileStream fs = new System.IO.FileStream(pathString, FileMode.Append))   
    {  
        for (byte i = 0; i < 100; i++)  
        {  
            fs.WriteByte(i);  
        }  
    }  
    ```  
  
 Run the example several times to verify that data is added to the file each time.  
  
 For more `FileMode` values that you can try, see <xref:System.IO.FileMode>.  
  
 The following conditions may cause an exception:  
  
-   The folder name is malformed. For example, it contains illegal characters or is only white space (<xref:System.ArgumentException> class). Use the <xref:System.IO.Path> class to create valid path names.  
  
-   The parent folder of the folder to be created is read-only (<xref:System.IO.IOException> class).  
  
-   The folder name is `null` (<xref:System.ArgumentNullException> class).  
  
-   The folder name is too long (<xref:System.IO.PathTooLongException> class).  
  
-   The folder name is only a colon, ":" (<xref:System.IO.PathTooLongException> class).  
  
## .NET Framework Security  
 An instance of the <xref:System.Security.SecurityException> class may be thrown in partial-trust situations.  
  
 If you don’t have permission to create the folder, the example throws an instance of the <xref:System.UnauthorizedAccessException> class.  
  
## See Also  
 <xref:System.IO?displayProperty=nameWithType>  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [File System and the Registry (C# Programming Guide)](../../../csharp/programming-guide/file-system/index.md)
