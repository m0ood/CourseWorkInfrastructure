#!/bin/bash

echo "* Add hosts ..."
echo "192.168.99.100 docker.lab docker" >> /etc/hosts

echo "* Add any prerequisites ..."
apt-get update
apt-get install -y ca-certificates curl gnupg lsb-release

echo "* Add Docker repository and key ..."
mkdir -p /etc/apt/keyrings
curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /etc/apt/keyrings/docker.gpg
echo "deb [arch=$(dpkg --print-architecture) signed-by=/etc/apt/keyrings/docker.gpg] https://download.docker.com/linux/ubuntu \
$(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null

echo "* Install Docker ..."
apt-get update
apt-get install -y docker-ce docker-ce-cli containerd.io docker-compose-plugin
sudo snap install docker

echo "* Add vagrant user to docker group ..."
usermod -aG docker vagrant

cd /WebCourseWork
echo "version: '3.4' 
 
networks: 
  services-network: 
    driver: bridge  
 
services: 
  WebCourseWork.Web: 
    container_name: WebCourseWork.Web 
    image: webcoursework.web:latest 
    depends_on: 
      - "WebCourseWork.API" 
    build: 
      context: WebCourseWork.Web 
      dockerfile: Dockerfile 
    environment:
        - WebCourseWork.API=http://webcoursework.api:80/
    ports: 
      - "5050:80" 
    networks: 
      - services-network 
   
  WebCourseWork.API: 
    container_name: WebCourseWork.API 
    image: webcoursework.api:latest 
    build: 
      context: WebCourseWork.API 
      dockerfile: Dockerfile     
    networks: 
      - services-network" >> /docker-compose.yml
docker-compose build
docker-compose up