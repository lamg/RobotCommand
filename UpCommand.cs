using System;

namespace RobotCommand
{
	public class UpCommand : ICommand
	{
		IReceiver receiver;

		public Point Execute ()
		{
			return receiver.moveUP ();
		}



		public UpCommand (IReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}

