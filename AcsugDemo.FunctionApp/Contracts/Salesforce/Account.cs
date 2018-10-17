using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcsugDemo.FunctionApp.Contracts.Salesforce
{
    public class Account
    {
        public string ItemInternalId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountSource { get; set; }
        public string AnnualRevenue { get; set; }
        public string BillingCity { get; set; }
        public string BillingCountry { get; set; }
        public string BillingLatitude { get; set; }
        public string BillingLongitude { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingState { get; set; }
        public string BillingStreet { get; set; }
        public string CleanStatus { get; set; }
        public string CreatedById { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string DandbCompanyId { get; set; }
        public string Description { get; set; }
        public string DunsNumber { get; set; }
        public string Fax { get; set; }
        public string Id { get; set; }
        public string Industry { get; set; }
        public bool IsDeleted { get; set; }
        public string Jigsaw { get; set; }
        public string JigsawCompanyId { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string LastModifiedById { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public DateTime? LastReferencedDate { get; set; }
        public DateTime? LastViewedDate { get; set; }
        public string MasterRecordId { get; set; }
        public string NaicsCode { get; set; }
        public string NaicsDesc { get; set; }
        public string Name { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string OwnerId { get; set; }
        public string Ownership { get; set; }
        public string ParentId { get; set; }
        public string Phone { get; set; }
        public string PhotoUrl { get; set; }
        public string Rating { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingLatitude { get; set; }
        public string ShippingLongitude { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingState { get; set; }
        public string ShippingStreet { get; set; }
        public string Sic { get; set; }
        public string SicDesc { get; set; }
        public string Site { get; set; }
        public DateTime SystemModstamp { get; set; }
        public string TickerSymbol { get; set; }
        public object Tradestyle { get; set; }
        public string Type { get; set; }
        public string Website { get; set; }
        public string YearStarted { get; set; }
        public string Active__c { get; set; }
        public string CustomerPriority__c { get; set; }
        public int? NumberofLocations__c { get; set; }
        public string SLAExpirationDate__c { get; set; }
        public string SLASerialNumber__c { get; set; }
        public string SLA__c { get; set; }
        public string UpsellOpportunity__c { get; set; }

    }
}
