using System;

namespace JobOfferTest_20_06_2022
{
    public abstract class Autmobile
    {
        // Объём топливного бака, л
        public float FuelTankVolume { set; get; } = float.MinValue;
        // Запас топлива в баке, л
        public float FuelVolume { set; get; } = float.MinValue;
        // Средний расход топлива л/сек
        public float AverageFuelConsumption { set; get; } = float.MinValue;
        // Скорость м/с
        public float Speed { set; get; } = float.MinValue;

        // Проверка готовности автомобиля
        public virtual bool CheckAuto()
        {
            bool result = true;

            // Проверка на превышение объёма топлива вместимости топливного бака
            if (this.FuelVolume > FuelTankVolume)
            {
                Console.WriteLine("Запас топлива не может превышать ёмкость топливного бака");
                result = false;
            }            

            return result;
        }

        // Подсчёт запаса хода автомобиля
        public virtual float CalculateCruisingRange()
        {
            // Если автомобиль не готов - результат неизвестен
            if(CheckAuto() == false)
            {
                return float.NaN;
            }

            // Запас хода рассчитываем по формуле:
            // Запас_хода = скорость * ( объём_топлива / расх )
            return Speed * ( FuelVolume / AverageFuelConsumption );
        }

        // Вычисление времени необходимого на преодоление заданного расстояния
        public virtual float CalculateCruisingTime(float range)
        {
            // Если автомобиль не готов - результат неизвестен
            if(CheckAuto() == false)
            {
                return float.NaN;
            }

            // Если заданное расстояние превышает запас хода - результат неизвестен
            if(range > CalculateCruisingRange())
            {
                return float.NaN;
            }

            return range / Speed;
        }
    }
}
