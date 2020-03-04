all : assemblybuilder_defineunmanagedresource2.exe EmittedTest3.exe

assemblybuilder_defineunmanagedresource2.exe : assemblybuilder_defineunmanagedresource2.vb
	vbc assemblybuilder_defineunmanagedresource2.vb

MyEmitTestAssembly.dll : assemblybuilder_defineunmanagedresource2.exe
	assemblybuilder_defineunmanagedresource2.exe

EmittedTest3.exe : MyEmitTestAssembly.dll EmittedTest3.vb
	vbc /r:MyEmitTestAssembly.dll EmittedTest3.vb