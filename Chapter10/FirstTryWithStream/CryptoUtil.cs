using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace FirstTryWithStream
{
	public class CryptoUtil
	{
		public static byte[] EncryptAes256(byte[] bytes, byte[] key)
		{
			using var aes = new RijndaelManaged
			{
				Key = CreateDeriveBytes(key, 32),
			};
			aes.GenerateIV();

			using var encryptor = aes.CreateEncryptor();
			using var encryptedStream = new MemoryStream();
			// Do not replace implicit using expression, when CryptoStream aws disposed, final block deliver to memory stream.
			using (var cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write))
			{
				cryptoStream.Write(bytes);
			}
			var encrypted = encryptedStream.ToArray();

			return aes.IV.Concat(encrypted).ToArray();
		}

		//public static string DecryptAes256(string encrypted, string key)
		//{
		//	var decryptAes256 = DecryptAes256(Convert.FromBase64String(encrypted), Encoding.UTF8.GetBytes(key));
		//	return Encoding.UTF8.GetString(decryptAes256);
		//}

		public static byte[] DecryptAes256(byte[] encrypted, byte[] key)
		{
			using var rijndeal = new RijndaelManaged
			{
				Key = CreateDeriveBytes(key, 32)
			};
			var iv = encrypted.Take(16).ToArray();
			rijndeal.IV = iv;

			var encryptedBytes = encrypted.Skip(16).ToArray();
			using var memoryStream = new MemoryStream();
			using var decryptor = rijndeal.CreateDecryptor();
			using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
			{
				cryptoStream.Write(encryptedBytes);
			}

			return memoryStream.ToArray();
		}

		private static byte[] CreateDeriveBytes(byte[] keyBytes, int size)
		{
			using var sha512 = SHA512.Create();
			var saltBytes = sha512.ComputeHash(keyBytes);
			using var derivBytes = new Rfc2898DeriveBytes(keyBytes, saltBytes, 65536);
			return derivBytes.GetBytes(size);
		}
	}
}