for sample in $(find . -name *.csproj); do dotnet restore $sample; dotnet build $sample; done
