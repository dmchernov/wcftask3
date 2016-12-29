using System;
using System.ServiceModel;
using NorthwindServiceFactories;
using Topshelf;

namespace NorthwindWindowService
{
	public class NorthwindWinService : ServiceControl
	{
		private readonly Uri httpServiceBaseAddress = new Uri("http://localhost:805/winservice/northwind");
		private readonly Uri netTcpServiceBaseAddress = new Uri("net.tcp://localhost:15432/winservice/northwind");

		ServiceHost _ordersHost, _productsHost, _categoriesHost;
		public bool Start(HostControl hostControl)
		{
			_ordersHost = new OrderServiceHostFactory().GetServiceHost(new[] { httpServiceBaseAddress, netTcpServiceBaseAddress });
			_productsHost = new ProductServiceHostFactory().GetServiceHost(new[] { httpServiceBaseAddress, netTcpServiceBaseAddress });
			_categoriesHost = new CategoryServiceHostFactory().GetServiceHost(new[] { httpServiceBaseAddress, netTcpServiceBaseAddress });

			_ordersHost.Open();
			_productsHost.Open();
			_categoriesHost.Open();

			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			throw new NotImplementedException();
		}
	}
}
