using System;


public class Room
{
    public int RoomNumber { get; set; }
    public string Type { get; set; }
    public decimal PricePerNight { get; set; }
    private bool IsAvailable; 
    public Room(int roomNumber, string type, decimal pricePerNight)
    {
        RoomNumber = roomNumber;
        Type = type;
        PricePerNight = pricePerNight;
        IsAvailable = true; 

    }

        public bool CheckAvailability()
    {
        return IsAvailable;
    }

    public void SetAvailability(bool availability)
    {
        IsAvailable = availability;
    }

    ~Room()
    {
        Console.WriteLine($"Room {RoomNumber} ({Type}) has been vacated.");
    }
}

public class HotelBookingSystem
{
    static void Main(string[] args)
    {
        Room room1 = new Room(101, "Standard", 100.00m);
        Room room2 = new Room(102, "Standard", 100.00m);
        Room room3 = new Room(103, "Standard", 100.00m);
        Room suite1 = new Room(201, "Suite", 200.00m);
        Room suite2 = new Room(202, "Suite", 200.00m);

        Console.WriteLine($"Room {room1.RoomNumber} Available: {room1.CheckAvailability()}");
        Console.WriteLine($"Room {suite1.RoomNumber} Available: {suite1.CheckAvailability()}");

        room1.SetAvailability(false);
        Console.WriteLine($"Room {room1.RoomNumber} Available: {room1.CheckAvailability()}");

        room1.SetAvailability(true);
        Console.WriteLine($"Room {room1.RoomNumber} Available: {room1.CheckAvailability()}");

        
    }
}