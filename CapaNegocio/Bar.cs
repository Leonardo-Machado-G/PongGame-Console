//Declaramos el namespace
namespace Pong_Game
{

	//Declaramos la clase
	public class Bar
	{

		/*Declaramos variables que no se cambiara su valor que establecen los limites de las barras
		  laterales en lo que respecta a altura*/
		private readonly int MAXLIMITY = 26;
		private readonly int MINLIMITY = 12;

		/*Estas dos seran variables que indicaran la posicion de las barras tanto altura como
		  su posicion en el eje X, la altura Y funciona de forma contraria, debido a que la matriz
		  se construye de 0 a un mayor valor, siendo 0 la maxima altura*/
		private int positionX;
		private int positionY;

		/*Declaramos la propiedad de la posicion en X de las barras que indicara donde esta situada
		  dentro de la matriz*/
		public int PositionX
		{

			get => this.positionX;
			set => this.positionX = value;

		}
		
		/*Declaramos la propiedad de la posicion en Y de las barras que indicara donde esta situada
		  dentro de la matriz, en caso de llegar a los limites, no nos permitira seguir subiendo o bajando*/
		public int PositionY
		{

			get => this.positionY;
			set
			{

				if (value >= MAXLIMITY)
				{

					this.positionY = MAXLIMITY;

				}
				else if (value <= MINLIMITY)
				{

					this.positionY = MINLIMITY;

				}
				else
				{

					this.positionY = value;

				}

			}

		}

		//Declaramos el constructor para asociarle posiciones a las barras
		public Bar(int positionx, int positiony)
		{

			this.PositionY = positiony;
			this.PositionX = positionx;

		}

	}

}

