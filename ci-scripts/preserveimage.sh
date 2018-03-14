IMAGE="$1"

mkdir "$BUILD_REPOSITORY_LOCALPATH/buildimage"
docker save -o $BUILD_REPOSITORY_LOCALPATH/buildimage/$BUILD_BUILDNUMBER-dotnet.tar "$IMAGE"
