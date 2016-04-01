using System;

namespace RobotCommand
{
	public class RightCommand : ICommand
	{
		IReceiver receiver;

		public Point Execute ()
		{
			return receiver.moveRight ();
		}

	

		public RightCommand (IReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}

