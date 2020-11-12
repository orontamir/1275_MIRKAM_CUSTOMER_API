using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1275_MIRKAM_CUSTOMER_API.Models
{
    public class Customer
    {
        public int Id_Num { get; set; }
        public DateTime Stamp_Tar { get; set; }
        public int Status { get; set; }
        public string RequestID { get; set; }
        public int CustomerNumber { get; set; }
        public string CustomerName { get; set; }
        public int IDBusiness { get; set; }
        public string PayeeCode { get; set; }
        public string CustomerType { get; set; }
        public int PartnershipVat { get; set; }
        public string Shared { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public string Entrance { get; set; }
        public int Apartment { get; set; }
        public string City { get; set; }
        public int ZIP { get; set; }
        public int Pob { get; set; }
        public int PobZip { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public string Fax { get; set; }
        public string ContactMan1 { get; set; }
        public string ContactMan1Occupation { get; set; }
        public string ContactMan1Phone { get; set; }
        public string ContactMan2 { get; set; }
        public string ContactMan2Occupation { get; set; }
        public string ContactMan2Phone { get; set; }
        public List<ContactMan> ContactMen { get; set; }
        public string Email { get; set; }
        public string SendMonthReportByEmail { get; set; }
        public string IssueMonthlyTransactionFile { get; set; }
        public string AttachPromotionData { get; set; }
        public string LogoAuthCode { get; set; }
        public string FuelDevice1 { get; set; }
        public string FuelDevice2 { get; set; }
        public string FuelDevice3 { get; set; }
        public string FuelDevice4 { get; set; }
        public string FuelDevice5 { get; set; }
        public string FuelDevice6 { get; set; }
        public string FuelDevice7 { get; set; }
        public int PrefferedFuelDeviceProvider { get; set; }
        public string JoinDate { get; set; }
        public string LastAgreementDate { get; set; }
        public string AgreementVersionDate { get; set; }
        public string IfThereAreSubCustomers { get; set; }
        public int ChargeLevel { get; set; }
        public int Bank { get; set; }
        public int BankBranch { get; set; }
        public int BankAccount { get; set; }
        public int CreditCard { get; set; }
        public string CreditCardLastDigits { get; set; }
        public int CreditCardToken { get; set; }
        public string CreditCardValidDate { get; set; }
        public int PriceListNumber { get; set; }
        public int CreditDaysSolar { get; set; }
        public int CreditDaysBenzin { get; set; }
        public int OpenAccountAuto { get; set; }
        public int AccountGroup { get; set; }
        public int AccountingNumber { get; set; }
        public int NonDebitableCustomerERPNumber { get; set; }
        public int ObligoMonth { get; set; }
        public int ObligoMonthUpdateAllowed { get; set; }
        public int ObligoCreditLimit { get; set; }
        public string BlockIfOverpassed { get; set; }
        public int LimitForDevicesForInheritance { get; set; }
        public string Blo { get; set; }
        public int BloBillingServiceCode { get; set; }
        public string VatFree { get; set; }
        public string ReferenceSource { get; set; }
        public string BonusGroup { get; set; }
        public string ClientCoversion { get; set; }
        public string InternalStationOperator { get; set; }
        public int CustomerCharacteristic { get; set; }
        public int CustomerCategory { get; set; }
        public int Marketer { get; set; }
        public int Recruiter { get; set; }
        public int StationGroup { get; set; }
        public int StationGroupOperationType { get; set; }
        public string UseOfSecretCode { get; set; }
        public string ContstantPrice { get; set; }
        public int VerifyVehicleNumberForInheritance { get; set; }
        public int CarWashing { get; set; }
        public string ShtifomatUsing { get; set; }
        public string Shti { get; set; }
        public string Comment1 { get; set; }
        public string Comment2 { get; set; }
        public string Comment3 { get; set; }
        public string Comment4 { get; set; }
        public string Comment5 { get; set; }
        public string Comment6 { get; set; }
        public string ContactManToSendCards { get; set; }
        public string ContactManToSendCardsOccupation { get; set; }
        public string ContactManToSendCardsPhone { get; set; }
        public string ContactManToSendCardsStreet { get; set; }
        public int ContactManToSendCardsHouse { get; set; }
        public string ContactManToSendCardsEntrance { get; set; }
        public int ContactManToSendCardsAppartment { get; set; }
        public string ContactManToSendCardsCity { get; set; }
        public int ContactManToSendCardsZip { get; set; }
        public string ContactManToSendCardsComments { get; set; }
        public int YearBillingFee { get; set; }
        public int YearBillingFeeForFuelDevice { get; set; }
        public int YearBillingFeeForFueCard { get; set; }
        public int YearsBillingFree { get; set; }
        public int MonthlyBillingFee { get; set; }
        public int MonthlyBillingFeeForFuelDevice { get; set; }
        public int MonthlyBillingFeeForFuelCard { get; set; }
        public int MonthsBillingFree { get; set; }
        public int BillingSumForFuelDevice1 { get; set; }
        public int BillingSumForFuelDevice2 { get; set; }
        public int BillingSumForFuelDevice3 { get; set; }
        public int BillingSumForFuelDevice4 { get; set; }
        public int BillingSumForFuelDevice5 { get; set; }
        public int BillingSumForFuelDevice6 { get; set; }
        public int BillingSumForFuelDevice7 { get; set; }
        public string UpdateBy { get; set; }
        public int CRMNumber { get; set; }

        public string GetContactManIDStr()
        {
            string result = null;
            foreach (ContactMan contactMan in ContactMen)
            {
                if (result != null)
                {
                    result += ",";
                }
                result += contactMan.ContactManID.ToString();
            }
            return result;
        }
    }
}