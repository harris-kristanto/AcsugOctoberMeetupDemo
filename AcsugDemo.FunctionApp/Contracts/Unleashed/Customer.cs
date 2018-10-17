using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcsugDemo.FunctionApp.Contracts.Unleashed
{
    public class Customer
    {
        public Address[] Addresses { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public object GSTVATNumber { get; set; }
        public object BankName { get; set; }
        public object BankBranch { get; set; }
        public object BankAccount { get; set; }
        public object Website { get; set; }
        public object PhoneNumber { get; set; }
        public object FaxNumber { get; set; }
        public object MobileNumber { get; set; }
        public object DDINumber { get; set; }
        public object TollFreeNumber { get; set; }
        public object Email { get; set; }
        public object EmailCC { get; set; }
        public Currency Currency { get; set; }
        public object Notes { get; set; }
        public bool Taxable { get; set; }
        public object XeroContactId { get; set; }
        public Salesperson SalesPerson { get; set; }
        public int DiscountRate { get; set; }
        public bool PrintPackingSlipInsteadOfInvoice { get; set; }
        public bool PrintInvoice { get; set; }
        public bool StopCredit { get; set; }
        public bool Obsolete { get; set; }
        public object XeroSalesAccount { get; set; }
        public object XeroCostOfGoodsAccount { get; set; }
        public string SellPriceTier { get; set; }
        public object SellPriceTierReference { get; set; }
        public string CustomerType { get; set; }
        public string PaymentTerm { get; set; }
        public object ContactFirstName { get; set; }
        public object ContactLastName { get; set; }
        public object SourceId { get; set; }
        public string CreatedBy { get; set; }
        public string Guid { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool IsMessageDuplicated { get; set; } = true;
    }

    public class Currency
    {
        public string CurrencyCode { get; set; }
        public string Description { get; set; }
        public string Guid { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }

    public class Salesperson
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool Obsolete { get; set; }
        public string Guid { get; set; }
        public DateTime LastModifiedOn { get; set; }
    }

    public class Address
    {
        public string AddressType { get; set; } = "Postal";
        public string AddressName { get; set; }
        public string StreetAddress { get; set; }
        public string StreetAddress2 { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

}
