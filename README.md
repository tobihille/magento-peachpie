# magento-peachpie
This Project mirrors Magento 1.9.3.8 and tries to make it compile via peachpie (https://www.peachpie.io/) to .net.
In the Process of doing this some fixes called "core hacks" are neccessary to satisfy the static compiler - so be warned!

# ToDo
* some messages classified as warnings are rather serious (like missing mcrypt functions), this should be fixed if possible
  * reduce warnings in general, optimal would be zero
* a step-by-step - guide to setup would be nice
* generate a release build

# Done
* make it compile to a .dll - file
* a minimal webserver exists utilizing Kestral compiles into a dll too 
* webserver is runnable (more precise callable, still exceptions atm)

# State
* experimental (not even alpha)
