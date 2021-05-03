## Kafka Overview

- Kafka: a high-throughput distributed messaging system
- Kafka is a pub-sub messaging system consisting of Producers, Consumers and Brokers within a cluster
- ZooKeeper: centralized service for maintaining metadata about a cluster of distributed nodes
- Topic: it is a logical entity, phisically stored as a log and can be stored in multiple brokers
- Message / Record: has a timestamp (when is received by broker), identifier, payload
- Offset: a bookmark to the last read message from the topic
- Partition: the basis for which Kafka can scale and be fault-tolerant. A partition is physically saved in /tmp/kafka-logs/{topic}-{partition}/. A partition must fit entirely on one machine.
- retention period is defined per topic and by default is 7 days
- ISR: In Sync Replica

## Partitioning Trade-offs
 - the more partitions the greater the Zookeeper overhead
 - message ordering can become complex
 - the more partitions the longer the leader fail-over time

 ## Producer
  - producer sets a *timestamp* in the record it sends. When message is stored on the disk, the timestamp used depends on the setting *log.message.timestamp.type = [CreateTime, LogAppendTime]*. Create time is the producer-set timstamp. LoggAppendTime is the broker-set timestamp when message is appended to commit log
  - A *Key* determines to which physical partion the message will be sent: no key -> round robin, else -> key mod-hash
  - Kafka uses microbatches to publish, broker write, consume messages to achieve better throughput
  - message batching/buffering is controlled by *batch.size* (in bytes), *buffer.memory*, *max.block.ms* and *linger.ms*
  - delivery guarantees from broker: *acks*:
    - 0: fire and forget
    - 1: leader acknowledged
    - 2: replication quorum acknowledged
  - *retries* and *retry.backoff.ms*

  ## Consumer
  - use method *subscribe()*(for topics) or *assign()*(for partitions, more advanced use case)
  - subscribe instructs that we plan to poll data from all the topics (including all their partitions) it subscribed to
  - *poll()* it actually starts consuming messages
  - *poll()* process is a single-threaded operation
  - Offset behaviour: Read != Committed
  - consumer store the commited offsets in *__consumer_offsets* after finishing processing the records returned by the *poll()* method
  - Consumer Groups are independent consumers working as a team as part of a *group.id*
  - a GroupCoordinator is responsabile of assigning partitions evenly to consumers and rebalances the load in case a consumer fails or assigns a newly added partition to an existing consumer
  - seek(), seekToBeginning(), seekToEnd(), pause(), resume() are advanced methods to control the consumer position and the flow
  - Kafka Schema Registry:
    - uses Apache Avro serialization format
    - schema registry and version management
    - open source
  - Kafka Connect
    - it is a common framework for integration to allow to move data from sources like RDBMS, NoSQL, File to other RDBMS, NoSQL, File
    - more than 50 connectors
  - Kafka Streams
    - single infrasturcture solution. No need for Spark, Storm or Hadoop.