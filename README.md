## Presentación
!HOLA¡ Soy Miquel Riera.
Este es un proyecto personal bajo desarrollo para un sistema de RTS.
Soy un estudiante de animación, modelado 3D y programación de entornos interactivos.
Estoy desarrollando estos sistemas para Unity con la idea de tener ya las bases para mi trabajo de fin de grado.

## Contenidos
- Sistema de construcción y economia (RTS  3D)
- Sistema de movimiento y acciones (juego de ROL 2d)

## Sistema de construcción y economia (RTS 3D)
- Construcción: El archivo [Constructor](BuildingSystemScripts/Constructor/buildingPlacer.cs) permite guardar una lista de prefabs de edificios y previsualizarlos, rotarlos e instanciarlos en la escena. 
- Edificios: Cada edificio contiene dos scripts, uno para sus operaciones logicas y otro para su información. Cada archivo de datos de un edificio especifico hereda de [Building Data](BuildingSystemScripts/BuildingsData/BuildingData.cs) una serie de valores comunes en todos los edificios y un acceso a el controlador global de la economia. Las acciones propias de cada edificio (Operaciones, cálculos y otras funciones logicas) se encuentran en otros archivos con el mismo nombre terminado en "L" de logica.
- Ayuntamiento y economia: Antes de empezar a construir siempre debe haber en la escena un edificio de ayuntamiento con el archivo maestro de gestión de economia [EconomyVault](BuildingSystemScripts/Economy/EconomyVault.cs) al que acceden los diferentes edicifios antes de empezar a aplicar sus operaciones logicas. Añadiré a la WIKI una explicación detallada del sistema economico implementado.

## Sistema de movimiento y acciones (Juego de Rol 2D)
- Ahora mismo en mi tiempo libre dedico un rato a crear las bases de un sistema de movimiento para un juego de rol en tiempo real 2D.
- Este sistema permite seleccionar entidades con el ratón y moverlas haciendo click en una posición del escenario.
- Ahora estoy implementando un sistema de selección multiple y de formaciones (Reordenar las entidades seleccionadas de forma ordenada en ubicación de destino).

## Futuras incorporaciones a este repositorio
- Sistema de gestión de nave espacial basado en el clásico juego de mesa "Star Fleet Battels" de Star Treck.

## Licencia
Los proyectos y archivos contenidos en este repositorio está bajo la Licencia MIT. Consulta el archivo [Licencia MIT](LICENSE) para obtener más información.
