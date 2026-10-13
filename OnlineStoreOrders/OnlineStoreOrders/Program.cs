using System;
using System.Collections.Generic;
using System.Linq;

class Order
{
    public int Id { get; set; }
    public string CustomerName { get; set; } = "";
    public string ProductName { get; set; } = "";
    public int Quantity { get; set; }
    public string Status { get; set; } = "Создан";
}

class Program
{
    static List<Order> orders = new List<Order>();

    static void Main()
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine("======================================");
            Console.WriteLine(" Система обработки заказов магазина");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Создать новый заказ");
            Console.WriteLine("2. Просмотреть список заказов");
            Console.WriteLine("3. Изменить статус заказа");
            Console.WriteLine("0. Выход");
            Console.WriteLine();
            Console.Write("Выберите действие: ");

            string? choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateOrder();
                    break;

                case "2":
                    ShowOrders();
                    break;

                case "3":
                    ChangeOrderStatus();
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Некорректный пункт меню.");
                    Pause();
                    break;
            }
        }
    }

    static void CreateOrder()
    {
        Console.Clear();
        Console.WriteLine("=== Создание нового заказа ===");

        Console.Write("Введите имя клиента: ");
        string customerName = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(customerName))
        {
            Console.WriteLine("Имя клиента не может быть пустым.");
            Pause();
            return;
        }

        Console.Write("Введите название товара: ");
        string productName = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(productName))
        {
            Console.WriteLine("Название товара не может быть пустым.");
            Pause();
            return;
        }

        Console.Write("Введите количество товара: ");

        if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
        {
            Console.WriteLine("Количество товара указано неверно.");
            Pause();
            return;
        }

        Order order = new Order
        {
            Id = orders.Count + 1,
            CustomerName = customerName,
            ProductName = productName,
            Quantity = quantity,
            Status = "Создан"
        };

        orders.Add(order);

        Console.WriteLine();
        Console.WriteLine($"Заказ №{order.Id} успешно создан.");
        Pause();
    }

    static void ShowOrders()
    {
        Console.Clear();
        Console.WriteLine("=== Список заказов ===");

        if (orders.Count == 0)
        {
            Console.WriteLine("Заказы отсутствуют.");
            Pause();
            return;
        }

        Console.WriteLine($"Всего заказов: {orders.Count}");
        Console.WriteLine();

        foreach (Order order in orders)
        {
            Console.WriteLine($"Заказ №{order.Id}");
            Console.WriteLine($"Клиент: {order.CustomerName}");
            Console.WriteLine($"Товар: {order.ProductName}");
            Console.WriteLine($"Количество: {order.Quantity}");
            Console.WriteLine($"Статус: {order.Status}");
            Console.WriteLine("--------------------------------------");
        }

        Pause();
    }

    static void ChangeOrderStatus()
    {
        Console.Clear();
        Console.WriteLine("=== Изменение статуса заказа ===");

        if (orders.Count == 0)
        {
            Console.WriteLine("Заказы отсутствуют.");
            Pause();
            return;
        }

        Console.Write("Введите номер заказа: ");

        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Некорректный номер заказа.");
            Pause();
            return;
        }

        Order? order = orders.FirstOrDefault(o => o.Id == id);

        if (order == null)
        {
            Console.WriteLine("Заказ с таким номером не найден.");
            Pause();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Выберите новый статус:");
        Console.WriteLine("1. Подтвержден");
        Console.WriteLine("2. Передан на склад");
        Console.WriteLine("3. Передан в доставку");
        Console.WriteLine("4. Выполнен");
        Console.WriteLine("5. Отменен");
        Console.Write("Выбор: ");

        string? statusChoice = Console.ReadLine();

        switch (statusChoice)
        {
            case "1":
                order.Status = "Подтвержден";
                break;
            case "2":
                order.Status = "Передан на склад";
                break;
            case "3":
                order.Status = "Передан в доставку";
                break;
            case "4":
                order.Status = "Выполнен";
                break;
            case "5":
                order.Status = "Отменен";
                break;
            default:
                Console.WriteLine("Некорректный статус.");
                Pause();
                return;
        }

        Console.WriteLine();
        Console.WriteLine($"Статус заказа №{order.Id} изменен на: {order.Status}");
        Pause();
    }

    static void Pause()
    {
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter для возврата в меню...");
        Console.ReadLine();
    }
}