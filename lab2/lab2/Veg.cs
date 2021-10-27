using System;
using System.Collections.Generic;
using System.Text;

namespace lab2
{
    class Veg
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public float Price { set; get; }
        public int Quantity { set; get; }

        public Veg() { }

        public Veg(int id, string name, float price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
