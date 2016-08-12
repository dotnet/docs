#!/bin/bash

# =================================
# Script used to obtain a list of
# project files that are used for
# restore and compilation.
#
# Last Update: 08/04/2016
# Author: Den Delimarsky
# =================================

# For logging purposes, create a folder that can uniquely identify the build
mkdir $BUILD_TAG

# For reference purposes, get the local home path that will be used
# as the root for file-related operations.
HPATH=$PWD
echo $HPATH

# For diagnostic purposes, log the information about the dotnet environment.
dotnet --info | tee $HPATH/global.projects --append $HPATH/$BUILD_TAG/buildlog.txt

# Get the list of global and single project files
find $HPATH/samples/core -name "global.json" |& tee $HPATH/global.projects --append $HPATH/$BUILD_TAG/buildlog.txt
find $HPATH/samples/core -name "project.json" |& tee $HPATH/single.projects --append $HPATH/$BUILD_TAG/buildlog.txt
