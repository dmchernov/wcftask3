﻿using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using NorthwindServiceLibrary.Contracts;

namespace NorthwindServiceFactories
{
	public class CategoryServiceHostFactory : ServiceHostFactory
	{
		public ServiceHost GetServiceHost(Uri[] baseAddresses)
		{
			return CreateServiceHost(typeof(ICategoryService), baseAddresses);
		}

		protected override ServiceHost CreateServiceHost (Type serviceType, Uri[] baseAddresses)
		{
			var host = base.CreateServiceHost(serviceType, baseAddresses);
			var contract = ContractDescription.GetContract(typeof(ICategoryService));

			var httpAddresses = baseAddresses.Where(a => a.Scheme == "http").ToList();
			httpAddresses.ForEach(httpAddress =>
			{
				var netHttpbinding = new NetHttpBinding { MaxReceivedMessageSize = Int32.MaxValue, TransferMode = TransferMode.Streamed };
				var netHttpendpoint = new ServiceEndpoint(contract, netHttpbinding, new EndpointAddress(new Uri(httpAddress, "categories.svc")));
				host.AddServiceEndpoint(netHttpendpoint);
			});

			var tcpAddresses = baseAddresses.Where(a => a.Scheme == "net.tcp").ToList();
			tcpAddresses.ForEach(tcpAddress =>
			{
				var netTcpBinding = new NetTcpBinding { MaxReceivedMessageSize = Int32.MaxValue, TransferMode = TransferMode.Streamed };
				var netTcpEndpoint = new ServiceEndpoint(contract, netTcpBinding, new EndpointAddress(new Uri(tcpAddress, "categories.svc")));
				host.AddServiceEndpoint(netTcpEndpoint);
			});

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