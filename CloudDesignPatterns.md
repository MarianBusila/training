# Cloud Design Patterns

# Overview

Cloud Design Patterns with a focus on Azure.

1. [GateKeeper](#gatekeeper)
2. [Gateway Aggregation](#gatewayaggregation)
3. [Gateway Offloading](#gatewayoffloading)

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

## Publish / Subscribe

- can be implemented with Azure ServiceBus Topics, EventHubs, EventGrid
- need to consider: ordering, poison messages, at least once delivery, message expiration and scheduling
  ![](images/csd/PublishSubscribeProblem.png)
  ![](images/csd/PublishSubscribeSolution.png)

## References

[30 Cloud Design Patterns in depth](https://www.youtube.com/watch?v=cxYHugyNTP0)
