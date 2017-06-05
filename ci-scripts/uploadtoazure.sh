export AZURE_STORAGE_CONNECTION_STRING="$1"

#config.ssh.shell = "bash -c 'BASH_ENV=/etc/profile exec bash'"

CONTAINER_NAME=constructors-images
SOURCE_FOLDER=/buildimage/*

# Install the CLI
# sudo npm install -g azure-cli

# Reload bash
#source ~/.profile

# azure

CONTAINER_LIST=$(azure storage container list)

if [[ $CONTAINER_LIST == *$CONTAINER_NAME* ]]; then
  echo "It's there!"
else
  azure storage container create $CONTAINER_NAME
fi

for file in $SOURCE_FOLDER
do
  azure storage blob upload $file $CONTAINER_NAME $BUILD_BUILDNUMBER
done
