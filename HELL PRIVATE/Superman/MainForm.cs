using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiscordRPC;
using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using Microsoft.Win32;
using Newtonsoft.Json;
using Superman.Properties;
using SupermanLove;

namespace Superman
{
	// Token: 0x02000011 RID: 17
	public partial class MainForm : Form
	{
		// Token: 0x06000079 RID: 121 RVA: 0x00005D5C File Offset: 0x00003F5C
		public MainForm()
		{
			this.method_13();
			this.BackColor = Color.Gray;
			base.TransparencyKey = Color.Gray;
			this.timer_0 = new System.Windows.Forms.Timer();
			this.timer_0.Tick += this.timer_0_Tick;
			this.timer_0.Interval = (int)TimeSpan.FromHours(24.0).TotalMilliseconds;
			this.timer_0.Start();
		}

		// Token: 0x0600007A RID: 122
		[DllImport("kernel32.dll")]
		public static extern IntPtr CreateToolhelp32Snapshot(uint flags, uint processid);

		// Token: 0x0600007B RID: 123
		[DllImport("kernel32.dll")]
		public static extern int Process32First(IntPtr handle, ref MainForm.ProcessEntry32 pe);

		// Token: 0x0600007C RID: 124
		[DllImport("kernel32.dll")]
		public static extern int Process32Next(IntPtr handle, ref MainForm.ProcessEntry32 pe);

		// Token: 0x0600007D RID: 125
		[DllImport("user32.dll")]
		public static extern int FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x0600007E RID: 126
		[DllImport("user32.dll")]
		public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

		// Token: 0x0600007F RID: 127 RVA: 0x00005E5C File Offset: 0x0000405C
		private Task method_0(int int_0)
		{
			MainForm.<PutTaskDelay>d__17 <PutTaskDelay>d__ = new MainForm.<PutTaskDelay>d__17();
			<PutTaskDelay>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PutTaskDelay>d__.<>4__this = this;
			<PutTaskDelay>d__.Time = int_0;
			<PutTaskDelay>d__.<>1__state = -1;
			<PutTaskDelay>d__.<>t__builder.Start<MainForm.<PutTaskDelay>d__17>(ref <PutTaskDelay>d__);
			return <PutTaskDelay>d__.<>t__builder.Task;
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00002250 File Offset: 0x00000450
		private void guna2RadioButton_0_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000081 RID: 129 RVA: 0x00005EA8 File Offset: 0x000040A8
		public void system(string arg)
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				FileName = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\cmd.exe",
				Arguments = "/c " + arg
			};
			process.Start();
			process.WaitForExit();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x00005F1C File Offset: 0x0000411C
		public string executee(string arg)
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				CreateNoWindow = true,
				UseShellExecute = false,
				RedirectStandardOutput = true,
				FileName = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\cmd.exe",
				Arguments = "/c " + arg
			};
			process.Start();
			process.WaitForExit();
			return process.StandardOutput.ReadToEnd();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x00005F9C File Offset: 0x0000419C
		public Task<MainForm.Data> FindBase(string HeaderBytes, long start, long end, bool readflag, bool writeflag, bool executeflag)
		{
			MainForm.<FindBase>d__22 <FindBase>d__ = new MainForm.<FindBase>d__22();
			<FindBase>d__.<>t__builder = AsyncTaskMethodBuilder<MainForm.Data>.Create();
			<FindBase>d__.<>4__this = this;
			<FindBase>d__.HeaderBytes = HeaderBytes;
			<FindBase>d__.start = start;
			<FindBase>d__.end = end;
			<FindBase>d__.readflag = readflag;
			<FindBase>d__.writeflag = writeflag;
			<FindBase>d__.executeflag = executeflag;
			<FindBase>d__.<>1__state = -1;
			<FindBase>d__.<>t__builder.Start<MainForm.<FindBase>d__22>(ref <FindBase>d__);
			return <FindBase>d__.<>t__builder.Task;
		}

		// Token: 0x06000084 RID: 132
		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenThread(MainForm.ThreadAccess threadAccess_0, bool bool_6, uint uint_0);

		// Token: 0x06000085 RID: 133
		[DllImport("kernel32.dll")]
		private static extern uint SuspendThread(IntPtr intptr_0);

		// Token: 0x06000086 RID: 134
		[DllImport("kernel32.dll")]
		private static extern int ResumeThread(IntPtr intptr_0);

		// Token: 0x06000087 RID: 135
		[DllImport("kernel32", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern bool CloseHandle(IntPtr intptr_0);

		// Token: 0x06000088 RID: 136 RVA: 0x00006010 File Offset: 0x00004210
		private Task<IntPtr> method_1()
		{
			MainForm.<ProcFindGAGAHEX>d__29 <ProcFindGAGAHEX>d__ = new MainForm.<ProcFindGAGAHEX>d__29();
			<ProcFindGAGAHEX>d__.<>t__builder = AsyncTaskMethodBuilder<IntPtr>.Create();
			<ProcFindGAGAHEX>d__.<>4__this = this;
			<ProcFindGAGAHEX>d__.<>1__state = -1;
			<ProcFindGAGAHEX>d__.<>t__builder.Start<MainForm.<ProcFindGAGAHEX>d__29>(ref <ProcFindGAGAHEX>d__);
			return <ProcFindGAGAHEX>d__.<>t__builder.Task;
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00006054 File Offset: 0x00004254
		private Task<IntPtr> method_2()
		{
			MainForm.<ProcFindLOOP7HEX>d__30 <ProcFindLOOP7HEX>d__ = new MainForm.<ProcFindLOOP7HEX>d__30();
			<ProcFindLOOP7HEX>d__.<>t__builder = AsyncTaskMethodBuilder<IntPtr>.Create();
			<ProcFindLOOP7HEX>d__.<>4__this = this;
			<ProcFindLOOP7HEX>d__.<>1__state = -1;
			<ProcFindLOOP7HEX>d__.<>t__builder.Start<MainForm.<ProcFindLOOP7HEX>d__30>(ref <ProcFindLOOP7HEX>d__);
			return <ProcFindLOOP7HEX>d__.<>t__builder.Task;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00006098 File Offset: 0x00004298
		public void WriteConig(string data)
		{
			string path = this.string_0;
			if (!File.Exists(path))
			{
				using (StreamWriter streamWriter = new StreamWriter(path, true))
				{
					streamWriter.WriteLine(data);
					return;
				}
			}
			if (File.Exists(path))
			{
				using (StreamWriter streamWriter2 = new StreamWriter(path, true))
				{
					streamWriter2.WriteLine(data);
				}
			}
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00006118 File Offset: 0x00004318
		public void Expires()
		{
			string text = File.ReadAllText("C:\\\\Windows\\\\Expire.txt");
			this.label_2.Text = text;
			this.label_2.ForeColor = Color.Red;
			this.label_2.Refresh();
		}

		// Token: 0x0600008C RID: 140 RVA: 0x00006158 File Offset: 0x00004358
		public void Loop()
		{
			do
			{
				this.executee("attrib +h +s +r C:\\Windows\\BypassDone");
				this.executee("attrib +h +s +r C:\\Windows\\EmuFound");
				Thread.Sleep(2000);
				if (File.Exists("C:\\\\Windows\\\\EmuFound"))
				{
					this.executee("attrib -h -s -r C:\\Windows\\EmuFound");
					File.Delete("C:\\\\Windows\\\\EmuFound");
					this.label_0.Text = "Emu Load Okay                                                           ";
					this.label_0.ForeColor = Color.Lime;
					this.label_0.Refresh();
					Thread.Sleep(2000);
					Thread thread = new Thread(new ThreadStart(this.Expires));
					thread.Start();
					File.Delete(this.string_0);
					this.label_0.Text = "PLEASE WAIT WORKING ON BYPASS                                                           ";
					this.label_0.ForeColor = Color.Yellow;
					this.label_0.Refresh();
				}
			}
			while (!File.Exists("C:\\\\Windows\\\\BypassDone"));
			this.executee("attrib -h -s -r C:\\Windows\\BypassDone");
			File.Delete("C:\\\\Windows\\\\BypassDone");
			this.label_0.Text = "BYPASS HELL DONE                                                            ";
			this.label_0.ForeColor = Color.LimeGreen;
			this.label_0.Refresh();
		}

		// Token: 0x0600008D RID: 141 RVA: 0x00006294 File Offset: 0x00004494
		private bool method_3(string string_1, string string_2)
		{
			string a;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(string_1))
				{
					byte[] value = md.ComputeHash(fileStream);
					a = BitConverter.ToString(value).Replace("-", string.Empty).ToLower();
				}
			}
			return !(a != string_2);
		}

		// Token: 0x0600008E RID: 142 RVA: 0x0000631C File Offset: 0x0000451C
		public string GetUiPath()
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\UI"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("InstallPath");
					if (value != null)
					{
						return value.ToString();
					}
				}
			}
			return null;
		}

		// Token: 0x0600008F RID: 143 RVA: 0x0000637C File Offset: 0x0000457C
		public string GetAppMarketPath()
		{
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Tencent\\MobileGamePC\\AppMarket"))
			{
				if (registryKey != null)
				{
					object value = registryKey.GetValue("InstallPath");
					if (value != null)
					{
						return value.ToString();
					}
				}
			}
			return null;
		}

		// Token: 0x06000090 RID: 144 RVA: 0x000063DC File Offset: 0x000045DC
		public static string GetTempPath()
		{
			string name = "Software\\Tencent\\MobileGamePC";
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(name);
			string result;
			if (registryKey != null)
			{
				object value = registryKey.GetValue("sf");
				string text = (value != null) ? value.ToString() : null;
				result = text;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000091 RID: 145
		public void StartEmulator()
		{
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo
			{
				FileName = "cmd.exe",
				CreateNoWindow = true,
				RedirectStandardInput = true,
				UseShellExecute = false
			};
			process.Start();
			using (StreamWriter standardInput = process.StandardInput)
			{
				if (standardInput.BaseStream.CanWrite)
				{
					standardInput.WriteLine("taskkill /F /im AppMarket.exe");
					standardInput.WriteLine("taskkill /F /im AppMarket.exe");
					standardInput.WriteLine("TaskKill /F /IM AndroidEmulatorEx.exe");
					standardInput.WriteLine("TaskKill /F /IM AndroidEmulatorEn.exe");
					standardInput.WriteLine("TaskKill /F /IM AndroidEmulator.exe");
					standardInput.WriteLine("TaskKill /F /IM aow.exe");
					Thread.Sleep(2000);
					string uiPath = this.GetUiPath();
					if (!string.IsNullOrEmpty(uiPath))
					{
						if (File.Exists(Path.Combine(uiPath, "dsound.dll")))
						{
							File.Delete(Path.Combine(uiPath, "dsound.dll"));
						}
						try
						{
							string destFileName = uiPath + "/dsound.dll";
							File.Copy("Memlib.dll", destFileName);
						}
						catch (Exception)
						{
							MessageBox.Show("Please Paste Memlib.dll In Bypass Folder", "Memlib.dll");
							Environment.Exit(0);
						}
						standardInput.WriteLine("@cd/d \"" + uiPath + "\"");
					}
					else
					{
						MessageBox.Show("Gameloop Not Found! Please Start Ex Emulator Manually", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
					}
					standardInput.WriteLine("start AndroidEmulatorEx.exe -vm 100");
					standardInput.Flush();
					standardInput.Close();
					process.WaitForExit();
				}
			}
		}

		// Token: 0x06000092 RID: 146 RVA: 0x000065C8 File Offset: 0x000047C8
		private void guna2GradientTileButton_0_Click(object sender, EventArgs e)
		{
			MainForm.<Guna2GradientTileButton1_Click>d__41 <Guna2GradientTileButton1_Click>d__ = new MainForm.<Guna2GradientTileButton1_Click>d__41();
			<Guna2GradientTileButton1_Click>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Guna2GradientTileButton1_Click>d__.<>4__this = this;
			<Guna2GradientTileButton1_Click>d__.sender = sender;
			<Guna2GradientTileButton1_Click>d__.e = e;
			<Guna2GradientTileButton1_Click>d__.<>1__state = -1;
			<Guna2GradientTileButton1_Click>d__.<>t__builder.Start<MainForm.<Guna2GradientTileButton1_Click>d__41>(ref <Guna2GradientTileButton1_Click>d__);
		}

		// Token: 0x06000093 RID: 147 RVA: 0x000022B8 File Offset: 0x000004B8
		private void MainForm_Load(object sender, EventArgs e)
		{
			this.method_4();
		}

		// Token: 0x06000094 RID: 148 RVA: 0x00002250 File Offset: 0x00000450
		private void label_0_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x06000095 RID: 149 RVA: 0x00006610 File Offset: 0x00004810
		private void method_4()
		{
			this.discordRpcClient_0 = new DiscordRpcClient("1160035844359471125", -1, null, true, null);
			this.discordRpcClient_0.Initialize();
			string text = "https://discord.gg/Fj2VkkDrS4";
			string text2 = "Join Discord";
			this.button_0[0] = JsonConvert.DeserializeObject<DiscordRPC.Button>(string.Concat(new string[]
			{
				"{\"Url\":\"",
				text,
				"\", \"Label\":\"",
				text2,
				"\"}"
			}));
			RichPresence presence = new RichPresence
			{
				Details = "Playing Pubg Mobile",
				Timestamps = Timestamps.Now,
				Assets = new Assets
				{
					LargeImageKey = "https://s6.gifyu.com/images/S63xd.gif",
					SmallImageKey = "https://i.giphy.com/media/yoTCgY1ysO7cLfa6s7/giphy.webp"
				}
			};
			this.discordRpcClient_0.SetPresence(presence);
		}

		// Token: 0x06000096 RID: 150 RVA: 0x000066CC File Offset: 0x000048CC
		private void method_5(int int_0)
		{
			MainForm.<SAFEEXIT>d__46 <SAFEEXIT>d__ = new MainForm.<SAFEEXIT>d__46();
			<SAFEEXIT>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<SAFEEXIT>d__.<>4__this = this;
			<SAFEEXIT>d__.times = int_0;
			<SAFEEXIT>d__.<>1__state = -1;
			<SAFEEXIT>d__.<>t__builder.Start<MainForm.<SAFEEXIT>d__46>(ref <SAFEEXIT>d__);
		}

		// Token: 0x06000097 RID: 151 RVA: 0x0000670C File Offset: 0x0000490C
		private void guna2GradientTileButton_1_Click(object sender, EventArgs e)
		{
			new SoundPlayer
			{
				SoundLocation = "C:\\click.wav"
			}.Play();
			this.backgroundWorker_0 = new BackgroundWorker();
			this.backgroundWorker_0.DoWork += this.backgroundWorker_0_DoWork;
			this.backgroundWorker_0.RunWorkerAsync();
		}

		// Token: 0x06000098 RID: 152 RVA: 0x00002250 File Offset: 0x00000450
		private void guna2RadioButton_1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000099 RID: 153 RVA: 0x00002250 File Offset: 0x00000450
		private void guna2CheckBox_2_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00002250 File Offset: 0x00000450
		private void label_1_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00002250 File Offset: 0x00000450
		private void guna2CheckBox_1_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00002250 File Offset: 0x00000450
		private void guna2ControlBox_0_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00006760 File Offset: 0x00004960
		private void method_6(object sender, EventArgs e)
		{
			new SoundPlayer
			{
				SoundLocation = "C:\\Windows\\song.wav"
			}.Play();
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00006784 File Offset: 0x00004984
		private void method_7(object sender, EventArgs e)
		{
			new SoundPlayer
			{
				SoundLocation = "C:\\Windows\\song.wav"
			}.Stop();
		}

		// Token: 0x0600009F RID: 159 RVA: 0x000022C0 File Offset: 0x000004C0
		private void method_8(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/phoenixvip");
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x000022CD File Offset: 0x000004CD
		private void method_9(object sender, EventArgs e)
		{
			Process.Start("https://t.me/blackmagicop");
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x00002250 File Offset: 0x00000450
		private void method_10(object sender, EventArgs e)
		{
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000022DA File Offset: 0x000004DA
		private void guna2GradientTileButton_2_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "GLOBAL";
			this.label_0.Refresh();
			this.label_0.ForeColor = Color.Lime;
			this.label_0.Refresh();
			this.bool_1 = true;
		}

		// Token: 0x060000A3 RID: 163 RVA: 0x00002319 File Offset: 0x00000519
		private void guna2GradientTileButton_5_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "VIETNAM";
			this.label_0.Refresh();
			this.label_0.ForeColor = Color.Lime;
			this.label_0.Refresh();
			this.bool_4 = true;
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x00002358 File Offset: 0x00000558
		private void guna2GradientTileButton_4_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "KOREA";
			this.label_0.Refresh();
			this.label_0.ForeColor = Color.Lime;
			this.label_0.Refresh();
			this.bool_2 = true;
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x00002397 File Offset: 0x00000597
		private void guna2GradientTileButton_3_Click(object sender, EventArgs e)
		{
			this.label_0.Text = "TAIWAN";
			this.label_0.Refresh();
			this.label_0.ForeColor = Color.Lime;
			this.label_0.Refresh();
			this.bool_3 = true;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x000023D6 File Offset: 0x000005D6
		private void method_11(object sender, EventArgs e)
		{
			Process.Start("https://t.me/HACKPUPGY2010");
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x000023E3 File Offset: 0x000005E3
		private void method_12(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/Fj2VkkDrS4");
		}

		// Token: 0x060000A8 RID: 168 RVA: 0x000023F0 File Offset: 0x000005F0
		private void guna2ControlBox_1_Click(object sender, EventArgs e)
		{
			Environment.Exit(0);
		}

		// Token: 0x060000AA RID: 170 RVA: 0x000067D8 File Offset: 0x000049D8
		private void method_13()
		{
			this.icontainer_0 = new Container();
			ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
			this.guna2Elipse_0 = new Guna2Elipse(this.icontainer_0);
			this.guna2DragControl_0 = new Guna2DragControl(this.icontainer_0);
			this.guna2ControlBox_0 = new Guna2ControlBox();
			this.guna2GradientTileButton_0 = new Guna2GradientTileButton();
			this.guna2RadioButton_0 = new Guna2RadioButton();
			this.guna2GradientTileButton_1 = new Guna2GradientTileButton();
			this.guna2CheckBox_0 = new Guna2CheckBox();
			this.label_0 = new Label();
			this.guna2CheckBox_2 = new Guna2CheckBox();
			this.guna2CheckBox_1 = new Guna2CheckBox();
			this.guna2RadioButton_1 = new Guna2RadioButton();
			this.label_1 = new Label();
			this.groupBox_0 = new GroupBox();
			this.guna2CheckBox_3 = new Guna2CheckBox();
			this.guna2CheckBox_4 = new Guna2CheckBox();
			this.guna2CheckBox_5 = new Guna2CheckBox();
			this.guna2RadioButton_2 = new Guna2RadioButton();
			this.guna2CheckBox_6 = new Guna2CheckBox();
			this.guna2GradientTileButton_2 = new Guna2GradientTileButton();
			this.guna2GradientTileButton_5 = new Guna2GradientTileButton();
			this.guna2GradientTileButton_4 = new Guna2GradientTileButton();
			this.guna2GradientTileButton_3 = new Guna2GradientTileButton();
			this.guna2ControlBox_1 = new Guna2ControlBox();
			this.label_2 = new Label();
			this.groupBox_0.SuspendLayout();
			base.SuspendLayout();
			this.guna2Elipse_0.TargetControl = this;
			this.guna2DragControl_0.TargetControl = this;
			this.guna2ControlBox_0.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.guna2ControlBox_0.Animated = true;
			this.guna2ControlBox_0.BackColor = Color.Transparent;
			this.guna2ControlBox_0.ControlBoxType = ControlBoxType.MinimizeBox;
			this.guna2ControlBox_0.FillColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.BorderColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.FillColor = Color.Transparent;
			this.guna2ControlBox_0.HoverState.Parent = this.guna2ControlBox_0;
			this.guna2ControlBox_0.IconColor = Color.Transparent;
			this.guna2ControlBox_0.Location = new Point(870, 10);
			this.guna2ControlBox_0.Margin = new Padding(4);
			this.guna2ControlBox_0.Name = "Minimized";
			this.guna2ControlBox_0.PressedColor = Color.Transparent;
			this.guna2ControlBox_0.ShadowDecoration.Parent = this.guna2ControlBox_0;
			this.guna2ControlBox_0.Size = new Size(37, 29);
			this.guna2ControlBox_0.TabIndex = 22;
			this.guna2ControlBox_0.Click += this.guna2ControlBox_0_Click;
			this.guna2GradientTileButton_0.BackColor = Color.Transparent;
			this.guna2GradientTileButton_0.CheckedState.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.CustomImages.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.FillColor = Color.Transparent;
			this.guna2GradientTileButton_0.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_0.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_0.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_0.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_0.HoverState.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.Location = new Point(577, 221);
			this.guna2GradientTileButton_0.Margin = new Padding(4);
			this.guna2GradientTileButton_0.Name = "guna2GradientTileButton1";
			this.guna2GradientTileButton_0.ShadowDecoration.Parent = this.guna2GradientTileButton_0;
			this.guna2GradientTileButton_0.Size = new Size(255, 37);
			this.guna2GradientTileButton_0.TabIndex = 29;
			this.guna2GradientTileButton_0.Text = "START BYPASS";
			this.guna2GradientTileButton_0.Click += this.guna2GradientTileButton_0_Click;
			this.guna2RadioButton_0.Animated = true;
			this.guna2RadioButton_0.AutoSize = true;
			this.guna2RadioButton_0.BackColor = Color.Transparent;
			this.guna2RadioButton_0.CheckedState.BorderThickness = 0;
			this.guna2RadioButton_0.CheckedState.FillColor = Color.FromArgb(192, 0, 0);
			this.guna2RadioButton_0.CheckedState.InnerColor = Color.White;
			this.guna2RadioButton_0.CheckedState.InnerOffset = -7;
			this.guna2RadioButton_0.FlatStyle = FlatStyle.Popup;
			this.guna2RadioButton_0.Font = new Font("Franklin Gothic Medium", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2RadioButton_0.ForeColor = Color.Silver;
			this.guna2RadioButton_0.Location = new Point(260, 49);
			this.guna2RadioButton_0.Margin = new Padding(4);
			this.guna2RadioButton_0.Name = "LOOPCH";
			this.guna2RadioButton_0.Size = new Size(128, 24);
			this.guna2RadioButton_0.TabIndex = 42;
			this.guna2RadioButton_0.Text = "LOOP 7.1{Ch}";
			this.guna2RadioButton_0.UncheckedState.BorderColor = Color.FromArgb(125, 137, 149);
			this.guna2RadioButton_0.UncheckedState.BorderThickness = 2;
			this.guna2RadioButton_0.UncheckedState.FillColor = Color.Transparent;
			this.guna2RadioButton_0.UncheckedState.InnerColor = Color.Transparent;
			this.guna2RadioButton_0.UseVisualStyleBackColor = false;
			this.guna2RadioButton_0.Visible = false;
			this.guna2RadioButton_0.CheckedChanged += this.guna2RadioButton_0_CheckedChanged;
			this.guna2GradientTileButton_1.BackColor = Color.Transparent;
			this.guna2GradientTileButton_1.CheckedState.Parent = this.guna2GradientTileButton_1;
			this.guna2GradientTileButton_1.CustomImages.Parent = this.guna2GradientTileButton_1;
			this.guna2GradientTileButton_1.FillColor = Color.Transparent;
			this.guna2GradientTileButton_1.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_1.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_1.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_1.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_1.HoverState.Parent = this.guna2GradientTileButton_1;
			this.guna2GradientTileButton_1.Location = new Point(577, 292);
			this.guna2GradientTileButton_1.Margin = new Padding(4);
			this.guna2GradientTileButton_1.Name = "guna2GradientTileButton2";
			this.guna2GradientTileButton_1.ShadowDecoration.Parent = this.guna2GradientTileButton_1;
			this.guna2GradientTileButton_1.Size = new Size(255, 34);
			this.guna2GradientTileButton_1.TabIndex = 44;
			this.guna2GradientTileButton_1.Text = "SAFE EXIT";
			this.guna2GradientTileButton_1.Click += this.guna2GradientTileButton_1_Click;
			this.guna2CheckBox_0.Animated = true;
			this.guna2CheckBox_0.AutoSize = true;
			this.guna2CheckBox_0.BackColor = Color.Transparent;
			this.guna2CheckBox_0.CheckedState.BorderColor = Color.Red;
			this.guna2CheckBox_0.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_0.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_0.CheckedState.FillColor = Color.Red;
			this.guna2CheckBox_0.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_0.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_0.Font = new Font("Microsoft YaHei UI", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_0.ForeColor = Color.FromArgb(255, 128, 0);
			this.guna2CheckBox_0.Location = new Point(735, 363);
			this.guna2CheckBox_0.Margin = new Padding(4);
			this.guna2CheckBox_0.Name = "DEVICEID";
			this.guna2CheckBox_0.Size = new Size(15, 14);
			this.guna2CheckBox_0.TabIndex = 45;
			this.guna2CheckBox_0.UncheckedState.BorderColor = Color.Red;
			this.guna2CheckBox_0.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_0.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_0.UncheckedState.FillColor = Color.Transparent;
			this.guna2CheckBox_0.UseVisualStyleBackColor = false;
			this.label_0.AutoSize = true;
			this.label_0.BackColor = Color.Transparent;
			this.label_0.Font = new Font("Microsoft YaHei", 7.8f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label_0.ForeColor = Color.White;
			this.label_0.Location = new Point(659, 402);
			this.label_0.Margin = new Padding(4, 0, 4, 0);
			this.label_0.Name = "status";
			this.label_0.Size = new Size(173, 19);
			this.label_0.TabIndex = 47;
			this.label_0.Text = "WELCOME HELL PRIVATE";
			this.label_0.Click += this.label_0_Click;
			this.guna2CheckBox_2.Animated = true;
			this.guna2CheckBox_2.AutoSize = true;
			this.guna2CheckBox_2.BackColor = Color.Transparent;
			this.guna2CheckBox_2.CheckedState.BorderColor = Color.Red;
			this.guna2CheckBox_2.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_2.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_2.CheckedState.FillColor = Color.Red;
			this.guna2CheckBox_2.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_2.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_2.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_2.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_2.Location = new Point(592, 363);
			this.guna2CheckBox_2.Margin = new Padding(4);
			this.guna2CheckBox_2.Name = "IPADVIEW";
			this.guna2CheckBox_2.Size = new Size(15, 14);
			this.guna2CheckBox_2.TabIndex = 48;
			this.guna2CheckBox_2.UncheckedState.BorderColor = Color.Red;
			this.guna2CheckBox_2.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_2.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_2.UncheckedState.FillColor = Color.Transparent;
			this.guna2CheckBox_2.UseVisualStyleBackColor = false;
			this.guna2CheckBox_2.CheckedChanged += this.guna2CheckBox_2_CheckedChanged;
			this.guna2CheckBox_1.Animated = true;
			this.guna2CheckBox_1.AutoSize = true;
			this.guna2CheckBox_1.BackColor = Color.Transparent;
			this.guna2CheckBox_1.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guna2CheckBox_1.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_1.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_1.CheckedState.FillColor = Color.Maroon;
			this.guna2CheckBox_1.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_1.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_1.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_1.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_1.Location = new Point(22, 23);
			this.guna2CheckBox_1.Margin = new Padding(4);
			this.guna2CheckBox_1.Name = "RECOIL";
			this.guna2CheckBox_1.Size = new Size(111, 21);
			this.guna2CheckBox_1.TabIndex = 49;
			this.guna2CheckBox_1.Text = "NO RECOIL";
			this.guna2CheckBox_1.UncheckedState.BorderColor = Color.Gray;
			this.guna2CheckBox_1.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_1.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_1.UncheckedState.FillColor = Color.Black;
			this.guna2CheckBox_1.UseVisualStyleBackColor = false;
			this.guna2CheckBox_1.Visible = false;
			this.guna2CheckBox_1.CheckedChanged += this.guna2CheckBox_1_CheckedChanged;
			this.guna2RadioButton_1.Animated = true;
			this.guna2RadioButton_1.AutoSize = true;
			this.guna2RadioButton_1.BackColor = Color.Transparent;
			this.guna2RadioButton_1.CheckedState.BorderThickness = 0;
			this.guna2RadioButton_1.CheckedState.FillColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_1.CheckedState.InnerColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_1.CheckedState.InnerOffset = -7;
			this.guna2RadioButton_1.FlatStyle = FlatStyle.Popup;
			this.guna2RadioButton_1.Font = new Font("Franklin Gothic Medium", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2RadioButton_1.ForeColor = Color.Transparent;
			this.guna2RadioButton_1.Location = new Point(178, 107);
			this.guna2RadioButton_1.Margin = new Padding(4);
			this.guna2RadioButton_1.Name = "LOOPEX";
			this.guna2RadioButton_1.Size = new Size(16, 15);
			this.guna2RadioButton_1.TabIndex = 50;
			this.guna2RadioButton_1.UncheckedState.BorderColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_1.UncheckedState.BorderThickness = 2;
			this.guna2RadioButton_1.UncheckedState.FillColor = Color.Transparent;
			this.guna2RadioButton_1.UncheckedState.InnerColor = Color.Transparent;
			this.guna2RadioButton_1.UseVisualStyleBackColor = false;
			this.guna2RadioButton_1.Visible = false;
			this.guna2RadioButton_1.CheckedChanged += this.guna2RadioButton_1_CheckedChanged;
			this.label_1.AutoSize = true;
			this.label_1.Location = new Point(70, 74);
			this.label_1.Name = "ProcID";
			this.label_1.Size = new Size(61, 16);
			this.label_1.TabIndex = 55;
			this.label_1.Text = "ProcFind";
			this.label_1.Visible = false;
			this.label_1.Click += this.label_1_Click;
			this.groupBox_0.BackColor = Color.Transparent;
			this.groupBox_0.Controls.Add(this.guna2CheckBox_3);
			this.groupBox_0.Controls.Add(this.guna2CheckBox_4);
			this.groupBox_0.Controls.Add(this.guna2CheckBox_5);
			this.groupBox_0.Controls.Add(this.guna2RadioButton_0);
			this.groupBox_0.Controls.Add(this.guna2CheckBox_1);
			this.groupBox_0.ForeColor = SystemColors.AppWorkspace;
			this.groupBox_0.Location = new Point(201, 11);
			this.groupBox_0.Margin = new Padding(4);
			this.groupBox_0.Name = "groupBox1";
			this.groupBox_0.Padding = new Padding(4);
			this.groupBox_0.Size = new Size(464, 86);
			this.groupBox_0.TabIndex = 57;
			this.groupBox_0.TabStop = false;
			this.groupBox_0.Text = "Memory";
			this.groupBox_0.Visible = false;
			this.guna2CheckBox_3.Animated = true;
			this.guna2CheckBox_3.AutoSize = true;
			this.guna2CheckBox_3.BackColor = Color.Transparent;
			this.guna2CheckBox_3.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guna2CheckBox_3.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_3.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_3.CheckedState.FillColor = Color.Maroon;
			this.guna2CheckBox_3.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_3.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_3.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_3.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_3.Location = new Point(151, 52);
			this.guna2CheckBox_3.Margin = new Padding(4);
			this.guna2CheckBox_3.Name = "guna2CheckBox2";
			this.guna2CheckBox_3.Size = new Size(101, 21);
			this.guna2CheckBox_3.TabIndex = 51;
			this.guna2CheckBox_3.Text = "SLOW MO";
			this.guna2CheckBox_3.UncheckedState.BorderColor = Color.Gray;
			this.guna2CheckBox_3.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_3.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_3.UncheckedState.FillColor = Color.Black;
			this.guna2CheckBox_3.UseVisualStyleBackColor = false;
			this.guna2CheckBox_3.Visible = false;
			this.guna2CheckBox_4.Animated = true;
			this.guna2CheckBox_4.AutoSize = true;
			this.guna2CheckBox_4.BackColor = Color.Transparent;
			this.guna2CheckBox_4.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guna2CheckBox_4.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_4.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_4.CheckedState.FillColor = Color.Maroon;
			this.guna2CheckBox_4.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_4.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_4.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_4.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_4.Location = new Point(8, 52);
			this.guna2CheckBox_4.Margin = new Padding(4);
			this.guna2CheckBox_4.Name = "guna2CheckBox1";
			this.guna2CheckBox_4.Size = new Size(104, 21);
			this.guna2CheckBox_4.TabIndex = 50;
			this.guna2CheckBox_4.Text = "FIX FLASH";
			this.guna2CheckBox_4.UncheckedState.BorderColor = Color.Gray;
			this.guna2CheckBox_4.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_4.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_4.UncheckedState.FillColor = Color.Black;
			this.guna2CheckBox_4.UseVisualStyleBackColor = false;
			this.guna2CheckBox_4.Visible = false;
			this.guna2CheckBox_5.Animated = true;
			this.guna2CheckBox_5.AutoSize = true;
			this.guna2CheckBox_5.BackColor = Color.Transparent;
			this.guna2CheckBox_5.CheckedState.BorderColor = Color.FromArgb(94, 148, 255);
			this.guna2CheckBox_5.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_5.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_5.CheckedState.FillColor = Color.Maroon;
			this.guna2CheckBox_5.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_5.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_5.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_5.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_5.Location = new Point(151, 23);
			this.guna2CheckBox_5.Margin = new Padding(4);
			this.guna2CheckBox_5.Name = "HEADSHOT";
			this.guna2CheckBox_5.Size = new Size(139, 21);
			this.guna2CheckBox_5.TabIndex = 48;
			this.guna2CheckBox_5.Text = "0% HEADSHOT";
			this.guna2CheckBox_5.UncheckedState.BorderColor = Color.Gray;
			this.guna2CheckBox_5.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_5.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_5.UncheckedState.FillColor = Color.Black;
			this.guna2CheckBox_5.UseVisualStyleBackColor = false;
			this.guna2CheckBox_5.Visible = false;
			this.guna2RadioButton_2.Animated = true;
			this.guna2RadioButton_2.AutoSize = true;
			this.guna2RadioButton_2.BackColor = Color.Transparent;
			this.guna2RadioButton_2.CheckedState.BorderThickness = 0;
			this.guna2RadioButton_2.CheckedState.FillColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_2.CheckedState.InnerColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_2.CheckedState.InnerOffset = -7;
			this.guna2RadioButton_2.FlatStyle = FlatStyle.Popup;
			this.guna2RadioButton_2.Font = new Font("Franklin Gothic Medium", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2RadioButton_2.ForeColor = Color.Transparent;
			this.guna2RadioButton_2.Location = new Point(178, 136);
			this.guna2RadioButton_2.Margin = new Padding(4);
			this.guna2RadioButton_2.Name = "GAGA";
			this.guna2RadioButton_2.Size = new Size(16, 15);
			this.guna2RadioButton_2.TabIndex = 59;
			this.guna2RadioButton_2.UncheckedState.BorderColor = Color.FromArgb(255, 128, 0);
			this.guna2RadioButton_2.UncheckedState.BorderThickness = 2;
			this.guna2RadioButton_2.UncheckedState.FillColor = Color.Transparent;
			this.guna2RadioButton_2.UncheckedState.InnerColor = Color.Transparent;
			this.guna2RadioButton_2.UseVisualStyleBackColor = false;
			this.guna2RadioButton_2.Visible = false;
			this.guna2CheckBox_6.Animated = true;
			this.guna2CheckBox_6.AutoSize = true;
			this.guna2CheckBox_6.BackColor = Color.Transparent;
			this.guna2CheckBox_6.CheckedState.BorderColor = Color.FromArgb(0, 0, 192);
			this.guna2CheckBox_6.CheckedState.BorderRadius = 2;
			this.guna2CheckBox_6.CheckedState.BorderThickness = 0;
			this.guna2CheckBox_6.CheckedState.FillColor = Color.Maroon;
			this.guna2CheckBox_6.FlatAppearance.BorderSize = 0;
			this.guna2CheckBox_6.FlatStyle = FlatStyle.Popup;
			this.guna2CheckBox_6.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2CheckBox_6.ForeColor = SystemColors.AppWorkspace;
			this.guna2CheckBox_6.Location = new Point(223, 137);
			this.guna2CheckBox_6.Margin = new Padding(4);
			this.guna2CheckBox_6.Name = "VisibibleCheck";
			this.guna2CheckBox_6.Size = new Size(15, 14);
			this.guna2CheckBox_6.TabIndex = 60;
			this.guna2CheckBox_6.UncheckedState.BorderColor = Color.FromArgb(0, 0, 192);
			this.guna2CheckBox_6.UncheckedState.BorderRadius = 2;
			this.guna2CheckBox_6.UncheckedState.BorderThickness = 1;
			this.guna2CheckBox_6.UncheckedState.FillColor = Color.Black;
			this.guna2CheckBox_6.UseVisualStyleBackColor = false;
			this.guna2CheckBox_6.Visible = false;
			this.guna2GradientTileButton_2.BackColor = Color.Transparent;
			this.guna2GradientTileButton_2.CheckedState.Parent = this.guna2GradientTileButton_2;
			this.guna2GradientTileButton_2.CustomImages.Parent = this.guna2GradientTileButton_2;
			this.guna2GradientTileButton_2.FillColor = Color.Transparent;
			this.guna2GradientTileButton_2.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_2.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_2.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_2.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_2.HoverState.Parent = this.guna2GradientTileButton_2;
			this.guna2GradientTileButton_2.Location = new Point(562, 163);
			this.guna2GradientTileButton_2.Margin = new Padding(4);
			this.guna2GradientTileButton_2.Name = "Global";
			this.guna2GradientTileButton_2.ShadowDecoration.Parent = this.guna2GradientTileButton_2;
			this.guna2GradientTileButton_2.Size = new Size(35, 25);
			this.guna2GradientTileButton_2.TabIndex = 65;
			this.guna2GradientTileButton_2.Text = "START BYPASS";
			this.guna2GradientTileButton_2.Click += this.guna2GradientTileButton_2_Click;
			this.guna2GradientTileButton_5.BackColor = Color.Transparent;
			this.guna2GradientTileButton_5.CheckedState.Parent = this.guna2GradientTileButton_5;
			this.guna2GradientTileButton_5.CustomImages.Parent = this.guna2GradientTileButton_5;
			this.guna2GradientTileButton_5.FillColor = Color.Transparent;
			this.guna2GradientTileButton_5.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_5.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_5.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_5.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_5.HoverState.Parent = this.guna2GradientTileButton_5;
			this.guna2GradientTileButton_5.Location = new Point(808, 161);
			this.guna2GradientTileButton_5.Margin = new Padding(4);
			this.guna2GradientTileButton_5.Name = "VIETNAM";
			this.guna2GradientTileButton_5.ShadowDecoration.Parent = this.guna2GradientTileButton_5;
			this.guna2GradientTileButton_5.Size = new Size(40, 25);
			this.guna2GradientTileButton_5.TabIndex = 66;
			this.guna2GradientTileButton_5.Text = "START BYPASS";
			this.guna2GradientTileButton_5.Click += this.guna2GradientTileButton_5_Click;
			this.guna2GradientTileButton_4.BackColor = Color.Transparent;
			this.guna2GradientTileButton_4.CheckedState.Parent = this.guna2GradientTileButton_4;
			this.guna2GradientTileButton_4.CustomImages.Parent = this.guna2GradientTileButton_4;
			this.guna2GradientTileButton_4.FillColor = Color.Transparent;
			this.guna2GradientTileButton_4.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_4.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_4.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_4.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_4.HoverState.Parent = this.guna2GradientTileButton_4;
			this.guna2GradientTileButton_4.Location = new Point(636, 161);
			this.guna2GradientTileButton_4.Margin = new Padding(4);
			this.guna2GradientTileButton_4.Name = "KOREA";
			this.guna2GradientTileButton_4.ShadowDecoration.Parent = this.guna2GradientTileButton_4;
			this.guna2GradientTileButton_4.Size = new Size(44, 25);
			this.guna2GradientTileButton_4.TabIndex = 67;
			this.guna2GradientTileButton_4.Text = "START BYPASS";
			this.guna2GradientTileButton_4.Click += this.guna2GradientTileButton_4_Click;
			this.guna2GradientTileButton_3.BackColor = Color.Transparent;
			this.guna2GradientTileButton_3.CheckedState.Parent = this.guna2GradientTileButton_3;
			this.guna2GradientTileButton_3.CustomImages.Parent = this.guna2GradientTileButton_3;
			this.guna2GradientTileButton_3.FillColor = Color.Transparent;
			this.guna2GradientTileButton_3.FillColor2 = Color.Transparent;
			this.guna2GradientTileButton_3.Font = new Font("Segoe UI", 9f);
			this.guna2GradientTileButton_3.ForeColor = Color.Transparent;
			this.guna2GradientTileButton_3.HoverState.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.guna2GradientTileButton_3.HoverState.Parent = this.guna2GradientTileButton_3;
			this.guna2GradientTileButton_3.Location = new Point(721, 161);
			this.guna2GradientTileButton_3.Margin = new Padding(4);
			this.guna2GradientTileButton_3.Name = "TAIWAN";
			this.guna2GradientTileButton_3.ShadowDecoration.Parent = this.guna2GradientTileButton_3;
			this.guna2GradientTileButton_3.Size = new Size(43, 25);
			this.guna2GradientTileButton_3.TabIndex = 68;
			this.guna2GradientTileButton_3.Text = "START BYPASS";
			this.guna2GradientTileButton_3.Click += this.guna2GradientTileButton_3_Click;
			this.guna2ControlBox_1.Anchor = (AnchorStyles.Top | AnchorStyles.Right);
			this.guna2ControlBox_1.Animated = true;
			this.guna2ControlBox_1.BackColor = Color.Transparent;
			this.guna2ControlBox_1.ControlBoxType = ControlBoxType.MinimizeBox;
			this.guna2ControlBox_1.FillColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.BorderColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.FillColor = Color.Transparent;
			this.guna2ControlBox_1.HoverState.Parent = this.guna2ControlBox_1;
			this.guna2ControlBox_1.IconColor = Color.Transparent;
			this.guna2ControlBox_1.Location = new Point(928, 6);
			this.guna2ControlBox_1.Margin = new Padding(4);
			this.guna2ControlBox_1.Name = "EXIT";
			this.guna2ControlBox_1.PressedColor = Color.Transparent;
			this.guna2ControlBox_1.ShadowDecoration.Parent = this.guna2ControlBox_1;
			this.guna2ControlBox_1.Size = new Size(44, 35);
			this.guna2ControlBox_1.TabIndex = 69;
			this.guna2ControlBox_1.Click += this.guna2ControlBox_1_Click;
			this.label_2.AutoSize = true;
			this.label_2.BackColor = Color.Transparent;
			this.label_2.Font = new Font("Candara", 9f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.label_2.ForeColor = Color.Red;
			this.label_2.Location = new Point(660, 429);
			this.label_2.Margin = new Padding(4, 0, 4, 0);
			this.label_2.Name = "Expire";
			this.label_2.Size = new Size(12, 18);
			this.label_2.TabIndex = 70;
			this.label_2.Text = "!";
			base.AutoScaleDimensions = new SizeF(8f, 16f);
			base.AutoScaleMode = AutoScaleMode.Font;
			this.BackColor = Color.Gray;
			this.BackgroundImage = Resources._23;
			this.BackgroundImageLayout = ImageLayout.Stretch;
			base.ClientSize = new Size(985, 479);
			base.Controls.Add(this.label_2);
			base.Controls.Add(this.guna2ControlBox_1);
			base.Controls.Add(this.guna2GradientTileButton_3);
			base.Controls.Add(this.guna2GradientTileButton_4);
			base.Controls.Add(this.guna2GradientTileButton_5);
			base.Controls.Add(this.guna2CheckBox_2);
			base.Controls.Add(this.guna2GradientTileButton_2);
			base.Controls.Add(this.guna2CheckBox_6);
			base.Controls.Add(this.guna2RadioButton_2);
			base.Controls.Add(this.groupBox_0);
			base.Controls.Add(this.guna2ControlBox_0);
			base.Controls.Add(this.label_1);
			base.Controls.Add(this.guna2RadioButton_1);
			base.Controls.Add(this.label_0);
			base.Controls.Add(this.guna2CheckBox_0);
			base.Controls.Add(this.guna2GradientTileButton_1);
			base.Controls.Add(this.guna2GradientTileButton_0);
			this.DoubleBuffered = true;
			base.FormBorderStyle = FormBorderStyle.None;
			base.Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
			base.Margin = new Padding(4);
			base.Name = "MainForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			base.Load += this.MainForm_Load;
			this.groupBox_0.ResumeLayout(false);
			this.groupBox_0.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x060000AB RID: 171 RVA: 0x000088A4 File Offset: 0x00006AA4
		[CompilerGenerated]
		private void timer_0_Tick(object sender, EventArgs e)
		{
			MessageBox.Show("Time Over Again Login Please");
			try
			{
				int num = MainForm.FindWindow(null, "Select RESET NETWORK");
				if (num > 0)
				{
					MainForm.SendMessage(num, 274U, 61536, 0);
				}
				num = MainForm.FindWindow(null, "RESET NETWORK");
				if (num > 0)
				{
					MainForm.SendMessage(num, 274U, 61536, 0);
				}
				this.label_0.Text = "PROCESSING...                                                          ";
				this.label_0.Refresh();
				this.label_0.ForeColor = Color.Red;
				this.label_0.Refresh();
				this.guna2CheckBox_1.CheckState = CheckState.Unchecked;
				this.guna2CheckBox_2.CheckState = CheckState.Unchecked;
				this.guna2CheckBox_0.CheckState = CheckState.Unchecked;
				Process process = new Process();
				process = new Process();
				process.StartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					CreateNoWindow = true,
					RedirectStandardInput = true,
					UseShellExecute = false
				};
				process.Start();
				using (StreamWriter standardInput = process.StandardInput)
				{
					if (!standardInput.BaseStream.CanWrite)
					{
						return;
					}
					standardInput.WriteLine("taskkill /F /im GameLoader.exe");
					standardInput.WriteLine("TaskKill /F /IM RuntimeBroker.exe");
					standardInput.WriteLine("TaskKill /F /IM QMEmulatorService.exe");
					standardInput.WriteLine("taskkill /F /im TBSWebRenderer.exe");
					standardInput.WriteLine("taskkill /F /im AndroidEmulator.exe");
					standardInput.WriteLine("taskkill /F /im AndroidEmulatorEn.exe");
					standardInput.WriteLine("taskkill /F /im AndroidEmulatorEx.exe");
					standardInput.WriteLine("taskkill /f /im SmartGaGa.exe");
					standardInput.WriteLine("taskkill /f /im ProjectTitan.exe");
					standardInput.WriteLine("taskkill /f /im AndroidProcess.exe");
					standardInput.WriteLine(" taskkill /f /im anubischeats.SG.vmp.exe  ");
					standardInput.WriteLine("taskkill /f /im adb.exe  ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q %USERPROFILE%\appdata\\local\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.* ");
					standardInput.WriteLine("del /f /q /S C: \\Users\\% username %\\Documents\\*.exe  ");
					standardInput.WriteLine("cacls C:\\Users\\%username%\\Documents /E /P everyone:f ");
					standardInput.WriteLine("cacls C:\\Users\\% username %\\AppData\\Local\\Temp /E /P everyone:f ");
					standardInput.WriteLine("cacls C:\\ProgramData / E /P everyone:f ");
					standardInput.WriteLine("cacls C:\\Windows\\Prefetch /E /P everyone:f ");
					standardInput.WriteLine("cacls C:\\Windows\\Temp /E /P everyone:f ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q %USERPROFILE%\appdata\\local\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.* ");
					standardInput.WriteLine("del /f /q /S C: \\Users\\% username %\\Documents\\*.exe ");
					standardInput.WriteLine("netsh firewall reset");
					standardInput.WriteLine("netsh winsock reset ");
					standardInput.WriteLine("netsh int ip reset ");
					standardInput.WriteLine("ipconfig /release ");
					standardInput.WriteLine("ipconfig /renew ");
					standardInput.WriteLine("ipconfig /flushdns ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\Prefetch\\*.* ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q C:\\Windows\\System32\\temp\\*.* ");
					standardInput.WriteLine("del /s /f /q %USERPROFILE%\\appdata\\local\\temp\\*.* ");
					standardInput.Flush();
					standardInput.Close();
					process.WaitForExit();
					File.WriteAllBytes("C:\\Windows\\System32\\drivers\\etc\\hosts", Resources.hosts);
					this.label_0.Text = "SAFE EXIT DONE";
					this.label_0.Refresh();
					this.label_0.ForeColor = Color.Lime;
					this.label_0.Refresh();
				}
			}
			catch
			{
				this.label_0.Text = "EROR 404 PLEASE TRY AGAIN       ";
				this.label_0.ForeColor = Color.Red;
			}
			Environment.Exit(0);
		}

		// Token: 0x060000AC RID: 172 RVA: 0x000023F8 File Offset: 0x000005F8
		[CompilerGenerated]
		private void backgroundWorker_0_DoWork(object sender, DoWorkEventArgs e)
		{
			this.method_5(1);
		}

		// Token: 0x0400006A RID: 106
		public string userName = Environment.UserName;

		// Token: 0x0400006B RID: 107
		public long enumerable = 0L;

		// Token: 0x0400006C RID: 108
		public string GagaPath = null;

		// Token: 0x0400006D RID: 109
		public Mem MemLib = new Mem();

		// Token: 0x0400006E RID: 110
		public string GameVersion = "";

		// Token: 0x0400006F RID: 111
		public int bypassed = 0;

		// Token: 0x04000070 RID: 112
		private System.Windows.Forms.Timer timer_0;

		// Token: 0x04000071 RID: 113
		private BackgroundWorker backgroundWorker_0;

		// Token: 0x04000072 RID: 114
		private DiscordRpcClient discordRpcClient_0;

		// Token: 0x04000073 RID: 115
		public const int WM_SYSCOMMAND = 274;

		// Token: 0x04000074 RID: 116
		public const int SC_CLOSE = 61536;

		// Token: 0x04000075 RID: 117
		private bool bool_0;

		// Token: 0x04000076 RID: 118
		private string string_0 = "C:\\\\DLLBYPASSCONFIG.ini";

		// Token: 0x04000077 RID: 119
		private DiscordRPC.Button[] button_0 = new DiscordRPC.Button[1];

		// Token: 0x04000078 RID: 120
		private bool bool_1 = false;

		// Token: 0x04000079 RID: 121
		private bool bool_2 = false;

		// Token: 0x0400007A RID: 122
		private bool bool_3 = false;

		// Token: 0x0400007B RID: 123
		private bool bool_4 = false;

		// Token: 0x0400007C RID: 124
		private bool bool_5 = false;

		// Token: 0x0400007E RID: 126
		private Guna2Elipse guna2Elipse_0;

		// Token: 0x0400007F RID: 127
		private Guna2DragControl guna2DragControl_0;

		// Token: 0x04000080 RID: 128
		private Guna2ControlBox guna2ControlBox_0;

		// Token: 0x04000081 RID: 129
		private Guna2GradientTileButton guna2GradientTileButton_0;

		// Token: 0x04000082 RID: 130
		private Guna2RadioButton guna2RadioButton_0;

		// Token: 0x04000083 RID: 131
		private Guna2GradientTileButton guna2GradientTileButton_1;

		// Token: 0x04000084 RID: 132
		private Guna2CheckBox guna2CheckBox_0;

		// Token: 0x04000085 RID: 133
		private Guna2CheckBox guna2CheckBox_1;

		// Token: 0x04000086 RID: 134
		private Guna2CheckBox guna2CheckBox_2;

		// Token: 0x04000087 RID: 135
		private Label label_0;

		// Token: 0x04000088 RID: 136
		private Guna2RadioButton guna2RadioButton_1;

		// Token: 0x04000089 RID: 137
		private Label label_1;

		// Token: 0x0400008A RID: 138
		private GroupBox groupBox_0;

		// Token: 0x0400008B RID: 139
		private Guna2CheckBox guna2CheckBox_3;

		// Token: 0x0400008C RID: 140
		private Guna2CheckBox guna2CheckBox_4;

		// Token: 0x0400008D RID: 141
		private Guna2CheckBox guna2CheckBox_5;

		// Token: 0x0400008E RID: 142
		private Guna2RadioButton guna2RadioButton_2;

		// Token: 0x0400008F RID: 143
		private Guna2CheckBox guna2CheckBox_6;

		// Token: 0x04000090 RID: 144
		private Guna2GradientTileButton guna2GradientTileButton_2;

		// Token: 0x04000091 RID: 145
		private Guna2GradientTileButton guna2GradientTileButton_3;

		// Token: 0x04000092 RID: 146
		private Guna2GradientTileButton guna2GradientTileButton_4;

		// Token: 0x04000093 RID: 147
		private Guna2GradientTileButton guna2GradientTileButton_5;

		// Token: 0x04000094 RID: 148
		private Guna2ControlBox guna2ControlBox_1;

		// Token: 0x04000095 RID: 149
		private Label label_2;

		// Token: 0x02000012 RID: 18
		public struct ProcessEntry32
		{
			// Token: 0x04000096 RID: 150
			public uint dwSize;

			// Token: 0x04000097 RID: 151
			public uint cntUsage;

			// Token: 0x04000098 RID: 152
			public uint th32ProcessID;

			// Token: 0x04000099 RID: 153
			public IntPtr th32DefaultHeapID;

			// Token: 0x0400009A RID: 154
			public uint th32ModuleID;

			// Token: 0x0400009B RID: 155
			public uint cntThreads;

			// Token: 0x0400009C RID: 156
			public uint uint_0;

			// Token: 0x0400009D RID: 157
			public int pcPriClassBase;

			// Token: 0x0400009E RID: 158
			public uint dwFlags;

			// Token: 0x0400009F RID: 159
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
			public string szExeFile;
		}

		// Token: 0x02000013 RID: 19
		public class Data
		{
			// Token: 0x17000002 RID: 2
			// (get) Token: 0x060000AD RID: 173 RVA: 0x00002401 File Offset: 0x00000601
			// (set) Token: 0x060000AE RID: 174 RVA: 0x00002409 File Offset: 0x00000609
			public long Address { get; set; }

			// Token: 0x040000A0 RID: 160
			[CompilerGenerated]
			private long long_0;
		}

		// Token: 0x02000014 RID: 20
		[Flags]
		public enum ThreadAccess
		{
			// Token: 0x040000A2 RID: 162
			TERMINATE = 1,
			// Token: 0x040000A3 RID: 163
			SUSPEND_RESUME = 2,
			// Token: 0x040000A4 RID: 164
			GET_CONTEXT = 8,
			// Token: 0x040000A5 RID: 165
			SET_CONTEXT = 16,
			// Token: 0x040000A6 RID: 166
			SET_INFORMATION = 32,
			// Token: 0x040000A7 RID: 167
			QUERY_INFORMATION = 64,
			// Token: 0x040000A8 RID: 168
			SET_THREAD_TOKEN = 128,
			// Token: 0x040000A9 RID: 169
			IMPERSONATE = 256,
			// Token: 0x040000AA RID: 170
			DIRECT_IMPERSONATION = 512
		}
	}
}
