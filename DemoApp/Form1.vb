Option Explicit On
Imports System.Threading

Public Class Form1

#Region " Task related stuff "
    Public myTasksNames As ArrayList = Nothing

    Private Function getTaskNames() As ArrayList
        Dim s As New ArrayList
        For i As Integer = 1 To 20
            s.Add($"Task #{i}")
        Next
        Return s
    End Function

    Private Async Function processTask(ByVal taskId As Integer) As Task(Of Integer)
        'await a function with no internal await
        Return Await Task.Run(Of Integer)(Function()
                                              Console.WriteLine($"Executing { myTasksNames(taskId) }. Sleeping now.")
                                              Threading.Thread.Sleep(5000)

                                              Console.WriteLine($"{ myTasksNames(taskId) } function done.")
                                              Return taskId
                                          End Function)
    End Function

    Private Async Function sumFunction() As Task(Of Integer)
        Console.WriteLine("sumFunction() > start")

        Dim rslt As Integer = 0
        For i As Integer = 1 To 10
            rslt += i
            Await Task.Delay(1000)
        Next

        Console.WriteLine("sumFunction() > done")
        Return rslt
    End Function

    Private Async Function wordFunction() As Task(Of String)
        Console.WriteLine("wordFunction() > start")

        Dim arrMonths As New ArrayList

        For i As Integer = 1 To 12
            arrMonths.Add(MonthName(i))
            Await Task.Delay(2000)
        Next

        Console.WriteLine("wordFunction() > done")
        Return String.Join(",", arrMonths.ToArray)
    End Function
#End Region


    Private Async Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        Dim txt As String = b1.Text : b1.Text = "Running"

        'initialize tasks
        myTasksNames = getTaskNames()

        'execute 1 task only (at index 0) and wait
        Console.WriteLine("Waiting for task to complete...")
        Dim rslt As Integer = Await processTask(0)

        'inform that you're done; return the result if necessary
        Console.WriteLine($"Task { rslt } have been executed.")
        b1.Text = txt
    End Sub

    Private Async Sub b2_Click(sender As Object, e As EventArgs) Handles b2.Click
        Dim txt As String = b2.Text : b2.Text = "Running"

        'initialize tasks
        myTasksNames = getTaskNames()

        'create a list of all your tasks to execute
        Dim taskList As New List(Of Task)

        'start all tasks and put them on your list
        For i As Integer = 0 To (myTasksNames.Count - 1)
            Dim newTask As Task = processTask(i)
            taskList.Add(newTask)
        Next

        'wait for all tasks to finish before proceeding
        Console.WriteLine("Waiting for all tasks to complete...")
        Await Task.WhenAll(taskList.ToArray)

        Console.WriteLine("All Tasks have been executed.")
        b2.Text = txt
    End Sub

    Private Async Sub btn3_Click(sender As Object, e As EventArgs) Handles b3.Click
        Dim txt As String = b3.Text
        b3.Text = "Running"

        'initialize tasks
        myTasksNames = getTaskNames()

        'create a list of all your tasks to execute
        Dim taskList As New List(Of Task)

        'run 5 tasks at a time
        Dim maxConcurrent As Integer = 5

        'start all tasks and put them on your list
        For i As Integer = 0 To (myTasksNames.Count - 1)
            Dim newTask As Task = processTask(i)
            taskList.Add(newTask)

            'throttle your tasks to a defined limit
            If taskList.Count > maxConcurrent Then
                Console.WriteLine("Limit reached. Stalling until a task is done....")
                Dim completedTask As Task(Of Integer) = Await Task.WhenAny(taskList)
                taskList.Remove(completedTask)
            End If
        Next

        Console.WriteLine("Waiting for the rest of the tasks to complete...")
        Await Task.WhenAll(taskList)


        Console.WriteLine("All Tasks have been executed.")
        b3.Text = txt
    End Sub



    Private Async Sub b4_Click(sender As Object, e As EventArgs) Handles b4.Click
        Dim txt As String = b4.Text : b4.Text = "Running"

        'start the sumFunction
        Dim sumTask = sumFunction()

        'start the wordFunction
        Dim wordTask = wordFunction()

        'wait for both tasks to finish before proceeding
        Console.WriteLine("Waiting for all tasks to complete...")
        Await Task.WhenAll(sumTask, wordTask)

        'tasks finished. display results
        Console.WriteLine("")
        Console.WriteLine($"Result of sumTask() is: { sumTask.Result }")
        Console.WriteLine($"Result of wordFunction() is: { wordTask.Result }")
        b4.Text = txt
    End Sub

End Class
