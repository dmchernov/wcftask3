﻿using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace NorthwindServiceFactories
{
	public static class ServiceHostHelper
	{
		public static ServiceHost ConfigureServiceHost(ServiceHost host, ContractDescription description, string endpointName, bool useStreaming = false)
		{
			var httpAddresses = host.BaseAddresses.Where(a => a.Scheme == "http").ToList();
			httpAddresses.ForEach(httpAddress =>
			{
				var netHttpBinding = new NetHttpBinding { MaxReceivedMessageSize = Int32.MaxValue, TransferMode = useStreaming ? TransferMode.Streamed : TransferMode.Buffered };
				var netHttpEndpoint = new ServiceEndpoint(description, netHttpBinding, new EndpointAddress(new Uri(httpAddress, endpointName)));
				host.AddServiceEndpoint(netHttpEndpoint);
			});

			var tcpAddresses = host.BaseAddresses.Where(a => a.Scheme == "net.tcp").ToList();
			tcpAddresses.ForEach(tcpAddress =>
			{
				var netTcpBinding = new NetTcpBinding { MaxReceivedMessageSize = Int32.MaxValue, TransferMode = useStreaming ? TransferMode.Streamed : TransferMode.Buffered };
				var netTcpEndpoint = new ServiceEndpoint(description, netTcpBinding, new EndpointAddress(new Uri(tcpAddress, endpointName)));
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
