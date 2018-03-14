'<snippet1>
Imports System

Namespace ReRegisterForFinalizeExample
    Class MyMainClass
        Shared Sub Main()
            'Create a MyFinalizeObject.
            Dim mfo As New MyFinalizeObject()

            'Release the reference to mfo.
            mfo = Nothing

            'Force a garbage collection.
            GC.Collect()

            'At this point mfo will have gone through the first Finalize.
            'There should now be a reference to mfo in the static
            'MyFinalizeObject.currentInstance field.  Setting this value
            'to null and forcing another garbage collection will now
            'cause the object to Finalize permanently.
            MyFinalizeObject.currentInstance = Nothing
            GC.Collect()
        End Sub
    End Class

    Class MyFinalizeObject
        Public Shared currentInstance As MyFinalizeObject = Nothing
        Private hasFinalized As Boolean = False

        Protected Overrides Sub Finalize()
            If hasFinalized = False Then
                Console.WriteLine("First finalization")

                'Put this object back into a root by creating
                'a reference to it.
                MyFinalizeObject.currentInstance = Me

                'Indicate that this instance has finalized once.
                hasFinalized = True

                'Place a reference to this object back in the
                'finalization queue.
                GC.ReRegisterForFinalize(Me)
            Else
                Console.WriteLine("Second finalization")
            End If
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
'</snippet1>