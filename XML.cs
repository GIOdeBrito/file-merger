using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FileMerger
{
	internal class XML
	{
		public static Config? configs = null;

		public static void ReadXMLConfigs ()
		{
			try
			{
				XmlSerializer xml = new XmlSerializer(typeof(G_Merger));

				using(StreamReader reader = new StreamReader(@"./config.xml"))
				{
					var _xmldata = (G_Merger) xml.Deserialize(reader);

					if(_xmldata.conf is null)
					{
						Console.WriteLine("'<Config>' tag in configuration file is null");
					}

					configs = _xmldata.conf;
				}
			}
			catch(IOException ex)
			{
				Console.WriteLine($"Exception when reading file. \n{ex.Message}");
			}
			catch(InvalidOperationException ex)
			{
				Console.WriteLine($"Exception when deserializing file. \n{ex.Message}");
			}
		}
	}
}

[XmlRoot("G_Merger")]
public class G_Merger
{
	[XmlElement("Config")]
	public Config conf { get; set; }
}

public class Config
{
	public string dir {get; set; }
	public string name {get; set; }
	public bool nocomments {get; set; }
	public bool nolinebreak {get; set; }
	public bool obfuscate {get; set; }
}
