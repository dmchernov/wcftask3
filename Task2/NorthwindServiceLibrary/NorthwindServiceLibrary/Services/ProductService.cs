﻿using System.Collections.Generic;
using System.Linq;
using NorthwindModel;
using NorthwindModel.Models;
using NorthwindServiceLibrary.Contracts;

namespace NorthwindServiceLibrary.Services
{
	public class ProductService : IProductService
	{
		public IList<Product> GetAllProducts()
		{
			using (var db = new Northwind())
			{
				db.Configuration.ProxyCreationEnabled = false;

				return db.Products.ToList();
			}
		}
	}
}
