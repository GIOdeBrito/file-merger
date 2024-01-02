using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FileMerger
{
	internal class Load
	{
		public static void GreetingMessage ()
		{
			Console.WriteLine("===============================================================");
			Console.WriteLine("\tGIO's File Merger");
			Console.WriteLine("\tv 1.0");
			Console.WriteLine("===============================================================");
			Console.WriteLine("");

			XML.ReadXMLConfigs();
			SelectFiles();
		}

		public static void SelectFiles ()
		{
			List<string> files = new List<string>();

			using(StreamReader reader = new StreamReader(@"./include.txt"))
			{
				string line = string.Empty;
				while((line = reader.ReadLine()) != null)
				{
					files.Add(line);
				}
			}

			Console.WriteLine("[100%] Files selected");

			UnifyFiles(files.ToArray());
		}

		public static void UnifyFiles (string[] files)
		{
			string finalstr = string.Empty;

			foreach(string file in files)
			{
				if(File.Exists(file))
				{
					string content = string.Empty;
					content += $"// --------------------------------\n";
					content += $"//\tARQUIVO: {file}";
					content += $"\n// --------------------------------\n\n";
					content += File.ReadAllText(file);

					finalstr += $"{content}\n\n";
				}
			}

			Console.WriteLine("[100%] Files merged in memory");

			if(XML.configs.nocomments)
			{
				Console.WriteLine("[100%] Removed comments from code");
				finalstr = Utis.RemoveComments(finalstr);
			}

			if(XML.configs.nolinebreak)
			{
				Console.WriteLine("[100%] Removed line breaks");
				finalstr = string.Join(" ", finalstr.Split(new[] { '\r', '\n' },
					StringSplitOptions.RemoveEmptyEntries));
			}

			// Experimental, portanto não utilizado
			if(XML.configs.obfuscate)
			{
				Console.WriteLine("[100%] Código obfuscado");
				finalstr = MakeStringArr(finalstr);
			}

			string dir = XML.configs.dir;
			string name = XML.configs.name;

			File.WriteAllText($"{dir}/{name}.js", finalstr);

			Console.WriteLine("[100%] Final file written on disk");
			Console.ReadKey();
		}

		public static string MakeStringArr (string str)
		{
			string[] _nova_str = str.Split(new[] { ' ', '\t', '\n', '\r' },
			StringSplitOptions.RemoveEmptyEntries);

			/*foreach(string _str in _nova_str)
			{
				Console.WriteLine(_str);
			}*/

			string neo_unified = UniteString(_nova_str);

			return neo_unified;
		}

		public static string UniteString (string[] arr)
		{
			string[] varType = {
				"const",
				"let",
				"var"
			};

			// Palavras-chave do JavaScript para separar da seguinte
			string[] keywords = {
				"function",
				"void",
				"await",
				"return",
				"else",
				"case",
				"default",
				"typeof",
				"throw",
			};

			string str = string.Empty;

			for(int i = 0; i < arr.Length; i++)
			{
				bool isVar = false;
				bool isKeyword = false;

				string _word = arr[i];
				string _tmp_word = _word;

				if(keywords.Contains(_tmp_word))
				{
					isKeyword = true;
				}
				if(varType.Contains(_tmp_word))
				{
					isVar = true;
				}

				if(isVar || isKeyword)
				{
					_tmp_word = $"{_tmp_word} ";
				}

				str += _tmp_word;
			}

			return str;
		}
	}
}
