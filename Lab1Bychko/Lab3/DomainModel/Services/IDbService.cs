using Lab1Bychko.Lab3.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab3.DomainModel.Services
{
    public interface IDbService
    {
        IEnumerable<Entities.SushiSet> GetSushiSets();
        IEnumerable<Entities.Sushi> GetSushi(int id);
        IEnumerable<Entities.Sushi> GetSushi();
        void Init();
    }
}
