using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Bychko.Lab2.ViewModel
{
    class ProgressBarVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string percentProgress;
        public string PercentProgress
        {
            get => percentProgress;

            set
            {
                percentProgress = value;
                OnPropertyChanged();
            }
        }

        private double progress;
        public double Progress
        {
            get => progress;

            set
            {
                progress = value;
                OnPropertyChanged();
            }
        }

        private bool isFree;
        public bool IsFree
        {
            get => isFree;

            set
            {
                isFree = value;
                OnPropertyChanged();
            }
        }

        private string labelText;
        public string LabelText
        {
            get => labelText;

            set
            {
                labelText = value;
                OnPropertyChanged();
            }
        }



        public ProgressBarVM()
        {
            Sinus.EvaluatingChanged += UpdateEvaluating;

            IsFree = true;
            LabelText = "Hi!";
            Progress = 0;
            PercentProgress = "0%";
        }

        public async void StartEvaluating()
        {
            IsFree = false;
            LabelText = "Вычисление";
            double answ = double.NaN;

            answ = await Sinus.RectangleSinus();

            if (answ.CompareTo(double.NaN) == 0)
                LabelText = "Вычисление прервано";
            else
                LabelText = Convert.ToString(answ);
            IsFree = true;
        }

        public void StopEvaluating()
        {
            Sinus.CancelEvaluation();
        }

        public void UpdateEvaluating(double percent)
        {
            var rounded = (int)(percent * 100);
            PercentProgress = $"{rounded}%";
            Progress = percent;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
