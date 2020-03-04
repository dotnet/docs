
all : control_state.dll
control_state.dll : control_state.cs
	csc /t:library /out:control_state.dll control_state.cs
	IF NOT EXIST bin md bin
	copy control_state.dll bin