using System;
using System.IO;

namespace HomeWork8
{
    class Program
    {
        static void Main()
        {

            String menu = "\nQ - выйти\n" +
                "A - добавить департамент или сотрудника\n" +
                "B - сократить департамент или сотрудника\n" +
                "C - отредактировать департамент или сотрудника\n"+
                "D - вывести департамент или всех сотрудников\n" +
                "E - отсортировать департамент или сотрудников \n" +
                "F - вывести или считать с файла\n";
            String AddMenu = "\nQ - выйти\n" +
                "A - вручную добавить департамент\n" +
                "B - добавить несколько департаментов случайным образом\n" +
                "C - вручную добавить сотрудника\n" +
                "D - добавить несколько сотрудников в Департамент случайным образом\n";
            String DeleteMenu = "\nQ - выйти\n" +
                "A - сократить определенный департамент\n" +
                "B - уволить по ID\n" +
                "С - уволить по имени и фамилии\n" +
                "D - уволить всех старше определенного возраста\n";
            String EditMenu = "\nQ - выйти\n" +
                "A - изменить название и номер департамента (или слить департамент в один)\n" +
                "B - изменить поле сотрудника c определенным ID\n";
            String PrintMenu = "\nQ - выйти\n" +
                "A - вывести всех сотрудников\n" +
                "B - вывести общую информацию о департаментах\n" +
                "C - вывести один Департамент\n";
            String SortMenu = "\nQ - выйти\n" +
                "0 - сортировка по ID сотрудников\n" +
                "1 - сортировка по имени сотрудников\n" +
                "2 - сортировка по фамилии сотрудников\n" +
                "3 - сортировка по возрасту сотрудников\n" +
                "4 - сортировка по департаментам сотрудников\n" +
                "5 - сортировка по должностям сотрудников\n" +
                "6 - сортировка по зарплате сотрудников\n" +
                "7 - сортировка по времени записи сотрудников\n"+
                "A - сортировка по отделу департамента\n" +
                "B - сортировка по названию департамента\n" +
                "C - сортировка по количеству людей в департаменте\n" +
                "D - сортировка по времени записи департамента\n";
            String FileMenu = "\nQ - выйти\n" +
                "A - вывести в файл\n" +
                "B - считать с файла\n";

            Repository repository = new Repository();
            Console.WriteLine(menu);
            bool ex = false;
            while (!ex)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    //нажали на кнопку А - чтобы добавить департамент или сотрудника
                    case ConsoleKey.A:
                        Console.WriteLine(AddMenu);
                        bool exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            //добавить Департамент или сотрудника
                            switch (keyadd.Key)
                            {
                                //добавить определенный департамент
                                case ConsoleKey.A:
                                    string temp_name;
                                    int temp_count;
                                    Console.WriteLine("Введите название Департамента (без номера):  ");
                                    temp_name = Console.ReadLine();
                                    Console.WriteLine("Сколько человек в Департаментеы:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_count))
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число!!!");
                                    }
                                    repository.AddDept(temp_name, temp_count);
                                    Console.WriteLine(AddMenu);
                                    break;
                                //добавить случайное число случайных департаментов
                                case ConsoleKey.B:                             
                                    Console.WriteLine("Сколько Департаментов вы хотите создать:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_count))
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число!!!");
                                    }
                                    repository.AddDeptRandom(temp_count);
                                    Console.WriteLine(AddMenu);
                                    break;
                                //добавить случайное число сотрудников в определенный департамент
                                case ConsoleKey.D:
                                    //ввод департамента
                                    string temp_depname;
                                    int  temp_IDdep;
                                    Console.Write($"Введите департамент и номер департамента \nДепартамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    Console.WriteLine($"Сколько людей устроить в департамент {temp_IDdep} {temp_depname}:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_count))
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число!!!");
                                    }
                                    repository.AddWorkerRandom(temp_count, (byte) temp_IDdep, temp_depname);
                                    Console.WriteLine(AddMenu);
                                    break;
                                //добавить сотрудника
                                case ConsoleKey.C:
                                    string temp_workname, temp_worksurname, temp_position;
                                    int temp_age, temp_salary;
                                    //ввод имени
                                    Console.Write("Введите имя сотрудника:  ");
                                    temp_workname = Console.ReadLine();
                                    //ввод фамилии
                                    Console.Write("Введите фамилию сотрудника:  ");
                                    temp_worksurname = Console.ReadLine();
                                    //ввод возраста
                                    Console.Write($"Введите возраст сотрудника {temp_worksurname}, {temp_workname}:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_age) || temp_age > 100 || temp_age < 18)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число от 18 до 100!");
                                    }
                                    //ввод должности
                                    Console.Write($"Введите должность сотрудника  {temp_worksurname}, {temp_workname}: ");
                                    temp_position = Console.ReadLine();
                                    //ввод департамента
                                    Console.Write($"Введите департамент и номер департамента, в котором работает сотрудник  {temp_worksurname}, {temp_workname} \nДепартамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    //ввод зарплаты
                                    Console.Write($"Введите зарплату сотрудника {temp_worksurname}, {temp_workname}:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_salary) || temp_salary < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число!");
                                    }
                                    repository.AddWorker(temp_workname, temp_worksurname, (byte) temp_age, temp_depname, (byte) temp_IDdep, temp_position, (uint) temp_salary);
                                    Console.WriteLine(AddMenu);
                                    break;                               
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                Console.WriteLine(menu);
                        break;
                        //сокращение департамента или сотрудников
                    case ConsoleKey.B:
                        Console.WriteLine(DeleteMenu);
                        exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            //сократить департамент или сотрудника
                            switch (keyadd.Key)
                            {
                                //сократить департамент
                                case ConsoleKey.A:
                                    //ввод департамента
                                    string temp_depname;
                                    int temp_IDdep;
                                    Console.Write($"Введите департамент и номер департамента \nДепартамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    repository.DeleteDep((byte)temp_IDdep,temp_depname);
                                    Console.WriteLine(DeleteMenu);
                                    break;
                                //уволить человека с ID
                                case ConsoleKey.B:
                                    int CurrentID;
                                    Console.Write("Сотрудника с каким ID Вы хотите уволить:  ");
                                    while (!int.TryParse(Console.ReadLine(), out CurrentID))
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число!!!");
                                    }
                                    repository.DeleteUserByID((ushort) CurrentID);
                                    Console.WriteLine(DeleteMenu);
                                    break;
                                //уволить по ФИ
                                case ConsoleKey.C:
                                    string temp_workname, temp_worksurname;
                                    //ввод имени
                                    Console.Write("Введите имя сотрудника:  ");
                                    temp_workname = Console.ReadLine();
                                    //ввод фамилии
                                    Console.Write("Введите фамилию сотрудника:  ");
                                    temp_worksurname = Console.ReadLine();
                                    repository.DeleteUserByNameSurname(temp_workname, temp_worksurname);
                                    Console.WriteLine(DeleteMenu);
                                    break;
                                //уволить по возрасту
                                case ConsoleKey.D:
                                    int temp_age;
                                    Console.Write($"Введите возраст сотрудника:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_age) || temp_age > 100 || temp_age < 18)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число от 18 до 100!");
                                    }
                                    repository.DeleteUserByAge((byte)temp_age);
                                    Console.WriteLine(DeleteMenu);
                                    break;
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                        Console.WriteLine(menu);
                        break;
                        //изменить департамент или сотрудника
                    case ConsoleKey.C:
                        Console.WriteLine(EditMenu);
                        exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            switch (keyadd.Key)
                            {
                                //изменить департамент
                                case ConsoleKey.A:
                                    string temp_depname, new_temp_depname;
                                    int temp_IDdep, new_temp_IDdep;
                                    Console.Write($"Введите департамент и номер департамента который Вы хотите изменить \nДепартамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    Console.Write($"Введите новое название департамента и номера \nДепартамент: ");
                                    new_temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out new_temp_IDdep) || new_temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    repository.EditDepByIDandName((byte)temp_IDdep, temp_depname, (byte) new_temp_IDdep, new_temp_depname);
                                    Console.WriteLine(EditMenu);
                                    break;
                                //изменить сотрудника
                                case ConsoleKey.B:
                                    string temp_workname, temp_worksurname, temp_position;
                                    int temp_age, temp_salary, CurrentID;
                                    Console.Write("Сотрудника с каким ID Вы хотите редактировать:  ");
                                    while (!int.TryParse(Console.ReadLine(), out CurrentID))
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число!!!");
                                    }
                                    //ввод имени
                                    Console.Write("Введите имя сотрудника:  ");
                                    temp_workname = Console.ReadLine();
                                    //ввод фамилии
                                    Console.Write("Введите фамилию сотрудника:  ");
                                    temp_worksurname = Console.ReadLine();
                                    //ввод возраста
                                    Console.Write($"Введите возраст сотрудника {temp_worksurname}, {temp_workname}:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_age) || temp_age > 100 || temp_age < 18)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое число от 18 до 100!");
                                    }
                                    //ввод должности
                                    Console.Write($"Введите должность сотрудника  {temp_worksurname}, {temp_workname}: ");
                                    temp_position = Console.ReadLine();
                                    //ввод департамента
                                    Console.Write($"Введите департамент и номер департамента, в котором работает сотрудник  {temp_worksurname}, {temp_workname} \n Департамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    //ввод зарплаты
                                    Console.Write($"Введите зарплату сотрудника {temp_worksurname}, {temp_workname}:  ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_salary) || temp_salary < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число!");
                                    }
                                    repository.EditUserByID((ushort)CurrentID, temp_workname, temp_worksurname, (byte)temp_age, temp_depname, (byte)temp_IDdep, temp_position, (uint)temp_salary);
                                    Console.WriteLine(EditMenu);
                                    break;
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                        Console.WriteLine(menu);
                        break;
                        //вывод всех департаментов или только один департамент
                    case ConsoleKey.D:
                        Console.WriteLine(PrintMenu);
                        exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            //добавить Департамент или сотрудника
                            switch (keyadd.Key)
                            {
                                case ConsoleKey.A:
                                    repository.Print_Work();
                                    Console.WriteLine(PrintMenu);
                                    break;
                                case ConsoleKey.B:
                                    repository.Print_Dep();
                                    Console.WriteLine(PrintMenu);
                                    break;
                                case ConsoleKey.C:
                                    string temp_depname;
                                    int temp_IDdep;
                                    Console.Write($"Введите департамент и номер департамента \n Департамент: ");
                                    temp_depname = Console.ReadLine();
                                    Console.Write("Номер департамента: ");
                                    while (!int.TryParse(Console.ReadLine(), out temp_IDdep) || temp_IDdep < 0)
                                    {
                                        Console.WriteLine("Ошибка ввода! Введите целое положительное число");
                                    }
                                    repository.Print_Work((byte) temp_IDdep, temp_depname);
                                    Console.WriteLine(PrintMenu);
                                    break;
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                        Console.WriteLine(menu);
                        break;
                    //сортировка
                    case ConsoleKey.E:
                        Console.WriteLine(SortMenu);
                        exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            //добавить Департамент или сотрудника
                            switch (keyadd.Key)
                            {
                                case ConsoleKey.D0:
                                    repository.Sort(0);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D1:
                                    repository.Sort(1);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D2:
                                    repository.Sort(2);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D3:
                                    repository.Sort(3);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D4:
                                    repository.Sort(4);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D5:
                                    repository.Sort(5);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D6:
                                    repository.Sort(6);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D7:
                                    repository.Sort(7);
                                    repository.Print_Work();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.A:
                                    repository.Sort(9);
                                    repository.Print_Dep();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.B:
                                    repository.Sort(8);
                                    repository.Print_Dep();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.C:
                                    repository.Sort(10);
                                    repository.Print_Dep();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.D:
                                    repository.Sort(11);
                                    repository.Print_Dep();
                                    Console.WriteLine(SortMenu);
                                    break;
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                        Console.WriteLine(menu);
                        break;
                    case ConsoleKey.F:
                        Console.WriteLine(FileMenu);
                        exadd = false;
                        while (!exadd)
                        {
                            ConsoleKeyInfo keyadd = Console.ReadKey(true);
                            
                            switch (keyadd.Key)
                            {
                                //записать в файл
                                case ConsoleKey.A:
                                    Console.Write("Напишите название файла, в который хотите выгрузить базу: ");
                                    string outpath = Console.ReadLine();
                                    repository.FilePrint(outpath);
                                    Console.WriteLine(FileMenu);
                                    break;
                                //считать с файла
                                case ConsoleKey.B:
                                    Console.Write("Напишите название файла, из которого хотите взять базу: ");
                                    string inpath = Console.ReadLine();
                                    if (File.Exists(inpath))
                                    {
                                        repository.FileRead(inpath);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Файла {inpath} не существует");
                                    }
                                    Console.WriteLine(FileMenu);
                                    break;
                                case ConsoleKey.Q:
                                    exadd = true;
                                    break;
                                default:
                                    Console.WriteLine("Нажмите другую кнопку");
                                    break;
                            }
                        }
                        Console.WriteLine(menu);
                        break;
                    case ConsoleKey.Q:
                        ex = true;
                        break;
                    default:
                        Console.WriteLine("Нажмите другую кнопку");
                        break;
                }
            }
        }
    }
}
