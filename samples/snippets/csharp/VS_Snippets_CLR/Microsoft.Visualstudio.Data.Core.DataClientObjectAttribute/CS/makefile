all: mydll.dll
mydll.dll : DataClientObjectAttrib.cs DataClientObjectAttrib2.cs
 	csc /t:library /out:mydll.dll /r:"C:\Program Files\Microsoft Visual Studio 2008 SDK\VisualStudioIntegration\Common\Assemblies\Microsoft.VisualStudio.Data.Core.dll" DataClientObjectAttrib.cs DataClientObjectAttrib2.cs