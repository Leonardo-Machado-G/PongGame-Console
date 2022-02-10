//Declaramos las librerias que vamos a utilizar
using System;
using System.Media;
using System.Threading;
using Pong_Game.CapaPresentacion;
using Pong_Game.CapaDatos;

//Declaramos el namespace
namespace Pong_Game.CapaNegocio
{

	/*Usaremos GameMode para cambiar el modo de juego en el que nos encontremos
	  y poder asi estructurar mejor nuestro codigo*/
	public enum GameMode
	{
		MenuMode,
		OptionMode,
		RunningMode,
		WinnerMode,
		OptionSize,
		OptionSpeed,
		OptionHandicap,
		OptionCount

	}

	//Declaramos la clase
	public class MainMenuController
	{

		/*Esta variable nos servira para cambiar el modo de juego y en funcion del modo en el que estemos
		  dentro del bucle accederemos a unas instrucciones concretas*/
		public static GameMode mode;

		/*Esta variable la usaremos para obtener las teclas pulsadas en funcion del modo de juego en el que estemos
		  pues haremos unas cosas u otras*/
		private static ConsoleKeyInfo key;

		/*Este es el metodo principal donde se estara ejecutando el bucle hasta pulsar 3 para salir del juego en el
		 menu principal*/
		static void Main(string[] args)
		{

			/*Al comenzar el main lo primero es intentar leer si existe una configuracion creada previamente
			  porque al abrir el juego automaticamente se genera un documento donde constan las variables
			  de la configuracion*/
			SaveSettings.readTextContent();

			/*Comenzamos en modo Menu, que es el menu principal, de modo que cambiamos el valor del enum declarado
			  para tener el codigo mas estructurado*/
			mode = GameMode.MenuMode;

			/*Este metodo sirve para hacer que suene la cancion del juego, una vez se acabe la partida y volvemos al
			  menu principal, esta se volvera a ejecutar pero en otro lugar*/
			playSong();

			/*Este bucle es el que permite que el juego siga funcionando, solo dejara de funcionar cuando en el menu
			  principal le demos a la tecla 3 devolviendo un break*/
			while (true)
			{

				/*Si estamos en el modo menu, llamamos al metodo mainmenu() que se encargara de ejecutar unas intrucciones y 
				 devolvernos un false o un true, al hacerlo romperemos o no el bucle*/
				if (mode == GameMode.MenuMode)
				{

					//Al regresar cada vez al modo menu guardamos la informacion de nuestra configuracion
					SaveSettings.generateTextContent();

					//Si al llamar al metodo devuelve true por pulsar la tecla 3 se cierra el juego
					if (mainMenu()) {
						break;
					}

				}

				/*Este sera el menu de opciones donde vamos a cambiar algunos valores para poder hacer el mapa mas grande
				  la velocidad de juego mas rapida, dar puntos a un jugador o cambiar el limite de puntos*/
				if (mode == GameMode.OptionMode)
				{
					/*Llamamos al menu de opciones*/
					optionMenu();

				}

				/*Este sera el valor de mode en el que comenzaremos a jugar, desplazando las barras laterales y la pelota
				  cambiando su posicion constantemente*/
				if (mode == GameMode.RunningMode)
				{
					/*Llamamos al metodo de esta clase que es el que se encarga de ejecutar las funciones relacionadas
					  con el modo de juego*/
					GameController.gameController();
				}

				/*Este if alberga las instrucciones para el submenu para cambiar la velocidad de juego, borrando la consola,
				 dibujando un nuevo menu y esperando las ordenes insertadas por teclado*/
				if (mode == GameMode.OptionSpeed)
				{
					/*Llamamos al metodo de option speed para ejecutar las intrucciones del cambio de velocidad*/
					optionSpeed();

				}

				/*Este if nos servira para que en caso de estar en modo option, ejecutar ciertas intrucciones como dibujar el menu de opciones
				  limpiar la consola, y esperar a que pulsemos una tecla para indicar como queremos proceder*/
				if (mode == GameMode.OptionCount)
				{
					/*Llamamos al metodo de option count para ejecutar las intrucciones del cambio de valores de contador iniciales*/
					optionCount();
					
				}

				//Estructura para elegir el tamaño del mapa
				if (mode == GameMode.OptionSize)
				{
					/*Llamamos al metodo de option size para ejecutar las intrucciones del cambio del tamaño del mapa*/
					optionSize();

				}

				//Estructura para elegir la puntuacion inicial
				if (mode == GameMode.OptionHandicap)
				{
					/*Llamamos al metodo de option handicap para ejecutar las intrucciones del cambio de la ventaja inicial*/
					optionHandicap();
					
				}

			}

		}

		/*Este metodo sirve para hacer sonar una cancion durante todo la partida hasta que se
		  ejecute otro sonido que impide que este siga funcionando teniendo que reiniciarse*/
		public static void playSong()
		{

			//Establecemos la ruta donde se encuentra el archivo de la cancion que queremos hacer sonar
			String path = "..\\assets\\song-theme.wav";

			//Declaramos una variable que nos permita hacer sonar la cancion que vamos a utilizar
			SoundPlayer player = new System.Media.SoundPlayer();

			//Asociamos su ruta con la variable
			player.SoundLocation = path;

			//Hacemos sonar la cancion en bucle para que cuando se acabe vuelva a sonar
			player.PlayLooping();

		}

		/*Cuando llamamos a este metodo, primero limpia la consola, dibuja el menu principal, y espera a que
		 *pulsemos una tecla para o salir del juego o cambiar el modo del juego*/
		private static bool mainMenu()
		{

			/*Limpiamos la consola para mostrar el menu y le indicamos que espere un segundo para que la transicion
			  no sea casi instantanea*/
			Console.Clear();
			Thread.Sleep(150);

			/*Llamamos a un metodo de la parte de la interfaz que se encargue de dibujar el menu principal
			 *una vez lo tenemos se muestra en pantalla que opciones tenemos para poder proceder*/
			DrawMenu.drawMenu();

			/*Insertamos en nuestra variable ya declarada anteriormente, esta instruccion para esperar la 
			 *proxima tecla pulsada*/
			key = Console.ReadKey(true);

			/*Volvemos a limpiar la consola porque vamos a cambiar el modo en el que nos encontramos
			  y dibujar otro modo*/
			Console.Clear();

			/*Si pulsamos la tecla de numero 1 del lado izquierdo del teclado, cambiamremos el modo de juego a
			 *running mode, que sera el modo con el que podremos desplazar las barras laterales y la pelota
			 *comenzara a moverse*/
			if (key.Key == ConsoleKey.D1)
			{

				//Establecemos el modo de juego
				mode = GameMode.RunningMode;

			}

			/*Si pulsamos la tecla del numero 2 del lado izquierdo del teclado, cambiaremos el modo de juego
			 *a modo de opciones*/
			if (key.Key == ConsoleKey.D2)
			{

				//Establecemos el modo de juego
				mode = GameMode.OptionMode;

			}

			/*Si pulsamos la tecla de numero 3 del lado izquierdo del teclado, no cambiaremos el modo de juego
			 *lo que haremos será cerrar el juego devolviendo un true, y al regresar de este metodo
			 *accederemos a un if, enviando un break y deteniendo el bucle que permite al juego seguir funcionando*/
			if (key.Key == ConsoleKey.D3)
			{

				/*Emitidmos un sonido por consola para indicar que se ha detenido y hemos entrado a este if*/
				Console.Beep();

				/*Devolvemos un true al if para poder acceder a break, y detener el juego*/
				return true;

			}

			/*Establecemos el valor de la variable usada para obtener datos de las teclas pulsadas en default
			 *que consiste en que no tenga valor para un futuro uso*/
			key = default(ConsoleKeyInfo);

			//Devolvemos un falso para no poder acceder al if donde se encuentra el break para cerrar el juego
			return false;

		}

		/*Este metodo sirve para ejecutar las instrucciones del menu de opciones, como obtener las indicaciones por
		  teclado para configurar nuestro juego*/
		private static void optionMenu() {

			/*Limpiamos la consola para mostrar el menu de opciones y le indicamos que espere un segundo para que la transicion
			  no sea casi instantanea*/
			Console.Clear();
			Thread.Sleep(150);

			/*Dibujamos el menu de opciones para poder acceder a ciertos parametros y complicar o facilitar el juego
			  en funcion de las teclas que pulsemos*/
			DrawMenu.drawOptionMenu();

			//Insertamos en esta variable un valor que hemos obtenido al pulsar una tecla para elegir opcion
			key = Console.ReadKey(true);

			/*Esta opcion cambiara el modo de juego indicando que ahora nos encontramos en un submenu
			  dentro de opciones que nos permitira cambiar el tamaño del mapa*/
			if (key.Key == ConsoleKey.D1)
			{
				//Cambiamos el valor de mode
				mode = GameMode.OptionSize;
			}

			/*Esta opcion cambiara el modo de juego indicando que ahora nos situamos en un submenu
			  dentro de opciones permitiendonos cambiar la velocidad del juego*/
			if (key.Key == ConsoleKey.D2)
			{
				//Cambiamos el valor de mode
				mode = GameMode.OptionSpeed;
			}

			/*Esta opcion cambiara el modo de juego indicando que ahora nos situamos en un submenu
			  dentro de opciones permitiendonos cambiar la puntuacion del juego*/
			if (key.Key == ConsoleKey.D3)
			{
				//Cambiamos el valor de mode
				mode = GameMode.OptionCount;
			}

			/*Esta opcion cambiara el modo de juego indicando que ahora nos situamos en un submenu
			 dentro de opciones permitiendonos cambiar los puntos iniciales de cada jugador*/
			if (key.Key == ConsoleKey.D4)
			{
				//Cambiamos el valor de mode
				mode = GameMode.OptionHandicap;
			}

			/*Esta opcion cambiara el modo de juego indicando que ahora nos vamos a encontrar en el
			  menu principal otra vez*/
			if (key.Key == ConsoleKey.D5)
			{
				mode = GameMode.MenuMode;
			}

			//Cambiamos otra vez el valor de esta variable al predeterminado
			key = default(ConsoleKeyInfo);

		}

		/*Este metodo sirve para ejecutar las instrucciones del submenu de velocidad, como obtener las indicaciones por
		  teclado para configurar nuestra velocidad juego*/
		private static void optionSpeed(){

			/*Limpiamos la consola para mostrar una nueva interfaz distinta a la anterior y con opciones diferentes
					  que daran como resultado el cambio o no de la velocidad de juego*/
			Console.Clear();

			/*Establecemos unos milisegundos para que la transicion no se haga de forma instantanea y se note la 
			 diferencia del cambio de un menu al otro*/
			Thread.Sleep(150);

			/*Llamamos a un metodo encargada de dibujar este menu mediante un complejo sistema de coordenadas en la pantalla
			  mostrando ciertas opciones antes no vistas en el menu opciones*/
			DrawMenu.drawOptionMenu();

			//Quedamos a la espera de que pulsemos una tecla y podamos proceder cambiar el modo de juego
			key = Console.ReadKey(true);

			//Este if se encarga de cambiar el valor de la variable de velocidad haciendo al juego lo maximo lento de las 3 opciones
			if (key.Key == ConsoleKey.D1)
			{
				//Le asignamos una velocidad en milisegundos, a cuanto mayor sea, mas tiempo tardara en volver a ejecutar el bucle
				GameController.gameSpeed = 500;

			}

			/*Este if se ejecutara cuando poulsemos la tecla 2 del teclado izquierdo, cambiando la velocidad de juego a media
			  que sera su valor estandar*/
			if (key.Key == ConsoleKey.D2)
			{
				//Le asignamos una velocidad en milisegundos, a cuanto mayor sea, mas tiempo tardara en volver a ejecutar el bucle
				GameController.gameSpeed = 250;

			}

			/*Cambiamos la velocidad de juego a la mas rapida posible, haciendo que la pelota se desplace mas rapido y la consola
			  se limpie y vuelva a escribir mas rapido y las barras laterales se muevan mas rapidas*/
			if (key.Key == ConsoleKey.D3)
			{
				//Le asignamos una velocidad en milisegundos, a cuanto mayor sea, mas tiempo tardara en volver a ejecutar el bucle
				GameController.gameSpeed = 50;

			}

			/*Si pulamos cualquiera de las teclas antes establecidas, automaticamente volvemos atras cambiando a optionmode para
			  dar a entender que se han guardado los datos aunque no se muestre por pantalla*/
			if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
				key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4)
			{
				//Cambiamos el modo de juego a optionmode
				mode = GameMode.OptionMode;

			}

			//Establecemos en predeterminado el valor de key para posterior uso
			key = default(ConsoleKeyInfo);

		}

		/*Este metodo sirve para ejecutar las instrucciones del submenu del contador, como obtener las indicaciones por
		  teclado para configurar nuestro contador de juego*/
		private static void optionCount() {

			/*Limpiamos la consola para mostrar una nuevo menu de opciones y le indicamos que espere un segundo para que la transicion
					  no sea casi instantanea*/
			Console.Clear();
			Thread.Sleep(150);

			/*Dibujamos el menu pero al encontrarnos en uno distinto automaticamente este lo sabra porque posee unas opciones para
			  identificar el modo en el que nos encontramos*/
			DrawMenu.drawOptionMenu();

			/*Esperamos a escribir un valor por teclado para ejecutar ciertas opciones*/
			key = Console.ReadKey(true);

			/*Si pulso la tecla numero 1 del lado izquierdo del teclado establecemos el valor del contador maximo como 9
			  indicando que queremos que al llegar a ese valor el jugador ganara*/
			if (key.Key == ConsoleKey.D1)
			{
				//Establecemos el valor maximo del contador como 9
				StageController.maxCounter = 9;

			}

			/*Si pulsamos la tecla 2 del lado izquierdo del teclado, establecemos el valor maximo del contador en 6*/
			if (key.Key == ConsoleKey.D2)
			{
				//Cambiamos el valor maximo a 6
				StageController.maxCounter = 6;

			}

			/*Al pulsar la tecla 3 del lado izquierdo del teclado establecemos el contador maximo en 3, que sera
			  el valor estandar con el que sin cambiar de opcion comenzaremos*/
			if (key.Key == ConsoleKey.D3)
			{
				//Cambiamos el valor maximo a 3
				StageController.maxCounter = 3;

			}

			/*Al pulsar cualquiera de las anteriores teclas del 1 al 4 cambiaremos otra vez al modo de opciones
			  indicando que hemos guardado el valor seleccionado sin necesidad de notificarlo por pantalla*/
			if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
				key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4)
			{
				//Establecemos el gamemode a option mode
				mode = GameMode.OptionMode;

			}

			//Establecemos el valor de key al predeterminado para futuros cambios
			key = default(ConsoleKeyInfo);

		}

		/*Este metodo sirve para ejecutar las instrucciones del submenu de tamaño, como obtener las indicaciones por
		  teclado para configurar nuestro tamaño del juego*/
		private static void optionSize() {

			/*Limpiamos la consola para mostrar una nuevo menu de opciones y le indicamos que espere un segundo para que la transicion
					  no sea casi instantanea*/
			Console.Clear();
			Thread.Sleep(150);

			/*Dibujamos el menu pero al encontrarnos en uno distinto automaticamente este lo sabra porque posee unas opciones para
			  identificar el modo en el que nos encontramos*/
			DrawMenu.drawOptionMenu();

			/*Esperamos a escribir un valor por teclado para ejecutar ciertas opciones*/
			key = Console.ReadKey(true);

			/*Al pulsar la tecla 1 del lado izquierdo del teclado cambiamos los limites lateriales del mapa desplazandolos para que
			  en otras clases se detecte las colisiones y dibujamos el mapa el lugares distintos*/
			if (key.Key == ConsoleKey.D1)
			{

				//Cambiamos el valor static de stage indicando que queremos que los limites sean esos
				StageController.limitRight = 79;
				StageController.limitLeft = 39;

			}

			/*Al pulsar la tecla 2 del lado izquierdo del teclado cambiaremos los limites laterales cambiando el tamaño del mapa
			  este sera el predeterminado*/
			if (key.Key == ConsoleKey.D2)
			{

				//Cambiamos el valor static de stage indicando que queremos que los limites sean esos
				StageController.limitRight = 89;
				StageController.limitLeft = 29;

			}

			/*Al pulsar la tecla 3 del lado izquierdo del teclado cambiaremos los limites laterales cambiando el tamaño del mapa
			  este sera el mayo de datos*/
			if (key.Key == ConsoleKey.D3)
			{
				//Cambiamos el valor static de stage indicando que queremos que los limites sean esos
				StageController.limitRight = 99;
				StageController.limitLeft = 19;

			}

			/*Al pulsar cualquiera de las anteriores teclas del 1 al 4 cambiaremos otra vez al modo de opciones
			  indicando que hemos guardado el valor seleccionado sin necesidad de notificarlo por pantalla*/
			if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
				key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4)
			{
				//Establecemos el gamemode a option mode
				mode = GameMode.OptionMode;

			}

			//Reseteamos el valor de la tecla
			key = default(ConsoleKeyInfo);

		}

		/*Este metodo sirve para ejecutar las instrucciones del submenu de handicap, como obtener las indicaciones por
		  teclado para configurar nuestra ventaja inicial de juego*/
		private static void optionHandicap(){

			/*Limpiamos la consola para mostrar una nuevo menu de opciones y le indicamos que espere un segundo para que la transicion
					  no sea casi instantanea*/
			Console.Clear();
			Thread.Sleep(150);

			/*Dibujamos el menu pero al encontrarnos en uno distinto automaticamente este lo sabra porque posee unas opciones para
			  identificar el modo en el que nos encontramos*/
			DrawMenu.drawOptionMenu();

			/*Esperamos a escribir un valor por teclado para ejecutar ciertas opciones*/
			key = Console.ReadKey(true);

			/*Al pulsar la tecla 1 del lado izquierdo del teclado establecemos el contador Left en 2, para darle una ventaja al player 1
			  en caso de que queramos darsela*/
			if (key.Key == ConsoleKey.D1)
			{
				//Cambiamos el valor inicial de contadores por los que se va a comenzar
				StageController.counterL = 2;

			}

			/*Al pulsar la tecla 2 del lado izquierdo del teclado establecemos el contador Right en 2, para darle una ventaja al player 2
			  en caso de que queramos darsela*/
			if (key.Key == ConsoleKey.D2)
			{
				//Cambiamos el valor inicial de contadores por los que se va a comenzar
				StageController.counterR = 2;

			}

			/*Al pulsar la tecla 3 del lado izquierdo del teclado establecemos ambos contadores iniciales en 0 para no dar ventaja
			  este sera el valor por defecto*/
			if (key.Key == ConsoleKey.D3)
			{
				//Cambiamos los valores de ambos contadores
				StageController.counterL = 0;
				StageController.counterR = 0;

			}

			/*Al pulsar cualquiera de las anteriores teclas del 1 al 4 cambiaremos otra vez al modo de opciones
			  indicando que hemos guardado el valor seleccionado sin necesidad de notificarlo por pantalla*/
			if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 ||
				key.Key == ConsoleKey.D3 || key.Key == ConsoleKey.D4)
			{

				mode = GameMode.OptionMode;

			}

			//Establecemos el valor de key al predeterminado para futuros cambios
			key = default(ConsoleKeyInfo);

		}

	}

}
