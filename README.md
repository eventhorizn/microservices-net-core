# Microservices

![](images/mservice-overview.png)

What are microservices?

1. Small business services
1. Can work together
1. Can be deployed independently
1. Communicate w/ each other
1. Technology agnostic

![](images/mservice-characteristic.png)

# Monolithic vs Microservice

## Monolithic Pro-Con

![](images/monolithic-pro-con.png)

## Microservice Pro-Con

![](images/mservice-pro-con.png)

## Deployment Comparison

![](images/deploy-compare.png)

# Catalog API - MongoDB

## Big Picture

![](images/big-picture.png)

## Catalog Design and Architecture

![](images/catalog/overview.png)

### Endpoints

![](images/catalog/endpoints.png)

### Layered Architecture

![](images/catalog/layered-arch.png)

### Repository Pattern

![](images/catalog/repo-pattern.png)

## MongoDB Setup

We are going to set up mongo in our docker environment

1. [Official Docker Image](https://hub.docker.com/_/mongo)
1. Install mongo on Docker
   ```ps1
   docker pull mongo
   ```
   ```ps1
   docker run -d -p 27017:27107 --name shopping-mongo mongo
   ```
   - Port forwarding (check my docker repo for more info)
1. Run commands inside mongo docker container
   - To create tables, etc, everything you can do on mongodb
   ```ps1
   docker exec -it shopping-mongo /bin/bash
   ```
1. Hooking mongo up to .net
   - [MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) Nuget package
1. [MongoClient](https://hub.docker.com/r/mongoclient/mongoclient)
   ```ps1
   docker run -d -p 3000:3000 mongoclient/mongoclient
   ```
   - Gives us a GUI for our mongo db
   - Best part, it's ran from docker just like the db

## Mongo CLI Commands

Run this command to connect to mongo docker image

```ps1
docker exec -it shopping-mongo /bin/bash
```

1. This will have you running linux commands from w/i the docker image (which is a linux image)
1. Simply type `mongo` to enter the mongo db cli
1. Show databases
   ```js
   show dbs
   ```
1. Create new database
   ```js
   use CatalogDb
   ```
   ```js
   db.createCollection('Products');
   ```
1. Insert many items
   ```mongo
   db.Products.insertMany([{}, {}])
   ```
1. There are more, check the `mongo-commands.txt` in the `Services\Catalog` folder
