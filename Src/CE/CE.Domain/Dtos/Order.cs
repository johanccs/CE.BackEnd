﻿using System;
using System.Collections.Generic;

namespace CE.Domain.Dtos
{
    public class Order
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public object MerchantComment { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public double SubTotalInclVat { get; set; }
        public double SubTotalVat { get; set; }
        public double ShippingCostsVat { get; set; }
        public double TotalInclVat { get; set; }
        public double TotalVat { get; set; }
        public double OriginalSubTotalInclVat { get; set; }
        public double OriginalSubTotalVat { get; set; }
        public double OriginalShippingCostsInclVat { get; set; }
        public double OriginalShippingCostsVat { get; set; }
        public double OriginalTotalInclVat { get; set; }
        public double OriginalTotalVat { get; set; }
        public List<Line> Lines { get; set; } = new List<Line>();
        public double ShippingCostsInclVat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public object CompanyRegistrationNo { get; set; }
        public object VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public object PaymentReferenceNo { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public object ChannelCustomerNo { get; set; }
        public ExtraDataDto ExtraData { get; set; }
    }
}
