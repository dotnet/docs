'<Snippet1>
' This example shows how a named mutex is used to signal between
' processes or threads.
' Run this program from two (or more) command windows. Each process
' creates a Mutex object that represents the named mutex "MyMutex".
' The named mutex is a system object whose lifetime is bounded by the
' lifetimes of the Mutex objects that represent it. The named mutex
' is created when the first process creates its local Mutex; in this
' example, the named mutex is owned by the first process. The named 
' mutex is destroyed when all the Mutex objects that represent it
' have been released. 
' The second process (and any subsequent process) waits for earlier
' processes to release the named mutex.

Imports System
Imports System.Threading

Public Class Test
   
   <MTAThread> _
   Public Shared Sub Main()
      ' Set this variable to false if you do not want to request 
      ' initial ownership of the named mutex.
      Dim requestInitialOwnership As Boolean = True
      Dim mutexWasCreated As Boolean
      
      ' Request initial ownership of the named mutex by passing
      ' true for the first parameter. Only one system object named 
      ' "MyMutex" can exist; the local Mutex object represents 
      ' this system object. If "MyMutex" is created by this call,
      ' then mutexWasCreated contains true; otherwise, it contains
      ' false.
      Dim m As New Mutex(requestInitialOwnership, "MyMutex", _
          mutexWasCreated)
      
      ' This thread owns the mutex only if it both requested 
      ' initial ownership and created the named mutex. Otherwise,
      ' it can request the named mutex by calling WaitOne.
      If Not (requestInitialOwnership And mutexWasCreated) Then
         Console.WriteLine("Waiting for the named mutex.")
         m.WaitOne()
      End If
      
      ' Once the process has gained control of the named mutex,
      ' hold onto it until the user presses ENTER.
      Console.WriteLine("This process owns the named mutex. " _
          & "Press ENTER to release the mutex and exit.")
      Console.ReadLine()
      
      ' Call ReleaseMutex to allow other threads to gain control
      ' of the named mutex. If you keep a reference to the local
      ' Mutex, you can call WaitOne to request control of the 
      ' named mutex.
      m.ReleaseMutex()
   End Sub 'Main
End Class 'Test
'</Snippet1>