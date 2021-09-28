all: testMethod.dll EndInvoke.exe WaitHandle.exe polling.exe callback.exe

testMethod.dll :testmethod.vb
	vbc /t:library testmethod.vb


EndInvoke.exe: endinvoke.vb testMethod.dll
	vbc /out:endinvoke.exe endinvoke.vb /r:testmethod.dll


WaitHandle.exe: waithandle.vb testMethod.dll
	vbc /out:waithandle.exe waithandle.vb /r:testmethod.dll

polling.exe: polling.vb testmethod.dll
	vbc /out:polling.exe polling.vb /r:testmethod.dll



callback.exe: callback.vb testmethod.dll
	vbc /out:callback.exe callback.vb /r:testmethod.dll

clean:
	del *.dll
	del *.exe