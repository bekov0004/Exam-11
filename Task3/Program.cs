List<Customer> customers = new List<Customer> {
    new Customer {
        Name = "Alice",
        Email = "alice@example.com",
        Age = 25,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 100.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 50.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 75.00M }
        }
    },
    new Customer {
        Name = "Bob",
        Email = "bob@example.com",
        Age = 35,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount =
                150.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 125.00M }
        }
    },
    new Customer {
        Name = "Charlie",
        Email = "charlie@example.com",
        Age = 30,
        PurchaseHistory = new List<Purchase> {
            new Purchase { Date = new DateTime(2022, 1, 1), Amount = 75.00M },
            new Purchase { Date = new DateTime(2022, 2, 1), Amount = 125.00M },
            new Purchase { Date = new DateTime(2022, 3, 1), Amount = 150.00M }
        }
    }
};

var query = (
    from c in customers
    select new
    {
        Name = c.Name,
        Email = c.Email,
        Age = c.Age,
        TotalAmount = c.PurchaseHistory.Select(x=>x.Amount).Sum()
    }).OrderByDescending(x=>x.TotalAmount).Take(5).ToList();

foreach (var q in query)
{
    Console.WriteLine($"Name = {q.Name} Email = {q.Email} Age = {q.Age} TotalAmount = {q.TotalAmount}");
}
class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public List<Purchase> PurchaseHistory { get; set; }
}
class Purchase
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }
}