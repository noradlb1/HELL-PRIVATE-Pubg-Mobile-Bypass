using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Superman.Properties
{
	// Token: 0x0200001F RID: 31
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000DE RID: 222 RVA: 0x000022AD File Offset: 0x000004AD
		internal Resources()
		{
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000B200 File Offset: 0x00009400
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (Resources.resourceManager_0 == null)
				{
					ResourceManager resourceManager = new ResourceManager("Superman.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceManager_0 = resourceManager;
				}
				return Resources.resourceManager_0;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x0000B240 File Offset: 0x00009440
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00002483 File Offset: 0x00000683
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.cultureInfo_0;
			}
			set
			{
				Resources.cultureInfo_0 = value;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0000B254 File Offset: 0x00009454
		internal static Bitmap _1
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("1", Resources.cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000B280 File Offset: 0x00009480
		internal static Bitmap _2
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("2", Resources.cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x0000B2AC File Offset: 0x000094AC
		internal static Bitmap _22
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("22", Resources.cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x0000B2D8 File Offset: 0x000094D8
		internal static Bitmap _23
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("23", Resources.cultureInfo_0);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x0000B304 File Offset: 0x00009504
		internal static byte[] click
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("click", Resources.cultureInfo_0);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x0000B330 File Offset: 0x00009530
		internal static byte[] hosts
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("hosts", Resources.cultureInfo_0);
				return (byte[])@object;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x0000B35C File Offset: 0x0000955C
		internal static byte[] Service
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Service", Resources.cultureInfo_0);
				return (byte[])@object;
			}
		}

		// Token: 0x040000F3 RID: 243
		private static ResourceManager resourceManager_0;

		// Token: 0x040000F4 RID: 244
		private static CultureInfo cultureInfo_0;
	}
}
