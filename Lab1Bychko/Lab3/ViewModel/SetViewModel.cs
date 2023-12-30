
using Lab1Bychko.Lab3.DomainModel.Entities;
using Lab1Bychko.Lab3.DomainModel.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab3.ViewModel
{
    public class SetViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<SushiSet> SushiSets { get; set; }

        public ObservableCollection<Sushi> Sushis { get; set; }

        private IDbService _db;

        public SetViewModel(IDbService db)
        {
            _db = db;
            _db.Init();
            SushiSets = new ObservableCollection<SushiSet>(_db.GetSushiSets());
            Sushis = new ObservableCollection<Sushi>();
        }

        private string output;

        public string Output
        {
            get => output;
            set
            {
                if (output != value)
                {
                    output = value;
                    OnPropertyChanged();
                }
            }
        }

        public void ChangedSushiSet(int id)
        {
            Output = "Описание:\n" + SushiSets[id - 1].Description +
                "Цена: " + SushiSets[id - 1].Price.ToString() + "\nСуши в сете:\n";

            Sushis.Clear();
            var temp = new ObservableCollection<Sushi>(_db.GetSushi(id));
            foreach (var elem in temp)
            {
                Sushis.Add(elem);
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
