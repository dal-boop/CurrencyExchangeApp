using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    //Поля содержащиеся в API ЦБ РФ

    public class Currency
    {
        public string CharCode { get; set; } //Код валюты (EUR, USD, RUB)
        public string Name { get; set; }//Полное наименование валюты (Российский рубль, Доллар США)
        public double Rate { get; set; }
        public double Value { get; set; }//Количество валюты к рублю
        
        //public DateTime Date { get; set; }

    }
}

