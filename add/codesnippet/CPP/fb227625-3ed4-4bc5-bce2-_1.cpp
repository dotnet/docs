                Type^ xmlDocumentType = System::Xml::XmlDocument::typeid;
                XmlDocument^ xmlDocumentOutput = (XmlDocument^)
                    xmlTransform->GetOutput(xmlDocumentType);