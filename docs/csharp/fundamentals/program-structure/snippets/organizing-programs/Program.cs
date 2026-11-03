using MyApp.Services;
using MyApp.Payments;
using MyApp.Inventory;

var service = new OrderService();
var order = service.CreateOrder("Widget", 3, 9.99m);
Console.WriteLine(service.FormatSummary(order));

var processor = new CreditCardProcessor();
processor.ProcessPayment(order.Total);

var inventory = new InventoryService();
Console.WriteLine($"Stock level for Widget: {inventory.GetStockLevel("Widget")}");
