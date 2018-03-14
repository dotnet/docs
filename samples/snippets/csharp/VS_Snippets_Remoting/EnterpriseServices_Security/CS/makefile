all: EmployeeInformation.dll
EmployeeInformation.snk:
	sn -k EmployeeInformation.snk
EmployeeInformation.dll: EmployeeInformation.cs EmployeeInformation.snk
	csc /nologo /t:library EmployeeInformation.cs
install: EmployeeInformation.dll
	regsvcs EmployeeInformation.dll
