using System;
using System.Reflection;

// Token: 0x02000031 RID: 49
internal class Class6
{
	// Token: 0x06000176 RID: 374 RVA: 0x0000D0BC File Offset: 0x0000B2BC
	internal static void smethod_0(int typemdt)
	{
		Type type = Class6.module_0.ResolveType(33554432 + typemdt);
		foreach (FieldInfo fieldInfo in type.GetFields())
		{
			MethodInfo method = (MethodInfo)Class6.module_0.ResolveMethod(fieldInfo.MetadataToken + 100663296);
			fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, method));
		}
	}

	// Token: 0x04000132 RID: 306
	internal static Module module_0 = typeof(Class6).Assembly.ManifestModule;

	// Token: 0x02000032 RID: 50
	// (Invoke) Token: 0x0600017A RID: 378
	internal delegate void Delegate0(object o);
}
