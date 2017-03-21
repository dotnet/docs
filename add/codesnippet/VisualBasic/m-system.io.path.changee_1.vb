Imports System
Imports System.IO

Public Class PathSnippets
    Public Sub ChangeExtension()
        Dim goodFileName As String = "C:\mydir\myfile.com.extension"
        Dim badFileName As String = "C:\mydir\"
        Dim result As String
        result = Path.ChangeExtension(goodFileName, ".old")
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", goodFileName, result)
        result = Path.ChangeExtension(goodFileName, "")
        Console.WriteLine("ChangeExtension({0}, '') returns '{1}'", goodFileName, result)
        result = Path.ChangeExtension(badFileName, ".old")
        Console.WriteLine("ChangeExtension({0}, '.old') returns '{1}'", badFileName, result)

        ' This code produces output similar to the following:
        '
        ' ChangeExtension(C:\mydir\myfile.com.extension, '.old') returns 'C:\mydir\myfile.com.old'
        ' ChangeExtension(C:\mydir\myfile.com.extension, '') returns 'C:\mydir\myfile.com.'
        ' ChangeExtension(C:\mydir\, '.old') returns 'C:\mydir\.old'