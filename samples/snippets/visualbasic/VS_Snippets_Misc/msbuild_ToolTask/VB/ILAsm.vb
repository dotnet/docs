'<Snippet1>
Imports System
Imports System.Collections
Imports System.Text
Imports Microsoft.Build.Utilities
Imports Microsoft.Build.Framework

Namespace MSBuildTasks

    ''' <summary>
    ''' A very simple and incomplete ToolTask to wrap the ILASM.EXE tool.
    ''' </summary>
    Public Class ILAsm
        Inherits ToolTask

        ''' <summary>
        ''' Parameter bag.
        ''' </summary>
        Protected Friend ReadOnly Property Bag() As Hashtable
            Get
                Return propertyBag
            End Get
        End Property

        Private propertyBag As New Hashtable()

        ''' <summary>
        ''' The Source file that is to be compled (.il)
        ''' </summary>
        Public Property [Source]() As ITaskItem
            Get
                Return Bag("Source")
            End Get
            Set(ByVal value As ITaskItem)
                Bag("Source") = value
            End Set
        End Property

        ''' <summary>
        ''' Either EXE or DLL indicating the assembly type to be generated
        ''' </summary>
        Public Property TargetType() As String
            Get
                Return Bag("TargetType")
            End Get
            Set(ByVal value As String)
                Bag("TargetType") = value
            End Set
        End Property '

        Protected Overrides ReadOnly Property ToolName() As String
            Get
                Return "ILAsm.exe"
            End Get
        End Property

        ''' <summary>
        ''' Use ToolLocationHelper to find ILASM.EXE in the Framework directory
        ''' </summary>
        Protected Overrides Function GenerateFullPathToTool() As String
            ' Ask ToolLocationHelper to find ILASM.EXE - it will look in the latest framework directory available
            Return ToolLocationHelper.GetPathToDotNetFrameworkFile(ToolName, TargetDotNetFrameworkVersion.VersionLatest)
        End Function

        ''' <summary>
        ''' Construct the command line from the task properties by using the CommandLineBuilder
        ''' </summary>
        Protected Overrides Function GenerateCommandLineCommands() As String
            Dim builder As New CommandLineBuilder()

            ' We don't need the tool's logo information shown
            builder.AppendSwitch("/nologo")

            Dim targetType As String = Bag("TargetType")
            ' Be explicit with our switches
            If Not (targetType Is Nothing) Then
                If [String].Compare(targetType, "DLL", True) = 0 Then
                    builder.AppendSwitch("/DLL")
                ElseIf [String].Compare(targetType, "EXE", True) = 0 Then
                    builder.AppendSwitch("/EXE")
                Else
                    Log.LogWarning("Invalid TargetType (valid values are DLL and EXE) specified: {0}", targetType)
                End If
            End If
            ' Add the filename that we want the tool to process
            builder.AppendFileNameIfNotNull(Bag("Source"))

            ' Log a High importance message stating the file that we are assembling
            Log.LogMessage(MessageImportance.High, "Assembling {0}", Bag("Source"))

            ' We have all of our switches added, return the commandline as a string
            Return builder.ToString()
        End Function
    End Class
End Namespace
'</Snippet1>