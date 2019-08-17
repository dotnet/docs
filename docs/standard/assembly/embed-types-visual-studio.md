---
title: "Walkthrough: Embed types from managed assemblies in Visual Studio"
ms.date: 08/16/2019
ms.assetid: 55ed13c9-c5bb-4bc2-bcd8-0587eb568864
---

# Walkthrough: Embed types from managed assemblies in Visual Studio

If you embed type information from a strong-named managed assembly, you can loosely couple types in an application to achieve version independence. That is, your program can be written to use types from multiple versions of a managed library without having to be recompiled for each version.

Type embedding is frequently used with COM interop, such as an application that uses automation objects from Microsoft Office. Embedding type information enables the same build of a program to work with different versions of Microsoft Office on different computers. However, you can also use type embedding with a fully managed solution.

Type information can be embedded from an assembly under the following conditions: 

- The assembly exposes at least one public interface.

- The embedded interfaces are annotated with a `ComImport` attribute and a `Guid` attribute with a unique GUID.

- The assembly is annotated with the `ImportedFromTypeLib` attribute or the `PrimaryInteropAssembly` attribute, and an assembly-level `Guid` attribute. Visual C# and Visual Basic project templates include an assembly-level `Guid` attribute by default.

After you specify the public interfaces that can be embedded, you can create runtime classes that implement those interfaces. A client program can then embed the type information for those interfaces at design time by referencing the assembly that contains the public interfaces and setting the `Embed Interop Types` property of the reference to `True`. This is equivalent to using the command line compiler and referencing the assembly by using the `/link` compiler option. The client program can then load instances of your runtime objects typed as those interfaces. If you create a new version of your strong-named runtime assembly, the client program doesn't have to be recompiled with the updated runtime assembly. Instead, the client program continues to use whichever version of the runtime assembly is available to it, using the embedded type information for the public interfaces.

Because the primary function of type embedding is to support embedding of type information from COM interop assemblies, the following limitations apply when you embed type information in a fully-managed solution:

- Only attributes specific to COM interop are embedded. Other attributes are ignored.

- If a type uses generic parameters, and the type of the generic parameter is an embedded type, that type cannot be used across an assembly boundary. Examples of crossing an assembly boundary include calling a method from another assembly or deriving a type from a type defined in another assembly.

- Constants are not embedded.

- The <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> class does not support an embedded type as a key. You can implement your own dictionary type to support an embedded type as a key.

In this walkthrough, you:

- Create a strong-named assembly with a public interface containing type information that can be embedded.

- Create a strong-named runtime assembly that implements the public interface.

- Create a client program that embeds the type information from the public interface, and creates an instance of the class from the runtime assembly.

- Modify and rebuild the runtime assembly.

- Run the client program to see that it uses the new version of the runtime assembly without having to be recompiled.

[!INCLUDE[note_settings_general](../../../includes/note-settings-general-md.md)]

## Create an interface

First, create the type equivalence interface project. 

1. In Visual Studio, select **File** > **New** > **Project**.
   
1. In the **New Project** dialog box, in the left pane, select either **Visual C#** or **Visual Basic**, make sure that **Windows** is selected. Select **Class Library** in the **Templates** pane. In the **Name** box, type `TypeEquivalenceInterface`, and then select **OK**. The new project is created.
   
1. In **Solution Explorer**, right-click the *Class1.cs* or *Class1.vb* file, select **Rename**, and rename the file from *Class1* to *ISampleInterface*. Renaming the file will also rename the class to `ISampleInterface`. This class will represent the public interface for the class.
   
1. Right-click the **TypeEquivalenceInterface**, select **Properties**, and then select the **Build** tab [**Compile** tab]. Set the output path to a valid location on your development computer, such as *C:\TypeEquivalenceSample*. This location will also be used in a later step in this walkthrough.
   
1. While still editing the project properties, select the **Signing** tab. Select the **Sign the assembly** option. In the **Choose a strong name key file** list, select **\<New...>**. In the **Key file name** box, type *key.snk*. Clear the **Protect my key file with a password** check box, and then select **OK**.
   
1. Open the *ISampleInterface.cs* or *ISampleInterface.vb* file. Add the following code to the *ISampleInterface* class file to create the `ISampleInterface` interface.
   
   # [C#](#tab/csharp)
   ```csharp
   using System;
   using System.Runtime.InteropServices;
   
   namespace TypeEquivalenceInterface
   {
       [ComImport]
       [Guid("8DA56996-A151-4136-B474-32784559F6DF")]
       public interface ISampleInterface
       {
           void GetUserInput();
           string UserInput { get; }
       }
   }
   ```
   
   # [Visual Basic](#tab/vb)
   ```vb
   Imports System.Runtime.InteropServices
   
   <ComImport()>
   <Guid("8DA56996-A151-4136-B474-32784559F6DF")>
   Public Interface ISampleInterface
       Sub GetUserInput()
       ReadOnly Property UserInput As String
   End Interface
   ```
   
1. On the **Tools** menu, select **Create Guid**. In the **Create GUID** dialog box, select **Registry Format** and then select **Copy**. select **Exit**.
   
1. In the `Guid` attribute, delete the sample GUID and paste in the GUID that you copied from the **Create GUID** dialog box. Remove the braces ({}) from the copied GUID.
   
1. In **Solution Explorer**, expand the **Properties** folder. Double-click the AssemblyInfo.cs file. Add the following attribute to the file:
   
   ```csharp
    [assembly: ImportedFromTypeLib("")]
    ```

8. On the Project menu, select Show All Files.

9. In Solution Explorer, expand the My Project folder. Double-click the AssemblyInfo.vb. Add the following attribute to the file.

VB

Copy
<Assembly: ImportedFromTypeLib("")><Assembly: ImportedFromTypeLib("")>

     Save the file.

10. Save the project.

11. Right-click the TypeEquivalenceInterface project and select **Build**. The class library .dll file is compiled and saved to the specified build output path (for example, C:\TypeEquivalenceSample).

## Creating a Runtime Class

#### To create the type equivalence runtime project

1. In Visual Studio, on the **File** menu, point to **New** and then select **Project**.

2. In the **New Project** dialog box, in the **Project Types** pane, make sure that **Windows** is selected. Select **Class Library** in the **Templates** pane. In the **Name** box, type `TypeEquivalenceRuntime`, and then select **OK**. The new project is created.

3. In **Solution Explorer**, right-click the Class1.cs or Class1.vb file and select **Rename**. Rename the file from *Class1* to *SampleClass* and press ENTER. Renaming the file also renames the class to `SampleClass`. This class will implement the `ISampleInterface` interface.

4. Right-click the TypeEquivalenceRuntime project and select **Properties**. select the **Build** [**Compile**] tab. Set the output path to the same location you used in the TypeEquivalenceInterface project, for example, `C:\TypeEquivalenceSample`.

5. While still editing the project properties, select the **Signing** tab. Select the **Sign the assembly** option. In the **Choose a strong name key file** list, select **\<New...>**. In the **Key file name** box, type `key.snk`. Clear the **Protect my key file with a password** check box. select **OK**.

6. Right-click the TypeEquivalenceRuntime project and select **Add Reference**. select the **Browse** tab and browse to the output path folder. Select the TypeEquivalenceInterface.dll file and select **OK**.

7. In **Solution Explorer**, expand the **References** folder. Select the TypeEquivalenceInterface reference. In the Properties window for the TypeEquivalenceInterface reference, set the **Specific Version** property to **False**.

8. Add the following code to the SampleClass class file to create the SampleClass class.

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TypeEquivalenceInterface;

    namespace TypeEquivalenceRuntime
    {
        public class SampleClass : ISampleInterface
        {
            private string p_UserInput;
            public string UserInput { get { return p_UserInput; } }

            public void GetUserInput()
            {
                Console.WriteLine("Please enter a value:");
                p_UserInput = Console.ReadLine();
            }
        }
    }
    ```

Imports TypeEquivalenceInterface

Public Class SampleClass
    Implements ISampleInterface

    Private p_UserInput As String
    Public ReadOnly Property UserInput() As String Implements ISampleInterface.UserInput
        Get
            Return p_UserInput
        End Get
    End Property

    Public Sub GetUserInput() Implements ISampleInterface.GetUserInput
        Console.WriteLine("Please enter a value:")
        p_UserInput = Console.ReadLine()
    End Sub
End Class


9. Save the project.

10. Right-click the TypeEquivalenceRuntime project and select **Build**. The class library .dll file is compiled and saved to the specified build output path (for example, C:\TypeEquivalenceSample).

## Creating a Client Project

#### To create the type equivalence client project

1. In Visual Studio, on the **File** menu, point to **New** and then select **Project**.

2. In the **New Project** dialog box, in the **Project Types** pane, make sure that **Windows** is selected. Select **Console Application** in the **Templates** pane. In the **Name** box, type `TypeEquivalenceClient`, and then select **OK**. The new project is created.

3. Right-click the TypeEquivalenceClient project and select **Properties**. select the **Build** [**Compile**] tab. Set the output path to the same location you used in the TypeEquivalenceInterface project, for example, `C:\TypeEquivalenceSample`.

4. Right-click the TypeEquivalenceClient project and select **Add Reference**. select the **Browse** tab and browse to the output path folder. Select the TypeEquivalenceInterface.dll file (not the TypeEquivalenceRuntime.dll) and select **OK**.

[On the Project menu, select Show All Files.]

5. In **Solution Explorer**, expand the **References** folder. Select the TypeEquivalenceInterface reference. In the Properties window for the TypeEquivalenceInterface reference, set the **Embed Interop Types** property to **True**.

6. Add the following code to the Program.cs file or the Module1.vb file to create the client program.

    ```csharp
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TypeEquivalenceInterface;
    using System.Reflection;

    namespace TypeEquivalenceClient
    {
        class Program
        {
            static void Main(string[] args)
            {
                Assembly sampleAssembly = Assembly.Load("TypeEquivalenceRuntime");
                ISampleInterface sampleClass =
                    (ISampleInterface)sampleAssembly.CreateInstance("TypeEquivalenceRuntime.SampleClass");
                sampleClass.GetUserInput();
                Console.WriteLine(sampleClass.UserInput);
                Console.WriteLine(sampleAssembly.GetName().Version.ToString());
                Console.ReadLine();
            }
        }
    }
    ```

Imports TypeEquivalenceInterface
Imports System.Reflection

Module Module1

    Sub Main()
        Dim sampleAssembly = Assembly.Load("TypeEquivalenceRuntime")
        Dim sampleClass As ISampleInterface = CType( _
            sampleAssembly.CreateInstance("TypeEquivalenceRuntime.SampleClass"), ISampleInterface)
        sampleClass.GetUserInput()
        Console.WriteLine(sampleClass.UserInput)
        Console.WriteLine(sampleAssembly.GetName().Version)
        Console.ReadLine()
    End Sub

End Module

7. Press CTRL+F5 to build and run the program.

## Modifying the Interface

#### To modify the interface

1. In Visual Studio, on the **File** menu, point to **Open**, and then select **Project/Solution**.

2. In the **Open Project** dialog box, right-click the TypeEquivalenceInterface project, and then select **Properties**. select the **Application** tab. select the **Assembly Information** button. Change the **Assembly Version** and **File Version** values to `2.0.0.0`.

3. Open the SampleInterface.cs or SampleInterface.vb file. Add the following line of code to the ISampleInterface interface.

    ```csharp
    DateTime GetDate();
    ```

Function GetDate() As Date

    Save the file.

4. Save the project.

5. Right-click the TypeEquivalenceInterface project and select **Build**. A new version of the class library .dll file is compiled and saved in the specified build output path (for example, C:\TypeEquivalenceSample).

## Modifying the Runtime Class

#### To modify the runtime class

1. In Visual Studio, on the **File** menu, point to **Open**, and then select **Project/Solution**.

2. In the **Open Project** dialog box, right-click the TypeEquivalenceRuntime project and select **Properties**. select the **Application** tab. select the **Assembly Information** button. Change the **Assembly Version** and **File Version** values to `2.0.0.0`.

3. Open the SampleClass.cs or SampleClass.vb file. Add the following lines of code to the SampleClass class.

    ```csharp
    public DateTime GetDate()
    {
        return DateTime.Now;
    }
    ```

Public Function GetDate() As DateTime Implements ISampleInterface.GetDate
    Return Now
End Function


    Save the file.

4. Save the project.

5. Right-click the TypeEquivalenceRuntime project and select **Build**. An updated version of the class library .dll file is compiled and saved in the previously specified build output path (for example, C:\TypeEquivalenceSample).

6. In File Explorer, open the output path folder (for example, C:\TypeEquivalenceSample). Double-click the TypeEquivalenceClient.exe to run the program. The program will reflect the new version of the TypeEquivalenceRuntime assembly without having been recompiled.

## See also

- [/link (C# Compiler Options)](../../csharp/language-reference/compiler-options/link-compiler-option.md)
- [/link (Visual Basic)](../../../../visual-basic/reference/command-line-compiler/link.md)
- [C# Programming Guide](../../csharp/programming-guide/index.md)
- [Programming Concepts (Visual Basic)](../../../../visual-basic/programming-guide/concepts/index.md)
- [Program with assemblies](program.md)
- [Assemblies in .NET](index.md)
