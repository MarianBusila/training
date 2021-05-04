## Build and Deploy

```
# build image and run in docker container and visist http://localhost:9000/info
docker image build -t helm-dotnet:v1 .
docker run --env APPENVIRONMENT=production --env APPHOST=docker --rm -it -p 9000:80 helm-dotnet:v1

# tag image and push to docker hub repository
docker tag helm-dotnet:v1 marianbusila/helm-dotnet:v1
docker login
docker push marianbusila/helm-dotnet:v1

# install chart
helm install aspnet3release ./chart
kubectl get all --selector app=aspnet3core

# port forward and visit http://localhost:9999/info
kubectl port-forward service/aspnet3release-service 9999:8888

# upgrade chart
helm upgrade aspnet3release .\chart --values .\chart\production-values.yaml

# uninstall the realease
helm uninstall aspnet3release
```