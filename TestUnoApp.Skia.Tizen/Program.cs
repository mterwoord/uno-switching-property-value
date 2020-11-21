using Tizen.Applications;
using Uno.UI.Runtime.Skia;

namespace TestUnoApp.Skia.Tizen
{
	class Program
	{
		static void Main(string[] args)
		{
			var host = new TizenHost(() => new TestUnoApp.App(), args);
			host.Run();
		}
	}
}
