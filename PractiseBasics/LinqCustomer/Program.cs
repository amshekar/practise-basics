// for each customer select his name and the names of the products he bought
using System;
using System.Collections.Generic;
using System.Linq;
					
public class LinqCustomer
{
	public static void Main(string[] args)
	{
		var apple = new Product { Name = "Apple" };
		var orange = new Product { Name = "Orange" };
		var bread = new Product { Name = "Bread" };
		var customers = new[] {
			new Customer { Name = "Alexey", Orders = new[] { new Order { Product = apple, Quantity = 10 ,Price=5},
															 new Order { Product = orange, Quantity = 5,Price=6 } }.ToList() },
			new Customer { Name = "Andrey", Orders = new[] { new Order { Product = bread, Quantity = 5,Price=4 },
															 new Order { Product = orange, Quantity = 2 ,Price=3} }.ToList() },
			new Customer { Name = "Alexandr", Orders = new[] { new Order { Product = apple, Quantity = 10 ,Price=2} }.ToList() }
			}.ToList();

		//double inputAmount = Convert.ToDouble(txtAmount.Text);
		//var result = db.tblCustomerOrders
		//	.GroupBy(m => m.CustomerID)
		//	.Select(g => new
		//	{
		//		CustomerID = g.Key,
		//		Sum = g.Sum(m => m.Amount)
		//	})
		//	.Where(m => m.Sum > inputAmount)
		//	.Select(m => m.CustomerID)
		//	.ToList();
		var query = customers.Select(c => new
		{
			name = c.Name,
			count = c.Orders.Count,
			product = string.Join(",", c.Orders.Select(p => p.Product.Name).ToList())
			//product =  c.Orders.ForEach(p=>p.Product.Name)

		});



								 
		foreach (var result in query)
			Console.WriteLine("{0} -> {1},{2}", result.name, result.count, result.product);

		// for each customer select his name and the names of the products he bought


	}


	public class Customer
	{
		public string Name { get; set; }
		public List<Order> Orders { get; set; }
	}
	public class Order
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
	public class Product
	{
		public string Name { get; set; }
	}
}
