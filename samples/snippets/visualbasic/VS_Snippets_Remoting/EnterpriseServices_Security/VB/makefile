all: EmployeeInformation.dll
EmployeeInformation.snk:
	sn -k EmployeeInformation.snk
EmployeeInformation.dll: EmployeeInformation.vb EmployeeInformation.snk
	vbc /nologo /t:library EmployeeInformation.vb
install: EmployeeInformation.dll
	regsvcs EmployeeInformation.dll
