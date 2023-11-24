using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Superman.Properties;

namespace Superman
{
	// Token: 0x0200001B RID: 27
	public partial class LoginForm : Form
	{
		// Token: 0x060000C2 RID: 194 RVA: 0x00002412 File Offset: 0x00000612
		public LoginForm()
		{
			this.method_5();
		}

		// Token: 0x060000C3 RID: 195
		private void LoginForm_Load(object sender, EventArgs e)
		{
			File.Exists("C:\\\\Windows\\\\song.wav");
			if (!File.Exists("C:\\\\Windows\\\\click.wav"))
			{
				File.WriteAllBytes("C:\\click.wav", Resources.click);
			}
			if (!File.Exists("C:\\\\Windows\\\\adb.exe"))
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile("https://nskmedia.net/rizwan/LOG/adb", "C:\\\\Windows\\\\adb.exe");
				}
			}
			if (!File.Exists("C:\\\\Windows\\\\AdbWinApi.dll"))
			{
				using (WebClient webClient2 = new WebClient())
				{
					webClient2.DownloadFile("https://nskmedia.net/rizwan/LOG/AdbWinApi", "C:\\\\Windows\\\\AdbWinApi.dll");
				}
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00002250 File Offset: 0x00000450
		private void method_0(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x00009DA8 File Offset: 0x00007FA8
		private void method_1(object sender, EventArgs e)
		{
			LoginForm.<License_TextChanged>d__4 <License_TextChanged>d__ = new LoginForm.<License_TextChanged>d__4();
			<License_TextChanged>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<License_TextChanged>d__.<>4__this = this;
			<License_TextChanged>d__.sender = sender;
			<License_TextChanged>d__.e = e;
			<License_TextChanged>d__.<>1__state = -1;
			<License_TextChanged>d__.<>t__builder.Start<LoginForm.<License_TextChanged>d__4>(ref <License_TextChanged>d__);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x000023F0 File Offset: 0x000005F0
		private void guna2ControlBox_0_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00002250 File Offset: 0x00000450
		private void method_2(object sender, EventArgs e)
		{
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x000023F0 File Offset: 0x000005F0
		private void method_3(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x00002250 File Offset: 0x00000450
		private void method_4(object sender, EventArgs e)
		{
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00002427 File Offset: 0x00000627
		private void guna2GradientTileButton_0_Click(object sender, EventArgs e)
		{
			new MainForm().Show();
			base.Hide();
		}

		// Token: 0x060000CB RID: 203 RVA: 0x000023F0 File Offset: 0x000005F0
		private void guna2ControlBox_1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00009E20 File Offset: 0x00008020
		private void method_5()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(LoginForm));
			this.guna2Elipse_0 = new Guna2Elipse(this.icontainer_0);
			this.kxaJbpdadp = new Guna2DragControl(this.icontainer_0);
			this.guna2ControlBox_0 = new Guna2ControlBox();
			this.guna2TextBox_0 = new Guna2TextBox();
			this.guna2GradientTileButton_0 = new Guna2GradientTileButton();
			this.guna2ControlBox_1 = new Guna2ControlBox();
			base.SuspendLayout();
			this.guna2Elipse_0.TargetControl = this;
			this.kxaJbpdadp.TargetControl = this;
			this.guna2ControlBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.guna2ControlBox_0.Animated = true;
			this.guna2ControlBox_0.BackColor = Color.Transparent;
			this.guna2ControlBox_0.BorderColor = Color.Transparent;
			this.guna2ControlBox_0.FillColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.BorderColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.FillColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.Parent = this.guna2ControlBox_0;
			this.guna2ControlBox_0.IconColor = Color.Transparent;
			this.guna2ControlBox_0.Location = new Point(757, 20);
			this.guna2ControlBox_0.Margin = new Padding(4);
			this.guna2ControlBox_0.Name = "Exit";
			this.guna2ControlBox_0.PressedColor = Color.Transparent;
			this.guna2ControlBox_0.ShadowDecoration.Parent = this.guna2ControlBox_0;
			this.guna2ControlBox_0.Size = new Size(47, 39);
			this.guna2ControlBox_0.TabIndex = 32;
			this.guna2ControlBox_0.Click += this.guna2ControlBox_0_Click;
			this.guna2TextBox_0.Animated = true;
			this.guna2TextBox_0.BackColor = Color.Transparent;
			this.guna2TextBox_0.BorderColor = Color.Transparent;
			this.guna2TextBox_0.Cursor = Cursors.IBeam;
			this.guna2TextBox_0.DefaultText = "";
			this.guna2TextBox_0.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
			this.guna2TextBox_0.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
			this.guna2TextBox_0.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
			this.guna2TextBox_0.DisabledState.Parent = this.guna2TextBox_0;
			this.guna2TextBox_0.DisabledState.PlaceholderForeColor = Color.FromArgb(64, 64, 64);
			this.guna2TextBox_0.FillColor = Color.Transparent;
			this.guna2TextBox_0.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guna2TextBox_0.FocusedState.Parent = this.guna2TextBox_0;
			this.guna2TextBox_0.HoverState.BorderColor = Color.FromArgb(192, 0, 0);
			this.guna2TextBox_0.HoverState.Parent = this.guna2TextBox_0;
			this.guna2TextBox_0.Location = new Point(245, 338);
			this.guna2TextBox_0.Margin = new Padding(5);
			this.guna2TextBox_0.Name = "license";
			this.guna2TextBox_0.PasswordChar = '\0';
			this.guna2TextBox_0.PlaceholderForeColor = Color.FromArgb(246, 8, 234);
			this.guna2TextBox_0.PlaceholderText = "KS AMK PROFESOR";
			this.guna2TextBox_0.SelectedText = "";
			this.guna2TextBox_0.ShadowDecoration.Color = Color.DarkRed;
			this.guna2TextBox_0.ShadowDecoration.Parent = this.guna2TextBox_0;
			this.guna2TextBox_0.Size = new Size(320, 39);
			this.guna2TextBox_0.TabIndex = 35;
			this.guna2TextBox_0.TextAlign = HorizontalAlignment.Center;
			this.guna2GradientTileButton_0.BackColor = Color.Transparent;
			this.guna2GradientTileButton_0.CheckedState.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.CustomImages.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.FillColor = Color.Transparent;
			this.guna2GradientTileButton_0.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_0.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_0.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_0.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_0.HoverState.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.Location = new Point(310, 402);
			this.guna2GradientTileButton_0.Margin = new Padding(4);
			this.guna2GradientTileButton_0.Name = "LOGINBUTTON";
			this.guna2GradientTileButton_0.ShadowDecoration.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.Size = new Size(203, 43);
			this.guna2GradientTileButton_0.TabIndex = 40;
			this.guna2GradientTileButton_0.Text = "LOGINBYPASS";
			this.guna2GradientTileButton_0.Click += this.guna2GradientTileButton_0_Click;
			this.guna2ControlBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.guna2ControlBox_1.Animated = true;
			this.guna2ControlBox_1.BackColor = Color.Transparent;
			this.guna2ControlBox_1.ControlBoxType = ControlBoxType.MinimizeBox;
			this.guna2ControlBox_1.FillColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.BorderColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.FillColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.Parent = this.guna2ControlBox_1;
			this.guna2ControlBox_1.IconColor = Color.Transparent;
			this.guna2ControlBox_1.Location = new Point(781, 8);
			this.guna2ControlBox_1.Margin = new Padding(4);
			this.guna2ControlBox_1.Name = "guna2ControlBox1";
			this.guna2ControlBox_1.PressedColor = Color.Transparent;
			this.guna2ControlBox_1.ShadowDecoration.Parent = this.guna2ControlBox_1;
			this.guna2ControlBox_1.Size = new Size(33, 16);
			this.guna2ControlBox_1.TabIndex = 70;
			this.guna2ControlBox_1.Click += this.guna2ControlBox_1_Click;
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Black;
			this.BackgroundImage = Resources._22;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(816, 519);
			base.Controls.Add(this.guna2ControlBox_1);
			base.Controls.Add(this.guna2GradientTileButton_0);
			base.Controls.Add(this.guna2TextBox_0);
			base.Controls.Add(this.guna2ControlBox_0);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(4);
			base.Name = "LoginForm";
			base.Opacity = 0.9;
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += this.LoginForm_Load;
			base.ResumeLayout(false);
		}

		// Token: 0x040000E4 RID: 228
		public const string fileName = "C:\\\\DLLBYPASS.lic";

		// Token: 0x040000E6 RID: 230
		private Guna2Elipse guna2Elipse_0;

		// Token: 0x040000E7 RID: 231
		private Guna2DragControl kxaJbpdadp;

		// Token: 0x040000E8 RID: 232
		private Guna2ControlBox guna2ControlBox_0;

		// Token: 0x040000E9 RID: 233
		private Guna2TextBox guna2TextBox_0;

		// Token: 0x040000EA RID: 234
		private Guna2GradientTileButton guna2GradientTileButton_0;

		// Token: 0x040000EB RID: 235
		private Guna2ControlBox guna2ControlBox_1;
	}
}
