---
title: "Walkthrough: Embed types from managed assemblies in Visual Studio"
ms.date: 08/19/2019
ms.assetid: 55ed13c9-c5bb-4bc2-bcd8-0587eb568864
dev_langs: 
  - "csharp"
  - "vb"
---

# Walkthrough: Embed types from managed assemblies in Visual Studio

If you embed type information from a strong-named managed assembly, you can loosely couple types in an application to achieve version independence. That is, your program can be written to use types from any version of a managed library without having to be recompiled for each new version.

Type embedding is frequently used with COM interop, such as an application that uses automation objects from Microsoft Office. Embedding type information enables the same build of a program to work with different versions of Microsoft Office on different computers. However, you can also use type embedding with fully managed solutions.

After you specify the public interfaces that can be embedded, you create runtime classes that implement those interfaces. A client program can embed the type information for the interfaces at design time by referencing the assembly that contains the public interfaces and setting the `Embed Interop Types` property of the reference to `True`. The client program can then load instances of the runtime objects typed as those interfaces. This is equivalent to using the command line compiler and referencing the assembly by using the `/link` compiler option. 

If you create a new version of your strong-named runtime assembly, the client program doesn't have to be recompiled. The client program continues to use whichever version of the runtime assembly is available to it, using the embedded type information for the public interfaces.

In this walkthrough, you:

1. Create a strong-named assembly with a public interface containing type information that can be embedded.
1. Create a strong-named runtime assembly that implements the public interface.
1. Create a client program that embeds the type information from the public interface and creates an instance of the class from the runtime assembly.
1. Modify and rebuild the runtime assembly.
1. Run the client program to see that it uses the new version of the runtime assembly without having to be recompiled.

[!INCLUDE[note_settings_general](../../../includes/note-settings-general-md.md)]

## Conditions and limitations

You can embed type information from an assembly under the following conditions: 

- The assembly exposes at least one public interface.
- The embedded interfaces are annotated with `ComImport` attributes and `Guid` attributes with unique GUIDs.
- The assembly is annotated with the `ImportedFromTypeLib` attribute or the `PrimaryInteropAssembly` attribute, and an assembly-level `Guid` attribute. The Visual C# and Visual Basic project templates include an assembly-level `Guid` attribute by default.

Because the primary function of type embedding is to support COM interop assemblies, the following limitations apply when you embed type information in a fully-managed solution:

- Only attributes specific to COM interop are embedded. Other attributes are ignored.
- If a type uses generic parameters, and the type of the generic parameter is an embedded type, that type cannot be used across an assembly boundary. Examples of crossing an assembly boundary include calling a method from another assembly or deriving a type from a type defined in another assembly.
- Constants are not embedded.
- The <xref:System.Collections.Generic.Dictionary%602?displayProperty=nameWithType> class does not support an embedded type as a key. You can implement your own dictionary type to support an embedded type as a key.

## Create an interface

The first step is to create the type equivalence interface assembly. 

1. In Visual Studio, select **File** > **New** > **Project**.
   
1. In the **Create a new project** dialog box, type *class library* in the **Search for templates** box. Select either the C# or VB **Class Library (.NET Framework)** template from the list, and then select **Next**. 
   
1. In the **Configure your new project** dialog box, under **Project name**, type *TypeEquivalenceInterface*, and then select **Create**. The new project is created.
   
1. In **Solution Explorer**, right-click the *Class1.cs* or *Class1.vb* file, select **Rename**, and rename the file from *Class1* to *ISampleInterface*. Respond **Yes** to the prompt to also rename the class to `ISampleInterface`. This class represents the public interface for the class.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceInterface** project, and then select **Properties**. 
   
1. Select **Build** on the left pane of the **Properties** screen, and set the **Output path** to a location on your computer, such as *C:\TypeEquivalenceSample*. You use the same location throughout this walkthrough. 
   
1. Select **Signing** on the left pane of the **Properties** screen, and then select the **Sign the assembly** check box. In the dropdown for **Choose a strong name key file**, select **New**. 
   
1. In the **Create Strong Name Key** dialog, under **Key file name**, type *key.snk*. Deselect the **Protect my key file with a password** check box, and then select **OK**.
   
1. Open the *ISampleInterface* class file in the code editor, and replace its contents with the following code to create the `ISampleInterface` interface:
   
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
   
   ```vb
   Imports System.Runtime.InteropServices
   
   <ComImport()>
   <Guid("8DA56996-A151-4136-B474-32784559F6DF")>
   Public Interface ISampleInterface
       Sub GetUserInput()
       ReadOnly Property UserInput As String
   End Interface
   ```
   
1. On the **Tools** menu, select **Create Guid**, and in the **Create GUID** dialog box, select **Registry Format**. Select **Copy**, and then select **Exit**.
   
1. In the `Guid` attribute of your code, replace the sample GUID with the GUID you copied, and remove the braces (**{ }**).
   
1. In **Solution Explorer**, expand the **Properties** folder and select the *AssemblyInfo.cs* or *AssemblyInfo.vb* file. In the code editor, add the following attribute to the file:
   
   ```csharp
   [assembly: ImportedFromTypeLib("")]
   ```
   
   ```vb
   <Assembly: ImportedFromTypeLib("")>
   ```
   
1. Select **File** > **Save All** or press **Ctrl**+**Shift**+**S** to save the files and project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceInterface** project and select **Build**. The class library DLL file is compiled and saved to the specified build output path, for example *C:\TypeEquivalenceSample*.

## Create a runtime class

Next, create the type equivalence runtime class.

1. In Visual Studio, select **File** > **New** > **Project**.
   
1. In the **Create a new project** dialog box, type *class library* in the **Search for templates** box. Select either the C# or VB **Class Library (.NET Framework)** template from the list, and then select **Next**. 
   
1. In the **Configure your new project** dialog box, under **Project name**, type *TypeEquivalenceRuntime*, and then select **Create**. The new project is created.
   
1. In **Solution Explorer**, right-click the *Class1.cs* or *Class1.vb* file, select **Rename**, and rename the file from *Class1* to *SampleClass*. Respond **Yes** to the prompt to also rename the class to `SampleClass`. This class implements the `ISampleInterface` interface.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceInterface** project and select **Properties**. 
   
1. Select **Build** on the left pane of the **Properties** screen, and then set the **Output path** to the same location you used for the TypeEquivalenceInterface project, for example, *C:\TypeEquivalenceSample*.
   
1. Select **Signing** on the left pane of the **Properties** screen, and then select the **Sign the assembly** check box. In the dropdown for **Choose a strong name key file**, select **New**. 
   
1. In the **Create Strong Name Key** dialog, under **Key file name**, type *key.snk*. Deselect the **Protect my key file with a password** check box, and then select **OK**.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceRuntime** project and select **Add** > **Reference**. 
   
1. In the **Reference Manager** dialog, select **Browse** and browse to the output path folder. Select the *TypeEquivalenceInterface.dll* file, select **Add**, and then select **OK**.
   
1. In **Solution Explorer**, expand the **References** folder and select the **TypeEquivalenceInterface** reference. In the **Properties** pane, set **Specific Version** to **False** if it is not already.
   
1. Open the *SampleClass* class file in the code editor, and replace its contents with the following code to create the `SampleClass` class:
   
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
   
   ```vb
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
   ```
   
1. Select **File** > **Save All** or press **Ctrl**+**Shift**+**S** to save the files and project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceRuntime** project and select **Build**. The class library DLL file is compiled and saved to the specified build output path.

## Create a client project

Finally, create a type equivalence client program that references the interface assembly.

1. In Visual Studio, select **File** > **New** > **Project**.
   
1. In the **Create a new project** dialog box, type *console* in the **Search for templates** box. Select either the C# or VB **Console App (.NET Framework)** template from the list, and then select **Next**. 
   
1. In the **Configure your new project** dialog box, under **Project name**, type *TypeEquivalenceClient*, and then select **Create**. The new project is created.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceClient** project and select **Properties**. 
   
1. Select **Build** on the left pane of the **Properties** screen, and then set the **Output path** to the same location you used for the TypeEquivalenceInterface project, for example, *C:\TypeEquivalenceSample*.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceClient** project and select **Add** > **Reference**. 
   
1. In the **Reference Manager** dialog, if the **TypeEquivalenceInterface.dll** file is already listed, select it. If not, select **Browse**, browse to the output path folder, select the *TypeEquivalenceInterface.dll* file (not the *TypeEquivalenceRuntime.dll*), and select **Add**. Select **OK**.
   
1. In **Solution Explorer**, expand the **References** folder and select the **TypeEquivalenceInterface** reference. In the **Properties** pane, set **Embed Interop Types** to **True**.
   
1. Open the *Program.cs* or *Module1.vb* file in the code editor, and replace its contents with the following code to create the client program:
   
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
   
   ```vb
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
   ```
   
1. Select **File** > **Save All** or press **Ctrl**+**Shift**+**S** to save the files and project.
   
1. Press **Ctrl**+**F5** to build and run the program. Note that the console output returns the assembly version **1.0.0.0**. 
   
## Modify the interface

Now, modify the interface assembly, and change its version. 

1. In Visual Studio, select **File** > **Open** > **Project/Solution**, and open the **TypeEquivalenceInterface** project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceInterface** project and select **Properties**. 
   
1. Select **Application** on the left pane of the **Properties** screen, and then select **Assembly Information**. 
   
1. In the **Assembly Information** dialog box, change the **Assembly version** and **File version** values to *2.0.0.0*, and then select **OK**.
   
1. Open the *SampleInterface.cs* or *SampleInterface.vb* file, and add the following line of code to the `ISampleInterface` interface:
   
   ```csharp
   DateTime GetDate();
   ```
   
   ```vb
   Function GetDate() As Date
   ```
   
1. Select **File** > **Save All** or press **Ctrl**+**Shift**+**S** to save the files and project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceInterface** project and select **Build**. A new version of the class library DLL file is compiled and saved to the build output path.

## Modify the runtime class

Also modify the runtime class and update its version. 

1. In Visual Studio, select **File** > **Open** > **Project/Solution**, and open the **TypeEquivalenceRuntime** project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceRuntime** project and select **Properties**. 
   
1. Select **Application** on the left pane of the **Properties** screen, and then select **Assembly Information**. 
   
1. In the **Assembly Information** dialog box, change the **Assembly version** and **File version** values to *2.0.0.0*, and then select **OK**.
   
1. Open the *SampleClass.cs* or *SampleClass.vb* file, and add the following code to the `SampleClass` class:
   
   ```csharp
    public DateTime GetDate()
    {
        return DateTime.Now;
    }
   ```
   
   ```vb
   Public Function GetDate() As DateTime Implements ISampleInterface.GetDate
       Return Now
   End Function
   ```
   
1. Select **File** > **Save All** or press **Ctrl**+**Shift**+**S** to save the files and project.
   
1. In **Solution Explorer**, right-click the **TypeEquivalenceRuntime** project and select **Build**. A new version of the class library DLL file is compiled and saved to the build output path.

## Run the updated client program 

Go to the build output folder location and run *TypeEquivalenceClient.exe*. Note that the console output now reflects the new version of the `TypeEquivalenceRuntime` assembly, *2.0.0.0*, without the program being recompiled.

## See also

- [-link (C# Compiler Options)](../../csharp/language-reference/compiler-options/link-compiler-option.md)
- [-link (Visual Basic)](../../visual-basic/reference/command-line-compiler/link.md)
- [C# programming guide](../../csharp/programming-guide/index.md)
- [Programming concepts (Visual Basic)](../../visual-basic/programming-guide/concepts/index.md)
- [Program with assemblies](program.md)
- [Assemblies in .NET](index.md)
