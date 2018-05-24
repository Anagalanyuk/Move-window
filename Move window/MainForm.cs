using System;
using System.Drawing;
using System.Windows.Forms;

namespace MoveWindow
{
	public partial class moveWindow : Form
	{
		private const int step = 6;

		private Direction move = Direction.Up;

		public moveWindow()
		{
			InitializeComponent();
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e)
		{
			moveTimer.Start();
			switch (e.KeyCode)
			{
				case Keys.Down:
					move = Direction.Up;
					break;
				case Keys.Enter:
					move = Direction.Enter;
					Location = new Point(533, 214);
					break;
				case Keys.Left:
					move = Direction.Left;
					break;
				case Keys.Right:
					move = Direction.Right;
					break;
				case Keys.Up:
					move = Direction.Down;
					break;
			}
		}

		private void MoveTimer_Tick(object sender, EventArgs e)
		{
			if (Location.Y > Screen.PrimaryScreen.Bounds.Bottom - Size.Height)
			{
				move = Direction.Down;
			}
			else if (Location.X > Screen.PrimaryScreen.Bounds.Right - Size.Width)
			{
				move = Direction.Left;
			}
			else if (Location.X < Screen.PrimaryScreen.Bounds.Left)
			{
				move = Direction.Right;
			}
			else if (Location.Y < Screen.PrimaryScreen.Bounds.Top)
			{
				move = Direction.Up;
			}

			switch (move)
			{
				case Direction.Down:
					Location = new Point(Location.X, Location.Y - step);
					break;
				case Direction.Left:
					Location = new Point(Location.X - step, Location.Y);
					break;
				case Direction.Right:
					Location = new Point(Location.X + step, Location.Y);
					break;
				case Direction.Up:
					Location = new Point(Location.X, Location.Y + step);
					break;
			}
		}
	}
}