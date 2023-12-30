using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab1Bychko.Lab1.ViewModel
{
    internal class LU : INotifyPropertyChanged
    {
        abstract class LUState
        {
            protected LU LogUn;

            public LUState(LU lu)
            {
                LogUn = lu;
            }

            public abstract void EnteredClear();

            public virtual void EnteredClearEvrething()
            {
                LogUn.clearEvrything();
                LogUn.CurrentNumber = "0";
                LogUn.resetNumber = true;
            }

            public abstract void EnteredDelete();
            public abstract void EnteredNumber(string number);
            public abstract void EnteredAnswer();

        }

        class NormalInputState : LUState
        {
            public NormalInputState(LU lu) : base(lu) { }

            // Evaluates percent
            public void EnteredPercent()
            {
                LogUn.CurrentNumber = LogUn.evaluatingSystem.EvaluatrPercent(LogUn.CurrentNumber);
            }

            // Evaluates fraction
            public void EnteredFraction()
            {
                try
                {
                    LogUn.CurrentNumber = LogUn.evaluatingSystem.EvaluateFraction(LogUn.CurrentNumber);
                }
                catch (Exception ex)
                {
                    LogUn.ChangeState(new ErrorInputState(LogUn, ex.Message));
                }

            }

            public void EnteredTask()
            {
                try
                {
                    LogUn.CurrentNumber = LogUn.evaluatingSystem.Task(LogUn.currentNumber);
                }
                catch (Exception ex)
                {
                    LogUn.ChangeState(new ErrorInputState(LogUn, ex.Message));
                }
            }

            // Evaluates square
            public void EnteredSquare()
            {
                LogUn.CurrentNumber = LogUn.evaluatingSystem.Square(LogUn.CurrentNumber);
            }

            // Does sqrt
            public void EnteredSqrt()
            {
                try
                {
                    LogUn.CurrentNumber = LogUn.evaluatingSystem.Sqrt(LogUn.CurrentNumber);
                }
                catch (Exception ex)
                {
                    LogUn.ChangeState(new ErrorInputState(LogUn, ex.Message));
                }
            }

            // Does negation
            public void EnteredNegate()
            {
                LogUn.CurrentNumber = LogUn.evaluatingSystem.Negate(LogUn.CurrentNumber);
            }

            // Handels input of binary operation
            public void EnteredBinaryOperation(string operation)
            {
                // If string is empty - starting to enter second number
                if (LogUn.Result == string.Empty)
                {
                    LogUn.Result = $"{LogUn.CurrentNumber} {operation}";
                    LogUn.operation = operation;
                    LogUn.resetNumber = true;
                }
                // If user changes the operation
                else if (LogUn.isFirstNumberEntered())
                {
                    LogUn.Result = LogUn.Result.Remove(LogUn.Result.Length - 1);
                    LogUn.Result += operation;
                    LogUn.operation = operation;
                }
            }

            // Clears input
            public override void EnteredClear()
            {
                LogUn.CurrentNumber = "0";
                LogUn.resetNumber = true;
            }

            // Deletes last digit or comma in number 
            public override void EnteredDelete()
            {
                if (LogUn.CurrentNumber != string.Empty)
                    LogUn.CurrentNumber = LogUn.CurrentNumber.Remove(LogUn.CurrentNumber.Length - 1);

                // If user deletes whole number
                // than it have to changed to 0
                if (LogUn.CurrentNumber == string.Empty)
                    LogUn.CurrentNumber = "0";
            }

            // Enters number
            public override void EnteredNumber(string number)
            {
                // Checks if user entered answer button
                // then must clear evrything
                if (LogUn.Result != string.Empty && !LogUn.isFirstNumberEntered())
                {
                    LogUn.clearEvrything();
                    LogUn.CurrentNumber = number;
                    LogUn.resetNumber = false;
                    return;
                }

                if (LogUn.resetNumber || LogUn.currentNumber == "0" && !LogUn.currentNumber.Contains("."))
                {
                    LogUn.CurrentNumber = number;
                    LogUn.resetNumber = false;
                    return;
                }

                if (LogUn.currentNumber.Length < inputLength)
                    LogUn.CurrentNumber += number;
            }

            // Evaluates current expression
            public override void EnteredAnswer()
            {
                // Checks if user didnt entered second number
                // then computes expression with the current number
                if (LogUn.isFirstNumberEntered())
                    LogUn.Result += $" {LogUn.CurrentNumber}";

                try
                {
                    LogUn.resetNumber = true;
                    var str = LogUn.Result;
                    LogUn.Result = "";
                    LogUn.CurrentNumber = LogUn.evaluatingSystem.EvaluateExpression(str);
                }
                catch (Exception ex)
                {
                    LogUn.ChangeState(new ErrorInputState(LogUn, ex.Message));
                }

            }

            // Enters comma
            public void EnteredComma()
            {
                if (!LogUn.CurrentNumber.Contains(",") && !LogUn.CurrentNumber.Contains("."))
                    LogUn.CurrentNumber += ".";

                LogUn.resetNumber = false;
            }
        }

        class ErrorInputState : LUState
        {
            public ErrorInputState(LU lu, string Error) : base(lu)
            {
                ChangeUIState(false);
                LogUn.CurrentNumber = Error;
            }

            void ChangeUIState(bool state)
            {
                LogUn.isEnabledUI = state;
                LogUn.OnPropertyChanged();
            }

            public override void EnteredClearEvrething()
            {
                base.EnteredClearEvrething();
                LogUn.ChangeState(new NormalInputState(LogUn));
            }
            public override void EnteredAnswer()
            {
                LogUn.clearEvrything();
                ChangeUIState(true);
                LogUn.ChangeState(new NormalInputState(LogUn));
            }

            public override void EnteredClear()
            {
                LogUn.clearEvrything();
                ChangeUIState(true);
                LogUn.ChangeState(new NormalInputState(LogUn));
            }

            public override void EnteredDelete()
            {
                LogUn.clearEvrything();
                ChangeUIState(true);
                LogUn.ChangeState(new NormalInputState(LogUn));
            }

            public override void EnteredNumber(string number)
            {
                ChangeUIState(true);
                LogUn.clearEvrything();
                LogUn.ChangeState(new NormalInputState(LogUn));
                LogUn.EnteredNumber(number);
            }
        }


        LUState state;
        DomainModel.EvaluatingSystem evaluatingSystem;
        bool isEnabledUI;

        private string result;
        public string Result
        {
            get => result;

            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        private string currentNumber;
        public string CurrentNumber
        {
            get => currentNumber;

            set
            {
                currentNumber = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        string operation;
        const int inputLength = 9;
        bool resetNumber;

        public LU()
        {
            resetNumber = true;
            result = string.Empty;
            evaluatingSystem = new DomainModel.EvaluatingSystem();
            CurrentNumber = "0";
            state = new NormalInputState(this);

            // Output of a number with "."
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            isEnabledUI = true;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        void ChangeState(LUState state)
        {
            this.state = state;
        }






        // Checks is user entered first number
        bool isFirstNumberEntered()
        {
            // If entered operation, than input of the first
            // number is ended
            if (operation != null && operation != null && operation == $"{Result.Last()}")
                return true;
            else return false;
        }

        void clearEvrything()
        {
            CurrentNumber = Result = operation = string.Empty;
        }

        public void EnteredClearEvrything()
        {
            state.EnteredClearEvrething();
        }

        public void EnteredPercent()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredPercent();
        }

        // Evaluates fraction
        public void EnteredFraction()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredFraction();

        }

        public void EnteredTask()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredTask();
        }

        // Evaluates square
        public void EnteredSquare()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredSquare();
        }

        // Does sqrt
        public void EnteredSqrt()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredSqrt();
        }

        // Does negation
        public void EnteredNegate()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredNegate();
        }

        // Handels input of binaty operation
        public void EnteredBinaryOperation(string operation)
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredBinaryOperation(operation);
        }

        // Clears input
        public void EnteredClear()
        {
            state.EnteredClear();
        }

        // Deletes last digit or comma in number 
        public void EnteredDelete()
        {
            state.EnteredDelete();
        }

        // Enters number
        public void EnteredNumber(string number)
        {
            state.EnteredNumber(number);
        }

        // Evaluates current expression
        public void EnteredAnswer()
        {
            state.EnteredAnswer();
        }

        // Enters comma
        public void EnteredComma()
        {
            if (state is NormalInputState)
                ((NormalInputState)state).EnteredComma();
        }

    }
}
