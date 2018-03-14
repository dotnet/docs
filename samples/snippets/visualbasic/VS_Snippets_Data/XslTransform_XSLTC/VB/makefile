all: Transform.dll XslTransform_XSLTC.dll
 
Transform.dll: Transform.xslt
 xsltc /settings:script+ Transform.xslt 
 
XslTransform_XSLTC.dll: XslTransform_XSLTC.vb
 vbc /r:Transform.dll XslTransform_XSLTC.vb