            ' Display results of PermissionSet.GetEnumerator.
            Dim psEnumerator As IEnumerator = ps1.GetEnumerator()
            While psEnumerator.MoveNext()
                Console.WriteLine(psEnumerator.Current)
            End While