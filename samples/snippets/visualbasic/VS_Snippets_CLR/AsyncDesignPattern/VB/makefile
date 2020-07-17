all: stateobject.exe nostateObject.exe endblock.exe endblockwait.exe poll.exe factor.exe

stateobject.exe : AsyncDelegateWithStateObject.vb
	vbc AsyncDelegateWithStateObject.vb


nostateObject.exe : AsyncDelegateNoState.vb
	vbc AsyncDelegateNoState.vb

endblock.exe : Async_EndBlock.vb
	vbc Async_EndBlock.vb

endblockwait.exe : Async_EndBlockWait.vb
	vbc Async_EndBlockWait.vb

poll.exe : Async_Poll.vb
	vbc Async_Poll.vb

factor.exe : Factorizer.vb
	vbc Factorizer.vb

