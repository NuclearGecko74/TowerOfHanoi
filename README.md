# Torres de Hanoi en C# con Pilas

## Descripción
Este proyecto implementa el juego de las **Torres de Hanoi** en C# utilizando **pilas** como estructura de datos principal para manejar los discos. Además, el juego cuenta con una interfaz visual desarrollada con **Raylib**, lo que permite visualizar el estado de las torres y los movimientos de los discos.

## Objetivo
Comprender y aplicar el uso de pilas en C# mediante la implementación del juego de las **Torres de Hanoi**. Se busca gestionar los discos de manera eficiente y resolver el problema utilizando el enfoque recursivo clásico.

## Características del Programa
- Permite al usuario seleccionar el número de discos con los que desea jugar.
- Representa gráficamente las torres y los discos.
- Opción para resolver el problema automáticamente, mostrando cada movimiento.
- Implementación basada en **recursividad** para generar los movimientos óptimos.
- Incluye botones interactivos para iniciar la solución y reiniciar el juego.

## Código Principal
El proyecto se compone de varias clases:
- **Game.cs**: Maneja la lógica principal del juego y la interacción con el usuario.
- **Tower.cs**: Representa cada torre del juego y gestiona los discos mediante una pila.
- **Pila.cs**: Implementa la estructura de datos tipo pila para almacenar los discos.
- **Node.cs**: Define los nodos que componen la pila.
- **Button.cs**: Implementa botones interactivos para la UI.

## Requisitos
Para ejecutar este proyecto, necesitas:
- **.NET SDK** instalado.
- **Raylib-cs** para la representación gráfica.
- Un entorno de desarrollo compatible con C# (Visual Studio, JetBrains Rider, VS Code, etc.).

## Instalación
1. Clona este repositorio:
   ```sh
   git clone https://github.com/tu-usuario/torres-de-hanoi-csharp.git
   ```
2. Navega hasta el directorio del proyecto:
   ```sh
   cd torres-de-hanoi-csharp
   ```
3. Compila y ejecuta el proyecto:
   ```sh
   dotnet run
   ```

## Ejemplo de Uso
```sh
Seleccione la cantidad de discos: 3
```
_(Se abrirá la ventana gráfica con las torres y discos representados visualmente)_

Si se presiona el botón "Solve", se mostrarán los movimientos paso a paso hasta completar el juego.

## Notas
- La interfaz está implementada con **Raylib**, por lo que es necesario instalar la biblioteca antes de compilar el proyecto.
- La dificultad del problema crece exponencialmente con el número de discos, por lo que valores muy altos pueden hacer que la solución tarde en completarse.

## Autor
- **Anton Emir Olguin Cabrales**

## Licencia
Este proyecto se distribuye bajo la licencia MIT. Puedes usarlo y modificarlo libremente.

