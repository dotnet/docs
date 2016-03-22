# Best practices for exceptions

A well-designed app handles exceptions and errors to prevent app crashes. This article describes best practices for handling and creating exceptions.

## Handle exceptions

The following list contains some general guidelines for handling exceptions in your app.

- Use exception handling code (**try**/**catch** blocks) appropriately. You can also programmatically check for a condition that is likely to occur without using exception handling.

  **Programmatic checks**. The following example uses an **if** statement to check whether a connection is closed. If it isn't, the example closes the connection instead of throwing an exception.

  C#
  ```
  if (conn.State != ConnectionState.Closed)
  {
      conn.Close();
  }
  ```

  C++
  ```
  if (conn->State != ConnectionState::Closed)
  {
      conn->Close();
  }
  ```

  Visual Basic
  ```
  If conn.State <> ConnectionState.Closed Then
      conn.Close()
  End IF
  ```

  **Exception handling**. The following example uses a **try**/**catch** block to check the connection and to throw an exception if the connection is not closed.

  C#
  ```
  Try
  conn.Close()
Catch ex As InvalidOperationException
  Console.WriteLine(ex.GetType().FullName)
  Console.WriteLine(ex.Message)
End Try
  ```

  C++
  ```
  try
{
  conn->Close();
}
catch (InvalidOperationException^ ex)
{
  Console::WriteLine(ex->GetType()->FullName);
  Console::WriteLine(ex->Message);
}
  ```

  Visual Basic
  ```
  Try
  conn.Close()
Catch ex As InvalidOperationException
  Console.WriteLine(ex.GetType().FullName)
  Console.WriteLine(ex.Message)
End Try
  ```

  The method you choose depends on how often you expect the event to occur.

  - Use exception handling if the event doesn't occur very often, that is, if the event is truly exceptional and indicates an error (such as an unexpected end-of-file). When you use exception handling, less code is executed in normal conditions.

  - Use the programmatic method to check for errors if the event happens routinely and could be considered part of normal execution. When you check for errors programmatically, more code is executed if an exception occurs.

- Use **try**/**catch** blocks around code that can potentially generate an exception, and use a **finally** block to clean up resources, if necessary. This way, the **try** statement generates the exception, the **catch** statement handles the exception, and the finally statement closes or deallocates resources whether or not an exception occurs.

- In **catch** blocks, always order exceptions from the most specific to the least specific. This technique handles the specific exception before it is passed to a more general **catch** block.

## Creating and raising exceptions

The following list contains guidelines for creating your own exceptions and when they should be raised. For a more details, see [Design Guidelines for Exceptions](https://msdn.microsoft.com/library/ms229014).

- Design classes so that an exception is never thrown in normal use. For example, a [FileStream](https://msdn.microsoft.com/library/system.io.filestream) class provides methods that help determine whether the end of the file has been reached. This avoids the exception that is thrown if you read past the end of the file. The following example shows how to read to the end of the file.

  C#
  ```
  class FileRead
  {
      public void ReadAll(FileStream fileToRead)
      {
          // This if statement is optional
          // as it is very unlikely that
          // the stream would ever be null.
          if (fileToRead == null)
          {
              throw new System.ArgumentNullException();
          }

          int b;

          // Set the stream position to the beginning of the file.
          fileToRead.Seek(0, SeekOrigin.Begin);

          // Read each byte to the end of the file.
          for (int i = 0; i < fileToRead.Length; i++)
          {
              b = fileToRead.ReadByte();
              Console.Write(b.ToString());
              // Or do something else with the byte.
          }
      }
  }
  ```

  C++
  ```
  class FileRead
  {
  public:
      void ReadAll(FileStream^ fileToRead)
      {
          // This if statement is optional
          // as it is very unlikely that
          // the stream would ever be null.
          if (fileToRead == nullptr)
          {
              throw gcnew System::ArgumentNullException();
          }

          int b;

          // Set the stream position to the beginning of the file.
          fileToRead->Seek(0, SeekOrigin::Begin);

          // Read each byte to the end of the file.
          for (int i = 0; i < fileToRead->Length; i++)
          {
              b = fileToRead->ReadByte();
              Console::Write(b.ToString());
              // Or do something else with the byte.
          }
      }
  };
  ```

  Visual Basic
  ```
  Class FileRead
      Public Sub ReadAll(fileToRead As FileStream)
          ' This if statement is optional
          ' as it is very unlikely that
          ' the stream would ever be null.
          If fileToRead Is Nothing Then
              Throw New System.ArgumentNullException()
          End If

          Dim b As Integer

          ' Set the stream position to the beginning of the file.
          fileToRead.Seek(0, SeekOrigin.Begin)

          ' Read each byte to the end of the file.
          For i As Integer = 0 To fileToRead.Length - 1
              b = fileToRead.ReadByte()
              Console.Write(b.ToString())
              ' Or do something else with the byte.
          Next i
      End Sub
  End Class
  ```

- Throw exceptions instead of returning an error code or HRESULT.

- Return null for extremely common error cases instead of throwing an exception. An extremely common error case can be considered normal flow of control. By returning null in these cases, you minimize the performance impact to an app.

- In most cases, use the predefined .NET Framework exception types. Introduce a new exception class only when a predefined one doesn't apply.

- Throw an [InvalidOperationException](https://msdn.microsoft.com/library/system.invalidoperationexception) exception if a property set or method call is not appropriate given the object's current state.

- Throw an [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception) exception or a class derived from [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception) if invalid parameters are passed.

- For most apps, derive custom exceptions from the [Exception](https://msdn.microsoft.com/library/system.exception) class. Deriving from the [ApplicationException](https://msdn.microsoft.com/library/system.applicationexception) class doesn't add significant value.

- End exception class names with the word "Exception". For example:

  C#
  ```
  public class MyFileNotFoundException : Exception
  {
  }
  ```

  C++
  ```
  public ref class MyFileNotFoundException : public Exception
  {
  };
  ```

  Visual Basic
  ```
  Public Class MyFileNotFoundException
      Inherits Exception
  End Class
  ```

- In C# and C++, use at least the three common constructors when creating your own exception classes: the default constructor, a constructor that takes a string message, and a constructor that takes a string message and an inner exception. For an example, see How to: Create User-Defined Exceptions.

  - [Exception()](https://msdn.microsoft.com/library/9f9b3wha), which uses default values.

  - [Exception(String)](https://msdn.microsoft.com/library/48ca3hhw), which accepts a string message.

  - [Exception(String, Exception)](https://msdn.microsoft.com/library/804f22sf), which accepts a string message and an inner exception.

- When you create user-defined exceptions, you must ensure that the metadata for the exceptions is available to code that is executing remotely, including when exceptions occur across app domains. For example, suppose App Domain A creates App Domain B, which executes code that throws an exception. For App Domain A to properly catch and handle the exception, it must be able to find the assembly that contains the exception thrown by App Domain B. If App Domain B throws an exception that is contained in an assembly under its application base, but not under App Domain A's application base, App Domain A will not be able to find the exception, and the common language runtime will throw a [FileNotFoundException](https://msdn.microsoft.com/library/system.io.filenotfoundexception) exception. To avoid this situation, you can deploy the assembly that contains the exception information in two ways:

  - Put the assembly into a common application base shared by both app domains.

    \- or -

  - If the domains do not share a common application base, sign the assembly that contains the exception information with a strong name and deploy the assembly into the global assembly cache.

- Include a localized description string in every exception. The error message that the user sees is derived from the description string of the exception that was thrown, and not from the exception class.

- Use grammatically correct error messages, including ending punctuation. Each sentence in a description string of an exception should end in a period. For example, "The log table has overflowed.” would be an appropriate description string.

- Provide [Exception](https://msdn.microsoft.com/library/system.exception) properties for programmatic access. Provide additional properties for an exception (in addition to the description string) only when there's a programmatic scenario where the additional information is useful. For example, the [FileNotFoundException](https://msdn.microsoft.com/library/system.io.filenotfoundexception) provides the [FileName](https://msdn.microsoft.com/library/system.io.filenotfoundexception.filename) property.

- The stack trace begins at the statement where the exception is thrown and ends at the **catch** statement that catches the exception. Be aware of this fact when deciding where to place a **throw** statement.

- Use exception builder methods. It is common for a class to throw the same exception from different places in its implementation. To avoid excessive code, use helper methods that create the exception and return it. For example:

  C#
  ```
  Class FileReader
      Private fileName As String

      Public Sub New(path As String)
          fileName = path
      End Sub

      Public Function Read(bytes As Integer) As Byte()
          Dim results() As Byte = FileUtils.ReadFromFile(fileName, bytes)
          If results Is Nothing
              Throw NewFileIOException()
          End If
          Return results
      End Function

      Function NewFileIOException() As FileReaderException
          Dim description As String = "My NewFileIOException Description"

          Return New FileReaderException(description)
      End Function
  End Class
  ```

  C++
  ```
  ref class FileReader
  {
  private:
      String^ fileName;

  public:
      FileReader(String^ path)
      {
          fileName = path;
      }

      array<Byte>^ Read(int bytes)
      {
          array<Byte>^ results = FileUtils::ReadFromFile(fileName, bytes);
          if (results == nullptr)
          {
              throw NewFileIOException();
          }
          return results;
      }

      FileReaderException^ NewFileIOException()
      {
          String^ description = "My NewFileIOException Description";

          return gcnew FileReaderException(description);
      }
  };
  ```

  Visual Basic
  ```
  Class FileReader
      Private fileName As String

      Public Sub New(path As String)
          fileName = path
      End Sub

      Public Function Read(bytes As Integer) As Byte()
          Dim results() As Byte = FileUtils.ReadFromFile(fileName, bytes)
          If results Is Nothing
              Throw NewFileIOException()
          End If
          Return results
      End Function

      Function NewFileIOException() As FileReaderException
          Dim description As String = "My NewFileIOException Description"

          Return New FileReaderException(description)
      End Function
  End Class
  ```

  Alternatively, use the exception's constructor to build the exception. This is more appropriate for global exception classes such as [ArgumentException](https://msdn.microsoft.com/library/system.argumentexception).

- Clean up intermediate results when throwing an exception. Callers should be able to assume that there are no side effects when an exception is thrown from a method.
