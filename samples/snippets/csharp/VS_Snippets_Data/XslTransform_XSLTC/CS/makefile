all: Transform.dll XslTransform_XSLTC.dll
 
Transform.dll: Transform.xslt
 xsltc /settings:script+ Transform.xslt 
 
XslTransform_XSLTC.dll: XslTransform_XSLTC.cs
 csc /r:Transform.dll XslTransform_XSLTC.cs 