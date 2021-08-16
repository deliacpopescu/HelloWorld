# HelloWorld
## How to deploy to Heroku. Login to heroku 
1.Login to Heroku 
```
heroku login 

```
2.Build container Build docker image:

```
docker build -t helloworlddeliapopescu

``` 
3.Create and run docker container

```
docker run -d -p 8081:80 --name helloworlddeliapoescu_container helloworlddeliapopescu

```

4.Push container
```
heroku container:push -a helloworlddeliapopescu web
```

5.Release the container
```
heroku container:release -a helloworlddeliapopescu web
```

