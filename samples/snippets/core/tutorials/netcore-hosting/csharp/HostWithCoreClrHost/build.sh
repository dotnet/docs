# This script builds the sample for x64 Linux. 
# It assumes that both the dotnet CLI and g++ compiler are available on the path.

SCRIPTPATH=$(readlink -f "$0")
BASEDIR=$(dirname $SCRIPTPATH)
SRCDIR=${BASEDIR}/src
OUTDIR=${BASEDIR}/bin/linux

# Make output directory, if needed
if [ ! -d "${OUTDIR}" ]; then
    mkdir -p ${OUTDIR}
fi

# Build managed component
echo Building Managed Library
dotnet publish --self-contained -r linux-x64 ${SRCDIR}/ManagedLibrary/ManagedLibrary.csproj -o ${OUTDIR}

# Build native component
g++ -o ${OUTDIR}/SampleHost -D LINUX ${SRCDIR}/SampleHost.cpp -ldl
