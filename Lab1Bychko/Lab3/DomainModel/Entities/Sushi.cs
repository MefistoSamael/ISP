using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab3.DomainModel.Entities
{
    [Table("Sushis")]
    public class Sushi
    {
        [PrimaryKey, AutoIncrement, Indexed]
        [Column("Id")]
        public int SushiId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        [Indexed]
        public int SetId { get; set; }

        public override string ToString()
        {
            return Name + " " + Count;
        }
    }
}
