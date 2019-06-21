---
title: Logging
description: Architecting Cloud Native .NET Apps for Azure | Logging
ms.date: 06/30/2019
---
# Elastic Stack 

There are many good centralized logging tools and they vary in cost from being free, open source tools to some quite expensive options. In many cases the free tools are on par or better than the paid offerings. One such tool is a combination of three open source components: Elastic search, Logstash and Kibana. 
Collectively these are known as the Elastic Stack. 

The first component is Logstash. This tool is used to gather log information from a large variety of different sources. For instance, Logstash can read logs from disk and also receive messages from logging libraries like [Serilog](https://serilog.net/). Log stash can perform some basic filtering and expansion on the logs as they arrive. For instance if your logs contain IP addresses then Logstash may be configured to perform a geographical lookup and obtain a country or even city of origin for that message. 

Serilog is a logging library for .NET languages which allows for parameterized logging. This means that instead of generating a textual log message which embeds fields, parameters are kept separate. This allows for more intelligent filtering and searching. A sample serilog configuration for writing to Logstash appears in Figure 8-1.

```
var log = new LoggerConfiguration()   
         .WriteTo.Http("http://localhost:8080")
         .CreateLogger();
```
**Figure 8-1** Serilog config for writing log information directly to logstash over HTTP

Logstash would then be configured using something like the configuration shown in Figure 8-2. 

```
input {
	http {	
		#default host 0.0.0.0:8080
		codec => json
	}
}

output {
	elasticsearch {
		hosts => "elasticsearch:9200"
		index=>"sales-%{+xxxx.ww}"
	}
}
```
**Figure 8-2** - A Logstash configuration for consuming logs from Serilog

For scenarios where extensive log manipulation is not needed there is an alternative to Logstash known as Beats. Beats is a family of tools which can gather a wide variety of data from logs to network data and uptime information.

Once the logs have been gathered by Logstash it needs somewhere to put them. While Logstash supports many different outputs one of the more exciting ones is Elastic search. Elastic search is a very powerful search engine which can index logs as they arrive. This makes running queries against the logs very quick. Elastic search is capable of handling huge quantities of logs and, in extreme cases, can be scaled out across many nodes. 

Log messages which have been crafted to contain parameters or which have had parameters split from them through Logstash processing can be queried directly as Elasticsearch preserves this information.

A query which searches for the top 10 pages visited by `jill@example.com` appears in Figure 8-1.

```
"query": {
    "match": {
      "user": "jill@example.com"
    }
  },
  "aggregations": {
    "top_10_pages": {
      "terms": {
        "field": "page",
        "size": 10
      }
    }
  }
```
**Figure 8-3** - An Elasticsearch query for finding top 10 pages visited by a user

The final component of the stack is Kibana. This tool is used for providing interactive visualizations in a web dashboard. Dashboards may be crafted even by users who are non-technical. Most any data which is resident in the Elasticsearch index can be included in the Kibana dashboards. Of course individual users may have different dashboard desires and Kibana enables this through allowing user specific dashboards. 

The Elastic stack can be installed on Azure in a number of ways. As per always it is possible to provision virtual machines and install Elastic Stack on them directly. This option is one which is preferred by some experienced users as it offers the highest degree of customizability. Of course, deploying on infrastructure as a service introduces a significant management overhead forcing those who take that path to take ownership of all the tasks associated with infrastructure as a service such as securing the machines and keeping up to date with patches. 

An option with less overhead is to make use of one of the many Docker containers on which the Elastic Stack has already been configured. These containers can simply be dropped into an existing Kubernetes cluster and run alongside application code. The [sebp/elk](https://elk-docker.readthedocs.io/) container is a particularly well documented and tested Elastic Stack container. 

>[!div class="step-by-step"]
>[Previous](observability-patterns.md)
>[Next](monitoring-azure-kubernetes.md)
