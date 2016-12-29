using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using NorthwindServiceLibrary.Contracts;

namespace NorthwindServiceFactories
{
	public class ProductServiceHostFactory : ServiceHostFactory
	{
		public ServiceHost GetServiceHost(Uri[] baseAddresses)
		{
			return CreateServiceHost(typeof(IProductService), baseAddresses);
		}

		protected override ServiceHost CreateServiceHost (Type serviceType, Uri[] baseAddresses)
		{
			var host = base.CreateServiceHost(serviceType, baseAddresses);
			var contract = ContractDescription.GetContract(typeof(IProductService));

			var httpAddress = baseAddresses.FirstOrDefault(a => a.Scheme == "http");
			if (httpAddress != null)
			{
				var netHttpbinding = new NetHttpBinding {MaxReceivedMessageSize = Int32.MaxValue};
				var netHttpendpoint = new ServiceEndpoint(contract, netHttpbinding, new EndpointAddress(httpAddress));
				host.AddServiceEndpoint(netHttpendpoint);
			}

			var tcpAddress = baseAddresses.FirstOrDefault(a => a.Scheme == "net.tcp");
			if (tcpAddress != null)
			{
				var netTcpBinding = new NetTcpBinding {MaxReceivedMessageSize = Int32.MaxValue};
				var netTcpEndpoint = new ServiceEndpoint(contract, netTcpBinding, new EndpointAddress(tcpAddress));
				host.AddServiceEndpoint(netTcpEndpoint);
			}

			var serviceMetadataBehavior = host.Description.Behaviors.Find<ServiceMetadataBehavior>();
			if (serviceMetadataBehavior == null)
			{
				serviceMetadataBehavior = new ServiceMetadataBehavior();
				host.Description.Behaviors.Add(serviceMetadataBehavior);
			}

			serviceMetadataBehavior.HttpGetEnabled = true;

			return host;
		}
	}
}