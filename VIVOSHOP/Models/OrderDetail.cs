﻿
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace VIVOSHOP.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class OrderDetail
    {
        [DisplayName("เลขที่การขาย")]
        public int Order_Id { get; set; }
        [DisplayName("รหัสสินค้า")]
        public int Pro_Id { get; set; }
        [DisplayName("จำนวน")]
        public int OrderDetails_Number { get; set; }
        [DisplayName("ราคา")]
        public decimal Pro_Price { get; set; }
        [DisplayName("เลขที่ใบสั่งซื้อ")]
        public int ProOrderId { get; set; }
        [DisplayName("ลูกค้า")]

        public Nullable<int> User_Id { get; set; }



    public virtual Product Product { get; set; }

    public virtual UserAccout UserAccout { get; set; }

}

}
