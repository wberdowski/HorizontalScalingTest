# HorizontalScalingTest

### Prerequisites
- [Docker](https://docs.docker.com/get-docker/) installed on your machine.
### Clone the repository
```
git clone https://github.com/your-username/your-repo.git
```
### Build and run
```
docker-compose up -d
```
### Testing
Access the Nginx load balancer in your web browser:
```
http://localhost:5050
```
To observe how the data changes across different API instances, simply press F5 (or refresh the browser) multiple times.
Nginx will distribute incoming requests across API containers, and you'll notice the data changes as you refresh, demonstrating horizontal scaling.
