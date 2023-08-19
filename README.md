# PRACTICA 1
Aplicación de consola hecha en .net framework con C#
Es un pequeño programa donde nos permite cargar la cantidad de pasajeros de una flota de transporte publico, y podemos dar la orden si deben detenerse o se pueden poner en marcha.

## Capturas
### Menu principal
Al iniciar la APP nos encontramos con un pequeño menu, en el cual accederemos ingresando el número correspondiente por consola. 

![menuPrincipal](https://github.com/Bortoli94/LabNet2023/assets/95387602/7d2174e0-5b96-4ada-9f0d-13f802033351)

### 1 - Carga de pasajeros
En esta sección podemos cargar manualmente la cantidad de pasajeros de cada vehiculo, siendo como máximo 4 pasajeros para los taxis, y 20 para los colectivos.
Podemos elegir el orden en el que los queremos cargar y no es obligatorio cargarlos a todos, cabe mensionar que los datos estan inicializados en 0. 
Al seleccionar un vehículo el cursor se posiciona automaticamente en la linea del vehiculo seleccionado, por lo que en todo momento sabremos donde estamos guardando los datos.

![CargarPasajeros](https://github.com/Bortoli94/LabNet2023/assets/95387602/7a9e2433-70f8-4830-a4f1-2abbba22f2b5)


### 2 - Cambiar estado
En esta sección podemos tener el control del estado de los vehiculos, pasando de estar detenidos a estar en marcha, o de estar en marcha a estar detenido. 
Seleccionando una opción este atributo cambia automaticamente

![CambiarEstado](https://github.com/Bortoli94/LabNet2023/assets/95387602/fc412f99-ae8f-4a2d-a673-8d605e250591)

### 3 - Ver Transporte
Acá podemos acceder a toda la información ordenada en formato tabla, podremos ver la cantidad de pasajeros y el estado de cada vehículo

![EstadoGeneral](https://github.com/Bortoli94/LabNet2023/assets/95387602/7e34f618-5a92-4799-827b-c57ef40ab6ae)
