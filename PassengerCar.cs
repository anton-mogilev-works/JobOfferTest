using System;

namespace JobOfferTest_20_06_2022
{
    public class PassengerCar : Autmobile
    {
        // Предел перевозки пассажиров
        public int PassangersLimit { set; get; } = int.MinValue;
        
        // Количество перевозимых пассажиров
        public int PassangersCount { set; get; } = int.MinValue;
                
        // Коэффициент снижения запаса хода в зависимости от количества пассажиров
        public const float cruisingRangeReductionFactor = 0.06f;

        public override bool CheckAuto()
        {
            bool result = base.CheckAuto();

            // Проверка на превышение предела перевозки пассажиров
            if (PassangersCount > PassangersLimit)
            {
                Console.WriteLine("Превышен предел перевозки пассажиров");
            }

            return result;
        }

        public override float CalculateCruisingRange()
        {
            // Досчитываем запас хода с учетом коэффициента потери запаса хода от количества пассажиров
            return base.CalculateCruisingRange() * (1 - cruisingRangeReductionFactor * PassangersCount);
        }

        // Вычисление времени необходимого на преодоление заданного расстояния
        // public override float CalculateCruisingTime(float range)
        // {
        //     // Если автомобиль не готов - результат неизвестен
        //     if(CheckAuto() == false)
        //     {
        //         return float.NaN;
        //     }

        //     // Если заданное расстояние превышает запас хода - результат неизвестен
        //     if(range > CalculateCruisingRange())
        //     {
        //         return float.NaN;
        //     }

        //     return range / Speed;
        // }
    }
}
