---
title: "Recoverable XSLT Errors"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 484929b0-fefb-4629-87ee-ebdde70ff1f8
caps.latest.revision: 2
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# Recoverable XSLT Errors
The W3C XSL Transformations (XSLT) Version 1.0 Recommendation includes areas in which the implementation provider may decide how to handle a situation. These areas are considered to be discretionary behavior. For example, in section 7.3 Creating Processing Instructions, the XSLT 1.0 recommendation states that it is an error if instantiating the content of `xsl:processing-instruction` creates nodes other than text nodes. For some problems, the XSLT 1.0 recommendation indicates what decision should be made if the processor decides to recover from the error. For the problem given in section 7.3, the W3C says that the implementation can recover from this error by ignoring the nodes and their content.  
  
## Discretionary Behaviors  
 The following table lists each of the discretionary behaviors allowed by the XSLT 1.0 recommendation, and how these behaviors are handled by the <xref:System.Xml.Xsl.XslCompiledTransform> class.  
  
-   Recover indicates that the <xref:System.Xml.Xsl.XslCompiledTransform> class will recover from this error. The <xref:System.Xml.Xsl.XsltArgumentList.XsltMessageEncountered?displayProperty=nameWithType> event can be used to report any events from the XSLT processor.  
  
-   Error indicates that an exception is raised for this condition.  
  
-   The section references can be found in the [W3C XSL Transformations (XSLT) Version 1.0 Recommendation](http://www.w3.org/TR/xslt) and the [W3C XSL Transformations (XSLT) Version 1.0 Specification Errata](https://www.w3.org/1999/11/REC-xslt-19991116-errata/).  
  
|XSLT condition|Section|XslCompiledTransform behavior|  
|--------------------|-------------|-----------------------------------|  
|A text node matches both `xsl:strip-space` and `xsl:preserve-space`.|3.4|Recover|  
|A source node matches more than one template rule.|5.5|Recover|  
|A namespace URI is declared to be an alias for multiple namespace URIs, all having the same import precedence.|7.1.1|Recover|  
|The `name` attribute in `xsl:attribute` and `xsl:element` generated from an attribute value is not a QName.|7.1.2, 7.1.3|Error*|  
|Two attribute sets with the same import and expanded-name have an attribute in common and there is no other attribute set containing the common attribute having the same name with higher importance.|7.1.4|Recover|  
|Adding an attribute to an element after children have been added to it.|7.1.3|Error*|  
|Creating an attribute with the name 'xmlns'|7.1.3|Error*|  
|Adding an attribute to a node that is not an element.|7.1.3|Error*|  
|Creating nodes other than text nodes during the instantiation of the content of the `xsl:attribute` attribute.|7.1.3|Error*|  
|The `name` attribute of an `xsl:processing-instruction` does not yield both an NCName and a processing instruction target.|7.3|Error*|  
|Instantiating the content of `xsl:processing-instruction` creates nodes other than text nodes.|7.3|Error*|  
|The result of instantiating the content of the `xsl:processing-instruction` contains the string "?>"|7.3|Recover|  
|The result of instantiating the content of the `xsl:processing-instruction` contains the string "--" or ends with "-".|7.4|Recover|  
|The result of instantiating the content of the `xsl:comment` creates nodes other than text nodes.|7.4|Error*|  
|The template within a variable-binding element returns an attribute node or a namespace node.|11.2|Error*|  
|There is an error retrieving the resource from the URI passed into the document function.|12.1|Error|  
|The URI reference in the document function contains a fragment identifier and there is an error processing the fragment identifier.|12.1|Recover*|  
|There are multiple attributes with the same name, but different values, that are not named cdata-section elements in `xsl:output` with the same import precedence.|16|Recover|  
|The processor does not support the encoding in the `xsl:output` encoding attribute.|16.1|Recover|  
|Disabling output escaping for a text node that is used for something other than a text node in the result tree.|16.4|Recover*|  
|Converting a result tree fragment to a number or string if the result tree fragment contains a text node with output escaping enabled.|16.4|Recover*|  
|Output escaping is disabled for a character that cannot be represented in the encoding that the XSLT processor is using for output.|16.4|Recover*|  
|Adding a namespace node to an element after children have been added to it or after attributes have been added to it.|errata 25|Error*|  
|The `value` attribute of an `xsl:number` is NAN, infinite or less than 0.5|errata 24|Recover|  
|The second argument node-set to the document function is empty and the URI reference is relative.|errata 14|Recover|  
  
 <sup>*</sup> This behavior is different than that of the <xref:System.Xml.Xsl.XslTransform> class. For more information, see [Implementation of Discretionary Behaviors in the XslTransform Class](../../../../docs/standard/data/xml/implementation-of-discretionary-behaviors-in-the-xsltransform-class.md).  
  
## See Also  
 [XSLT Transformations](../../../../docs/standard/data/xml/xslt-transformations.md)
