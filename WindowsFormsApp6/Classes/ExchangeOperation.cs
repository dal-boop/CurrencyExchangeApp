using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp6
{
    public class ExchangeOperation
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public decimal Amount { get; set; }
        public decimal ResultAmount { get; set; }
        public decimal ExchangeRate { get; set; }
        public decimal Commission { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
