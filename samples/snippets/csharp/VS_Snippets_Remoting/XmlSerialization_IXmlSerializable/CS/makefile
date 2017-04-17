all: Reader.exe Writer.exe
Reader.exe: Reader.cs Person.cs
	csc Reader.cs Person.cs
Writer.exe: Writer.cs Person.cs
	csc Writer.cs Person.cs
clean:
	del *.exe
