# DockerPlayground
playing with docker

Simple setup with .net core web api talking to sql server in separate containers. 
Wide open endpoint to obtain JWT bearer token that may be used to interact with application where you can add persons and list them.

Build and start DB container by running dbstartup.ps1 script from DB folder.  DB initialisation may fail due to DB startup time. If this happens, run docker exec command from script manually

Build and start API application from Person folder running appStartup.ps1 script.

DockerPlayground.postman_collection.json contains export of postman request to interact with API.
