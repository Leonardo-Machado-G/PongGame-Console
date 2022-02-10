//Declaramos las librerias que vamos a utilizar
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pong_Game.CapaNegocio;
using Pong_Game.CapaPresentacion;

//Declaramos el namespace
namespace Pong_Game.CapaDatos
{
    //Declaramos la clase
    public class SaveSettings{

        //Metodo para generar un archivo de texto y guardar la configuracion que deseemos
        public static void generateTextContent() {

            //Establecemos la ruta donde vamos a guardar la configuracion de nuestro juego
            String path = "..\\assets\\configuration.txt";

            //Si no existe el archivo capturamos la exception para evitar fallos, sino, lo borramos
            try {
            
                File.Delete(path);
            
            } catch (Exception e) {  }

            //Guardamos en un string toda la informacion al respecto de nuestra configuracion
            String content = GameController.gameSpeed + "\n" + StageController.maxCounter + "\n" + 
                             StageController.limitRight + "\n" + StageController.limitLeft + "\n" +
                             StageController.counterL + "\n" + StageController.counterR;

            //Creamos un archivo con una rita y escribimos el contenido en el
            using (StreamWriter file = new StreamWriter(path, true)) {

                //Escribimos el contenido y cerramos el archivo
                file.WriteLine(content);
                file.Close();

            }

        }

        //Metodo para obtener los valores del documento de texto y asociarlo a variables
        public static void readTextContent()
        {

            //Indicamos una ruta de achivo
            String path = "..\\assets\\configuration.txt";

            //Indicamos una variable que nos servira para leer lineas del coumento
            string line = "";

            //Intentamos leer el archivo, en caso de saltar un error lo capturamos
            try {

                //Declaramos un strean reader para leer la ruta especificada
                using (StreamReader file = new StreamReader(path))
                {

                    //Creamos un bucle para leer cada linea del documento e ir introduciendolas en las variables
                    for (int i = 0; line != null; i++)
                    {
                        line = file.ReadLine();
                        if (i == 0) { GameController.gameSpeed = Int32.Parse(line); }
                        else if (i == 1) { StageController.maxCounter = Int32.Parse(line); }
                        else if (i == 2) { StageController.limitRight = Int32.Parse(line); }
                        else if (i == 3) { StageController.limitLeft = Int32.Parse(line); }
                        else if (i == 4) { StageController.counterL = Int32.Parse(line); }
                        else if (i == 5) { StageController.counterR = Int32.Parse(line); }

                    }

                }

            //No nos interesa conocer el mensaje en caso de no encontrar el archivo
            } catch (Exception e) { }

        }

    }

}
