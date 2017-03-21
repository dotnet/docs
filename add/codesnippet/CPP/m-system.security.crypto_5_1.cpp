                        Type^ streamType = Stream::typeid;
                        CryptoStream^ outputStream = 
                            (CryptoStream^)(xmlTransform->GetOutput(
							streamType));