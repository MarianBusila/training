# Cloud Design Patterns

# Overview

Cloud Design Patterns with a focus on Azure.

1. [GateKeeper](#gatekeeper)
2. [Gateway Aggregation](#gateway-aggregation)
3. [Gateway Offloading](#gateway-offloading)
4. [Gateway Routing](#gateway-routing)
5. [Priority Queue](#priority-queue)
6. [Publish Subscribe](#publish-subscribe)
7. [Queue Based Load Leveling](#queue-based-load-leveling)
8. [Asynchronous Request Reply](#asynchronous-request-reply)
9. [Bulkhead](#bulkhead)
10. [Static Content Hosting](#static-content-hosting)
11. [Claim Check](#claim-check)
12. [Ambassador](#ambassador)
13. [Anti Corruption Layer](#anti-corruption-layer)
14. [Strangler Fig](#strangler-fig)
15. [Backends For Frontends](#backends-for-frontends)
16. [Sidecar](#sidecar)
17. [Throttling](#throttling)

## GateKeeper

- the purpose is to have an aditional layer of security in front of application services (OAuth, hide the URL of application services, SSL Offloading)
- can be implemented with Azure API Management (OAuth, transformation policies) and ApplicationGateway(SQLIngection, cross site scripting)
- will add latency and a single point of failure

## Gateway Aggregation

- aggregate multiple individual requests into a single request
- can be implemented with Durable Functions (Fan In Fan Out)
- gateway has to be close to backend services to limit latency
- single point of failure
- performance bottleneck
- implement distributed tracing

![](images/csd/GatewayAggregation.png)

## Gateway Offloading

- need high availability and scalable

![](images/csd/GatewayOffloadingProblem.png)
![](images/csd/GatewayOffloadingSolution.png)

## Gateway Routing

- protect the client to make changes when backend urls change
- provide a single endpoint for the client
- can be implemented with Azure Front Door or Application Gateway

![](images/csd/GatewayRoutingProblem.png)
![](images/csd/GatewayRoutingSolution.png)

## Priority Queue

- can be implemented with Azure Service Bus Queues
- some message queues provide support for priority already
  ![](images/csd/PriorityQueueSolution1.png)

- this pattern can also be implemented with different queues for each priority
  ![](images/csd/PriorityQueueSolution2.png)

- instead of having dedicated consumers, we can have a pool of consumers for all the 3 queues, with the condition that a consumer must consume first from the high priority queues first
  ![](images/csd/PriorityQueueSolution3.png)

## Publish Subscribe

- can be implemented with Azure ServiceBus Topics, EventHubs, EventGrid
- need to consider: ordering, poison messages, at least once delivery, message expiration and scheduling
  ![](images/csd/PublishSubscribeProblem.png)
  ![](images/csd/PublishSubscribeSolution.png)

## Queue Based Load Leveling

- useful to any application that uses services that are subject to overloading
- not to be used if application expects a response from the service with minimal latency

![](images/csd/QueueBasedLoadLevelingSolution.png)

## Asynchronous Request Reply

- use this pattern when it is difficult to provide callback endpoints (websockets, webhooks) or because of firewall restrictions on the client side
- don't use it when you can use a service for asynchronous notifications (Event Grid) or responses must stream in realtime to the client
- use HTTP 202 and include Location and Retry-After headers
- should allow for cancellation of a request

![](images/csd/AsyncRequestReplyProblem.png)
![](images/csd/AsyncRequestReplySolution1.png)
![](images/csd/AsyncRequestReplySolution2.png)

## Bulkhead

- isolate resources used to consume backend services
- isolate critical consumers from standard consumers
- can be implemented using a dedicated pool of resources (ports, threads)
- can be combined with other patterns like circuit breaker
- can be implemented using containers

![](images/csd/BulkheadProblem1.png)
![](images/csd/BulkheadProblem2.png)
![](images/csd/BulkheadSolution1.png)
![](images/csd/BulkheadSolution2.png)

## Static Content Hosting

- place static content in storage (Azure Blob, AWS S3) instead of in a compute service to save on cost
- use CDN to better serve clients from different regions than where the storage account is

![](images/csd/StaticContentHostingProblem.png)
![](images/csd/StaticContentHostingSolution.png)

## Claim Check

- use when the message size cannot fit the supported message limit of the chosen message bus technology. For example Azure Service Bus has a limit of 256KB - 1 MB per message depending on the tier.
- message will be split into a claim check (samll) and a payload(big) saved into a storage

![](images/csd/ClaimCheckProblem.png)
![](images/csd/ClaimCheckSolution.png)

## Ambassador

- you need to build a common set of connectivity features for multiple microservices, languages, frameworks
- avoid breaking the DRY principle
- should allow clients to pass some context to the ambassador, like max number of retries

![](images/csd/AmbassadorProblem.png)
![](images/csd/AmbassadorSolution.png)

## Anti Corruption Layer

- allows to perform a multi stage migration from a legacy system to a new system

![](images/csd/AntiCorruptionLayerProblem1.png)
![](images/csd/AntiCorruptionLayerProblem2.png)
![](images/csd/AntiCorruptionLayerSolution1.png)
![](images/csd/AntiCorruptionLayerSolution2.png)
![](images/csd/AntiCorruptionLayerSolution3.png)

## Strangler Fig

- gradually migrate a back-end application to a new architecture, without affecting the website

![](images/csd/StranglerFigProblem.png)
![](images/csd/StranglerFigSolution1.png)
![](images/csd/StranglerFigSolution2.png)

- can be combined with Anti Corruption Layer

![](images/csd/StranglerFigSolution3.png)

## Backends For Frontends

- create separate backend services to be consumed by specific frontend applications

![](images/csd/BackendsForFrontendsProblem.png)
![](images/csd/BackendsForFrontendsSolution.png)

## Sidecar

- isolate in a different process some common functionality (log, configuration, proxy)
- used when having different technologies in the main applications, then the sidecar can offer these features

![](images/csd/SidecarProblem.png)
![](images/csd/SidecarSolution.png)

## Throttling

- control the consumption of resources used by the application
- can be implemented with Azure API Management

## References

[30 Cloud Design Patterns in depth](https://www.youtube.com/watch?v=cxYHugyNTP0)
