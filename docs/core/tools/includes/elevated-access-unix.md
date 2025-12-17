### Install the global tool

Package assets should be installed in a protected location using the `--tool-path` option. This separation avoids sharing a restricted user environment with an elevated environment.

```bash
sudo dotnet tool install PACKAGEID --tool-path /usr/local/share/dotnet-tools
```

`/usr/local/share/dotnet-tools` will be created with permission `drwxr-xr-x`. If the directory already exists, use the `ls -l` command to verify the restricted user doesn't have permission to edit the directory. If so, use the `sudo chmod o-w -R /usr/share/dotnet-tools` command to remove the access.

### Run the global tool

**Option 1** Use the full path with sudo:

```bash
sudo /usr/local/share/dotnet-tools/TOOLCOMMAND
```

**Option 2** Add the symbol link of the tool, once per tool:

```bash
sudo ln -s /usr/local/share/dotnet-tools/TOOLCOMMAND /usr/local/bin/TOOLCOMMAND
```

And run with:

```bash
sudo TOOLCOMMAND
```

### Uninstall the global tool

```bash
sudo dotnet tool uninstall PACKAGEID --tool-path /usr/local/share/dotnet-tools
```

If you made a symbol link, you also need to remove it:

```bash
sudo rm /usr/local/bin/TOOLCOMMAND
```
