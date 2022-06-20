using System;

namespace JobOfferTest_20_06_2022
{
    public class Truck : Autmobile
    {
        // Предел веса перевозимого груза, кг
        public float CargoLimit { set; get; } = float.MinValue;
        // Вес перевозимого груза, кг
        public float CargoWeight { set; get; } = float.MinValue;

        // Коэффициент снижения запаса хода в зависимости от груза 0.04 / 200 = .0002
        public const float cruisingRangeReductionFactor = .0002f;
        
        // Проверка готовности автомобиля
        public override bool CheckAuto()
        {
            bool result = base.CheckAuto();

            // Проверка на превышение предела веса перевозимого груза
            if (CargoWeight > CargoLimit)
            {
                Console.WriteLine("Превышен предел веса перевозимого груза");
                result = false;
            }

            return result;
        }

        public override float CalculateCruisingRange()
        {
            // Досчитываем запас хода с учетом коэффициента потери запаса хода от веса груза
            return base.CalculateCruisingRange() * (1 - cruisingRangeReductionFactor * CargoWeight);
        }

        // Вычисление времени необходимого на преодоление заданного расстояния
        // public float CalculateCruisingTime(float range)
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