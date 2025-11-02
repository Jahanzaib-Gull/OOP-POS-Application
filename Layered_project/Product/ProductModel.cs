using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float purchasePrice { get; set; }
        public float salePrice { get; set; }
        public float discount { get; set; }

        public ProductModel()
        {

        }

        public ProductModel(string name, string desc,float pprice,float salePrice,float discount)
        {
            this.name = name;
            description = desc;
            purchasePrice = pprice;
            this.salePrice = salePrice;
            this.discount = discount;
        }

        public ProductModel(int id ,string name, string desc, float pprice, float salePrice, float discount)
        {
            this.id = id;
            this.name = name;
            description = desc;
            purchasePrice = pprice;
            this.salePrice = salePrice;
            this.discount = discount;
        }


        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, Description: {description}, Purchase Price: {purchasePrice}, Sale Price: {salePrice}, Discount: {discount}";
        }
    }
}
