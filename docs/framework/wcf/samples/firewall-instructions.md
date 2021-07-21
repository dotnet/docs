---
title: "Firewall Instructions"
description: Learn how to enable ports or programs in the firewall for WCF samples. Use one of these procedures, depending on your requirements and security environment.
ms.date: "03/30/2017"
ms.assetid: a7dc429f-65ac-4faf-974a-77d5fb977fe1
---
# Firewall instructions

You must enable several ports or programs in the firewall so that the Windows Communication Foundation (WCF) samples can function. Many of the samples communicate by using ports in the range 8000-8003, and port 9000. The firewall is turned on by default and prevents access to these ports. To enable the firewall for the samples, complete one of the following procedures, depending on your requirements and security environment:

- Option 1: Interactively enable samples while running. Make no advance changes to your firewall configuration and proceed to start building and running the samples. When a sample is run, a **Windows Security Alert** dialog box appears. The sample program in question can then be added interactively to an unblocked list. With this procedure, you may have to then restart the sample.

- Option 2: Enable sample programs in advance. Start the **Windows Firewall Control Panel** applet and enable the sample programs you plan to run. You must build the programs first so the executable files exist. You can find more detailed instructions in the following procedure.

- Option 3: Enable a port range in advance. Start the **Windows Firewall Control Panel** applet and enable ports 80, 443, 8000-8003 and 9000, which are used by the samples. You can find more detailed instructions in the following procedure. This option is less secure than the others because it allows any program to use these ports, not just the samples.

If you are unsure of which procedure to use, choose the first option. If you are running a firewall from another vendor, you might need to make similar changes.

> [!IMPORTANT]
> Changing your firewall configuration affects your security. It is recommended that you record the changes you make and remove them when you are finished working with the samples.

## Enable samples programs in advance

1. Build the sample.

2. Choose **Start** > **Run**, and enter `firewall.cpl`. This opens the **Windows Firewall Control Panel** applet.

    > [!NOTE]
    > You must have permission to change the Firewall settings to run samples that require the ability to communicate through the Windows Firewall. If some firewall settings are unavailable and your computer is connected to a domain, your system administrator might be controlling these settings through Group Policy.

3. Complete one of the following operating-specific steps to allow a program through the Windows Firewall:

    - On Windows 7 or Windows Server 2008 R2, click **Allow a program or feature through Windows Firewall**. Click **Change Settings** > **Allow Another Program**.

    - On Windows Vista or Windows Server 2008, click **Allow a program through Windows Firewall**.

4. On the **Exceptions** tab, click **Add Program**.

5. Click the **Browse** button and select the executable file of the sample you plan to run.

6. Repeat steps 4 and 5 until you have added the executable files of all the samples you plan to run.

7. Click **OK** to close the firewall applet.

## Enable a port range in advance

1. Choose **Start** > **Run**, and enter `firewall.cpl`. This opens the **Windows Firewall Control Panel** applet.

2. On Windows 7 or Windows Server 2008 R2, follow these steps.

    1. Click **Advanced settings** in the left column of the Windows Firewall window.

    2. Click **Inbound Rules** in the left column.

    3. Click **New Rules** in the right column.

    4. Select **Port** and click **next**.

    5. Select **TCP** and enter `8000, 8001, 8002, 8003, 9000, 80, 443` in the **Specific local ports** field.

    6. Click **Next**.

    7. Select **Allow the connection**, and click **Next** .

    8. Select **Domain** and **Private**, and click **Next**.

    9. Name this rule `WCF-WF 4.0 Samples`, and click **Finish**.

    10. Click **Outbound Rules** and repeat steps c to h.

3. On Windows Vista or Windows Server 2008, follow these steps.

    1. Click **Allow a program through Windows Firewall**.

    2. On the **Exceptions** tab, click **Add Port**.

    3. Enter a name, enter 8000 as the port number, and select the **TCP** option.

    4. Click the **Change Scope** button, select the **My Network** (subnet) only option, and click **OK**.

    5. Repeat steps b to d for ports 8001, 8002, 8003, 9000, 80, and 443.

4. Click **OK** to close the firewall applet.

> [!NOTE]
> Remove any firewall exceptions when you are finished working with the samples. To do so, open the **Windows Firewall Control Panel** applet and remove any programs or port entries that were added by the previous procedures.
