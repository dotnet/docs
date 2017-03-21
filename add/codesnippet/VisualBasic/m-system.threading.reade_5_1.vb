' The complete code is located in the ReaderWriterLock class topic.
Imports System.Threading

Public Module Example
   Private rwl As New ReaderWriterLock()
   ' Define the shared resource protected by the ReaderWriterLock.
   Private resource As Integer = 0