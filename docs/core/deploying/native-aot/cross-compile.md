---
title: Cross-compilation
description: Instructions and limitations for cross-compilation
author: agocke
ms.author: angocke
ms.date: 10/10/2023
---

# Cross-compilation

Due to restrictions of the platforms themselves, **Native AOT does not support cross-OS
compilation**, meaning you cannot directly compile for Windows using Linux or vice versa. Cross-OS
compilation requires some form of emulation, like a virtual machine or Windows WSL.

However, Native AOT does have limited support for _cross-architecture_ compilation. As long as the
necessary native toolchain is installed, you can cross-compile between the `x64` and the `arm64`
architectures on Windows, Mac, or Linux.

## Windows

Windows will require the toolchain for both the host and target architecture. This means you will need
the MSVC C/C++ Visual Studio workloads for both x64/x86 and for arm64.

## Mac

MacOS provides the x64 and amd64 toolchains in the default XCode install.

## Linux

Every Linux distribution has a different system for installing native toolchain dependencies. The documentation for your Linux distribution will need to be consulted to determine the necessary steps.

The necessary dependencies are:

- A cross-linker, or a linker which can emit for the target. `clang` is one such linker
- A target-compatible `objcopy` or `strip`, if `StripSymbols` is enabled for your project
- Object files for the C runtime of the target architecture
- Object files for zlib for the target architecture

The following commands may suffice for compiling for `linux-arm64` on Ubuntu 22.04 amd64, although this is not documented or guaranteed by Ubuntu:

```bash
sudo dpkg --add-architecture arm64
sudo bash -c 'cat > /etc/apt/sources.list.d/arm64.list <<EOF
deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy main restricted
deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy-updates main restricted
deb [arch=arm64] http://ports.ubuntu.com/ubuntu-ports/ jammy-backports main restricted universe multiverse
EOF'
sudo sed -i -e 's/deb http/deb [arch=amd64] http/g' /etc/apt/sources.list
sudo sed -i -e 's/deb mirror/deb [arch=amd64] mirror/g' /etc/apt/sources.list
sudo apt update
sudo apt install -y clang llvm binutils-aarch64-linux-gnu gcc-aarch64-linux-gnu zlib1g-dev:arm64
```
