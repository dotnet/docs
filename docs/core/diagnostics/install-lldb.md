---
title: Installing LLDB
description: LLDB is a command-line native debugger on Linux and macOS.  It is a prerequisite to perform low-level inspection of .NET Core processes and dumps on Linux and macOS with SOS. 
ms.date: 5/2/2022
ms.topic: reference
---
# Installing LLDB on Linux and macOS
========================

LLDB is a command-line native debugger on Linux and macOS.  It is a prerequisite to perform low-level inspection of .NET Core processes and dumps on Linux and macOS with SOS.  These instructions will lead you through installing or building the best version of lldb to use with [SOS](sos-debugging-extension.md).   SOS requires LLDB 3.9 or later.

We recommend installing the latest supported LLDB on the platform that is being used.

## Ubuntu 16.04

Add the additional package sources:

```
sudo apt-get update
sudo apt-get install wget
echo "deb http://llvm.org/apt/xenial/ llvm-toolchain-xenial main" | sudo tee /etc/apt/sources.list.d/llvm.list
echo "deb http://llvm.org/apt/xenial/ llvm-toolchain-xenial-3.9 main" | sudo tee -a /etc/apt/sources.list.d/llvm.list
wget -O - http://llvm.org/apt/llvm-snapshot.gpg.key | sudo apt-key add -
sudo apt-get update
```

Install the lldb packages:

```console
sudo apt-get install lldb-3.9 python-lldb-3.9
```

To launch lldb:

```console
lldb-3.9
```

## Ubuntu 18.04

To install the lldb packages:

```console
sudo apt-get update
sudo apt-get install lldb-3.9 llvm-3.9 python-lldb-3.9
```

To launch lldb:

```console
lldb-3.9
```

lldb versions 10.0 and higher are the only version of lldb that works with SOS for Arm32 on Ubuntu 18.04.

## Ubuntu 20.04 and later

To install the lldb packages:

```console
sudo get-get update
sudo apt-get install lldb
```

This installs lldb version 10.0.

## Alpine 3.9 and later

```console
apk update
apk add lldb
```

This installs lldb version 10.0.

## Debian 9 and later

```console
sudo apt-get install lldb-3.9 python-lldb-3.9
```

To launch lldb:

```console
lldb-3.9
```

## Fedora 29 and later

```console
sudo dnf install lldb python2-lldb
```

To launch lldb:

```console
lldb
```

## RHEL 7.5

See [LLDB](https://access.redhat.com/documentation/en-us/red_hat_developer_tools/1/html/using_llvm_12.0.1_toolset/assembly_llvm#proc_installing-comp-toolset_assembly_llvm) on RedHat's web site.