using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x0200002B RID: 43
	public class json_wrapper
	{
		// Token: 0x06000168 RID: 360 RVA: 0x000027A2 File Offset: 0x000009A2
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x06000169 RID: 361 RVA: 0x0000CC3C File Offset: 0x0000AE3C
		public json_wrapper(object obj_to_work_with)
		{
			this.object_0 = obj_to_work_with;
			Type type = this.object_0.GetType();
			this.dataContractJsonSerializer_0 = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.object_0));
			}
		}

		// Token: 0x0600016A RID: 362 RVA: 0x0000CC90 File Offset: 0x0000AE90
		public object string_to_object(string json)
		{
			byte[] bytes = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				result = this.dataContractJsonSerializer_0.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000027C0 File Offset: 0x000009C0
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x0400012A RID: 298
		private DataContractJsonSerializer dataContractJsonSerializer_0;

		// Token: 0x0400012B RID: 299
		private object object_0;
	}
}
