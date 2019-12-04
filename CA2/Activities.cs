using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA2
{
    public class Activities : IComparable
    {
        public enum ActivityType { All, Land, Water, Air }

        public string Name { get; set; }
        public ActivityType _ActivityType { get; set; }
        public decimal Cost { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public Activities(string _name, decimal _cost, ActivityType _activity, string _description, DateTime _date)
        {
            Name = _name;
            _ActivityType = _activity;
            Cost = _cost;
            Description = _description;
            Date = _date;
        }

        public Activities(string _name, ActivityType _activity) :this(_name, 0, _activity, "", DateTime.Now)
        {
            Name = _name;
            _ActivityType = _activity;
        }

        public Activities() :this("", 0, ActivityType.All, "", DateTime.Now){}

        public void DisplayActivity()
        {

        }

        /*public override string ToString()
        {

        }*/

        public override string ToString()
        {
            return $"{Name} - {Date.ToShortDateString()}";
        }
        
        public int CompareTo(object obj)
        {
            Activities that = (Activities)obj;
            return Date.CompareTo(that.Date);
        }

    }
}
