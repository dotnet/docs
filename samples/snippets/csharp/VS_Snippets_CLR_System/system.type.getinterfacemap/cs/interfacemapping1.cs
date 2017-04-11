// <Snippet1>
using System;
using System.Globalization;
using System.Reflection;

public class Example
{
   public static void Main()
   {
      Type[] interf = { typeof(IFormatProvider), typeof(IAppDomainSetup) };
      Type[] impl = { typeof(CultureInfo), typeof(AppDomainSetup) };

      for (int ctr = 0; ctr < interf.Length; ctr++)
         ShowInterfaceMapping(interf[ctr], impl[ctr]);
   }

   private static void ShowInterfaceMapping(Type intType, Type implType)
   {
      InterfaceMapping map = implType.GetInterfaceMap(intType);
      Console.WriteLine("Mapping of {0} to {1}: ", map.InterfaceType, map.TargetType);
      for (int ctr = 0; ctr < map.InterfaceMethods.Length; ctr++) {
         MethodInfo im = map.InterfaceMethods[ctr];
         MethodInfo tm = map.TargetMethods[ctr];
         Console.WriteLine("   {0} --> {1}", im.Name,tm.Name);
      }
      Console.WriteLine();
   }
}
// The example displays the following output:
//    Mapping of System.IFormatProvider to System.Globalization.CultureInfo:
//       GetFormat --> GetFormat
//
//    Mapping of System.IAppDomainSetup to System.AppDomainSetup:
//       get_ApplicationBase --> get_ApplicationBase
//       set_ApplicationBase --> set_ApplicationBase
//       get_ApplicationName --> get_ApplicationName
//       set_ApplicationName --> set_ApplicationName
//       get_CachePath --> get_CachePath
//       set_CachePath --> set_CachePath
//       get_ConfigurationFile --> get_ConfigurationFile
//       set_ConfigurationFile --> set_ConfigurationFile
//       get_DynamicBase --> get_DynamicBase
//       set_DynamicBase --> set_DynamicBase
//       get_LicenseFile --> get_LicenseFile
//       set_LicenseFile --> set_LicenseFile
//       get_PrivateBinPath --> get_PrivateBinPath
//       set_PrivateBinPath --> set_PrivateBinPath
//       get_PrivateBinPathProbe --> get_PrivateBinPathProbe
//       set_PrivateBinPathProbe --> set_PrivateBinPathProbe
//       get_ShadowCopyDirectories --> get_ShadowCopyDirectories
//       set_ShadowCopyDirectories --> set_ShadowCopyDirectories
//       get_ShadowCopyFiles --> get_ShadowCopyFiles
//       set_ShadowCopyFiles --> set_ShadowCopyFiles
// </Snippet1>
