using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Thunder.Models
{
    public class ProductMetaData
    {
    }
    [MetadataTypeAttribute(typeof(Product.ProductMetaData))]
    public partial class Product
    {
        internal sealed class ProductMetaData
        {

            public int ProductId { get; set; }
            public string ProduceCode { get; set; }
            public string ProductName { get; set; }
            public string ProductDetails { get; set; }
            [Required(ErrorMessage="Product Update can not null")]
            [DataType(DataType.DateTime,ErrorMessage="Datetime")]
            [Display(Name="Product Update")]
            public Nullable<System.DateTime> ProductUpdate { get; set; }
            public Nullable<int> ProductQty { get; set; }
            public Nullable<int> ProductSold { get; set; }
            public Nullable<int> SupplierId { get; set; }
            public Nullable<int> CategoryId { get; set; }
        }
    }
}