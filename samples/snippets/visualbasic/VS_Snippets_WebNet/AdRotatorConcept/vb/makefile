all:
	IF NOT EXIST App_Data md App_Data
	XCOPY Sample.ads App_Data /c /o /r /y
	XCOPY AdResponses.xml App_Data /c /o /r /y
	IF NOT EXIST Images md Images
	XCOPY Contoso_ad.gif Images /c /o /r /y
	XCOPY ASPNET_ad.gif Images /c /o /r /y
