'<snippet1>
' This example demonstrates the 
'     Environment.GetEnvironmentVariable,
'     Environment.SetEnvironmentVariable, and 
'     Environment.GetEnvironmentVariables overloaded methods.
Imports System
Imports System.Collections
Imports Microsoft.Win32
Imports Microsoft.VisualBasic

Class Sample
   '-------------------------------------------------------------------------------------
   ' Globals: 
   '-------------------------------------------------------------------------------------
   Protected Shared fmtNameValue As String = "  {0} {1}."
   Protected Shared myVarSuffix As String = "_GETSET_ENVAR_SAMPLE"
   
   ' Four relatively unique environment variable names.
   Protected Shared myVarA As String = "A" & myVarSuffix ' default process
   Protected Shared myVarB As String = "B" & myVarSuffix ' Current Process
   Protected Shared myVarC As String = "C" & myVarSuffix ' Current User
   Protected Shared myVarD As String = "D" & myVarSuffix ' Local Machine
   '=====================================================================================
   ' EachVariable: 
   ' Test whether a specific environment variable exists in a target.
   ' This section demonstrates Environment.GetEnvironmentVariable.
   '-------------------------------------------------------------------------------------
   Protected Shared Sub EachVariable(var As String, tgt As EnvironmentVariableTarget)
      Dim str As String
      '
      If 0 = tgt Then ' Zero means use the default target.
         str = Environment.GetEnvironmentVariable(var)
      Else
         str = Environment.GetEnvironmentVariable(var, tgt)
      End If
      Console.WriteLine(fmtNameValue, var, IIf(String.IsNullOrEmpty(str), _
                                              "doesn't exist", str))
   End Sub 'EachVariable
   
   '-------------------------------------------------------------------------------------
   ' CheckEachVariable: 
   ' Uses EachVariable to test whether each environment variable exists in a target.
   '-------------------------------------------------------------------------------------
   Protected Shared Sub CheckEachVariable()
      Console.WriteLine("Process:")
      EachVariable(myVarA, 0) ' Check the default target (current process)
      EachVariable(myVarB, EnvironmentVariableTarget.Process)
      EachVariable(myVarC, EnvironmentVariableTarget.Process)
      EachVariable(myVarD, EnvironmentVariableTarget.Process)
      Console.WriteLine()
      
      Console.WriteLine("User:")
      EachVariable(myVarA, EnvironmentVariableTarget.User)
      EachVariable(myVarB, EnvironmentVariableTarget.User)
      EachVariable(myVarC, EnvironmentVariableTarget.User)
      EachVariable(myVarD, EnvironmentVariableTarget.User)
      Console.WriteLine()
      
      Console.WriteLine("Machine:")
      EachVariable(myVarA, EnvironmentVariableTarget.Machine)
      EachVariable(myVarB, EnvironmentVariableTarget.Machine)
      EachVariable(myVarC, EnvironmentVariableTarget.Machine)
      EachVariable(myVarD, EnvironmentVariableTarget.Machine)
      Console.WriteLine()
   End Sub 'CheckEachVariable
   
   '=====================================================================================
   ' AllVariables: CheckAllVariables helper function.
   ' This section demonstrates Environment.GetEnvironmentVariables.
   '-------------------------------------------------------------------------------------
   Private Shared Sub AllVariables(tgt As EnvironmentVariableTarget)
      Dim value As String
      Dim key As String
      
      Dim de As DictionaryEntry
      For Each de In Environment.GetEnvironmentVariables(tgt)
         key = CStr(de.Key)
         value = CStr(de.Value)
         If key.Contains(myVarSuffix) Then
            Console.WriteLine(fmtNameValue, key, value)
         End If
      Next de
      Console.WriteLine()
   End Sub 'AllVariables
   
   '=====================================================================================
   ' CheckAllVariables: 
   ' Uses AllVariables to test whether each environment variable exists in a target.
   '-------------------------------------------------------------------------------------
   Protected Shared Sub CheckAllVariables()
      Console.WriteLine("Process:")
      AllVariables(EnvironmentVariableTarget.Process)
      
      Console.WriteLine("User:")
      AllVariables(EnvironmentVariableTarget.User)
      
      Console.WriteLine("Machine:")
      AllVariables(EnvironmentVariableTarget.Machine)
   End Sub 'CheckAllVariables
   
   '=====================================================================================
   ' ChkReg: CheckRegistry helper function.
   ' This function filters out irrelevant environment variables. 
   '-------------------------------------------------------------------------------------
   Private Shared Sub ChkReg(rk As RegistryKey)
      Dim exists As Boolean = False
      Dim registryNone As String = "  Environment variable doesn't exist."
      
      Dim s As String
      For Each s In rk.GetValueNames()
         If s.Contains(myVarSuffix) Then
            Console.WriteLine(fmtNameValue, s, CStr(rk.GetValue(s)))
            exists = True
         End If
      Next s
      If exists = False Then
         Console.WriteLine(registryNone)
      End If
      Console.WriteLine()
   End Sub 'ChkReg
   
   '-------------------------------------------------------------------------------------
   ' CheckRegistry: 
   ' Uses ChkReg to display the User and Machine environment variables in the registry.
   '-------------------------------------------------------------------------------------
   Protected Shared Sub CheckRegistry()
      Dim subkeyU As String = "Environment"
      Dim subkeyM As String = "System\CurrentControlSet\Control\Session Manager\Environment"
      Dim fmtSubkey As String = """{0}"" key:"
      
      Console.WriteLine(fmtSubkey, subkeyU)
      ChkReg(Registry.CurrentUser.OpenSubKey(subkeyU))
      
      Console.WriteLine(fmtSubkey, subkeyM)
      ChkReg(Registry.LocalMachine.OpenSubKey(subkeyM))
   End Sub 'CheckRegistry
   
   '=====================================================================================
   ' Main:
   '-------------------------------------------------------------------------------------
   Public Shared Sub Main()
      '-------------------------------------------------------------------------------------
      ' Environment variable values
      '-------------------------------------------------------------------------------------
      Dim existsA As String = "exists in the default target (Process)"
      Dim existsB As String = "exists in Process"
      Dim existsC As String = "exists in User"
      Dim existsD As String = "exists in Machine"
      '-------------------------------------------------------------------------------------
      ' Messages:
      '-------------------------------------------------------------------------------------
      Dim msg1  As String = "Step 1:" & vbCrLf & _
                            "  Check whether the environment variables already exist in " _
                 & vbCrLf & "  the various targets..." & vbCrLf
      Dim msg2  As String = "Step 2:" & vbCrLf & _
                            "  Set the environment variable for each target..." & vbCrLf
      Dim msg31 As String = "Step 3, part 1:" & vbCrLf & _
                            "  Display the environment variables in each target..." & vbCrLf
      Dim msg32 As String = "Step 3, part 2:" & vbCrLf & _
                            "  Check whether the User and Machine environment variables " _
                 & vbCrLf & "  were created in the Windows operating system registry..." _
                 & vbCrLf
      Dim msg41 As String = "Step 4, part 1:" & vbCrLf & _
                            "  Delete the environment variables created for this sample..." _
                 & vbCrLf
      Dim msg42 As String = "Step 4, part 2:" & vbCrLf & _
                            "  Check whether the environment variables were deleted " _
                 & vbCrLf & "  in each target..." & vbCrLf
      Dim msg43 As String = "Step 4, part 3:" & vbCrLf & _
                            "  Check whether the User and Machine environment variables " _
                 & vbCrLf & "  were deleted from the Windows operating system registry..." _
                 & vbCrLf
      Dim fmt2x As String = "  {0,9}: Set {1} = ""{2}"""
      '-------------------------------------------------------------------------------------
      ' Step 1:
      ' Check whether the sample environment variables already exist.
      ' WARNING: These variables will be deleted at the end of this sample.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg1)
      CheckEachVariable()
      Console.WriteLine()
      '-------------------------------------------------------------------------------------
      ' Step 2:
      ' Set the environment variable for each target.
      ' This section demonstrates Environment.SetEnvironmentVariable.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg2)
      ' Set the environment variable for the default target (the current process).
      Console.WriteLine(fmt2x, "(default)", myVarA, existsA)
      Environment.SetEnvironmentVariable(myVarA, existsA)
      
      ' Set the environment variable for the current process.
      Console.WriteLine(fmt2x, "Process", myVarB, existsB)
      Environment.SetEnvironmentVariable(myVarB, existsB, EnvironmentVariableTarget.Process)
      
      ' Set the environment variable for the current user.
      Console.WriteLine(fmt2x, "User", myVarC, existsC)
      Environment.SetEnvironmentVariable(myVarC, existsC, EnvironmentVariableTarget.User)
      
      ' Set the environment variable for the local machine.
      Console.WriteLine(fmt2x, "Machine", myVarD, existsD)
      Environment.SetEnvironmentVariable(myVarD, existsD, EnvironmentVariableTarget.Machine)
      Console.WriteLine()
      '-------------------------------------------------------------------------------------
      ' Step 3, part 1:
      ' Display the environment variables in each target.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg31)
      CheckAllVariables()
      Console.WriteLine()
      '-------------------------------------------------------------------------------------
      ' Step 3, part 2:
      ' Check whether the User and Machine environment variables were created in the Windows 
      ' operating system registry.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg32)
      CheckRegistry()
      Console.WriteLine()
      '-------------------------------------------------------------------------------------
      ' Step 4, part 1:
      ' Delete the environment variables created for this sample.
      ' This section demonstrates using Environment.SetEnvironmentVariable to delete an 
      ' environment variable.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg41)
      Environment.SetEnvironmentVariable(myVarA, Nothing)
      Environment.SetEnvironmentVariable(myVarB, Nothing, EnvironmentVariableTarget.Process)
      Environment.SetEnvironmentVariable(myVarC, Nothing, EnvironmentVariableTarget.User)
      Environment.SetEnvironmentVariable(myVarD, Nothing, EnvironmentVariableTarget.Machine)
      '-------------------------------------------------------------------------------------
      ' Step 4, part 2:
      ' Check whether the environment variables were deleted in each target.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg42)
      CheckEachVariable()
      '-------------------------------------------------------------------------------------
      ' Step 4, part 3:
      ' Check whether the User and Machine environment variables were deleted from the 
      ' Windows operating system registry.
      '-------------------------------------------------------------------------------------
      Console.WriteLine(msg43)
      CheckRegistry()
   End Sub 'Main
End Class 'Sample
'
'This example produces the following results:
'
'Step 1:
'  Check whether the environment variables already exist in
'  the various targets...
'
'Process:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'User:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'Machine:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'
'Step 2:
'  Set the environment variable for each target...
'
'  (default): Set A_GETSET_ENVAR_SAMPLE = "exists in the default target (Process)"
'    Process: Set B_GETSET_ENVAR_SAMPLE = "exists in Process"
'       User: Set C_GETSET_ENVAR_SAMPLE = "exists in User"
'    Machine: Set D_GETSET_ENVAR_SAMPLE = "exists in Machine"
'
'Step 3, part 1:
'  Display the environment variables in each target...
'
'Process:
'  B_GETSET_ENVAR_SAMPLE exists in Process.
'  A_GETSET_ENVAR_SAMPLE exists in the default target (Process).
'
'User:
'  C_GETSET_ENVAR_SAMPLE exists in User.
'
'Machine:
'  D_GETSET_ENVAR_SAMPLE exists in Machine.
'
'
'Step 3, part 2:
'  Check whether the User and Machine environment variables
'  were created in the Windows operating system registry...
'
'"Environment" key:
'  C_GETSET_ENVAR_SAMPLE exists in User.
'
'"System\CurrentControlSet\Control\Session Manager\Environment" key:
'  D_GETSET_ENVAR_SAMPLE exists in Machine.
'
'
'Step 4, part 1:
'  Delete the environment variables created for this sample...
'
'Step 4, part 2:
'  Check whether the environment variables were deleted
'  in each target...
'
'Process:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'User:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'Machine:
'  A_GETSET_ENVAR_SAMPLE doesn't exist.
'  B_GETSET_ENVAR_SAMPLE doesn't exist.
'  C_GETSET_ENVAR_SAMPLE doesn't exist.
'  D_GETSET_ENVAR_SAMPLE doesn't exist.
'
'Step 4, part 3:
'  Check whether the User and Machine environment variables
'  were deleted from the Windows operating system registry...
'
'"Environment" key:
'  Environment variable doesn't exist.
'
'"System\CurrentControlSet\Control\Session Manager\Environment" key:
'  Environment variable doesn't exist.
'
'</snippet1>