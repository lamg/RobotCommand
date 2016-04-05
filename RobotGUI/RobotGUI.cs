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
        Image rb;
		int ch,cw;

		public RobotGUI ()
		{
			Width = 550;
			Height = 320;
			Text = "Robot";
            rb = new Bitmap("robot-5.png");
            MinimumSize = new Size(Width, Height);
            MaximumSize = new Size(Width, Height);
            KeyUp += RobotGUI_KeyUp;
            KeyPreview = true;
           
            

			lim = new RobotCommand.Point (10, 10);
			pos = new RobotCommand.Point (4, 4);
			rob = new RobotCommand.RobotReceiver (pos, lim);

			da = new PictureBox ();
            da.LostFocus += Da_LostFocus;
			da.Left = 10;
			da.Top = 10;
			da.Width = Width - 200;
			da.Height = Height - 60;
			da.Paint += Da_Paint;
			da.BackColor = Color.Black;
			ch = da.Height / lim.i;
			cw = da.Width / lim.j;
			da.Show ();

			left = new Button ();
            left.Capture = false;
            left.LostFocus += Left_LostFocus;
			left.Text = "←";
			left.Width = 50;
			left.Height = 30;
			left.Left = da.Left + da.Width + 15;
			left.Top = da.Top + left.Height + da.Height/3;
			left.Click += Left_Click;
			left.Show ();

			right = new Button ();
            right.GotFocus += Right_GotFocus;
			right.Text = "→";
			right.Left = left.Left + left.Width + left.Width;
			right.Top = left.Top;
			right.Width = left.Width;
			right.Height = left.Height;
			right.Click += Right_Click;
			right.Show ();

			up = new Button ();
            up.GotFocus += Up_GotFocus;
			up.Text = "↑";
            up.Top = da.Top + da.Height / 3;
            up.Left = left.Left + left.Width;
			up.Width = left.Width;
			up.Height = left.Height;
			up.Click += Up_Click;
			up.Show ();

			down = new Button ();
            down.GotFocus += Down_GotFocus;
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

        private void Da_LostFocus(object sender, EventArgs e)
        {
            da.Focus();
        }

        private void Down_GotFocus(object sender, EventArgs e)
        {
            da.Focus();
        }

        private void Up_GotFocus(object sender, EventArgs e)
        {
            da.Focus();
        }

        private void Right_GotFocus(object sender, EventArgs e)
        {
            da.Focus();
        }

        private void Left_LostFocus(object sender, EventArgs e)
        {
            da.Focus();
        }

        private void RobotGUI_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                MLeft();
            }
            else if (e.KeyCode == Keys.Right)
            {
                MRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                MUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                MDown();
            }
           
        }

     
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RobotGUI
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RobotGUI";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.RobotGUI_KeyUp);
            this.ResumeLayout(false);

        }

        void Down_Click (object sender, EventArgs e)
		{
            MDown();
		}

		void Up_Click (object sender, EventArgs e)
		{
            MUp();
		}

		void Right_Click (object sender, EventArgs e)
		{
            MRight();
		}

		void Left_Click (object sender, EventArgs e)
		{
            MLeft();
		}

        void MLeft()
        {
            var command = new RobotCommand.LeftCommand(rob); // el comando que se va a ejecutar
            var invoker = new RobotCommand.Invoker(command);// es el que va a invokar el comando 
            pos = invoker.Run();
            da.Refresh();
        }

        void MRight()
        {
            var command = new RobotCommand.RightCommand(rob); // el comando que se va a ejecutar
            var invoker = new RobotCommand.Invoker(command);// es el que va a invokar el comando 
            pos = invoker.Run();
            da.Refresh();
        }

        void MUp()
        {
            var command = new RobotCommand.UpCommand(rob); // el comando que se va a ejecutar
            var invoker = new RobotCommand.Invoker(command);// es el que va a invokar el comando 
            pos = invoker.Run();
            da.Refresh();
        }

        void MDown()
        {
            var command = new RobotCommand.DownCommand(rob); // el comando que se va a ejecutar
            var invoker = new RobotCommand.Invoker(command);// es el que va a invokar el comando 
            pos = invoker.Run();
            da.Refresh();
        }

		void Da_Paint (object sender, PaintEventArgs e)
		{
			for (int i = 0; i != lim.i; i++) {
				for (int j = 0; j != lim.j; j++) {
                    if (i == pos.i && j == pos.j)
                    {
                        e.Graphics.DrawImage(rb, j * cw, i * ch, cw - 1, ch - 1);
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, j * cw, i * ch, cw - 1, ch - 1);
                    }
					
				}
			}
		}
	}
}

