## Presentación
¡Hola! Soy Miquel Riera.
Este es un repositorio donde comparto parte de mi trabajo de programación.
Soy un estudiante de animación, modelado 3D y programación de entornos interactivos.
Me especializo en el motor Unity (mis fortalezas son los VFX y shaders, programación y GameDesign) pero también tengo bases de ilustración (Adobe Photoshop) y de modelado y texturizado 3D (Autodesk Maya).
- Dejaré al final de este documento algunos datos de contacto.
- Se pueden encontrar enlaces a mis redes sociales en mi perfil.
- Para los interesados: Dispongo de un build de mi primer juego EXONEMA listo para jugar. Es un poco inestable, pero fue mi primer proyecto y le tengo mucho cariño.

## Contenidos
- Sistema de construcción y economía (RTS  3D)
- Sistema de movimiento y acciones (juego de ROL 2D)
- Sistema de movimiento tridimensional para nave espacial (Proyecto 3D)
- WIKI completa con información más detallada -> [URL página INICIO de WIKI](https://github.com/Aennareon/Personal-Projects/wiki/Inicio)

## Sistema de construcción y economía (RTS 3D)
- Paquete de Unity básico. -> [Paquete de Unity](BuildingSystemScripts)
- Carpeta de Scripts. -> [Archivos](BuildingSystem)
- Construcción: El archivo [Constructor](BuildingSystemScripts/Constructor/buildingPlacer.cs) permite guardar una lista de prefabs de edificios y previsualizarlos, rotarlos e instanciarlos en la escena. 
- Edificios: Cada edificio contiene dos scripts, uno para sus operaciones lógicas y otro para su información. Cada archivo de datos de un edificio específico hereda de [Building Data](BuildingSystemScripts/BuildingsData/BuildingData.cs) una serie de valores comunes en todos los edificios y un acceso al controlador global de la economía. Las acciones propias de cada edificio (operaciones, cálculos y otras funciones lógicas) se encuentran en otros archivos con el mismo nombre terminado en "L" de lógica.
- Ayuntamiento y economía: Antes de empezar a construir, siempre debe haber en la escena un edificio de ayuntamiento con el archivo maestro de gestión de economía [EconomyVault](BuildingSystemScripts/Economy/EconomyVault.cs) al que acceden los diferentes edificios antes de empezar a aplicar sus operaciones lógicas. Añadiré a la WIKI una explicación detallada del sistema económico implementado.

## Sistema de movimiento y acciones (juego de Rol 2D)
- Paquete de Unity básico -> [Paquete de Unity](2dRolMovement)
- Carpeta de Scripts -> [Archivos](2dRolMovementScripts)
- Este sistema permite seleccionar entidades con el ratón y moverlas haciendo clic en una posición del escenario.
- Ahora estoy implementando un sistema de selección múltiple y de formaciones (reordenar las entidades seleccionadas de forma ordenada en ubicación de destino).

## Sistema de movimiento tridimensional para nave espacial (Proyecto 3D)
- Script de movimiento -> [Archivo](SpaceShipMovementScripts/SpaceShipMovement.cs)
- Sistema de gestión de nave espacial basado en el clásico juego de mesa "Star Fleet Battels" de Star Treck.
- Movimiento tridimensional determinado por la capacidad energética de los motores.
- Todo el movimiento por fuerzas.

## Contacto personal
- email: xarxamiquelriera@gmail.com
- Youtube: @Aennareon
- Instagram: @aennareoon

## Licencia
Los proyectos y archivos contenidos en este repositorio están bajo la licencia MIT. Consulta el archivo [Licencia MIT](LICENSE) para obtener más información.
