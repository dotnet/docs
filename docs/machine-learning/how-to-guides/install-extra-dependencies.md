---
title: Install extra ML.NET dependencies
description: Learn how to install any native libraries that ML.NET packages are dependent on but do not get installed with the NuGet packages
ms.date: 10/05/2021
author: natke
ms.author: nakersha
ms.custom: how-to
ms.topic: how-to
---

# Install extra ML.NET dependencies

In most cases, on all operating systems, installing ML.NET is as simple as referencing the appropriate NuGet package.

```dotnetcli
dotnet add package Microsoft.ML
```

In some cases though, there are additional installation requirements, particularly when native components are required. This document describes the installation requirements for those cases. The sections are broken down by the specific `Microsoft.ML.*` NuGet package that has the additional dependency.

## Microsoft.ML.TimeSeries, Microsoft.ML.AutoML

Both of these packages have a dependency on `Microsoft.ML.MKL.Redist`, which has a dependency on `libomp`.

### Windows

No extra installation steps required. The library is installed when the NuGet package is added to the project.

### Linux

1. Install the GPG key for the repository

    ```bash
    sudo bash
    # <type your user password when prompted.  this will put you in a root shell>
    # cd to /tmp where this shell has write permission
    cd /tmp
    # now get the key:
    wget https://apt.repos.intel.com/intel-gpg-keys/GPG-PUB-KEY-INTEL-SW-PRODUCTS-2019.PUB
    # now install that key
    apt-key add GPG-PUB-KEY-INTEL-SW-PRODUCTS-2019.PUB
    # now remove the public key file exit the root shell
    rm GPG-PUB-KEY-INTEL-SW-PRODUCTS-2019.PUB
    exit
    ```

2. Add the APT Repository for MKL

    ```bash
    sudo sh -c 'echo deb https://apt.repos.intel.com/mkl all main > /etc/apt/sources.list.d/intel-mkl.list'
    ```

3. Update packages

    ```bash
    sudo apt-get update
    ```

4. Install MKL

    ```bash
    sudo apt-get install <COMPONENT>-<VERSION>.<UPDATE>-<BUILD_NUMBER>
    ```

    For example:

    ```bash
    sudo apt-get install intel-mkl-64bit-2020.0-088
    ```

    Determine the location of `libiomp.so`

    ```bash
    find /opt -name "libiomp5.so"
    ```

    For example:

    ```output
    /opt/intel/compilers_and_libraries_2020.0.166/linux/compiler/lib/intel64_lin/libiomp5.so
    ```

5. Add this location to the load library path:

    ```bash
    sudo ldconfig /opt/intel/compilers_and_libraries_2020.0.166/linux/compiler/lib/intel64_lin
    ```

### Mac

1. Install the library with `Homebrew`

    ```bash
    wget https://raw.githubusercontent.com/Homebrew/homebrew-core/fb8323f2b170bd4ae97e1bac9bf3e2983af3fdb0/Formula/libomp.rb && brew install ./libomp.rb && brew link libomp --force
    ```
