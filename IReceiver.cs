using System;

namespace RobotCommand
{
	public interface IReceiver
	{
		Point moveUP();
		Point moveDown();
		Point moveRight();
		Point moveLeft();
	}
}

