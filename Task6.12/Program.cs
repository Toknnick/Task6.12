using System;
using System.Collections.Generic;

namespace Task6._12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Zoo zoo = new Zoo();
            zoo.Work();
        }
    }

    class Zoo
    {
        private List<Aviary> _aviaries = new List<Aviary>();

        public Zoo()
        {
            AddAviaries();
        }

        public void Work()
        {
            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine("Добро пожаловать в зоопарк! \n1.Посмотреть на карту зоопарка. \n2.Подойти к вольеру. \n3.Покинуть зоопарк. \nВыберите вариант:");
                string userInput = Console.ReadLine();
                Console.Clear();

                switch (userInput)
                {
                    case "1":
                        ShowAviaries();
                        break;
                    case "2":
                        ShowOnAviary();
                        break;
                    case "3":
                        isWork = false;
                        break;
                    default:
                        isWork = Quit();
                        break;
                }

                Console.WriteLine(" \nДля продолжения нажмите любую клавишу:");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void ShowAviaries()
        {
            for (int i = 0; i < _aviaries.Count; i++)
            {
                Console.Write(i + 1 + ".");
                _aviaries[i].ShowInfo();
            }
        }

        private void ShowOnAviary()
        {
            ShowAviaries();
            Console.WriteLine("Введите номер вольера:");
            string userInput = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(userInput, out int numberOfAviary))
            {
                numberOfAviary -= 1;

                if (numberOfAviary >= 0 && numberOfAviary < _aviaries.Count)
                {
                    _aviaries[numberOfAviary].ShowInfo();
                }
                else
                {
                    WriteError("Вы не нашли нужный вольер и вернулись обратно ко входу.");
                }
            }
            else
            {
                WriteError("Вы не нашли нужный вольер и вернулись обратно ко входу.");
            }
        }

        private void AddAviaries()
        {
            Random random = new Random();
            string[] genders = { "мужского", "женского", "разного" };
            string gender;
            int minCountOfAviaries = 4;
            int minCountOfAnimals = 1;
            int maxCount = 10;
            int countOfAviaries = random.Next(minCountOfAviaries, maxCount);

            for (int i = 0; i < countOfAviaries; i++)
            {
                int countOfAnimals = random.Next(minCountOfAnimals, maxCount);

                if (countOfAviaries > 1)
                {
                    gender = genders[random.Next(genders.Length)];
                }
                else
                {
                    gender = genders[random.Next(genders.Length - 1)];
                }

                _aviaries.Add(new Aviary((NamesOfAnimals)i, countOfAnimals, gender, (SoundsOfAnimals)i));
            }
        }

        private bool Quit()
        {
            bool isQuit = false;
            WriteError();
            return isQuit;
        }

        private void WriteError(string text = "Вы начали буянить. Зачем-то...Охрана вас вышвырнула.")
        {
            Console.WriteLine(text);
        }
    }

    enum NamesOfAnimals
    {
        попугай,
        слон,
        жираф,
        тигр,
        лев,
        обезьяна,
        волк,
        лиса,
        енот,
        зебра,
    }

    enum SoundsOfAnimals
    {
        чикЧирик,
        трууу,
        мычания,
        фырФыр,
        рычания,
        уаАуАа,
        воя,
        тяфкает,
        урчания,
        ржания,
    }

    class Aviary
    {
        private Animal _animal = new Animal();
        private int _count;

        public Aviary(NamesOfAnimals name, int count, string gender, SoundsOfAnimals sound)
        {
            _animal.SetName(name);
            _count = count;
            _animal.SetGender(gender);
            _animal.SetSounds(sound);
        }

        public void ShowInfo()
        {
            Console.WriteLine(ChangeInfo());
        }

        private string ChangeInfo()
        {
            string text = $"В вольере {_animal.Name}. Их {_count}. Они {_animal.Gender} пола. Издают звуки {_animal.Sounds}.";

            if (_count == 1)
            {
                if (_animal.Gender == "мужского")
                {
                    text = $"В вольере {_animal.Name}. Он сидит там в одиночестве. Он {_animal.Gender} пола. Издает звуки {_animal.Sounds}.";
                }
                else
                {
                    text = $"В вольере {_animal.Name}. Она сидит там в одиночестве. Она {_animal.Gender} пола. Издает звуки {_animal.Sounds}.";
                }
            }

            return text;
        }
    }

    class Animal
    {
        public string Gender { get; private set; }
        public NamesOfAnimals Name { get; private set; }
        public SoundsOfAnimals Sounds { get; private set; }

        public void SetName(NamesOfAnimals name)
        {
            Name = name;
        }

        public void SetSounds(SoundsOfAnimals sounds)
        {
            Sounds = sounds;
        }

        public void SetGender(string gender)
        {
            Gender = gender;
        }
    }
}
