all: mydll.dll
mydll.dll : IVsDataSource.cs IVsDataSource2.cs IVsDataSource3.cs 
 	csc /t:library /out:mydll.dll /r:"C:\Program Files\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration\Common\Assemblies\Microsoft.VisualStudio.Data.Core.dll" IVsDataSource.cs IVsDataSource2.cs IVsDataSource3.cs