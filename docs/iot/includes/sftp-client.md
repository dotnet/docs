1. [Using an SFTP client](https://www.raspberrypi.org/documentation/remote-access/ssh/sftp.md), copy the files from the publish location on the development computer to a new folder on the Raspberry Pi.

    To use the `scp` command to copy files from the development computer to your Raspberry Pi, open a command prompt and execute the following:

    ```console
    scp /publish-location/*.* pi@raspberrypi:/home/pi/deployment-location/
    ```

    Where:

    - *c:\publish-location\* is the folder you published to in the previous step.
    - *pi@raspberypi* is the user and host names in the format `<username>@<hostname>`.
    - */home/pi/deployment-location/* is the new folder on the Raspberry Pi.

    > [!TIP]
    > Recent versions of Windows have OpenSSH, which includes `scp`, pre-installed.
