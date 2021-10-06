[Using an SFTP client like `scp`](https://www.raspberrypi.com/documentation/computers/remote-access.html#using-secure-copy), copy the files from the publish location on the development computer to a new folder on the Raspberry Pi.

For example, to use the `scp` command to copy files from the development computer to your Raspberry Pi, open a command prompt and execute the following:

```console
scp -r /publish-location/* pi@raspberrypi:/home/pi/deployment-location/
```

Where:

- The `-r` option instructs `scp` to copy files recursively.
- */publish-location/* is the folder you published to in the previous step.
- `pi@raspberypi` is the user and host names in the format `<username>@<hostname>`.
- */home/pi/deployment-location/* is the new folder on the Raspberry Pi.

> [!TIP]
> Recent versions of Windows have OpenSSH, which includes `scp`, pre-installed.
