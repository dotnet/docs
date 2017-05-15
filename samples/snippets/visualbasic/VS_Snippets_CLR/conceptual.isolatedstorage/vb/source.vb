'<snippet1>
Imports System.IO
Imports System.IO.IsolatedStorage

Module Module1
    Sub Main()
        Using isoStore As IsolatedStorageFile = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or IsolatedStorageScope.Assembly Or IsolatedStorageScope.Domain, Nothing, Nothing)

            isoStore.CreateDirectory("TopLevelDirectory")
            isoStore.CreateDirectory("TopLevelDirectory/SecondLevel")
            isoStore.CreateDirectory("AnotherTopLevelDirectory/InsideDirectory")
            Console.WriteLine("Created directories.")

            isoStore.CreateFile("InTheRoot.txt")
            Console.WriteLine("Created a new file in the root.")

            isoStore.CreateFile("AnotherTopLevelDirectory/InsideDirectory/HereIAm.txt")
            Console.WriteLine("Created a new file in the InsideDirectory.")
        End Using
    End Sub
End Module

'</snippet1>