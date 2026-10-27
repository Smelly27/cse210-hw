public class Fraction
{
    private int _top;
    private int _bottom;

    // Default constructor
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor with two parameters
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom != 0 ? bottom : 1;
    }

    // Getters and setters
    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0)
        {
            _bottom = bottom;
        }
    }

    // Return fraction as a string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Return fraction as a decimal
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}