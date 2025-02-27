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
