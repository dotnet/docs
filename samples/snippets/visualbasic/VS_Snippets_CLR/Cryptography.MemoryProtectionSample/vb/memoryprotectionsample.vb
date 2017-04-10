'<SNIPPET1>
Imports System
Imports System.Security.Cryptography



Public Class MemoryProtectionSample

    Public Shared Sub Main()
        ' Create the original data to be encrypted (The data length should be a multiple of 16).
        Dim secret As Byte() = {1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4}

        ' Encrypt the data in memory. The result is stored in the same same array as the original data.
        ProtectedMemory.Protect(secret, MemoryProtectionScope.SameLogon)

        ' Decrypt the data in memory and store in the original array.
        ProtectedMemory.Unprotect(secret, MemoryProtectionScope.SameLogon)

    End Sub
End Class
'</SNIPPET1>