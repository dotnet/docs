'SpinWait conceptual topic in dv_fxadvance
'<snippet05>
Imports System.Threading

Module SpinWaitDemo


    Public Class LockFreeStack(Of T)
        Private m_head As Node

        Private Class Node
            Public [Next] As Node
            Public Value As T
        End Class

        Public Sub Push(ByVal item As T)
            Dim spin As New SpinWait()
            Dim head As Node, node As New Node With {.Value = item}

            While True
                Thread.MemoryBarrier()
                head = m_head
                node.Next = head
                If Interlocked.CompareExchange(m_head, node, head) Is head Then Exit While
                spin.SpinOnce()
            End While
        End Sub

        Public Function TryPop(ByRef result As T) As Boolean
            result = CType(Nothing, T)
            Dim spin As New SpinWait()

            Dim head As Node
            While True
                Thread.MemoryBarrier()
                head = m_head
                If head Is Nothing Then Return False
                If Interlocked.CompareExchange(m_head, head.Next, head) Is head Then
                    result = head.Value
                    Return True
                End If
                spin.SpinOnce()
            End While
        End Function
    End Class


End Module
'</snippet05>
