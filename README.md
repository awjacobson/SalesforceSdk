# SalesforceSdk
[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-%3E%3D%204.0-red.svg)](#) [![.NET Standard](https://img.shields.io/badge/.NET%20Standard-%3E%3D%202.0-red.svg)](#)

SalesforceSdk is a .NET implementation of the Salesforce API.

## Install SalesforceSdk via Nuget
If you want to include SalesforceSdk in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/AWJ.SalesforceSdk/)

To install SalesforceSdk, run the following command in the Package Manager Console
```
PM> Install-Package AWJ.SalesforceSdk
```

## Usage: WPF (.NET Framework)
### MainWindow.xaml.cs
```C#
var username = ConfigurationManager.AppSettings["Username"];
var password = ConfigurationManager.AppSettings["Password"];
var clientId = ConfigurationManager.AppSettings["ClientId"];
var clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
var sandbox = ConfigurationManager.AppSettings["Sandbox"];

using (var client = new BulkApiClient()
{
    Username = username,
    Password = password,
    ClientId = clientId,
    ClientSecret = clientSecret,
    IsSandbox = sandbox != null && sandbox == "true"
})
{
    if (client.Login())
    {
        var allJobs = client.GetAllJobs();
    }
}
```