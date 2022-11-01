---
title: ".NET SDK error list"
description: A complete list of NETSDKxxxx errors, with links to more info where more info is available.
ms.topic: error-reference
ms.date: 06/23/2022
f1_keywords:
- NETSDK1001
- NETSDK1002
- NETSDK1003
- NETSDK1006
- NETSDK1007
- NETSDK1008
- NETSDK1009
- NETSDK1010
- NETSDK1011
- NETSDK1012
- NETSDK1014
- NETSDK1015
- NETSDK1016
- NETSDK1017
- NETSDK1018
- NETSDK1019
- NETSDK1020
- NETSDK1021
- NETSDK1023
- NETSDK1024
- NETSDK1025
- NETSDK1028
- NETSDK1029
- NETSDK1030
- NETSDK1031
- NETSDK1032
- NETSDK1042
- NETSDK1043
- NETSDK1044
- NETSDK1046
- NETSDK1048
- NETSDK1049
- NETSDK1050
- NETSDK1051
- NETSDK1052
- NETSDK1053
- NETSDK1054
- NETSDK1055
- NETSDK1056
- NETSDK1057
- NETSDK1058
- NETSDK1060
- NETSDK1061
- NETSDK1063
- NETSDK1065
- NETSDK1067
- NETSDK1068
- NETSDK1069
- NETSDK1070
- NETSDK1072
- NETSDK1074
- NETSDK1075
- NETSDK1076
- NETSDK1077
- NETSDK1078
- NETSDK1081
- NETSDK1083
- NETSDK1084
- NETSDK1085
- NETSDK1086
- NETSDK1087
- NETSDK1088
- NETSDK1089
- NETSDK1090
- NETSDK1091
- NETSDK1092
- NETSDK1093
- NETSDK1094
- NETSDK1095
- NETSDK1096
- NETSDK1097
- NETSDK1098
- NETSDK1099
- NETSDK1102
- NETSDK1103
- NETSDK1104
- NETSDK1105
- NETSDK1106
- NETSDK1107
- NETSDK1109
- NETSDK1110
- NETSDK1111
- NETSDK1113
- NETSDK1114
- NETSDK1115
- NETSDK1116
- NETSDK1117
- NETSDK1118
- NETSDK1119
- NETSDK1120
- NETSDK1121
- NETSDK1122
- NETSDK1123
- NETSDK1124
- NETSDK1125
- NETSDK1126
- NETSDK1127
- NETSDK1128
- NETSDK1129
- NETSDK1131
- NETSDK1132
- NETSDK1133
- NETSDK1134
- NETSDK1139
- NETSDK1140
- NETSDK1142
- NETSDK1143
- NETSDK1144
- NETSDK1146
- NETSDK1148
- NETSDK1150
- NETSDK1151
- NETSDK1152
- NETSDK1153
- NETSDK1154
- NETSDK1155
- NETSDK1156
- NETSDK1157
- NETSDK1158
- NETSDK1159
- NETSDK1160
- NETSDK1161
- NETSDK1162
- NETSDK1163
- NETSDK1164
- NETSDK1165
- NETSDK1166
- NETSDK1167
- NETSDK1168
- NETSDK1169
- NETSDK1170
- NETSDK1171
- NETSDK1172
- NETSDK1173
- NETSDK1175
- NETSDK1176
- NETSDK1177
- NETSDK1178
- NETSDK1179
- NETSDK1181
- NETSDK1183
- NETSDK1184
- NETSDK1185
- NETSDK1186
- NETSDK1187
- NETSDK1188
- NETSDK1189
- NETSDK1190
- NETSDK1191
- NETSDK1192
---
# .NET SDK error list

**This article applies to:** ✔️ .NET 6 SDK and later versions

This is a complete list of the errors that you might get from the .NET SDK while developing .NET apps. If more info is available for a particular error, the error number is a link.

| SDK Message Number | Message            |
|--------------------|--------------------|
|NETSDK1001|At least one possible target framework must be specified.|
|NETSDK1002|Project '{0}' targets '{2}'. It cannot be referenced by a project that targets '{1}'.|
|NETSDK1003|Invalid framework name: '{0}'.|
|[NETSDK1004](netsdk1004.md)|Assets file '{0}' not found. Run a NuGet package restore to generate this file.|
|[NETSDK1005](netsdk1005.md)|Assets file '{0}' doesn't have a target for '{1}'. Ensure that restore has run and that you have included '{2}' in the TargetFrameworks for your project.|
|NETSDK1006|Assets file path '{0}' is not rooted. Only full paths are supported.|
|NETSDK1007|Cannot find project info for '{0}'. This can indicate a missing project reference.|
|NETSDK1008|Missing '{0}' metadata on '{1}' item '{2}'.|
|NETSDK1009|Unrecognized preprocessor token '{0}' in '{1}'.|
|NETSDK1010|The '{0}' task must be given a value for parameter '{1}' in order to consume preprocessed content.|
|NETSDK1011|Assets are consumed from project '{0}', but no corresponding MSBuild project path was  found in '{1}'.|
|NETSDK1012|Unexpected file type for '{0}'. Type is both '{1}' and '{2}'.|
|[NETSDK1013](netsdk1013.md)|The TargetFramework value '{0}' was not recognized. It may be misspelled. If not, then the TargetFrameworkIdentifier and/or TargetFrameworkVersion properties must be specified explicitly.|
|NETSDK1014|Content item for '{0}' sets '{1}', but does not provide  '{2}' or '{3}'.|
|NETSDK1015|The preprocessor token '{0}' has been given more than one value. Choosing '{1}' as the value.|
|NETSDK1016|Unable to find resolved path for '{0}'.|
|NETSDK1017|Asset preprocessor must be configured before assets are processed.|
|NETSDK1018|Invalid NuGet version string: '{0}'.|
|NETSDK1019|{0} is an unsupported framework.|
|NETSDK1020|Package Root {0} was incorrectly given for Resolved library {1}.|
|NETSDK1021|More than one file found for {0}|
|[NETSDK1022](netsdk1022.md)|Duplicate '{0}' items were included. The .NET SDK includes '{0}' items from your project directory by default. You can either remove these items from your project file, or set the '{1}' property to '{2}' if you want to explicitly include them in your project file. For more information, see {4}. The duplicate items were: {3}.|
|NETSDK1023|A PackageReference for '{0}' was included in your project. This package is implicitly referenced by the .NET SDK and you do not typically need to reference it from your project. For more information, see {1}.|
|NETSDK1024|Folder '{0}' already exists - either delete it or provide a different ComposeWorkingDir.|
|NETSDK1025|The target manifest {0} provided is of not the correct format.|
|NETSDK1028|Specify a RuntimeIdentifier.|
|NETSDK1029|Unable to use '{0}' as application host executable as it does not contain the expected placeholder byte sequence '{1}' that would mark where the application name would be written.|
|NETSDK1030|Given file name '{0}' is longer than 1024 bytes.|
|NETSDK1031|It is not supported to build or publish a self-contained application without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set SelfContained to false.|
|NETSDK1032|The RuntimeIdentifier platform '{0}' and the PlatformTarget '{1}' must be compatible.|
|NETSDK1042|Could not load PlatformManifest from '{0}' because it did not exist.|
|NETSDK1043|Error parsing PlatformManifest from '{0}' line {1}.  Lines must have the format {2}.|
|NETSDK1044|Error parsing PlatformManifest from '{0}' line {1}.  {2} '{3}' was invalid.|
|[NETSDK1045](netsdk1045.md)|The current .NET SDK does not support targeting {0} {1}.  Either target {0} {2} or lower, or use a version of the .NET SDK that supports {0} {1}.|
|NETSDK1046|The TargetFramework value '{0}' is not valid. To multi-target, use the 'TargetFrameworks' property instead.|
|NETSDK1047|Assets file '{0}' doesn't have a target for '{1}'. Ensure that restore has run and that you have included '{2}' in the TargetFrameworks for your project. You may also need to include '{3}' in your project's RuntimeIdentifiers.|
|NETSDK1048|'AdditionalProbingPaths' were specified for GenerateRuntimeConfigurationFiles, but are being skipped because 'RuntimeConfigDevPath' is empty.|
|NETSDK1049|Resolved file has a bad image, no metadata, or is otherwise inaccessible. {0} {1}.|
|NETSDK1050|The version of Microsoft.NET.Sdk used by this project is insufficient to support references to libraries targeting .NET Standard 1.5 or higher.  Please install version 2.0 or higher of the .NET Core SDK.|
|NETSDK1051|Error parsing FrameworkList from '{0}'.  {1} '{2}' was invalid.|
|NETSDK1052|Framework list file path '{0}' is not rooted. Only full paths are supported.|
|NETSDK1053|Pack as tool does not support self contained.|
|NETSDK1054|Only supports .NET Core.|
|NETSDK1055|DotnetTool does not support target framework lower than netcoreapp2.1.|
|NETSDK1056|Project is targeting runtime '{0}' but did not resolve any runtime-specific packages. This runtime may not be supported by the target framework.|
|NETSDK1057|You are using a preview version of .NET. See <https://aka.ms/dotnet-support-policy>.|
|NETSDK1058|Invalid value for ItemSpecToUse parameter: '{0}'.  This property must be blank or set to 'Left' or 'Right'|
|[NETSDK1059](netsdk1059.md)|The tool '{0}' is now included in the .NET SDK. Information on resolving this warning is available at <https://aka.ms/dotnetclitools-in-box>.|
|NETSDK1060|Error reading assets file: {0}|
|NETSDK1061|The project was restored using {0} version {1}, but with current settings, version {2} would be used instead. To resolve this issue, make sure the same settings are used for restore and for subsequent operations such as build or publish. Typically this issue can occur if the RuntimeIdentifier property is set during build or publish but not during restore. For more information, see <https://aka.ms/dotnet-runtime-patch-selection>.|
|NETSDK1063|The path to the project assets file was not set. Run a NuGet package restore to generate this file.|
|[NETSDK1064](netsdk1064.md)|Package {0}, version {1} was not found. It might have been deleted since NuGet restore. Otherwise, NuGet restore might have only partially completed, which might have been due to maximum path length restrictions.|
|NETSDK1065|Cannot find app host for {0}. {0} could be an invalid runtime identifier (RID). For more information about RID, see <https://aka.ms/rid-catalog>.|
|NETSDK1067|Self-contained applications are required to use the application host. Either set SelfContained to false or set UseAppHost to true.|
|NETSDK1068|The framework-dependent application host requires a target framework of at least 'netcoreapp2.1'.|
|NETSDK1069|This project uses a library that targets .NET Standard 1.5 or higher, and the project targets a version of .NET Framework that doesn't have built-in support for that version of .NET Standard. Visit <https://aka.ms/net-standard-known-issues> for a set of known issues. Consider retargeting to .NET Framework 4.7.2.|
|NETSDK1070|The application configuration file must have root configuration element.|
|[NETSDK1071](netsdk1071.md)|A PackageReference to '{0}' specified a Version of `{1}`. Specifying the version of this package is not recommended. For more information, see <https://aka.ms/sdkimplicitrefs>.|
|NETSDK1072|Unable to use '{0}' as application host executable because it's not a Windows executable for the CUI (Console) subsystem.|
|[NETSDK1073](netsdk1073.md)|The FrameworkReference '{0}' was not recognized.|
|NETSDK1074|The application host executable will not be customized because adding resources requires that the build be performed on Windows (excluding Nano Server).|
|NETSDK1075|Update handle is invalid. This instance may not be used for further updates.|
|NETSDK1076|AddResource can only be used with integer resource types.|
|NETSDK1077|Failed to lock resource.|
|NETSDK1078|Unable to use '{0}' as application host executable because it's not a Windows PE file.|
|[NETSDK1079](netsdk1079.md)|The Microsoft.AspNetCore.All package is not supported when targeting .NET Core 3.0 or higher.  A FrameworkReference to Microsoft.AspNetCore.App should be used instead, and will be implicitly included by Microsoft.NET.Sdk.Web.|
|[NETSDK1080](netsdk1080.md)|A PackageReference to Microsoft.AspNetCore.App is not necessary when targeting .NET Core 3.0 or higher. If Microsoft.NET.Sdk.Web is used, the shared framework will be referenced automatically. Otherwise, the PackageReference should be replaced with a FrameworkReference.|
|NETSDK1081|The targeting pack for {0} was not found. You may be able to resolve this by running a NuGet restore on the project.|
|[NETSDK1082](netsdk1082.md)|There was no runtime pack for {0} available for the specified RuntimeIdentifier '{1}'.|
|NETSDK1083|The specified RuntimeIdentifier '{0}' is not recognized.|
|NETSDK1084|There is no application host available for the specified RuntimeIdentifier '{0}'.|
|NETSDK1085|The 'NoBuild' property was set to true but the 'Build' target was invoked.|
|NETSDK1086|A FrameworkReference for '{0}' was included in the project. This is implicitly referenced by the .NET SDK and you do not typically need to reference it from your project. For more information, see {1}.|
|NETSDK1087|Multiple FrameworkReference items for '{0}' were included in the project.|
|NETSDK1088|The COMVisible class '{0}' must have a GuidAttribute with the CLSID of the class to be made visible to COM in .NET Core.|
|NETSDK1089|The '{0}' and '{1}' types have the same CLSID '{2}' set in their GuidAttribute. Each COMVisible class needs to have a distinct guid for their CLSID.|
|NETSDK1090|The supplied assembly '{0}' is not valid. Cannot generate a CLSIDMap from it.|
|NETSDK1091|Unable to find a .NET Core COM host. The .NET Core COM host is only available on .NET Core 3.0 or higher when targeting Windows.|
|NETSDK1092|The CLSIDMap cannot be embedded on the COM host because adding resources requires that the build be performed on Windows (excluding Nano Server).|
|NETSDK1093|Project tools (DotnetCliTool) only support targeting .NET Core 2.2 and lower.|
|NETSDK1094|Unable to optimize assemblies for performance: a valid runtime package was not found. Either set the PublishReadyToRun property to false, or use a supported runtime identifier when publishing. When targeting .NET 6 or higher, make sure to restore packages with the PublishReadyToRun property set to true.|
|NETSDK1095|Optimizing assemblies for performance is not supported for the selected target platform or architecture. Please verify you are using a supported runtime identifier, or set the PublishReadyToRun property to false.|
|NETSDK1096|Optimizing assemblies for performance failed. You can either exclude the failing assemblies from being optimized, or set the PublishReadyToRun property to false.|
|NETSDK1097|It is not supported to publish an application to a single-file without specifying a RuntimeIdentifier. You must either specify a RuntimeIdentifier or set PublishSingleFile to false.|
|NETSDK1098|Applications published to a single-file are required to use the application host. You must either set PublishSingleFile to false or set UseAppHost to true.|
|NETSDK1099|Publishing to a single-file is only supported for executable applications.|
|[NETSDK1100](netsdk1100.md)|To build a project targeting Windows on this operating system, set the EnableWindowsTargeting property to true.|
|NETSDK1102|Optimizing assemblies for size is not supported for the selected publish configuration. Please ensure that you are publishing a self-contained app.|
|NETSDK1103|RollForward setting is only supported on .NET Core 3.0 or higher.|
|NETSDK1104|RollForward value '{0}' is invalid. Allowed values are {1}.|
|NETSDK1105|Windows desktop applications are only supported on .NET Core 3.0 or higher.|
|NETSDK1106|Microsoft.NET.Sdk.WindowsDesktop requires 'UseWpf' or 'UseWindowsForms' to be set to 'true'.|
|NETSDK1107|Microsoft.NET.Sdk.WindowsDesktop is required to build Windows desktop applications. 'UseWpf' and 'UseWindowsForms' are not supported by the current SDK.|
|NETSDK1109|Runtime list file '{0}' was not found. Report this error to the .NET team here: <https://aka.ms/dotnet-sdk-issue>.|
|NETSDK1110|More than one asset in the runtime pack has the same destination sub-path of '{0}'. Report this error to the .NET team here: <https://aka.ms/dotnet-sdk-issue>.|
|NETSDK1111|Failed to delete output apphost: {0}.|
|[NETSDK1112](netsdk1112.md)|The runtime pack for {0} was not downloaded. Try running a NuGet restore with the RuntimeIdentifier '{1}'.|
|NETSDK1113|Failed to create apphost (attempt {0} out of {1}): {2}.|
|NETSDK1114|Unable to find a .NET Core IJW host. The .NET Core IJW host is only available on .NET Core 3.1 or higher when targeting Windows.|
|NETSDK1115|The current .NET SDK does not support .NET Framework without using .NET SDK Defaults. It is likely due to a mismatch between C++/CLI project CLRSupport property and TargetFramework.|
|NETSDK1116|C++/CLI projects targeting .NET Core must be dynamic libraries.|
|NETSDK1117|Does not support publish of C++/CLI project targeting dotnet core.|
|NETSDK1118|C++/CLI projects targeting .NET Core cannot be packed.|
|NETSDK1119|C++/CLI projects targeting .NET Core cannot use EnableComHosting=true.|
|NETSDK1120|C++/CLI projects targeting .NET Core require a target framework of at least 'netcoreapp3.1'.|
|NETSDK1121|C++/CLI projects targeting .NET Core cannot use SelfContained=true.|
|NETSDK1122|ReadyToRun compilation will be skipped because it is only supported for .NET Core 3.0 or higher.|
|NETSDK1123|Publishing an application to a single-file requires .NET Core 3.0 or higher.|
|NETSDK1124|Trimming assemblies requires .NET Core 3.0 or higher.|
|NETSDK1125|Publishing to a single-file is only supported for netcoreapp target.|
|NETSDK1126|Publishing ReadyToRun using Crossgen2 is only supported for self-contained applications.|
|NETSDK1127|The targeting pack {0} is not installed. Please restore and try again.|
|NETSDK1128|COM hosting does not support self-contained deployments.|
|NETSDK1129|The 'Publish' target is not supported without specifying a target framework. The current project targets multiple frameworks, you must specify the framework for the published application.|
|[NETSDK1130](netsdk1130.md)|{1} cannot be referenced. Referencing a Windows Metadata component directly when targeting .NET 5 or higher is not supported. For more information, see <https://aka.ms/netsdk1130>.|
|NETSDK1131|Producing a managed Windows Metadata component with WinMDExp is not supported when targeting {0}.|
|NETSDK1132|No runtime pack information was available for {0}.|
|NETSDK1133|There was conflicting information about runtime packs available for {0}.|
|NETSDK1134|Building a solution with a specific RuntimeIdentifier is not supported. If you would like to publish for a single RID, specify the RID at the individual project level instead.|
|[NETSDK1135](netsdk1135.md)|SupportedOSPlatformVersion {0} cannot be higher than TargetPlatformVersion {1}.|
|[NETSDK1136](netsdk1136.md)|The target platform must be set to Windows (usually by including '-windows' in the TargetFramework property) when using Windows Forms or WPF, or referencing projects or packages that do so.|
|[NETSDK1137](netsdk1137.md)|It is no longer necessary to use the Microsoft.NET.Sdk.WindowsDesktop SDK. Consider changing the Sdk attribute of the root Project element to 'Microsoft.NET.Sdk'.|
|[NETSDK1138](netsdk1138.md)|The target framework '{0}' is out of support and will not receive security updates in the future. Please refer to <https://aka.ms/dotnet-core-support> for more information about the support policy.|
|NETSDK1139|The target platform identifier {0} was not recognized.|
|NETSDK1140|{0} is not a valid TargetPlatformVersion for {1}. Valid versions include:|
|[NETSDK1141](netsdk1141.md)|Unable to resolve the .NET SDK version as specified in the global.json located at {0}.|
|NETSDK1142|Including symbols in a single file bundle is not supported when publishing for .NET5 or higher.|
|NETSDK1143|Including all content in a single file bundle also includes native libraries. If IncludeAllContentForSelfExtract is true, IncludeNativeLibrariesForSelfExtract must not be false.|
|NETSDK1144|Optimizing assemblies for size failed. Optimization can be disabled by setting the PublishTrimmed property to false.|
|[NETSDK1145](netsdk1145.md)|The {0} pack is not installed and NuGet package restore is not supported. Upgrade Visual Studio, remove global.json if it specifies a certain SDK version, and uninstall the newer SDK. For more options visit <https://aka.ms/targeting-apphost-pack-missing>. Pack Type:{0}, Pack directory: {1}, targetframework: {2}, Pack PackageId: {3}, Pack Package Version: {4}.|
|NETSDK1146|PackAsTool does not support TargetPlatformIdentifier being set. For example, TargetFramework cannot be net5.0-windows, only net5.0. PackAsTool also does not support UseWPF or UseWindowsForms when targeting .NET 5 and higher.|
|[NETSDK1147](netsdk1147.md)|To build this project, the following workloads must be installed: {0}.|
|NETSDK1148|A referenced assembly was compiled using a newer version of Microsoft.Windows.SDK.NET.dll. Please update to a newer .NET SDK in order to reference this assembly.|
|[NETSDK1149](netsdk1149.md)|{0} cannot be referenced because it uses built-in support for WinRT, which is no longer supported in .NET 5 and higher. An updated version of the component supporting .NET 5 is needed. For more information, see <https://aka.ms/netsdk1149>.|
|NETSDK1150|The referenced project '{0}' is a non self-contained executable.  A non self-contained executable cannot be referenced by a self-contained executable.  For more information, see <https://aka.ms/netsdk1150>.|
|NETSDK1151|The referenced project '{0}' is a self-contained executable.  A self-contained executable cannot be referenced by a non self-contained executable.  For more information, see <https://aka.ms/netsdk1151>.|
|NETSDK1152|Found multiple publish output files with the same relative path: {0}.|
|NETSDK1153|CrossgenTool not specified in PDB compilation mode.|
|NETSDK1154|Crossgen2Tool must be specified when UseCrossgen2 is set to true.|
|NETSDK1155|Crossgen2Tool executable '{0}' not found.|
|NETSDK1156|.NET host executable '{0}' not found.|
|NETSDK1157|JIT library '{0}' not found.|
|NETSDK1158|Required '{0}' metadata missing on Crossgen2Tool item.|
|NETSDK1159|CrossgenTool must be specified when UseCrossgen2 is set to false.|
|NETSDK1160|CrossgenTool executable '{0}' not found.|
|NETSDK1161|DiaSymReader library '{0}' not found.|
|NETSDK1162|PDB generation: R2R executable '{0}' not found.|
|NETSDK1163|Input assembly '{0}' not found.|
|NETSDK1164|Missing output PDB path in PDB generation mode (OutputPDBImage metadata).|
|NETSDK1165|Missing output R2R image path (OutputR2RImage metadata).|
|NETSDK1166|Cannot emit symbols when publishing for .NET 5 with Crossgen2 using composite mode.|
|NETSDK1167|Compression in a single file bundle is only supported when publishing for .NET 6 or higher.|
|NETSDK1168|WPF is not supported or recommended with trimming enabled. Please go to <https://aka.ms/dotnet-illink/wpf> for more details.|
|NETSDK1169|The same resource ID {0} was specified for two type libraries '{1}' and '{2}'. Duplicate type library IDs are not allowed.|
|NETSDK1170|The provided type library ID '{0}' for type libary '{1}' is invalid. The ID must be a positive integer less than 65536.|
|NETSDK1171|An integer ID less than 65536 must be provided for type library '{0}' because more than one type library is specified.|
|NETSDK1172|The provided type library '{0}' does not exist.|
|NETSDK1173|The provided type library '{0}' is in an invalid format.|
|[NETSDK1174](netsdk1174.md)|The abbreviation of -p for --project is deprecated. Please use --project.|
|NETSDK1175|Windows Forms is not supported or recommended with trimming enabled. Please go to <https://aka.ms/dotnet-illink/windows-forms> for more details.|
|NETSDK1176|Compression in a single file bundle is only supported when publishing a self-contained application.|
|NETSDK1177|Failed to sign apphost with error code {1}: {0}.|
|NETSDK1178|The project depends on the following workload packs that do not exist in any of the workloads available in this installation: {0}.|
|NETSDK1179|One of '--self-contained' or '--no-self-contained' options are required when '--runtime' is used.|
|NETSDK1181|Error getting pack version: Pack '{0}' was not present in workload manifests.|
|[NETSDK1182](netsdk1182.md)|Targeting .NET 6.0 or higher in Visual Studio 2019 is not supported.|
|NETSDK1183|Unable to optimize assemblies for Ahead of time compilation: a valid runtime package was not found. Either set the PublishAot property to false, or use a supported runtime identifier when publishing. When targeting .NET 7 or higher, make sure to restore packages with the PublishAot property set to true.|
|NETSDK1184|The Targeting Pack for FrameworkReference '{0}' was not available. This may be because DisableTransitiveFrameworkReferenceDownloads was set to true.|
|NETSDK1185|The Runtime Pack for FrameworkReference '{0}' was not available. This may be because DisableTransitiveFrameworkReferenceDownloads was set to true.|
|NETSDK1186|This project depends on Maui Essentials through a project or NuGet package reference, but doesn't declare that dependency explicitly. To build this project, you must set the UseMauiEssentials property to true (and install the Maui workload if necessary).|
|NETSDK1187|Package {0} {1} has a resource with the locale '{2}'. This locale has been normalized to the standard format '{3}' to prevent casing issues in the build. Consider notifying the package author about this casing issue.|
|NETSDK1188|Package {0} {1} has a resource with the locale '{2}'. This locale is not recognized by .NET. Consider notifying the package author that it appears to be using an invalid locale.|
|NETSDK1189|Prefer32Bit is not supported and has no effect for netcoreapp target.|
|NETSDK1190|To use '{0}' in solution projects, you must set the environment variable '{1}' (to true). This will increase the time to complete the operation.|
|NETSDK1191|A runtime identifier for the property '{0}' couldn't be inferred. Specify a rid explicitly.|
|NETSDK1192|Targeting .NET 7.0 or higher in Visual Studio 2022 17.3 is not supported.|
