# Tweet Stream
 
JHA coding test.
 
This was fun. Thanks for the opportunity. 
 
Tech:
- RESTful API 
- Background Ingestion service
- Dot Net/EF Core
 
It would be really cool if this was event driven, and we could ingest events from Twitter. In that case we could do some cloud functions/lambda. For the sake of brevity and ease of review I'm persisting tweets to SQLite database. In the "real world" I would rather be a recipient than a requestor of the data, to scale this. But hey, it's a coding test. 
 
You should find careful consideration has been given the application layer boundaries herein. Again, with more time to execute, I would have pitched a cloud solution.
 
A background runner CLI app polls the REST API specified in the reqs for new tweets. Spin up the RESTful web service and hit 
```
https://localhost:44374/tweet
```
For tweets, and the below for the statistics in the reqs:
```
https://localhost:44374/statistics
```
 
### Before the first run:
```
Update-Database
```
Via Package Manager Console with the `SimpleDataAccess` project selected in the Visual Studio drop down. This creates and migrates a SQLite DB.