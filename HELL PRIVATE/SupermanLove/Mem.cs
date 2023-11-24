using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SupermanLove
{
	// Token: 0x02000003 RID: 3
	public class Mem
	{
		// Token: 0x06000009 RID: 9
		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

		// Token: 0x0600000A RID: 10
		[DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx")]
		public static extern UIntPtr VirtualQueryEx_1(IntPtr hProcess, UIntPtr lpAddress, out Mem.MEMORY_BASIC_INFORMATION32 lpBuffer, UIntPtr dwLength);

		// Token: 0x0600000B RID: 11
		[DllImport("kernel32.dll", EntryPoint = "VirtualQueryEx")]
		public static extern UIntPtr VirtualQueryEx_2(IntPtr hProcess, UIntPtr lpAddress, out Mem.MEMORY_BASIC_INFORMATION64 lpBuffer, UIntPtr dwLength);

		// Token: 0x0600000C RID: 12
		[DllImport("kernel32.dll")]
		private static extern uint GetLastError();

		// Token: 0x0600000D RID: 13 RVA: 0x00002B70 File Offset: 0x00000D70
		public UIntPtr VirtualQueryEx(IntPtr hProcess, UIntPtr lpAddress, out Mem.MEMORY_BASIC_INFORMATION lpBuffer)
		{
			UIntPtr result;
			if (!this.Is64Bit && IntPtr.Size != 8)
			{
				Mem.MEMORY_BASIC_INFORMATION32 memory_BASIC_INFORMATION = default(Mem.MEMORY_BASIC_INFORMATION32);
				UIntPtr uintPtr = Mem.VirtualQueryEx_1(hProcess, lpAddress, out memory_BASIC_INFORMATION, new UIntPtr((uint)Marshal.SizeOf<Mem.MEMORY_BASIC_INFORMATION32>(memory_BASIC_INFORMATION)));
				lpBuffer.BaseAddress = memory_BASIC_INFORMATION.BaseAddress;
				lpBuffer.AllocationBase = memory_BASIC_INFORMATION.AllocationBase;
				lpBuffer.AllocationProtect = memory_BASIC_INFORMATION.AllocationProtect;
				lpBuffer.RegionSize = (long)((ulong)memory_BASIC_INFORMATION.RegionSize);
				lpBuffer.State = memory_BASIC_INFORMATION.State;
				lpBuffer.Protect = memory_BASIC_INFORMATION.Protect;
				lpBuffer.Type = memory_BASIC_INFORMATION.Type;
				result = uintPtr;
			}
			else
			{
				Mem.MEMORY_BASIC_INFORMATION64 memory_BASIC_INFORMATION2 = default(Mem.MEMORY_BASIC_INFORMATION64);
				UIntPtr uintPtr = Mem.VirtualQueryEx_2(hProcess, lpAddress, out memory_BASIC_INFORMATION2, new UIntPtr((uint)Marshal.SizeOf<Mem.MEMORY_BASIC_INFORMATION64>(memory_BASIC_INFORMATION2)));
				lpBuffer.BaseAddress = memory_BASIC_INFORMATION2.BaseAddress;
				lpBuffer.AllocationBase = memory_BASIC_INFORMATION2.AllocationBase;
				lpBuffer.AllocationProtect = memory_BASIC_INFORMATION2.AllocationProtect;
				lpBuffer.RegionSize = (long)memory_BASIC_INFORMATION2.RegionSize;
				lpBuffer.State = memory_BASIC_INFORMATION2.State;
				lpBuffer.Protect = memory_BASIC_INFORMATION2.Protect;
				lpBuffer.Type = memory_BASIC_INFORMATION2.Type;
				result = uintPtr;
			}
			return result;
		}

		// Token: 0x0600000E RID: 14
		[DllImport("kernel32.dll")]
		private static extern void GetSystemInfo(out Mem.SYSTEM_INFO system_INFO_0);

		// Token: 0x0600000F RID: 15
		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenThread(Mem.ThreadAccess threadAccess_0, bool bool_1, uint uint_2);

		// Token: 0x06000010 RID: 16
		[DllImport("kernel32.dll")]
		private static extern uint SuspendThread(IntPtr intptr_0);

		// Token: 0x06000011 RID: 17
		[DllImport("kernel32.dll")]
		private static extern int ResumeThread(IntPtr intptr_0);

		// Token: 0x06000012 RID: 18
		[DllImport("dbghelp.dll")]
		private static extern bool MiniDumpWriteDump(IntPtr intptr_0, int int_0, IntPtr intptr_1, Mem.Enum0 enum0_0, IntPtr intptr_2, IntPtr intptr_3, IntPtr intptr_4);

		// Token: 0x06000013 RID: 19
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetWindowLong(IntPtr intptr_0, int int_0);

		// Token: 0x06000014 RID: 20
		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);

		// Token: 0x06000015 RID: 21
		[DllImport("kernel32.dll")]
		private static extern bool WriteProcessMemory(IntPtr intptr_0, UIntPtr uintptr_0, string string_1, UIntPtr uintptr_1, out IntPtr intptr_1);

		// Token: 0x06000016 RID: 22
		[DllImport("kernel32.dll")]
		private static extern int GetProcessId(IntPtr intptr_0);

		// Token: 0x06000017 RID: 23
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private static extern uint GetPrivateProfileString(string string_1, string string_2, string string_3, StringBuilder stringBuilder_0, uint uint_2, string string_4);

		// Token: 0x06000018 RID: 24
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern bool VirtualFreeEx(IntPtr intptr_0, UIntPtr uintptr_0, UIntPtr uintptr_1, uint uint_2);

		// Token: 0x06000019 RID: 25
		[DllImport("kernel32.dll")]
		private static extern bool ReadProcessMemory(IntPtr intptr_0, UIntPtr uintptr_0, [Out] byte[] byte_0, UIntPtr uintptr_1, IntPtr intptr_1);

		// Token: 0x0600001A RID: 26
		[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		private static extern bool ReadProcessMemory_1(IntPtr intptr_0, UIntPtr uintptr_0, [Out] byte[] byte_0, UIntPtr uintptr_1, out ulong ulong_0);

		// Token: 0x0600001B RID: 27
		[DllImport("kernel32.dll", EntryPoint = "ReadProcessMemory")]
		private static extern bool ReadProcessMemory_2(IntPtr intptr_0, UIntPtr uintptr_0, [Out] IntPtr intptr_1, UIntPtr uintptr_1, out ulong ulong_0);

		// Token: 0x0600001C RID: 28
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern UIntPtr VirtualAllocEx(IntPtr intptr_0, UIntPtr uintptr_0, uint uint_2, uint uint_3, uint uint_4);

		// Token: 0x0600001D RID: 29
		[DllImport("kernel32.dll")]
		private static extern bool VirtualProtectEx(IntPtr intptr_0, UIntPtr uintptr_0, IntPtr intptr_1, Mem.MemoryProtection memoryProtection_0, out Mem.MemoryProtection memoryProtection_1);

		// Token: 0x0600001E RID: 30
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
		public static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);

		// Token: 0x0600001F RID: 31
		[DllImport("kernel32.dll", EntryPoint = "CloseHandle")]
		private static extern bool CloseHandle_1(IntPtr intptr_0);

		// Token: 0x06000020 RID: 32
		[DllImport("kernel32.dll")]
		public static extern int CloseHandle(IntPtr hObject);

		// Token: 0x06000021 RID: 33
		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x06000022 RID: 34
		[DllImport("kernel32", ExactSpelling = true, SetLastError = true)]
		internal static extern int WaitForSingleObject(IntPtr intptr_0, int int_0);

		// Token: 0x06000023 RID: 35
		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern bool WriteProcessMemory_1(IntPtr intptr_0, UIntPtr uintptr_0, byte[] byte_0, UIntPtr uintptr_1, IntPtr intptr_1);

		// Token: 0x06000024 RID: 36
		[DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
		private static extern bool WriteProcessMemory_2(IntPtr intptr_0, UIntPtr uintptr_0, byte[] byte_0, UIntPtr uintptr_1, out IntPtr intptr_1);

		// Token: 0x06000025 RID: 37
		[DllImport("kernel32")]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, UIntPtr lpStartAddress, UIntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

		// Token: 0x06000026 RID: 38
		[DllImport("kernel32")]
		public static extern bool IsWow64Process(IntPtr hProcess, out bool lpSystemInfo);

		// Token: 0x06000027 RID: 39
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr intptr_0);

		// Token: 0x06000028 RID: 40 RVA: 0x00002C80 File Offset: 0x00000E80
		private bool method_0(string string_1)
		{
			foreach (char c in string_1)
			{
				if (c < '0' || c > '9')
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00002CC0 File Offset: 0x00000EC0
		public void FreezeValue(string address, string type, string value, string file = "")
		{
			Mem.<>c__DisplayClass56_0 CS$<>8__locals1 = new Mem.<>c__DisplayClass56_0();
			CS$<>8__locals1.mem_0 = this;
			CS$<>8__locals1.string_0 = address;
			CS$<>8__locals1.string_1 = type;
			CS$<>8__locals1.string_2 = value;
			CS$<>8__locals1.string_3 = file;
			CS$<>8__locals1.cancellationTokenSource_0 = new CancellationTokenSource();
			if (this.dictionary_0.ContainsKey(CS$<>8__locals1.string_0))
			{
				try
				{
					this.dictionary_0[CS$<>8__locals1.string_0].Cancel();
					this.dictionary_0.Remove(CS$<>8__locals1.string_0);
				}
				catch
				{
				}
			}
			this.dictionary_0.Add(CS$<>8__locals1.string_0, CS$<>8__locals1.cancellationTokenSource_0);
			Task.Factory.StartNew(new Action(CS$<>8__locals1.method_0), CS$<>8__locals1.cancellationTokenSource_0.Token);
		}

		// Token: 0x0600002A RID: 42 RVA: 0x00002D8C File Offset: 0x00000F8C
		public void UnfreezeValue(string address)
		{
			try
			{
				this.dictionary_0[address].Cancel();
				this.dictionary_0.Remove(address);
			}
			catch
			{
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x00002DCC File Offset: 0x00000FCC
		public bool OpenProcess(int pid)
		{
			if (!this.IsAdmin())
			{
			}
			bool result;
			if (pid <= 0)
			{
				result = false;
			}
			else if (this.theProc != null && this.theProc.Id == pid)
			{
				result = true;
			}
			else
			{
				try
				{
					this.theProc = Process.GetProcessById(pid);
					if (this.theProc != null && !this.theProc.Responding)
					{
						result = false;
					}
					else
					{
						this.pHandle = Mem.OpenProcess(2035711U, true, pid);
						Process.EnterDebugMode();
						if (this.pHandle == IntPtr.Zero)
						{
							Marshal.GetLastWin32Error();
							Process.LeaveDebugMode();
							this.theProc = null;
							result = false;
						}
						else
						{
							this.processModule_0 = this.theProc.MainModule;
							this.GetModules();
							bool flag;
							this.Is64Bit = (Environment.Is64BitOperatingSystem && Mem.IsWow64Process(this.pHandle, out flag) && !flag);
							result = true;
						}
					}
				}
				catch
				{
					result = false;
				}
			}
			return result;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00002ED8 File Offset: 0x000010D8
		public bool OpenProcess(string proc)
		{
			return this.OpenProcess(this.GetProcIdFromName(proc));
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00002EF4 File Offset: 0x000010F4
		public bool IsAdmin()
		{
			bool result;
			using (WindowsIdentity current = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
				result = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			return result;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00002F38 File Offset: 0x00001138
		// (set) Token: 0x0600002F RID: 47 RVA: 0x00002285 File Offset: 0x00000485
		public bool Is64Bit
		{
			get
			{
				return this.bool_0;
			}
			private set
			{
				this.bool_0 = value;
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002F4C File Offset: 0x0000114C
		public void GetModules()
		{
			if (this.theProc != null)
			{
				this.modules.Clear();
				foreach (object obj in this.theProc.Modules)
				{
					ProcessModule processModule = (ProcessModule)obj;
					if (!string.IsNullOrEmpty(processModule.ModuleName) && !this.modules.ContainsKey(processModule.ModuleName))
					{
						this.modules.Add(processModule.ModuleName, processModule.BaseAddress);
					}
				}
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x0000228E File Offset: 0x0000048E
		public void SetFocus()
		{
			Mem.SetForegroundWindow(this.theProc.MainWindowHandle);
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002FFC File Offset: 0x000011FC
		public int GetProcIdFromName(string name)
		{
			Process[] processes = Process.GetProcesses();
			if (name.ToLower().Contains(".exe"))
			{
				name = name.Replace(".exe", "");
			}
			if (name.ToLower().Contains(".bin"))
			{
				name = name.Replace(".bin", "");
			}
			foreach (Process process in processes)
			{
				if (process.ProcessName.Equals(name, StringComparison.CurrentCultureIgnoreCase))
				{
					return process.Id;
				}
			}
			return 0;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00003094 File Offset: 0x00001294
		public string LoadCode(string name, string file)
		{
			StringBuilder stringBuilder = new StringBuilder(1024);
			if (file != "")
			{
				Mem.GetPrivateProfileString("codes", name, "", stringBuilder, (uint)stringBuilder.Capacity, file);
			}
			else
			{
				stringBuilder.Append(name);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000034 RID: 52 RVA: 0x000030E4 File Offset: 0x000012E4
		private int method_1(string string_1, string string_2)
		{
			int result;
			try
			{
				int num = Convert.ToInt32(this.LoadCode(string_1, string_2), 16);
				if (num >= 0)
				{
					result = num;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00003128 File Offset: 0x00001328
		public void ThreadStartClient(string func, string name)
		{
			using (NamedPipeClientStream namedPipeClientStream = new NamedPipeClientStream(name))
			{
				if (!namedPipeClientStream.IsConnected)
				{
					namedPipeClientStream.Connect();
				}
				using (StreamWriter streamWriter = new StreamWriter(namedPipeClientStream))
				{
					if (!streamWriter.AutoFlush)
					{
						streamWriter.AutoFlush = true;
					}
					streamWriter.WriteLine(func);
				}
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x000031A4 File Offset: 0x000013A4
		public string CutString(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if (c < ' ' || c > '~')
				{
					break;
				}
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000031F4 File Offset: 0x000013F4
		public string SanitizeString(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in str)
			{
				if (c >= ' ' && c <= '~')
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00003244 File Offset: 0x00001444
		public bool ChangeProtection(string code, Mem.MemoryProtection newProtection, out Mem.MemoryProtection oldProtection, string file = "")
		{
			UIntPtr code2 = this.GetCode(code, file, 8);
			bool result;
			if (!(code2 == UIntPtr.Zero) && !(this.pHandle == IntPtr.Zero))
			{
				result = Mem.VirtualProtectEx(this.pHandle, code2, (IntPtr)(this.Is64Bit ? 8 : 4), newProtection, out oldProtection);
			}
			else
			{
				oldProtection = (Mem.MemoryProtection)0U;
				result = false;
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000032A4 File Offset: 0x000014A4
		public byte[] ReadBytes(string code, long length, string file = "")
		{
			byte[] array = new byte[length];
			UIntPtr code2 = this.GetCode(code, file, 8);
			byte[] result;
			if (!Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)((ulong)length), IntPtr.Zero))
			{
				result = null;
			}
			else
			{
				result = array;
			}
			return result;
		}

		// Token: 0x0600003A RID: 58 RVA: 0x000032E8 File Offset: 0x000014E8
		public float ReadFloat(string code, string file = "", bool round = true)
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			float result;
			try
			{
				if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)4UL, IntPtr.Zero))
				{
					float num = BitConverter.ToSingle(array, 0);
					float num2 = num;
					if (round)
					{
						num2 = (float)Math.Round((double)num, 2);
					}
					result = num2;
				}
				else
				{
					result = 0f;
				}
			}
			catch
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00003370 File Offset: 0x00001570
		public string ReadString(string code, string file = "", int length = 32, bool zeroTerminated = true)
		{
			byte[] array = new byte[length];
			UIntPtr code2 = this.GetCode(code, file, 8);
			string result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)((ulong)((long)length)), IntPtr.Zero))
			{
				result = (zeroTerminated ? Encoding.UTF8.GetString(array).Split(new char[1])[0] : Encoding.UTF8.GetString(array));
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x000033DC File Offset: 0x000015DC
		public double ReadDouble(string code, string file = "", bool round = true)
		{
			byte[] array = new byte[8];
			UIntPtr code2 = this.GetCode(code, file, 8);
			double result;
			try
			{
				if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)8UL, IntPtr.Zero))
				{
					double num = BitConverter.ToDouble(array, 0);
					double num2 = num;
					if (round)
					{
						num2 = Math.Round(num, 2);
					}
					result = num2;
				}
				else
				{
					result = 0.0;
				}
			}
			catch
			{
				result = 0.0;
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00003468 File Offset: 0x00001668
		public int method_2(UIntPtr code)
		{
			byte[] array = new byte[4];
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, code, array, (UIntPtr)4UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000034AC File Offset: 0x000016AC
		public int ReadInt(string code, string file = "")
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)4UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x000034FC File Offset: 0x000016FC
		public long ReadLong(string code, string file = "")
		{
			byte[] array = new byte[16];
			UIntPtr code2 = this.GetCode(code, file, 8);
			long result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)16UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt64(array, 0);
			}
			else
			{
				result = 0L;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00003554 File Offset: 0x00001754
		public ulong ReadUInt(string code, string file = "")
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			ulong result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)4UL, IntPtr.Zero))
			{
				result = BitConverter.ToUInt64(array, 0);
			}
			else
			{
				result = 0UL;
			}
			return result;
		}

		// Token: 0x06000041 RID: 65 RVA: 0x000035AC File Offset: 0x000017AC
		public int Read2ByteMove(string code, int moveQty, string file = "")
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			UIntPtr uintptr_ = UIntPtr.Add(code2, moveQty);
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, uintptr_, array, (UIntPtr)2UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00003604 File Offset: 0x00001804
		public int ReadIntMove(string code, int moveQty, string file = "")
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			UIntPtr uintptr_ = UIntPtr.Add(code2, moveQty);
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, uintptr_, array, (UIntPtr)4UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x0000365C File Offset: 0x0000185C
		public ulong ReadUIntMove(string code, int moveQty, string file = "")
		{
			byte[] array = new byte[8];
			UIntPtr code2 = this.GetCode(code, file, 8);
			UIntPtr uintptr_ = UIntPtr.Add(code2, moveQty);
			ulong result;
			if (Mem.ReadProcessMemory(this.pHandle, uintptr_, array, (UIntPtr)8UL, IntPtr.Zero))
			{
				result = BitConverter.ToUInt64(array, 0);
			}
			else
			{
				result = 0UL;
			}
			return result;
		}

		// Token: 0x06000044 RID: 68 RVA: 0x000036BC File Offset: 0x000018BC
		public int method_3(string code, string file = "")
		{
			byte[] array = new byte[4];
			UIntPtr code2 = this.GetCode(code, file, 8);
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)2UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000045 RID: 69 RVA: 0x0000370C File Offset: 0x0000190C
		public int ReadByte(string code, string file = "")
		{
			byte[] array = new byte[1];
			UIntPtr code2 = this.GetCode(code, file, 8);
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)1UL, IntPtr.Zero))
			{
				result = (int)array[0];
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00003758 File Offset: 0x00001958
		public bool[] ReadBits(string code, string file = "")
		{
			byte[] array = new byte[1];
			UIntPtr code2 = this.GetCode(code, file, 8);
			bool[] array2 = new bool[8];
			bool[] result;
			if (!Mem.ReadProcessMemory(this.pHandle, code2, array, (UIntPtr)1UL, IntPtr.Zero))
			{
				result = array2;
			}
			else
			{
				if (!BitConverter.IsLittleEndian)
				{
					throw new Exception("Should be little endian");
				}
				for (int i = 0; i < 8; i++)
				{
					array2[i] = Convert.ToBoolean((int)array[0] & 1 << i);
				}
				result = array2;
			}
			return result;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x000037E8 File Offset: 0x000019E8
		public int method_4(UIntPtr address, string code, string file = "")
		{
			byte[] array = new byte[4];
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, address + this.method_1(code, file), array, (UIntPtr)1UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00003838 File Offset: 0x00001A38
		public float method_5(UIntPtr address, string code, string file = "")
		{
			byte[] array = new byte[4];
			float result;
			if (Mem.ReadProcessMemory(this.pHandle, address + this.method_1(code, file), array, (UIntPtr)4UL, IntPtr.Zero))
			{
				float num = BitConverter.ToSingle(array, 0);
				result = (float)Math.Round((double)num, 2);
			}
			else
			{
				result = 0f;
			}
			return result;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00003898 File Offset: 0x00001A98
		public int ReadPInt(UIntPtr address, string code, string file = "")
		{
			byte[] array = new byte[4];
			int result;
			if (Mem.ReadProcessMemory(this.pHandle, address + this.method_1(code, file), array, (UIntPtr)4UL, IntPtr.Zero))
			{
				result = BitConverter.ToInt32(array, 0);
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x000038E8 File Offset: 0x00001AE8
		public string method_6(UIntPtr address, string code, string file = "")
		{
			byte[] array = new byte[32];
			string result;
			if (Mem.ReadProcessMemory(this.pHandle, address + this.method_1(code, file), array, (UIntPtr)32UL, IntPtr.Zero))
			{
				result = this.CutString(Encoding.ASCII.GetString(array));
			}
			else
			{
				result = "";
			}
			return result;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00003948 File Offset: 0x00001B48
		public bool WriteMemory(string code, string type, string write, string file = "", Encoding stringEncoding = null)
		{
			byte[] array = new byte[4];
			int num = 4;
			UIntPtr code2 = this.GetCode(code, file, 8);
			if (type.ToLower() == "float")
			{
				array = BitConverter.GetBytes(Convert.ToSingle(write));
				num = 4;
			}
			else if (type.ToLower() == "int")
			{
				array = BitConverter.GetBytes(Convert.ToInt32(write));
				num = 4;
			}
			else if (type.ToLower() == "byte")
			{
				array = new byte[]
				{
					Convert.ToByte(write, 16)
				};
				num = 1;
			}
			else if (type.ToLower() == "2bytes")
			{
				array = new byte[]
				{
					(byte)(Convert.ToInt32(write) % 256),
					(byte)(Convert.ToInt32(write) / 256)
				};
				num = 2;
			}
			else if (type.ToLower() == "bytes")
			{
				if (!write.Contains(",") && !write.Contains(" "))
				{
					array = new byte[]
					{
						Convert.ToByte(write, 16)
					};
					num = 1;
				}
				else
				{
					string[] array2;
					if (write.Contains(","))
					{
						array2 = write.Split(new char[]
						{
							','
						});
					}
					else
					{
						array2 = write.Split(new char[]
						{
							' '
						});
					}
					int num2 = array2.Count<string>();
					array = new byte[num2];
					for (int i = 0; i < num2; i++)
					{
						array[i] = Convert.ToByte(array2[i], 16);
					}
					num = array2.Count<string>();
				}
			}
			else if (type.ToLower() == "double")
			{
				array = BitConverter.GetBytes(Convert.ToDouble(write));
				num = 8;
			}
			else if (type.ToLower() == "long")
			{
				array = BitConverter.GetBytes(Convert.ToInt64(write));
				num = 8;
			}
			else if (type.ToLower() == "string")
			{
				if (stringEncoding == null)
				{
					array = Encoding.UTF8.GetBytes(write);
				}
				else
				{
					array = stringEncoding.GetBytes(write);
				}
				num = array.Length;
			}
			return Mem.WriteProcessMemory_1(this.pHandle, code2, array, (UIntPtr)((ulong)((long)num)), IntPtr.Zero);
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00003B6C File Offset: 0x00001D6C
		public bool WriteMove(string code, string type, string write, int moveQty, string file = "")
		{
			byte[] byte_ = new byte[4];
			int num = 4;
			UIntPtr code2 = this.GetCode(code, file, 8);
			if (type == "float")
			{
				byte_ = new byte[write.Length];
				byte_ = BitConverter.GetBytes(Convert.ToSingle(write));
				num = write.Length;
			}
			else if (type == "int")
			{
				byte_ = BitConverter.GetBytes(Convert.ToInt32(write));
				num = 4;
			}
			else if (type == "double")
			{
				byte_ = BitConverter.GetBytes(Convert.ToDouble(write));
				num = 8;
			}
			else if (type == "long")
			{
				byte_ = BitConverter.GetBytes(Convert.ToInt64(write));
				num = 8;
			}
			else if (type == "byte")
			{
				byte_ = new byte[]
				{
					Convert.ToByte(write, 16)
				};
				num = 1;
			}
			else if (type == "string")
			{
				byte_ = new byte[write.Length];
				byte_ = Encoding.UTF8.GetBytes(write);
				num = write.Length;
			}
			UIntPtr uintptr_ = UIntPtr.Add(code2, moveQty);
			Thread.Sleep(1000);
			return Mem.WriteProcessMemory_1(this.pHandle, uintptr_, byte_, (UIntPtr)((ulong)((long)num)), IntPtr.Zero);
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00003C94 File Offset: 0x00001E94
		public void WriteBytes(string code, byte[] write, string file = "")
		{
			UIntPtr code2 = this.GetCode(code, file, 8);
			Mem.WriteProcessMemory_1(this.pHandle, code2, write, (UIntPtr)((ulong)((long)write.Length)), IntPtr.Zero);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00003CC8 File Offset: 0x00001EC8
		public void WriteBits(string code, bool[] bits, string file = "")
		{
			if (bits.Length != 8)
			{
				throw new ArgumentException("Not enough bits for a whole byte", "bits");
			}
			byte[] array = new byte[1];
			UIntPtr code2 = this.GetCode(code, file, 8);
			for (int i = 0; i < 8; i++)
			{
				if (bits[i])
				{
					byte[] array2 = array;
					int num = 0;
					array2[num] |= (byte)(1 << i);
				}
			}
			Mem.WriteProcessMemory_1(this.pHandle, code2, array, (UIntPtr)1UL, IntPtr.Zero);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00003D48 File Offset: 0x00001F48
		public void WriteBytes(UIntPtr address, byte[] write)
		{
			IntPtr intPtr;
			Mem.WriteProcessMemory_2(this.pHandle, address, write, (UIntPtr)((ulong)((long)write.Length)), out intPtr);
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00003D70 File Offset: 0x00001F70
		public UIntPtr GetCode(string name, string path = "", int size = 8)
		{
			UIntPtr result;
			if (this.Is64Bit)
			{
				if (size == 8)
				{
					size = 16;
				}
				result = this.Get64BitCode(name, path, size);
			}
			else
			{
				string text;
				if (path != "")
				{
					text = this.LoadCode(name, path);
				}
				else
				{
					text = name;
				}
				if (text == "")
				{
					result = UIntPtr.Zero;
				}
				else
				{
					if (text.Contains(" "))
					{
						text.Replace(" ", string.Empty);
					}
					if (!text.Contains("+") && !text.Contains(","))
					{
						result = new UIntPtr(Convert.ToUInt32(text, 16));
					}
					else
					{
						string text2 = text;
						if (text.Contains("+"))
						{
							text2 = text.Substring(text.IndexOf('+') + 1);
						}
						byte[] array = new byte[size];
						if (text2.Contains(','))
						{
							List<int> list = new List<int>();
							string[] array2 = text2.Split(new char[]
							{
								','
							});
							foreach (string text3 in array2)
							{
								string text4 = text3;
								if (text3.Contains("0x"))
								{
									text4 = text3.Replace("0x", "");
								}
								int num;
								if (!text3.Contains("-"))
								{
									num = int.Parse(text4, NumberStyles.AllowHexSpecifier);
								}
								else
								{
									text4 = text4.Replace("-", "");
									num = int.Parse(text4, NumberStyles.AllowHexSpecifier);
									num *= -1;
								}
								list.Add(num);
							}
							int[] array4 = list.ToArray();
							if (!text.Contains("base") && !text.Contains("main"))
							{
								if (!text.Contains("base") && !text.Contains("main") && text.Contains("+"))
								{
									string[] array5 = text.Split(new char[]
									{
										'+'
									});
									IntPtr value = IntPtr.Zero;
									if (!array5[0].ToLower().Contains(".dll") && !array5[0].ToLower().Contains(".exe") && !array5[0].ToLower().Contains(".bin"))
									{
										string text5 = array5[0];
										if (text5.Contains("0x"))
										{
											text5 = text5.Replace("0x", "");
										}
										value = (IntPtr)int.Parse(text5, NumberStyles.HexNumber);
									}
									else
									{
										try
										{
											value = this.modules[array5[0]];
										}
										catch
										{
										}
									}
									Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)((long)((int)value + array4[0]))), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
								}
								else
								{
									Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)((long)array4[0])), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
								}
							}
							else
							{
								Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)((long)((int)this.processModule_0.BaseAddress + array4[0]))), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
							}
							uint num2 = BitConverter.ToUInt32(array, 0);
							UIntPtr uintPtr = (UIntPtr)0UL;
							for (int j = 1; j < array4.Length; j++)
							{
								uintPtr = new UIntPtr(Convert.ToUInt32((long)((ulong)num2 + (ulong)((long)array4[j]))));
								Mem.ReadProcessMemory(this.pHandle, uintPtr, array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
								num2 = BitConverter.ToUInt32(array, 0);
							}
							result = uintPtr;
						}
						else
						{
							int num3 = Convert.ToInt32(text2, 16);
							IntPtr value2 = IntPtr.Zero;
							if (!text.ToLower().Contains("base") && !text.ToLower().Contains("main"))
							{
								if (!text.ToLower().Contains("base") && !text.ToLower().Contains("main") && text.Contains("+"))
								{
									string[] array6 = text.Split(new char[]
									{
										'+'
									});
									if (!array6[0].ToLower().Contains(".dll") && !array6[0].ToLower().Contains(".exe") && !array6[0].ToLower().Contains(".bin"))
									{
										string text6 = array6[0];
										if (text6.Contains("0x"))
										{
											text6 = text6.Replace("0x", "");
										}
										value2 = (IntPtr)int.Parse(text6, NumberStyles.HexNumber);
										goto IL_4E0;
									}
									try
									{
										value2 = this.modules[array6[0]];
										goto IL_4E0;
									}
									catch
									{
										goto IL_4E0;
									}
								}
								value2 = this.modules[text.Split(new char[]
								{
									'+'
								})[0]];
							}
							else
							{
								value2 = this.processModule_0.BaseAddress;
							}
							IL_4E0:
							result = (UIntPtr)((ulong)((long)((int)value2 + num3)));
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00004290 File Offset: 0x00002490
		public UIntPtr Get64BitCode(string name, string path = "", int size = 16)
		{
			string text;
			if (path != "")
			{
				text = this.LoadCode(name, path);
			}
			else
			{
				text = name;
			}
			UIntPtr result;
			if (text == "")
			{
				result = UIntPtr.Zero;
			}
			else
			{
				if (text.Contains(" "))
				{
					text.Replace(" ", string.Empty);
				}
				string text2 = text;
				if (text.Contains("+"))
				{
					text2 = text.Substring(text.IndexOf('+') + 1);
				}
				byte[] array = new byte[size];
				if (!text.Contains("+") && !text.Contains(","))
				{
					result = new UIntPtr(Convert.ToUInt64(text, 16));
				}
				else if (text2.Contains(','))
				{
					List<long> list = new List<long>();
					string[] array2 = text2.Split(new char[]
					{
						','
					});
					foreach (string text3 in array2)
					{
						string text4 = text3;
						if (text3.Contains("0x"))
						{
							text4 = text3.Replace("0x", "");
						}
						long num;
						if (!text3.Contains("-"))
						{
							num = long.Parse(text4, NumberStyles.AllowHexSpecifier);
						}
						else
						{
							text4 = text4.Replace("-", "");
							num = long.Parse(text4, NumberStyles.AllowHexSpecifier);
							num *= -1L;
						}
						list.Add(num);
					}
					long[] array4 = list.ToArray();
					if (!text.Contains("base") && !text.Contains("main"))
					{
						if (!text.Contains("base") && !text.Contains("main") && text.Contains("+"))
						{
							string[] array5 = text.Split(new char[]
							{
								'+'
							});
							IntPtr value = IntPtr.Zero;
							if (!array5[0].ToLower().Contains(".dll") && !array5[0].ToLower().Contains(".exe") && !array5[0].ToLower().Contains(".bin"))
							{
								value = (IntPtr)long.Parse(array5[0], NumberStyles.HexNumber);
							}
							else
							{
								try
								{
									value = this.modules[array5[0]];
								}
								catch
								{
								}
							}
							Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)((long)value + array4[0])), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
						}
						else
						{
							Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)array4[0]), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
						}
					}
					else
					{
						Mem.ReadProcessMemory(this.pHandle, (UIntPtr)((ulong)((long)this.processModule_0.BaseAddress + array4[0])), array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
					}
					long num2 = BitConverter.ToInt64(array, 0);
					UIntPtr uintPtr = (UIntPtr)0UL;
					for (int j = 1; j < array4.Length; j++)
					{
						uintPtr = new UIntPtr(Convert.ToUInt64(num2 + array4[j]));
						Mem.ReadProcessMemory(this.pHandle, uintPtr, array, (UIntPtr)((ulong)((long)size)), IntPtr.Zero);
						num2 = BitConverter.ToInt64(array, 0);
					}
					result = uintPtr;
				}
				else
				{
					long num3 = Convert.ToInt64(text2, 16);
					IntPtr value2 = IntPtr.Zero;
					if (!text.Contains("base") && !text.Contains("main"))
					{
						if (!text.Contains("base") && !text.Contains("main") && text.Contains("+"))
						{
							string[] array6 = text.Split(new char[]
							{
								'+'
							});
							if (!array6[0].ToLower().Contains(".dll") && !array6[0].ToLower().Contains(".exe") && !array6[0].ToLower().Contains(".bin"))
							{
								string text5 = array6[0];
								if (text5.Contains("0x"))
								{
									text5 = text5.Replace("0x", "");
								}
								value2 = (IntPtr)long.Parse(text5, NumberStyles.HexNumber);
								goto IL_490;
							}
							try
							{
								value2 = this.modules[array6[0]];
								goto IL_490;
							}
							catch
							{
								goto IL_490;
							}
						}
						value2 = this.modules[text.Split(new char[]
						{
							'+'
						})[0]];
					}
					else
					{
						value2 = this.processModule_0.BaseAddress;
					}
					IL_490:
					result = (UIntPtr)((ulong)((long)value2 + num3));
				}
			}
			return result;
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000475C File Offset: 0x0000295C
		public void CloseProcess()
		{
			Mem.CloseHandle(this.pHandle);
			this.theProc = null;
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000477C File Offset: 0x0000297C
		public void InjectDll(string strDllName)
		{
			foreach (object obj in this.theProc.Modules)
			{
				ProcessModule processModule = (ProcessModule)obj;
				if (processModule.ModuleName.StartsWith("inject", StringComparison.InvariantCultureIgnoreCase))
				{
					return;
				}
			}
			if (this.theProc.Responding)
			{
				int num = strDllName.Length + 1;
				UIntPtr uintPtr = Mem.VirtualAllocEx(this.pHandle, (UIntPtr)null, (uint)num, 12288U, 4U);
				IntPtr intPtr;
				Mem.WriteProcessMemory(this.pHandle, uintPtr, strDllName, (UIntPtr)((ulong)((long)num)), out intPtr);
				UIntPtr procAddress = Mem.GetProcAddress(Mem.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
				IntPtr intPtr2 = Mem.CreateRemoteThread(this.pHandle, (IntPtr)null, 0U, procAddress, uintPtr, 0U, out intPtr);
				int num2 = Mem.WaitForSingleObject(intPtr2, 10000);
				if ((long)num2 != 128L && (long)num2 != 258L)
				{
					Mem.VirtualFreeEx(this.pHandle, uintPtr, (UIntPtr)0UL, 32768U);
					Mem.CloseHandle(intPtr2);
				}
				else
				{
					Mem.CloseHandle(intPtr2);
				}
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x000048D0 File Offset: 0x00002AD0
		public UIntPtr CreateCodeCave(string code, byte[] newBytes, int replaceCount, int size = 4096, string file = "")
		{
			UIntPtr result;
			if (replaceCount < 5)
			{
				result = UIntPtr.Zero;
			}
			else
			{
				UIntPtr code2 = this.GetCode(code, file, 8);
				UIntPtr uintPtr = code2;
				UIntPtr uintPtr2 = UIntPtr.Zero;
				UIntPtr uintPtr3 = uintPtr;
				int num = 0;
				while (num < 10 && uintPtr2 == UIntPtr.Zero)
				{
					uintPtr2 = Mem.VirtualAllocEx(this.pHandle, this.method_7(uintPtr3, (uint)size), (uint)size, 12288U, 64U);
					if (uintPtr2 == UIntPtr.Zero)
					{
						uintPtr3 = UIntPtr.Add(uintPtr3, 65536);
					}
					num++;
				}
				if (uintPtr2 == UIntPtr.Zero)
				{
					uintPtr2 = Mem.VirtualAllocEx(this.pHandle, UIntPtr.Zero, (uint)size, 12288U, 64U);
				}
				int num2 = (replaceCount > 5) ? (replaceCount - 5) : 0;
				int value = (int)((ulong)uintPtr2 - (ulong)uintPtr - 5UL);
				byte[] array = new byte[5 + num2];
				array[0] = 233;
				BitConverter.GetBytes(value).CopyTo(array, 1);
				for (int i = 5; i < array.Length; i++)
				{
					array[i] = 144;
				}
				this.WriteBytes(uintPtr, array);
				byte[] array2 = new byte[5 + newBytes.Length];
				value = (int)((ulong)uintPtr + (ulong)((long)array.Length) - ((ulong)uintPtr2 + (ulong)((long)newBytes.Length)) - 5UL);
				newBytes.CopyTo(array2, 0);
				array2[newBytes.Length] = 233;
				BitConverter.GetBytes(value).CopyTo(array2, newBytes.Length + 1);
				this.WriteBytes(uintPtr2, array2);
				result = uintPtr2;
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x00004A58 File Offset: 0x00002C58
		private UIntPtr method_7(UIntPtr uintptr_0, uint uint_2)
		{
			UIntPtr uintPtr = UIntPtr.Subtract(uintptr_0, 1879048192);
			UIntPtr value = UIntPtr.Add(uintptr_0, 1879048192);
			UIntPtr uintPtr2 = UIntPtr.Zero;
			UIntPtr uintPtr3 = UIntPtr.Zero;
			Mem.SYSTEM_INFO system_INFO;
			Mem.GetSystemInfo(out system_INFO);
			if (this.Is64Bit)
			{
				if ((ulong)uintPtr > (ulong)system_INFO.maximumApplicationAddress || (ulong)uintPtr < (ulong)system_INFO.minimumApplicationAddress)
				{
					uintPtr = system_INFO.minimumApplicationAddress;
				}
				if ((ulong)value < (ulong)system_INFO.minimumApplicationAddress || (ulong)value > (ulong)system_INFO.maximumApplicationAddress)
				{
					value = system_INFO.maximumApplicationAddress;
				}
			}
			else
			{
				uintPtr = system_INFO.minimumApplicationAddress;
				value = system_INFO.maximumApplicationAddress;
			}
			UIntPtr uintPtr4 = uintPtr;
			Mem.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION;
			while (this.VirtualQueryEx(this.pHandle, uintPtr4, out memory_BASIC_INFORMATION).ToUInt64() > 0UL)
			{
				UIntPtr result;
				if ((ulong)memory_BASIC_INFORMATION.BaseAddress <= (ulong)value)
				{
					if (memory_BASIC_INFORMATION.State == 65536U && memory_BASIC_INFORMATION.RegionSize > (long)((ulong)uint_2))
					{
						if ((ulong)memory_BASIC_INFORMATION.BaseAddress % (ulong)system_INFO.allocationGranularity > 0UL)
						{
							uintPtr3 = memory_BASIC_INFORMATION.BaseAddress;
							int num = (int)((ulong)system_INFO.allocationGranularity - (ulong)uintPtr3 % (ulong)system_INFO.allocationGranularity);
							if (memory_BASIC_INFORMATION.RegionSize - (long)num >= (long)((ulong)uint_2))
							{
								uintPtr3 = UIntPtr.Add(uintPtr3, num);
								if ((ulong)uintPtr3 < (ulong)uintptr_0)
								{
									uintPtr3 = UIntPtr.Add(uintPtr3, (int)(memory_BASIC_INFORMATION.RegionSize - (long)num - (long)((ulong)uint_2)));
									if ((ulong)uintPtr3 > (ulong)uintptr_0)
									{
										uintPtr3 = uintptr_0;
									}
									uintPtr3 = UIntPtr.Subtract(uintPtr3, (int)((ulong)uintPtr3 % (ulong)system_INFO.allocationGranularity));
								}
								if (Math.Abs((long)((ulong)uintPtr3 - (ulong)uintptr_0)) < Math.Abs((long)((ulong)uintPtr2 - (ulong)uintptr_0)))
								{
									uintPtr2 = uintPtr3;
								}
							}
						}
						else
						{
							uintPtr3 = memory_BASIC_INFORMATION.BaseAddress;
							if ((ulong)uintPtr3 < (ulong)uintptr_0)
							{
								uintPtr3 = UIntPtr.Add(uintPtr3, (int)(memory_BASIC_INFORMATION.RegionSize - (long)((ulong)uint_2)));
								if ((ulong)uintPtr3 > (ulong)uintptr_0)
								{
									uintPtr3 = uintptr_0;
								}
								uintPtr3 = UIntPtr.Subtract(uintPtr3, (int)((ulong)uintPtr3 % (ulong)system_INFO.allocationGranularity));
							}
							if (Math.Abs((long)((ulong)uintPtr3 - (ulong)uintptr_0)) < Math.Abs((long)((ulong)uintPtr2 - (ulong)uintptr_0)))
							{
								uintPtr2 = uintPtr3;
							}
						}
					}
					if (memory_BASIC_INFORMATION.RegionSize % (long)((ulong)system_INFO.allocationGranularity) > 0L)
					{
						memory_BASIC_INFORMATION.RegionSize += (long)((ulong)system_INFO.allocationGranularity - (ulong)(memory_BASIC_INFORMATION.RegionSize % (long)((ulong)system_INFO.allocationGranularity)));
					}
					UIntPtr value2 = uintPtr4;
					uintPtr4 = UIntPtr.Add(memory_BASIC_INFORMATION.BaseAddress, (int)memory_BASIC_INFORMATION.RegionSize);
					if ((ulong)uintPtr4 <= (ulong)value)
					{
						if ((ulong)value2 <= (ulong)uintPtr4)
						{
							continue;
						}
						result = uintPtr2;
					}
					else
					{
						result = uintPtr2;
					}
				}
				else
				{
					result = UIntPtr.Zero;
				}
				return result;
			}
			return uintPtr2;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x00004D78 File Offset: 0x00002F78
		public static void SuspendProcess(int pid)
		{
			Process processById = Process.GetProcessById(pid);
			if (!(processById.ProcessName == string.Empty))
			{
				foreach (object obj in processById.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					IntPtr intPtr = Mem.OpenThread(Mem.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
					if (!(intPtr == IntPtr.Zero))
					{
						Mem.SuspendThread(intPtr);
						Mem.CloseHandle(intPtr);
					}
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00004E14 File Offset: 0x00003014
		public static void ResumeProcess(int pid)
		{
			Process processById = Process.GetProcessById(pid);
			if (!(processById.ProcessName == string.Empty))
			{
				foreach (object obj in processById.Threads)
				{
					ProcessThread processThread = (ProcessThread)obj;
					IntPtr intPtr = Mem.OpenThread(Mem.ThreadAccess.SUSPEND_RESUME, false, (uint)processThread.Id);
					if (!(intPtr == IntPtr.Zero))
					{
						int num;
						do
						{
							num = Mem.ResumeThread(intPtr);
						}
						while (num > 0);
						Mem.CloseHandle(intPtr);
					}
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00004EBC File Offset: 0x000030BC
		private Task method_8(int int_0)
		{
			Mem.<PutTaskDelay>d__109 <PutTaskDelay>d__ = new Mem.<PutTaskDelay>d__109();
			<PutTaskDelay>d__.<>t__builder = AsyncTaskMethodBuilder.Create();
			<PutTaskDelay>d__.<>4__this = this;
			<PutTaskDelay>d__.delay = int_0;
			<PutTaskDelay>d__.<>1__state = -1;
			<PutTaskDelay>d__.<>t__builder.Start<Mem.<PutTaskDelay>d__109>(ref <PutTaskDelay>d__);
			return <PutTaskDelay>d__.<>t__builder.Task;
		}

		// Token: 0x06000059 RID: 89 RVA: 0x00004F08 File Offset: 0x00003108
		private void method_9(string string_1, byte[] byte_0)
		{
			using (FileStream fileStream = new FileStream(string_1, FileMode.Append))
			{
				fileStream.Write(byte_0, 0, byte_0.Length);
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x00004F44 File Offset: 0x00003144
		public byte[] FileToBytes(string path, bool dontDelete = false)
		{
			byte[] result = File.ReadAllBytes(path);
			if (!dontDelete)
			{
				File.Delete(path);
			}
			return result;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x00004F68 File Offset: 0x00003168
		public string MSize()
		{
			string result;
			if (this.Is64Bit)
			{
				result = "x16";
			}
			else
			{
				result = "x8";
			}
			return result;
		}

		// Token: 0x0600005C RID: 92 RVA: 0x00004F8C File Offset: 0x0000318C
		public static string ByteArrayToHexString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			int num = 1;
			foreach (byte b in ba)
			{
				if (num == 16)
				{
					stringBuilder.AppendFormat("{0:x2}{1}", b, Environment.NewLine);
					num = 0;
				}
				else
				{
					stringBuilder.AppendFormat("{0:x2} ", b);
				}
				num++;
			}
			return stringBuilder.ToString().ToUpper();
		}

		// Token: 0x0600005D RID: 93 RVA: 0x00005004 File Offset: 0x00003204
		public static string ByteArrayToString(byte[] ba)
		{
			StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
			foreach (byte b in ba)
			{
				stringBuilder.AppendFormat("{0:x2} ", b);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000504C File Offset: 0x0000324C
		public ulong GetMinAddress()
		{
			Mem.SYSTEM_INFO system_INFO;
			Mem.GetSystemInfo(out system_INFO);
			return (ulong)system_INFO.minimumApplicationAddress;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x00005070 File Offset: 0x00003270
		public bool DumpMemory(string file = "dump.dmp")
		{
			Mem.SYSTEM_INFO system_INFO = default(Mem.SYSTEM_INFO);
			Mem.GetSystemInfo(out system_INFO);
			UIntPtr minimumApplicationAddress = system_INFO.minimumApplicationAddress;
			long num = (long)((ulong)minimumApplicationAddress);
			long num2 = this.theProc.VirtualMemorySize64 + num;
			if (File.Exists(file))
			{
				File.Delete(file);
			}
			Mem.MEMORY_BASIC_INFORMATION memory_BASIC_INFORMATION = default(Mem.MEMORY_BASIC_INFORMATION);
			while (num < num2)
			{
				this.VirtualQueryEx(this.pHandle, minimumApplicationAddress, out memory_BASIC_INFORMATION);
				byte[] byte_ = new byte[memory_BASIC_INFORMATION.RegionSize];
				UIntPtr uintptr_ = (UIntPtr)((ulong)memory_BASIC_INFORMATION.RegionSize);
				UIntPtr uintptr_2 = (UIntPtr)((ulong)memory_BASIC_INFORMATION.BaseAddress);
				Mem.ReadProcessMemory(this.pHandle, uintptr_2, byte_, uintptr_, IntPtr.Zero);
				this.method_9(file, byte_);
				num += memory_BASIC_INFORMATION.RegionSize;
				minimumApplicationAddress = new UIntPtr((ulong)num);
			}
			return true;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000513C File Offset: 0x0000333C
		public Task<IEnumerable<long>> AoBScan(string search, bool writable = false, bool executable = true, string file = "")
		{
			return this.AoBScan(0L, long.MaxValue, search, writable, executable, file);
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00005168 File Offset: 0x00003368
		public Task<IEnumerable<long>> AoBScan(string search, bool readable, bool writable, bool executable, string file = "")
		{
			return this.AoBScan(0L, long.MaxValue, search, readable, writable, executable, file);
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00005198 File Offset: 0x00003398
		public Task<IEnumerable<long>> AoBScan(long start, long end, string search, bool writable = false, bool executable = true, string file = "")
		{
			return this.AoBScan(start, end, search, true, writable, executable, file);
		}

		// Token: 0x06000063 RID: 99 RVA: 0x000051B8 File Offset: 0x000033B8
		private string method_10(string string_1)
		{
			string_1 = string_1.Replace(" ", "+");
			try
			{
				byte[] array = Convert.FromBase64String(string_1);
				using (Aes aes = Aes.Create())
				{
					Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(this.string_0, new byte[]
					{
						73,
						118,
						97,
						110,
						32,
						77,
						101,
						100,
						118,
						101,
						100,
						101,
						118
					});
					if (aes != null)
					{
						aes.Key = rfc2898DeriveBytes.GetBytes(32);
						aes.IV = rfc2898DeriveBytes.GetBytes(16);
						using (MemoryStream memoryStream = new MemoryStream())
						{
							using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
							{
								cryptoStream.Write(array, 0, array.Length);
								cryptoStream.Close();
							}
							memoryStream.ToArray();
							string_1 = Encoding.Unicode.GetString(memoryStream.ToArray());
						}
					}
				}
			}
			catch (Exception)
			{
				return string.Empty;
			}
			return string_1;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x000052D8 File Offset: 0x000034D8
		public Task<IEnumerable<long>> AoBScan(long start, long end, string search, bool readable, bool writable, bool executable, string file = "")
		{
			Mem.<>c__DisplayClass125_0 CS$<>8__locals1 = new Mem.<>c__DisplayClass125_0();
			CS$<>8__locals1.mem_0 = this;
			CS$<>8__locals1.string_0 = search;
			CS$<>8__locals1.string_1 = file;
			CS$<>8__locals1.long_0 = start;
			CS$<>8__locals1.long_1 = end;
			CS$<>8__locals1.bool_0 = readable;
			CS$<>8__locals1.bool_1 = writable;
			CS$<>8__locals1.bool_2 = executable;
			return Task.Run<IEnumerable<long>>(new Func<IEnumerable<long>>(CS$<>8__locals1.method_0));
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000533C File Offset: 0x0000353C
		public Task<long> AoBScan(string code, long end, string search, string file = "")
		{
			Mem.<AoBScan>d__126 <AoBScan>d__ = new Mem.<AoBScan>d__126();
			<AoBScan>d__.<>t__builder = AsyncTaskMethodBuilder<long>.Create();
			<AoBScan>d__.<>4__this = this;
			<AoBScan>d__.code = code;
			<AoBScan>d__.end = end;
			<AoBScan>d__.search = search;
			<AoBScan>d__.file = file;
			<AoBScan>d__.<>1__state = -1;
			<AoBScan>d__.<>t__builder.Start<Mem.<AoBScan>d__126>(ref <AoBScan>d__);
			return <AoBScan>d__.<>t__builder.Task;
		}

		// Token: 0x06000066 RID: 102 RVA: 0x000053A0 File Offset: 0x000035A0
		private unsafe long[] method_11(Struct0 struct0_0, byte[] byte_0, byte[] byte_1)
		{
			if (byte_1.Length != byte_0.Length)
			{
				throw new ArgumentException("aobPattern.Length != mask.Length");
			}
			IntPtr intPtr = Marshal.AllocHGlobal((int)struct0_0.method_2());
			ulong num;
			Mem.ReadProcessMemory_2(this.pHandle, struct0_0.method_0(), intPtr, (UIntPtr)((ulong)struct0_0.method_2()), out num);
			int num2 = 0 - byte_0.Length;
			List<long> list = new List<long>();
			do
			{
				num2 = this.method_13((byte*)intPtr.ToPointer(), (int)num, byte_0, byte_1, num2 + byte_0.Length);
				if (num2 >= 0)
				{
					list.Add((long)((ulong)struct0_0.method_0() + (ulong)((long)num2)));
				}
			}
			while (num2 != -1);
			Marshal.FreeHGlobal(intPtr);
			return list.ToArray();
		}

		// Token: 0x06000067 RID: 103 RVA: 0x00005458 File Offset: 0x00003658
		private int method_12(byte[] byte_0, byte[] byte_1, byte[] byte_2, int int_0 = 0)
		{
			int result = -1;
			if (byte_0.Length != 0 && byte_1.Length != 0 && int_0 <= byte_0.Length - byte_1.Length && byte_1.Length <= byte_0.Length)
			{
				for (int i = int_0; i <= byte_0.Length - byte_1.Length; i++)
				{
					if ((byte_0[i] & byte_2[0]) == (byte_1[0] & byte_2[0]))
					{
						bool flag = true;
						int j = 1;
						while (j <= byte_1.Length - 1)
						{
							if ((byte_0[i + j] & byte_2[j]) == (byte_1[j] & byte_2[j]))
							{
								j++;
							}
							else
							{
								flag = false;
								IL_75:
								if (!flag)
								{
									goto IL_7C;
								}
								result = i;
								goto IL_93;
							}
						}
						goto IL_75;
						IL_93:
						return result;
					}
					IL_7C:;
				}
				goto IL_93;
			}
			return result;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00005500 File Offset: 0x00003700
		private unsafe int method_13(byte* pByte_0, int int_0, byte[] byte_0, byte[] byte_1, int int_1 = 0)
		{
			int result = -1;
			if (int_0 > 0 && byte_0.Length != 0 && int_1 <= int_0 - byte_0.Length && byte_0.Length <= int_0)
			{
				for (int i = int_1; i <= int_0 - byte_0.Length; i++)
				{
					if ((pByte_0[i] & byte_1[0]) == (byte_0[0] & byte_1[0]))
					{
						bool flag = true;
						int j = 1;
						while (j <= byte_0.Length - 1)
						{
							if ((pByte_0[i + j] & byte_1[j]) == (byte_0[j] & byte_1[j]))
							{
								j++;
							}
							else
							{
								flag = false;
								IL_77:
								if (!flag)
								{
									goto IL_7E;
								}
								result = i;
								goto IL_93;
							}
						}
						goto IL_77;
						IL_93:
						return result;
					}
					IL_7E:;
				}
				goto IL_93;
			}
			return result;
		}

		// Token: 0x04000005 RID: 5
		private string string_0 = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		// Token: 0x04000006 RID: 6
		private uint uint_0 = 131072U;

		// Token: 0x04000007 RID: 7
		private uint uint_1 = 16777216U;

		// Token: 0x04000008 RID: 8
		public IntPtr pHandle;

		// Token: 0x04000009 RID: 9
		private Dictionary<string, CancellationTokenSource> dictionary_0 = new Dictionary<string, CancellationTokenSource>();

		// Token: 0x0400000A RID: 10
		public Process theProc = null;

		// Token: 0x0400000B RID: 11
		private bool bool_0;

		// Token: 0x0400000C RID: 12
		public Dictionary<string, IntPtr> modules = new Dictionary<string, IntPtr>();

		// Token: 0x0400000D RID: 13
		private ProcessModule processModule_0;

		// Token: 0x02000004 RID: 4
		internal enum Enum0
		{

		}

		// Token: 0x02000005 RID: 5
		[Flags]
		public enum MemoryProtection : uint
		{
			// Token: 0x04000010 RID: 16
			Execute = 16U,
			// Token: 0x04000011 RID: 17
			ExecuteRead = 32U,
			// Token: 0x04000012 RID: 18
			ExecuteReadWrite = 64U,
			// Token: 0x04000013 RID: 19
			ExecuteWriteCopy = 128U,
			// Token: 0x04000014 RID: 20
			NoAccess = 1U,
			// Token: 0x04000015 RID: 21
			ReadOnly = 2U,
			// Token: 0x04000016 RID: 22
			ReadWrite = 4U,
			// Token: 0x04000017 RID: 23
			WriteCopy = 8U,
			// Token: 0x04000018 RID: 24
			GuardModifierflag = 256U,
			// Token: 0x04000019 RID: 25
			NoCacheModifierflag = 512U,
			// Token: 0x0400001A RID: 26
			WriteCombineModifierflag = 1024U
		}

		// Token: 0x02000006 RID: 6
		[Flags]
		public enum ThreadAccess
		{
			// Token: 0x0400001C RID: 28
			TERMINATE = 1,
			// Token: 0x0400001D RID: 29
			SUSPEND_RESUME = 2,
			// Token: 0x0400001E RID: 30
			GET_CONTEXT = 8,
			// Token: 0x0400001F RID: 31
			SET_CONTEXT = 16,
			// Token: 0x04000020 RID: 32
			SET_INFORMATION = 32,
			// Token: 0x04000021 RID: 33
			QUERY_INFORMATION = 64,
			// Token: 0x04000022 RID: 34
			SET_THREAD_TOKEN = 128,
			// Token: 0x04000023 RID: 35
			IMPERSONATE = 256,
			// Token: 0x04000024 RID: 36
			DIRECT_IMPERSONATION = 512
		}

		// Token: 0x02000007 RID: 7
		public struct SYSTEM_INFO
		{
			// Token: 0x04000025 RID: 37
			public ushort processorArchitecture;

			// Token: 0x04000026 RID: 38
			private ushort ushort_0;

			// Token: 0x04000027 RID: 39
			public uint pageSize;

			// Token: 0x04000028 RID: 40
			public UIntPtr minimumApplicationAddress;

			// Token: 0x04000029 RID: 41
			public UIntPtr maximumApplicationAddress;

			// Token: 0x0400002A RID: 42
			public IntPtr activeProcessorMask;

			// Token: 0x0400002B RID: 43
			public uint numberOfProcessors;

			// Token: 0x0400002C RID: 44
			public uint processorType;

			// Token: 0x0400002D RID: 45
			public uint allocationGranularity;

			// Token: 0x0400002E RID: 46
			public ushort processorLevel;

			// Token: 0x0400002F RID: 47
			public ushort processorRevision;
		}

		// Token: 0x02000008 RID: 8
		public struct MEMORY_BASIC_INFORMATION32
		{
			// Token: 0x04000030 RID: 48
			public UIntPtr BaseAddress;

			// Token: 0x04000031 RID: 49
			public UIntPtr AllocationBase;

			// Token: 0x04000032 RID: 50
			public uint AllocationProtect;

			// Token: 0x04000033 RID: 51
			public uint RegionSize;

			// Token: 0x04000034 RID: 52
			public uint State;

			// Token: 0x04000035 RID: 53
			public uint Protect;

			// Token: 0x04000036 RID: 54
			public uint Type;
		}

		// Token: 0x02000009 RID: 9
		public struct MEMORY_BASIC_INFORMATION64
		{
			// Token: 0x04000037 RID: 55
			public UIntPtr BaseAddress;

			// Token: 0x04000038 RID: 56
			public UIntPtr AllocationBase;

			// Token: 0x04000039 RID: 57
			public uint AllocationProtect;

			// Token: 0x0400003A RID: 58
			public uint __alignment1;

			// Token: 0x0400003B RID: 59
			public ulong RegionSize;

			// Token: 0x0400003C RID: 60
			public uint State;

			// Token: 0x0400003D RID: 61
			public uint Protect;

			// Token: 0x0400003E RID: 62
			public uint Type;

			// Token: 0x0400003F RID: 63
			public uint __alignment2;
		}

		// Token: 0x0200000A RID: 10
		public struct MEMORY_BASIC_INFORMATION
		{
			// Token: 0x04000040 RID: 64
			public UIntPtr BaseAddress;

			// Token: 0x04000041 RID: 65
			public UIntPtr AllocationBase;

			// Token: 0x04000042 RID: 66
			public uint AllocationProtect;

			// Token: 0x04000043 RID: 67
			public long RegionSize;

			// Token: 0x04000044 RID: 68
			public uint State;

			// Token: 0x04000045 RID: 69
			public uint Protect;

			// Token: 0x04000046 RID: 70
			public uint Type;
		}
	}
}
