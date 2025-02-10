using System;

public class Order
{
    public int OrderId { get; private set; }
    public string CustomerName { get; private set; }
    public string OrderDetails { get; private set; }
    public string Status { get; private set; }

    public Order(int orderId, string customerName, string orderDetails)
    {
        OrderId = orderId;
        CustomerName = customerName;
        OrderDetails = orderDetails;
        Status = "Pending";
    }

    public void ProcessOrder()
    {
        Status = "Processed";
        Console.WriteLine($"Order {OrderId} for {CustomerName} has been processed.");
    }
}
public class EmailNotification
{
    private readonly string _recipientEmail;

    public EmailNotification(string recipientEmail)
    {
        _recipientEmail = recipientEmail;
    }

    public void SendOrderConfirmation(Order order)
    {
        string subject = $"Order Confirmation: {order.OrderId}";
        string message = $"Dear {order.CustomerName},\n\nYour order has been processed.\n\nOrder Details:\n{order.OrderDetails}\n\nStatus: {order.Status}";

        SendEmail(subject, message);
    }

    private void SendEmail(string subject, string message)
    {
        Console.WriteLine($"Sending email to {_recipientEmail} with subject '{subject}' and message:\n{message}");
    }
}

public class Program
{
    public static void Main()
    {
        Order order = new Order(orderId: 101, customerName: "Rajvi Patel ", orderDetails: "Product Laptop, Product Mobile");
        order.ProcessOrder(); 

        EmailNotification emailNotification = new EmailNotification(recipientEmail: "patelrajvi@gmail.com");
        emailNotification.SendOrderConfirmation(order);  
    }
}
