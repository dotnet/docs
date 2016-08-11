#!/bin/bash

# =================================
# Script used to restore packages
# for projects that have a single
# project file (project.json) and
# subsequently build those.
#
# Last Update: 08/04/2016
# Author: Den Delimarsky
# =================================

# For reference purposes, get the local home path that will be used
# as the root for file-related operations.
HPATH=$PWD
echo $HPATH

# Variable used to track the success of the overall script execution.
SCRIPT_OUTPUT=0

# Read the file that contains the list of single project files
# line-by-line and trigger a dotnet restore and dotnet build for each.
# SCRIPT_OUTPUT will be incremented for any non-zero results.
while IFS='' read -r line || [[ -n "$line" ]]; do
    DIR=$(dirname "${line}")
    
    cd $DIR
  
    dotnet restore |& tee --append $HPATH/$BUILD_TAG/buildlog.txt
    SCRIPT_OUTPUT=$((${PIPESTATUS[0]} + $SCRIPT_OUTPUT))
  
    dotnet build |& tee --append $HPATH/$BUILD_TAG/buildlog.txt
    SCRIPT_OUTPUT=$((${PIPESTATUS[0]} + $SCRIPT_OUTPUT))
done < $HPATH/single.projects

# Only if SCRIPT_OUTPUT is still zero means that the script
# execution completed successfully. Otherwise, force a failure.
if [ $SCRIPT_OUTPUT -eq 0 ]; then
	exit 0
else
	exit 1
fi
