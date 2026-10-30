using System;

public class TravelItinerary
{
    private string _departureDate;
    private string _returnDate;
    private string _transportation;
    private string _accommodation;
    private decimal _budget;

    public TravelItinerary(
        string departureDate,
        string returnDate,
        string transportation,
        string accommodation,
        decimal budget)
    {
        _departureDate = departureDate;
        _returnDate = returnDate;
        _transportation = transportation;
        _accommodation = accommodation;
        _budget = budget;
    }

    public string GetDepartureDate()
    {
        return _departureDate;
    }

    public string GetReturnDate()
    {
        return _returnDate;
    }

    public string GetTransportation()
    {
        return _transportation;
    }

    public string GetAccommodation()
    {
        return _accommodation;
    }

    public decimal GetBudget()
    {
        return _budget;
    }

    public void UpdateTransportation(string transportation)
    {
        _transportation = transportation;
    }

    public void UpdateAccommodation(string accommodation)
    {
        _accommodation = accommodation;
    }

    public void UpdateBudget(decimal budget)
    {
        if (budget >= 0)
        {
            _budget = budget;
        }
    }

    public void DisplayItinerary()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("           TRAVEL ITINERARY");
        Console.WriteLine("========================================");
        Console.WriteLine($"Departure Date: {_departureDate}");
        Console.WriteLine($"Return Date: {_returnDate}");
        Console.WriteLine($"Transportation: {_transportation}");
        Console.WriteLine($"Accommodation: {_accommodation}");
        Console.WriteLine($"Travel Budget: ${_budget:F2}");
    }
}