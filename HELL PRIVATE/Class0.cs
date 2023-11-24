using System;
using System.Windows.Forms;
using Superman;

// Token: 0x0200001D RID: 29
internal static class Class0
{
	// Token: 0x060000D1 RID: 209 RVA: 0x00002439 File Offset: 0x00000639
	[STAThread]
	private static void Main(string[] args)
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run(new LoginForm());
	}
}
