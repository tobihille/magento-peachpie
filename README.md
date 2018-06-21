
# Magento-Peachpie

This Project mirrors [Magento 1.9.3.8](https://magento.com/tech-resources/download) and tries to make it compile via [Peachpie](https://www.peachpie.io/) (on [GitHub](https://github.com/peachpiecompiler/peachpie)) to .NET.  
 In the Process of doing this some fixes (in Magento and used libraries) called "core hacks" are neccessary to satisfy the static compiler - so be warned!

# ToDo

* some messages classified as warnings are rather serious (like missing mcrypt functions), this should be fixed if possible
  * reduce warnings in general, optimal would be zero
* a step-by-step - guide to setup would be nice
* generate a release build
* fix constant Mage_Exception errors

# Done

* make it compile to a .dll - file
* a minimal webserver exists utilizing Kestral compiles into a dll too
* webserver runs without startup problems

# State

* experimental (not even alpha)
