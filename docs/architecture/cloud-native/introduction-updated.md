---
title: Introduction to Cloud-Native .NET Applications
description: Architecting Cloud-Native .NET Apps for Azure | Introduction to Cloud-Native .NET Applications
author: robvet
ms.date: 08/05/2019
---
# Introduction to Cloud-Native .NET Applications

Another day, at your desk, building the next big thing and your cell phone rings.

You take the call, It's your friendly recruiter - the one who calls your twice a day with non-stop job opportunities.

But this time it's different: Start-up, equity and plenty of funding.

The mention of the cloud and cutting-edge technology pushes you over the edge.

Fast forward a few weeks and you're now an employee there in a design session architecting the next taxi-haling application.

How will you build it?

If you follow the guidance from past 15 years, you'll most likely build the system shown in Figure 1.1.

![Temporary monolithic design](media/monolithic-design-temporary.png)

**Figure 1-1**. Traditional monolithic design

You construct a large core containing all of your business logic: Billing, Payments, Passenger Management and more. You surround it with a layer of adapters that communicate with various data stores and external services. You expose functionality via REST API and HTML interfaces.

Congratulations!  You just created a monolithic application.

Not all is bad. Monoliths offers some distinct advantages. For example, they are straightforward to...

- build 
- test
- deploy
- troubleshoot
- scale

Many successful apps which exist today were created as monoliths.  The app is a hit and continues to evolve.

As the appllication grows ever larger, iteration after iteration, you feel yourself losing control and enter a state known as the **Fear Cycle**.

- The app has become so overwhelmingly complicated that no single person understands it.
- You fear making changes - each has unintended and costly side effects.
- New features/fixes become tricky, time-consuming and expensive to implement.
- Each requires a full deployment of the entire application.
- It's difficult to implement agile delivery methodologies.
- One unstable component can crash the entire system.
- Implementing new technologies and frameworks is not an option
- Architectural erosion sets in as the code base deteriorates with never-ending "special cases"
- The consultants come in tell you to rewrite it

Many organizations address the monolithic fear cycle by adopting a cloud-native approach. Figure 1-2 shows the same system built with microservices.

![Temporary monolithic design](media/microservice-design-temporary.png)

**Figure 1-2**. Microservice based architecture

Note in the previous image how the application is decomposed across a set of small isolated services. Each service is self-contained and includes its own code, data and dependencies. Each services exposes a RESTFul interface to communicate with other services and front-end applications. 

### Cloud-native computing

Welcome to the world of Cloud-Native computing!

You first thought might be, “What exactly cloud native mean?” Another industry buzzword concocted by cloud providers to sell us more stuff?”

Fortunately, it’s far different than that, and hopefully this book will help convince you.

Within a short time, cloud native has become a driving trend in the software industry. It’s a new way to think about building large, complex systems. An approach that takes full advantage of modern software development practices, technologies, and cloud infrastructure. It changes the way you design, implement, deploy, and operationalize systems.

Unlike the constant hype that drives our industry, cloud native is “*for-real.”* Consider the [Cloud Native Computing Foundation](https://www.cncf.io/) (CNCF), a consortium of over 300 major corporations with a charter to make cloud-native computing ubiquitous across technology and cloud stacks. Arguably, one of the most influential open source groups, it is the owner of nuermous cloud native OSS projects including Kuberentes.

This organization serves as the home for many of the fastest-growing open source projects in GitHub, including [Kubernetes](https://kubernetes.io/), [Prometheus](https://prometheus.io/), [Helm](https://helm.sh/), [Envoy](https://www.envoyproxy.io/), and [gRPC](https://grpc.io/).

The CNCF fosters an ecosystem of open source and vendor-neutrality. Following that lead, we present cloud-native principles, patterns, and best practices that are technology agnostic. At the same time, we want to raise your awareness of the services and infrastructure available in the Microsoft Azure cloud for constructing cloud-native systems. 

So, what exactly *is* Cloud Native? Sit back, relax, and let us help you explore this new world and how it ties to the Azure cloud.

>[!div class="step-by-step"]
>[Previous](index.md)
>[Next](definition.md)
