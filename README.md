# PixelSentinel  

PixelSentinel is a collection of programs consisting of a web client, server, and web services designed to facilitate the search for Minecraft servers on the internet. The primary objective of PixelSentinel is to create a browseable list of Minecraft servers, enriched with tags and scoring for enhanced user experience.

## Installation  

*To be updated*

0. Pre-requirements

The following instruction assumes that you have `git`, `docker`, `docker-compose` and `dotnet7 sdk` installed on your machine.

1. Clone the repository to your local machine  

```shell
git clone https://github.com/your-username/PixelSentinel.git
```

2. Navigate to the project directory

```shell
cd src
```

Modify the `docker-compose.yml` file in accordance with your needs, then launch the project.

```shell
docker-compose up -d
```

## Configuring dev environment

Follow these steps to debug the code on windows:  

1. Download **VisualStudio 2022** with WASM Debugging and Web Developement packages installed
2. Install and set up WSL v2
3. Download Docker Desktop and enable WSL support
4. Open the solution (/src/ServerIndex.sln) and set docker-compose as a startup project.

## License  

The license can be found [here](LICENSE.txt).  
Read it before making any changes or deploying the solution.