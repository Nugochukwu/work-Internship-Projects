using System;
using System.Collections.Generic;
using System.Linq;
public class Inventory
{
    //Charger-Electronics-Price-Quantity
    //Dress-Clothing-Price-Quantity
    //ThingsFallApart-Books-Price-Quantity

    private Dictionary<int, Item> _items;//Dictionary for Item LookUp.
    public IReadOnlyDictionary<int, Item> Items => _items;

    public Inventory()
    {
        _items = new Dictionary<int, Item>();
    }

    public void AddItem(Item item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        if(_items.ContainsKey(item.Id)) 
        {
            Console.WriteLine($"An item with ID {item.Id} already exists. Updating quantity.");
            _items[item.Id].Quantity += item.Quantity;
        }
        else
        {
            _items.Add(item.Id, item);
        }
    }


    public bool RemoveItem(int itemId, int quantityToRemove) 
    {
        if (_items.TryGetValue(itemId, out Item item))
        {
            if(item.Quantity >= quantityToRemove)
            {
                item.Quantity -= quantityToRemove;
                if (item.Quantity == 0)
                {
                    _items.Remove(itemId);
                }
                Console.WriteLine($"Item {item.Name} removed from Inventory.");
                return true;
            }
            else
            {
                Console.WriteLine($"Not enough {item.Name} in stock. Available: {item.Quantity}.");
                return false;
            }
        }
        else
        {
            Console.WriteLine($"Item with Id {itemId} not found in inventory.");
            return false;
        }
    }


    public Item GetItemById(int itemId)
    {
        _items.TryGetValue(itemId, out Item item);
        return item;
    }


    public decimal GetTotalInventoryValue()
    {
        return _items.Values.Sum(item => item.Price * item.Quantity);
    }
}
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    
    //Constructor to Initialize Item Object.
    public Item(int id, string name, string category, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Category = category;//Electronics,Clothing,Books
        Price = price;
        Quantity = quantity;
    }
}

public class Product
{
    private string item;
    private double price;
    private int discount;
   
    public int Discount
    {
        set { discount = value; }
        get { return discount; }
    }
    public double Price
    {   get{ return price; }
        set { price = value;}
    }
    
    public void PrintDetails()
    {
        Console.WriteLine($"{price - (price*discount/100)}");
    }
}
public class ShoppingCart
{
    //addItem
    //removeItem
    //CalculateTotal
}

public class Program
{
    public static void Main()
    {
        Product product = new Product();
        product.Price = 100;
        product.Discount = 5;
        product.PrintDetails();


        Inventory shopInventory = new Inventory();

        Item charger = new Item(1, "Charger","Electronics",3000.00m,5);

        shopInventory.AddItem(charger);

        Console.WriteLine("--- Inventory after initial setup ---");
        foreach (var itemEntry in shopInventory.Items)
        {
            Item item = itemEntry.Value;
            Console.WriteLine($"ID: {item.Id}, Name: {item.Name},Category: {item.Category}, Price: {item.Price:C}, Quantity: {item.Quantity}");
        }
        //Orders
    }
}
