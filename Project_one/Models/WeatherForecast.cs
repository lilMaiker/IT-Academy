﻿using System;

namespace Project_one.Models
{
    public class WeatherForecast : IWeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string Summary { get; set; }
        public Enums.Weekday Weekday { get; set; }

        public override string ToString()
        {
            return $"Дата: {Date}, Температутра: {TemperatureCelsius}";
        }
    }
}
