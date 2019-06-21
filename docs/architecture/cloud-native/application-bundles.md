---
title: Cloud Native Application Bundles
description: Architecting Cloud Native .NET Apps for Azure | Cloud Native Application Bundles
ms.date: 06/30/2019
---

# Cloud Native Application Bundles

A key property of Cloud Native Applications is that they leverage the properties of the cloud to speed up development. This often means that a full application uses a variety of different technologies. Applications may be shipped in Docker containers, some services may use Azure Functions while other parts may run directly on virtual machines allocated on big metal servers with hardware GPU acceleration. No two Cloud Native Applications are the same so it has been difficult to provide a single mechanism for shipping them.

The Docker containers may run on Kubernetes using a Helm Chart for deployment. The Azure Functions may be allocated using Terraform templates. Finally the virtual machines may be allocated using Terraform but built out using Ansible. This is a whole mess of technologies and there has been no way to package them all together into a reasonable package. Until now.

Cloud Native Application Bundles are a joint effort of a number of community minded companies such as Microsoft, Docker, and HashiCorp to develop a specification to package distributed applications.

The effort was announced in December of 2018 so there remains a fair bit of work to do to expose the effort to the greater community. Already, however, there is an [open specification](https://github.com/deislabs/cnab-spec) as well as a reference implementation known as [Duffle](https://duffle.sh/). This tool, written in Go, is a joint effort between Docker and Microsoft.

The CNABs can contain a variety of different installation technologies. This allows things like Helm Charts, Terraform templates, and Ansible Playbooks to coexist in the same package. Once built the packages are self-contained and portable; they can be installed from a USB stick.  The packages are cryptographically signed to ensure that they originate from the party they claim.

The core of a CNAB is a file called `bundle.json`. This file defines the contents of the bundle, be they Terraform or images or anything else. Figure 11-9 defines a CNAB which invokes some Terraform. Notice, however that it actually defines an invocation image which is used to invoke the Terraform. When packaged up the Docker file located in the cnab directory will be built into a docker image which will be included in the bundle. Having Terraform installed inside a Docker container in the bundle means that users don't need to have Terraform installed on their machine to run the bundling.

```json
{
    "name": "terraform",
    "version": "0.1.0",
    "schemaVersion": "v1.0.0-WD",
    "parameters": {
        "backend": {
            "type": "boolean",
            "defaultValue": false,
            "destination": {
                "env": "TF_VAR_backend"
            }
        }
    },
    "invocationImages": [
        {
        "imageType": "docker",
        "image": "cnab/terraform:latest"
        }
    ],
    "credentials": {
        "tenant_id": {
            "env": "TF_VAR_tenant_id"
        },
        "client_id": {
            "env": "TF_VAR_client_id"
        },
        "client_secret": {
            "env": "TF_VAR_client_secret"
        },
        "subscription_id": {
            "env": "TF_VAR_subscription_id"
        },
        "ssh_authorized_key": {
            "env": "TF_VAR_ssh_authorized_key"
        }
    },
    "actions": {
        "status": {
            "modifies": true
        }
    }
}
```

**Figure 11-13** - An example Terraform file

The `bundle.json` also defines a set of parameters which are passed down into the Terraform. Parameterization of the bundle allows for installation in a variety of different environments.

The CNAB format is very flexible too, allowing it to be used against any cloud. It can even be used against on premise solutions such as [OpenStack](https://www.openstack.org/).

## DevOps Decisions

There are so many great tools in the DevOps space these days and even more fantastic books and papers on how to succeed. A favorite book to get started on the DevOps journey is [The Phoenix Project](https://www.oreilly.com/library/view/the-phoenix-project/9781457191350/) which follows the transformation of a fictional company from NoOps to DevOps. One thing is for certain: DevOps is no longer a "nice to have" when deploying complex, Cloud Native Applications.  It is a requirement and should be planned for and resourced at the start of any project.

>[!div class="step-by-step"]
>[Previous](infrastructure-as-code.md)
