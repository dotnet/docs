pushd MyPath\v5.0
csc /t:library MyAssembly.cs
popd
csc /t:library YourAssembly.cs
csc source.cs
