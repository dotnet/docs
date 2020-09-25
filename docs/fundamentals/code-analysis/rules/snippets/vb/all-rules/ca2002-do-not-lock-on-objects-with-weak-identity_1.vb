Imports System
Imports System.IO
Imports System.Reflection
Imports System.Threading

Namespace ca2002

    Class WeakIdentities

        Sub SyncLockOnWeakId1()

            SyncLock GetType(WeakIdentities)
            End SyncLock

        End Sub

        Sub SyncLockOnWeakId2()

            Dim stream As New MemoryStream()
            SyncLock stream
            End SyncLock

        End Sub

        Sub SyncLockOnWeakId3()

            SyncLock "string"
            End SyncLock

        End Sub

        Sub SyncLockOnWeakId4()

            Dim member As MemberInfo =
            Me.GetType().GetMember("SyncLockOnWeakId1")(0)
            SyncLock member
            End SyncLock

        End Sub

        Sub SyncLockOnWeakId5()

            Dim outOfMemory As New OutOfMemoryException()
            SyncLock outOfMemory
            End SyncLock

        End Sub

    End Class

End Namespace
