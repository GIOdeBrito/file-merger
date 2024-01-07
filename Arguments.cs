using System;
using System.Collections.Generic;
using System.IO;

namespace FileMerger
{
	internal class Arguments
	{
		private static bool prolixo = true;
		private static bool defloop = true;
		private static string configpath = "./config.xml";
		private static string fileext = null;

		public static void HandleArguments (string[] args)
		{
			foreach(string argument in args)
			{
				// Caso algum dos argumentos atribua um valor
				string[] argval = argument.Split('=');

				switch(argval[0])
				{
					case "--help":
					case "-h": {
						ShowHelp();
					}
					break;
					case "--version":
					case "-v": {
						ShowVersion();
					}
					break;
					case "--clean": {
						prolixo = false;
					}
					break;
					case "--config": {
						configpath = argval[1];
					}
					break;
					case "--no-loop": {
						defloop = false;
					}
					break;
					case "--ext": {
						fileext = argval[1];
					}
					break;
				}
			}
		}

		private static void ShowHelp ()
		{
			Console.WriteLine("Need help? I got you, mate.\n");

			Console.WriteLine("GIO's File Merger");
			Console.WriteLine("\n  A program to, well, merge files together.\n");
			Console.WriteLine("Usage: FileMerger.dll [arguments]\n");
			Console.WriteLine("Options");
			Console.WriteLine("  -v|--version\t\tPrints the program's version.");
			Console.WriteLine("  -h|--help\t\tShows the help section of the program.");
			Console.WriteLine("  --clean\t\tMinimize the quantity of print-to-console messages.");
			Console.WriteLine("  --config=[path]\tDefines the path of the configuration xml file to use.");
			Console.WriteLine("  --ext=[extension]\tSpecifies an extension for the final merged file.");
			Console.WriteLine("  --no-loop\t\tThe program will execute only a single time and end right away.");

			System.Environment.Exit(1);
		}

		private static void ShowVersion ()
		{
			Console.WriteLine("v" + "1.0.5");
			System.Environment.Exit(1);
		}

		public static bool isVerbose ()
		{
			return prolixo;
		}

		public static bool toLoop ()
		{
			return defloop;
		}

		public static string XMLPath ()
		{
			return configpath;
		}

		public static string Extension ()
		{
			return fileext;
		}
	}
}
