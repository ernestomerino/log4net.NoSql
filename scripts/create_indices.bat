curl -XDELETE localhost:9200/logs
echo ""


curl -XPOST localhost:9200/logs -d '{
	"_all" : {"enabled" : true},
	"settings" : {
    	"number_of_shards" : 1
	},
	"mappings" : {
	    "apps":{
	        "_timestamp" : {
	            "enabled" : true,
	            "store" : true
	        },
	        "_ttl" : {
	        	"enabled" : true,
	        	"store" : true,
	        	"default" : "5000"
	        }
	    }
	  }
}'