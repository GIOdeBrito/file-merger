using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileMerger
{
	internal class Utis
	{
		public static string RemoveComments (string str)
		{
			// Gostaria de agradecer ao  ChatGPT por me fornecer esta loucura aqui
			return Regex.Replace(str, @"(/\*([^*]|[\r\n]|(\*+([^*/]|[\r\n])))*\*+/)|(//.*)", string.Empty, RegexOptions.Multiline);
		}

		public static string[] ShatterString (string str)
		{
			string[] _str = str.Split(new[] { ' ', '\t', '\n', '\r' },
			StringSplitOptions.RemoveEmptyEntries);
			return _str;
		}

		public static string[] GetStringByLine (string str)
		{
			string[] _str = str.Split(new[] { '\n', }, StringSplitOptions.RemoveEmptyEntries);
			return _str;
		}

		public static string GenerateRandomHex ()
		{
			Random random = new Random();

			int length = 12;
			string hexString = string.Empty;

			hexString = string.Concat(Enumerable.Range(0, length).Select(item =>
				random.Next(16).ToString("X")));

			return hexString;
		}
	}
}
