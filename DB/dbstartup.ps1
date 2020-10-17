docker build -t persondb:latest .

docker network create mynet

docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=V3ldigSterktPassord@' -p 1433:1433 -d --name sql --hostname sql --network mynet persondb:latest 

Write-Output "waiting"
Start-Sleep -s 30
Write-Output "moving on"

#Må flyttes i eget script??
docker exec -it sql /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P V3ldigSterktPassord@ -i /usr/src/app/setup.sql