### Resource manifest file names

Starting in .NET Core 3.0, the generated resource manifest file name has changed.

#### Version introduced

3.0

#### Change description

Prior to .NET Core 3.0, when [DependentUpon](/visualstudio/msbuild/common-msbuild-project-items#compile) metadata was set for a resource (*.resx*) file in the MSBuild project file, the generated manifest name was *Namespace.Classname.resources*. When [DependentUpon](/visualstudio/msbuild/common-msbuild-project-items#compile) was not set, the generated manifest name was *Namespace.Classname.FolderPathRelativeToRoot.Culture.resources*.

Starting in .NET Core 3.0, when a *.resx* file is colocated with a source file of the same name, for example, in Windows Forms apps, the resource manifest name is generated from the full name of the first type in the source file. For example, if *Type.cs* is colocated with *Type.resx*, the generated manifest name is *Namespace.Classname.resources*. However, if you modify any of the attributes on the `EmbeddedResource` property for the *.resx* file, the generated manifest file name may be different:

- If the `LogicalName` attribute on the `EmbeddedResource` property is set, that value is used as the resource manifest file name.

  Examples:

  ```xml
  <EmbeddedResource Include="X.resx" LogicalName="SomeName.resources" />
  -or-
  <EmbeddedResource Include="X.fr-FR.resx" LogicalName="SomeName.resources" />
  ```

  **Generated resource manifest file name**: *SomeName.resources* (regardless of the *.resx* file name or culture or any other metadata).

- If `LogicalName` is not set, but the `ManifestResourceName` attribute on the `EmbeddedResource` property is set, its value, combined with the file extension *.resources*, is used as the resource manifest file name.

  Examples:

  ```xml
  <EmbeddedResource Include="X.resx" ManifestResourceName="SomeName" />
  -or-
  <EmbeddedResource Include="X.fr-FR.resx" ManifestResourceName="SomeName.fr-FR" />
  ```

  **Generated resource manifest file name**: *SomeName.resources* or *SomeName.fr-FR.resources*.

- If the previous rules don't apply, and the `DependentUpon` attribute on the `EmbeddedResource` element is set to a source file, the type name of the first class in the source file is used in the resource manifest file name. More specifically, the generated file name is *Namespace.Classname\[.Culture].resources*.

  Examples:

  ```xml
  <EmbeddedResource Include="X.resx" DependentUpon="MyTypes.cs">
  -or-
  <EmbeddedResource Include="X.fr-FR.resx" DependentUpon="MyTypes.cs">
  ```

  **Generated resource manifest file name**: *Namespace.Classname.resources* or *Namespace.Classname.fr-FR.resources* (where `Namespace.Classname` is the name of the first class in *MyTypes.cs*).

- If the previous rules don't apply, `EmbeddedResourceUseDependentUponConvention` is `true` (the default for .NET Core), and there's a source file colocated with a *.resx* file that has the same base file name, the *.resx* file is made dependent upon the matching source file, and the generated name is the same as in the previous rule. This is the "default settings" rule for .NET Core projects.
  
  Examples:
  
  Files *MyTypes.cs* and *MyTypes.resx* or *MyTypes.fr-FR.resx* exist in the same folder.
  
  **Generated resource manifest file name**: *Namespace.Classname.resources* or *Namespace.Classname.fr-FR.resources* (where `Namespace.Classname` is the name of the first class in *MyTypes.cs*).

- If none of the previous rules apply, the generated resource manifest file name is *RootNamespace.RelativePathWithDotsForSlashes.\[Culture.]resources*. The relative path is the value of the `Link` attribute of the `EmbeddedResource` element if it's set. Otherwise, the relative path is the value of the `Identity` attribute of the `EmbeddedResource` element. In Visual Studio, this is the path from the project root to the file in Solution Explorer.

#### Recommended action

If you're unsatisfied with the generated manifest names, you can:

- Modify your resource file metadata according to one of the previously described naming rules.

- Set `EmbeddedResourceUseDependentUponConvention` to `false` in your project file to opt out of the new convention entirely:

   ```xml
   <EmbeddedResourceUseDependentUponConvention>false</EmbeddedResourceUseDependentUponConvention>
   ```

   > [!NOTE]
   > If the `LogicalName` or `ManifestResourceName` attributes are present, their values will still be used for the generated file name.

#### Category

MSBuild

#### Affected APIs

N/A
