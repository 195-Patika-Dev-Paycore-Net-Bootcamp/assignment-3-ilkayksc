
# Patika Paycore .Net/.Net Core Bootcamp Homework-3 

A company is working on smart waste collection systems. A garbage collection or waste all points in the shortest time by using the collection tool in the most optimum and efficient way. Called in and collected all containers in n trips (fill and unload operations) is expected.


## API Usage
### Vehicle
#### Get All Vehicles
Returns all vehicles as a list
```http
  GET api/Vehicle
```

#### Get Vehicle By Id
Returns the desired vehicle
```http
  GET /api/Vehicle/GetVehicleById?id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |


#### Create New Vehicle
Creates a new vehicle
```http
  POST /api/Vehicle
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |
| `vehicleName`      | `String` | **Required**. Vehicle Name |
| `vehiclePlate`      | `String` | **Required**. Vehicle Plate |


#### Update New Vehicle
Updates the desired vehicle information
```http
  UPDATE /api/Vehicle/id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |
| `vehicleName`      | `String` | **Required**. Vehicle Name |
| `vehiclePlate`      | `String` | **Required**. Vehicle Plate |

#### Delete Vehicle By Id
Deletes the desired vehicle information

```http
  DELETE /api/Vehicle/id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |


### Container
#### Get All Containers
Returns all containers as a list
```http
  GET api/Container
```

#### Get Container By Id
Returns the desired container
```http
  GET /api/Container/GetContainerById?id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Container Id |

#### Create New Container
Creates a new container
```http
  POST /api/Container
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |
| `containerName`      | `String` | **Required**. Container Name |
| `latitude`      | `Double` | **Required**. latitude |
| `longitude`      | `Double` | **Required**. longitude |
| `vehicleId`      | `Long` | **Required**. Vehicle Id |

#### Update New Container
Updates the desired container information
```http
  UPDATE /api/Container/id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |
| `containerName`      | `String` | **Required**. Container Name |
| `latitude`      | `Double` | **Required**. latitude |
| `longitude`      | `Double` | **Required**. longitude |
| `vehicleId`      | `Long` | **Required**. Vehicle Id |

#### Delete Container By Id
Deletes the desired Container information

```http
  DELETE /api/Container/id
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Container Id |

#### Get Container By Vehicle Id
Returns the containers of the desired vehicle as a list

```http
  GET /api/Container/GetContainersByVehicleId?vehicleId
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `long` | **Required**. Vehicle Id |


#### Get Container Pieces By Vehicle Id
It divides the containers of the desired vehicle into the desired number of groups and returns as a list.

```http
  GET /api/Container/vehicleId/5
```

| Parametre | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `vehicleId`      | `long` | **Required**. Vehicle Id |
| `pieces`      | `Int` | **Required**. Number of Pieces|
