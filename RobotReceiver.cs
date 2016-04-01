using System;

namespace RobotCommand
{
	public class RobotReceiver : IReceiver
	{
		Point pos,lim;

		#region IReceiver implementation

		public Point moveUP ()
		{
			pos.i = Math.Max (0, pos.i - 1);
			return pos;
		}

		public Point moveDown ()
		{
			pos.i = Math.Min (lim.i-1, pos.i + 1);
			return pos;
		}

		public Point moveRight ()
		{
			pos.j = Math.Min (lim.j-1, pos.j + 1);
			return pos;
		}

		public Point moveLeft ()
		{
			pos.j = Math.Max (0, pos.j - 1);
			return pos;
		}

		#endregion

		public RobotReceiver (Point pos, Point lim)
		{
			this.pos = pos;
			this.lim = lim;
		}
	}
}

