## Terminology
- Users
- Groups
- Policies: json documents to give permission to what a User/Group/Role is able to do
- Roles: they are assigned to AWS Resources and give them permission to access other AWS Resources

## Notes
- IAM resources are Global and not tight to a Region
- Users are assigned *Programatic access* (access key ID and secret access key) and / or *AWS Management Console access* (user and password)
- for a Group you can attach a policy like AdministratorAccess or Billing
- a policy has Effect (Allow, Deny), Action (s3:Get*, s3:PutObject), Resource(arn:aws:s3:::benchmark-aggregated)
- when you create a role, you choose the service that will use the role (Ec2 for example), then you attach the permission policies (AmazonS3FullAccess)