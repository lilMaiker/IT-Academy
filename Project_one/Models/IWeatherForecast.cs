using System;

namespace Project_one.Models
{
    public interface IWeatherForecast
    {
        DateTimeOffset Date { get; set; }
        string Summary { get; set; }
        int TemperatureCelsius { get; set; }
        Enums.Weekday Weekday { get; set; }
    }
}