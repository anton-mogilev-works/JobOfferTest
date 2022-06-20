using System;
using System.IO;
using Microsoft.Data.Sqlite;

namespace JobOfferTest_20_06_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            // Задание №1 - создание и проверка работы классов автомобилей и расчетов их параметров
            // Создаём экземпляр класса грузового автомобиля
            Truck truck = new Truck()
            {
                FuelTankVolume = 500,
                FuelVolume = 450,
                AverageFuelConsumption = 10,
                Speed = 40,
                CargoLimit = 400,
                CargoWeight = 200,
            };

            // Создаём экземпляр класса пассажирского автомобиля
            PassengerCar passengerCar = new PassengerCar()
            {
                FuelTankVolume = 100,
                FuelVolume = 90,
                AverageFuelConsumption = 2,
                Speed = 100,
                PassangersLimit = 5,
                PassangersCount = 4
            };

            // Создаём экземпляр класса спортивного автомобиля
            SportCar sportCar = new SportCar()
            {
                FuelTankVolume = 500,
                FuelVolume = 450,
                AverageFuelConsumption = 10,
                Speed = 40,
            };

            //Запуск проверки
            Console.WriteLine(
                "Запас хода грузового автомобиля: " + truck.CalculateCruisingRange() + " м."
            );
            Console.WriteLine(
                "Время преодоления дистанции 1000 м. для грузового автомобиля: "
                    + truck.CalculateCruisingTime(1000)
                    + " cек."
            );
            Console.WriteLine();
            Console.WriteLine(
                "Запас хода легкового автомобиля: " + passengerCar.CalculateCruisingRange() + " м."
            );
            Console.WriteLine(
                "Время преодоления дистанции 1000 м. для легкового автомобиля: "
                    + passengerCar.CalculateCruisingTime(1000)
                    + " cек."
            );
            Console.WriteLine();
            Console.WriteLine(
                "Запас хода спортивного автомобиля: " + sportCar.CalculateCruisingRange() + " м."
            );
            Console.WriteLine(
                "Время преодоления дистанции 1000 м. для спортивного автомобиля: "
                    + sportCar.CalculateCruisingTime(1000)
                    + " cек."
            );

            Console.WriteLine();
            Console.WriteLine("************************************");

            // Задача №2 - работа с базами данных
            File.Delete("database.sqlite3");
            using var connection = new SqliteConnection("Data Source=database.sqlite3");
            connection.Open();

            SqliteCommand command = new SqliteCommand();
            command.Connection = connection;
            command.CommandText =
                "CREATE TABLE Customers(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL)";
            command.ExecuteNonQuery();

            command.CommandText =
                "INSERT INTO Customers (Name) Values ('Max'), ('Pavel'), ('Ivan'), ('Leonid')";
            command.ExecuteNonQuery();

            command.CommandText =
                "CREATE TABLE Orders(Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, CustomerId INTEGER NOT NULL UNIQUE)";
            command.ExecuteNonQuery();

            command.CommandText = "INSERT INTO Orders (CustomerId) Values (2), (4)";
            command.ExecuteNonQuery();

            SqliteCommand select = new SqliteCommand(
                "SELECT Name FROM Customers WHERE Customers.Id NOT IN ( SELECT CustomerId FROM Orders )",
                connection
            );
            using SqliteDataReader reader = select.ExecuteReader();

            Console.WriteLine("|" + "\t" +  "Customers" + "\t" + "|");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var customer = reader.GetValue(0);
                    Console.WriteLine("|" + "\t" +  customer + "\t" + "|");
                }
            }
        }
    }
}
