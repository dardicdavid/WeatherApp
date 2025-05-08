namespace WeatherApp.Models;

public class WeatherResponse
{
    public int queryCost { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public string resolvedAddress { get; set; }
    public string address { get; set; }
    public string timezone { get; set; }
    public double tzoffset { get; set; }
    public string description { get; set; }
    public Days[] days { get; set; }
    public object[] alerts { get; set; }
    public Stations stations { get; set; }
    public CurrentConditions currentConditions { get; set; }
}

public class Days
{
    public string datetime { get; set; }
    public int datetimeEpoch { get; set; }
    public double tempmax { get; set; }
    public double tempmin { get; set; }
    public double temp { get; set; }
    public double feelslikemax { get; set; }
    public double feelslikemin { get; set; }
    public double feelslike { get; set; }
    public double dew { get; set; }
    public double humidity { get; set; }
    public double precip { get; set; }
    public double precipprob { get; set; }
    public double precipcover { get; set; }
    public string[] preciptype { get; set; }
    public double snow { get; set; }
    public double snowdepth { get; set; }
    public double windgust { get; set; }
    public double windspeed { get; set; }
    public double winddir { get; set; }
    public double pressure { get; set; }
    public double cloudcover { get; set; }
    public double visibility { get; set; }
    public double solarradiation { get; set; }
    public double solarenergy { get; set; }
    public double uvindex { get; set; }
    public double severerisk { get; set; }
    public string sunrise { get; set; }
    public int sunriseEpoch { get; set; }
    public string sunset { get; set; }
    public int sunsetEpoch { get; set; }
    public double moonphase { get; set; }
    public string conditions { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
    public string[] stations { get; set; }
    public string source { get; set; }
    public Hours[] hours { get; set; }
}

public class Hours
{
    public string datetime { get; set; }
    public int datetimeEpoch { get; set; }
    public double temp { get; set; }
    public double feelslike { get; set; }
    public double humidity { get; set; }
    public double dew { get; set; }
    public double precip { get; set; }
    public double precipprob { get; set; }
    public double snow { get; set; }
    public double snowdepth { get; set; }
    public string[]? preciptype { get; set; }
    public double windgust { get; set; }
    public double windspeed { get; set; }
    public double winddir { get; set; }
    public double pressure { get; set; }
    public double visibility { get; set; }
    public double cloudcover { get; set; }
    public double solarradiation { get; set; }
    public double solarenergy { get; set; }
    public double uvindex { get; set; }
    public double severerisk { get; set; }
    public string conditions { get; set; }
    public string icon { get; set; }
    public string[] stations { get; set; }
    public string source { get; set; }
}

public class Stations
{
    public EGWU EGWU { get; set; }
    public EGLC EGLC { get; set; }
    public EGLL EGLL { get; set; }
    public D5621 D5621 { get; set; }
    public F6665 F6665 { get; set; }
}

public class EGWU
{
    public double distance { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int useCount { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public double contribution { get; set; }
}

public class EGLC
{
    public double distance { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int useCount { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public double contribution { get; set; }
}

public class EGLL
{
    public double distance { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int useCount { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public double contribution { get; set; }
}

public class D5621
{
    public double distance { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int useCount { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public double contribution { get; set; }
}

public class F6665
{
    public double distance { get; set; }
    public double latitude { get; set; }
    public double longitude { get; set; }
    public int useCount { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int quality { get; set; }
    public double contribution { get; set; }
}

public class CurrentConditions
{
    public string datetime { get; set; }
    public int datetimeEpoch { get; set; }
    public double temp { get; set; }
    public double feelslike { get; set; }
    public double humidity { get; set; }
    public double dew { get; set; }
    public double? precip { get; set; }
    public double precipprob { get; set; }
    public double snow { get; set; }
    public double snowdepth { get; set; }
    public object? preciptype { get; set; }
    public double? windgust { get; set; }
    public double windspeed { get; set; }
    public double winddir { get; set; }
    public double pressure { get; set; }
    public double visibility { get; set; }
    public double cloudcover { get; set; }
    public double solarradiation { get; set; }
    public double solarenergy { get; set; }
    public double uvindex { get; set; }
    public string conditions { get; set; }
    public string icon { get; set; }
    public string[] stations { get; set; }
    public string source { get; set; }
    public string sunrise { get; set; }
    public int sunriseEpoch { get; set; }
    public string sunset { get; set; }
    public int sunsetEpoch { get; set; }
    public double moonphase { get; set; }
}

