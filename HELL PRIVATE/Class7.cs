using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

// Token: 0x02000033 RID: 51
internal class Class7
{
	// Token: 0x0600017D RID: 381 RVA: 0x0000D128 File Offset: 0x0000B328
	static Class7()
	{
		Class7.bool_1 = false;
		Class7.bool_6 = false;
		Class7.rsacryptoServiceProvider_0 = null;
		Class7.dictionary_0 = null;
		Class7.object_1 = new object();
		Class7.int_0 = 0;
		Class7.object_0 = new object();
		Class7.list_0 = null;
		Class7.list_1 = null;
		Class7.byte_1 = new byte[0];
		Class7.byte_0 = new byte[0];
		Class7.intptr_0 = IntPtr.Zero;
		Class7.intptr_3 = IntPtr.Zero;
		Class7.string_0 = new string[0];
		Class7.int_5 = new int[0];
		Class7.int_1 = 1;
		Class7.bool_3 = false;
		Class7.sortedList_0 = new SortedList();
		Class7.int_2 = 0;
		Class7.long_0 = 0L;
		Class7.delegate2_0 = null;
		Class7.delegate2_1 = null;
		Class7.long_1 = 0L;
		Class7.int_3 = 0;
		Class7.bool_5 = false;
		Class7.bool_4 = false;
		Class7.int_4 = 0;
		Class7.intptr_2 = IntPtr.Zero;
		Class7.bool_2 = false;
		Class7.hashtable_0 = new Hashtable();
		Class7.delegate4_0 = null;
		Class7.delegate5_0 = null;
		Class7.delegate6_0 = null;
		Class7.delegate7_0 = null;
		Class7.delegate8_0 = null;
		Class7.delegate9_0 = null;
		Class7.intptr_1 = IntPtr.Zero;
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00002250 File Offset: 0x00000450
	private void method_0()
	{
	}

	// Token: 0x0600017F RID: 383 RVA: 0x0000D2A4 File Offset: 0x0000B4A4
	internal static byte[] smethod_0(byte[] byte_2)
	{
		uint[] array = new uint[16];
		uint num = (uint)((448 - byte_2.Length * 8 % 512 + 512) % 512);
		if (num == 0U)
		{
			num = 512U;
		}
		uint num2 = (uint)((long)byte_2.Length + (long)((ulong)(num / 8U)) + 8L);
		ulong num3 = (ulong)((long)byte_2.Length * 8L);
		byte[] array2 = new byte[num2];
		for (int i = 0; i < byte_2.Length; i++)
		{
			array2[i] = byte_2[i];
		}
		byte[] array3 = array2;
		int num4 = byte_2.Length;
		array3[num4] |= 128;
		for (int j = 8; j > 0; j--)
		{
			array2[(int)(checked((IntPtr)(unchecked((ulong)num2 - (ulong)((long)j)))))] = (byte)(num3 >> (8 - j) * 8 & 255UL);
		}
		uint num5 = (uint)(array2.Length * 8 / 32);
		uint num6 = 1732584193U;
		uint num7 = 4023233417U;
		uint num8 = 2562383102U;
		uint num9 = 271733878U;
		for (uint num10 = 0U; num10 < num5 / 16U; num10 += 1U)
		{
			uint num11 = num10 << 6;
			for (uint num12 = 0U; num12 < 61U; num12 += 4U)
			{
				array[(int)(num12 >> 2)] = (uint)((int)array2[(int)(num11 + (num12 + 3U))] << 24 | (int)array2[(int)(num11 + (num12 + 2U))] << 16 | (int)array2[(int)(num11 + (num12 + 1U))] << 8 | (int)array2[(int)(num11 + num12)]);
			}
			uint num13 = num6;
			uint num14 = num7;
			uint num15 = num8;
			uint num16 = num9;
			Class7.smethod_1(ref num6, num7, num8, num9, 0U, 7, 1U, array);
			Class7.smethod_1(ref num9, num6, num7, num8, 1U, 12, 2U, array);
			Class7.smethod_1(ref num8, num9, num6, num7, 2U, 17, 3U, array);
			Class7.smethod_1(ref num7, num8, num9, num6, 3U, 22, 4U, array);
			Class7.smethod_1(ref num6, num7, num8, num9, 4U, 7, 5U, array);
			Class7.smethod_1(ref num9, num6, num7, num8, 5U, 12, 6U, array);
			Class7.smethod_1(ref num8, num9, num6, num7, 6U, 17, 7U, array);
			Class7.smethod_1(ref num7, num8, num9, num6, 7U, 22, 8U, array);
			Class7.smethod_1(ref num6, num7, num8, num9, 8U, 7, 9U, array);
			Class7.smethod_1(ref num9, num6, num7, num8, 9U, 12, 10U, array);
			Class7.smethod_1(ref num8, num9, num6, num7, 10U, 17, 11U, array);
			Class7.smethod_1(ref num7, num8, num9, num6, 11U, 22, 12U, array);
			Class7.smethod_1(ref num6, num7, num8, num9, 12U, 7, 13U, array);
			Class7.smethod_1(ref num9, num6, num7, num8, 13U, 12, 14U, array);
			Class7.smethod_1(ref num8, num9, num6, num7, 14U, 17, 15U, array);
			Class7.smethod_1(ref num7, num8, num9, num6, 15U, 22, 16U, array);
			Class7.smethod_2(ref num6, num7, num8, num9, 1U, 5, 17U, array);
			Class7.smethod_2(ref num9, num6, num7, num8, 6U, 9, 18U, array);
			Class7.smethod_2(ref num8, num9, num6, num7, 11U, 14, 19U, array);
			Class7.smethod_2(ref num7, num8, num9, num6, 0U, 20, 20U, array);
			Class7.smethod_2(ref num6, num7, num8, num9, 5U, 5, 21U, array);
			Class7.smethod_2(ref num9, num6, num7, num8, 10U, 9, 22U, array);
			Class7.smethod_2(ref num8, num9, num6, num7, 15U, 14, 23U, array);
			Class7.smethod_2(ref num7, num8, num9, num6, 4U, 20, 24U, array);
			Class7.smethod_2(ref num6, num7, num8, num9, 9U, 5, 25U, array);
			Class7.smethod_2(ref num9, num6, num7, num8, 14U, 9, 26U, array);
			Class7.smethod_2(ref num8, num9, num6, num7, 3U, 14, 27U, array);
			Class7.smethod_2(ref num7, num8, num9, num6, 8U, 20, 28U, array);
			Class7.smethod_2(ref num6, num7, num8, num9, 13U, 5, 29U, array);
			Class7.smethod_2(ref num9, num6, num7, num8, 2U, 9, 30U, array);
			Class7.smethod_2(ref num8, num9, num6, num7, 7U, 14, 31U, array);
			Class7.smethod_2(ref num7, num8, num9, num6, 12U, 20, 32U, array);
			Class7.smethod_3(ref num6, num7, num8, num9, 5U, 4, 33U, array);
			Class7.smethod_3(ref num9, num6, num7, num8, 8U, 11, 34U, array);
			Class7.smethod_3(ref num8, num9, num6, num7, 11U, 16, 35U, array);
			Class7.smethod_3(ref num7, num8, num9, num6, 14U, 23, 36U, array);
			Class7.smethod_3(ref num6, num7, num8, num9, 1U, 4, 37U, array);
			Class7.smethod_3(ref num9, num6, num7, num8, 4U, 11, 38U, array);
			Class7.smethod_3(ref num8, num9, num6, num7, 7U, 16, 39U, array);
			Class7.smethod_3(ref num7, num8, num9, num6, 10U, 23, 40U, array);
			Class7.smethod_3(ref num6, num7, num8, num9, 13U, 4, 41U, array);
			Class7.smethod_3(ref num9, num6, num7, num8, 0U, 11, 42U, array);
			Class7.smethod_3(ref num8, num9, num6, num7, 3U, 16, 43U, array);
			Class7.smethod_3(ref num7, num8, num9, num6, 6U, 23, 44U, array);
			Class7.smethod_3(ref num6, num7, num8, num9, 9U, 4, 45U, array);
			Class7.smethod_3(ref num9, num6, num7, num8, 12U, 11, 46U, array);
			Class7.smethod_3(ref num8, num9, num6, num7, 15U, 16, 47U, array);
			Class7.smethod_3(ref num7, num8, num9, num6, 2U, 23, 48U, array);
			Class7.smethod_4(ref num6, num7, num8, num9, 0U, 6, 49U, array);
			Class7.smethod_4(ref num9, num6, num7, num8, 7U, 10, 50U, array);
			Class7.smethod_4(ref num8, num9, num6, num7, 14U, 15, 51U, array);
			Class7.smethod_4(ref num7, num8, num9, num6, 5U, 21, 52U, array);
			Class7.smethod_4(ref num6, num7, num8, num9, 12U, 6, 53U, array);
			Class7.smethod_4(ref num9, num6, num7, num8, 3U, 10, 54U, array);
			Class7.smethod_4(ref num8, num9, num6, num7, 10U, 15, 55U, array);
			Class7.smethod_4(ref num7, num8, num9, num6, 1U, 21, 56U, array);
			Class7.smethod_4(ref num6, num7, num8, num9, 8U, 6, 57U, array);
			Class7.smethod_4(ref num9, num6, num7, num8, 15U, 10, 58U, array);
			Class7.smethod_4(ref num8, num9, num6, num7, 6U, 15, 59U, array);
			Class7.smethod_4(ref num7, num8, num9, num6, 13U, 21, 60U, array);
			Class7.smethod_4(ref num6, num7, num8, num9, 4U, 6, 61U, array);
			Class7.smethod_4(ref num9, num6, num7, num8, 11U, 10, 62U, array);
			Class7.smethod_4(ref num8, num9, num6, num7, 2U, 15, 63U, array);
			Class7.smethod_4(ref num7, num8, num9, num6, 9U, 21, 64U, array);
			num6 += num13;
			num7 += num14;
			num8 += num15;
			num9 += num16;
		}
		byte[] array4 = new byte[16];
		Array.Copy(BitConverter.GetBytes(num6), 0, array4, 0, 4);
		Array.Copy(BitConverter.GetBytes(num7), 0, array4, 4, 4);
		Array.Copy(BitConverter.GetBytes(num8), 0, array4, 8, 4);
		Array.Copy(BitConverter.GetBytes(num9), 0, array4, 12, 4);
		return array4;
	}

	// Token: 0x06000180 RID: 384 RVA: 0x000027FA File Offset: 0x000009FA
	private static void smethod_1(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + Class7.smethod_5(uint_1 + ((uint_2 & uint_3) | (~uint_2 & uint_4)) + uint_7[(int)uint_5] + Class7.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00002823 File Offset: 0x00000A23
	private static void smethod_2(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + Class7.smethod_5(uint_1 + ((uint_2 & uint_4) | (uint_3 & ~uint_4)) + uint_7[(int)uint_5] + Class7.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000182 RID: 386 RVA: 0x0000284C File Offset: 0x00000A4C
	private static void smethod_3(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + Class7.smethod_5(uint_1 + (uint_2 ^ uint_3 ^ uint_4) + uint_7[(int)uint_5] + Class7.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00002872 File Offset: 0x00000A72
	private static void smethod_4(ref uint uint_1, uint uint_2, uint uint_3, uint uint_4, uint uint_5, ushort ushort_0, uint uint_6, uint[] uint_7)
	{
		uint_1 = uint_2 + Class7.smethod_5(uint_1 + (uint_3 ^ (uint_2 | ~uint_4)) + uint_7[(int)uint_5] + Class7.uint_0[(int)(uint_6 - 1U)], ushort_0);
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00002899 File Offset: 0x00000A99
	private static uint smethod_5(uint uint_1, ushort ushort_0)
	{
		return uint_1 >> (int)(32 - ushort_0) | uint_1 << (int)ushort_0;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x000028AB File Offset: 0x00000AAB
	internal static bool smethod_6()
	{
		if (!Class7.bool_1)
		{
			Class7.smethod_8();
			Class7.bool_1 = true;
		}
		return Class7.bool_6;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x000022AD File Offset: 0x000004AD
	internal Class7()
	{
	}

	// Token: 0x06000187 RID: 391 RVA: 0x0000D904 File Offset: 0x0000BB04
	private void method_1(byte[] byte_2, byte[] byte_3, byte[] byte_4)
	{
		int num = byte_4.Length % 4;
		int num2 = byte_4.Length / 4;
		byte[] array = new byte[byte_4.Length];
		int num3 = byte_2.Length / 4;
		uint num4 = 0U;
		if (num > 0)
		{
			num2++;
		}
		for (int i = 0; i < num2; i++)
		{
			int num5 = i % num3;
			int num6 = i * 4;
			uint num7 = (uint)(num5 * 4);
			uint num8 = (uint)((int)byte_2[(int)(num7 + 3U)] << 24 | (int)byte_2[(int)(num7 + 2U)] << 16 | (int)byte_2[(int)(num7 + 1U)] << 8 | (int)byte_2[(int)num7]);
			uint num9 = 255U;
			int num10 = 0;
			uint num11;
			if (i == num2 - 1 && num > 0)
			{
				num11 = 0U;
				num4 += num8;
				for (int j = 0; j < num; j++)
				{
					if (j > 0)
					{
						num11 <<= 8;
					}
					num11 |= (uint)byte_4[byte_4.Length - (1 + j)];
				}
			}
			else
			{
				num4 += num8;
				num7 = (uint)num6;
				num11 = (uint)((int)byte_4[(int)(num7 + 3U)] << 24 | (int)byte_4[(int)(num7 + 2U)] << 16 | (int)byte_4[(int)(num7 + 1U)] << 8 | (int)byte_4[(int)num7]);
			}
			uint num13;
			uint num12 = num13 = num4;
			uint num14 = 1433820929U;
			uint num15 = 1257022020U;
			uint num16 = 770959034U;
			uint num17 = 1192762477U;
			ulong num18 = (ulong)(1433820929U * num13);
			if (num18 == 0UL)
			{
				num18 -= 1UL;
			}
			num16 = (uint)((ulong)(num16 * num16) % num18);
			uint num19 = num15 & 252645135U;
			uint num20 = num15 & 4042322160U;
			num19 = ((num19 >> 4 | num20 << 4) ^ num13);
			num15 = (num15 << 11 | num15 >> 21);
			num19 = (num13 & 16711935U);
			num20 = (num13 & 4278255360U);
			num19 = (num19 >> 8 | num20 << 8) + num16;
			num13 = (num13 << 5 | num13 >> 27);
			if (num14 == 0U)
			{
				num14 -= 1U;
			}
			uint num21 = num16 / num14 + num14;
			num14 = num16 + num16 - num21 + num16;
			num15 = 16868U * (num15 & 32767U) + (num15 >> 15);
			num13 = 52855U * (num13 & 32767U) + (num13 >> 15);
			num16 = 50331U * num16 - num14;
			num13 ^= num13 >> 3;
			num13 += num13;
			num13 ^= num13 >> 25;
			num13 += num14;
			num13 ^= num13 << 23;
			num13 += num17;
			num13 = ((num16 << 12) + num14 ^ num13) - num13;
			num4 = num12 + (uint)num13;
			if (i == num2 - 1 && num > 0)
			{
				uint num22 = num4 ^ num11;
				for (int k = 0; k < num; k++)
				{
					if (k > 0)
					{
						num9 <<= 8;
						num10 += 8;
					}
					array[num6 + k] = (byte)((num22 & num9) >> num10);
				}
			}
			else
			{
				uint num23 = num4 ^ num11;
				array[num6] = (byte)(num23 & 255U);
				array[num6 + 1] = (byte)((num23 & 65280U) >> 8);
				array[num6 + 2] = (byte)((num23 & 16711680U) >> 16);
				array[num6 + 3] = (byte)((num23 & 4278190080U) >> 24);
			}
		}
		Class7.byte_1 = array;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x0000DCC8 File Offset: 0x0000BEC8
	internal static SymmetricAlgorithm smethod_7()
	{
		SymmetricAlgorithm result = null;
		if (Class7.smethod_6())
		{
			result = new AesCryptoServiceProvider();
		}
		else
		{
			try
			{
				result = new RijndaelManaged();
			}
			catch
			{
				try
				{
					result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
				catch
				{
					result = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
		}
		return result;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x0000DD48 File Offset: 0x0000BF48
	internal static void smethod_8()
	{
		try
		{
			new MD5CryptoServiceProvider();
		}
		catch
		{
			Class7.bool_6 = true;
			return;
		}
		try
		{
			Class7.bool_6 = CryptoConfig.AllowOnlyFipsAlgorithms;
		}
		catch
		{
		}
	}

	// Token: 0x0600018A RID: 394 RVA: 0x000028C4 File Offset: 0x00000AC4
	internal static byte[] smethod_9(byte[] byte_2)
	{
		if (!Class7.smethod_6())
		{
			return new MD5CryptoServiceProvider().ComputeHash(byte_2);
		}
		return Class7.smethod_0(byte_2);
	}

	// Token: 0x0600018B RID: 395 RVA: 0x0000DD94 File Offset: 0x0000BF94
	internal static void smethod_10(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_1, byte[] byte_2)
	{
		while (uint_1 > 0U)
		{
			int num = (uint_1 > (uint)byte_2.Length) ? byte_2.Length : ((int)uint_1);
			stream_0.Read(byte_2, 0, num);
			Class7.smethod_11(hashAlgorithm_0, byte_2, 0, num);
			uint_1 -= (uint)num;
		}
	}

	// Token: 0x0600018C RID: 396 RVA: 0x000028DF File Offset: 0x00000ADF
	internal static void smethod_11(HashAlgorithm hashAlgorithm_0, byte[] byte_2, int int_6, int int_7)
	{
		hashAlgorithm_0.TransformBlock(byte_2, int_6, int_7, byte_2, int_6);
	}

	// Token: 0x0600018D RID: 397 RVA: 0x0000DDD0 File Offset: 0x0000BFD0
	internal static uint smethod_12(uint uint_1, int int_6, long long_2, BinaryReader binaryReader_0)
	{
		for (int i = 0; i < int_6; i++)
		{
			binaryReader_0.BaseStream.Position = long_2 + (long)(i * 40 + 8);
			uint num = binaryReader_0.ReadUInt32();
			uint num2 = binaryReader_0.ReadUInt32();
			binaryReader_0.ReadUInt32();
			uint num3 = binaryReader_0.ReadUInt32();
			if (num2 <= uint_1 && uint_1 < num2 + num)
			{
				return num3 + uint_1 - num2;
			}
		}
		return 0U;
	}

	// Token: 0x0600018E RID: 398 RVA: 0x0000DE2C File Offset: 0x0000C02C
	public static void smethod_13(RuntimeTypeHandle runtimeTypeHandle_0)
	{
		try
		{
			Type typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandle_0);
			if (Class7.dictionary_0 == null)
			{
				object obj = Class7.object_1;
				lock (obj)
				{
					Dictionary<int, int> dictionary = new Dictionary<int, int>();
					BinaryReader binaryReader = new BinaryReader(typeof(Class7).Assembly.GetManifestResourceStream("SSF7DeadOBQGgLFYAC.FBXPPUfXPueuiisRRc"));
					binaryReader.BaseStream.Position = 0L;
					byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
					binaryReader.Close();
					if (array.Length != 0)
					{
						int num = array.Length % 4;
						int num2 = array.Length / 4;
						byte[] array2 = new byte[array.Length];
						uint num3 = 0U;
						if (num > 0)
						{
							num2++;
						}
						for (int i = 0; i < num2; i++)
						{
							int num4 = i * 4;
							uint num5 = 255U;
							int num6 = 0;
							uint num7;
							if (i == num2 - 1 && num > 0)
							{
								num7 = 0U;
								for (int j = 0; j < num; j++)
								{
									if (j > 0)
									{
										num7 <<= 8;
									}
									num7 |= (uint)array[array.Length - (1 + j)];
								}
							}
							else
							{
								uint num8 = (uint)num4;
								num7 = (uint)((int)array[(int)(num8 + 3U)] << 24 | (int)array[(int)(num8 + 2U)] << 16 | (int)array[(int)(num8 + 1U)] << 8 | (int)array[(int)num8]);
							}
							num3 = num3;
							num3 += 0U;
							if (i == num2 - 1 && num > 0)
							{
								uint num9 = num3 ^ num7;
								for (int k = 0; k < num; k++)
								{
									if (k > 0)
									{
										num5 <<= 8;
										num6 += 8;
									}
									array2[num4 + k] = (byte)((num9 & num5) >> num6);
								}
							}
							else
							{
								uint num10 = num3 ^ num7;
								array2[num4] = (byte)(num10 & 255U);
								array2[num4 + 1] = (byte)((num10 & 65280U) >> 8);
								array2[num4 + 2] = (byte)((num10 & 16711680U) >> 16);
								array2[num4 + 3] = (byte)((num10 & 4278190080U) >> 24);
							}
						}
						array = array2;
						int num11 = array.Length / 8;
						Class7.Class10 @class = new Class7.Class10(new MemoryStream(array));
						for (int l = 0; l < num11; l++)
						{
							int key = @class.method_1();
							int value = @class.method_1();
							dictionary.Add(key, value);
						}
						@class.method_2();
					}
					Class7.dictionary_0 = dictionary;
				}
			}
			FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			for (int m = 0; m < fields.Length; m++)
			{
				try
				{
					FieldInfo fieldInfo = fields[m];
					int metadataToken = fieldInfo.MetadataToken;
					int num12 = Class7.dictionary_0[metadataToken];
					bool flag2 = (num12 & 1073741824) > 0;
					num12 &= 1073741823;
					MethodInfo methodInfo = (MethodInfo)typeof(Class7).Module.ResolveMethod(num12, typeFromHandle.GetGenericArguments(), new Type[0]);
					if (methodInfo.IsStatic)
					{
						fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
					}
					else
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						int num13 = parameters.Length + 1;
						Type[] array3 = new Type[num13];
						if (methodInfo.DeclaringType.IsValueType)
						{
							array3[0] = methodInfo.DeclaringType.MakeByRefType();
						}
						else
						{
							array3[0] = typeof(object);
						}
						for (int n = 0; n < parameters.Length; n++)
						{
							array3[n + 1] = parameters[n].ParameterType;
						}
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						for (int num14 = 0; num14 < num13; num14++)
						{
							switch (num14)
							{
							case 0:
								ilgenerator.Emit(OpCodes.Ldarg_0);
								break;
							case 1:
								ilgenerator.Emit(OpCodes.Ldarg_1);
								break;
							case 2:
								ilgenerator.Emit(OpCodes.Ldarg_2);
								break;
							case 3:
								ilgenerator.Emit(OpCodes.Ldarg_3);
								break;
							default:
								ilgenerator.Emit(OpCodes.Ldarg_S, num14);
								break;
							}
						}
						ilgenerator.Emit(OpCodes.Tailcall);
						ilgenerator.Emit(flag2 ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
						ilgenerator.Emit(OpCodes.Ret);
						fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x0600018F RID: 399 RVA: 0x000028ED File Offset: 0x00000AED
	private static uint smethod_14(uint uint_1)
	{
		return (uint)"{11111-22222-10009-11112}".Length;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000028F9 File Offset: 0x00000AF9
	private static uint smethod_15(uint uint_1)
	{
		return 0U;
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00002250 File Offset: 0x00000450
	internal static void smethod_16()
	{
	}

	// Token: 0x06000192 RID: 402 RVA: 0x0000E2B4 File Offset: 0x0000C4B4
	private static void smethod_17(Stream stream_0, int int_6)
	{
		Class7.Class10 @class = new Class7.Class10(stream_0);
		@class.method_0().Position = 0L;
		byte[] array = @class.cYoyBkdYbx((int)@class.method_0().Length);
		@class.method_2();
		byte[] array2 = new byte[32];
		array2[0] = 87;
		array2[0] = 214;
		array2[0] = 144;
		array2[0] = 130;
		array2[0] = 174;
		array2[1] = 116;
		array2[1] = 139;
		array2[1] = 112;
		array2[2] = 157;
		array2[2] = 137;
		array2[2] = 139;
		array2[3] = 116;
		array2[3] = 98;
		array2[3] = 78;
		array2[3] = 110;
		array2[3] = 90;
		array2[4] = 124;
		array2[4] = 124;
		array2[4] = 166;
		array2[4] = 89;
		array2[4] = 124;
		array2[4] = 190;
		array2[5] = 124;
		array2[5] = 148;
		array2[5] = 41;
		array2[6] = 144;
		array2[6] = 159;
		array2[6] = 83;
		array2[7] = 219;
		array2[7] = 162;
		array2[7] = 57;
		array2[8] = 95;
		array2[8] = 123;
		array2[8] = 27;
		array2[8] = 146;
		array2[8] = 63;
		array2[9] = 106;
		array2[9] = 87;
		array2[9] = 250;
		array2[10] = 224;
		array2[10] = 71;
		array2[10] = 96;
		array2[10] = 190;
		array2[11] = 97;
		array2[11] = 148;
		array2[11] = 37;
		array2[12] = 194;
		array2[12] = 232;
		array2[12] = 126;
		array2[12] = 173;
		array2[12] = 127;
		array2[13] = 140;
		array2[13] = 88;
		array2[13] = 0;
		array2[14] = 12;
		array2[14] = 47;
		array2[14] = 160;
		array2[14] = 98;
		array2[14] = 65;
		array2[14] = 112;
		array2[15] = 234;
		array2[15] = 150;
		array2[15] = 125;
		array2[16] = 155;
		array2[16] = 168;
		array2[16] = 110;
		array2[16] = 104;
		array2[16] = 120;
		array2[17] = 152;
		array2[17] = 154;
		array2[17] = 166;
		array2[17] = 68;
		array2[18] = 94;
		array2[18] = 104;
		array2[18] = 91;
		array2[18] = 91;
		array2[19] = 103;
		array2[19] = 108;
		array2[19] = 118;
		array2[19] = 144;
		array2[19] = 197;
		array2[19] = 56;
		array2[20] = 85;
		array2[20] = 63;
		array2[20] = 73;
		array2[21] = 98;
		array2[21] = 129;
		array2[21] = 111;
		array2[22] = 157;
		array2[22] = 130;
		array2[22] = 154;
		array2[22] = 81;
		array2[22] = 137;
		array2[23] = 78;
		array2[23] = 130;
		array2[23] = 178;
		array2[23] = 106;
		array2[23] = 25;
		array2[24] = 136;
		array2[24] = 64;
		array2[24] = 163;
		array2[25] = 140;
		array2[25] = 144;
		array2[25] = 142;
		array2[25] = 218;
		array2[26] = 122;
		array2[26] = 168;
		array2[26] = 124;
		array2[26] = 148;
		array2[26] = 25;
		array2[27] = 81;
		array2[27] = 162;
		array2[27] = 169;
		array2[27] = 122;
		array2[28] = 124;
		array2[28] = 163;
		array2[28] = 50;
		array2[29] = 148;
		array2[29] = 158;
		array2[29] = 119;
		array2[30] = 117;
		array2[30] = 124;
		array2[30] = 115;
		array2[30] = 225;
		array2[31] = 85;
		array2[31] = 167;
		array2[31] = 106;
		array2[31] = 136;
		array2[31] = 49;
		array2[31] = 147;
		byte[] array3 = array2;
		byte[] array4 = new byte[16];
		array4[0] = 87;
		array4[0] = 156;
		array4[0] = 74;
		array4[0] = 180;
		array4[1] = 110;
		array4[1] = 92;
		array4[1] = 116;
		array4[1] = 97;
		array4[1] = 93;
		array4[1] = 201;
		array4[2] = 117;
		array4[2] = 76;
		array4[2] = 133;
		array4[3] = 135;
		array4[3] = 97;
		array4[3] = 90;
		array4[3] = 98;
		array4[3] = 11;
		array4[4] = 96;
		array4[4] = 221;
		array4[4] = 121;
		array4[4] = 134;
		array4[4] = 132;
		array4[4] = 227;
		array4[5] = 152;
		array4[5] = 144;
		array4[5] = 159;
		array4[5] = 139;
		array4[5] = 177;
		array4[6] = 128;
		array4[6] = 117;
		array4[6] = 134;
		array4[6] = 212;
		array4[7] = 94;
		array4[7] = 87;
		array4[7] = 19;
		array4[8] = 155;
		array4[8] = 31;
		array4[8] = 110;
		array4[8] = 116;
		array4[8] = 162;
		array4[8] = 214;
		array4[9] = 163;
		array4[9] = 75;
		array4[9] = 95;
		array4[9] = 126;
		array4[10] = 194;
		array4[10] = 167;
		array4[10] = 146;
		array4[10] = 126;
		array4[10] = 131;
		array4[11] = 180;
		array4[11] = 218;
		array4[11] = 86;
		array4[11] = 126;
		array4[12] = 130;
		array4[12] = 145;
		array4[12] = 138;
		array4[12] = 117;
		array4[12] = 114;
		array4[12] = 144;
		array4[13] = 136;
		array4[13] = 63;
		array4[13] = 155;
		array4[13] = 168;
		array4[13] = 171;
		array4[14] = 216;
		array4[14] = 82;
		array4[14] = 152;
		array4[14] = 157;
		array4[14] = 164;
		array4[15] = 94;
		array4[15] = 104;
		array4[15] = 21;
		byte[] array5 = array4;
		Array.Reverse(array5);
		byte[] publicKeyToken = Class7.assembly_0.GetName().GetPublicKeyToken();
		if (publicKeyToken != null && publicKeyToken.Length != 0)
		{
			array5[1] = publicKeyToken[0];
			array5[3] = publicKeyToken[1];
			array5[5] = publicKeyToken[2];
			array5[7] = publicKeyToken[3];
			array5[9] = publicKeyToken[4];
			array5[11] = publicKeyToken[5];
			array5[13] = publicKeyToken[6];
			array5[15] = publicKeyToken[7];
		}
		for (int i = 0; i < array5.Length; i++)
		{
			array3[i] ^= array5[i];
		}
		if (int_6 == -1)
		{
			SymmetricAlgorithm symmetricAlgorithm = Class7.smethod_7();
			symmetricAlgorithm.Mode = CipherMode.CBC;
			ICryptoTransform transform = symmetricAlgorithm.CreateDecryptor(array3, array5);
			Stream stream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(stream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(array, 0, array.Length);
			cryptoStream.FlushFinalBlock();
			Class7.byte_1 = Class7.smethod_30(stream);
			stream.Close();
			cryptoStream.Close();
			array = Class7.byte_1;
		}
		if (Class7.assembly_0.EntryPoint == null)
		{
			Class7.int_0 = 80;
		}
		new Class7().method_1(array3, array5, array);
	}

	// Token: 0x06000193 RID: 403 RVA: 0x0000EEE0 File Offset: 0x0000D0E0
	internal static string smethod_18(int int_6)
	{
		if (Class7.byte_1.Length == 0)
		{
			Class7.list_0 = new List<string>();
			Class7.list_1 = new List<int>();
			Class7.smethod_17(Class7.assembly_0.GetManifestResourceStream("tiIJqT3dPOnLCAGZcZ.3Zaoi5JVtNt2SrRJuk"), int_6);
		}
		if (Class7.int_0 < 75)
		{
			if (Class7.assembly_0 != new StackFrame(1).GetMethod().DeclaringType.Assembly)
			{
				throw new Exception();
			}
			Class7.int_0++;
		}
		object obj = Class7.object_0;
		lock (obj)
		{
			int num = BitConverter.ToInt32(Class7.byte_1, int_6);
			if (num >= Class7.list_1.Count || Class7.list_1[num] != int_6)
			{
				try
				{
					byte[] array = new byte[num];
					Array.Copy(Class7.byte_1, int_6 + 4, array, 0, num);
					string @string = Encoding.Unicode.GetString(array, 0, array.Length);
					Class7.list_0.Add(@string);
					Class7.list_1.Add(int_6);
					Array.Copy(BitConverter.GetBytes(Class7.list_0.Count - 1), 0, Class7.byte_1, int_6, 4);
					return @string;
				}
				catch
				{
					goto IL_128;
				}
			}
			return Class7.list_0[num];
		}
		IL_128:
		return "";
	}

	// Token: 0x06000194 RID: 404 RVA: 0x0000F038 File Offset: 0x0000D238
	internal static string smethod_19(string string_1)
	{
		"{11111-22222-50001-00000}".Trim();
		byte[] array = Convert.FromBase64String(string_1);
		return Encoding.Unicode.GetString(array, 0, array.Length);
	}

	// Token: 0x06000195 RID: 405 RVA: 0x000028FC File Offset: 0x00000AFC
	private static int smethod_20()
	{
		return 5;
	}

	// Token: 0x06000196 RID: 406 RVA: 0x0000F068 File Offset: 0x0000D268
	private static void smethod_21()
	{
		try
		{
			RSACryptoServiceProvider.UseMachineKeyStore = true;
		}
		catch
		{
		}
	}

	// Token: 0x06000197 RID: 407 RVA: 0x0000F090 File Offset: 0x0000D290
	private static Delegate smethod_22(IntPtr intptr_4, Type type_0)
	{
		return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
		{
			typeof(IntPtr),
			typeof(Type)
		}).Invoke(null, new object[]
		{
			intptr_4,
			type_0
		});
	}

	// Token: 0x06000198 RID: 408 RVA: 0x0000F0F0 File Offset: 0x0000D2F0
	internal static object smethod_23(Assembly assembly_1)
	{
		try
		{
			if (File.Exists(((Assembly)assembly_1).Location))
			{
				return ((Assembly)assembly_1).Location;
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "")))
			{
				return ((Assembly)assembly_1).GetName().CodeBase.ToString().Replace("file:///", "");
			}
		}
		catch
		{
		}
		try
		{
			if (File.Exists(assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString()))
			{
				return assembly_1.GetType().GetProperty("Location").GetValue(assembly_1, new object[0]).ToString();
			}
		}
		catch
		{
		}
		return "";
	}

	// Token: 0x06000199 RID: 409
	[DllImport("kernel32")]
	public static extern IntPtr LoadLibrary(string string_1);

	// Token: 0x0600019A RID: 410
	[DllImport("kernel32", CharSet = CharSet.Ansi)]
	public static extern IntPtr GetProcAddress(IntPtr intptr_4, string string_1);

	// Token: 0x0600019B RID: 411 RVA: 0x0000F200 File Offset: 0x0000D400
	private static IntPtr smethod_24(IntPtr intptr_4, string string_1, uint uint_1)
	{
		if (Class7.delegate4_0 == null)
		{
			Class7.delegate4_0 = (Class7.Delegate4)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Find ".Trim() + "ResourceA"), typeof(Class7.Delegate4));
		}
		return Class7.delegate4_0(intptr_4, string_1, uint_1);
	}

	// Token: 0x0600019C RID: 412 RVA: 0x0000F258 File Offset: 0x0000D458
	private static IntPtr pxNluOfojT(IntPtr intptr_4, uint uint_1, uint uint_2, uint uint_3)
	{
		if (Class7.delegate5_0 == null)
		{
			Class7.delegate5_0 = (Class7.Delegate5)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Virtual ".Trim() + "Alloc"), typeof(Class7.Delegate5));
		}
		return Class7.delegate5_0(intptr_4, uint_1, uint_2, uint_3);
	}

	// Token: 0x0600019D RID: 413 RVA: 0x0000F2B4 File Offset: 0x0000D4B4
	private static int smethod_25(IntPtr intptr_4, IntPtr intptr_5, [In] [Out] byte[] byte_2, uint uint_1, out IntPtr intptr_6)
	{
		if (Class7.delegate6_0 == null)
		{
			Class7.delegate6_0 = (Class7.Delegate6)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Write ".Trim() + "Process ".Trim() + "Memory"), typeof(Class7.Delegate6));
		}
		return Class7.delegate6_0(intptr_4, intptr_5, byte_2, uint_1, out intptr_6);
	}

	// Token: 0x0600019E RID: 414 RVA: 0x0000F31C File Offset: 0x0000D51C
	private static int smethod_26(IntPtr intptr_4, int int_6, int int_7, ref int int_8)
	{
		if (Class7.delegate7_0 == null)
		{
			Class7.delegate7_0 = (Class7.Delegate7)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Virtual ".Trim() + "Protect"), typeof(Class7.Delegate7));
		}
		return Class7.delegate7_0(intptr_4, int_6, int_7, ref int_8);
	}

	// Token: 0x0600019F RID: 415 RVA: 0x0000F378 File Offset: 0x0000D578
	private static IntPtr smethod_27(uint uint_1, int int_6, uint uint_2)
	{
		if (Class7.delegate8_0 == null)
		{
			Class7.delegate8_0 = (Class7.Delegate8)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Open ".Trim() + "Process"), typeof(Class7.Delegate8));
		}
		return Class7.delegate8_0(uint_1, int_6, uint_2);
	}

	// Token: 0x060001A0 RID: 416 RVA: 0x0000F3D0 File Offset: 0x0000D5D0
	private static int smethod_28(IntPtr intptr_4)
	{
		if (Class7.delegate9_0 == null)
		{
			Class7.delegate9_0 = (Class7.Delegate9)Marshal.GetDelegateForFunctionPointer(Class7.GetProcAddress(Class7.smethod_29(), "Close ".Trim() + "Handle"), typeof(Class7.Delegate9));
		}
		return Class7.delegate9_0(intptr_4);
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x000028FF File Offset: 0x00000AFF
	private static IntPtr smethod_29()
	{
		if (Class7.intptr_1 == IntPtr.Zero)
		{
			Class7.intptr_1 = Class7.LoadLibrary("kernel ".Trim() + "32.dll");
		}
		return Class7.intptr_1;
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0000F428 File Offset: 0x0000D628
	private static byte[] qeClcPlveD(string string_1)
	{
		byte[] array;
		using (FileStream fileStream = new FileStream(string_1, FileMode.Open, FileAccess.Read, FileShare.Read))
		{
			int num = 0;
			int i = (int)fileStream.Length;
			array = new byte[i];
			while (i > 0)
			{
				int num2 = fileStream.Read(array, num, i);
				num += num2;
				i -= num2;
			}
		}
		return array;
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x00002935 File Offset: 0x00000B35
	internal static byte[] smethod_30(Stream stream_0)
	{
		return ((MemoryStream)stream_0).ToArray();
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0000F488 File Offset: 0x0000D688
	private static byte[] smethod_31(byte[] byte_2)
	{
		Stream stream = new MemoryStream();
		SymmetricAlgorithm symmetricAlgorithm = Class7.smethod_7();
		symmetricAlgorithm.Key = new byte[]
		{
			84,
			201,
			123,
			120,
			249,
			54,
			236,
			204,
			42,
			116,
			205,
			203,
			80,
			70,
			200,
			36,
			229,
			69,
			239,
			179,
			145,
			218,
			81,
			220,
			85,
			115,
			155,
			26,
			180,
			132,
			171,
			41
		};
		symmetricAlgorithm.IV = new byte[]
		{
			17,
			111,
			219,
			203,
			211,
			67,
			197,
			141,
			169,
			168,
			180,
			169,
			150,
			100,
			159,
			13
		};
		CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
		cryptoStream.Write(byte_2, 0, byte_2.Length);
		cryptoStream.Close();
		return Class7.smethod_30(stream);
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000F4F4 File Offset: 0x0000D6F4
	private byte[] method_2()
	{
		return null;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0000F4F4 File Offset: 0x0000D6F4
	private byte[] method_3()
	{
		return null;
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x00002942 File Offset: 0x00000B42
	private byte[] method_4()
	{
		int length = "{11111-22222-20001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0000295D File Offset: 0x00000B5D
	private byte[] method_5()
	{
		int length = "{11111-22222-20001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x00002978 File Offset: 0x00000B78
	private byte[] method_6()
	{
		int length = "{11111-22222-30001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AA RID: 426 RVA: 0x00002993 File Offset: 0x00000B93
	private byte[] method_7()
	{
		int length = "{11111-22222-30001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AB RID: 427 RVA: 0x000029AE File Offset: 0x00000BAE
	internal byte[] method_8()
	{
		int length = "{11111-22222-40001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AC RID: 428 RVA: 0x000029C9 File Offset: 0x00000BC9
	internal byte[] method_9()
	{
		int length = "{11111-22222-40001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AD RID: 429 RVA: 0x000029E4 File Offset: 0x00000BE4
	internal byte[] method_10()
	{
		int length = "{11111-22222-50001-00001}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AE RID: 430 RVA: 0x000029FF File Offset: 0x00000BFF
	internal byte[] method_11()
	{
		int length = "{11111-22222-50001-00002}".Length;
		return new byte[]
		{
			1,
			2
		};
	}

	// Token: 0x060001AF RID: 431 RVA: 0x00002A1A File Offset: 0x00000C1A
	internal static object smethod_32(Class7.Class10 class10_0)
	{
		return class10_0.method_0();
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x00002A25 File Offset: 0x00000C25
	internal static void smethod_33(Stream stream_0, long long_2)
	{
		stream_0.Position = long_2;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x00002A34 File Offset: 0x00000C34
	internal static long smethod_34(Stream stream_0)
	{
		return stream_0.Length;
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x00002A3F File Offset: 0x00000C3F
	internal static object smethod_35(Class7.Class10 class10_0, int int_6)
	{
		return class10_0.cYoyBkdYbx(int_6);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x00002A4E File Offset: 0x00000C4E
	internal static void smethod_36(Class7.Class10 class10_0)
	{
		class10_0.method_2();
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x00002A59 File Offset: 0x00000C59
	internal static void smethod_37(Array array_0)
	{
		Array.Reverse(array_0);
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x00002A64 File Offset: 0x00000C64
	internal static object smethod_38(Assembly assembly_1)
	{
		return assembly_1.GetName();
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x00002A6F File Offset: 0x00000C6F
	internal static object smethod_39(AssemblyName assemblyName_0)
	{
		return assemblyName_0.GetPublicKeyToken();
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00002A7A File Offset: 0x00000C7A
	internal static object smethod_40()
	{
		return Class7.smethod_7();
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x00002A81 File Offset: 0x00000C81
	internal static void smethod_41(SymmetricAlgorithm symmetricAlgorithm_0, CipherMode cipherMode_0)
	{
		symmetricAlgorithm_0.Mode = cipherMode_0;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x00002A90 File Offset: 0x00000C90
	internal static object smethod_42(SymmetricAlgorithm symmetricAlgorithm_0, byte[] byte_2, byte[] byte_3)
	{
		return symmetricAlgorithm_0.CreateDecryptor(byte_2, byte_3);
	}

	// Token: 0x060001BA RID: 442 RVA: 0x00002AA3 File Offset: 0x00000CA3
	internal static object smethod_43()
	{
		return new MemoryStream();
	}

	// Token: 0x060001BB RID: 443 RVA: 0x00002AAA File Offset: 0x00000CAA
	internal static void smethod_44(Stream stream_0, byte[] byte_2, int int_6, int int_7)
	{
		stream_0.Write(byte_2, int_6, int_7);
	}

	// Token: 0x060001BC RID: 444 RVA: 0x00002AC1 File Offset: 0x00000CC1
	internal static void smethod_45(CryptoStream cryptoStream_0)
	{
		cryptoStream_0.FlushFinalBlock();
	}

	// Token: 0x060001BD RID: 445 RVA: 0x00002ACC File Offset: 0x00000CCC
	internal static object smethod_46(Stream stream_0)
	{
		return Class7.smethod_30(stream_0);
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00002AD7 File Offset: 0x00000CD7
	internal static void smethod_47(Stream stream_0)
	{
		stream_0.Close();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00002AE2 File Offset: 0x00000CE2
	internal static object smethod_48(Assembly assembly_1)
	{
		return assembly_1.EntryPoint;
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x00002AED File Offset: 0x00000CED
	internal static bool smethod_49(MethodInfo methodInfo_0, MethodInfo methodInfo_1)
	{
		return methodInfo_0 == methodInfo_1;
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x00002AFC File Offset: 0x00000CFC
	internal static bool smethod_50()
	{
		return null == null;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x00002B02 File Offset: 0x00000D02
	internal static object smethod_51()
	{
		return null;
	}

	// Token: 0x04000133 RID: 307
	private static bool bool_0 = false;

	// Token: 0x04000134 RID: 308
	private static bool bool_1;

	// Token: 0x04000135 RID: 309
	internal static RSACryptoServiceProvider rsacryptoServiceProvider_0;

	// Token: 0x04000136 RID: 310
	private static int int_0;

	// Token: 0x04000137 RID: 311
	private static object object_0;

	// Token: 0x04000138 RID: 312
	private static byte[] byte_0;

	// Token: 0x04000139 RID: 313
	private static int int_1;

	// Token: 0x0400013A RID: 314
	private static int int_2;

	// Token: 0x0400013B RID: 315
	internal static Class7.Delegate2 delegate2_0;

	// Token: 0x0400013C RID: 316
	private static int int_3;

	// Token: 0x0400013D RID: 317
	private static int int_4;

	// Token: 0x0400013E RID: 318
	[Class7.Attribute0(typeof(Class7.Attribute0.Class8<object>[]))]
	private static bool bool_2;

	// Token: 0x0400013F RID: 319
	internal static Hashtable hashtable_0;

	// Token: 0x04000140 RID: 320
	private static Class7.Delegate4 delegate4_0;

	// Token: 0x04000141 RID: 321
	private static IntPtr intptr_0;

	// Token: 0x04000142 RID: 322
	internal static Assembly assembly_0 = typeof(Class7).Assembly;

	// Token: 0x04000143 RID: 323
	private static IntPtr intptr_1;

	// Token: 0x04000144 RID: 324
	private static Class7.Delegate7 delegate7_0;

	// Token: 0x04000145 RID: 325
	private static Class7.Delegate6 delegate6_0;

	// Token: 0x04000146 RID: 326
	private static int[] int_5;

	// Token: 0x04000147 RID: 327
	private static List<string> list_0;

	// Token: 0x04000148 RID: 328
	private static Class7.Delegate9 delegate9_0;

	// Token: 0x04000149 RID: 329
	private static Dictionary<int, int> dictionary_0;

	// Token: 0x0400014A RID: 330
	private static IntPtr intptr_2;

	// Token: 0x0400014B RID: 331
	private static Class7.Delegate5 delegate5_0;

	// Token: 0x0400014C RID: 332
	private static string[] string_0;

	// Token: 0x0400014D RID: 333
	internal static Class7.Delegate2 delegate2_1;

	// Token: 0x0400014E RID: 334
	private static bool bool_3;

	// Token: 0x0400014F RID: 335
	private static SortedList sortedList_0;

	// Token: 0x04000150 RID: 336
	private static bool bool_4;

	// Token: 0x04000151 RID: 337
	private static long long_0;

	// Token: 0x04000152 RID: 338
	private static byte[] byte_1;

	// Token: 0x04000153 RID: 339
	private static Class7.Delegate8 delegate8_0;

	// Token: 0x04000154 RID: 340
	private static uint[] uint_0 = new uint[]
	{
		3614090360U,
		3905402710U,
		606105819U,
		3250441966U,
		4118548399U,
		1200080426U,
		2821735955U,
		4249261313U,
		1770035416U,
		2336552879U,
		4294925233U,
		2304563134U,
		1804603682U,
		4254626195U,
		2792965006U,
		1236535329U,
		4129170786U,
		3225465664U,
		643717713U,
		3921069994U,
		3593408605U,
		38016083U,
		3634488961U,
		3889429448U,
		568446438U,
		3275163606U,
		4107603335U,
		1163531501U,
		2850285829U,
		4243563512U,
		1735328473U,
		2368359562U,
		4294588738U,
		2272392833U,
		1839030562U,
		4259657740U,
		2763975236U,
		1272893353U,
		4139469664U,
		3200236656U,
		681279174U,
		3936430074U,
		3572445317U,
		76029189U,
		3654602809U,
		3873151461U,
		530742520U,
		3299628645U,
		4096336452U,
		1126891415U,
		2878612391U,
		4237533241U,
		1700485571U,
		2399980690U,
		4293915773U,
		2240044497U,
		1873313359U,
		4264355552U,
		2734768916U,
		1309151649U,
		4149444226U,
		3174756917U,
		718787259U,
		3951481745U
	};

	// Token: 0x04000155 RID: 341
	private static List<int> list_1;

	// Token: 0x04000156 RID: 342
	private static bool bool_5;

	// Token: 0x04000157 RID: 343
	private static object object_1;

	// Token: 0x04000158 RID: 344
	private static IntPtr intptr_3;

	// Token: 0x04000159 RID: 345
	private static long long_1;

	// Token: 0x0400015A RID: 346
	private static bool bool_6;

	// Token: 0x02000034 RID: 52
	// (Invoke) Token: 0x060001C4 RID: 452
	private delegate void Delegate1(object o);

	// Token: 0x02000035 RID: 53
	internal class Attribute0 : Attribute
	{
		// Token: 0x060001C7 RID: 455 RVA: 0x00002B05 File Offset: 0x00000D05
		public Attribute0(object object_0)
		{
		}

		// Token: 0x02000036 RID: 54
		internal class Class8<T>
		{
		}
	}

	// Token: 0x02000037 RID: 55
	internal class Class9
	{
		// Token: 0x060001C9 RID: 457 RVA: 0x0000F504 File Offset: 0x0000D704
		internal static string smethod_0(string string_0, string string_1)
		{
			byte[] bytes = Encoding.Unicode.GetBytes(string_0);
			byte[] key = new byte[]
			{
				82,
				102,
				104,
				110,
				32,
				77,
				24,
				34,
				118,
				181,
				51,
				17,
				18,
				51,
				12,
				109,
				10,
				32,
				77,
				24,
				34,
				158,
				161,
				41,
				97,
				28,
				118,
				181,
				5,
				25,
				1,
				88
			};
			byte[] iv = Class7.smethod_9(Encoding.Unicode.GetBytes(string_1));
			MemoryStream memoryStream = new MemoryStream();
			SymmetricAlgorithm symmetricAlgorithm = Class7.smethod_7();
			symmetricAlgorithm.Key = key;
			symmetricAlgorithm.IV = iv;
			CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(bytes, 0, bytes.Length);
			cryptoStream.Close();
			return Convert.ToBase64String(memoryStream.ToArray());
		}
	}

	// Token: 0x02000038 RID: 56
	// (Invoke) Token: 0x060001CC RID: 460
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	internal delegate uint Delegate2(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

	// Token: 0x02000039 RID: 57
	// (Invoke) Token: 0x060001D0 RID: 464
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate3();

	// Token: 0x0200003A RID: 58
	internal struct Struct2
	{
		// Token: 0x0400015B RID: 347
		internal bool bool_0;

		// Token: 0x0400015C RID: 348
		internal byte[] byte_0;
	}

	// Token: 0x0200003B RID: 59
	internal class Class10
	{
		// Token: 0x060001D3 RID: 467 RVA: 0x00002B0D File Offset: 0x00000D0D
		public Class10(Stream stream_0)
		{
			this.binaryReader_0 = new BinaryReader(stream_0);
		}

		// Token: 0x060001D4 RID: 468 RVA: 0x00002B21 File Offset: 0x00000D21
		internal Stream method_0()
		{
			return this.binaryReader_0.BaseStream;
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00002B2E File Offset: 0x00000D2E
		internal byte[] cYoyBkdYbx(int int_0)
		{
			return this.binaryReader_0.ReadBytes(int_0);
		}

		// Token: 0x060001D6 RID: 470 RVA: 0x00002B3C File Offset: 0x00000D3C
		internal int sfXyrUxRgn(byte[] byte_0, int int_0, int int_1)
		{
			return this.binaryReader_0.Read(byte_0, int_0, int_1);
		}

		// Token: 0x060001D7 RID: 471 RVA: 0x00002B4C File Offset: 0x00000D4C
		internal int method_1()
		{
			return this.binaryReader_0.ReadInt32();
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00002B59 File Offset: 0x00000D59
		internal void method_2()
		{
			this.binaryReader_0.Close();
		}

		// Token: 0x0400015D RID: 349
		private BinaryReader binaryReader_0;
	}

	// Token: 0x0200003C RID: 60
	// (Invoke) Token: 0x060001DA RID: 474
	[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = 2)]
	private delegate IntPtr Delegate4(IntPtr hModule, string lpName, uint lpType);

	// Token: 0x0200003D RID: 61
	// (Invoke) Token: 0x060001DE RID: 478
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate5(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

	// Token: 0x0200003E RID: 62
	// (Invoke) Token: 0x060001E2 RID: 482
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate6(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

	// Token: 0x0200003F RID: 63
	// (Invoke) Token: 0x060001E6 RID: 486
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate7(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

	// Token: 0x02000040 RID: 64
	// (Invoke) Token: 0x060001EA RID: 490
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate IntPtr Delegate8(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

	// Token: 0x02000041 RID: 65
	// (Invoke) Token: 0x060001EE RID: 494
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private delegate int Delegate9(IntPtr ptr);

	// Token: 0x02000042 RID: 66
	[Flags]
	private enum Enum1
	{

	}
}
