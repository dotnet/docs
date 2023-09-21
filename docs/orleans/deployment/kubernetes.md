---
title: Kubernetes hosting
description: Learn how to host an Orleans app with Kubernetes.
ms.date: 03/09/2022
---

# Kubernetes hosting

Kubernetes is a popular choice for hosting Orleans applications. Orleans will run in Kubernetes without specific configuration, however, it can also take advantage of extra knowledge which the hosting platform can provide.

The [`Microsoft.Orleans.Hosting.Kubernetes`](https://www.nuget.org/packages/Microsoft.Orleans.Hosting.Kubernetes) package adds integration for hosting an Orleans application in a Kubernetes cluster. The package provides an extension method, <xref:Orleans.Hosting.KubernetesHostingExtensions.UseKubernetesHosting%2A>, which performs the following actions:

- <xref:Orleans.Configuration.SiloOptions.SiloName?displayProperty=nameWithType> is set to the pod name.
- <xref:Orleans.Configuration.EndpointOptions.AdvertisedIPAddress?displayProperty=nameWithType> is set to the pod IP.
- <xref:Orleans.Configuration.EndpointOptions.SiloListeningEndpoint?displayProperty=nameWithType> &amp; <xref:Orleans.Configuration.EndpointOptions.GatewayListeningEndpoint?displayProperty=nameWithType> are configured to listen on any address, with the configured <xref:Orleans.Configuration.EndpointOptions.SiloPort> and <xref:Orleans.Configuration.EndpointOptions.GatewayPort>. Defaults port values of `11111` and `30000` are used if no values are set explicitly).
- <xref:Orleans.Configuration.ClusterOptions.ServiceId?displayProperty=nameWithType> is set to the value of the pod label with the name `orleans/serviceId`.
- <xref:Orleans.Configuration.ClusterOptions.ClusterId?displayProperty=nameWithType> is set to the value of the pod label with the name `orleans/clusterId`.
- Early in the startup process, the silo will probe Kubernetes to find which silos do not have corresponding pods and mark those silos as dead.
- The same process will occur at runtime for a subset of all silos, to remove the load on Kubernetes' API server. By default, 2 silos in the cluster will watch Kubernetes.

Note that the Kubernetes hosting package does not use Kubernetes for clustering. For clustering, a separate clustering provider is still needed. For more information on configuring clustering, see the [Server configuration](../host/configuration-guide/server-configuration.md) documentation.

This functionality imposes some requirements on how the service is deployed:

* Silo names must match pod names.
* Pods must have an `orleans/serviceId` and `orleans/clusterId` label which corresponds to the silo's `ServiceId` and `ClusterId`. The above-mentioned method will propagate those labels into the corresponding options in Orleans from environment variables.
* Pods must have the following environment variables set: `POD_NAME`, `POD_NAMESPACE`, `POD_IP`, `ORLEANS_SERVICE_ID`, `ORLEANS_CLUSTER_ID`.

The following example shows how to configure these labels and environment variables correctly:

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: dictionary-app
  labels:
    orleans/serviceId: dictionary-app
spec:
  selector:
    matchLabels:
      orleans/serviceId: dictionary-app
  replicas: 3
  template:
    metadata:
      labels:
        # This label is used to identify the service to Orleans
        orleans/serviceId: dictionary-app

        # This label is used to identify an instance of a cluster to Orleans.
        # Typically, this will be the same value as the previous label, or any
        # fixed value.
        # In cases where you are not using rolling deployments (for example,
        # blue/green deployments),
        # this value can allow for distinct clusters which do not communicate
        # directly with each others,
        # but which still share the same storage and other resources.
        orleans/clusterId: dictionary-app
    spec:
      containers:
        - name: main
          image: my-registry.azurecr.io/my-image
          imagePullPolicy: Always
          ports:
          # Define the ports which Orleans uses
          - containerPort: 11111
          - containerPort: 30000
          env:
          # The Azure Storage connection string for clustering is injected as an
          # environment variable
          # It must be created separately using a command such as:
          # > kubectl create secret generic az-storage-acct `
          #     --from-file=key=./az-storage-acct.txt
          - name: STORAGE_CONNECTION_STRING
            valueFrom:
              secretKeyRef:
                name: az-storage-acct
                key: key
          # Configure settings to let Orleans know which cluster it belongs to
          # and which pod it is running in
          - name: ORLEANS_SERVICE_ID
            valueFrom:
              fieldRef:
                fieldPath: metadata.labels['orleans/serviceId']
          - name: ORLEANS_CLUSTER_ID
            valueFrom:
              fieldRef:
                fieldPath: metadata.labels['orleans/clusterId']
          - name: POD_NAMESPACE
            valueFrom:
              fieldRef:
                fieldPath: metadata.namespace
          - name: POD_NAME
            valueFrom:
              fieldRef:
                fieldPath: metadata.name
          - name: POD_IP
            valueFrom:
              fieldRef:
                fieldPath: status.podIP
          - name: DOTNET_SHUTDOWNTIMEOUTSECONDS
            value: "120"
          request:
            # Set resource requests
      terminationGracePeriodSeconds: 180
      imagePullSecrets:
        - name: my-image-pull-secret
  minReadySeconds: 60
  strategy:
    rollingUpdate:
      maxUnavailable: 0
      maxSurge: 1
```

For RBAC-enabled clusters, the Kubernetes service account for the pods may also need to be granted the required access:

```yaml
kind: Role
apiVersion: rbac.authorization.k8s.io/v1
metadata:
  name: orleans-hosting
rules:
- apiGroups: [ "" ]
  resources: ["pods"]
  verbs: ["get", "watch", "list", "delete"]
---
kind: RoleBinding
apiVersion: rbac.authorization.k8s.io/v1
metadata:
  name: orleans-hosting-binding
subjects:
- kind: ServiceAccount
  name: default
  apiGroup: ''
roleRef:
  kind: Role
  name: orleans-hosting
  apiGroup: ''
```

## Liveness, readiness, and startup probes

Kubernetes can probe pods to determine the health of a service. For more information, see [Configure liveness, readiness and startup probes](https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/) in Kubernetes' documentation.

Orleans uses a cluster membership protocol to promptly detect and recover from a process or network failures. Each node monitors a subset of other nodes, sending periodic probes. If a node fails to respond to multiple successive probes from multiple other nodes, then it will be forcibly removed from the cluster. Once a failed node learns that it has been removed, it terminates immediately. Kubernetes will restart the terminated process and it will attempt to rejoin the cluster.

Kubernetes' probes can help to determine whether a process in a pod is executing and is not stuck in a zombie state. probes do not verify inter-pod connectivity or responsiveness or perform any application-level functionality checks. If a pod fails to respond to a liveness probe, then Kubernetes may eventually terminate that pod and reschedule it. Kubernetes' probes and Orleans' probes are therefore complementary.

The recommended approach is to configure Liveness Probes in Kubernetes which perform a simple local-only check that the application is performing as intended. These probes serve to terminate the process if there is a total freeze, for example, due to a runtime fault or another unlikely event.

## Resource quotas

Kubernetes works in conjunction with the operating system to implement [resource quotas](https://kubernetes.io/docs/concepts/policy/resource-quotas/). This allows CPU and memory reservations and/or limits to be enforced. For a primary application that is serving interactive load, we recommend not implementing restrictive limits unless necessary. It is important to note that requests and limits are substantially different in their meaning and where they are implemented. Before setting requests or limits, take the time to gain a detailed understanding of how they are implemented and enforced. For example, memory may not be measured uniformly between Kubernetes, the Linux kernel, and your monitoring system. CPU quotas may not be enforced in the way that you expect.

## Troubleshooting

### Pods crash, complaining that `KUBERNETES_SERVICE_HOST and KUBERNETES_SERVICE_PORT must be defined`

Full exception message:

```Output
Unhandled exception. k8s.Exceptions.KubeConfigException: unable to load in-cluster configuration, KUBERNETES_SERVICE_HOST and KUBERNETES_SERVICE_PORT must be defined
at k8s.KubernetesClientConfiguration.InClusterConfig()
```

* Check that `KUBERNETES_SERVICE_HOST` and `KUBERNETES_SERVICE_PORT` environment variables are set inside your Pod.
You can check by executing the following command `kubectl exec -it <pod_name> /bin/bash -c env`.
* Ensure that `automountServiceAccountToken` set to **true** on your Kubernetes `deployment.yaml`. For more information, see [Configure Service Accounts for Pods](https://kubernetes.io/docs/tasks/configure-pod-container/configure-service-account/)
