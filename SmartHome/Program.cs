using System;
using SmartHome.Models;

namespace SmartHome
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            SmartLight livingRoomLamp = new SmartLight("Лампа в гостиной", 80);

            Console.WriteLine("=== Демонстрация перегрузки методов ===");
            livingRoomLamp.SetBrightness(65);
            livingRoomLamp.SetBrightness("evening");
            Console.WriteLine();

            SmartDevice[] devices =
            {
                livingRoomLamp,
                new Thermostat("Термостат", 22.5),
                new SmartSpeaker("Колонка", 30),
                new SecurityCamera("Камера у входа"),
                new RobotVacuum("Робот-пылесос", 85),
                new SmartKettle("Умный чайник", 95)
            };

            bool isRunning = true;
            while (isRunning)
            {
                PrintMenu();
                Console.Write("Выберите пункт: ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ShowAllDevices(devices);
                        break;
                    case "2":
                        ToggleAllDevices(devices, true);
                        break;
                    case "3":
                        ToggleAllDevices(devices, false);
                        break;
                    case "4":
                        ToggleDeviceByName(devices, true);
                        break;
                    case "5":
                        ToggleDeviceByName(devices, false);
                        break;
                    case "6":
                        ShowStatistics(devices);
                        break;
                    case "7":
                        ShowTotalPowerConsumption(devices);
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void PrintMenu()
        {
            Console.WriteLine("=== УМНЫЙ ДОМ ===");
            Console.WriteLine("1. Показать все устройства");
            Console.WriteLine("2. Включить все устройства");
            Console.WriteLine("3. Выключить все устройства");
            Console.WriteLine("4. Включить устройство по имени");
            Console.WriteLine("5. Выключить устройство по имени");
            Console.WriteLine("6. Статистика (сколько включено / выключено)");
            Console.WriteLine("7. Показать суммарное энергопотребление");
            Console.WriteLine("0. Выход");
        }

        static void ShowAllDevices(SmartDevice[] devices)
        {
            Console.WriteLine("--- Список устройств ---");
            foreach (SmartDevice device in devices)
            {
                Console.WriteLine(device.GetStatus());
            }
        }

        static void ToggleAllDevices(SmartDevice[] devices, bool turnOn)
        {
            foreach (SmartDevice device in devices)
            {
                if (turnOn)
                    device.TurnOn();
                else
                    device.TurnOff();
            }
        }

        static void ToggleDeviceByName(SmartDevice[] devices, bool turnOn)
        {
            Console.Write("Введите название устройства (или его часть): ");
            string query = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(query))
            {
                Console.WriteLine("Имя не может быть пустым.");
                return;
            }

            SmartDevice foundDevice = null;
            foreach (SmartDevice device in devices)
            {
                if (device.Name.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    foundDevice = device;
                    break;
                }
            }

            if (foundDevice != null)
            {
                if (turnOn)
                    foundDevice.TurnOn();
                else
                    foundDevice.TurnOff();
            }
            else
            {
                Console.WriteLine($"Устройство с именем \"{query}\" не найдено.");
            }
        }

        static void ShowStatistics(SmartDevice[] devices)
        {
            int onCount = 0;
            int offCount = 0;

            foreach (SmartDevice device in devices)
            {
                if (device.IsOn)
                    onCount++;
                else
                    offCount++;
            }

            Console.WriteLine($"Всего устройств: {devices.Length}");
            Console.WriteLine($"Включено: {onCount}");
            Console.WriteLine($"Выключено: {offCount}");
        }

        static void ShowTotalPowerConsumption(SmartDevice[] devices)
        {
            double totalWatts = 0;
            foreach (SmartDevice device in devices)
            {
                totalWatts += device.GetPowerConsumption();
            }
            Console.WriteLine($"Суммарное энергопотребление: {totalWatts:F1} Вт");
        }
    }
}
