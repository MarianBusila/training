## Terraform & Terragrunt

Tutorial how to set up and EKS cluster using terrgrunt, based on [Terragrunt Tutorial: Create VPC, EKS from Scratch!](https://www.youtube.com/watch?v=yduHaOj3XMg). A few iterations are showcased on how to make the code DRY.

### Terraform V1

Copy pasted staging from dev. A lot of code duplication.

```
cd infrastructure-live-v1/dev/vpc
terraform init
terraform apply
terraform destroy
```

### Terraform V2

Refactor V1 using vpc module.

```
cd infrastructure-live-v2/dev/vpc
terraform init
terraform apply
terraform destroy
```

### Terraform V3

Refactor V2 using terragrunt.

```
cd infrastructure-live-v3/dev/vpc
terragrunt init
terragrunt apply
cd infrastructure-live-v3/staging/vpc
terragrunt init
terragrunt apply

cd infrastructure-live-v3
terragrunt run-all destroy
```

### Terraform V4

Add EKS cluster

#### Notes
- when specifying a dependency use _mock_outputs_ to be able to run _terragrunt run_ on 2 or more modules at the same time

```
cd infrastructure-live-v4/dev
terragrunt run-all init
terragrunt run-all plan
terragrunt run-all apply
// check cluster created ok
aws eks update-kubeconfig --name dev-demo --region us-east-1
kubectl get nodes
// check autscaller is installed and running correctly
helm list -A
kubectl get pods -n kube-system
kubectl logs -f autoscaller-aws-cluster-autoscaller-XXX -n kube-system

cd infrastructure-live-v4/staging
terragrunt run-all init
terragrunt run-all plan
terragrunt run-all apply

cd infrastructure-live-v4
terragrunt run-all destroy
```