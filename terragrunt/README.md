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