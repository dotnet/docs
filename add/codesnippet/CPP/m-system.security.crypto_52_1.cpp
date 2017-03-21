               Type^ streamType = System::IO::Stream::typeid;
               MemoryStream^ outputStream = static_cast<MemoryStream^>(
                  xmlTransform->GetOutput( streamType ));