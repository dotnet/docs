' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Imports System.Globalization
Imports System.Reflection

Module Example
   Public Sub Main()
      Dim int() As Type = { GetType(IFormatProvider), GetType(IAppDomainSetup) }
      Dim impl() As Type = { GetType(CultureInfo), GetType(AppDomainSetup) }
      
      For ctr As Integer = 0 To int.Length - 1
         ShowInterfaceMapping(int(ctr), impl(ctr))
      Next
   End Sub
   
   Private Sub ShowInterfaceMapping(intType As Type, implType As Type)
      Dim map As InterfaceMapping = implType.GetInterfaceMap(intType)
      Console.WriteLine("Mapping of {0} to {1}: ", map.InterfaceType, map.TargetType)
      For ctr As Integer = 0 To map.InterfaceMethods.Length - 1
         Dim im As MethodInfo = map.InterfaceMethods(ctr)
         Dim tm As MethodInfo = map.TargetMethods(ctr)
         Console.WriteLine("   {0} --> {1}", im.Name,tm.Name)
      Next
      Console.WriteLine()
   End Sub
End Module
' The example displays the following output:
'    Mapping of System.IFormatProvider to System.Globalization.CultureInfo:
'       GetFormat --> GetFormat
'
'    Mapping of System.IAppDomainSetup to System.AppDomainSetup:
'       get_ApplicationBase --> get_ApplicationBase
'       set_ApplicationBase --> set_ApplicationBase
'       get_ApplicationName --> get_ApplicationName
'       set_ApplicationName --> set_ApplicationName
'       get_CachePath --> get_CachePath
'       set_CachePath --> set_CachePath
'       get_ConfigurationFile --> get_ConfigurationFile
'       set_ConfigurationFile --> set_ConfigurationFile
'       get_DynamicBase --> get_DynamicBase
'       set_DynamicBase --> set_DynamicBase
'       get_LicenseFile --> get_LicenseFile
'       set_LicenseFile --> set_LicenseFile
'       get_PrivateBinPath --> get_PrivateBinPath
'       set_PrivateBinPath --> set_PrivateBinPath
'       get_PrivateBinPathProbe --> get_PrivateBinPathProbe
'       set_PrivateBinPathProbe --> set_PrivateBinPathProbe
'       get_ShadowCopyDirectories --> get_ShadowCopyDirectories
'       set_ShadowCopyDirectories --> set_ShadowCopyDirectories
'       get_ShadowCopyFiles --> get_ShadowCopyFiles
'       set_ShadowCopyFiles --> set_ShadowCopyFiles
' </Snippet1>
