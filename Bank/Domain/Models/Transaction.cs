﻿using Domain.Enum;

namespace Domain.Models
{
    public class Transaction
    {
        public Guid IdTransaction {  get; set; }
        public Guid IdAccount { get; set; }
        public DateTime Date {  get; set; }
        public decimal Value { get; set; }
        public TransferType Type { get; set; }
        public BankAccount BankAccount { get; set; }
    }
}
