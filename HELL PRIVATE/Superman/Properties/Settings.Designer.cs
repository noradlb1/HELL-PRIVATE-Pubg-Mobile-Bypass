using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Superman.Properties
{
	// Token: 0x02000020 RID: 32
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	[CompilerGenerated]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x0000B388 File Offset: 0x00009588
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x040000F5 RID: 245
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
