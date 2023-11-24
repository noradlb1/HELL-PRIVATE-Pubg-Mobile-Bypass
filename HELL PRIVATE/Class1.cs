using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using KeyAuth;
using Superman.Properties;

// Token: 0x0200001E RID: 30
internal class Class1
{
	// Token: 0x060000D2 RID: 210
	[DllImport("user32.dll")]
	public static extern int FindWindow(string string_1, string string_2);

	// Token: 0x060000D3 RID: 211
	[DllImport("user32.dll")]
	private static extern int ShowWindow(int int_0, int int_1);

	// Token: 0x060000D4 RID: 212
	[DllImport("kernel32.dll")]
	public static extern int GetConsoleWindow();

	// Token: 0x060000D5 RID: 213 RVA: 0x0000A5F0 File Offset: 0x000087F0
	private bool method_0()
	{
		int num = Class1.FindWindow(null, "protectorwindow");
		bool result;
		if (num > 0)
		{
			result = false;
		}
		else
		{
			this.string_0 = "protectorwindow";
			result = true;
		}
		return result;
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0000A624 File Offset: 0x00008824
	private bool method_1()
	{
		Process[] processes = Process.GetProcesses();
		foreach (Process process in processes)
		{
			if (!string.IsNullOrEmpty(process.MainWindowTitle))
			{
				string mainWindowTitle = process.MainWindowTitle;
				string text = mainWindowTitle.ToLower();
				string value = "dump";
				bool result;
				if (!text.Contains(value))
				{
					string value2 = "microsoft sp";
					if (!text.Contains(value2))
					{
						string value3 = "memory v";
						if (!text.Contains(value3))
						{
							string value4 = "ilspy";
							if (!text.Contains(value4))
							{
								string value5 = "x32dbg";
								if (!text.Contains(value5))
								{
									string value6 = "sharpod";
									if (!text.Contains(value6))
									{
										string value7 = "x64dbg";
										if (!text.Contains(value7))
										{
											string value8 = "x32_dbg";
											if (!text.Contains(value8))
											{
												string value9 = "x64_dbg";
												if (!text.Contains(value9))
												{
													string value10 = "strongod";
													if (!text.Contains(value10))
													{
														string value11 = "titanHide";
														if (!text.Contains(value11))
														{
															string value12 = "scyllaHide";
															if (!text.Contains(value12))
															{
																string value13 = "graywolf";
																if (!text.Contains(value13))
																{
																	string value14 = "X64netdumper";
																	if (!text.Contains(value14))
																	{
																		string value15 = "megadumper";
																		if (!text.Contains(value15))
																		{
																			string value16 = "simple assem";
																			if (!text.Contains(value16))
																			{
																				string value17 = "ollydbg";
																				if (!text.Contains(value17))
																				{
																					string value18 = "ida pr";
																					if (!text.Contains(value18))
																					{
																						string value19 = "charles";
																						if (!text.Contains(value19))
																						{
																							string value20 = "dnspy";
																							if (!text.Contains(value20))
																							{
																								string value21 = "httpanalyzer";
																								if (!text.Contains(value21))
																								{
																									string value22 = "httpdebug";
																									if (!text.Contains(value22))
																									{
																										string value23 = "fiddler";
																										if (!text.Contains(value23))
																										{
																											string value24 = "wireshark";
																											if (!text.Contains(value24))
																											{
																												string value25 = "proxifier";
																												if (!text.Contains(value25))
																												{
																													string value26 = "mitmproxy";
																													if (!text.Contains(value26))
																													{
																														string value27 = "system expl";
																														if (!text.Contains(value27))
																														{
																															string value28 = "wpe p";
																															if (!text.Contains(value28))
																															{
																																string value29 = "ghidra";
																																if (!text.Contains(value29))
																																{
																																	string value30 = "windbg";
																																	if (!text.Contains(value30))
																																	{
																																		string value31 = "dbgclr";
																																		if (!text.Contains(value31))
																																		{
																																			string value32 = "Susmdbtend";
																																			if (!text.Contains(value32))
																																			{
																																				string value33 = "poopengine";
																																				if (!text.Contains(value33))
																																				{
																																					string value34 = "lua script";
																																					if (!text.Contains(value34))
																																					{
																																						string value35 = "ue4";
																																						if (!text.Contains(value35))
																																						{
																																							string value36 = "tersafe";
																																							if (!text.Contains(value36))
																																							{
																																								string value37 = "resource mo";
																																								if (!text.Contains(value37))
																																								{
																																									string value38 = "wazer";
																																									if (!text.Contains(value38))
																																									{
																																										string value39 = "crack";
																																										if (!text.Contains(value39))
																																										{
																																											goto IL_36D;
																																										}
																																										Class1.api_0.ban();
																																										this.string_0 = "crack";
																																										result = true;
																																									}
																																									else
																																									{
																																										Class1.api_0.ban();
																																										this.string_0 = "wazer";
																																										result = true;
																																									}
																																								}
																																								else
																																								{
																																									Class1.api_0.ban();
																																									this.string_0 = "resourcemonitor";
																																									result = true;
																																								}
																																							}
																																							else
																																							{
																																								Class1.api_0.ban();
																																								this.string_0 = "tersafe";
																																								result = true;
																																							}
																																						}
																																						else
																																						{
																																							Class1.api_0.ban();
																																							this.string_0 = "ue4";
																																							result = true;
																																						}
																																					}
																																					else
																																					{
																																						Class1.api_0.ban();
																																						this.string_0 = "luascript";
																																						result = true;
																																					}
																																				}
																																				else
																																				{
																																					Class1.api_0.ban();
																																					this.string_0 = "poopengine";
																																					result = true;
																																				}
																																			}
																																			else
																																			{
																																				Class1.api_0.ban();
																																				this.string_0 = "mdb";
																																				result = true;
																																			}
																																		}
																																		else
																																		{
																																			Class1.api_0.ban();
																																			this.string_0 = "dbgclr";
																																			result = true;
																																		}
																																	}
																																	else
																																	{
																																		Class1.api_0.ban();
																																		this.string_0 = "windbg";
																																		result = true;
																																	}
																																}
																																else
																																{
																																	Class1.api_0.ban();
																																	this.string_0 = "ghidra";
																																	result = true;
																																}
																															}
																															else
																															{
																																Class1.api_0.ban();
																																this.string_0 = "wpepro";
																																result = true;
																															}
																														}
																														else
																														{
																															Class1.api_0.ban();
																															this.string_0 = "explorer";
																															result = true;
																														}
																													}
																													else
																													{
																														Class1.api_0.ban();
																														this.string_0 = "mitmproxy";
																														result = true;
																													}
																												}
																												else
																												{
																													Class1.api_0.ban();
																													this.string_0 = "proxifier";
																													result = true;
																												}
																											}
																											else
																											{
																												Class1.api_0.ban();
																												this.string_0 = "wireshark";
																												result = true;
																											}
																										}
																										else
																										{
																											Class1.api_0.ban();
																											this.string_0 = "fiddler";
																											result = true;
																										}
																									}
																									else
																									{
																										Class1.api_0.ban();
																										this.string_0 = "httpdebug";
																										result = true;
																									}
																								}
																								else
																								{
																									Class1.api_0.ban();
																									this.string_0 = "httpanalyzer";
																									result = true;
																								}
																							}
																							else
																							{
																								Class1.api_0.ban();
																								this.string_0 = "dnspy";
																								result = true;
																							}
																						}
																						else
																						{
																							Class1.api_0.ban();
																							this.string_0 = "charles";
																							result = true;
																						}
																					}
																					else
																					{
																						Class1.api_0.ban();
																						this.string_0 = "ida";
																						result = true;
																					}
																				}
																				else
																				{
																					Class1.api_0.ban();
																					this.string_0 = "x32dbg";
																					result = true;
																				}
																			}
																			else
																			{
																				Class1.api_0.ban();
																				this.string_0 = "simpleassemblyexplorer";
																				result = true;
																			}
																		}
																		else
																		{
																			Class1.api_0.ban();
																			this.string_0 = "megadumper";
																			result = true;
																		}
																	}
																	else
																	{
																		Class1.api_0.ban();
																		this.string_0 = "X64netdumper";
																		result = true;
																	}
																}
																else
																{
																	Class1.api_0.ban();
																	this.string_0 = "graywolf";
																	result = true;
																}
															}
															else
															{
																Class1.api_0.ban();
																this.string_0 = "scyllaHide";
																result = true;
															}
														}
														else
														{
															Class1.api_0.ban();
															this.string_0 = "titanHide";
															result = true;
														}
													}
													else
													{
														Class1.api_0.ban();
														this.string_0 = "strongod";
														result = true;
													}
												}
												else
												{
													Class1.api_0.ban();
													this.string_0 = "x64_dbg";
													result = true;
												}
											}
											else
											{
												Class1.api_0.ban();
												this.string_0 = "x32dbg";
												result = true;
											}
										}
										else
										{
											Class1.api_0.ban();
											this.string_0 = "x64dbg";
											result = true;
										}
									}
									else
									{
										Class1.api_0.ban();
										this.string_0 = "sharpod";
										result = true;
									}
								}
								else
								{
									Class1.api_0.ban();
									this.string_0 = "x32dbg";
									result = true;
								}
							}
							else
							{
								Class1.api_0.ban();
								this.string_0 = "ilspy";
								result = true;
							}
						}
						else
						{
							Class1.api_0.ban();
							this.string_0 = "memory";
							result = true;
						}
					}
					else
					{
						Class1.api_0.ban();
						this.string_0 = "microsoftsp";
						result = true;
					}
				}
				else
				{
					Class1.api_0.ban();
					this.string_0 = "dump";
					result = true;
				}
				return result;
			}
			IL_36D:;
		}
		int num = Class1.FindWindow("#By 666 CH....", null);
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "Moded Process Hacker";
			return true;
		}
		num = Class1.FindWindow("#Window", "Jonas Blue");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "Moded Process Hacker";
			return true;
		}
		num = Class1.FindWindow("Window", "Memory Viewer");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "Memory";
			return true;
		}
		num = Class1.FindWindow("ProcessHacker", null);
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "ProcessHacker";
			return true;
		}
		num = Class1.FindWindow("Window", "Referenced Strings");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "Window";
			return true;
		}
		num = Class1.FindWindow("32770", "API Monitor: Memory Editor");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "API Monitor: Memory Editor";
			return true;
		}
		num = Class1.FindWindow("Qt5QWindowIcon", "x32dbg");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "x32dbg";
			return true;
		}
		num = Class1.FindWindow("ConsoleWindowClass", "Command Prompt");
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "ProcessHacker";
			return true;
		}
		num = Class1.FindWindow("Window", null);
		if (num > 0)
		{
			Class1.api_0.ban();
			this.string_0 = "Cheat Engine";
			return true;
		}
		return false;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0000AFD0 File Offset: 0x000091D0
	public void method_2()
	{
		Class1.smethod_0("attrib -h -s -r C:\\Windows\\OK.exe");
		if (File.Exists("C:\\Windows\\OK.exe"))
		{
			Class1.smethod_0("del C:\\Windows\\OK.exe");
		}
		Thread.Sleep(500);
		if (!File.Exists("C:\\Windows\\OK.exe"))
		{
			File.WriteAllBytes("C:\\Windows\\OK.exe", Resources.Service);
		}
		Class1.smethod_0("start C:\\Windows\\OK.exe");
		Class1.smethod_0("attrib +h +s +r C:\\Windows\\OK.exe");
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x0000B040 File Offset: 0x00009240
	public void method_3()
	{
		Class1.api_0.init();
		if (!Class1.api_0.response.success)
		{
			MessageBox.Show(Class1.api_0.response.message);
			Environment.Exit(0);
		}
		if (File.Exists("C:\\SUPERMANBP.lic"))
		{
			string key = File.ReadAllText("C:\\SUPERMANBP.lic");
			Class1.api_0.license(key);
			if (Class1.api_0.response.success)
			{
				string a = Class1.api_0.var("25x6hr-027bafe8de3c8fce586f169f20c0a17995b4d543");
				if (a != "fj8hqk-027bafe8de3c8fce586f169f20c0a17995b4d543")
				{
					Thread.Sleep(100);
					Environment.Exit(0);
				}
			}
			else
			{
				Environment.Exit(0);
			}
		}
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000B0F0 File Offset: 0x000092F0
	public void method_4()
	{
		Thread thread = new Thread(new ThreadStart(this.method_2));
		thread.Start();
		for (;;)
		{
			Thread.Sleep(8000);
			if (this.method_0())
			{
				Class1.api_0.log(this.string_0);
				Environment.Exit(0);
			}
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x0000B144 File Offset: 0x00009344
	public void method_5()
	{
		for (;;)
		{
			Thread.Sleep(3000);
			if (this.method_1())
			{
				Class1.api_0.log(this.string_0);
				Environment.Exit(0);
			}
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x0000B180 File Offset: 0x00009380
	public static string smethod_0(string string_1)
	{
		Process process = new Process();
		process.StartInfo = new ProcessStartInfo
		{
			WindowStyle = ProcessWindowStyle.Hidden,
			CreateNoWindow = true,
			UseShellExecute = false,
			RedirectStandardOutput = true,
			FileName = Environment.GetFolderPath(Environment.SpecialFolder.SystemX86) + "\\cmd.exe",
			Arguments = "/c " + string_1
		};
		process.Start();
		string result = process.StandardOutput.ReadToEnd();
		process.WaitForExit();
		return result;
	}

	// Token: 0x040000F1 RID: 241
	public static api api_0 = new api("SUPERMAN VIP BYPSS", "USbQL4vvgs", "42481645084f970749793ae84a27b71f6c8711717fc47bc2a8c4e06e9732ac5b", "1.5");

	// Token: 0x040000F2 RID: 242
	private string string_0 = "";
}
