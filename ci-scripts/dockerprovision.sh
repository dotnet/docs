DOCKER_UN="$1"
DOCKER_PW="$2"
WORK_FOLDER="$3"
TARGET_IMAGE="$4"

echo $WORK_FOLDER >> .buildtarget

docker login -u "$DOCKER_UN" -p "$DOCKER_PW" constructors.azurecr.io

docker pull constructors.azurecr.io/platforms/netcoresdk

echo "Creating container for pre-provisioning..."
docker create --name builder constructors.azurecr.io/platforms/netcoresdk

echo "Copying samples to container..."
docker cp "$BUILD_REPOSITORY_LOCALPATH/samples/." builder:/samples/
docker cp "$BUILD_REPOSITORY_LOCALPATH/ci-scripts/buildsamples.sh" builder:buildsamples.sh
docker cp "$BUILD_REPOSITORY_LOCALPATH/.buildtarget" builder:.buildtarget

echo "Committing changes..."
docker commit builder constructors.azurecr.io/platforms/netcoresdk

#docker run --name builder bash -c "for sample in $(find . -name *.csproj); do dotnet restore $sample; dotnet build $sample; done"

docker run --name newbuilder --rm -w $WORK_FOLDER $TARGET_IMAGE bash -c 'sh ../../buildsamples.sh'
