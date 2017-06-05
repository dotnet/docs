#!/bin/sh

TARGET_FOLDER=`cat .buildtarget`
echo "$value"

for sample in $(find $TARGET_FOLDER -name *.csproj); do dotnet restore $sample; dotnet build $sample; done
