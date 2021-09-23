using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace HomeWork8
{
    class Repository
    {
        /// <summary>
        /// Личный идентификатор сотрудника
        /// </summary>
        public uint ID = 0;
        /// <summary>
        /// База данных названий департаментов
        /// </summary>
        static string[] Dep_names;
        /// <summary>
        /// База данных имён сотрудников
        /// </summary>
        static string[] Work_names;
        /// <summary>
        /// База данных фамилий сотрудников
        /// </summary>
        static string[] Work_surnames;
        /// <summary>
        /// База данных должностей сотрудников
        /// </summary>
        static string[] Work_positions;
        /// <summary>
        /// Генератор псевдослучайных чисел
        /// </summary>
        static Random randomize;
        /// <summary>
        /// Статический конструктор, в котором "хранятся"
        /// данные о именах,фамилиях, должностях сотрудниках и именах
        /// </summary>
        static Repository()
        {
            randomize = new Random(); // Размещение в памяти генератора случайных чисел
            // Размещение названий департаментов
            Dep_names = new string[] {
                "ДИБ", //департамент инфоормационной безопасности
                "ДТБ",
                "ДЦР",
                "ДСНГ",
            };
            // Размещение имен сотрудников
            Work_names = new string[] {
                "Никита",
                "Александр",
                "Николай",
                "Владимир",
                "Тимофей"
            };
            // Размещение фамилий сотрудников
            Work_surnames = new string[] {
                "Миняев",
                "Холмачев",
                "Крутов",
                "Быков",
                "Петров"
            };
            // Размещение наименований должностей
            Work_positions = new string[] {        
                "Сотрудник",
                "Ведущий сотрудник",
                "Заместитель начальника",
                "Начальник"
            };
        }
        /// <summary>
        /// База данных департаментов и сотрудников
        /// </summary>
        public List<Department> departments { get; set; }
        public List<Worker> workers { get; set; }
        /// <summary>
        /// Конструктор, заполняющий базы данных department и worker
        /// </summary>
        public Repository()
        {
            // Выделение памяти для хранения баз данных
            this.departments = new List<Department>();      
            this.workers = new List<Worker>();      
        }
        public void AddDept(string temp_name, int temp_count)
        {
            byte l = 1; //номер департамента
            bool st = false;
            //проверям, есть ли такой департамент
            while (!st)
            {
                st = true;
                foreach (Department department in departments)
                {
                    if (department.Name == temp_name && department.ID == l)
                    {
                        l++;
                        st = false;
                    }
                }
            }
            // Добавляем новый департамент
            this.departments.Add(
                new Department(
                    l,
                    temp_name,
                    0,
                    DateTime.Now
                    )
                );
            AddWorkerRandom(temp_count, l, temp_name);
        }
        /// <summary>
        /// Конструктор, заполняющий случайно департамент
        /// </summary>
        /// <param name="Count">Количество департаментов, которых нужно создать</param>
        /// 
        public void AddDeptRandom(int Count)
        {
            for (int i = 0; i < Count; i++)    // Заполнение базы данных департаментов.
            {
                //Департаменты будут нумероваться (но цифрами): первый Департамент, второй Департамент и т.д.
                string temp_name;
                temp_name = Dep_names[Repository.randomize.Next(Repository.Dep_names.Length)];
                byte l = 1; //номер департамента
                ushort temp_count = (ushort)randomize.Next(1, 5);
                bool st = false;
                //проверям, есть ли такой департамент
                while (!st)
                {
                    st = true;
                    foreach (Department department in departments)
                    {
                        if (department.Name == temp_name && department.ID == l)
                        {
                            l++;
                            st = false;
                        }
                    }
                }
                // Добавляем новый департамент в базу данных департаментов
                this.departments.Add(
                    new Department(
                        l,
                        // выбираем случайное имя из базы данных имён
                        temp_name,
                        //выбираем случайное количество человек от 1 до 10 - если есть начальник, он обязан быть один
                        0,
                        DateTime.Now
                        ));
                AddWorkerRandom(temp_count, l, temp_name);
            }
        }
        /// <summary>
        /// Конструктор, заполняющий вручную сотрудника
        /// </summary>
        /// 
        public void AddWorker(string temp_name, string temp_surname, byte temp_age , string temp_depname, byte temp_ID, string temp_position, uint temp_salary)
        {
            ID++;
            DateTime Date_Create = DateTime.Now;
            EditDepByIDandName(temp_ID, temp_depname, 1);
            foreach(Department department in departments)
            {
                if(department.ID == temp_ID && department.Name == temp_depname)
                {
                    Date_Create = department.Date_create;
                }
            }
            // Добавляем новый департамент
            this.workers.Add(
                new Worker(
                    ID,
                    temp_name,
                    temp_surname,
                    temp_age,
                    temp_ID.ToString() + " " + temp_depname,
                    temp_position,
                    temp_salary,
                    DateTime.Now,
                    Date_Create
                    ));
        }
        /// <summary>
        /// Конструктор, заполняющий определенный департамент людьми
        /// </summary>
        /// 
        public void AddWorkerRandom(int Count, byte id_dept, string name_dept)
        {
            DateTime Date_Create = DateTime.Now;
            foreach (Department department in departments)
            {
                if (department.ID == id_dept && department.Name == name_dept)
                {
                    Date_Create = department.Date_create;
                }
            }      
            EditDepByIDandName(id_dept, name_dept, Count);
            for (int i = 0; i < Count; i++)    // Заполнение базы данных сотрудников Департамента.
            {   
                ID++;
                string temp_position = Work_positions[Repository.randomize.Next(Repository.Work_positions.Length)];
            
                if (temp_position == "Начальник")
                {//Проверяем, есть ли начальник
                    foreach (Worker temp_work in workers)
                    {
                        if (temp_work.Position == "Начальник" && temp_work.Department == id_dept + " "+ name_dept)
                        {
                            //если уже есть в департаменте начальник, то сотрудник не может им быть
                            temp_position = Work_positions[Repository.randomize.Next(Repository.Work_positions.Length-1)];
                        }
                    }
                }
                // Добавляем нового сотрудника в базу данных департамента
                this.workers.Add(
                    new Worker(
                        ID,
                        // выбираем случайное имя из базы данных имён
                        Work_names[Repository.randomize.Next(Repository.Work_names.Length)],
                        // выбираем случайную фамилию из базы данных имён
                        Work_surnames[Repository.randomize.Next(Repository.Work_surnames.Length)],
                        // возраст от 18 до 60
                        (byte) randomize.Next(18, 60),
                        // название Департамента
                        id_dept.ToString() + " " + name_dept,
                        temp_position,
                        // возраст от 18 до 60
                        (uint) randomize.Next(80000, 100000),
                        DateTime.Now,
                        Date_Create
                        ));
            }
        }
        /// <summary>
        /// Метод, позволяющий редактировать название Департамента
        /// </summary>
        /// <param name ="CurrentID"> <param name ="name_dept">, который нужно редактировать</param>
        public void EditDepByIDandName(byte CurrentID, string name_dept, byte newID, string newname_dept)
        {
            DateTime Create_time = DateTime.Now;
            int temp_count = 0, newtemp_count = 0;
            bool is_dept = false;       
            for(int i=1; i < ID; i++)
            {
                if (this.workers[i].Department == CurrentID + " " + name_dept)
                {
                    EditUserByID((ushort) workers[i].ID, newname_dept, newID);
                }
            }

            //если такой департамент уже есть, то просто сливаем их
            foreach (Department department in departments)
            {
                if (department.ID == newID && department.Name == newname_dept)
                {
                    newtemp_count = department.Count;
                    is_dept = true;
                    break;
                }
            }
            //перепишем количество
            foreach (Department department in departments)
            {
                if (department.ID == CurrentID && department.Name == name_dept)
                {
                    Create_time = department.Date_create;
                    temp_count = department.Count;
                    break;
                }
            }
            if (!is_dept)
            {
                this.departments.RemoveAll(e => e.ID == CurrentID && e.Name == name_dept);//удаление департамента
                this.departments.Add(
                    new Department(
                        newID,
                        newname_dept,
                        temp_count,
                        Create_time
                        )
                    );
            }
            else
            {
                this.departments.RemoveAll(e => e.ID == CurrentID && e.Name == name_dept);//удаление департамента
                EditDepByIDandName(newID, newname_dept, temp_count);//слияние департаментов
            }
        }
        /// <summary>
        /// Метод, позволяющий увеличивать число человек в департаменте
        /// </summary>
        /// <param name ="CurrentID"> <param name ="name_dept">, который нужно редактировать</param>
        public void EditDepByIDandName(byte CurrentID, string name_dept, int temp_pluscount)
        {
            DateTime Create_time = DateTime.Now;
            int temp_count = 0;
            foreach (Department department in departments)
            {
                if (department.ID == CurrentID && department.Name == name_dept)
                {
                    temp_count = department.Count;
                    Create_time = department.Date_create;
                    break;
                }
            }
            this.departments.RemoveAll(e => e.ID == CurrentID && e.Name == name_dept);//удаление департамента
            this.departments.Add(
                new Department(
                    CurrentID,
                    name_dept,
                    (ushort) (temp_count + temp_pluscount),
                    Create_time
                    )
                );
        }
        public void EditDepByIDandName(byte CurrentID, string name_dept, int temp_pluscount, DateTime Create_time)
        {
            int temp_count = 0;
            foreach (Department department in departments)
            {
                if (department.ID == CurrentID && department.Name == name_dept)
                {
                    temp_count = department.Count;
                    Create_time = department.Date_create;
                    break;
                }
            }
            this.departments.RemoveAll(e => e.ID == CurrentID && e.Name == name_dept);//удаление департамента
            this.departments.Add(
                new Department(
                    CurrentID,
                    name_dept,
                    (ushort)(temp_count + temp_pluscount),
                    Create_time
                    )
                );
        }
        /// <summary>
        /// Методы, позволяющий изменить поле сотрудника
        /// </summary>
        /// <param name ="CurrentID"> <param name ="name_dept">, который нужно редактировать</param>
        public void EditUserByID(ushort CurrentID, string temp_Name, string temp_Surname, byte temp_Age, string temp_Department, byte temp_ID_Dep, string temo_Position, uint temp_Salary)
        {
            DateTime Create_time = DateTime.Now;
            string[] s = {"1", "ДСНГ"};
            foreach (Worker worker in workers)
            {
                if(worker.ID == CurrentID)
                {
                    s = worker.Department.Split();
                    break; 
                }
            }
            EditDepByIDandName(byte.Parse(s[0]), s[1], -1);
            EditDepByIDandName(temp_ID_Dep, temp_Department, 1);
            foreach (Department department in departments)
            {
                if (department.ID == temp_ID_Dep && department.Name == temp_Department)
                {
                    Create_time = department.Date_create;
                    break;
                }
            }
            this.workers.RemoveAll(e => e.ID == CurrentID);//удаление сотрудника чьё ID удовлетворяет CurrentID
                                                         // Добавляем нового cотруднка в базы данных Users
            this.workers.Add(
                new Worker(
                    CurrentID,
                    temp_Name,
                    temp_Surname,
                    temp_Age,
                    temp_ID_Dep + " " + temp_Department,
                    temo_Position,
                    temp_Salary,
                    DateTime.Now,
                    Create_time
                    )
                );
            Sort(0);
        }
        public void EditUserByID(ushort CurrentID, string temp_Department, byte temp_ID_Dep)
        {
            DateTime Create_time = DateTime.Now;
            string temp_Name = "", temp_Surname = "", temp_Position = "";
            byte temp_Age = 0;
            uint temp_Salary = 0;
            foreach(Worker worker in workers)
            {
                if (worker.ID == CurrentID)
                {
                    temp_Name = worker.Name;
                    temp_Surname = worker.Surname;
                    temp_Position = worker.Position;
                    temp_Age = worker.Age;
                    temp_Salary = worker.Salary;
                }
            }
            foreach (Department department in departments)
            {
                if (department.ID == temp_ID_Dep && department.Name == temp_Department)
                {
                    Create_time = department.Date_create;
                    break;
                }
            }
            this.workers.RemoveAll(e => e.ID == CurrentID);//удаление сотрудника чьё ID удовлетворяет CurrentID
                                                           // Добавляем нового cотруднка в базы данных Users
            this.workers.Add(
                new Worker(
                    CurrentID,
                    temp_Name,
                    temp_Surname,
                    temp_Age,
                    temp_ID_Dep + " " + temp_Department,
                    temp_Position,
                    temp_Salary,
                    DateTime.Now,
                    Create_time
                    )
                );
            Sort(0);
        }
        /// <summary>
        /// Методы, позволяющие выводить на консоль
        /// </summary>
        public void Print_Work()
        {
            // Изменяем цвет шрифта для печати в консоли на DarkBlue
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Выводим Заголовки колонок базы данных
            Console.WriteLine($"{"ID",5} {"Имя",20} {"Фамилия",21} {"Возраст",15} {"Департамент",20} {"Должность",30} {"Зарплата",15} {"Время записи",25}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var worker in this.workers)
            {                                    // Печатаем в консоль всех студентов
                Console.WriteLine(worker);
            }
        }
        public void Print_Work(byte id_dept, string name_dept)
        {
            // Изменяем цвет шрифта для печати в консоли на DarkBlue
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Выводим Заголовки колонок базы данных
            Console.WriteLine($"{"ID",5} {"Имя",20} {"Фамилия",21} {"Возраст",15} {"Департамент",20} {"Должность",30} {"Зарплата",15} {"Время записи",25}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var worker in this.workers)
            {                                    // Печатаем в консоль всех студентов
                if((id_dept + " " + name_dept) == worker.Department)
                    Console.WriteLine(worker);
            }
        }
        public void Print_Dep()
        {
            // Изменяем цвет шрифта для печати в консоли на DarkBlue
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Выводим Заголовки колонок базы данных
            Console.WriteLine($"{"Имя",9} {"Количество сотрудников",30} {"Время создания",26}");

            // Изменяем цвет шрифта для печати в консоли на Gray
            Console.ForegroundColor = ConsoleColor.Gray;
            foreach (var department in this.departments)
            {                                    // Печатаем в консоль всех студентов
                Console.WriteLine(department);
            }
        }
        /// <summary>
        /// Удаление по имени и фамилии
        /// </summary>
        public void DeleteUserByNameSurname(string CurrentName, string CurrentSurname)
        {
            //сначала уменьшим число сотрудников в департаменте
            string[] s;
            foreach (Worker worker in workers)
            {
                if (worker.Name == CurrentName && worker.Surname == CurrentSurname)
                {
                    s = worker.Department.Split();
                    EditDepByIDandName(byte.Parse(s[0]), s[1], -1);
                }
            }
            this.workers.RemoveAll(e => e.Name == CurrentName && e.Surname == CurrentSurname);//Увольнение сотрудников по имени и фамилии
        }
        /// <summary>
        /// Удаление по ID
        /// </summary>
        public void DeleteUserByID(ushort currentID)
        {
            string[] s = { "1", "ДСНГ" };
            foreach (Worker worker in workers)
            {
                if (worker.ID == currentID)
                {
                    s = worker.Department.Split();
                    break;
                }
            }
            EditDepByIDandName(byte.Parse(s[0]), s[1], -1);
            this.workers.RemoveAll(e => e.ID == currentID);//Увольнение сотрудников по ID
        }
        /// <summary>
        /// Удаление по возрасту
        /// </summary>
        public void DeleteUserByAge(byte Age)
        {
            //сначала уменьшим число сотрудников в департаменте
            string[] s;
            foreach (Worker worker in workers)
            {
                if (worker.Age > Age)
                {
                    s = worker.Department.Split();
                    EditDepByIDandName(byte.Parse(s[0]), s[1], -1);
                }
            }
                this.workers.RemoveAll(e => e.Age > Age);//Увольнение старых сотрудников
        }
        /// <summary>
        /// Удаление департамента
        /// </summary>
        public void DeleteDep(byte id_dept, string name_dept)
        {
            this.departments.RemoveAll(e => e.ID == id_dept && e.Name == name_dept);//сокращение департамента
            this.workers.RemoveAll(e => e.Department == id_dept + " " + name_dept);//увольнение людей из департамента
        }
        /// <summary>
        /// Сортировка в зависимости от параметра
        /// </summary>
        public void Sort(int k)
        {
            switch (k)
            {
                //сортировка по ID
                case 0:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.ID.CompareTo(user2.ID); });
                    break;
                //сортировка по имени
                case 1:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Name.CompareTo(user2.Name); });
                    break;
                //сортировка по фамилии
                case 2:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Surname.CompareTo(user2.Surname); });
                    break;
                //сортировка по возрасту
                case 3:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Age.CompareTo(user2.Age); });
                    break;
                //сортировка по баллу по департаментам
                case 4:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Department.CompareTo(user2.Department); });
                    break;
                //сортировка по баллу должностям
                case 5:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Position.CompareTo(user2.Position); });
                    break;
                //сортировка по зарплате
                case 6:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return user1.Salary.CompareTo(user2.Salary); });
                    break;
                //сортировка по времени сотрудников
                case 7:
                    this.workers.Sort(delegate (Worker user1, Worker user2)
                    { return ((user1.Date_create).CompareTo(user2.Date_create)); });
                    break;
                //сортировка  по названию департамента
                case 8:
                    this.departments.Sort(delegate (Department user1, Department user2)
                    { return user1.Name.CompareTo(user2.Name); });
                    break;
                //сортировка по номеру департамента
                case 9:
                    this.departments.Sort(delegate (Department user1, Department user2)
                    { return user1.ID.CompareTo(user2.ID); });
                    break;
                //сортировка по количеству людей
                case 10:
                    this.departments.Sort(delegate (Department user1, Department user2)
                    { return user1.Count.CompareTo(user2.Count); });
                    break;
                //сортировка  по времени департаментов
                case 11:
                    this.departments.Sort(delegate (Department user1, Department user2)
                    { return user1.Date_create.CompareTo(user2.Count); });
                    break;
            }

        }
        /// <summary>
        /// Конструктор, записывающий в файл 
        /// </summary>
        /// <param name="outpath">файл, в который будет записан список</param>
        /// 
        public void FilePrint(string outpath)
        {
            string json = JsonConvert.SerializeObject(workers);
            File.WriteAllText(outpath, json);
        }
        /// <summary>
        /// Конструктор, считывающий с  файа 
        /// </summary>
        /// <param name="intpath">файл, с которого будет считана база</param>
        /// 
        public void FileRead(string inpath)
        {
            departments.Clear();
            string json = File.ReadAllText(inpath);
            workers = JsonConvert.DeserializeObject<List<Worker>>(json);
            //отсортируем по департаментам
            Sort(4);
            foreach (Worker worker in workers)
            {
                //определение максимального ID
                if (worker.ID > ID)
                    ID = worker.ID;
                string[] s;
                s = worker.Department.Split();
                EditDepByIDandName(byte.Parse(s[0]), s[1], 1,worker.Date_create_dep);             
            }
            Sort(0);
            Sort(10);

        }
    }
}
