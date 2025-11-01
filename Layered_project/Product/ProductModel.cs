using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layered_project.Product
{
    internal class ProductModel
    {
        private string name;
        private string description;
        private float purchasePrice;
        private float salePrice;
        private float discount;

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

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return this.name;
        }


        public void SetDesc(string desc)
        {
            this.description = desc;
        }
        public string GetDesc()
        {
            return this.description;
        }


        public void SetPurchasePrice(float price)
        {
            this.purchasePrice = price;
        }
        public float GetPurchasePrice()
        {
            return this.purchasePrice;
        }

        public void SetSalePrice(float price)
        {
            this.salePrice = price;
        }
        public float GetSalePrice()
        {
            return this.salePrice - this.discount;
        }
        public float GetDiscount()
        {
            return this.discount;
        }

        public override string ToString()
        {
            return $"{name},{description},{purchasePrice},{salePrice},{discount}";
        }
    }
}
