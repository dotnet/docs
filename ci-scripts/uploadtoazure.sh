export AZURE_STORAGE_CONNECTION_STRING=$AZURESCS

CONTAINER_NAME=constructors-images
SOURCE_FOLDER=/buildimages/*

az storage container create -n $CONTAINER_NAME

for file in $SOURCE_FOLDER
do
  az storage blob upload --file $file --container-name $CONTAINER_NAME --name $BUILD_BUILDNUMBER
done
