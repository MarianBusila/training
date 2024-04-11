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