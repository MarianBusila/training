## Overview

This tutorial follows the step from [AWS CDK NET Workshop](https://cdkworkshop.com/40-dotnet.html)

## Installation & Setup

- install CDK Toolkit (cdk cli) - <https://docs.aws.amazon.com/cdk/v2/guide/cli.html>

```
npm install -g aws-cdk
```

- create CDK app

```
cdk init sample-app --language csharp
```

## Useful commands

```
cdk synth - creates the CloudFormation templates in cdk.out folder

cdk bootstrap aws://810275592917/us-east-2 - bootstraps an environment (account/region). This creates the *CDKToolkit* stack in CloudFormation,which includes an Amazon S3 bucket for storing files and IAM roles that grant permissions needed to perform deployments.

cdk deploy - to deploy the stack

cdk diff - to compare your app with what is deloyed in AWS

cdk deploy --hotswap - to deploy just assets (lambda code), and not the cloud formation template, which can be long. To be used only in Dev.

cdk watch - monitors the files and automatically deploy lambda code(hotswap) or cloud formation changes

cdk destroy

```

## Best practices

- the *id* parameter in a Construct has to be unique in the scope where is created
- have multiple AWS accounts based on best practices of creating a landing zone (Dev, Stag, Prod, SharedServices (CICD pipelines))
- infrastructure code and application code lives in the same package
- use props in constructor, instead of env variables for customization
- don’t change the scope and logical ID of stateful resources (database, VPC) since it will destroy the resource. Write unit test to make sure it will not change.
- make decisions at synth time, not deployment time using if and function parameters
- use generated resource names, not physical names. You can’t make any more changes to the resource that requires it to be replaced when using physical names
- keep as many resources in the same stack as possible
- separate stateful resources (like databases) separated from the stateless resources
- avoid making network calls in your app. The result of that call might be different at synth time compared to deploy time. Instead use *.fromLookUp()* that saves values is **cdk.context.json** which should be commited to git
- allow AWS CDK to manage roles and security groups, by using code like *myBucket.grantRead(myLambda)* which assigns behind the scenes the persmissions to the Lambda role. Using precreated roles complicates things
- model all production stages in code. The code/config for all envs should be in the app. At synth time, *cdk.out* will contain a separate template for each env.
- define removal policies and log retention
- add metrics
- naming for stack ids: {context}{App}{Stage}. Ex: datalakeIngestionProd
- naming for construct ids: use camelCase and no special characters
- add tags
- use cdk.json to store config values and use a helper function to get the values

  ```
  "context": {
      "dev": {
          "account": 1234567,
          "region": "us-west-2",
          # ...
      },
      "prod": {
          # ...
      }
  }
  ```

  ```
  function getEnv(stage, key) {
      scope.node.tryGetContext(stage)[key]
  }
  ```

## Stacks

- a useful mental model of thinking about stacks is to separate them as outer and inner
  - outer stacks describe the stack purpose (eg. service stack)
  - inner stack are a component that makes up the outer stack (eg. monitoring)

- common outer stacks
  - foundation: vpc, security groups, etc
  - tools: ci/cd, automation, opsworks, etc
  - service|app: your user facing service or app
  - business|analytics: aws budgets, quicksignt, etc
  - security: config rules, acm certs, etc
  - ml|data pipeline: sagemaker, athena, etc

- common inner stacks
  - for applications
    - frontend
    - backend
    - database
  - for services
    - control plane
    - data plane
  - for any all stacks
    - logs and monitoring
    - automation

### References

- [Best practices for developing and deploying cloud infrastructure with the AWS CDK](https://docs.aws.amazon.com/cdk/v2/guide/best-practices.html)
- [CDK Guide of best practices](https://github.com/kevinslin/open-cdk)
