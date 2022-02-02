## Overview

This tutorial follows the step from [AWS CDK NET Workshop](https://cdkworkshop.com/40-dotnet.html)

## Installation & Setup

- install CDK Toolkit (cdk cli) - https://docs.aws.amazon.com/cdk/v2/guide/cli.html

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

## Notes

- the *id* parameter in a Construct has to be unique in the scope where is created
