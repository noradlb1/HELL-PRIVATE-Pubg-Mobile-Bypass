using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000021 RID: 33
	public class api
	{
		// Token: 0x060000EC RID: 236 RVA: 0x0000B39C File Offset: 0x0000959C
		public api(string name, string ownerid, string secret, string version)
		{
			if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ownerid) || string.IsNullOrWhiteSpace(secret) || string.IsNullOrWhiteSpace(version))
			{
				api.error("Application not setup correctly. Please watch video link found in Program.cs");
				Environment.Exit(0);
			}
			this.name = name;
			this.ownerid = ownerid;
			this.secret = secret;
			this.version = version;
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000B430 File Offset: 0x00009630
		public void init()
		{
			this.string_1 = encryption.sha256(encryption.iv_key());
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("init"));
			nameValueCollection["ver"] = encryption.encrypt(this.version, this.secret, text);
			nameValueCollection["hash"] = api.checksum(Process.GetCurrentProcess().MainModule.FileName);
			nameValueCollection["enckey"] = encryption.encrypt(this.string_1, this.secret, text);
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			if (text2 == "KeyAuth_Invalid")
			{
				api.error("Application not found");
				Environment.Exit(0);
			}
			text2 = encryption.decrypt(text2, this.secret, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			if (@class.Boolean_0)
			{
				this.method_0(@class.Class4_0);
				this.string_0 = @class.sessionid;
				this.bool_0 = true;
			}
			else if (@class.message == "invalidver")
			{
				this.app_data.downloadLink = @class.String_1;
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x060000EE RID: 238 RVA: 0x0000B5B4 File Offset: 0x000097B4
		public static bool IsDebugRelease
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000B5C4 File Offset: 0x000097C4
		public void Checkinit()
		{
			if (!this.bool_0)
			{
				api.error("Please initialize first");
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000B5E8 File Offset: 0x000097E8
		public void register(string username, string pass, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("register"));
			nameValueCollection["username"] = encryption.encrypt(username, this.string_1, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.string_1, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.string_1, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			if (@class.Boolean_0)
			{
				this.method_1(@class.Class3_0);
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000B748 File Offset: 0x00009948
		public void login(string username, string pass)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("login"));
			nameValueCollection["username"] = encryption.encrypt(username, this.string_1, text);
			nameValueCollection["pass"] = encryption.encrypt(pass, this.string_1, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			if (@class.Boolean_0)
			{
				this.method_1(@class.Class3_0);
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000B890 File Offset: 0x00009A90
		public void upgrade(string username, string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("upgrade"));
			nameValueCollection["username"] = encryption.encrypt(username, this.string_1, text);
			nameValueCollection["key"] = encryption.encrypt(key, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			@class.Boolean_0 = false;
			this.method_2(@class);
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000B9B4 File Offset: 0x00009BB4
		public void license(string key)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("license"));
			nameValueCollection["key"] = encryption.encrypt(key, this.string_1, text);
			nameValueCollection["hwid"] = encryption.encrypt(value, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			if (@class.Boolean_0)
			{
				this.method_1(@class.Class3_0);
			}
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000BAE4 File Offset: 0x00009CE4
		public void check()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("check"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 class2_ = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(class2_);
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000BBBC File Offset: 0x00009DBC
		public void setvar(string var, string data)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("setvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.string_1, text);
			nameValueCollection["data"] = encryption.encrypt(data, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 class2_ = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(class2_);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000BCC4 File Offset: 0x00009EC4
		public string getvar(string var)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("getvar"));
			nameValueCollection["var"] = encryption.encrypt(var, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			string result;
			if (@class.Boolean_0)
			{
				result = @class.WmTdAjhpu4;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000BDCC File Offset: 0x00009FCC
		public void ban()
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("ban"));
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 class2_ = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(class2_);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000BEA4 File Offset: 0x0000A0A4
		public string var(string varid)
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("var"));
			nameValueCollection["varid"] = encryption.encrypt(varid, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			string result;
			if (@class.Boolean_0)
			{
				result = @class.message;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000BFC0 File Offset: 0x0000A1C0
		public List<api.msg> chatget(string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatget"));
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			List<api.msg> result;
			if (@class.Boolean_0)
			{
				result = @class.List_0;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000C0C8 File Offset: 0x0000A2C8
		public bool chatsend(string msg, string channelname)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("chatsend"));
			nameValueCollection["message"] = encryption.encrypt(msg, this.string_1, text);
			nameValueCollection["channel"] = encryption.encrypt(channelname, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			return @class.Boolean_0;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000C1E4 File Offset: 0x0000A3E4
		public bool checkblack()
		{
			this.Checkinit();
			string value = WindowsIdentity.GetCurrent().User.Value;
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("checkblacklist"));
			nameValueCollection["hwid"] = encryption.encrypt(value, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			return @class.Boolean_0;
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000C2FC File Offset: 0x0000A4FC
		public string webhook(string webid, string param, string body = "", string conttype = "")
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("webhook"));
			nameValueCollection["webid"] = encryption.encrypt(webid, this.string_1, text);
			nameValueCollection["params"] = encryption.encrypt(param, this.string_1, text);
			nameValueCollection["body"] = encryption.encrypt(body, this.string_1, text);
			nameValueCollection["conttype"] = encryption.encrypt(conttype, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			string result;
			if (@class.Boolean_0)
			{
				result = @class.WmTdAjhpu4;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000C44C File Offset: 0x0000A64C
		public byte[] download(string fileid)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("file"));
			nameValueCollection["fileid"] = encryption.encrypt(fileid, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			string text2 = api.smethod_0(nameValueCollection_);
			text2 = encryption.decrypt(text2, this.string_1, text);
			api.Class2 @class = this.json_wrapper_0.string_to_generic<api.Class2>(text2);
			this.method_2(@class);
			byte[] result;
			if (@class.Boolean_0)
			{
				result = encryption.str_to_byte_arr(@class.String_0);
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000C558 File Offset: 0x0000A758
		public void log(string message)
		{
			this.Checkinit();
			string text = encryption.sha256(encryption.iv_key());
			NameValueCollection nameValueCollection = new NameValueCollection();
			nameValueCollection["type"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes("log"));
			nameValueCollection["pcuser"] = encryption.encrypt(Environment.UserName, this.string_1, text);
			nameValueCollection["message"] = encryption.encrypt(message, this.string_1, text);
			nameValueCollection["sessionid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.string_0));
			nameValueCollection["name"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.name));
			nameValueCollection["ownerid"] = encryption.byte_arr_to_str(Encoding.Default.GetBytes(this.ownerid));
			nameValueCollection["init_iv"] = text;
			NameValueCollection nameValueCollection_ = nameValueCollection;
			api.smethod_0(nameValueCollection_);
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000C644 File Offset: 0x0000A844
		public static string checksum(string filename)
		{
			string result;
			using (MD5 md = MD5.Create())
			{
				using (FileStream fileStream = File.OpenRead(filename))
				{
					byte[] value = md.ComputeHash(fileStream);
					result = BitConverter.ToString(value).Replace("-", "").ToLowerInvariant();
				}
			}
			return result;
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000C6BC File Offset: 0x0000A8BC
		public static void error(string message)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c start cmd /C \"color b && title Error && echo " + message + " && timeout /t 5\"")
			{
				CreateNoWindow = true,
				RedirectStandardOutput = true,
				RedirectStandardError = true,
				UseShellExecute = false
			});
			Environment.Exit(0);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000C70C File Offset: 0x0000A90C
		private static string smethod_0(NameValueCollection nameValueCollection_0)
		{
			string result;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					byte[] bytes = webClient.UploadValues("https://keyauth.win/api/1.0/", nameValueCollection_0);
					result = Encoding.Default.GetString(bytes);
				}
			}
			catch (WebException ex)
			{
				HttpWebResponse httpWebResponse = (HttpWebResponse)ex.Response;
				HttpStatusCode statusCode = httpWebResponse.StatusCode;
				HttpStatusCode httpStatusCode = statusCode;
				if (httpStatusCode != (HttpStatusCode)429)
				{
					api.error("Connection failure. Please try again, or contact us for help.");
					Environment.Exit(0);
					result = "";
				}
				else
				{
					api.error("You're connecting too fast to loader, slow down.");
					Environment.Exit(0);
					result = "";
				}
			}
			return result;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000C7B8 File Offset: 0x0000A9B8
		private void method_0(api.Class4 class4_0)
		{
			this.app_data.numUsers = class4_0.String_0;
			this.app_data.numOnlineUsers = class4_0.String_1;
			this.app_data.numKeys = class4_0.String_2;
			this.app_data.version = class4_0.String_3;
			this.app_data.customerPanelLink = class4_0.String_4;
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000C81C File Offset: 0x0000AA1C
		private void method_1(api.Class3 class3_0)
		{
			this.user_data.username = class3_0.username;
			this.user_data.ip = class3_0.String_0;
			this.user_data.hwid = class3_0.hwid;
			this.user_data.createdate = class3_0.String_1;
			this.user_data.lastlogin = class3_0.String_2;
			this.user_data.subscriptions = class3_0.List_0;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000C890 File Offset: 0x0000AA90
		public string expirydaysleft()
		{
			this.Checkinit();
			DateTime d = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Local);
			d = d.AddSeconds((double)long.Parse(this.user_data.subscriptions[0].expiry)).ToLocalTime();
			TimeSpan timeSpan = d - DateTime.Now;
			return Convert.ToString(timeSpan.Days.ToString() + " Days " + timeSpan.Hours.ToString() + " Hours Left");
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000024A9 File Offset: 0x000006A9
		private void method_2(api.Class2 class2_0)
		{
			this.response.success = class2_0.Boolean_0;
			this.response.message = class2_0.message;
		}

		// Token: 0x040000F6 RID: 246
		public string name;

		// Token: 0x040000F7 RID: 247
		public string ownerid;

		// Token: 0x040000F8 RID: 248
		public string secret;

		// Token: 0x040000F9 RID: 249
		public string version;

		// Token: 0x040000FA RID: 250
		private string string_0;

		// Token: 0x040000FB RID: 251
		private string string_1;

		// Token: 0x040000FC RID: 252
		private bool bool_0;

		// Token: 0x040000FD RID: 253
		public api.app_data_class app_data = new api.app_data_class();

		// Token: 0x040000FE RID: 254
		public api.user_data_class user_data = new api.user_data_class();

		// Token: 0x040000FF RID: 255
		public api.response_class response = new api.response_class();

		// Token: 0x04000100 RID: 256
		private json_wrapper json_wrapper_0 = new json_wrapper(new api.Class2());

		// Token: 0x02000022 RID: 34
		[DataContract]
		private class Class2
		{
			// Token: 0x1700000E RID: 14
			// (get) Token: 0x06000106 RID: 262 RVA: 0x000024CD File Offset: 0x000006CD
			// (set) Token: 0x06000107 RID: 263 RVA: 0x000024D5 File Offset: 0x000006D5
			[DataMember]
			public bool Boolean_0 { get; set; }

			// Token: 0x1700000F RID: 15
			// (get) Token: 0x06000108 RID: 264 RVA: 0x000024DE File Offset: 0x000006DE
			// (set) Token: 0x06000109 RID: 265 RVA: 0x000024E6 File Offset: 0x000006E6
			[DataMember]
			public string sessionid { get; set; }

			// Token: 0x17000010 RID: 16
			// (get) Token: 0x0600010A RID: 266 RVA: 0x000024EF File Offset: 0x000006EF
			// (set) Token: 0x0600010B RID: 267 RVA: 0x000024F7 File Offset: 0x000006F7
			[DataMember]
			public string String_0 { get; set; }

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x0600010C RID: 268 RVA: 0x00002500 File Offset: 0x00000700
			// (set) Token: 0x0600010D RID: 269 RVA: 0x00002508 File Offset: 0x00000708
			[DataMember]
			public string WmTdAjhpu4 { get; set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x0600010E RID: 270 RVA: 0x00002511 File Offset: 0x00000711
			// (set) Token: 0x0600010F RID: 271 RVA: 0x00002519 File Offset: 0x00000719
			[DataMember]
			public string message { get; set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000110 RID: 272 RVA: 0x00002522 File Offset: 0x00000722
			// (set) Token: 0x06000111 RID: 273 RVA: 0x0000252A File Offset: 0x0000072A
			[DataMember]
			public string String_1 { get; set; }

			// Token: 0x17000014 RID: 20
			// (get) Token: 0x06000112 RID: 274 RVA: 0x00002533 File Offset: 0x00000733
			// (set) Token: 0x06000113 RID: 275 RVA: 0x0000253B File Offset: 0x0000073B
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.Class3 Class3_0 { get; set; }

			// Token: 0x17000015 RID: 21
			// (get) Token: 0x06000114 RID: 276 RVA: 0x00002544 File Offset: 0x00000744
			// (set) Token: 0x06000115 RID: 277 RVA: 0x0000254C File Offset: 0x0000074C
			[DataMember(IsRequired = false, EmitDefaultValue = false)]
			public api.Class4 Class4_0 { get; set; }

			// Token: 0x17000016 RID: 22
			// (get) Token: 0x06000116 RID: 278 RVA: 0x00002555 File Offset: 0x00000755
			// (set) Token: 0x06000117 RID: 279 RVA: 0x0000255D File Offset: 0x0000075D
			[DataMember]
			public List<api.msg> List_0 { get; set; }

			// Token: 0x04000101 RID: 257
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x04000102 RID: 258
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000103 RID: 259
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000104 RID: 260
			[CompilerGenerated]
			private string string_2;

			// Token: 0x04000105 RID: 261
			[CompilerGenerated]
			private string string_3;

			// Token: 0x04000106 RID: 262
			[CompilerGenerated]
			private string string_4;

			// Token: 0x04000107 RID: 263
			[CompilerGenerated]
			private api.Class3 class3_0;

			// Token: 0x04000108 RID: 264
			[CompilerGenerated]
			private api.Class4 class4_0;

			// Token: 0x04000109 RID: 265
			[CompilerGenerated]
			private List<api.msg> list_0;
		}

		// Token: 0x02000023 RID: 35
		public class msg
		{
			// Token: 0x17000017 RID: 23
			// (get) Token: 0x06000119 RID: 281 RVA: 0x00002566 File Offset: 0x00000766
			// (set) Token: 0x0600011A RID: 282 RVA: 0x0000256E File Offset: 0x0000076E
			public string message { get; set; }

			// Token: 0x17000018 RID: 24
			// (get) Token: 0x0600011B RID: 283 RVA: 0x00002577 File Offset: 0x00000777
			// (set) Token: 0x0600011C RID: 284 RVA: 0x0000257F File Offset: 0x0000077F
			public string author { get; set; }

			// Token: 0x17000019 RID: 25
			// (get) Token: 0x0600011D RID: 285 RVA: 0x00002588 File Offset: 0x00000788
			// (set) Token: 0x0600011E RID: 286 RVA: 0x00002590 File Offset: 0x00000790
			public string timestamp { get; set; }

			// Token: 0x0400010A RID: 266
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400010B RID: 267
			[CompilerGenerated]
			private string string_1;

			// Token: 0x0400010C RID: 268
			[CompilerGenerated]
			private string string_2;
		}

		// Token: 0x02000024 RID: 36
		[DataContract]
		private class Class3
		{
			// Token: 0x1700001A RID: 26
			// (get) Token: 0x06000120 RID: 288 RVA: 0x00002599 File Offset: 0x00000799
			// (set) Token: 0x06000121 RID: 289 RVA: 0x000025A1 File Offset: 0x000007A1
			[DataMember]
			public string username { get; set; }

			// Token: 0x1700001B RID: 27
			// (get) Token: 0x06000122 RID: 290 RVA: 0x000025AA File Offset: 0x000007AA
			// (set) Token: 0x06000123 RID: 291 RVA: 0x000025B2 File Offset: 0x000007B2
			[DataMember]
			public string String_0 { get; set; }

			// Token: 0x1700001C RID: 28
			// (get) Token: 0x06000124 RID: 292 RVA: 0x000025BB File Offset: 0x000007BB
			// (set) Token: 0x06000125 RID: 293 RVA: 0x000025C3 File Offset: 0x000007C3
			[DataMember]
			public string hwid { get; set; }

			// Token: 0x1700001D RID: 29
			// (get) Token: 0x06000126 RID: 294 RVA: 0x000025CC File Offset: 0x000007CC
			// (set) Token: 0x06000127 RID: 295 RVA: 0x000025D4 File Offset: 0x000007D4
			[DataMember]
			public string String_1 { get; set; }

			// Token: 0x1700001E RID: 30
			// (get) Token: 0x06000128 RID: 296 RVA: 0x000025DD File Offset: 0x000007DD
			// (set) Token: 0x06000129 RID: 297 RVA: 0x000025E5 File Offset: 0x000007E5
			[DataMember]
			public string String_2 { get; set; }

			// Token: 0x1700001F RID: 31
			// (get) Token: 0x0600012A RID: 298 RVA: 0x000025EE File Offset: 0x000007EE
			// (set) Token: 0x0600012B RID: 299 RVA: 0x000025F6 File Offset: 0x000007F6
			[DataMember]
			public List<api.Data> List_0 { get; set; }

			// Token: 0x0400010D RID: 269
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400010E RID: 270
			[CompilerGenerated]
			private string string_1;

			// Token: 0x0400010F RID: 271
			[CompilerGenerated]
			private string string_2;

			// Token: 0x04000110 RID: 272
			[CompilerGenerated]
			private string string_3;

			// Token: 0x04000111 RID: 273
			[CompilerGenerated]
			private string string_4;

			// Token: 0x04000112 RID: 274
			[CompilerGenerated]
			private List<api.Data> list_0;
		}

		// Token: 0x02000025 RID: 37
		[DataContract]
		private class Class4
		{
			// Token: 0x17000020 RID: 32
			// (get) Token: 0x0600012D RID: 301 RVA: 0x000025FF File Offset: 0x000007FF
			// (set) Token: 0x0600012E RID: 302 RVA: 0x00002607 File Offset: 0x00000807
			[DataMember]
			public string String_0 { get; set; }

			// Token: 0x17000021 RID: 33
			// (get) Token: 0x0600012F RID: 303 RVA: 0x00002610 File Offset: 0x00000810
			// (set) Token: 0x06000130 RID: 304 RVA: 0x00002618 File Offset: 0x00000818
			[DataMember]
			public string String_1 { get; set; }

			// Token: 0x17000022 RID: 34
			// (get) Token: 0x06000131 RID: 305 RVA: 0x00002621 File Offset: 0x00000821
			// (set) Token: 0x06000132 RID: 306 RVA: 0x00002629 File Offset: 0x00000829
			[DataMember]
			public string String_2 { get; set; }

			// Token: 0x17000023 RID: 35
			// (get) Token: 0x06000133 RID: 307 RVA: 0x00002632 File Offset: 0x00000832
			// (set) Token: 0x06000134 RID: 308 RVA: 0x0000263A File Offset: 0x0000083A
			[DataMember]
			public string String_3 { get; set; }

			// Token: 0x17000024 RID: 36
			// (get) Token: 0x06000135 RID: 309 RVA: 0x00002643 File Offset: 0x00000843
			// (set) Token: 0x06000136 RID: 310 RVA: 0x0000264B File Offset: 0x0000084B
			[DataMember]
			public string String_4 { get; set; }

			// Token: 0x17000025 RID: 37
			// (get) Token: 0x06000137 RID: 311 RVA: 0x00002654 File Offset: 0x00000854
			// (set) Token: 0x06000138 RID: 312 RVA: 0x0000265C File Offset: 0x0000085C
			[DataMember]
			public string String_5 { get; set; }

			// Token: 0x04000113 RID: 275
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000114 RID: 276
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000115 RID: 277
			[CompilerGenerated]
			private string string_2;

			// Token: 0x04000116 RID: 278
			[CompilerGenerated]
			private string string_3;

			// Token: 0x04000117 RID: 279
			[CompilerGenerated]
			private string string_4;

			// Token: 0x04000118 RID: 280
			[CompilerGenerated]
			private string string_5;
		}

		// Token: 0x02000026 RID: 38
		public class app_data_class
		{
			// Token: 0x17000026 RID: 38
			// (get) Token: 0x0600013A RID: 314 RVA: 0x00002665 File Offset: 0x00000865
			// (set) Token: 0x0600013B RID: 315 RVA: 0x0000266D File Offset: 0x0000086D
			public string numUsers { get; set; }

			// Token: 0x17000027 RID: 39
			// (get) Token: 0x0600013C RID: 316 RVA: 0x00002676 File Offset: 0x00000876
			// (set) Token: 0x0600013D RID: 317 RVA: 0x0000267E File Offset: 0x0000087E
			public string numOnlineUsers { get; set; }

			// Token: 0x17000028 RID: 40
			// (get) Token: 0x0600013E RID: 318 RVA: 0x00002687 File Offset: 0x00000887
			// (set) Token: 0x0600013F RID: 319 RVA: 0x0000268F File Offset: 0x0000088F
			public string numKeys { get; set; }

			// Token: 0x17000029 RID: 41
			// (get) Token: 0x06000140 RID: 320 RVA: 0x00002698 File Offset: 0x00000898
			// (set) Token: 0x06000141 RID: 321 RVA: 0x000026A0 File Offset: 0x000008A0
			public string version { get; set; }

			// Token: 0x1700002A RID: 42
			// (get) Token: 0x06000142 RID: 322 RVA: 0x000026A9 File Offset: 0x000008A9
			// (set) Token: 0x06000143 RID: 323 RVA: 0x000026B1 File Offset: 0x000008B1
			public string customerPanelLink { get; set; }

			// Token: 0x1700002B RID: 43
			// (get) Token: 0x06000144 RID: 324 RVA: 0x000026BA File Offset: 0x000008BA
			// (set) Token: 0x06000145 RID: 325 RVA: 0x000026C2 File Offset: 0x000008C2
			public string downloadLink { get; set; }

			// Token: 0x04000119 RID: 281
			[CompilerGenerated]
			private string string_0;

			// Token: 0x0400011A RID: 282
			[CompilerGenerated]
			private string string_1;

			// Token: 0x0400011B RID: 283
			[CompilerGenerated]
			private string string_2;

			// Token: 0x0400011C RID: 284
			[CompilerGenerated]
			private string string_3;

			// Token: 0x0400011D RID: 285
			[CompilerGenerated]
			private string string_4;

			// Token: 0x0400011E RID: 286
			[CompilerGenerated]
			private string string_5;
		}

		// Token: 0x02000027 RID: 39
		public class user_data_class
		{
			// Token: 0x1700002C RID: 44
			// (get) Token: 0x06000147 RID: 327 RVA: 0x000026CB File Offset: 0x000008CB
			// (set) Token: 0x06000148 RID: 328 RVA: 0x000026D3 File Offset: 0x000008D3
			public string username { get; set; }

			// Token: 0x1700002D RID: 45
			// (get) Token: 0x06000149 RID: 329 RVA: 0x000026DC File Offset: 0x000008DC
			// (set) Token: 0x0600014A RID: 330 RVA: 0x000026E4 File Offset: 0x000008E4
			public string ip { get; set; }

			// Token: 0x1700002E RID: 46
			// (get) Token: 0x0600014B RID: 331 RVA: 0x000026ED File Offset: 0x000008ED
			// (set) Token: 0x0600014C RID: 332 RVA: 0x000026F5 File Offset: 0x000008F5
			public string hwid { get; set; }

			// Token: 0x1700002F RID: 47
			// (get) Token: 0x0600014D RID: 333 RVA: 0x000026FE File Offset: 0x000008FE
			// (set) Token: 0x0600014E RID: 334 RVA: 0x00002706 File Offset: 0x00000906
			public string createdate { get; set; }

			// Token: 0x17000030 RID: 48
			// (get) Token: 0x0600014F RID: 335 RVA: 0x0000270F File Offset: 0x0000090F
			// (set) Token: 0x06000150 RID: 336 RVA: 0x00002717 File Offset: 0x00000917
			public string lastlogin { get; set; }

			// Token: 0x17000031 RID: 49
			// (get) Token: 0x06000151 RID: 337 RVA: 0x00002720 File Offset: 0x00000920
			// (set) Token: 0x06000152 RID: 338 RVA: 0x00002728 File Offset: 0x00000928
			public List<api.Data> subscriptions { get; set; }

			// Token: 0x0400011F RID: 287
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000120 RID: 288
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000121 RID: 289
			[CompilerGenerated]
			private string string_2;

			// Token: 0x04000122 RID: 290
			[CompilerGenerated]
			private string string_3;

			// Token: 0x04000123 RID: 291
			[CompilerGenerated]
			private string string_4;

			// Token: 0x04000124 RID: 292
			[CompilerGenerated]
			private List<api.Data> list_0;
		}

		// Token: 0x02000028 RID: 40
		public class Data
		{
			// Token: 0x17000032 RID: 50
			// (get) Token: 0x06000154 RID: 340 RVA: 0x00002731 File Offset: 0x00000931
			// (set) Token: 0x06000155 RID: 341 RVA: 0x00002739 File Offset: 0x00000939
			public string subscription { get; set; }

			// Token: 0x17000033 RID: 51
			// (get) Token: 0x06000156 RID: 342 RVA: 0x00002742 File Offset: 0x00000942
			// (set) Token: 0x06000157 RID: 343 RVA: 0x0000274A File Offset: 0x0000094A
			public string expiry { get; set; }

			// Token: 0x17000034 RID: 52
			// (get) Token: 0x06000158 RID: 344 RVA: 0x00002753 File Offset: 0x00000953
			// (set) Token: 0x06000159 RID: 345 RVA: 0x0000275B File Offset: 0x0000095B
			public string timeleft { get; set; }

			// Token: 0x04000125 RID: 293
			[CompilerGenerated]
			private string string_0;

			// Token: 0x04000126 RID: 294
			[CompilerGenerated]
			private string string_1;

			// Token: 0x04000127 RID: 295
			[CompilerGenerated]
			private string string_2;
		}

		// Token: 0x02000029 RID: 41
		public class response_class
		{
			// Token: 0x17000035 RID: 53
			// (get) Token: 0x0600015B RID: 347 RVA: 0x00002764 File Offset: 0x00000964
			// (set) Token: 0x0600015C RID: 348 RVA: 0x0000276C File Offset: 0x0000096C
			public bool success { get; set; }

			// Token: 0x17000036 RID: 54
			// (get) Token: 0x0600015D RID: 349 RVA: 0x00002775 File Offset: 0x00000975
			// (set) Token: 0x0600015E RID: 350 RVA: 0x0000277D File Offset: 0x0000097D
			public string message { get; set; }

			// Token: 0x04000128 RID: 296
			[CompilerGenerated]
			private bool bool_0;

			// Token: 0x04000129 RID: 297
			[CompilerGenerated]
			private string string_0;
		}
	}
}
