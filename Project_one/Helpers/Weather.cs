using Project_one.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_one.Helpers
{
    public class Weather
    {
        public int ID { get; set; }
        public int Temp { get; set; }

        /// <summary>
        /// Добавление новогой погоды в БД
        /// </summary>
        /// <param name="weatherForecast"></param>
        /// <returns></returns>
        public bool Add(WeatherForecast weatherForecast)
        {
            // Вставить данные о погоде в таблицу БД
            return true;
        }
    }

    public class WeatherReport
    {
        /// <summary>
        /// Отчет по погоде
        /// </summary>
        public void GenerateReport(WeatherForecast weatherForecast)
        {
            // Генерация отчета по погоде ... за месяц и etc 
        }
    }
}
