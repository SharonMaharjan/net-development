using ExerciseDI_FeedReader;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;



//serviceProvider = services.BuildServiceProvider(true);

//FeedService serviceParts = new FeedService(serviceProvider.GetServices<IFeedService>().ElementAt(0));
//serviceParts.GetFeed();

namespace ExerciseDI_FeedReader { 
internal class Program
{
		private static IServiceProvider _serviceProvider;
		static void Main(string[] args)
		{
			RegisterServices();
			FeedService servicePodcast = new FeedService(_serviceProvider.GetServices<IFeedService>().ElementAt(0));
			FeedService serviceBlog = new FeedService(_serviceProvider.GetServices<IFeedService>().ElementAt(1));
			FeedService serviceYoutube = new FeedService(_serviceProvider.GetServices<IFeedService>().ElementAt(2));

			string feed = servicePodcast.GetFeed();
			Console.WriteLine(feed);
			feed = serviceYoutube.GetFeed();
			Console.WriteLine(feed);

			DisposeServices();
			Console.WriteLine("Press any key");
			Console.ReadKey();
			//FeedService servicePodcast = new FeedService(new YouTubeFeedReader());
			//servicePodcast.GetFeed();
			//string feed = servicePodcast.GetFeed();
			//Console.ReadLine();
		}
		private static void RegisterServices()
		{
			var services = new ServiceCollection();

			XmlReaderSettings settings = new XmlReaderSettings();
			settings.IgnoreWhitespace = true;


			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load("config\\di_configuration.xml");
			XmlNode root = xmlDocument.DocumentElement;

			XmlNodeList nodeList = root.SelectNodes("implementation");
			foreach (XmlNode service in nodeList)
			{
				services.AddSingleton(Type.GetType(service.FirstChild.InnerText),
					Type.GetType(service.LastChild.InnerText));

			}

			//register interface using factory that return implementation
			services.AddSingleton<IFeedService, YouTubeFeedReader>();
			services.AddSingleton<IFeedService, BlogFeedReader>();
			services.AddSingleton<IFeedService, PodcastFeedReader>();

			_serviceProvider = services.BuildServiceProvider(true);
		}

		private static void DisposeServices()
        {
			if (_serviceProvider != null)
            {
				return;
            }
			if(_serviceProvider is IDisposable)
            {
				_serviceProvider = null;
            }
        }

		
}
}