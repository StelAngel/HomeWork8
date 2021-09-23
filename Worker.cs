using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork8
{
    struct Worker
    {
        ///<summary>
        ///Идентификатор сотрудника
        ///</summary>
        public uint ID { get; set; }
        ///<summary>
        ///Фамилия сотруднка
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Имя сотрудника
        ///</summary>
        public string Surname { get; set; }
        ///<summary>
        ///Возраст сотрудника
        ///</summary>
        public byte Age { get; set; }
        ///<summary>
        ///Департамент, в котором работает сотрудник
        ///</summary>
        public string Department { get; set; }
        ///<summary>
        ///Должность сотрудника
        ///</summary>
        public string Position { get; set; }
        ///<summary>
        ///Размер заработной платы сотрудника
        ///</summary>
        public uint Salary { get; set; }
        ///<summary>
        ///Дата появления сотрудника в департаменте
        ///</summary>
        public DateTime Date_create { get; set; }
        ///<summary>
        ///Дата создания департамента
        ///</summary>
        public DateTime Date_create_dep { get; set; }

        /// <summary>
        /// Конструктор, позволяющий присвоить значение соответствующим полям сотрудника
        /// </summary>
        /// <param name="ID">Идентификатор сотрудника</param>
        /// <param name="Name">Имя сотрудника</param>
        /// <param name="Surname">Фамилия сотрудника</param>
        /// <param name="Age">Возраст сотрудника</param>
        /// <param name="Department">Департамент, в котором работает сотрудник</param>
        /// <param name="Position">Должность, на которой работает сотрудник</param>
        /// <param name="Salary">Должность, на которой работает сотрудник</param>
        /// <param name="Date_create">Дата появления сотрудника</param>
        /// /// <param name="Date_create_dep">Дата появления департамента</param>
        public Worker(uint ID, string Name, string Surname, byte Age, string Department, string Position, uint Salary, DateTime Date_create, DateTime Date_create_dep)
        {
            this.ID = ID;                           // Сохранить переданное значение ID
            this.Name = Name;                       // Сохранить переданное значение имени сотрудника
            this.Surname = Surname;                 // Сохранить переданное значение фамилии сотрудника
            this.Age = Age;                         // Сохранить переданное значение возраста сотрудника
            this.Department = Department;           // Сохранить переданное значение названия департамента, в котором работает сотрудник
            this.Position = Position;               // Сохранить переданное значение названия должности сотрудника
            this.Salary = Salary;                   // Сохранить переданное значение заработной платы сотрудника
            this.Date_create = Date_create;         // Сохранить переданное значение времени поялвения сотрудника (времени записи)
            this.Date_create_dep = Date_create_dep;         // Сохранить переданное значение времени поялвения департамента (времени записи)
        }
        public override string ToString()
        {
            return $"{ID,5} {Name,20}  {Surname,20} {Age,15} {Department,20} {Position,30} {Salary,15} {Date_create,25}.";
        }
    }
}
