docker build -t mvcrandomanswers .

docker images
docker run -d -p 8000:8000 --name randomanswers mvcrandomanswers
docker exec randomanswers ipconfig

