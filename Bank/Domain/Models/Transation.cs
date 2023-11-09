using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Transation
    {
        public Guid IdTransation {  get; set; }
        public Guid IdAccount { get; set; }
        public DateTime Date {  get; set; }
        public decimal Value { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
