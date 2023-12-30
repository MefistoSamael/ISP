using Lab1Bychko.Lab3.DomainModel.Entities;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab3.DomainModel.Services
{
    public class SQLiteService : IDbService
    {
        private SQLiteConnection Database;

        public SQLiteService()
        {

        }

        public IEnumerable<Sushi> GetSushi(int id)
        {
            return Database.Table<Sushi>().Where(t => t.SetId == id);
        }

        public IEnumerable<Sushi> GetSushi()
        {
            return Database.Table<Sushi>();
        }

        public IEnumerable<SushiSet> GetSushiSets()
        {
            return Database.Table<SushiSet>();
        }
        
        public void Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            Database.CreateTables<Sushi,SushiSet>();

            AddSushiSets();
            AddSushi();
        }

        private void AddSushiSets()
        {
            Database.InsertOrReplace(new SushiSet
            {
                Name = "Окинава сет",
                Id = 1,
                Description = "Ролл в гречневый хлопьях и нитях чили с тунцом гречневой лапшой и соусом Цезарь" +
                    "\nРолл в тунце со сливочным сыром, салатом айсберг и кунжутным маслом" +
                    "\nРолл в огурце с креветкой в темпуре, сливочным сыром, соусом Терияки и кунжутом" +
                    "\nРолл в маринованном морском окуне со сливочным сыром, огурцом и кунжутом Ким чи" +
                    "\nРолл в креветке со сливочным сыром, огурцом и икрой летучей рыбы\n",
                Price = 34.99
            });

            Database.InsertOrReplace(new SushiSet
            {
                Name = "Васаби сет",
                Id = 2,
                Description = "Ролл в огурце с копченым лососем, сливочным сыром, соусом Терияки и кунжутом" +
                    "\nРолл в миксе копченого лосося и морского окуня со сливочным сыром и тобико с сливочным сыром, салатом айсберг, картофелем пай" +
                    "\nРолл в кунжуте с лососем, сливочным сыром, авокадо и огурцом" +
                    "\nРолл в хлопьях тунца с лососем, сливочным сыром и авокадо" +
                    "\nРолл в кунжуте Ким чи с лососем, сливочным сыром, авокадо и огурцом\n",
                Price = 44.99
            });

        }

        private void AddSushi()
        {
            Database.InsertOrReplace(new Sushi
            {
                 SushiId = 1,
                 SetId = 1,
                 Name = "Мияги маки",
                 Count = 5
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 2,
                SetId = 1,
                Name = "Флорида маки",
                Count = 7
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 3,
                SetId = 1,
                Name = "Эдо маки",
                Count = 3
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 4,
                SetId = 1,
                Name = "Пинку маки",
                Count = 6
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 5,
                SetId = 1,
                Name = "Филадельфия маки",
                Count = 6
            });



            Database.InsertOrReplace(new Sushi
            {
                SushiId = 6,
                SetId = 2,
                Name = "Мантана маки",
                Count = 5
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 7,
                SetId = 2,
                Name = "Кьюри маки",
                Count = 5
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 8,
                SetId = 2,
                Name = "Ямато маки",
                Count = 7
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 9,
                SetId = 2,
                Name = "Бонито маки",
                Count = 7
            });

            Database.InsertOrReplace(new Sushi
            {
                SushiId = 10,
                SetId = 2,
                Name = "Аляска маки",
                Count = 6
            });
        }

    }
}
