' <Snippet1>

Imports System.Web.Compilation
Imports System.Security
Imports System.Security.Permissions
Namespace PrecompBuildSystem

    <PermissionSet(SecurityAction.Demand, Unrestricted:=true)> _
    Public Class PrecompBuilder
        Private Shared builder As ClientBuildManager
        Private Shared _vPath As String ' Virtual
        Private Shared _pPath As String ' Physical
        Private Shared _tPath As String ' Target
        Private Shared _flags As PrecompilationFlags
        Private Shared _cbmParameter As ClientBuildManagerParameter
        Private Shared _keyFile As String

        Public Shared Sub Main(ByVal args As String())
            ' Check arguments.
            If (ValidateAndSetArguments(args)) Then

                '<Snippet2>
                _cbmParameter = New ClientBuildManagerParameter()
                _cbmParameter.PrecompilationFlags = _flags
                _cbmParameter.StrongNameKeyFile = _keyFile

                builder = New ClientBuildManager(_vPath, _pPath, _tPath, _cbmParameter)
                '</Snippet2>
                ' Pre-compile.
                If (Precompiler()) Then
                    Console.Write("Build succeeded. Result is at " + _tPath + ".")
                End If
            End If
        End Sub

        Private Shared Function ValidateAndSetArguments(ByVal args As String()) As Boolean
            Try
                If (args.Length > 0) Then
                    _vPath = args(0)
                Else
                    _vPath = AppSettingsExpressionBuilder.GetAppSetting("virtualDirectory")
                End If

                If (args.Length > 1) Then
                    _pPath = args(1)
                Else
                    _pPath = AppSettingsExpressionBuilder.GetAppSetting("physicalDirectory")
                End If

                If (args.Length > 2) Then
                    _tPath = args(2)
                Else
                    _tPath = AppSettingsExpressionBuilder.GetAppSetting("targetDirectory")
                End If

                If (args.Length > 3) Then
                    Dim precompFlags As String()
                    precompFlags = args(3).Split("|"c)
                    For Each flag As String In precompFlags
                        _flags = _flags Or [Enum].Parse(GetType(PrecompilationFlags), flag.Trim())
                    Next
                Else
                    _flags = PrecompilationFlags.Clean Or PrecompilationFlags.ForceDebug
                End If

                If (args.Length > 4) Then
                    _keyFile = args(4)
                End If
                Return True
            Catch e As Exception
                OutputErrorList(e)
            End Try
            Return False
        End Function

        Private Shared Sub OutputErrorList(ByVal e As Exception)
            Console.Write("Error: " + e.Message)
        End Sub

        Private Shared Function Precompiler() As Boolean
            Try
                builder.PrecompileApplication()

                ' The precompilation was successful.
                Return True
            Catch e As Exception
                OutputErrorList(e)
            End Try

            ' The precompilation failed.
            Return False
        End Function
    End Class
End Namespace
'  </Snippet1>