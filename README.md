# .NET Microservices with Docker, Kubernetes, RabbitMQ & gRPC

This project demonstrates how to build and deploy **two .NET microservices** using modern cloud-native practices.  
It covers service scaffolding, implementing persistence, containerization, synchronous and asynchronous communication, and deployment to Kubernetes.

---

## 🏗️ Architecture Overview

![Project Architecture](<kubernetes microservice1.png>)

- **Ingress NGINX Controller** exposes services to the outside world.
- **Platform Service** communicates with SQL Server and publishes events to RabbitMQ.
- **Command Service** consumes events from RabbitMQ and communicates with Platform Service via REST and gRPC.
- **RabbitMQ** handles asynchronous communication.
- **SQL Server** provides persistent storage with a Kubernetes Persistent Volume Claim.
- **API Gateway (NGINX Ingress)** routes external requests to the right service inside the cluster.

---

## 🚀 Project Overview

- **Two .NET Microservices** built with the REST API pattern.
- **Dedicated persistence layers** for each service using SQL Server.
- **API Gateway pattern** for routing requests across services.
- **Synchronous communication** using HTTP and gRPC.
- **Asynchronous communication** using RabbitMQ as an event bus.
- **Docker** for containerization and **Kubernetes** for orchestration.

---

## 🛠️ Prerequisites

### Platform
- Tested on **Ubuntu 22.04 with WSL2** (Windows Subsystem for Linux 2).

### Tools Required
- [Docker](https://www.docker.com/) (with Docker Desktop for Windows)
- [Minikube](https://minikube.sigs.k8s.io/docs/) (v1.26+)
- [Kubectl](https://kubernetes.io/docs/tasks/tools/) (v1.22+)
- [NGINX Ingress Controller](https://kubernetes.github.io/ingress-nginx/)
- [SQL Server 2022](https://learn.microsoft.com/en-us/sql/linux/sql-server-linux-setup) (with TCP enabled for Ubuntu)
- [RabbitMQ .NET Client](https://www.rabbitmq.com/dotnet.html) (v6.2.2)
- [Metallb](https://metallb.universe.tf/) (Load balancer for Kubernetes, used with RabbitMQ)
- [gRPC .NET Client](https://grpc.io/docs/languages/csharp/) (v6.2.2)

---

## 📂 Services

1. **Platform Service**
   - Exposes REST APIs.
   - Publishes events to RabbitMQ.
   - Hosts a gRPC server for inter-service communication.
   - Uses SQL Server for persistence.

2. **Command Service**
   - Consumes events from RabbitMQ.
   - Communicates with Platform Service via HTTP & gRPC.
   - Maintains its own persistence layer.

---

## 📡 Communication Patterns

- **Synchronous**
  - REST over HTTP.
  - gRPC for efficient service-to-service communication.

- **Asynchronous**
  - Event-driven messaging with RabbitMQ.

---

## ☸️ Deployment

1. **Docker**
   - Each service containerized.
   - Images pushed to Docker Hub.

2. **Kubernetes**
   - Platform & Command services deployed into the cluster.
   - SQL Server deployed with Persistent Volume Claims and Secrets.
   - RabbitMQ deployed as a message bus.
   - API Gateway configured for routing external traffic.

---

## 🔑 Key Features

- Build and scaffold services with data models, repositories, DTOs, and controllers.
- Implement persistence using SQL Server inside Kubernetes.
- Use AutoMapper for mapping between entities and DTOs.
- Apply event-driven architecture with RabbitMQ.
- Enable synchronous and asynchronous messaging across services.
- Deploy complete system into a Kubernetes cluster with networking, secrets, and volumes.

---
