# Smart-Building-PCS
# Smart Building Monitoring System

## Overview
The Smart Building Monitoring System is a training example for collecting and monitoring environmental data within a building. This project utilizes Arduino-based sensor nodes to gather data, a Raspberry Pi as a gateway for cloud transmission, and Azure services for efficient data storage and management. Additionally, a computer acts as a real-time monitoring interface, receiving updates through a TCP socket connection.

## Key Components

### Arduino Sensor Node
- Gathers data from various sensors within the building.

- ![Skjermbilde 2023-11-16 105153](https://github.com/Zakaria989/Smart-Building-PCS/assets/58915560/30d680fd-88e2-4317-b554-122fc4e093d5)


### Raspberry Pi Gateway
- Sends sensor data to Azure IoT Hub for cloud integration.
- Stores data in Azure SQL Database for historical analysis.
- Establishes a TCP socket connection for real-time updates to a monitoring computer.

### Azure IoT Hub
- Centralized message broker enabling bidirectional communication between Arduino and Raspberry Pi.

### Azure SQL Database
- Stores and manages historical sensor data for further analysis.

### Monitoring Computer
- Receives real-time data from the Raspberry Pi through a TCP socket connection.
- Provides a user interface for monitoring and interacting with the building's environmental data.

## Usage

### Sensor Data Collection
- Arduino nodes collect temperature, door status, and pump level data.

### Cloud Integration
- Raspberry Pi sends data to Azure IoT Hub for cloud processing.

### Data Storage
- Sensor data is stored in Azure SQL Database for historical analysis.

### Real-time Monitoring
- Monitoring computer receives real-time data via a TCP socket connection, offering a user-friendly interface to stay updated on building conditions.
