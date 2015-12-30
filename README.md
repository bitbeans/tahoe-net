# tahoe-net [![NuGet Version](https://img.shields.io/nuget/v/tahoe-net.svg?style=flat-square)](https://www.nuget.org/packages/tahoe-net/) [![License](http://img.shields.io/badge/license-MIT-green.svg?style=flat-square)](https://github.com/bitbeans/tahoe-net/blob/master/LICENSE.md)

Simple basic communication with a tahoe-lafs client over the available REST API.

## Installation

There is a [NuGet package](https://www.nuget.org/packages/tahoe-net/) available.

## This project uses the following libraries

  * [Newtonsoft.Json]
  * [RestSharp]


[Newtonsoft.Json]:https://github.com/JamesNK/Newtonsoft.Json
[RestSharp]:https://github.com/restsharp/RestSharp

## Requirements

This library targets **.NET 4.5.1**.

## Usage

#### Direcories

###### Create a directory
```csharp
TahoeCommunication.CreateDir
```

###### Get some directory informations
```csharp
TahoeCommunication.GetDir
```

###### Get the file list of a directory
```csharp
TahoeCommunication.GetFileList
```

###### Get the used space of a directory
```csharp
TahoeCommunication.GetUsedSpace
```

#### Maintenance

###### Perform a check
```csharp
TahoeMaintenance.Check
```

###### Perform a deep check
```csharp
TahoeMaintenance.DeepCheck
```

###### Check a deep check (with handle)
```csharp
TahoeMaintenance.CheckDeepCheck
```

#### Gather

###### Read the pickle2json.py output
```csharp
TahoeGather.ConvertGatherOutput
```


## License
[MIT](https://en.wikipedia.org/wiki/MIT_License)