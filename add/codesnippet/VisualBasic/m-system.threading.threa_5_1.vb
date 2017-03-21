Imports System.Threading

Public Class MyUtility
    Public Sub PerformTask() 
        ' Code in this region can be aborted without affecting
        ' other tasks.
        '
        Thread.BeginCriticalRegion()
        '
        ' The host might decide to unload the application domain
        ' if a failure occurs in this code region.
        '
        Thread.EndCriticalRegion()
        ' Code in this region can be aborted without affecting
        ' other tasks.
    End Sub
End Class 