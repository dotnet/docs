DOCKER_UN="$1"
DOCKER_PW="$2"

docker login -u "$DOCKER_UN" -p "$DOCKER_PW" constructors.azurecr.io

docker pull constructors.azurecr.io/platforms/netcoresdk

echo "Creating container container-netcoresdk-$BUILD_BUILDNUMBER..."
docker create constructors.azurecr.io/platforms/netcoresdk --name "container-netcoresdk-$BUILD_BUILDNUMBER"

echo "Copying samples to container..."
docker cp "$BUILD_REPOSITORY_LOCALPATH/samples/." "container-netcoresdk-$BUILD_BUILDNUMBER":/samples/

docker run --name "container-netcoresdk-$BUILD_BUILDNUMBER" -c "for sample in $(find . -name *.csproj); do dotnet restore $sample; dotnet build $sample; done"

#docker run --name container-netcoresdk-305 --rm -v /opt/vsts/work/1/s:/source -w /source/samples/csharp constructors.azurecr.io/platforms/netcoresdk bash -c for sample in $(find . -name *.csproj); do dotnet restore $sample; dotnet build $sample; done
