
# Magento-Peachpie

This project mirrors [Magento 1.9.4.1](https://magento.com/tech-resources/download) and tries to make it compile via [Peachpie](https://www.peachpie.io/) (on [GitHub](https://github.com/peachpiecompiler/peachpie)) to .NET.  
 In the process of doing this, some fixes (in Magento and used libraries) called "core hacks" are necessary to satisfy the static compiler - so be warned!

# ToDo

* some messages classified as warnings are rather serious, this should be fixed if possible
  * reduce warnings in general, optimal would be zero
  * some frequently occurring warnings are ignored right now (see `NoWarn` section in [.msbuildproj-file](https://github.com/tobihille/magento-peachpie/blob/master/website/magento.msbuildproj))
* generate a release build
* fix constant `Mage_Exception` errors

# Done

* compiled Magento into a .dll-file
* a minimal webserver exists utilizing [Kestrel](https://docs.microsoft.com/de-de/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.2) compiles into a .dll-file too
* webserver runs without startup problems

# How to setup

* clone this project
* copy app.config.sample to app.config and enter your values
* create a new db and install the magento 1 sample data (extract the file and import the .sql - file) from https://github.com/peachpiecompiler/peachpie/issues
  * change core_cache_option to disable all caches
  * change core_config_data, enter web/secure/base_url and web/unsecure/base_url
  * you can use ```INSERT INTO core_config_data (scope,scope_id,path,value)
VALUES
 ('default',0,'web/unsecure/base_url','http://localhost:5004/'),
 ('default',0,'web/secure/base_url','http://localhost:5004/');```
* follow the instructions to get peachpie running: https://github.com/peachpiecompiler/peachpie#how-to-use-peachpie
* change to 'webserver' - dir and run `dotnet clean; dotnet build` to see if everything is at least working on a basic level
* if yes you can now set breakpoints to e.g. index.php and start debugging by pressing F5

# State

* experimental (not even alpha)
* html output is generated, but the update scripts are failing
