using System;

namespace RobotCommand
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var point = new Point (0, 0);// Creo el nuevo punto
			var receiver = new RobotReceiver (point, new Point(10,10)); // creo el recividor es quien contiene los movimiento

			for (int i = 0; i < 14; i++) {
				var command = new RightCommand (receiver); // el comando que se va a ejecutar
				var invoker = new Invoker (command);// es el que va a invokar el comando 
				var result  = invoker.Run ();// lo ejecuto, si no puede hacer el moviento entonces devuelve null, en caso 
				// contrario devuelve la posision.
				Console.WriteLine (result);

			}
		}


	}
}
