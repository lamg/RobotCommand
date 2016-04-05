using System;

namespace RobotCommand
{
	public class Invoker
	{
		ICommand command;

		public Point Run()
		{
			return command.Execute ();
		}
			
		public Invoker (ICommand command)
		{
			this.command = command;
		}
	}
}

