                    Dim xmlDocumentType As Type
                    xmlDocumentType = GetType(System.Xml.XmlDocument)

                    Dim xmlDocumentOutput As XmlDocument
                    xmlDocumentOutput = CType( _
                        xmlTransform.GetOutput(xmlDocumentType), _
                        XmlDocument)