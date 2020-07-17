all: testMethod.dll EndInvoke.exe WaitHandle.exe polling.exe Callback.exe

testMethod.dll: testmethod.cs
	csc /t:library testmethod.cs


EndInvoke.exe: endinvoke.cs testMethod.dll
	csc /out:endinvoke.exe endinvoke.cs /r:testmethod.dll


WaitHandle.exe: waithandle.cs testMethod.dll
	csc /out:waithandle.exe waithandle.cs /r:testmethod.dll

polling.exe: polling.cs testmethod.dll
	csc /out:polling.exe polling.cs /r:testmethod.dll

Callback.exe: Callback.cs testmethod.dll
	csc /out:Callback.exe Callback.cs /r:testmethod.dll
clean:
	del *.dll
	del *.exe