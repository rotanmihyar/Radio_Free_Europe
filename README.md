# Radio Free Europe API

Summary

The project introduces a service that exposes 3 main APIs. The primary responsibility of these APIs is to store 2 strings per ID and compute the diff between them.

### APIs
<https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Radio_Free_Europe/Controllers/MainController.cs>

#### SetLeft
- **Path**: v1/diff/{Id}/left
- **Method**: Post
- **Params**: 
  - **Id:** Path Parameter that represents the ID of that diff.
  - **diffData:** JSON Body Parameter that represents the content of the string.

An API that allows passing the First/Left string for an ID to be compared or Dffrestiated.


![image](https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Screenshots/PostLeftApi.png)



#### SetRight
- **Path**: v1/diff/{Id}/right
- **Method**: Post
- **Params**: 
  - **Id:** Path Parameter that represents the ID of that diff.
  - **diffData:** JSON Body Parameter that represents the content of the string.

An API that allows passing the Second/Right string for an ID to be compared or Dffrestiated.

![image](https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Screenshots/PostRightApi.png)



#### GetDiff
- **Path**: v1/diff/{Id}
- **Method**: GET
- **Params**: 
  - **Id:** Path Parameter that represents the ID of that diff.

An API that computes the diff for the two strings previously provided for the given ID.

![image](https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Screenshots/GetApi.png)




### Main Components:

#### MainController
<https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Radio_Free_Europe/Controllers/MainController.cs>

A class that defines the Inputs, Outputs, and Paths for each of the APIs.

#### MainService
<https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Radio_Free_Europe/Services/MainServices/MainService.cs>

The service handles the API requests and delegates the responsibilities of storing the diff string and computing the diffs to the implementation of the classes IDiffStorage and IDiffFinder consequently.


#### LocalDiffStorage : IDiffStorage
<https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Radio_Free_Europe/Services/MainServices/Models/LocalDiffStorage.cs>

LocalDiffStorage is an implementation of the IDiffStorage interface that utilizes the local memory storage for storing the Diff inputs (left and right strings). The implementation is rather simple and has a set of limitations like:

`    `- At the moment, the data lives forever (as long as the service is running)

`    `- There is a risk of race condition

`    `- All data lives in the memory

`    `- this approach would be challenging if the service had more than one service/host, as the requests with the same ID must end up at the same server.

`    `- the data will be lost upon restarting the service




There can be other implementations of the interface IDiffStorage that solve some of these limitations. For example, a simple DB storage can be used to store the Diff inputs which would solve the limitations like losing the data upon restarting the service, or that all the data live in memory.

#### DiffFinder: IDiffFinder
DiffFinder is an implementation of the IDiffFinder interface that computes the diff between the 2 given strings. This implementation is a simple one and comparing the same inputs multiple times would require a full rerun of the compare functionality (no caching).

Another implementation of the interface IDiffFinder might be introduced to increase the efficiency of that method.


### Testing
#### 1- .Net Core Swagger
By running the project, a swagger window will be opened automatically that displays the list of APIs and gives the opportunity to call them.

![image](https://github.com/rotanmihyar/Radio_Free_Europe/blob/master/Screenshots/Swagger.png)

#### 2- Unit Testing
All of the main components have unit tests that test all the possible seniors (at least all that I could think of).


### Missing Items
Unfortunately, My team and I are having a couple of hard days at work (tight release deadline), and I couldn’t implement all of the requirements. Some of these missing requirements are:

- The APIs accept the body to JSON as a string, not BASE64 encoded.
- I have done the task on the weekend before the task deadline. Unfortunately, I didn’t understand the requirement that the diff must provide the offsets alongside the lengths of the inputs. And there is no time to ask for clarifications (I apologise for that). So I have improvised and implemented the diff functionality to return only the offsets.


