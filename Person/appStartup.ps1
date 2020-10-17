docker build -t personapp:latest .


docker run -p 5000:80 -d --name personapp --network mynet personapp:latest 