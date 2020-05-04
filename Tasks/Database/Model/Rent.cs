using System;
using System.Collections.Generic;
using System.Text;

namespace Database.Model
{
    public class Rent: Task
    {
        public int Price { get; set; }
        public int Repetition { get; set; }
        public Owner Owner { get; set; }

        public int TotalRent (int price, int repetition)
        {
            return price * repetition;
        }
    }
}
