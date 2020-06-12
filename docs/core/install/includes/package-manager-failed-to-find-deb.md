
If you receive an error message similar to **Unable to locate package {netcore-package}**, run the following commands.

There are two placeholders in the following set of commands.

- `{dotnet-package}`\
This represents the .NET Core package you're installing, such as `aspnetcore-runtime-3.1`. This is used in the `sudo apt-get install` command below.

- `{os-version}`\
This represents the Linux version you are on. This is used in the `wget` command below.

Try purging the package list:

```bash
sudo dpkg --purge packages-microsoft-prod && sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install {dotnet-package}
```

If that doesn't work, you can run a manual install with the following commands:
