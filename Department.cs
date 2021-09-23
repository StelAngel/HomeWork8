using System;
using System.Collections.Generic;
using System.Text;

namespace HomeWork8
{
    struct Department

    {
        ///<summary>
        ///Номер департамента
        ///</summary>
        public byte ID { get; set; }
        ///<summary>
        ///Названия департамента
        ///</summary>
        public string Name { get; set; }
        ///<summary>
        ///Количество сотрудникова 
        ///</summary>
        public int Count { get; set; }
        ///<summary>
        ///Время создания департамента 
        ///</summary>
        public DateTime Date_create { get; set; }
        /// <summary>
        /// Конструктор, позволяющий присвоить значение соответствующим полям департамента
        /// </summary>
        /// <param name="Name">Название департамента</param>
        /// <param name="Count">Количество сотрудников</param>
        /// <param name="Date_create">Дата создания</param>
        public Department(byte ID,string Name, int Count, DateTime Date_create)
        {
            this.ID = ID;                   // Сохранить переданное значение номера департамента
            this.Name = Name;               // Сохранить переданное значение названия департамента
            this.Count = Count;             // Сохранить переданное значение количества сотрудника в департаменте
            this.Date_create = Date_create; // Сохранить переданное значение времени создания департамента (времени записи)
        }
        public override string ToString()
        {
            return $"{ID} {Name,7} {Count,30}  {Date_create,25}.";
        }
    }
}
