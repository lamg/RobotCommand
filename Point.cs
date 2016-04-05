using System;

namespace RobotCommand
{
	public class Point
	{
		public int i {
			get;
			set;
		}

		public int j {
			get;
			set;
		}

		public Point (int i , int j)
		{
			this.i = i;
			this.j = j;
		}

		public override string ToString ()
		{
			return string.Format ("[Point: i={0}, j={1}]", i, j);
		}

		public override bool Equals (object obj)
		{
			return obj as Point != null && obj.ToString() == ToString();
		}

		public override int GetHashCode ()
		{
			return ToString ().GetHashCode ();
		}
	}
}

