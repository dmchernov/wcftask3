﻿using System;
using System.ServiceModel;
using NUnit.Framework;
using TestProject.Common;
using TestProject.OrderService;

namespace TestProject.OrderServiceTests
{
	public class OrderFaultTest : IOrderServiceCallback
	{
		[Test]
		public void GetOrderExFaultTest()
		{
			var ex = Assert.Catch<FaultException<OrderFault>>(() => { new OrderServiceClient(new InstanceContext(this)).GetOrderEx(-1); });
			Assert.AreEqual(ex.Detail.Message, "Заказ с указанным номером не найден.");
		}

		[Test]
		public void SendOrderToProcessFaultTest()
		{
			var order = new OrdersHelper().AddOrder();

			var service = new OrderServiceClient(new InstanceContext(this));
			var processedOrder = service.SendOrderToProcess(order.OrderID, DateTime.Now);

			var ex = Assert.Catch<FaultException<OrderFault>>(() => { new OrderServiceClient(new InstanceContext(this)).SendOrderToProcess(processedOrder.OrderID, DateTime.Now); });
			Assert.AreEqual(ex.Detail.Message, "Заказ уже находится в обработке или был отправлен покупателю.");

			ex = Assert.Catch<FaultException<OrderFault>>(() => { new OrderServiceClient(new InstanceContext(this)).SendOrderToProcess(processedOrder.OrderID, DateTime.Now.AddDays(-7)); });
			Assert.AreEqual(ex.Detail.Message, "Невозможно отправить заказ задним числом.");
		}

		[Test]
		public void SendOrderToCustomerFaultTest()
		{
			var order = new OrdersHelper().AddOrder();

			var service = new OrderServiceClient(new InstanceContext(this));
			var processedOrder = service.SendOrderToProcess(order.OrderID, DateTime.Now);
			var shippedOrder = service.SendOrderToCustomer(processedOrder.OrderID, DateTime.Now.AddDays(7));

			var ex = Assert.Catch<FaultException<OrderFault>>(() => { new OrderServiceClient(new InstanceContext(this)).SendOrderToCustomer(shippedOrder.OrderID, DateTime.Now.AddDays(10)); });
			Assert.AreEqual(ex.Detail.Message, "Невозможно отправить заказ, не находящийся в обработке.");
		}

		[Test]
		public void UpdateOrderFaultTest()
		{
			var order = new OrdersHelper().AddOrder();

			var service = new OrderServiceClient(new InstanceContext(this));
			var oldId = order.OrderID;
			order.OrderID = -100;

			var ex = Assert.Catch<FaultException<OrderFault>>(() => { service.UpdateOrder(order); });
			Assert.AreEqual(ex.Detail.Message, "Заказ для обновления не найден.");

			order.OrderID = oldId;
			order = service.SendOrderToProcess(order.OrderID, DateTime.Now);

			ex = Assert.Catch<FaultException<OrderFault>>(() => { service.UpdateOrder(order); });
			Assert.AreEqual(ex.Detail.Message, "Нельзя изменить отправленный или находящийся в обработке заказ.");
		}

		[Test]
		public void DeleteOrderFaultTest()
		{
			var order = new OrdersHelper().AddOrder();

			var service = new OrderServiceClient(new InstanceContext(this));

			var ex = Assert.Catch<FaultException<OrderFault>>(() => { service.DeleteOrder(-1); });
			Assert.AreEqual(ex.Detail.Message, "Заказ с указанным номером не зарегистрирован.");

			order = service.SendOrderToProcess(order.OrderID, DateTime.Now);
			order = service.SendOrderToCustomer(order.OrderID, DateTime.Now);

			ex = Assert.Catch<FaultException<OrderFault>>(() => { service.DeleteOrder(order.OrderID); });
			Assert.AreEqual(ex.Detail.Message, "Невозможно удалить отправленный заказ.");
		}

		public void SendInformationMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}
