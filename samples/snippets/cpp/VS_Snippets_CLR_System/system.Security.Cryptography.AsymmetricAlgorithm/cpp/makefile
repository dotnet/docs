all : customcrypto.dll System.Security.Cryptography.AsymmetricAlgorithm.exe

CustomCrypto.dll : customcrypto.cpp
    cl /LD /Fecustomcrypto.dll /clr:pure customcrypto.cpp

System.Security.Cryptography.AsymmetricAlgorithm.exe : customcrypto.dll customcryptoimpl.cpp
    cl /FeSystem.Security.Cryptography.AsymmetricAlgorithm.exe /clr:pure customcryptoimpl.cpp /FUcustomcrypto.dll