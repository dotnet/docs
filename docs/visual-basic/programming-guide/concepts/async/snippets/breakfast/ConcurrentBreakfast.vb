Imports System
Imports System.Collections.Generic
Imports System.Threading.Tasks

' <ConcurrentBreakfast>
Module ConcurrentBreakfastProgram
    Async Function Main() As Task
        Dim cup As Coffee = PourCoffee()
        Console.WriteLine("Coffee is ready")

        Dim eggsTask As Task(Of Egg) = FryEggsAsync(2)
        Dim hashBrownTask As Task(Of HashBrown) = FryHashBrownsAsync(3)
        Dim toastTask As Task(Of Toast) = MakeToastWithButterAndJamAsync(2)

        Dim breakfastTasks As New List(Of Task) From {eggsTask, hashBrownTask, toastTask}
        While breakfastTasks.Count > 0
            Dim finishedTask As Task = Await Task.WhenAny(breakfastTasks)
            If finishedTask Is eggsTask Then
                Console.WriteLine("eggs are ready")
            ElseIf finishedTask Is hashBrownTask Then
                Console.WriteLine("hash browns are ready")
            ElseIf finishedTask Is toastTask Then
                Console.WriteLine("toast is ready")
            End If
            Await finishedTask
            breakfastTasks.Remove(finishedTask)
        End While

        Dim oj As Juice = PourOJ()
        Console.WriteLine("oj is ready")
        Console.WriteLine("Breakfast is ready!")
    End Function

    Async Function MakeToastWithButterAndJamAsync(number As Integer) As Task(Of Toast)
        Dim toast As Toast = Await ToastBreadAsync(number)
        ApplyButter(toast)
        ApplyJam(toast)

        Return toast
    End Function

    Private Async Function ToastBreadAsync(slices As Integer) As Task(Of Toast)
        For slice As Integer = 0 To slices - 1
            Console.WriteLine("Putting a slice of bread in the toaster")
        Next
        Console.WriteLine("Start toasting...")
        Await Task.Delay(3000)
        Console.WriteLine("Remove toast from toaster")

        Return New Toast()
    End Function

    Private Async Function FryHashBrownsAsync(patties As Integer) As Task(Of HashBrown)
        Console.WriteLine($"putting {patties} hash brown patties in the pan")
        Console.WriteLine("cooking first side of hash browns...")
        Await Task.Delay(3000)
        For patty As Integer = 0 To patties - 1
            Console.WriteLine("flipping a hash brown patty")
        Next
        Console.WriteLine("cooking the second side of hash browns...")
        Await Task.Delay(3000)
        Console.WriteLine("Put hash browns on plate")

        Return New HashBrown()
    End Function

    Private Async Function FryEggsAsync(howMany As Integer) As Task(Of Egg)
        Console.WriteLine("Warming the egg pan...")
        Await Task.Delay(3000)
        Console.WriteLine($"cracking {howMany} eggs")
        Console.WriteLine("cooking the eggs ...")
        Await Task.Delay(3000)
        Console.WriteLine("Put eggs on plate")

        Return New Egg()
    End Function

    Private Function PourCoffee() As Coffee
        Console.WriteLine("Pouring coffee")
        Return New Coffee()
    End Function

    Private Function PourOJ() As Juice
        Console.WriteLine("Pouring orange juice")
        Return New Juice()
    End Function

    Private Sub ApplyJam(toast As Toast)
        Console.WriteLine("Putting jam on the toast")
    End Sub

    Private Sub ApplyButter(toast As Toast)
        Console.WriteLine("Putting butter on the toast")
    End Sub
End Module
' </ConcurrentBreakfast>