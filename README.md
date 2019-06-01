
# Magento-Peachpie

This project mirrors [Magento 1.9.4.1](https://magento.com/tech-resources/download) and tries to make it compile via [Peachpie](https://www.peachpie.io/) (on [GitHub](https://github.com/peachpiecompiler/peachpie)) to .NET.  
 In the process of doing this, some fixes (in Magento and used libraries) called "core hacks" are necessary to satisfy the static compiler - so be warned!

# ToDo

* some messages classified as warnings are rather serious, this should be fixed if possible
  * reduce warnings in general, optimal would be zero
  * some frequently occurring warnings are ignored right now (see `NoWarn` section in [.msbuildproj-file](https://github.com/tobihille/magento-peachpie/blob/master/website/magento.msbuildproj))
* a step-by-step - guide to setup would be nice
* generate a release build
* fix constant `Mage_Exception` errors

# Done

* compiled Magento into a .dll-file
* a minimal webserver exists utilizing [Kestrel](https://docs.microsoft.com/de-de/aspnet/core/fundamentals/servers/kestrel?view=aspnetcore-2.2) compiles into a .dll-file too
* webserver runs without startup problems

# State

* experimental (not even alpha)
