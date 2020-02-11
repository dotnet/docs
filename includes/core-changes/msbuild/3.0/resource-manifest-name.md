### Resource file names



#### Version introduced

3.0

#### Change description

Prior to .NET Core 3.0, when [DependentUpon](/visualstudio/msbuild/common-msbuild-project-items#compile) metadata was set for a resource file in the MSBuild project file, the generated manifest name was *Namespace.Classname.resources*. When [DependentUpon](/visualstudio/msbuild/common-msbuild-project-items#compile) was not set, the generated manifest name was Namespace.Classname.FolderPathRelativeToRoot.Culture.resources.

Starting in .NET Core 3.0, when a *.resx* file is associated with a type, for example, in Windows Forms apps, it's assumed that the resource is named *Namespace.Classname\[.Culture].resources*. From this convention, the rules around how the root namespace and folders impact the chosen name mirror how Visual Studio picks a namespace and name for a new class: *Namespace.FoldersSeparatedByDots.FileName.(resx|resources|cs)*.

##### Rules that determine resource file names

If you leave all the defaults when you add files and resources in Visual Studio, then when *Type.cs* is colocated with *Type.resx*, the generated manifest name is *Namespace.Classname.resources*.

If you don't use the default settings, there are more considerations as to how the manifest name is generated:

- If the `LogicalName` attribute on the `EmbeddedResource` element is set, that value is used as the resource file name.

  Examples:

  `<EmbeddedResource Include="X.resx" LogicalName="SomeName.resources" />`
  `<EmbeddedResource Include="X.fr-FR.resx" LogicalName="SomeName.resources" />`

  Generated resource name: *SomeName.resources* (regardless of the *.resx* file name or culture or any other metadata)

- If `LogicalName` is not set, but the `ManifestResourceName` attribute on the `EmbeddedResource` element is set, its value, combined with the file extension *.resources* is used as the resource file name.

  Examples:

  `<EmbeddedResource Include="X.resx" ManifestResourceName="SomeName" />`

  Generated resource name: *SomeName.resources*

  `<EmbeddedResource Include="X.fr-FR.resx" ManifestResourceName="SomeName.fr-FR" />`

  Generated resource name: *SomeName.fr-FR.resources*

- If `LogicalName` and `ManifestResourceName` are not set, but the `DependentUpon` attribute on the `EmbeddedResource` element is set to a source file, the type name of the first class in the source file is used in the resource file name. More specifically, the generated file name is *Namespace.Classname\[.Culture].resources*.

  Examples:

  `<EmbeddedResource Include="X.resx" DependentUpon="MyTypes.cs">`

  Generated resource name: *Namespace.Classname.resources*

  `<EmbeddedResource Include="X.fr-FR.resx" DependentUpon="MyTypes.cs">`

  Generated resource name: *Namespace.Classname.fr-FR.resources*

- 

#### Recommended action

If you're unsatisfied with the generated manifest names, you can:

- Modify your resource file metadata according to one of the [previously described rules](#rules-that-determine-resource-file-names)

- Set `EmbeddedResourceUseDependentUponConvention` to `false` in your project file to opt out of the new convention entirely:

   ```xml
   <EmbeddedResourceUseDependentUponConvention>false</EmbeddedResourceUseDependentUponConvention>
   ```

   > [!NOTE]
   > The first two [rules](#rules-that-determine-resource-file-names) still apply (`LogicalName` and `ManifestResourceName` attributes).

#### Category

MSBuild

#### Affected APIs

<!--

#### Affected APIs

-->
