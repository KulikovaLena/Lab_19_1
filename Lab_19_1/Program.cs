using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_19_1
{
    class Computer
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Processor { get; set; }
        public double ClockCPU { get; set; }
        public byte RAM { get; set; }
        public double НardDrive { get; set; }
        public double VRAM { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            List<Computer> listComputer = new List<Computer>()
            {
                new Computer() {Id=1, Mark="Asus", Processor="Core i5", ClockCPU=2, RAM=8, НardDrive=1, VRAM=0.5, Cost=700, Quantity=15 },
                new Computer() {Id=2, Mark="Aser", Processor="Core i5", ClockCPU=3, RAM=8, НardDrive=0.5, VRAM=0.5, Cost=500, Quantity=10 },
                new Computer() {Id=3, Mark="Lenovo", Processor="Core i5", ClockCPU=3.5, RAM=16, НardDrive=1.125, VRAM=1, Cost=1000, Quantity=40 },
                new Computer() {Id=4, Mark="Dell", Processor="Athlon", ClockCPU=3.5, RAM=16, НardDrive= 1, VRAM=1, Cost=1000, Quantity=28 },
                new Computer() {Id=5, Mark="DNS", Processor="Ryzen", ClockCPU=4, RAM=32, НardDrive= 2.5, VRAM=3, Cost=2000, Quantity=31 },
                new Computer() {Id=6, Mark="Samsung", Processor="Ryzen", ClockCPU=4, RAM=32, НardDrive= 5, VRAM=2, Cost=1500, Quantity=5 },
            };
            int n;
            Console.Write("Выберети интересующий Вас процессор\n  1   Core i5\n  2   Athlon\n  3   Ryzen\n Vash vibor: ");
            n = int.Parse(Console.ReadLine());
            switch (n)
            {
                case 1:
                    {
                        List<Computer> comp = listComputer
                            .Where(c => c.Processor == "Core i5")
                            .ToList();
                        foreach (Computer c in comp)
                            Console.WriteLine("Компьютер с указаным процессором:\n  марка компьютера - {0}\n  процессор - {1}\n  частотa  работы  процессора - {2} ГГц\n  объем оперативной памяти - {3} ГБ\n  объемом жесткого диска - {4} ТБ\n  объем памяти видеокарты - {5} ГБ\n  стоимость компьютера - {6} у.е.", c.Mark, c.Processor, c.ClockCPU, c.RAM, c.НardDrive, c.VRAM, c.Cost);
                        break;
                    }
                case 2:
                    {
                        List<Computer> comp = listComputer
                            .Where(c => c.Processor == "Athlon")
                            .ToList();
                        foreach (Computer c in comp)
                            Console.WriteLine("Компьютер с указаным процессором:\n  марка компьютера - {0}\n  процессор - {1}\n  частотa  работы  процессора - {2} ГГц\n  объем оперативной памяти - {3} ГБ\n  объемом жесткого диска - {4} ТБ\n  объем памяти видеокарты - {5} ГБ\n  стоимость компьютера - {6} у.е.", c.Mark, c.Processor, c.ClockCPU, c.RAM, c.НardDrive, c.VRAM, c.Cost);
                        break;
                    }
                case 3:
                    {
                        List<Computer> comp = listComputer
                            .Where(c => c.Processor == "Ryzen")
                            .ToList();
                        foreach (Computer c in comp)
                            Console.WriteLine("Компьютер с указаным процессором:\n  марка компьютера - {0}\n  процессор - {1}\n  частотa  работы  процессора - {2} ГГц\n  объем оперативной памяти - {3} ГБ\n  объемом жесткого диска - {4} ТБ\n  объем памяти видеокарты - {5} ГБ\n  стоимость компьютера - {6} у.е.", c.Mark, c.Processor, c.ClockCPU, c.RAM, c.НardDrive, c.VRAM, c.Cost);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Таких вариантов нет");
                        break;
                    }

            }
            Console.WriteLine();

            try
            {
                Console.Write("Введите минимальный необходимый объем ОЗУ в ГБ - ");
                byte x = byte.Parse(Console.ReadLine());
                List<Computer> comp1 = listComputer
                                .Where(c => c.RAM >= x)
                                .ToList();
                Console.WriteLine("Компьютер с объемом ОЗУ не ниже, чем указано:");
                foreach (Computer c in comp1)
                    Console.WriteLine(" {0}  марка компьютера - {1,-8}  объем оперативной памяти - {2} ГБ", c.Id, c.Mark, c.RAM);
                if (x>32)
                    Console.WriteLine("Таких вариантов нет");
            }
            catch
            {
                Console.WriteLine("Введено некорректное значение");
            }
            Console.WriteLine();
            Console.ReadKey();

            List<Computer> comp2 = listComputer
                .OrderBy(c => c.Cost)
                .ToList();
            Console.WriteLine("Сортировка компьютеров по стоимости:");
            foreach (Computer c in comp2)
                Console.WriteLine(" {0}  марка компьютера - {1,-8}  стоимость - {2} у.е.", c.Id, c.Mark, c.Cost);
            Console.WriteLine();
            Console.ReadKey();

            var comp3 = listComputer
                .GroupBy(c => c.Processor);
            Console.WriteLine("Cписок, сгруппированный по типу процессора:");
            foreach (IGrouping<string, Computer> c in comp3)
            {
                Console.WriteLine("{0}\n-------",c.Key);
                foreach (var p in c)
                    Console.WriteLine("{0} {1}",p.Id, p.Processor);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.ReadKey();

            int min = listComputer
                .Min(c => c.Cost);
            List<Computer> comp4 = listComputer
                                .Where(c => c.Cost ==min)
                                .ToList();
            Console.WriteLine("Компьютер с минимальной ценой:");
            foreach (Computer c in comp4)
                Console.WriteLine(" {0}  марка компьютера - {1,-8}  стоимость - {2} у.е.", c.Id, c.Mark, c.Cost);
            Console.WriteLine();
            Console.ReadKey();

            int max = listComputer
                .Max(c => c.Cost);
            List<Computer> comp5 = listComputer
                                .Where(c => c.Cost == max)
                                .ToList();
            Console.WriteLine("Компьютер с максимальной ценой:");
            foreach (Computer c in comp5)
                Console.WriteLine(" {0}  марка компьютера - {1,-8}  стоимость - {2} у.е.", c.Id, c.Mark, c.Cost);
            Console.WriteLine();
            Console.ReadKey();

            bool quantity = listComputer
                .Any(c => c.Quantity > 30);
            if (quantity)
                Console.WriteLine("Есть хотя бы один вид компьютера в количестве не менее 30 штук");
            else
                Console.WriteLine("Каждого вида компьютера осталось меньше 30 штук");
            Console.ReadKey();
        }
    }
}
