using Project_one.Models;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Project_one
{
    public class Program
    {
        public static List<Models.WeatherForecast> ListWeather = new List<WeatherForecast>();

        static void Main(string[] args)
        {
            var weatherForecast = new WeatherForecast
            {
                Date = DateTime.Parse("2019-08-01"),
                TemperatureCelsius = 25,
                Summary = "Hot"
            };

            string jsonString = JsonSerializer.Serialize(weatherForecast);

            Console.WriteLine(jsonString);

            SetWeather(Enums.Weekday.Friday, 25, "Hot", DateTime.Now, pList: ListWeather);
            ShowFirstWeather();

            //TASK 4

            Weather weather1 = new ItalianWeather();
            weather1 = new WeatherSouth(weather1);
            Console.WriteLine("Название: {0}", weather1.Name);
            Console.WriteLine("Температура: {0}", weather1.GetTempNow());

            Weather weather2 = new BulgerianWeather();
            weather2 = new WeatherSouth(weather2);
            Console.WriteLine("Название: {0}", weather2.Name);
            Console.WriteLine("Температура: {0}", weather2.GetTempNow());

            Weather weather3 = new ItalianWeather();
            weather3 = new WatherWest(weather3);
            Console.WriteLine("Название: {0}", weather3.Name);
            Console.WriteLine("Температура: {0}", weather3.GetTempNow());

            Console.ReadLine();
        }

        /// <summary>
        /// Установить погоду на неделю
        /// </summary>
        /// <param name="pWeekday"></param>
        /// <param name="pTemperatureCelsius"></param>
        /// <param name="pSummary"></param>
        /// <param name="pDate"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetWeather(Models.Enums.Weekday pWeekday, int pTemperatureCelsius, string pSummary, DateTime pDate, List<Models.WeatherForecast> pList)
        {
            if (pSummary is null)
                throw new ArgumentNullException(nameof(pSummary));

            pList.Add(new WeatherForecast() { Weekday = pWeekday, Date = pDate, Summary = pSummary, TemperatureCelsius = pTemperatureCelsius });
        }

        /// <summary>
        /// Вывести первую позицию из списка
        /// </summary>
        public static void ShowFirstWeather()
        {
            Console.WriteLine(ListWeather[0].ToString());
        }
    }

    abstract class Weather
    {
        public Weather(string n)
        {
            this.Name = n;
        }
        public string Name { get; protected set; }
        public abstract int GetTempNow();
    }

    class ItalianWeather : Weather
    {
        public ItalianWeather() : base("Погода в Италии")
        { }
        public override int GetTempNow()
        {
            return 10;
        }
    }
    class BulgerianWeather : Weather
    {
        public BulgerianWeather()
            : base("Погода в Болгарии")
        { }
        public override int GetTempNow()
        {
            return 8;
        }
    }

    abstract class WeatherDecorator : Weather
    {
        protected Weather weather;
        public WeatherDecorator(string n, Weather weather) : base(n)
        {
            this.weather = weather;
        }
    }

    class WatherWest : WeatherDecorator
    {
        public WatherWest(Weather p)
            : base(p.Name + ", западнее", p)
        { }

        public override int GetTempNow()
        {
            return weather.GetTempNow() + 3;
        }
    }

    class WeatherSouth : WeatherDecorator
    {
        public WeatherSouth(Weather p)
            : base(p.Name + ", севернее", p)
        { }

        public override int GetTempNow()
        {
            return weather.GetTempNow() + 5;
        }
    }


}
