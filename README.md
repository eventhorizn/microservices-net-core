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

# Basket.API - Redis

## Big Picture

![](images/big-picture.png)

## Basket Design and Architecture

![](images/basket/overview.png)

### Endpoints

![](images/basket/endpoints.png)

### Layered Architecture

![](images/basket/layered-arch.png)

## Redis

We will be using redis in the basket api

1. Open-source NoSQL database
1. Remote Dictionary server
1. Key-value pairs
1. Data Structure Server
1. Extremely fast
1. Save data both on RAM and on disk

## Redis Setup

1. [Docker Image](https://hub.docker.com/_/redis)
   ```ps1
   docker pull redis
   ```
1. Docker run command
   ```ps1
   docker run -d -p 6379:6379 --name aspnetrun-redis redis
   ```
1. Get inside redis image
   ```ps1
   docker exec -it aspnetrun-redis /bin/bash
   ```

## Redis CLI

```bash
redis-cli
ping

set key value
get key
set name mehmet
get name
```
