all : ClientCloneBasic.exe 
ClientCloneBasic.exe: ClientCloneBasic.vb  Authorization_Constructor3.vb
	vbc /t:library Authorization_Constructor3.vb
        vbc /r:Authorization_Constructor3.dll ClientCloneBasic.vb