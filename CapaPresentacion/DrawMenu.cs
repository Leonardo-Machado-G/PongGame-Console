//Declaramos las librerias que vamos a utilizar
using System;
using Pong_Game.CapaNegocio;

//Declaramos el NameSpace
namespace Pong_Game.CapaPresentacion
{
	//Declaramos la clase
    public class DrawMenu
	{

		/*Metodo que condensa todo el menu de opciones en una interfaz para que dependiendo
		  del modo de juego en el que nos encontremos dibujar una u otra opcion, funciona por una
		  matriz con unas coordenadas, que dependiendo de donde queramos situar un determinado texto
		  le introduciremos una opcion u otra*/
		static public void drawOptionMenu()
		{

			for (int i = 0; i < 29; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (j == 0 && i != 0 || j == 118 && i != 0)
					{

						Console.Write("│");

					}
					else if (i == 0 || i == 28)
					{

						Console.Write("─");

					}
					else if (i == 1 || i == 27 || j == 1 && i != 1 || j == 117 && i != 1)
					{

						Console.Write("▒");

					}
					else if (i == 2 || i == 26 || j == 2 && i != 2 || j == 116 && i != 2)
					{

						Console.Write("█");

					}
					else if (i == 3 || i == 25 || j == 3 && i != 3 || j == 115 && i != 3)
					{

						Console.Write("▒");

					}
					else if (i == 13)
					{

						Console.Write("─");

					}
					else if (j == 15 && i >= 6 && i <= 11 || j == 22 && i >= 6 && i <= 11 ||
							 j == 28 && i >= 6 && i <= 11 || j == 35 && i >= 6 && i <= 8 ||
							 j == 44 && i >= 6 && i <= 11 || i == 6 && j >= 41 && j <= 47 ||
							 j == 57 && i >= 6 && i <= 11 ||
							 j == 67 && i >= 6 && i <= 11 || j == 74 && i >= 6 && i <= 11 ||
							 j == 80 && i >= 6 && i <= 11 || j == 87 && i >= 6 && i <= 11 ||
							 j == 93 && i >= 6 && i <= 8 || j == 100 && i >= 8 && i <= 11 ||
							 i == 11 && j >= 15 && j <= 22 || i == 6 && j >= 15 && j <= 22 ||
							 i == 8 && j >= 28 && j <= 35 || i == 6 && j >= 28 && j <= 35 ||
							 i == 11 && j >= 67 && j <= 74 || i == 6 && j >= 67 && j <= 74 ||
							 i == 11 && j >= 93 && j <= 100 || i == 6 && j >= 93 && j <= 100 || i == 8 && j >= 93 && j <= 100 ||
							 i == 7 && j == 81 || i == 8 && j == 82 || i == 9 && j == 83 || i == 10 && j == 84 ||
							 i == 11 && j == 85 || i == 11 && j == 86)
					{

						Console.Write("█");

					}

					else if (i == 15 && j >= 53 && j <= 65 && MainMenuController.mode == GameMode.OptionMode)
					{

						if (i == 15 && j == 53)
						{
							Console.Write("1. Game Size.");

						}

					}
					else if (i == 17 && j >= 53 && j <= 66 && MainMenuController.mode == GameMode.OptionMode)
					{

						if (i == 17 && j == 53)
						{
							Console.Write("2. Game Speed.");

						}

					}
					else if (i == 19 && j >= 53 && j <= 67 && MainMenuController.mode == GameMode.OptionMode)
					{

						if (i == 19 && j == 53)
						{
							Console.Write("3. Game Points.");

						}

					}
					else if (i == 21 && j >= 53 && j <= 69 && MainMenuController.mode == GameMode.OptionMode)
					{

						if (i == 21 && j == 53)
						{
							Console.Write("4. Game Handicap.");

						}

					}
					else if (i == 23 && j >= 53 && j <= 75 && MainMenuController.mode == GameMode.OptionMode)
					{

						if (i == 23 && j == 53)
						{
							Console.Write("5. Return to main menu.");

						}

					}

					else if (i == 15 && j >= 53 && j <= 67 && MainMenuController.mode == GameMode.OptionSize)
					{

						if (i == 15 && j == 53)
						{
							Console.Write("1. Small Stage.");

						}

					}
					else if (i == 17 && j >= 53 && j <= 68 && MainMenuController.mode == GameMode.OptionSize)
					{

						if (i == 17 && j == 55)
						{
							Console.Write("2. Medium Stage.");

						}

					}
					else if (i == 19 && j >= 53 && j <= 67 && MainMenuController.mode == GameMode.OptionSize)
					{

						if (i == 19 && j == 55)
						{
							Console.Write("3. Large Stage.");

						}

					}
					else if (i == 21 && j >= 53 && j <= 78 && MainMenuController.mode == GameMode.OptionSize)
					{

						if (i == 21 && j == 53)
						{
							Console.Write("4. Return to options menu.");

						}

					}
					else if (i == 23 && j >= 53 && j <= 60 && MainMenuController.mode == GameMode.OptionSize)
					{

						Console.Write(" ");

					}

					else if (i == 15 && j >= 53 && j <= 65 && MainMenuController.mode == GameMode.OptionSpeed)
					{

						if (i == 15 && j == 53)
						{
							Console.Write("1. Low Speed.");

						}

					}
					else if (i == 17 && j >= 53 && j <= 68 && MainMenuController.mode == GameMode.OptionSpeed)
					{

						if (i == 17 && j == 53)
						{
							Console.Write("2. Medium Speed.");

						}

					}
					else if (i == 19 && j >= 53 && j <= 67 && MainMenuController.mode == GameMode.OptionSpeed)
					{

						if (i == 19 && j == 53)
						{
							Console.Write("3. Hight Speed.");

						}

					}
					else if (i == 21 && j >= 53 && j <= 78 && MainMenuController.mode == GameMode.OptionSpeed)
					{

						if (i == 21 && j == 53)
						{
							Console.Write("4. Return to options menu.");

						}

					}
					else if (i == 23 && j >= 53 && j <= 60 && MainMenuController.mode == GameMode.OptionSpeed)
					{

						Console.Write(" ");

					}

					else if (i == 15 && j >= 53 && j <= 73 && MainMenuController.mode == GameMode.OptionHandicap)
					{

						if (i == 15 && j == 53)
						{
							Console.Write("1. Player 1 Handicap.");

						}

					}
					else if (i == 17 && j >= 53 && j <= 73 && MainMenuController.mode == GameMode.OptionHandicap)
					{

						if (i == 17 && j == 53)
						{
							Console.Write("2. Player 2 Handicap.");

						}

					}
					else if (i == 19 && j >= 53 && j <= 71 && MainMenuController.mode == GameMode.OptionHandicap)
					{

						if (i == 19 && j == 53)
						{
							Console.Write("3. Remove Handicap.");

						}

					}
					else if (i == 21 && j >= 53 && j <= 78 && MainMenuController.mode == GameMode.OptionHandicap)
					{

						if (i == 21 && j == 53)
						{
							Console.Write("4. Return to options menu."); ;

						}

					}
					else if (i == 23 && j >= 53 && j <= 60 && MainMenuController.mode == GameMode.OptionHandicap)
					{

						Console.Write(" ");

					}

					else if (i == 15 && j >= 53 && j <= 73 && MainMenuController.mode == GameMode.OptionCount)
					{

						if (i == 15 && j == 53)
						{
							Console.Write("1. Points to win (9).");

						}

					}
					else if (i == 17 && j >= 53 && j <= 73 && MainMenuController.mode == GameMode.OptionCount)
					{

						if (i == 17 && j == 53)
						{
							Console.Write("2. Points to win (6).");

						}

					}
					else if (i == 19 && j >= 53 && j <= 73 && MainMenuController.mode == GameMode.OptionCount)
					{

						if (i == 19 && j == 53)
						{
							Console.Write("3. Points to win (3).");

						}

					}
					else if (i == 21 && j >= 53 && j <= 78 && MainMenuController.mode == GameMode.OptionCount)
					{

						if (i == 21 && j == 53)
						{
							Console.Write("4. Return to options menu.");

						}

					}
					else if (i == 23 && j >= 53 && j <= 60 && MainMenuController.mode == GameMode.OptionCount)
					{

						Console.Write(" ");

					}

					else
					{

						Console.Write(" ");

					}

				}

				Console.WriteLine();

			}

		}

		/*Metodo que condensa todas las funciones para dibujar el menu comenzando desde una barra longitudinal,
		 luego el titulo, luego otra linea, el dibujo, otra linea, las opciones y otra linea*/
		static public void drawMenu()
		{

			//Dibujamos el limite superior
			createBarMenu();

			//Mostramos el titulo del juego
			drawTitle();

			//Creamos un limite entre el titulo y el ejemplo del juego
			createBarMenu();

			//Dibujamos un ejemplo del juego
			drawGameMenu();

			//Creamos un limite entre el juego y el titulo
			createBarMenu();

			//Mostramos estas opciones por pantalla
			Console.WriteLine("\n\t\t\t\t\t\t     1.Start Game.");

			Console.WriteLine("\n\t\t\t\t\t\t      2.Options.");

			Console.WriteLine("\n\t\t\t\t\t\t\t3.Exit.\n");

			//Creamos las barras inferiores de menu
			createBarMenu();

		}

		/*Metodo para dibujar un ejemplo del juego en funcion de una matriz que en sus coordenadas iremos
		  situando diversos elementos que queramos mostrar por consola*/
		static public void drawGameMenu()
		{

			for (int i = 0; i < 11; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (i <= 6 && j == 3 && i >= 4 ||
						i <= 6 && i >= 4 && j == 115)
					{

						Console.Write("█");

					}
					else if (i == 0 ||
							 i == 10)
					{

						Console.Write("▒");

					}
					else if (j == 59 &&
							 i != 0 && i != 10)
					{

						Console.Write("░");

					}
					else if (i == 7 &&
							 j == 29)
					{

						Console.Write("o");

					}
					else if (i != 0 && j == 1 ||
							 i != 10 && j == 117)
					{

						Console.Write("│");

					}
					else
					{

						Console.Write(" ");

					}

				}

				Console.WriteLine();

			}

		}

		//Metodo parar crear las barras inferiores y superiores del menu
		static public void createBarMenu()
		{

			for (int i = 0; i < 119; i++)
			{

				Console.Write("─");

			}

			Console.WriteLine("");
		}

		//Metodo que dibuja el titulo del juego en funcion de unas coordenadas
		static public void drawTitle()
		{

			for (int i = 0; i < 5; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (j < 29 &&
						j > 20 &&
						i != 1 && i != 2 && i != 4)
					{

						Console.Write("█");

					}
					else if (j == 20 ||
							 j == 53 ||
							 j == 44 ||
							 j == 70 ||
							 j == 77 ||
							 j == 94 ||
							 j == 101 && i != 2 && i != 3 && i != 1)
					{

						Console.Write("█");

					}
					else if (j < 53 &&
							 j > 44 &&
							 i != 1 && i != 2 && i != 3 ||
							 j == 28 && i != 4)
					{

						Console.Write("█");

					}
					else if (j < 101 &&
							 j > 94 && i != 3 && i != 2 && i != 1 ||
							 j == 101 && i == 3 ||
							 j == 100 && i == 2 ||
							 j == 101 && i == 2 ||
							 j == 102 && i == 2)
					{

						Console.Write("█");

					}
					else if (j == 71 && i == 0 ||
							 j == 72 && i == 1 ||
							 j == 73 && i == 2 ||
							 j == 74 && i == 3 ||
							 j == 75 && i == 4 ||
							 j == 76 && i == 4)
					{

						Console.Write("█");

					}
					else
					{

						Console.Write(" ");

					}

				}

				Console.WriteLine();

			}

		}

	}

}