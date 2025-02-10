using System;
public class Room: HotelService
{
    public string Name { get; set; }
    public string Location { get; set; }


    public Room(string name, string location)
    {
        Name = name;
        Location = location;
    }
    public virtual decimal CalculateTotalPrice(int nights)
    {
        return 100 * nights;
    }
    public virtual void GetRoomDetails()
    {
        Console.WriteLine($"Room Name: {Name}\nLocation: {Location}");
    }

    public override string GetServiceType()
    {
        return "Abstraction performed";
    }
}

// Derived class StandardRoom
public class StandardRoom : Room
{
    public string Amenities { get; set; }

    public StandardRoom(string name, string location, string amenities)
     : base(name, location)
    {
        Amenities = amenities;
    }

    // Overriding GetRoomDetails
    public override void GetRoomDetails()
    {
        base.GetRoomDetails();
        Console.WriteLine($"Amenities: {Amenities}");
    }

    public override decimal CalculateTotalPrice(int nights)
    {
        decimal basePrice = base.CalculateTotalPrice(nights);
        return basePrice + 50; 
    }
}

public class SuiteRoom : Room
{
    public string LuxuryFeatures { get; set; }

    public SuiteRoom(string name, string location, string luxuryFeatures)
     : base(name, location)
    {
        LuxuryFeatures = luxuryFeatures;
    }
    public override void GetRoomDetails()
    {
        base.GetRoomDetails();
        Console.WriteLine($"Luxury Features: {LuxuryFeatures}");
    }
    public override decimal CalculateTotalPrice(int nights)
    {
        decimal basePrice = base.CalculateTotalPrice(nights);
        return basePrice + 200; 
    }
}

// Abstract class HotelService
public abstract class HotelService
{
    public abstract string GetServiceType(); 
    public void PrintHotelPolicy()
    {
        Console.WriteLine("Hotel policy: No smoking, No pets.");
    }
}

public interface IHotelOperations
{
    void BookRoom(int roomNumber);
    void CheckoutRoom(int roomNumber);
    void DisplayAvailableRooms();
}

public class HotelManager : IHotelOperations
{
    void IHotelOperations.BookRoom(int roomNumber)
    {
        Console.WriteLine($"Booking room {roomNumber}");
    }

    void IHotelOperations.CheckoutRoom(int roomNumber)
    {
        Console.WriteLine($"Checkout room {roomNumber}");
    }

    void IHotelOperations.DisplayAvailableRooms()
    {
        Console.WriteLine("Displaying available rooms...");
    }
}
public sealed class BookingManager
{
    public void ProcessBooking(int roomNumber, string customerName)
    {
        Console.WriteLine($"Processing booking for room {roomNumber} under customer {customerName}");
    }
}

public partial class HotelOperations
{
    public void BookRoom(int roomNumber)
    {
        Console.WriteLine($"Room {roomNumber} has been booked.");
    }

    public void CheckoutRoom(int roomNumber)
    {
        Console.WriteLine($"Room {roomNumber} has been checked out.");
    }
}
public partial class HotelOperations
{
    public void UpdateAvailability()
    {
        Console.WriteLine("Updating room availability...");
    }

    public void DisplayAvailableRooms()
    {
        Console.WriteLine("Displaying all available rooms...");
    }
}

class Program
{
    static void Main()
    {
        Room standardRoom = new StandardRoom("Standard Room", "1st Floor", "Wi-Fi, TV");
        Room suiteRoom = new SuiteRoom("Suite Room", "Top Floor", "Jacuzzi, Mini Bar");

        standardRoom.GetRoomDetails();
        Console.WriteLine($"Total Price for 3 nights: {standardRoom.CalculateTotalPrice(3)}\n");

        suiteRoom.GetRoomDetails();
        Console.WriteLine($"Total Price for 3 nights: {suiteRoom.CalculateTotalPrice(3)}\n");

        IHotelOperations hotelManager = new HotelManager();
        hotelManager.BookRoom(101);
        hotelManager.CheckoutRoom(101);
        hotelManager.DisplayAvailableRooms();

        BookingManager bookingManager = new BookingManager();
        bookingManager.ProcessBooking(101, "Alice");

        HotelOperations hotelOperations = new HotelOperations();
        hotelOperations.BookRoom(101);
        hotelOperations.CheckoutRoom(101);
        hotelOperations.UpdateAvailability();
        hotelOperations.DisplayAvailableRooms();
    }
}
