all: mqbeginreceive_noparms_mre.dll mqbeginreceive_noparms_wh.dll
mqbeginreceive_noparms_mre.dll: mqbeginreceive_noparms_mre.cs
	csc /t:library mqbeginreceive_noparms_mre.cs

mqbeginreceive_noparms_wh.dll: mqbeginreceive_noparms_wh.cs mqbeginreceive_noparms_mre.dll
	csc /t:library mqbeginreceive_noparms_wh.cs
