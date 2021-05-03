## Architecture and Theory

* Container: an isolated area of an OS with resource usage limits applied
* Container are based on kernel namespaces (isolation) and control groups (setting limits)
* Docker client -> Docker Deamon -> containerd -> shim / runc -> which starts the container (on Linux)
* on Windows you can have native Windows containers (they use the HostOS Kernel) or Hyper-V containers (they use a light VM with its own kernel which runs on the host OS)
* containers do not contain a kernel. They use the one of the host. Generally linux containers run on linux hosts and windows containers run on windows hosts.

## Working with images
* an image is formed of mutiple layers and a json manifest file that reference those layers
```
// behind the scenes this gets the image manifest and pull the layers
docker image pull redis

// show how image was built by showing the layers and their size
docker history redis

// details about volumes, entrypoint, layers, etc
docker image inspect redis

// shows the sha of the image
docker image ls --digests
```

* images are stored in registry/repo/image(tag). Example: docker image pull  docker.io/redis:4.0.1

* locally when we build / pull an image we have *content hashes* for all the layers, but when we push them and store them in a registry, they are commpressed and there we store the *distribution hashes*

## Containerizing an app
* create the Dockerfile in the root of your app. CAPITALIZE instructions in a key  value format like INSTRUCTION value. Ex: FROM alpine, RUN npm install, EXPOSE 8080

```
// build context is the  current folder (.)
docker image build -t psweb .
// or code is in github
docker image build -t psweb https://github.com/psweb.git
//

// first is host port, second is container port
docker container run -d --name web1 -p 8080:8080 psweb
```

* multi stage builds docker files allow to build your app using a base build image, which containes compiler, etc, and then use those layers to create a deployable image which is based on a slim runtime base image

## Working with containers
```
docker container ls
docker container run -it alpine sh
docker container run -d alpine sleep 1d
docker container exec <containerid> ls -l
// stoping and restarting a container does not destroy any of its data that was written
docker container stop

docker port <container-name>
docker logs <container-name>
```
