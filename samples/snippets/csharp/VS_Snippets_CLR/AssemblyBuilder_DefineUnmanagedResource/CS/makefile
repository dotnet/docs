all : assemblybuilder_defineunmanagedresource.exe EmittedTest2.exe

assemblybuilder_defineunmanagedresource.exe : assemblybuilder_defineunmanagedresource.cs
	csc assemblybuilder_defineunmanagedresource.cs

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource.exe
	assemblybuilder_defineunmanagedresource.exe

EmittedTest2.exe : MyEmitTestAssembly.dll EmittedTest2.cs
	csc /r:MyEmitTestAssembly.dll EmittedTest2.cs