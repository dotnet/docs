all : assemblybuilder_defineunmanagedresource2.exe EmittedTest3.exe

assemblybuilder_defineunmanagedresource2.exe : assemblybuilder_defineunmanagedresource2.cs
	csc assemblybuilder_defineunmanagedresource2.cs

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource2.exe
	assemblybuilder_defineunmanagedresource2.exe

EmittedTest3.exe : MyEmitTestAssembly.dll EmittedTest3.cs
	csc /r:MyEmitTestAssembly.dll EmittedTest3.cs