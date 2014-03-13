log4net.NoSql
=============

A collection of log4net Appenders to NoSQL data stores. Currently only ElasticSearch is supported. 

Uses RESTSharp to communicate with the ElasticSearch REST Api and contains a custom Layout, which makes use of the RESTSharp JSON Serializer to convert the LoggingEvent into JSON. 

Testing:
============

Use the TestHarness project to configure and test logs are bwing written to a local instance of ElasticSearch. 

/scripts/create_indices.bat contains a script which will create an index called "logs", and enable and store the _timestamp and _ttl fields in ES. TTL is set to 5 seconds. 


Dependencies
=============
RestSharp
