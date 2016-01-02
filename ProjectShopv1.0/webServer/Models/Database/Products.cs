using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webServer.Models
{
    public class Products
    {
        public int id { get; set; }

        [DisplayName("Kategori")]
        public int productCategory { get; set; }
        [DisplayName("Produkt navn")]
        public string productName { get; set; }
        [DisplayName("Produkt beskrivelse")]
        public string productDescription { get; set; }
        [DisplayName("Produkt indkøbspris")]
        public int productRegularPrice { get; set; }
        [DisplayName("Produkt salgspris")]
        public int productSalePrice { get; set; }
        [DisplayName("Mængde")]
        public int productQuantity { get; set; }
        // Stock or instock
        [DisplayName("Status")]
        public int productStatus { get; set; }
        [DisplayName("Produkt billede")]
        public string productImage { get; set; }
        //SEO
        [DisplayName("Produkt SEO tekst")]
        public string productImageAltText { get; set; }




    }
}