Imports System
Imports System.Diagnostics

Public Class Snippet
    
    Public Shared Sub Main()
    
        '<Snippet1> 
        If Not PerformanceCounterCategory.Exists("Orders") Then        
            Dim milk As New CounterCreationData()
            milk.CounterName = "milk"
            milk.CounterType = PerformanceCounterType.NumberOfItems32
            
            Dim milkPerSecond As New CounterCreationData()
            milkPerSecond.CounterName = "milk orders/second"
            milkPerSecond.CounterType = PerformanceCounterType.RateOfCountsPerSecond32
            
            Dim ccds As New CounterCreationDataCollection()
            ccds.Add(milkPerSecond)
            ccds.Add(milk)
            
            PerformanceCounterCategory.Create("Orders", "Number of processed orders", _
                   PerformanceCounterCategoryType.SingleInstance, ccds)
        End If
        '</Snippet1>
        
    End Sub 'Main
End Class 'Snippet
