using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using NorthwindServiceFactories;
using NorthwindServiceLibrary.Contracts;
using NorthwindServiceLibrary.Services;
using Topshelf;

namespace NorthwindWindowService
{
	public class NorthwindWinService : ServiceControl
	{
		private static readonly Uri httpBaseAddress = new Uri("http://localhost/winsvc/northwind/");
		private static readonly Uri netTcpBaseAddress = new Uri("net.tcp://localhost:15432/winsvc/northwind/");

	private ServiceHost _ordersHost = new ServiceHost(typeof(OrderService), new Uri(httpBaseAddress, "orders"), new Uri(netTcpBaseAddress, "orders"));
		private ServiceHost _productsHost = new ServiceHost(typeof(ProductService), new Uri(httpBaseAddress, "products"), new Uri(netTcpBaseAddress, "products"));
		private ServiceHost _categoriesHost = new ServiceHost(typeof(CategoryService), new Uri(httpBaseAddress, "categories"), new Uri(netTcpBaseAddress, "categories"));

		public bool Start(HostControl hostControl)
		{
			_ordersHost = ServiceHostHelper.ConfigureServiceHost(_ordersHost, ContractDescription.GetContract(typeof(IOrderService)), /*"orders.svc"*/String.Empty);
			_productsHost = ServiceHostHelper.ConfigureServiceHost(_productsHost, ContractDescription.GetContract(typeof(IProductService)), String.Empty/*"products.svc"*/);
			_categoriesHost = ServiceHostHelper.ConfigureServiceHost(_categoriesHost, ContractDescription.GetContract(typeof(ICategoryService)), /*"categories.svc"*/String.Empty, true);

			_ordersHost.BeginOpen(OnOpen, _ordersHost);
			_productsHost.BeginOpen(OnOpen, _productsHost);
			_categoriesHost.BeginOpen(OnOpen, _categoriesHost);
			//_ordersHost.Open();
			//_productsHost.Open();
			//_categoriesHost.Open();

			return true;
		}

		public bool Stop(HostControl hostControl)
		{
			_ordersHost.BeginClose(OnClose, _ordersHost);
			_productsHost.BeginClose(OnClose, _productsHost);
			_categoriesHost.BeginClose(OnClose, _categoriesHost);

			//_ordersHost.Close();
			//_productsHost.Close();
			//_categoriesHost.Close();

			return true;
		}

		private void OnOpen(IAsyncResult result)
		{
			ServiceHost service = (ServiceHost)result.AsyncState;
			service.EndOpen(result);
		}

		private void OnClose (IAsyncResult result)
		{
			ServiceHost service = (ServiceHost)result.AsyncState;
			service.EndClose(result);
			((IDisposable)service).Dispose();
		}
	}
}
