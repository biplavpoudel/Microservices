This is a project intended for the author to learn the basics of event-driven Microservice Architecture using:
ASP.NET WEB API, Docker, Kubernetes, RabbitMQ and gRPC.

## Prerequisites

1. **Platform**: 
   - Tested on Ubuntu 22.04 with WSL2 (Windows Subsystem for Linux 2).
   
2. **Tools Required**:
   - [Docker](https://docs.docker.com/get-docker/) (with Docker Desktop for Windows)
   - [Minikube](https://minikube.sigs.k8s.io/docs/start/) (v1.26+)
   - [Kubectl](https://kubernetes.io/docs/tasks/tools/install-kubectl/) (v1.22+)
   - [NGINX Ingress Controller](https://kubernetes.github.io/ingress-nginx/)
   - [SQL Server 2022](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (for Ubuntu, allow TCP)
   - [RabbitMQ .NET Client](https://www.rabbitmq.com/client-libraries/dotnet-api-guide) (v6.2.2)
   - [Metallb](https://metallb.universe.tf/installation/) (Addons for RabbitMQ)
   - [gRPC .NET Client](https://learn.microsoft.com/en-us/aspnet/core/grpc/?view=aspnetcore-8.0) (v6.2.2)