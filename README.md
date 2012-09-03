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
We are activly looing for anybody to contribute. Everybody is welcome but our only requirement is that you **be nice and helpful**. 

Use this forum both as a learning and teaching platform! :)
Whether you know how to code or not, come join and help build the project.

We can use anybody, there needs to be documentation, code, examples, tutorials, etc. Join and help build what you would like to see!

##Examples
Check out the CitrixServices.XenServer project in the repo for a quick prototype example (this will be updated as the project goes along)

