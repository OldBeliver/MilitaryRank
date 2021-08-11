using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilitaryRank
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Creator creator = new Creator();
            List<Cossack> cossacks = new List<Cossack>();

            int cossacksNumber = 15;

            for (int i = 0; i < cossacksNumber; i++)
            {
                cossacks.Add(creator.CreateNewCossack());
            }

            Console.WriteLine($"список казаков в дозоре");
            Console.WriteLine($"-----------------------");

            for (int i = 0; i < cossacks.Count; i++)
            {
                Console.Write($"{i+1:d2}. ");
                cossacks[i].ShowInfo();
            }

            Console.WriteLine($"Нажмите любую, чтобы скрыть от вражин вооружение и срок службы");
            Console.ReadKey();

            var rankFilter = from Cossack cossack in cossacks
                select new
                {
                    Name = cossack.Name,
                    Rank = cossack.Rank
                };

            foreach (var cossack in cossacks)
            {
                Console.WriteLine($"{cossack.Rank} {cossack.Name}");
            }
        }
    }

    class Creator
    {
        private static Random _random;

        static Creator()
        {
            _random = new Random();
        }

        public Cossack CreateNewCossack()
        {
            return new Cossack(CreateNewName(), CreateNewEquipment(), CreateNewRank(), CreateNewWorkMonth());
        }

        private string CreateNewName()
        {
            string[] names = new string[]
            {
                "Покамисть", "Тонкоглас", "Мовбыгора", "Таксоби", "Перебийнис",
                "Непыйвода", "Толмач", "Гуртовой", "Скляр", "Трубач", "Порохня",
                "Погоняло", "Головатый", "Писанка", "Зубенко", "Кучера",
                "Побегайло", "Череватый", "Подопригора", "Неижсало", "Задерыхвист", "Жуйборода"
            };

            return names[_random.Next(names.Length)];
        }

        private string CreateNewEquipment()
        {
            string[] equipments = new[]
            {
                "кинжал", "клинок", "лук/стрелы", "сабля", "копье", "пистоль", "самопал", "мортира"
            };

            return equipments[_random.Next(equipments.Length)];
        }

        private string CreateNewRank()
        {
            string[] ranks = new[]
            {
                "казак", "приказный", "урядник", "вахмистр", "подхорунжий", 
                "хорунжий", "сотник", "подъесаул", "есаул", "характерник"
            };
            
            return ranks[_random.Next(ranks.Length)];
        }

        private int CreateNewWorkMonth()
        {
            int monthOfService = 60;

            return _random.Next(monthOfService);
        }
    }

    class Cossack
    {
        public string Name { get; private set; }
        public string Equipment { get; private set; }
        public string Rank { get; private set; }
        public int WorkMonth { get; private set; }

        public Cossack(string name, string equipment, string rank, int workMonth)
        {
            Name = name;
            Equipment = equipment;
            Rank = rank;
            WorkMonth = workMonth;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"{Rank} {Name}, вооружение: {Equipment}, на службе {WorkMonth} месяцев");
        }
    }
}