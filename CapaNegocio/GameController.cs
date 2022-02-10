//Declaramos las librerias que vamos a utilizar
using System;
using System.Media;
using System.Threading;
using Pong_Game.CapaPresentacion;

//Declaramos el namespace
namespace Pong_Game.CapaNegocio
{

	//Declaramos la clase
	public class GameController
	{

		/*Este sera el escenario donde se van a ejecutar ciertas intrucciones relacionadas
		  con la colision y contendra las posiciones de las barras, la pelota, etc*/
		public static StageController stage;

		/*Esta variable la usaremos para obtener las teclas pulsadas en funcion del modo de juego en el que estemos
		  pues haremos unas cosas u otras*/
		private static ConsoleKeyInfo key;

		/*Estas variables serviran para solo permitir el desplazamiento de las barras laterales cada vez que se
		  actualice la pantalla, impidiendo desplazamientos grandes que puedan teletransportar las barras*/
		private static bool runningL = false;
		private static bool runningR = false;

		/*Variables para indicar que jugador ha ganado la partida, junto al gamemode para asegurarnos de que
		  estamos en el modo correcto*/
		private static bool playerWin1 = false;
		private static bool playerWin2 = false;

		/*Variable para indicar la velocidad de juego, a cuanto mas valor haya, mas lento seran las pausas para
		  seguir ejecutando el bucle, este valor cambia en el menu opciones*/
		public static int gameSpeed = 250;

		/*Propiedad de player 1 para indicar si ha ganado o no o para cambiar el valor de su variable*/
		public static bool PlayerWin1
		{

			get => playerWin1;
			set => playerWin1 = value;

		}

		/*Propiedad de player 2 para indicar si ha ganado o no o para cambiar el valor de su variable*/
		public static bool PlayerWin2
		{

			get => playerWin2;
			set => playerWin2 = value;

		}

		/*Este metodo nos servira para supervisar el juego conforme funciona, indicando cuando dibujarlo
		  comprobar colisiones de la pelota con las pared y las barras, las teclas pulsadas, asignar los
		 objetos al escenario y generarlo*/
		public static void gameController()
		{

			//Limpiamos la consola del anterior menu
			Console.Clear();

			//Mostramos la interfaz de las instruccion de como jugar
			DrawStage.drawTutorial();

			//Esperamos 4 segundos para que de tiempo a ver las instrucciones
			Thread.Sleep(4000);

			//Limpiamos la consola del tutorial
			Console.Clear();

			/*Declaramos un nuevo hilo que vamos a necesitar para el control de las teclas pulsadas mientras el
			  escenario sigue en ejecucion, el incoveniente de prescindir de este hilo, es que el escenario
			  no se podria continuar dibujando, solo lo haria cuando pulsasemos una tecla, debido a que
			  permaneceria a la espera de que pulsemos una tecla. Le asignamos el metodo que sera el hilo*/
			Thread th1 = new Thread(new ThreadStart(keyDetector));

			//Indicamos que comience el hilo
			th1.Start();

			/*Declaramos la pelota del escenario y su posicion inicial que esta sera el centro del mapa*/
			Ball ball = new Ball(60, 20);

			/*Esta barra, es la izquierda, le asignamos una posicion inicial que depende del limite del mapa
			  asignado en las opciones*/
			Bar barLeft = new Bar((StageController.limitLeft + 10), 20);

			/*Esta barra, es la derecha, le asignamos una posicion inicial que depende del limite del mapa
			  asignado en las opciones*/
			Bar barRight = new Bar((StageController.limitRight - 10), 20);

			/*Declaramos un stage, que sera el escenario, le asignamos la pelota, las barras, y los contadores
			  iniciales de cada uno que se podran cambiar en opciones*/
			stage = new StageController(ball, barLeft, barRight, StageController.counterL, StageController.counterR);

			/*Comienza un nuevo bucle, que es necesario para separar el anterior en el que aun estamos para cerrar
			  tan solo este en caso de pulsar la tecla ESC, una vez volvamos al anterior, podremos volver a ejecutar el
			  juego y las posiciones se resetearan*/
			while (MainMenuController.mode == GameMode.RunningMode)
			{

				/*Esto determinara la velocidad de juego, esta velocidad podra cambiar una vez accedamos a las opciones
				  y cada vez que volvamos a esta instruccion, deberemos esperar unas milesimas de segundo*/
				Thread.Sleep(gameSpeed);

				/*Llamaremos a este metodo del stage, que cambia la posicion de la pelota cada vez que volvemos a cargar
				  el bucle while en funcion de su direccion*/
				stage.setPosition();

				/*Este metodo detecta las colisiones de la pelota en caso de encontrarnos en los limites, 
				  redirigiremos la pelota cambiandole su direccion y si se trata de los bordes reseteamos 
				  la posicion y cambiamos el valor del contador, si el contador ya esta al maximo establecido
				  indicamos al ganador*/
				stage.detectColision();

				/*Borramos la consola y dibujamos el escenario con las nuevas posiciones de la pelota dependiendo
				  de si ha colisionado con los bordes superiores, lateriales o con las barras que usamos para
				  redirigir la pelota*/
				Console.Clear();
				DrawStage.drawStage();

				/*Reseteamos las dos variables que nos permiten mover las barras laterales cada vez que las desplazamos
				  en cada ciclo del while, solo se puede desplazar una vez por cada actualizacion de consola*/
				runningL = true;
				runningR = true;

			}

			/*Si hemos llegado al limite de los puntos, se habra cambiado el modo de juego a traves de stage
			  y nos habra indicado quien es el ganador, si el player 1 o 2*/
			if (PlayerWin1 && !PlayerWin2 && MainMenuController.mode == GameMode.WinnerMode)
			{

				/*Limpiamos la consola para que todo el escenario que estuviese dibujado anteriormente deje de mostrarse
				  y podamos indicar quien es el ganador*/
				Console.Clear();

				/*Dibujamos al ganador en funcion de lo que nos hayan indicado las variables, llamando a este metodo*/
				DrawStage.drawWinner1();

				/*Reseteamos las variables para dejar de asignar al ganador y que todo comience otra vez*/
				PlayerWin2 = false;
				PlayerWin1 = false;

				//Hacemos sonar la cancion del ganador
				playSoundWinner();

				//Detenemos el programa 7 segundos para mostrar al ganador y el sonido que le acompaña que dura 7 s
				Thread.Sleep(7000);

				//Cambiamos el modo de juego para que volvamos al menu
				MainMenuController.mode = GameMode.MenuMode;

				/*Hacemos que vuelva a sonar la cancion del juego debido a que la inicial que ejecutamos, esta fuera
				  del bucle y no podemos estar ejecutando la cancion todo el tiempo ubicando la funcion dentro de él*/
				MainMenuController.playSong();

			}

			/*Si hemos llegado al limite de los puntos, se habra cambiado el modo de juego a traves de stage
			  y nos habra indicado quien es el ganador, si el player 1 o 2*/
			if (PlayerWin2 && !PlayerWin1 && MainMenuController.mode == GameMode.WinnerMode)
			{

				/*Limpiamos la consola para que todo el escenario que estuviese dibujado anteriormente deje de mostrarse
				  y podamos indicar quien es el ganador*/
				Console.Clear();

				/*Dibujamos al ganador en funcion de lo que nos hayan indicado las variables, llamando a este metodo*/
				DrawStage.drawWinner2();

				/*Reseteamos las variables para dejar de asignar al ganador y que todo comience otra vez*/
				PlayerWin2 = false;
				PlayerWin1 = false;

				//Hacemos sonar la cancion del ganador
				playSoundWinner();

				//Detenemos el programa 7 segundos para mostrar al ganador y el sonido que le acompaña que dura 7 s
				Thread.Sleep(7000);

				//Cambiamos el modo de juego para que volvamos al menu
				MainMenuController.mode = GameMode.MenuMode;

				/*Hacemos que vuelva a sonar la cancion del juego debido a que la inicial que ejecutamos, esta fuera
				  del bucle y no podemos estar ejecutando la cancion todo el tiempo ubicando la funcion dentro de él*/
				MainMenuController.playSong();

			}

		}

		/*Metodo que es ejecutado como un nuevo hilo para estar detectando las teclas que pulsamos en todo
		  momento desplazando las barras laterales y detectar si hemos salido del juego*/
		private static void keyDetector()
		{

			/*Bucle que se sigue ejecutando mientras el modo de juego es running mode, que es el modo que indica
			  que el juego esta funcionando*/
			while (MainMenuController.mode == GameMode.RunningMode)
			{

				/*Introducimos en la variable key un valor que hemos obtenido al pulsar una tecla, realizando distintas
				  tareas*/
				key = Console.ReadKey(true);

				/*Este if solo puede ejecutarse en caso de que pulsemos la tecla W y no estemos pulsando la tecla S
				  para impedir que se sume o reste a la vez valores, tambien se le asocia otra variable para no
				  acceder otra vez al if una vez entremos, para no variar la posicion de las barras varias veces en cada 
				  ciclo*/
				if (key.Key == ConsoleKey.W && runningL && key.Key != ConsoleKey.S)
				{

					/*Aumentamos la altura de la posicion Y de la barra izquierda, es negativa, porque la matriz
					  indica la altura de forma contraria siendo el valor 0, la maxima altura*/
					stage.BarLeft.PositionY -= 1;

					/*Impedimos seguir desplazando la barra lateral izquierda, cambiando el valor de esta variable
					  a false*/
					runningL = false;

				}

				/*Este if solo puede ejecutarse en caso de que pulsemos la tecla S y no estemos pulsando la tecla W
				  para impedir que se sume o reste a la vez valores, tambien se le asocia otra variable para no
				  acceder otra vez al if una vez entremos, para no variar la posicion de las barras varias veces en cada 
				  ciclo*/
				if (key.Key == ConsoleKey.S && runningL && key.Key != ConsoleKey.W)
				{

					/*Disminuimos la altura de la posicion Y de la barra izquierda, es positiva porque la matriz
					  indica la altura de forma contraria siendo el valor 0, la maxima altura*/
					stage.BarLeft.PositionY += 1;

					/*Impedimos seguir desplazando la barra lateral izquierda, cambiando el valor de esta variable
					  a false*/
					runningL = false;

				}

				/*Este if solo puede ejecutarse en caso de que pulsemos la tecla UpArrow y no estemos pulsando la tecla
				  DownArrow para impedir que se sume o reste a la vez valores, tambien se le asocia otra variable para no
				  acceder otra vez al if una vez entremos, para no variar la posicion de las barras varias veces en cada 
				  ciclo*/
				if (key.Key == ConsoleKey.UpArrow && runningR && key.Key != ConsoleKey.DownArrow)
				{

					/*Disminuimos la altura de la posicion Y de la barra derecha, es negativa porque la matriz
					  indica la altura de forma contraria siendo el valor 0, la maxima altura*/
					stage.BarRight.PositionY -= 1;

					/*Impedimos seguir desplazando la barra lateral izquierda, cambiando el valor de esta variable
					  a false*/
					runningR = false;

				}

				/*Este if solo puede ejecutarse en caso de que pulsemos la tecla DownArrow y no estemos pulsando la tecla
				  UpArrow para impedir que se sume o reste a la vez valores, tambien se le asocia otra variable para no
				  acceder otra vez al if una vez entremos, para no variar la posicion de las barras varias veces en cada 
				  ciclo*/
				if (key.Key == ConsoleKey.DownArrow && runningR && key.Key != ConsoleKey.UpArrow)
				{

					/*Disminuimos la altura de la posicion Y de la barra derecha, es positiva porque la matriz
					  indica la altura de forma contraria siendo el valor 0, la maxima altura*/
					stage.BarRight.PositionY += 1;

					/*Impedimos seguir desplazando la barra lateral izquierda, cambiando el valor de esta variable
					  a false*/
					runningR = false;

				}

				//Al pulsar la tecla ESC indicamos que queremos salir del juego
				if (key.Key == ConsoleKey.Escape)
				{

					//Reseteamos el valor de key para un posterior uso distinto
					key = default(ConsoleKeyInfo);

					//Cambiamos al modo menu para volver al menu principal
					MainMenuController.mode = GameMode.MenuMode;

				}

			}

		}

		//Metodo que ejecuta la cancion del ganador una vez sea llamado
		private static void playSoundWinner()
		{

			//Declaramos la ruta donde se encuentra el archivo wav para acceder a ella y asociarlo al soundplayer
			String path = "..\\assets\\winner.wav";

			//Creamos un sounplayer para ejecutar el sonido del ganador
			SoundPlayer player = new SoundPlayer();

			//Asociamos la ruta donde se encuentra el archivo con el soundplayer
			player.SoundLocation = path;

			//Hacemos sobar el sonido del ganador
			player.Play();

		}

	}

}
