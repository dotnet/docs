---
title: Cross-compilation
description: Instructions and limitations for cross-compilation
author: agocke
ms.author: angocke
ms.date: 10/10/2023
ms.custom: linux-related-content
ms.topic: article
---

# Cross-compilation

Cross-compilation is a process of creating executable code for a platform other than the one on which the compiler is running. The platform difference might be a different OS or a different architecture. For instance, compiling for Windows from Linux, or for Arm64 from x64. On Linux, the difference can also be between the standard C library implementations - glibc (e.g. Ubuntu Linux) or musl (e.g. Alpine Linux).

Native AOT uses platform tools (linkers) to link platform libraries (static and dynamic) together with AOT-compiled managed code into the final executable file. The availability of cross-linkers and static/dynamic libraries for the target system limits the OS/architecture pairs that can cross-compile.

Since there's no standardized way to obtain native macOS SDK for use on Windows/Linux, or Windows SDK for use on Linux/macOS, or a Linux SDK for use on Windows/macOS, **Native AOT does not support cross-OS
compilation**. Cross-OS compilation with Native AOT requires some form of emulation, like a virtual machine or Windows WSL.

However, Native AOT does have limited support for _cross-architecture_ compilation. As long as the
necessary native toolchain is installed, it's possible to cross-compile between the `x64` and the `arm64`
architectures on Windows, Mac, or Linux.

## Windows

Cross-compiling from x64 Windows to ARM64 Windows or vice versa works as long as the appropriate VS 2022 C++ build tools are installed. To target ARM64 make sure the Visual Studio component "VS 2022 C++ ARM64/ARM64EC build tools (Latest)" is installed. To target x64, look for "VS 2022 C++ x64/x86 build tools (Latest)" instead.

## Mac

MacOS provides the x64 and amd64 toolchains in the default XCode install.

## Linux

Every Linux distribution has a different system for installing native toolchain dependencies. Consult the documentation for your Linux distribution to determine the necessary steps.

The necessary dependencies are:

- A cross-linker, or a linker that can emit for the target. `clang` is one such linker.
- A target-compatible `objcopy` or `strip`, if `StripSymbols` is enabled for your project.
- Object files for the C runtime of the target architecture.
- Object files for zlib for the target architecture.

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
