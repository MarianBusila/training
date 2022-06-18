# Data Analytics

## Kinesis Data Streams

- a Stream is composed of multiple Shards
- a produced Record has a partition key and a data blob(max 1 MB)
- producer: 1 MB/sec or 1000 msg/sec per shard
- a consumed Recods has a partition key, sequence number and a data blob
- consumer: 2MB/sec per shard / per all consumers
- has on-demand capacity for autoscalling
- scaling: we can split (scale up) or merge shards(scale down)
- scaling takes time, one shard at a time can take a few seconds (1000 shards takes 8.3 hours to double to 2000 shards)

## Kinesis Data Firehose

- it is for near realtime processing (60 sec latency min)
- can read data from Kinesis DataStreams, CloudWatch, etc and can batch write to S3, Redshift, ElaticSearch, Splunk
- auto scalling 
- data transformation can be done with Lambda if needed