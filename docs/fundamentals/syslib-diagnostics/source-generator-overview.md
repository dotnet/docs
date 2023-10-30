---
title: Analyzer diagnostics in .NET 6+
description: Learn about analyzer diagnostics created by source generators in .NET 6 and later versions that produce SYSLIB compiler warnings.
ms.date: 10/27/2023
---

# Source-generator diagnostics in .NET 6+

If your .NET 6+ project references a package that enables source generation of code, for example, a logging solution, then the analyzers that are specific to source generation will run at compile time. This article lists the compiler diagnostics related to source-generated code.

If you encounter one of these build warnings or errors, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. You can also suppress warnings using the specific `SYSLIB1XXX` diagnostic ID value. For more information, see [Suppress warnings](#suppress-warnings).

## Analyzer warnings

The diagnostic ID values reserved for source-generated code analyzer warnings are `SYSLIB1001` through `SYSLIB1999`.

## Reference

The following table provides an index to the `SYSLIB1XXX` diagnostics in .NET 6 and later versions.

| Diagnostic ID      | Description                                                                                                  |
|--------------------|--------------------------------------------------------------------------------------------------------------|
| [SYSLIB1001][1001] | Logging method names cannot start with `_`                                                                   |
| [SYSLIB1002][1002] | Don't include log level parameters as templates in the logging message                                       |
| [SYSLIB1003][1003] | `InvalidLoggingMethodParameterNameTitle`                                                                     |
| SYSLIB1004 | Logging class cannot be in nested types.                                                                     |
| [SYSLIB1005][1005] | Could not find a required type definition                                                                    |
| [SYSLIB1006][1006] | Multiple logging methods cannot use the same event ID within a class                                         |
| [SYSLIB1007][1007] | Logging methods must return `void`                                                                           |
| [SYSLIB1008][1008] | One of the arguments to a logging method must implement the `Microsoft.Extensions.Logging.ILogger` interface |
| [SYSLIB1009][1009] | Logging methods must be `static`                                                                             |
| [SYSLIB1010][1010] | Logging methods must be `partial`                                                                            |
| [SYSLIB1011][1011] | Logging methods cannot be generic                                                                            |
| [SYSLIB1012][1012] | Redundant qualifier in logging message                                                                       |
| [SYSLIB1013][1013] | Don't include exception parameters as templates in the logging message                                       |
| [SYSLIB1014][1014] | Logging template has no corresponding method argument                                                        |
| [SYSLIB1015][1015] | Argument is not referenced from the logging message                                                          |
| [SYSLIB1016][1016] | Logging methods cannot have a body                                                                           |
| [SYSLIB1017][1017] | A LogLevel value must be supplied in the `LoggerMessage` attribute or as a parameter to the logging method   |
| [SYSLIB1018][1018] | Don't include logger parameters as templates in the logging message                                          |
| [SYSLIB1019][1019] | Couldn't find a field of type `Microsoft.Extensions.Logging.ILogger`                                         |
| [SYSLIB1020][1020] | Found multiple fields of type `Microsoft.Extensions.Logging.ILogger`                                         |
| [SYSLIB1021][1021] | Multiple message-template item names differ only by case |
| [SYSLIB1022][1022] | Can't have malformed format strings (for example, dangling curly braces) |
| [SYSLIB1023][1023] | Generating more than six arguments is not supported |
| SYSLIB1024 | Logging method argument uses unsupported `out` parameter modifier |
| SYSLIB1025 | Multiple logging methods cannot use the same event name within a class |
| SYSLIB1026 | C# language version not supported by the logging source generator. |
| SYSLIB1027 | (Reserved for logging.) |
| SYSLIB1028 | (Reserved for logging.) |
| SYSLIB1029 | (Reserved for logging.) |
| [SYSLIB1030][1030] | The `System.Text.Json` source generator did not generate serialization metadata for type |
| [SYSLIB1031][1031] | The `System.Text.Json` source generator encountered a duplicate `JsonTypeInfo` property name |
| [SYSLIB1032][1032] | The `System.Text.Json` source generator encountered a context class that is not partial |
| [SYSLIB1033][1033] | The `System.Text.Json` source generator encountered a type that has multiple `[JsonConstructor]` annotations |
| [SYSLIB1034][1034] | JsonSourceGenerator encountered a `JsonStringEnumConverter` annotation |
| [SYSLIB1035][1035] | The `System.Text.Json` source generator encountered a type that has multiple `[JsonExtensionData]` annotations |
| [SYSLIB1036][1036] | The `System.Text.Json` source generator encountered an invalid `[JsonExtensionData]` annotation |
| [SYSLIB1037][1037] | The `System.Text.Json` source generator encountered a type with init-only properties for which deserialization is not supported |
| [SYSLIB1038][1038] | The `System.Text.Json` source generator encountered a property annotated with `[JsonInclude]` that has inaccessible accessors |
| [SYSLIB1039][1039] | JsonSourceGenerator encountered a `JsonDerivedTypeAttribute` annotation with `JsonSourceGenerationMode.Serialization` enabled |
| [SYSLIB1040][1040] | Invalid <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> usage. |
| [SYSLIB1041][1041] | Multiple <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attributes were applied to the same method, but only one is allowed. |
| [SYSLIB1042][1042] | The specified regular expression is invalid. |
| [SYSLIB1043][1043] | A <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> method must be partial, parameterless, non-generic, and non-abstract, and return <xref:System.Text.RegularExpressions.Regex>. |
| [SYSLIB1044][1044] | The regex generator couldn't generate a complete source implementation for the specified regular expression due to an internal limitation. See the explanation in the generated source for more details. |
| [SYSLIB1045][1045] | Use <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> to generate the regular expression implementation at compile time. |
| [SYSLIB1046][1046] | (Reserved for System.Text.RegularExpressions.Generator.) |
| [SYSLIB1047][1047] | (Reserved for System.Text.RegularExpressions.Generator.) |
| [SYSLIB1048][1048] | (Reserved for System.Text.RegularExpressions.Generator.) |
| [SYSLIB1049][1049] | (Reserved for System.Text.RegularExpressions.Generator.) |
| [SYSLIB1050][1050] | Invalid <xref:System.Runtime.InteropServices.LibraryImportAttribute> usage. |
| [SYSLIB1051][1051] | The specified type is not supported by source-generated p/invokes. |
| [SYSLIB1052][1052] | The specified configuration is not supported by source-generated p/invokes. |
| [SYSLIB1053][1053] | The specified <xref:System.Runtime.InteropServices.LibraryImportAttribute> arguments cannot be forwarded to <xref:System.Runtime.InteropServices.DllImportAttribute>. |
| [SYSLIB1054][1054] | Use <xref:System.Runtime.InteropServices.LibraryImportAttribute> instead of <xref:System.Runtime.InteropServices.DllImportAttribute> to generate p/invoke marshalling code at compile time. |
| [SYSLIB1055][1055] | Invalid <xref:System.Runtime.InteropServices.Marshalling.CustomMarshallerAttribute> usage. |
| [SYSLIB1056][1056] | The specified native type is invalid. |
| [SYSLIB1057][1057] | The marshaller type does not have the required shape. |
| [SYSLIB1058][1058] | Invalid <xref:System.Runtime.InteropServices.Marshalling.NativeMarshallingAttribute> usage. |
| [SYSLIB1059][1059] | The marshaller type does not support an allocating constructor. |
| [SYSLIB1060][1060] | The specified marshaller type is invalid. |
| [SYSLIB1061][1061] | The marshaller type has incompatible method signatures. |
| [SYSLIB1062][1062] | The project must be updated with `<AllowUnsafeBlocks>true</AllowUnsafeBlocks>`. |
| [SYSLIB1063][1063] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1064][1064] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1065][1065] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1066][1066] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1067][1067] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1068][1068] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1069][1069] | (Reserved for Microsoft.Interop.LibraryImportGenerator.) |
| [SYSLIB1070][1070] | Invalid <xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute> usage. |
| [SYSLIB1071][1071] | Invalid <xref:System.Runtime.InteropServices.JavaScript.JSExportAttribute> usage. |
| [SYSLIB1072][1072] | The specified type is not supported by source-generated JavaScript interop. |
| [SYSLIB1073][1073] | The specified configuration is not supported by source-generated JavaScript interop. |
| [SYSLIB1074][1074] | <xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute> requires unsafe code. |
| [SYSLIB1075][1075] | <xref:System.Runtime.InteropServices.JavaScript.JSImportAttribute> requires unsafe code. |
| [SYSLIB1076][1076] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1077][1077] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1078][1078] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1079][1079] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1080][1080] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1081][1081] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1082][1082] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1083][1083] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1084][1084] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1085][1085] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1086][1086] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1087][1087] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1088][1088] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1089][1089] | (Reserved for System.Runtime.InteropServices.JavaScript.JSImportGenerator.) |
| [SYSLIB1090][1090] | Invalid `GeneratedComInterfaceAttribute` usage. |
| [SYSLIB1091][1091] | Method is declared in different partial declaration than the `GeneratedComInterface` attribute. |
| [SYSLIB1092][1092] | Usage of `LibraryImport` or `GeneratedComInterface` attribute does not follow recommendation. |
| [SYSLIB1093][1093] | Analysis for COM interface generation has failed. |
| [SYSLIB1094][1094] | The base COM interface failed to generate source. Code will not be generated for this interface. |
| [SYSLIB1095][1095] | Invalid `GeneratedComClassAttribute` usage. |
| [SYSLIB1096][1096] | Use `GeneratedComInterfaceAttribute` instead of `ComImportAttribute` to generate COM marshalling code at compile time. |
| [SYSLIB1097][1097] | This type implements at least one type with the `GeneratedComInterfaceAttribute` attribute. Add the `GeneratedComClassAttribute` to enable passing this type to COM and exposing the COM interfaces for the types with the `GeneratedComInterfaceAttribute` from objects of this type. |
| [SYSLIB1098][1098] | .NET COM hosting with `EnableComHosting` only supports built-in COM interop. It does not support source-generated COM interop with `GeneratedComInterfaceAttribute`. |
| [SYSLIB1099][1099] | COM Interop APIs on `System.Runtime.InteropServices.Marshal` do not support source-generated COM and will fail at run time. |
| [SYSLIB1100][1100] | Configuration binding generator: Type is not supported. |
| [SYSLIB1101][1101] | Configuration binding generator: Property on type is not supported. |
| [SYSLIB1102][1102] | Configuration binding generator: Project's language version must be at least C# 11. |
| [SYSLIB1103][1103] | Configuration binding generator: Value types are invalid inputs to configuration 'Bind' methods. |
| [SYSLIB1104][1104] | Configuration binding generator: Generator cannot determine the target configuration type. |
| [SYSLIB1105][1105] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1106][1106] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.)(Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.)  |
| [SYSLIB1107][1107] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1108][1108] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1109][1109] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1110][1110] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1111][1111] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1112][1112] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1113][1113] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1114][1114] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1115][1115] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1116][1116] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1117][1117] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1118][1118] | (Reserved for Microsoft.Extensions.Configuration.Binder.SourceGeneration.) |
| [SYSLIB1201][1201] | Can't use `ValidateObjectMembersAttribute` or `ValidateEnumeratedItemsAttribute` on fields or properties with open generic types. |
| [SYSLIB1202][1202] | A member type has no fields or properties to validate. |
| [SYSLIB1203][1203] | A type has no fields or properties to validate. |
| [SYSLIB1204][1204] | A type annotated with `OptionsValidatorAttribute` doesn't implement the necessary interface. |
| [SYSLIB1205][1205] | A type already includes an implementation of the 'Validate' method. |
| [SYSLIB1206][1206] | Can't validate private fields or properties. |
| [SYSLIB1207][1207] | Member type is not enumerable. |
| [SYSLIB1208][1208] | Validators used for transitive or enumerable validation must have a constructor with no parameters. |
| [SYSLIB1209][1209] | `OptionsValidatorAttribute` can't be applied to a static class. |
| [SYSLIB1210][1210] | Null validator type specified for the `ValidateObjectMembersAttribute` or `ValidateEnumeratedItemsAttribute` attributes. |
| [SYSLIB1211][1211] | Unsupported circular references in model types. |
| [SYSLIB1212][1212] | Member potentially missing transitive validation. |
| [SYSLIB1213][1213] | Member potentially missing enumerable validation. |
| [SYSLIB1214][1214] | Can't validate constants, static fields, or properties. |
| [SYSLIB1215][1215] | Validation attribute on the member is inaccessible from the validator type. |
| [SYSLIB1216][1216] | C# language version not supported by the options validation source generator. |
| [SYSLIB1217][1217] | The validation attribute is only applicable to properties of type string, array, or `ICollection`; it cannot be used with other types. |
| [SYSLIB1218][1218] | (Reserved for Microsoft.Extensions.Options.SourceGeneration.) |
| [SYSLIB1219][1219] | (Reserved for Microsoft.Extensions.Options.SourceGeneration.) |
| [SYSLIB1220][1220] | JsonSourceGenerator encountered a [JsonConverterAttribute] with an invalid type argument. |
| [SYSLIB1221][1221] | JsonSourceGenerator does not support this C# language version. |
| [SYSLIB1222][1222] | Constructor annotated with JsonConstructorAttribute is inaccessible. |
| [SYSLIB1223][1223] | Constructor annotated with JsonConstructorAttribute is inaccessible. |
| [SYSLIB1224][1224] | Types annotated with JsonSerializableAttribute must be classes deriving from JsonSerializerContext. |
| [SYSLIB1225][1225] | (Reserved for System.Text.Json.SourceGeneration.) |
| [SYSLIB1226][1226] | (Reserved for System.Text.Json.SourceGeneration.) |
| [SYSLIB1227][1227] | (Reserved for System.Text.Json.SourceGeneration.) |
| [SYSLIB1228][1228] | (Reserved for System.Text.Json.SourceGeneration.) |
| [SYSLIB1229][1229] | (Reserved for System.Text.Json.SourceGeneration.) |

<!-- Include adds ## Suppress warnings (H2 heading) -->
[!INCLUDE [suppress-source-generator-diagnostics](includes/suppress-source-generator-diagnostics.md)]

[1001]: syslib1001.md
[1002]: syslib1002.md
[1003]: syslib1003.md
[1005]: syslib1005.md
[1006]: syslib1006.md
[1007]: syslib1007.md
[1008]: syslib1008.md
[1009]: syslib1009.md
[1010]: syslib1010.md
[1011]: syslib1011.md
[1012]: syslib1012.md
[1013]: syslib1013.md
[1014]: syslib1014.md
[1015]: syslib1015.md
[1016]: syslib1016.md
[1017]: syslib1017.md
[1018]: syslib1018.md
[1019]: syslib1019.md
[1020]: syslib1020.md
[1021]: syslib1021.md
[1022]: syslib1022.md
[1023]: syslib1023.md
[1030]: syslib1030.md
[1031]: syslib1031.md
[1032]: syslib1032.md
[1033]: syslib1033.md
[1034]: syslib1034.md
[1035]: syslib1035.md
[1036]: syslib1036.md
[1037]: syslib1037.md
[1038]: syslib1038.md
[1039]: syslib1039.md
[1040]: syslib1040-1049.md
[1041]: syslib1040-1049.md
[1042]: syslib1040-1049.md
[1043]: syslib1040-1049.md
[1044]: syslib1040-1049.md
[1045]: syslib1040-1049.md
[1046]: syslib1040-1049.md
[1047]: syslib1040-1049.md
[1048]: syslib1040-1049.md
[1049]: syslib1040-1049.md
[1050]: syslib1050-1069.md
[1051]: syslib1050-1069.md
[1052]: syslib1050-1069.md
[1053]: syslib1050-1069.md
[1054]: syslib1050-1069.md
[1055]: syslib1050-1069.md
[1056]: syslib1050-1069.md
[1057]: syslib1050-1069.md
[1058]: syslib1050-1069.md
[1059]: syslib1050-1069.md
[1060]: syslib1050-1069.md
[1061]: syslib1050-1069.md
[1062]: syslib1050-1069.md
[1063]: syslib1050-1069.md
[1064]: syslib1050-1069.md
[1065]: syslib1050-1069.md
[1066]: syslib1050-1069.md
[1067]: syslib1050-1069.md
[1068]: syslib1050-1069.md
[1069]: syslib1050-1069.md
[1070]: syslib1070-1089.md
[1071]: syslib1070-1089.md
[1072]: syslib1070-1089.md
[1073]: syslib1070-1089.md
[1074]: syslib1070-1089.md
[1075]: syslib1070-1089.md
[1076]: syslib1070-1089.md
[1077]: syslib1070-1089.md
[1078]: syslib1070-1089.md
[1079]: syslib1070-1089.md
[1080]: syslib1070-1089.md
[1081]: syslib1070-1089.md
[1082]: syslib1070-1089.md
[1083]: syslib1070-1089.md
[1084]: syslib1070-1089.md
[1085]: syslib1070-1089.md
[1086]: syslib1070-1089.md
[1087]: syslib1070-1089.md
[1088]: syslib1070-1089.md
[1089]: syslib1070-1089.md
[1090]: syslib1090-1099.md
[1091]: syslib1090-1099.md
[1092]: syslib1090-1099.md
[1093]: syslib1090-1099.md
[1094]: syslib1090-1099.md
[1095]: syslib1090-1099.md
[1096]: syslib1090-1099.md
[1097]: syslib1090-1099.md
[1098]: syslib1090-1099.md
[1099]: syslib1090-1099.md
[1100]: syslib1100-1118.md
[1101]: syslib1100-1118.md
[1102]: syslib1100-1118.md
[1103]: syslib1100-1118.md
[1104]: syslib1100-1118.md
[1105]: syslib1100-1118.md
[1106]: syslib1100-1118.md
[1107]: syslib1100-1118.md
[1108]: syslib1100-1118.md
[1109]: syslib1100-1118.md
[1110]: syslib1100-1118.md
[1111]: syslib1100-1118.md
[1112]: syslib1100-1118.md
[1113]: syslib1100-1118.md
[1114]: syslib1100-1118.md
[1115]: syslib1100-1118.md
[1116]: syslib1100-1118.md
[1117]: syslib1100-1118.md
[1118]: syslib1100-1118.md
[1201]: syslib1201-1219.md
[1202]: syslib1201-1219.md
[1203]: syslib1201-1219.md
[1204]: syslib1201-1219.md
[1205]: syslib1201-1219.md
[1206]: syslib1201-1219.md
[1207]: syslib1201-1219.md
[1208]: syslib1201-1219.md
[1209]: syslib1201-1219.md
[1210]: syslib1201-1219.md
[1211]: syslib1201-1219.md
[1212]: syslib1201-1219.md
[1213]: syslib1201-1219.md
[1214]: syslib1201-1219.md
[1215]: syslib1201-1219.md
[1216]: syslib1201-1219.md
[1217]: syslib1201-1219.md
[1218]: syslib1201-1219.md
[1219]: syslib1201-1219.md
[1220]: syslib1220-1229.md
[1221]: syslib1220-1229.md
[1222]: syslib1220-1229.md
[1223]: syslib1220-1229.md
[1224]: syslib1220-1229.md
[1225]: syslib1220-1229.md
[1226]: syslib1220-1229.md
[1227]: syslib1220-1229.md
[1228]: syslib1220-1229.md
[1229]: syslib1220-1229.md
