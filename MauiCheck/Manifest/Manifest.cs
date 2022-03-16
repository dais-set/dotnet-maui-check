using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DotNetCheck.Manifest
{
	public partial class Manifest
	{
		internal const string DefaultManifestUrl = "maui.manifest.json";
		internal const string PreviewManifestUrl = "maui-previlew.manifest.json";
		internal const string MainManifestUrl = "maui-main.manifest.json";

		public static Task<Manifest> FileFromResource(string resource)
		{
			var resourceStream = Assembly.GetAssembly(typeof(FilePermissions)).GetManifestResourceStream(resource);

			using(var reader = new StreamReader(resourceStream, Encoding.UTF8))
			{
				var file = reader.ReadToEnd();
				return FromJson(file);
			}
		}

		public static Task<Manifest> FromFileOrUrl(string fileOrUrl)
		{
			if (fileOrUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase))
				return FromUrl(fileOrUrl);

			return FromFile(fileOrUrl);
		}

		public static async Task<Manifest> FromFile(string filename)
		{
			var json = await System.IO.File.ReadAllTextAsync(filename);
			return await FromJson(json);
		}

		public static async Task<Manifest> FromUrl(string url)
		{
			var http = new HttpClient();
			var json = await http.GetStringAsync(url);

			return await FromJson(json);
		}

		public static async Task<Manifest> FromJson(string json)
		{
			var m = JsonConvert.DeserializeObject<Manifest>(json, new JsonSerializerSettings {
				TypeNameHandling = TypeNameHandling.Auto
			});

			await m?.Check?.MapVariables();

			return m;
		}

		[JsonProperty("check")]
		public Check Check { get; set; }
	}
}
