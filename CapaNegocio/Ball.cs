using System;

//Declaramos el namespace
namespace Pong_Game.CapaNegocio
{

	//Declaramos la clase 
	public class Ball
	{

		/*Declaramos las variables que representaran la posicion de la pelota tanto en el eje X como en el 
		  eje Y*/
		private int positionX;
		private int positionY;

		/*Declaramos las direcciones que tendra la pelota constantemente, que iremos cambiando en funcion
		  de donde se encuentre colisionando*/
		private int directionX;
		private int directionY;

		/*Declaramos propiedades de la pelota, para su posicion y para su direccion*/
		public int PositionX
		{

			get => this.positionX;
			set => this.positionX = value;

		}

		public int PositionY
		{

			get => this.positionY;
			set => this.positionY = value;
		}

		public int DirectionX
		{

			get => this.directionX;
			set => this.directionX = value;

		}

		public int DirectionY
		{

			get => this.directionY;
			set => this.directionY = value;

		}

		/*Declaramos el constructor de la pelota para asociarle una posicion y una direccion,
		  la direccion sera aleatoria para que haya un 50% de probabilidad de que vaya
		  hacia un lado del escenario o hacia el otro*/
		public Ball(int posicionx, int posiciony)
		{

			//Establecemos una direccion aleatoria inicial para la pelota
			int direccionAleatoria = (new Random()).Next(1, 10);

			//Si la direccion es cambiar le asignamos una direccion, si no, le asignamos la contraria
			if (direccionAleatoria % 2 == 0)
			{

				this.DirectionX = -1;
				this.DirectionY = -1;

			}
			else
			{

				this.DirectionX = -1;
				this.DirectionY = -1;

			}

			this.PositionX = posicionx;
			this.PositionY = posiciony;

		}

	}

}

