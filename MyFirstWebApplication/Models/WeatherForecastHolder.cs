using System.Collections.Generic;
using System;

namespace MyFirstWebApplication.Models
{
    /// <summary>
    /// Объект на базе класса WeatherForecastHolder, будет хранить список показателей температуры
    /// </summary>
    public class WeatherForecastHolder
    {
        // Коллекция для хранения показателей температуры
        private List<WeatherForecast> _values;

        public WeatherForecastHolder()
        {
            // Инициализируем коллекцию для хранения показателей температуры
            _values = new List<WeatherForecast>();
        }

        /// <summary>
        /// Добавить новый показатель температуры
        /// </summary>
        /// <param name="dateTime">Дата фиксации показателя температуры</param>
        /// <param name="temperatureC">Показатель температуры</param>
        public void Add(DateTime dateTime, int temperatureC)
        {
            WeatherForecast forecast = new WeatherForecast();
            forecast.TemperatureC = temperatureC;
            forecast.Date = dateTime;

            _values.Add(forecast);
        }

        /// <summary>
        /// Обновить показатель температуры
        /// </summary>
        /// <param name="date">Дата фиксации показателя температуры</param>
        /// <param name="temperatureC">Новый показатель температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Update(DateTime date, int temperatureC)
        {
            foreach (WeatherForecast item in _values)
            {
                if (item.Date == date)
                {
                    item.TemperatureC = temperatureC;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Получить показатели температуры за временной период
        /// </summary>
        /// <param name="dateFrom">Начальная дата</param>
        /// <param name="dateTo">Конечная дата</param>
        /// <returns>Коллекция показателей температуры</returns>
        public List<WeatherForecast> Get(DateTime dateFrom, DateTime dateTo)
        {
            List<WeatherForecast> list = new List<WeatherForecast>();
            foreach (WeatherForecast item in _values)
            {
                if (item.Date >= dateFrom && item.Date <= dateTo)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        /// <summary>
        /// Удаляет показатель температуры на указанную дату
        /// </summary>
        /// <param name="date">Дата фиксации показателя температуры</param>
        /// <returns>Результат выполнения операции</returns>
        public bool Delete(DateTime date)
        {
            // Найдем элемент, который соответствует переданной дате
            WeatherForecast forecastToDelete = _values.FirstOrDefault(f => f.Date == date);

            // Если элемент найден, удаляем его из коллекции
            if (forecastToDelete != null)
            {
                _values.Remove(forecastToDelete);
                return true;
            }

            // Если не нашли, возвращаем false
            return false;
        }
    }
}
