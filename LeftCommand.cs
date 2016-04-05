using System;

namespace RobotCommand
{
	public class LeftCommand : ICommand
	{
		IReceiver receiver;

		public Point Execute ()
		{
			return receiver.moveLeft ();
		}

	

		public LeftCommand (IReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}

