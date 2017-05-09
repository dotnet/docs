all: mydll.dll
mydll.dll : IVsDataSupportImportResolver.cs
 	csc /t:library /out:mydll.dll /r:"C:\Program Files\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration\Common\Assemblies\Microsoft.VisualStudio.Data.Core.dll","C:\Program Files\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration\Common\Assemblies\Microsoft.VisualStudio.Data.Services.dll" IVsDataSupportImportResolver.cs