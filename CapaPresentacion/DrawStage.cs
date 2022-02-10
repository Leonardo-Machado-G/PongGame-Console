//Declaramos las librerias que vamos a utilizar
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong_Game.CapaNegocio;

//Declaramos el namespace
namespace Pong_Game.CapaPresentacion
{

	//Declaramos la calse
	public class DrawStage
	{

		/*Este metodo sirve para mostrar el pequeño tutorial de como jugar al comenzar a ejecutarse
		 el juego, consiste en una matriz, con un sistema de coordenadas que situa elementos en pantalla
		  dependiendo del resultado que queramos lograr*/
		public static void drawTutorial()
		{

			for (int i = 0; i < 29; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (i == 0 || i == 28 || j == 0 || j == 118) {

						Console.Write("░");

					} else if (i == 1 || i == 27 || j == 1 || j == 117) {

						Console.Write("█");

					} else if (i == 2 || i == 26 || j == 2 || j == 116) {

						Console.Write("░");

					}
					else if (j == 23 && i <= 23 && i >= 5 || j == 46 && i <= 23 && i >= 5 ||
							 j == 69 && i <= 23 && i >= 5 || j == 92 && i <= 23 && i >= 5 ||
							 j >= 23 && j <= 46 && i == 5 || j >= 69 && j <= 92 && i == 5 ||
							 j >= 23 && j <= 46 && i == 23 || j >= 69 && j <= 92 && i == 23 ||
							 j >= 23 && j <= 46 && i == 14 || j >= 69 && j <= 92 && i == 14) {

						Console.Write("█");

					} else if (j == 26 && i == 7 || j == 27 && i == 8  ||
							   j == 28 && i == 9 || j == 29 && i == 10 ||
							   j == 30 && i == 11|| j == 31 && i == 11 ||
							   j == 32 && i == 10|| j == 33 && i == 9  ||
							   j == 34 && i == 8 || j == 35 && i == 8  ||
							   j == 36 && i == 9 || j == 37 && i == 10 ||
							   j == 38 && i == 11|| j == 39 && i == 11 ||
							   j == 40 && i == 10|| j == 41 && i == 9  ||
							   j == 42 && i == 8 || j == 43 && i == 7) {

						Console.Write("█");

					} else if (j >= 28 && j <= 41 && i == 21 || j >= 28 && j <= 41 && i == 16 || 
							   j >= 28 && j <= 41 && i == 19 || j >= 28 && j == 41 && i >= 19 && i <= 21 ||
							   j >= 28 && j == 28 && i >= 16 && i <= 19) {

						Console.Write("█");

					} else if(i >= 16 && i <= 21 && j == 81 || i >= 7 && i <= 12 && j == 81 ||
							  i == 21 && j == 82 || i == 21 && j == 80 || i == 20 && j == 79||
							  i == 19 && j == 78 || i == 20 && j == 83 || i == 19 && j == 84||
							  i == 7 && j == 82 || i == 7 && j == 80 || i == 8 && j == 79||
							  i == 9 && j == 78 || i == 8 && j == 83 || i == 9 && j == 84) {

						Console.Write("█");

					}
					else {

						Console.Write(" ");

					}

				}

				Console.WriteLine();

			}

		}
		/*Metodo para dibujar el ganador que seria el player 1, consiste en una matriz que
		  dependiendo donde quieras situar ciertas elementos, haremos uso de unas coordenadas
		  para dibujar en unos lugares concretos*/
		public static void drawWinner1()
		{

			for (int i = 0; i < 29; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (i == 0 || i == 28 || j == 0 || j == 118)
					{

						Console.Write("▒");

					}
					else if (i == 27 || i == 1 || j == 1 || j == 117)
					{

						Console.Write("█");

					}
					else if (i == 26 || i == 2 || j == 2 || j == 116)
					{

						Console.Write("░");

					}
					else if (i <= 10 && i >= 5 && j == 8 || i <= 8 && i >= 5 && j == 16 ||
							 i <= 10 && i >= 5 && j == 24 || i <= 10 && i >= 5 && j == 40 ||
							 i <= 10 && i >= 5 && j == 48 || i <= 10 && i >= 7 && j == 59 ||
							 i <= 10 && i >= 5 && j == 70 || i <= 10 && i >= 5 && j == 86 ||
							 i <= 10 && i >= 5 && j == 94)
					{

						Console.Write("█");

					}
					else if (i == 8 && j <= 16 && j >= 8 || i == 5 && j <= 16 && j >= 8 ||
							 i == 10 && j >= 24 && j <= 32 || i == 5 && j <= 48 && j >= 40 ||
							 i == 8 && j <= 48 && j >= 40 || i == 5 && j == 56 || i == 6 && j == 57 ||
							 i == 7 && j == 58 || i == 7 && j == 60 || i == 6 && j == 61 || i == 5 && j == 62)
					{

						Console.Write("█");

					}
					else if (i == 7 && j <= 78 && j >= 70 || i == 10 && j <= 78 && j >= 70 ||
							 i == 5 && j <= 78 && j >= 70 || i == 7 && j <= 94 && j >= 86 ||
							 i == 5 && j <= 94 && j >= 86)
					{

						Console.Write("█");


					}
					else if (j == 105 && i >= 5 && i <= 10 || i == 5 && j <= 105 && j >= 102)
					{

						Console.Write("█");

					}
					else if (j == 35 && i == 18 || j == 36 && i == 19 || j == 37 && i == 20 ||
							  j == 38 && i == 21 || j == 34 && i == 17 || j == 33 && i == 16 ||
							  j == 32 && i == 15 || j == 39 && i == 21 || j == 40 && i == 20 ||
							  j == 41 && i == 19 || j == 42 && i == 18 || j == 43 && i == 17 ||
							  j == 44 && i == 16 || j == 45 && i == 15 || j == 46 && i == 15 ||
							  j == 47 && i == 16 || j == 48 && i == 17 || j == 49 && i == 18 ||
							  j == 50 && i == 19 || j == 51 && i == 20 || j == 52 && i == 21 ||
							  j == 53 && i == 21 || j == 54 && i == 20 || j == 55 && i == 19 ||
							  j == 56 && i == 18 || j == 57 && i == 17 || j == 58 && i == 16 ||
							  j == 59 && i == 15 || j == 67 && i <= 21 && i >= 15 ||
							  j == 77 && i <= 21 && i >= 15 || j == 89 && i <= 21 && i >= 15 ||
							  j == 78 && i == 15 || j == 79 && i == 16 || j == 80 && i == 16 ||
							  j == 81 && i == 17 || j == 82 && i == 17 || j == 83 && i == 18 ||
							  j == 84 && i == 19 || j == 85 && i == 19 || j == 86 && i == 20 ||
							  j == 87 && i == 21 || j == 88 && i == 21)
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

		/*Metodo para dibujar el ganador que seria el player 2, consiste en una matriz que
		  dependiendo donde quieras situar ciertas elementos, haremos uso de unas coordenadas
		  para dibujar en unos lugares concretos*/
		public static void drawWinner2()
		{


			for (int i = 0; i < 29; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (i == 0 || i == 28 || j == 0 || j == 118)
					{

						Console.Write("▒");

					}
					else if (i == 27 || i == 1 || j == 1 || j == 117)
					{

						Console.Write("█");

					}
					else if (i == 26 || i == 2 || j == 2 || j == 116)
					{

						Console.Write("░");

					}
					else if (i <= 10 && i >= 5 && j == 8 || i <= 8 && i >= 5 && j == 16 ||
							 i <= 10 && i >= 5 && j == 24 || i <= 10 && i >= 5 && j == 40 ||
							 i <= 10 && i >= 5 && j == 48 || i <= 10 && i >= 7 && j == 59 ||
							 i <= 10 && i >= 5 && j == 70 || i <= 10 && i >= 5 && j == 86 ||
							 i <= 10 && i >= 5 && j == 94)
					{

						Console.Write("█");

					}
					else if (i == 8 && j <= 16 && j >= 8 || i == 5 && j <= 16 && j >= 8 ||
							 i == 10 && j >= 24 && j <= 32 || i == 5 && j <= 48 && j >= 40 ||
							 i == 8 && j <= 48 && j >= 40 || i == 5 && j == 56 || i == 6 && j == 57 ||
							 i == 7 && j == 58 || i == 7 && j == 60 || i == 6 && j == 61 || i == 5 && j == 62)
					{

						Console.Write("█");

					}
					else if (i == 7 && j <= 78 && j >= 70 || i == 10 && j <= 78 && j >= 70 ||
							 i == 5 && j <= 78 && j >= 70 || i == 7 && j <= 94 && j >= 86 ||
							 i == 5 && j <= 94 && j >= 86)
					{

						Console.Write("█");


					}
					else if (j == 101 && i >= 8 && i <= 10 || i == 5 && j <= 108 && j >= 101 ||
									 j == 108 && i >= 5 && i <= 7 || i == 8 && j <= 108 && j >= 101 ||
									 i == 10 && j <= 108 && j >= 101)
					{

						Console.Write("█");

					}
					else if (j == 35 && i == 18 || j == 36 && i == 19 || j == 37 && i == 20 ||
							  j == 38 && i == 21 || j == 34 && i == 17 || j == 33 && i == 16 ||
							  j == 32 && i == 15 || j == 39 && i == 21 || j == 40 && i == 20 ||
							  j == 41 && i == 19 || j == 42 && i == 18 || j == 43 && i == 17 ||
							  j == 44 && i == 16 || j == 45 && i == 15 || j == 46 && i == 15 ||
							  j == 47 && i == 16 || j == 48 && i == 17 || j == 49 && i == 18 ||
							  j == 50 && i == 19 || j == 51 && i == 20 || j == 52 && i == 21 ||
							  j == 53 && i == 21 || j == 54 && i == 20 || j == 55 && i == 19 ||
							  j == 56 && i == 18 || j == 57 && i == 17 || j == 58 && i == 16 ||
							  j == 59 && i == 15 || j == 67 && i <= 21 && i >= 15 ||
							  j == 77 && i <= 21 && i >= 15 || j == 89 && i <= 21 && i >= 15 ||
							  j == 78 && i == 15 || j == 79 && i == 16 || j == 80 && i == 16 ||
							  j == 81 && i == 17 || j == 82 && i == 17 || j == 83 && i == 18 ||
							  j == 84 && i == 19 || j == 85 && i == 19 || j == 86 && i == 20 ||
							  j == 87 && i == 21 || j == 88 && i == 21)
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

		/*Metodo que dibuja el escenario de forma constante, las barras laterales, la pelota, los muros
		  y el contador, que dependiendo de donde se encuentren estos elementos, pues variaria el dibujo
		  el metodo cuenta con variables que se pueden cambiar en el menu de opciones para aumentar el
		  tamaño del escenario, o hacer que el contador llegue hasta 9 puntos, etcétera. */
		public static void drawStage() {

			for (int i = 0; i < 29; i++)
			{

				for (int j = 0; j < 119; j++)
				{

					if (i == 0 && j >= 29 && j <= 89 || i == 10 && j >= 29 && j <= 89 ||
						i == 10 && j >= StageController.limitLeft && j <= StageController.limitRight ||
						j == 29 && i < 10 && i > 0 ||
						j == 89 && i < 10 && i > 0 ||
						j == 59 && i < 10 && i > 0 ||
						i == 28 && j >= StageController.limitLeft && j <= StageController.limitRight ||
						i > 10 && i < 29 && j == StageController.limitLeft ||
						i > 10 && i < 29 && j == StageController.limitRight) {

						Console.Write("▒");

					}

					else if (i > 10 && i < 29 && j == (StageController.limitLeft + 2) ||
							 i > 10 && i < 29 && j == (StageController.limitRight - 2)) {

						Console.Write("│");

					}

					else if (i > 10 && i < 29 && j == 59) {

						if (i == GameController.stage.BallStage.PositionY && j == GameController.stage.BallStage.PositionX) {

							Console.Write("o");

						}
						else {

							Console.Write("░");

						}

					} else if (GameController.stage.CounterR == 0 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 0 && i == 8 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 0 && j == 78 && i <= 8 && i >= 2 ||
							GameController.stage.CounterR == 0 && j == 70 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 1 && i == 2 && j <= 74 && j >= 71 ||
							GameController.stage.CounterR == 1 && j == 74 && i <= 8 && i >= 2) {

						Console.Write("█");

					}
					else if (GameController.stage.CounterR == 2 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 2 && i == 5 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 2 && i == 8 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 2 && j == 78 && i <= 4 && i >= 2 ||
							GameController.stage.CounterR == 2 && j == 70 && i <= 8 && i >= 6) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 3 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 3 && i == 5 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 3 && i == 8 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 3 && j == 78 && i <= 8 && i >= 2) {

						Console.Write("█");

					} 	else if (GameController.stage.CounterR == 4 && i == 5 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 4 && j == 70 && i <= 4 && i >= 2 ||
							GameController.stage.CounterR == 4 && j == 78 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 5 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 5 && i == 5 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 5 && i == 8 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 5 && j == 70 && i <= 4 && i >= 2 ||
							GameController.stage.CounterR == 5 && j == 78 && i <= 8 && i >= 6) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 6 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 6 && i == 5 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 6 && i == 8 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 6 && j == 70 && i <= 8 && i >= 2 ||
							GameController.stage.CounterR == 6 && j == 78 && i <= 8 && i >= 6){

						Console.Write("█");

					} else if (GameController.stage.CounterR == 7 && i == 2 && j <= 78 && j >= 70 ||
							GameController.stage.CounterR == 7 && j == 70 && i <= 4 && i >= 2 ||
							GameController.stage.CounterR == 7 && j == 78 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 8 && i == 2 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 8 && i == 5 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 8 && i == 8 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 8 && j == 70 && i <= 8 && i >= 2 ||
						   GameController.stage.CounterR == 8 && j == 78 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterR == 9 && i == 2 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 9 && i == 5 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 9 && i == 8 && j <= 78 && j >= 70 ||
						   GameController.stage.CounterR == 9 && j == 70 && i <= 4 && i >= 2 ||
						   GameController.stage.CounterR == 9 && j == 78 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 0 && i == 2 && j <= 48 && j >= 40 ||
						   GameController.stage.CounterL == 0 && i == 8 && j <= 48 && j >= 40 ||
							GameController.stage.CounterL == 0 && j == 48 && i <= 8 && i >= 2 ||
						   GameController.stage.CounterL == 0 && j == 40 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 1 && i == 2 && j <= 46 && j >= 43 ||
							GameController.stage.CounterL == 1 && j == 46 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 2 && i == 2 && j <= 48 && j >= 40 ||
							  GameController.stage.CounterL == 2 && i == 5 && j <= 48 && j >= 40 ||
							  GameController.stage.CounterL == 2 && i == 8 && j <= 48 && j >= 40 ||
							  GameController.stage.CounterL == 2 && j == 48 && i <= 4 && i >= 2 ||
							 GameController.stage.CounterL == 2 && j == 40 && i <= 8 && i >= 6) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 3 && i == 2 && j <= 48 && j >= 40 ||
							  GameController.stage.CounterL == 3 && i == 5 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 3 && i == 8 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 3 && j == 48 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 4 && i == 5 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 4 && j == 40 && i <= 4 && i >= 2 ||
							 GameController.stage.CounterL == 4 && j == 48 && i <= 8 && i >= 2){

						Console.Write("█");

					} else if (GameController.stage.CounterL == 5 && i == 2 && j <= 48 && j >= 40 ||
						   GameController.stage.CounterL == 5 && i == 5 && j <= 48 && j >= 40 ||
						   GameController.stage.CounterL == 5 && i == 8 && j <= 48 && j >= 40 ||
							GameController.stage.CounterL == 5 && j == 40 && i <= 4 && i >= 2 ||
						   GameController.stage.CounterL == 5 && j == 48 && i <= 8 && i >= 6) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 6 && i == 2 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 6 && i == 5 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 6 && i == 8 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 6 && j == 40 && i <= 8 && i >= 2 ||
							 GameController.stage.CounterL == 6 && j == 48 && i <= 8 && i >= 6) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 7 && i == 2 && j <= 48 && j >= 40 ||
							  GameController.stage.CounterL == 7 && j == 40 && i <= 4 && i >= 2 ||
							 GameController.stage.CounterL == 7 && j == 48 && i <= 8 && i >= 2) 	{

						Console.Write("█");

					} else if (GameController.stage.CounterL == 8 && i == 2 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 8 && i == 5 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 8 && i == 8 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 8 && j == 40 && i <= 8 && i >= 2 ||
							 GameController.stage.CounterL == 8 && j == 48 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (GameController.stage.CounterL == 9 && i == 2 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 9 && i == 5 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 9 && i == 8 && j <= 48 && j >= 40 ||
							 GameController.stage.CounterL == 9 && j == 40 && i <= 4 && i >= 2 ||
							 GameController.stage.CounterL == 9 && j == 48 && i <= 8 && i >= 2) {

						Console.Write("█");

					} else if (i == GameController.stage.BarLeft.PositionY && j == GameController.stage.BarLeft.PositionX ||
						   i == (GameController.stage.BarLeft.PositionY - 1) && j == GameController.stage.BarLeft.PositionX ||
						   i == (GameController.stage.BarLeft.PositionY + 1) && j == GameController.stage.BarLeft.PositionX) {

						Console.Write("█");

					} else if (i == GameController.stage.BarRight.PositionY && j == GameController.stage.BarRight.PositionX ||
						   i == (GameController.stage.BarRight.PositionY - 1) && j == GameController.stage.BarRight.PositionX ||
						   (i == GameController.stage.BarRight.PositionY + 1) && j == GameController.stage.BarRight.PositionX){

						Console.Write("█");

					} 	else if (i == GameController.stage.BallStage.PositionY && j == GameController.stage.BallStage.PositionX) {

						Console.Write("o");

					} else {

						Console.Write(" ");

					}

				}

				Console.WriteLine();

			}

		}

	}
	
}




