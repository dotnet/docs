'<Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.InteropServices



Module Win32
    ' The SHAutoComplete function allows you 
    ' to add auto-compete functionality to your
    ' Windows Forms text boxes. In .NET Framework 
    ' 1.1 and earlier, you can use SHAutoComplete.
    ' Later versions have this ability built in without
    ' requiring platform invoke.
    ' See the MSDN documentation of the 
    ' SHAutoComplete function for the 
    ' complete set of flags.

    Public Enum SHAutoCompleteFlags
        SHACF_DEFAULT = &H1
        SHACF_FILESYSTEM = &H1
    End Enum 


    ' Use the DllImportAttribute to import the SHAutoComplete function. 
    ' Set the PreserveSig to false to specify exception errors.
    <DllImportAttribute("shlwapi.dll", EntryPoint:="SHAutoComplete", ExactSpelling:=True, PreserveSig:=False)> _
    Public Sub SHAutoComplete(ByVal hwndEdit As IntPtr, ByVal dwFlags As SHAutoCompleteFlags)
    End Sub


    ' Use the DllImportAttribute to import the SHAutoComplete function. 
    ' Use the default value of the PreserveSig field to specify HRESULT errors.
    <DllImportAttribute("shlwapi.dll", EntryPoint:="SHAutoComplete", ExactSpelling:=True)> _
    Public Function SHAutoCompleteHRESULT(ByVal hwndEdit As IntPtr, ByVal dwFlags As SHAutoCompleteFlags) As Integer
    End Function
End Module



Module Program

    Sub Main()
        Run()

    End Sub


    Sub Run()
        ' Create a null (nothing in Visual Basic) IntPtr
        ' to pass to the SHAutoComplete method.  Doing so
        ' creates a failure and demonstrates the two ways  
        ' that the PreserveSig property allows you to handle 
        ' failures.  
        ' Normally, you would pass a handle to a managed
        ' Windows Forms text box.
        Dim iPtr As New IntPtr(0)

        ' Call the SHAutoComplete function using exceptions.
        Try
            Console.WriteLine("Calling the SHAutoComplete method with the PreserveSig field set to false.")

            Win32.SHAutoComplete(iPtr,Win32.SHAutoCompleteFlags.SHACF_DEFAULT)
        Catch e As Exception
            Console.WriteLine("Exception handled: " + e.Message)
        End Try

        Console.WriteLine("Calling the SHAutoComplete method with the PreserveSig field set to true.")

        ' Call the SHAutoComplete function using HRESULTS.
        Dim HRESULT As Integer = Win32.SHAutoCompleteHRESULT(iPtr,Win32.SHAutoCompleteFlags.SHACF_DEFAULT)

        Console.WriteLine("HRESULT handled: " + HRESULT.ToString())

    End Sub
End Module
'</Snippet1>