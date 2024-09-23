# SharedLibrary

## Descripci�n

- Definir l�gica de negocio, modelos, utilidades o servicios que son comunes a varias aplicaciones.
- Ayuda a mantener una arquitectura limpia y organizada, separando el c�digo com�n del c�digo espec�fico. Esto sigue el principio de separaci�n de preocupaciones (SoC).
- Al centralizar el c�digo compartido en una biblioteca, cualquier modificaci�n o correcci�n de errores solo se tiene que realizar en un solo lugar.
- Fomenta la modularizaci�n del c�digo, lo que hace que las aplicaciones sean m�s f�ciles de desarrollar y mantener.


## Uso comunes 

- Modelos y entidades: Las clases que representan modelos de datos o entidades.
- Componentes de acceso a datos: El acceso a bases de datos, repositorios, o clases que gestionan la persistencia de datos.
- Constantes y configuraciones: Valores constantes o configuraciones que deben ser accesibles en m�ltiples proyectos.
- Servicios utilitarios: Funcionalidades como la validaci�n, criptograf�a, logging  o servicios de utilidades que pueden ser centralizadas en una biblioteca compartida, en lugar de duplicar la l�gica en cada proyecto.