## Presentación
!HOLA¡ Soy Miquel Riera.
Este es un proyecto personal bajo desarrollo para un sistema de RTS.
Soy un estudiante de animación, modelado 3D y programación de entornos interactivos.
Estoy desarrollando estos sistemas para Unity con la idea de tener ya las bases para mi trabajo de fin de grado.

## Contenidos
- Sistema de construcción y economia.
- Sistema de movimiento y acciones.

## Sistema de construcción y economia
- Construcción: El archivo [Constructor] ()
- Edificios: Cada edificio contiene dos scripts, uno para sus operaciones logicas y otro para su información. Cada archivo de datos de un edificio especifico hereda de [Building Data](BuildingSystemScripts/BuildingsData/BuildingData.cs) una serie de valores comunes en todos los edificios y un acceso a el controlador global de la economia. Las acciones propias de cada edificio (Operaciones, cálculos y otras funciones logicas) se encuentran en otros archivos con el mismo nombre terminado en "L" de logica.

## Licencia
Los proyectos y archivos contenidos en este repositorio está bajo la Licencia MIT. Consulta el archivo [Licencia MIT](LICENSE) para obtener más información.
