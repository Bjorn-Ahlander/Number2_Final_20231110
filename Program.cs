
using System.Diagnostics;

List<Item> items = new List<Item>();
Console.WriteLine("Enter q to show list");

goto Found;

Found:

while (true)
{
    // Get Category
    Console.Write("Input Category: ");
    string categoryInput = Console.ReadLine();
    if (categoryInput.ToLower().Trim() == "q")
    {
        break;
    }
    // Get Item Name
    Console.Write("Input Produkt: ");
    string productInput = Console.ReadLine();
    if (productInput.ToLower().Trim() == "q")
    {
        break;
    }

    // Get Price
    Console.Write("Input Price: ");
    string priceInput = Console.ReadLine();
    if (priceInput.ToLower().Trim() == "q")
    {
        break;
    }

    bool isValid = int.TryParse(priceInput, out int price);
    if (isValid)
    {
        //try
        //{
        Item product = new Item(categoryInput, productInput, price);
        items.Add(product);
        Console.WriteLine("Produkten är tillagd på listan");
        //}
        //catch (Exception e)
        //{
        //    Console.WriteLine("Something went wrong.");
        //}
    }

}

Console.WriteLine("---------------");
Console.WriteLine("Lista sorterad på Pris");

List<Item> sorterad = items.OrderBy(item => item.Price).ToList();
Console.WriteLine(("Kategori").PadRight(20)
         + "Vara".PadRight(20) + "Pris");

foreach (var item in sorterad)
{
    Console.WriteLine(item.Category.CategoryName.PadRight(20) + item.Vara.PadRight(20) + item.Price);
}

int sumOfAllPrices = items.Sum(item => item.Price);
Console.WriteLine("                               Summa alla priser:" + sumOfAllPrices);

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Vill registrera mer?: j/n");
string xx = Console.ReadLine();

if (xx == "j")
{
    goto Found;
}

else
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("hejdå! - programmet avslutas");
}

class Item
{
    public Item(string category, string product, int price)
    {
        //Category = category;
        Category = new Category(category);
        Vara = product;
        Price = price;
    }

    //public string Category { get; set; }
    public Category Category { get; set; }
    public string Vara { get; set; }
    public int Price { get; set; }
}

class Category
{
    public Category(string categoryName)
    {
        CategoryName = categoryName;
    }

    public string CategoryName { get; set; }
}