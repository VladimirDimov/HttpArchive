# HTTP Archive
The proposed infrastructural solution consists of the following modules:
- Angular front-end application
- HTTP Archive API
- Identity Server API
- MSSQL Database for storing users
- Mongo DB for storing files

![image](https://user-images.githubusercontent.com/10475215/147081067-5c86d971-dfd1-48bb-9247-1478030ad4b9.png)

# Motivation for selected technological stack
One of the key requirements of the task is to create a scalable application. The proposed approach will allow this. We are using distributed authentication, so if we can scale our application independetly. The HTTP Archive API can be scaled horisontally (no state, caching or other potential problems). Ideally it could be containerized and scaled more easily. 
The har files are stored in a Mongo database, which is very scalable with support for sharding and replicas. Also it's very performant. The file content is stored in it. It could go to a blob storage, but this solution requires more time. Bellow is an example approach for scaling the application. 

The current infrastructure is simple, due to the limited time, but it allows further scaling. An example approach would be as follows:
![image](https://user-images.githubusercontent.com/10475215/147082153-1e71f79f-bce7-4453-afb3-834911385d44.png)
