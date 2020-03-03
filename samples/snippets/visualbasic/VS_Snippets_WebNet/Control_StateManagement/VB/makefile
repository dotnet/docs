
all : control_state.dll
control_state.dll : control_state.vb
	vbc /t:library /out:control_state.dll control_state.vb
	IF NOT EXIST bin md bin
	copy control_state.dll bin