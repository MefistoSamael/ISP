using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab3.DomainModel.Entities
{
    [Table("SushiSets")]
    public class SushiSet
    {
        [PrimaryKey, AutoIncrement, Indexed]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return Name + "\n" +
                Description + "\n" +
                Price;
        }

    }
}
