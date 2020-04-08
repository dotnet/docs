# This script builds the sample for x64 OSX. 
# It assumes that both the dotnet CLI and g++ compiler are available on the path.

BASEDIR="$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )"
SRCDIR=${BASEDIR}/src
OUTDIR=${BASEDIR}/bin/osx

# Make output directory, if needed
if [ ! -d "${OUTDIR}" ]; then
    mkdir -p ${OUTDIR}
fi

# Build managed component
echo Building Managed Library
echo dotnet publish --self-contained -r osx-x64 ${SRCDIR}/ManagedLibrary/ManagedLibrary.csproj -o ${OUTDIR}
dotnet publish --self-contained -r osx-x64 ${SRCDIR}/ManagedLibrary/ManagedLibrary.csproj -o ${OUTDIR}

# Build native component
# -D both LINUX and OSX since most LINUX code paths apply to OSX also
g++ -o ${OUTDIR}/SampleHost -D LINUX -D OSX ${SRCDIR}/SampleHost.cpp -ldl
