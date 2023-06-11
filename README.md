## Instructions

The project requires docker to run.

Build the image .

```sh
docker build -t tiebreak-client -f .Dockerfile .
```

Run the image as a container .

```sh
docker run --name tiebreak-container tiebreak-client
```
