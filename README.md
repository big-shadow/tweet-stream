# Tweet Stream
 
JHA coding test.
 
This was fun. Thanks for the opportunity. 
 
Architecture:
- REST API 
- Tweet Ingestion microservice
- Dot Net/EF Core
- SQLite
 
It would be really cool if this was event driven, and we could ingest events from Twitter. In that case we could do some cloud functions/lambda. For the sake of brevity and ease of review I'm persisting tweets to SQLite database. In the "real world" I would rather be a recipient than a requestor of the data, to scale this. But hey, it's a coding test. 
 
You should find careful consideration has been given the application layer boundaries herein. Again, with more time to execute, I would have pitched a cloud solution.
 
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
Then, Run the `BackgroundTaskRunner` service to ingest the stream. Stop it, or leave it running, before running the REST API to watch the statistics get updated by the `BackgroundTaskRunner` ingestion service.
![Logo](https://i.ibb.co/bPMWN6L/feed.png)

#### Step 4
Spin up the RESTful web service. For tweets:
```
https://localhost:44374/tweet
```
![Logo](https://i.ibb.co/dgz9sn7/rest.png)

For statistics:
```
https://localhost:44374/statistics
```