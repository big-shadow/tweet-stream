# Tweet Stream
 
Ray's JHA coding test.
 
This was fun. Thanks for the opportunity. 
 
Architecture:
- REST API 
- Tweet Ingestion microservice
- Dot Net/EF Core
- SQLite

It would be really cool if Twitter's feed was event driven, rather than a stream. In that case I would recommend some serverless cloud functions/lambda. In the "real world" I would rather be a recipient than a requestor. But hey, it's a coding test.
 
You should find careful consideration has been given to the application layer boundaries herein. Again, with more time to execute, I would have pitched a cloud solution. (Elastic search, firehose/queue, serverless ingestion service surface, etc!)
 
The `Domain` project is loosely coupled with both the API and service projects, and could totally be a nuget package in an enterprise environment. `Domain` dependencies are injected into both projects respectively. 
 
### Before the first run:
#### Step 1
```
Update-Database
```
Via Package Manager Console with the `SimpleDataAccess` project selected in the Visual Studio drop down. This creates and migrates a SQLite DB.
 
#### Step 2
Then, Set some key values in `BackgroundTaskRunner\appsettings.json` and `TwitterFeed\appsettings.json`
```JavaScript
// This is the path to the DB created with Update-Database above
"TweetsSQLiteDBPath": "C:\Source\tweet-stream\TwitterFeed\Tweets.db",
 
// This one's only needed in the background runner
"TwitterApiKey": "Your key goes here",
```
 
#### Step 3
Then, Run the `BackgroundTaskRunner` service to begin ingesting and processing the Tweet stream. Leave it running. :)
 
![Logo](https://i.ibb.co/bPMWN6L/feed.png)
 
#### Step 4
Spin up the REST API web service. For tweets:
```
https://localhost:44374/tweet
```
![Logo](https://i.ibb.co/dgz9sn7/rest.png)
 
For statistics:
```
https://localhost:44374/statistics
```
![Logo](https://i.ibb.co/5cTBfNQ/stats.png)
