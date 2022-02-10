//Declaramos las librerias que vamos a utilizar
using System;
using Pong_Game.CapaPresentacion;

//Declaramos el namespace
namespace Pong_Game.CapaNegocio
{

	//Declaramos la clase
	public class StageController
	{

		/*Esta sera la pelota que tendra unas direcciones de movimientos y una posicion en nuestra matriz
		  o escenario*/
		private Ball ball;

		/*Esta sera la barra lateral izquierda que iremos desplazando e ira cambiando su posicion a medida
		  que pulsemos las teclas*/
		private Bar barLeft;

		/*Esta sera la barra lateral derecha que iremos desplazando e ira cambiando su posicion en funcion
		  de las teclas pulsemos*/
		private Bar barRight;

		/*Estos seran los limites laterales del mapa que basicamente son unos valores que le indicaremos a la
		  matriz para dibujar los limites o establecer las colisiones con ellos, estos podran ser cambiamos
		  en funcion del tamaño del mapa que indiquemos en opciones*/
		public static int limitRight = 89;
		public static int limitLeft = 29;

		/*Estas variables representan los valores del contador en todo momento*/
		private int counterRight;
		private int counterLeft;

		/*Este sera el valor maximo del contador, que si cualquier contador lateral llega a este limite
		  supondra que ha ganado la partida*/
		public static int maxCounter = 3;

		/*Estos son los valores iniciales que tomaran los contadores, si deseamos cambiarlo en opciones y
		  dar una ventaja inicial a un jugador podemos hacerlo*/
		public static int counterL = 0;
		public static int counterR = 0;

		/*Esta propiedad nos sirve para establecer los valores del contador izquierdo o obtener su valor*/
		public int CounterL
		{

			get => this.counterLeft;
			set => this.counterLeft = value;

		}

		/*Esta propiedad nos sirve para establecer los valores del contador derecho o obtener su valor*/
		public int CounterR
		{

			get => this.counterRight;
			set => this.counterRight = value;

		}

		/*Esta propiedad nos sirve para establecer los valores de la pelota*/
		public Ball BallStage
		{

			get => this.ball;
			set => this.ball = value;

		}

		/*Esta propiedad nos sirve para establecer los valores del de la barra izquierda*/
		public Bar BarLeft
		{

			get => this.barLeft;
			set => this.barLeft = value;

		}

		/*Esta propiedad nos sirve para establecer los valores del de la barra derecha*/
		public Bar BarRight
		{

			get => this.barRight;
			set => this.barRight = value;

		}

		/*Este sera el constructor de esta clase, asociando la pelota, las barras, los contadores iniciales con el objeto
		  que hayamos creado*/
		public StageController(Ball ball, Bar barLeft, Bar barRight, int CL, int CR)
		{

			this.BallStage = ball;
			this.BarLeft = barLeft;
			this.BarRight = barRight;
			this.CounterL = CL;
			this.CounterR = CR;

		}

		/*Este metodo sirve para ir cambiando la posicion de la pelota del escenario en funcion de su direccion*/
		public void setPosition()
		{

			/*Este if hara que la pelota se dirija hacia la derecha, y abajo, porque el eje Y esta invertido
			  las condiciones nos indican que la direccion en el eje X es positiva y en el Y negativa*/
			if (this.BallStage.DirectionX == 1 && this.BallStage.DirectionY == 1)
			{

				//La posicion en X la aumentamos y la direccion en Y, la disminuimos
				this.BallStage.PositionX++;
				this.BallStage.PositionY++;

			}

			/*Este if representa el movimiento de la pelota cuando la direccion en X sea positiva y en Y sea positiva
			  lo que hara sera desplazar la pelota hacia arriba a la derecha*/
			else if (this.BallStage.DirectionX == 1 && this.BallStage.DirectionY == -1)
			{
				//La posicion en X la aumentamos y en Y la aumentamos
				this.BallStage.PositionX++;
				this.BallStage.PositionY--;

			}

			/*Este if nos indica que la direccion en X es negativa y la Y tambien es negativa, cambiando la posicion
			  de la pelota hacia abajo a la izquierda*/
			else if (this.BallStage.DirectionX == -1 && this.BallStage.DirectionY == 1)
			{
				//La posicion en X la disminuimos y la Y la disminuimos
				this.BallStage.PositionX--;
				this.BallStage.PositionY++;

			}

			/*Este metodo nos indica que la direccion de la pelota en X es negativa y en Y es positiva, lo que hara
			 sera desplazar la pelota arriba a la izquierda*/
			else if (this.BallStage.DirectionX == -1 && this.BallStage.DirectionY == -1)
			{
				//La posicion en X la disminuimos y en Y la aumentamos
				this.BallStage.PositionX--;
				this.BallStage.PositionY--;

			}

			/*La direccion en X es positiva y en Y es 0, indicando que se mueve en linea recta,
			 esto originara que solo se desplace en el eje de las abscisas positivamente*/
			else if (this.BallStage.DirectionX == 1 && this.BallStage.DirectionY == 0)
			{
				//Cambiamos solo la posicion X de la pelota hacia la derecha
				this.BallStage.PositionX++;

			}

			/*La direccion de la pelota en X es negativa y en Y es 0 indicando que se desplazara
			  la pelota solo en el eje X hacia la izquierda*/
			else if (this.BallStage.DirectionX == -1 && this.BallStage.DirectionY == 0)
			{
				//Cambiamos la posicion X de la pelota, solo hacia la izquierda
				this.BallStage.PositionX--;

			}

		}

		/*Este metodo nos sirve para detectar las colisiones de forma constante con las paredes laterales,
		  superiores e inferiores, para cambiar la direccion de la pelota, tambien si hemos llegado
		  al contador maximo de los laterales para indicar quien es el ganador, a su vez de la colision
		  con las barras*/
		public void detectColision()
		{

			//Si estamos en el limite superior cambiamos la direccion de la pelota
			if (this.BallStage.PositionY == 11)
			{
				//Establemos la direccion en Y en negativa
				this.BallStage.DirectionY = 1;

			}

			//Si estamos en el limite inferior cambiamos la direccion de la pelota
			if (this.BallStage.PositionY == 27)
			{
				//Establecemos la direccion de Y en positiva
				this.BallStage.DirectionY = -1;

			}

			//Si el contador ha llegado al limite establecido se acaba el juego e indicamos que jugador ha ganado
			if (CounterL >= maxCounter)
			{
				//Cambiamos el modo de juego a modo ganador, para detener el bucle y mostrar al ganador
				MainMenuController.mode = GameMode.WinnerMode;

				//Cambiamos la variable para indicar quien es el ganador
				GameController.PlayerWin1 = true;

			}

			//Si el contador ha llegado al limite establecido se acaba el juego e indicamos que jugador ha ganado
			if (CounterR >= maxCounter)
			{
				//Cambiamos el modo de juego a modo ganador, para detener el bucle y mostrar al ganador
				MainMenuController.mode = GameMode.WinnerMode;

				//Cambiamos la variable para indicar quien es el ganador
				GameController.PlayerWin2 = true;

			}

			/*Si llegamos a los limites laterales, detectamos esa colision y reseteamos las posiciones de la pelota,
			  de las barras laterales, aumentamos los contadores respectivos para mostrar una mayor puntuacion y
			  cambiamos la direccion de la pelota para ir en sentido opuesto a la porteria donde se han marcado los puntos*/
			if (this.BallStage.PositionX == (limitRight - 2))
			{
				//Incrementamos el contador del jugador 1
				this.CounterL++;

				//Establecemos las posiciones iniciales de los elementos
				this.BallStage.PositionX = 60;
				this.BallStage.PositionY = 20;

				this.BarRight.PositionX = limitRight - 10;
				this.BarRight.PositionY = 20;

				this.BarLeft.PositionX = limitLeft + 10;
				this.BarLeft.PositionY = 20;

				//Cambiamos la direccion de la pelota cuando se reinicie en sentido contrario al de la porteria
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = -1;

			}

			/*Si llegamos a los limites laterales, detectamos esa colision y reseteamos las posiciones de la pelota,
			  de las barras laterales, aumentamos los contadores respectivos para mostrar una mayor puntuacion y
			  cambiamos la direccion de la pelota para ir en sentido opuesto a la porteria donde se han marcado los puntos*/
			if (this.BallStage.PositionX == (limitLeft + 2))
			{
				//Incrementamos el contador del jugador 1
				this.CounterR++;

				//Establecemos las posiciones iniciales de los elementos
				this.BallStage.PositionX = 60;
				this.BallStage.PositionY = 20;

				this.BarRight.PositionX = limitRight - 10;
				this.BarRight.PositionY = 20;

				this.BarLeft.PositionX = limitLeft + 10;
				this.BarLeft.PositionY = 20;

				//Cambiamos la direccion de la pelota cuando se reinicie en sentido contrario al de la porteria
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = 1;

			}

			//Detectamos la colision de la pelota con el centro de la barra
			if (this.BallStage.PositionX == this.BarRight.PositionX - 1 &&
				this.BallStage.PositionY == this.BarRight.PositionY || 
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY)
			{

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y no se modifica
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = 0;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado*/
			if (this.BallStage.PositionX == this.BarRight.PositionX - 1 &&
				this.BallStage.PositionY == this.BarRight.PositionY - 1 ||
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY - 1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = -1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado*/
			if (this.BallStage.PositionX == this.BarRight.PositionX - 1 &&
				this.BallStage.PositionY == this.BarRight.PositionY + 1 ||
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY + 1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = 1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado*/
			if (this.BallStage.PositionX == this.BarLeft.PositionX + 1 &&
				this.BallStage.PositionY == this.BarLeft.PositionY ||
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = 0;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado*/
			if (this.BallStage.PositionX == this.BarLeft.PositionX + 1 &&
			   this.BallStage.PositionY == this.BarLeft.PositionY + 1 ||
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY + 1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = 1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado*/
			if (this.BallStage.PositionX == this.BarLeft.PositionX + 1 &&
				this.BallStage.PositionY == this.BarLeft.PositionY - 1 ||
				this.BallStage.PositionX == this.BarRight.PositionX &&
				this.BallStage.PositionY == this.BarRight.PositionY - 1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = -1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado, este en concreto
			  detecta una colision exterior si la pelota esta en una direccion concreta*/
			if (this.BallStage.PositionX == this.BarRight.PositionX - 1 &&
				this.BallStage.PositionY == this.BarRight.PositionY - 2 &&
				this.BallStage.DirectionX == 1 && this.BallStage.DirectionY == 1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = -1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado, este en concreto
			  detecta una colision exterior si la pelota esta en una direccion concreta*/
			if (this.BallStage.PositionX == this.BarRight.PositionX - 1 &&
				this.BallStage.PositionY == this.BarRight.PositionY + 2 &&
				this.BallStage.DirectionX == 1 && this.BallStage.DirectionY == -1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = -1;
				this.BallStage.DirectionY = 1;

			}

			/*Detec/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado, este en concreto
			  detecta una colision exterior si la pelota esta en una direccion concreta*/
			if (this.BallStage.PositionX == this.BarLeft.PositionX + 1 &&
				this.BallStage.PositionY == this.BarLeft.PositionY + 2 &&
				this.BallStage.DirectionX == -1 && this.BallStage.DirectionY == -1) {

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = 1;

			}

			/*Detectamos la colision con los laterales de la barra que estos funcionan de una forma distinta
			  ya que redirigen la direccion en Y en el sentido opuesto al que ha colisionado, este en concreto
			  detecta una colision exterior si la pelota esta en una direccion concreta*/
			if (this.BallStage.PositionX == this.BarLeft.PositionX + 1 &&
				this.BallStage.PositionY == this.BarLeft.PositionY - 2 &&
				this.BallStage.DirectionX == -1 && this.BallStage.DirectionY == 1) 	{

				//Cambiamos la direccion de la pelota al sentido opuesto en X y en Y
				this.BallStage.DirectionX = 1;
				this.BallStage.DirectionY = -1;

			}

		}

	}

}
