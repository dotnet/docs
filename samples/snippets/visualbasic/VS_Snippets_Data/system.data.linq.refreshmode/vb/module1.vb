Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Reflection

' Imports System.Linq


Module Module1

    Sub Main()
        ' <Snippet1>
        Dim db As New Northwnd("...")

        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As ChangeConflictException
            Console.WriteLine(ex.Message)

            For Each occ As ObjectChangeConflict In db.ChangeConflicts
                ' All database values overwrite current values.
                occ.Resolve(Data.Linq.RefreshMode.OverwriteCurrentValues)
            Next

        End Try
        ' </Snippet1>


        ' <Snippet2>
        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As ChangeConflictException
            Console.WriteLine(ex.Message)

            For Each occ As ObjectChangeConflict In db.ChangeConflicts
                ' No database values are merged into current.
                occ.Resolve(Data.Linq.RefreshMode.KeepCurrentValues)
            Next

        End Try
        ' </Snippet2>

        ' <Snippet3>
        Try
            db.SubmitChanges(ConflictMode.ContinueOnConflict)

        Catch ex As ChangeConflictException
            Console.WriteLine(ex.Message)

            For Each occ As ObjectChangeConflict In db.ChangeConflicts
                ' Automerge database values into current for members
                ' that client has not modified.
                occ.Resolve(Data.Linq.RefreshMode.KeepChanges)
            Next

        End Try

        ' Submit succeeds on second try.
        db.SubmitChanges(ConflictMode.FailOnFirstConflict)
        ' </Snippet3>


        Console.ReadLine()

    End Sub



End Module
