using System;

namespace RobotCommand
{
	public class DownCommand : ICommand
	{
		IReceiver receiver;

		public Point Execute ()
		{
			return receiver.moveDown ();
		}

	

		public DownCommand (IReceiver receiver)
		{
			this.receiver = receiver;
		}
	}
}

