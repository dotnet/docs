export AZURE_STORAGE_CONNECTION_STRING="$1"

CONTAINER_NAME=constructors-images
SOURCE_FOLDER="$BUILD_REPOSITORY_LOCALPATH/buildimage/*"

CONTAINER_LIST=$(azure storage container list)

if [[ $CONTAINER_LIST == *$CONTAINER_NAME* ]]; then
  echo "It's there!"
else
  azure storage container create "$CONTAINER_NAME"
fi

ls "$BUILD_REPOSITORY_LOCALPATH/buildimage"

for file in $SOURCE_FOLDER; do
  azure storage blob upload "$file" "$CONTAINER_NAME" "$BUILD_BUILDNUMBER"
done
