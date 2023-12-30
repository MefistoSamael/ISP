using System.ComponentModel.DataAnnotations;

namespace Lab1Bychko.Lab4.DomainModel.Entities
{
    public class Rate
    {
        [Key]
        public int Cur_ID { get; set; }     //внутренний код
        public DateTime Date { get; set; }  //дата, на которую запрашивается курс
        public string Cur_Abbreviation { get; set; }    //буквенный код
        public int Cur_Scale { get; set; }  //количество единиц иностранной валюты
        public string Cur_Name { get; set; }    //наименование валюты на русском языке во множественном, либо в единственном числе, в зависимости от количества единиц
        public decimal? Cur_OfficialRate { get; set; }  //курс

        public override string ToString()
        {
            if (Cur_OfficialRate is null)
                return string.Empty;

            return Cur_Abbreviation + "  " + Cur_Scale.ToString()
                + "        " + Math.Round((decimal)Cur_OfficialRate, 2).ToString() + "  BEL";
        }
    }
}