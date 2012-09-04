CitrixServices - The Developer API for Citrix
==============

A pluggable .NET based services layer for the different Citrix technology SDK.  This is intended to be a service layer that will abstract the different SDK's and make it easy to interact with the Citrix infrastructure.

A .NET based service layer for the different Citrix technologies.

## What's it about?

The CitrixServices project is aimed at being the .NET based, pluggable, RESTful service layer that abstracts the different Citrix product SDK giving a developer a consitent, easy way to build applications to interact with the Citrix infrastructure.
Given the pluggablity nature of this project the developer should be able to implement the ICitrixAPI Mobile and ICitrixAPIRoute interfaces, drop the compiled DLL into the plugins directory and implement any SDK to their choosing.

## Current Status

Currently this project is under
development, its changing as we iteriate through the dev process, and will change as we go. Jump on in an help!

## What products will be added the library?

Roughly the first target will be the Citrix XenServer abstraction, with the XenApp powershell and NetScaler abstrations next. Thats the initial plan, but as with everything open source, feel free to fork it and work on the abstraction that interests you!

## Contribute
We are activly looking for anybody to contribute. Everybody is welcome but our only requirement is that you **be nice and helpful**. 

Use this forum both as a learning and teaching platform! :)
Whether you know how to code or not, come join and help build the project.

We can use anybody, there needs to be documentation, code, examples, tutorials, etc. Join and help build what you would like to see!

##Examples
Check out the CitrixServices.XenServer project in the repo for a quick prototype example (this will be updated as the project goes along)
***
##Quick Tutorial
1. Create a new Class library project in Visual Studio 
2. Since this project uses the MEF framework you will need to add a reference in your plugin to the System.ComponentModule.Composition
3. You will need to add a reference to the CitrixServices.Plugin assembly. This will give you the interfaces you will need to implement in your plugin.
4. Add a new class to your project called XenServerAPIModule and implement the ICitrixAPIModule interface.
	1. override the string property Name
	2. override the string propery Version
	3. override the method Routes to return a List<ICitrixAPIRoute>. This will be the url routes you want your plugin to listen to and the controller associated to it.
5. Add a new class to your project called XenServerAPIRoute and implement the ICitrixAPIRoute
	1. override the string property Controller
	2. override the string property Name	
	3. override the string property Route
6. Add a new class to your project called ServersController and implment the ApiController interface.
7. Compile and copy your new dll to the bins/plugins directory of the API site. 
##### API Module Example Implementation
````c#
 [Export(typeof(ICitrixAPIModule))]
    public class XenServerAPIModule : ICitrixAPIModule
    {
        public List<ICitrixAPIRoute> Routes()
        {
            return new List<ICitrixAPIRoute>
            {
                new XenServerAPIRoute{ Controller="Servers", Name="XenServers API Route", Route="XenServer/Servers"}
            };
        }
        public string Name
        {
            get
            {
                return "XenServer API Module";
            }
        }
        public string Version 
        {
            get
            {
                return "0.0.1";
            }
        }
    }
````
##### API Route Example Implementation
````c#
public class XenServerAPIRoute : ICitrixAPIRoute
    {
        public string Controller { get; set; }
        public string Name { get; set; }
        public string Route { get; set; }
    } 
````
##### API Controller Example Implementation
````c#
 public class ServersController : ApiController
    {
        public string Get()
        {
            return "A list of configured XenServers";
        }
    }
````