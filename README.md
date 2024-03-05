# MQTT Broker Application

## Overview

The MQTT Broker Project leverages the .NET 8.0 framework and MQTTnet, a high-performance .NET library for MQTT-based communication, to facilitate messaging between devices and services. Designed for scalability, it supports a wide range of IoT applications, offering robust messaging capabilities with enhanced security features including authentication and authorization.

## Detailed Description

The MQTT Broker Project is a comprehensive .NET 8.0 application designed to facilitate robust and secure MQTT communication between various devices and services in IoT ecosystems. Leveraging the high-performance MQTTnet library, the project provides an efficient, scalable solution for real-time messaging, supporting a wide range of IoT applications from home automation to industrial telemetry.

At its core, the project offers a fully integrated MQTT broker setup, enabling devices to publish and subscribe to messages efficiently. It enhances security through custom authentication and authorization mechanisms, ensuring that only authorized devices and services can interact within the network. Global exception handling is implemented to ensure the system's reliability and resilience, capturing and managing unexpected errors gracefully.

WebSocket support is included, allowing for MQTT communication over web protocols, making it ideal for web-based IoT applications requiring real-time data exchange. The project's architecture is designed with modularity and scalability in mind, facilitating easy expansion and customization to meet specific application needs.

With its focus on security, performance, and scalability, the MQTT Broker Project aims to provide a solid foundation for developers looking to build or integrate MQTT communication capabilities into their .NET-based IoT solutions, ensuring secure, reliable, and efficient messaging across devices and services.

## Key Features

- **MQTT Broker Integration**: Utilizes MQTTnet for handling MQTT communications.
- **Security**: Implements custom authentication and authorization for secure message exchange.
- **Error Handling**: Features global exception handling for improved application robustness.
- **WebSocket Support**: Offers WebSocket connections for real-time web applications.
- **Modular Design**: Ensures a clear separation of concerns for maintainability and scalability.

## Prerequisites & Dependencies

Before you begin, ensure you have the following prerequisites installed on your system:

- Visual Studio 2022, VS Code, or any IDE compatible with .NET 8.0
- .NET 8.0 SDK

Additionally, this project depends on several NuGet packages. Below is the list of necessary packages with their respective versions and links to their NuGet pages for more information. Ensure these are correctly restored by following the setup instructions provided in the [Setup Instructions](#setup-instructions) section.

- [`Microsoft.AspNetCore.WebUtilities` version `8.0.2`](https://www.nuget.org/packages/Microsoft.AspNetCore.WebUtilities/8.0.2)
- [`Microsoft.Extensions.DependencyInjection` version `8.0.0`](https://www.nuget.org/packages/Microsoft.Extensions.DependencyInjection/8.0.0)
- [`Microsoft.Extensions.Logging` version `8.0.0`](https://www.nuget.org/packages/Microsoft.Extensions.Logging/8.0.0)
- [`MQTTnet` version `3.1.2`](https://www.nuget.org/packages/MQTTnet/3.1.2) - Utilized for MQTT protocol support.
- [`MQTTnet.AspNetCore` version `3.1.2`](https://www.nuget.org/packages/MQTTnet.AspNetCore/3.1.2) - Facilitates the integration of MQTTnet with ASP.NET Core.
- [`Newtonsoft.Json` version `13.0.3`](https://www.nuget.org/packages/Newtonsoft.Json/13.0.3) - Employed for JSON processing.
- [`RabbitMQ.Client` version `6.8.1`](https://www.nuget.org/packages/RabbitMQ.Client/6.8.1) - Required for RabbitMQ support.
- [`System.Collections` version `4.3.0`](https://www.nuget.org/packages/System.Collections/4.3.0) - Provides support for collections in .NET.
- [`System.Text.Json` version `8.0.2`](https://www.nuget.org/packages/System.Text.Json/8.0.2) - Used for high-performance JSON processing.

To install these packages, you can use the .NET CLI command `dotnet restore` within the project directory after cloning the repository and navigating to the project folder as mentioned in the setup instructions.

## Setup Instructions

1. **Clone the Repository**
   ```
   git clone <[repository-url](https://github.com/khalidalrifai/MQTT-Broker-Application)>
   ```
2. **Navigate to Project Directory**
   ```
   cd MQTTBrokerProject
   ```
3. **Restore NuGet Packages**
   ```
   dotnet restore
   ```
4. **Build the Project**
   ```
   dotnet build
   ```

## Running the Application

- **Using .NET CLI**
  ```
  dotnet run
  ```
- **Using an IDE**: Open the project in Visual Studio or your preferred IDE and run using the built-in tools.

## Configuration

Modify the `appsettings.json` file to customize MQTT broker settings, client settings, and logging configurations as per your requirements.

- **MQTT Broker Settings**: Configure host, port, and security options.
  ```json
  "MqttBrokerSettings": {
    "Host": "localhost",
    "Port": 1883,
    "SecurePort": 8883,
    ...
  }
  ```

- **Logging**: Fine-tune logging levels and destinations in the `Logging` section.

## How to Use

### Publishing MQTT Messages

Inject `IMqttAppService` where needed and use the following snippet to publish messages:

```csharp
await mqttService.PublishAsync("your/topic", "Hello MQTT");
```

### Subscribing to MQTT Topics

Inject `IMqttAppService` and subscribe to topics as shown below:

```csharp
await mqttService.SubscribeAsync("your/topic");
```

## Documentation

For more details on MQTTnet and .NET 8.0:
- [MQTTnet GitHub Repository](https://github.com/chkr1011/MQTTnet)
- [.NET 8.0 Documentation](https://docs.microsoft.com/en-us/dotnet/)

## Contributing

I welcome contributions of all forms. Feel free to fork the project, make improvements, and submit pull requests. For major changes, please open an issue first to discuss what you would like to change.

## License

Distributed under the MIT License. See the `LICENSE` file for more information.

## Acknowledgments

- MQTTnet for providing the MQTT library used in this project.
- The .NET team for the comprehensive .NET 8.0 framework.

## About MQTT

MQTT (Message Queuing Telemetry Transport) is a lightweight, publish-subscribe network protocol that transports messages between devices. It's designed for low-bandwidth, high-latency environments, making it exceptionally well-suited for IoT applications. This project's implementation provides a robust foundation for building MQTT-based applications, with an emphasis on security, scalability, and reliability.
