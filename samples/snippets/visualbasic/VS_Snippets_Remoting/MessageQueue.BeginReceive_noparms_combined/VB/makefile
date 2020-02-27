all: mqbeginreceive_noparms_mre.dll mqbeginreceive_noparms_wh.dll
mqbeginreceive_noparms_mre.dll: mqbeginreceive_noparms_mre.vb
	vbc /t:library mqbeginreceive_noparms_mre.vb

mqbeginreceive_noparms_wh.dll: mqbeginreceive_noparms_wh.vb mqbeginreceive_noparms_mre.dll
	vbc /t:library mqbeginreceive_noparms_wh.vb
