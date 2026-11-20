
## CarteleraCine

Programa de consola en C# (.NET 10) que administra las funciones de la cartelera de un cine en SQL Server (LocalDB) con un CRUD completo: registrar, listar, buscar por Id, actualizar precio y eliminar. Todas las consultas son parametrizadas y los errores de la base de datos se controlan con try/catch en el menú.......

- **Curso:** Algoritmos (008), UMG Chiquimulilla
- **Estudiante:** Sergio Augusto Diaz Chacon
- **Carnet:** 1790-26-20684

## Menú

1. Registrar función
2. Listar funciones
3. Buscar función por Id
4. Actualizar precio
5. Eliminar función
6. Salir

## Requisitos

- Visual Studio Community 2026
- .NET 10
- SQL Server LocalDB ((localdb)\MSSQLLocalDB)
- Paquete NuGet Microsoft.Data.SqlClient

## Cómo ejecutarlo

1. Clonar o descargar este repositorio.
2. Ejecutar **primero** el script `01_crear_CarteleraDB.sql` en LocalDB (una sola vez). Crea la base CarteleraDB, la tabla Funciones y las funciones de Coco (Sala 1, Q 40.00) y Moana (Sala 2, Q 45.00).
3. Abrir la solución (`.sln`) en Visual Studio.
4. Presionar **F5** (con depuración) o **Ctrl+F5** (sin depuración).
5. Elegir una opción del menú en la consola.

Los precios se escriben con punto, por ejemplo 50.00.

## Escenarios probados

### Escenario 1: registrar Encanto, Sala 3, precio 50.00 (opción 1) y listar (opción 2)

Resultado esperado: "Función registrada."; la lista muestra Coco, Moana y Encanto, con TOTAL DE PRECIOS: Q 135.00

### Escenario 2: buscar el Id 9 (opción 3)

Resultado esperado: "No existe ese Id."

### Escenario 3: actualizar el precio del Id 2 a 55.00 (opción 4)

Resultado esperado: "Función actualizada."

### Escenario 4: eliminar el Id 1 (opción 5) y listar

Resultado esperado: "Función eliminada."; la lista muestra Moana (Q 55.00) y Encanto (Q 50.00), con TOTAL DE PRECIOS: Q 105.00

### Escenario 5: dato inválido al registrar (opción 1) con el precio vacío o en 0

Resultado esperado: "Datos inválidos." y no se guarda nada.

### Escenario 6: nombre de base inexistente en la cadena de conexión y opción 2

Resultado esperado: el programa no se cae; muestra "Error de base de datos: ..." y vuelve al menú.

## Capturas

![Captura 1](capturas/Cap1.png)
![Captura 2](capturas/Cap2.png)
![Captura 3](capturas/Cap3.png)
![Captura 4](capturas/Cap4.png)
![Captura 5](capturas/Cap5.png)
![Captura 6](capturas/Cap6.png) 



