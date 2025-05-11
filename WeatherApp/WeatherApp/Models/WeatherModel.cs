namespace WeatherApp.Models;

public class WeatherModel
{   
    public string City { get; set; }
    public string resolvedAddress { get; set; }
    public string address { get; set; }
    public WeatherDays[] days { get; set; }
    public WeatherCurrentConditions currentConditions { get; set; }
}

public class WeatherDays
{
    public string datetime { get; set; }
    public double tempmax { get; set; }
    public double tempmin { get; set; }
    public double temp { get; set; }
    public double precipprob { get; set; }
    public string[] preciptype { get; set; }
    public double snow { get; set; }
    public double windspeed { get; set; }
    public string sunrise { get; set; }
    public string sunset { get; set; }
    public string conditions { get; set; }
    public string icon { get; set; }
    public WeatherHours[] hours { get; set; }
}

public class WeatherHours
{
    public string datetime { get; set; }
    public double temp { get; set; }
    public double humidity { get; set; }
    public double precipprob { get; set; }
    public string[]? preciptype { get; set; }
    public double snow { get; set; }
    public double windspeed { get; set; }
    public string conditions { get; set; }
    public string icon { get; set; }
}


public class WeatherCurrentConditions
{
    public string datetime { get; set; }
    public double temp { get; set; }
    public double precipprob { get; set; }
    public object? preciptype { get; set; }
    public double snow { get; set; }
    public double windspeed { get; set; }
    public string conditions { get; set; }
    public string icon { get; set; }
    public string sunrise { get; set; }
    public string sunset { get; set; }
}

