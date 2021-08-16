# HelloWorld
## How to deploy to Heroku. Login to heroku 
Login to Heroku 
```
heroku login 

```
Build container Build docker image:

```
docker build -t helloworlddeliapopescu

``` 
Create and run docker container

```
docker run -d -p 8081:80 --name helloworlddeliapoescu_container helloworlddeliapopescu

```


