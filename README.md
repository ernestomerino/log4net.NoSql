log4net.NoSql
=============

A collection of log4net Appenders to NoSQL data stores. Currently only ElasticSearch is supported. 

Uses RESTSharp to communicate with the ElasticSearch REST Api and contains a custom Layout, which makes use of the RESTSharp JSON Serializer to convert the LoggingEvent into JSON. 

Usage:
============

Sample configuration specifying ES Host, Port, Index and DocType values


&lt;appender name=&quot;Elastic&quot; type=&quot;log4net.NoSql.Appender.ElasticSearchAppender, log4net.NoSql&quot;&gt;

  &lt;Host value=&quot;localhost&quot; /&gt;
  
  &lt;Port value=&quot;9200&quot; /&gt;
  
  &lt;Index value=&quot;logs&quot; /&gt;
  
  &lt;DocumentType value=&quot;apps&quot; /&gt;
  
  &lt;layout type=&quot;log4net.  NoSql.Layout.JsonLayout, log4net.NoSql&quot; /&gt;
  
&lt;/appender&gt; 

  
  

Testing:
============

Use the TestHarness project to configure and test logs are being written to a local instance of ElasticSearch. 

/scripts/create_indices.bat contains a script which will create an index called "logs", and enable and store the _timestamp and _ttl fields in ES. TTL is set to 5 seconds. 


Dependencies
=============
RestSharp
