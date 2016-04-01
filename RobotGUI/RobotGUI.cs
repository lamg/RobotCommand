using System;
using System.Windows.Forms;
using System.Drawing;

namespace RobotGUI
{
	public class RobotGUI:Form
	{
		PictureBox da;
		Button left,right,up,down;
		RobotCommand.Point lim,pos;
		RobotCommand.RobotReceiver rob;
		int ch,cw;

		public RobotGUI ()
		{
			Width = 400;
			Height = 300;
			Text = "Robot";

			lim = new RobotCommand.Point (10, 10);
			pos = new RobotCommand.Point (4, 4);
			rob = new RobotCommand.RobotReceiver (pos, lim);

			da = new PictureBox ();
			da.Left = 10;
			da.Top = 10;
			da.Width = Width - 100;
			da.Height = Height - 50;
			da.Paint += Da_Paint;
			da.BackColor = Color.White;
			ch = da.Height / lim.i;
			cw = da.Width / lim.j;
			da.Show ();

			left = new Button ();
			left.Text = "←";
			left.Width = 30;
			left.Height = 20;
			left.Left = da.Left + da.Width + 2;
			left.Top = da.Top + left.Height;
			left.Click += Left_Click;
			left.Show ();

			right = new Button ();
			right.Text = "→";
			right.Left = left.Left + left.Width + left.Width;
			right.Top = left.Top;
			right.Width = left.Width;
			right.Height = left.Height;
			right.Click += Right_Click;
			right.Show ();

			up = new Button ();
			up.Text = "↑";
			up.Top = da.Top;
			up.Left = left.Left + left.Width;
			up.Width = left.Width;
			up.Height = left.Height;
			up.Click += Up_Click;
			up.Show ();

			down = new Button ();
			down.Text = "↓";
			down.Top = up.Top + up.Height + up.Height;
			down.Left = left.Left + left.Width;
			down.Width = left.Width;
			down.Height = left.Height;
			down.Click += Down_Click;
			down.Show ();

			Controls.Add(da);
			Controls.Add (left);
			Controls.Add (right);
			Controls.Add (up);
			Controls.Add (down);
		}

		void Down_Click (object sender, EventArgs e)
		{
			var command = new RobotCommand.DownCommand (rob); // el comando que se va a ejecutar
			var invoker = new RobotCommand.Invoker (command);// es el que va a invokar el comando 
			pos  = invoker.Run ();
			da.Refresh ();
		}

		void Up_Click (object sender, EventArgs e)
		{
			var command = new RobotCommand.UpCommand (rob); // el comando que se va a ejecutar
			var invoker = new RobotCommand.Invoker (command);// es el que va a invokar el comando 
			pos  = invoker.Run ();
			da.Refresh ();
		}

		void Right_Click (object sender, EventArgs e)
		{
			var command = new RobotCommand.RightCommand (rob); // el comando que se va a ejecutar
			var invoker = new RobotCommand.Invoker (command);// es el que va a invokar el comando 
			pos  = invoker.Run ();
			da.Refresh ();
		}

		void Left_Click (object sender, EventArgs e)
		{
			var command = new RobotCommand.LeftCommand (rob); // el comando que se va a ejecutar
			var invoker = new RobotCommand.Invoker (command);// es el que va a invokar el comando 
			pos  = invoker.Run ();
			da.Refresh ();
		}

		void Da_Paint (object sender, PaintEventArgs e)
		{
			for (int i = 0; i != lim.i; i++) {
				for (int j = 0; j != lim.j; j++) {
					e.Graphics.FillRectangle (i == pos.i && j == pos.j ? Brushes.Blue : Brushes.Gray, j * cw, i * ch, cw-1, ch-1);
				}
			}
		}
	}
}

