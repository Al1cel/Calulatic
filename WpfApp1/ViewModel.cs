using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Model _model;
        private string _display;
        private string _operator;
        private bool _isoperatorClick;

        public ICommand NumberCommand { get; set; }

        public ICommand OperatorCommand { get; set; }

        public ICommand ClearCommand { get; set; }

        public ICommand CalculateCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ViewModel()
        {
            _model = new Model();
            _display = "0";
            _isoperatorClick = false;

            NumberCommand = new RelayCommand(OnNumberClick);
            OperatorCommand = new RelayCommand(OnOperatorClick);
            ClearCommand = new RelayCommand(OnClearClicked);
            CalculateCommand = new RelayCommand(OnCalculateClick);

        }

        public string DisplayText
        {
            get { return _display; }
            set { _display = value; OnPropertyChanged(nameof(DisplayText)); }
        }



        private void OnCalculateClick(object obj)
        {
            DisplayText = _model.Calculate().ToString();
            _model.FirstNumber = double.Parse(DisplayText);
        }

        private void OnClearClicked(object obj)
        {
            DisplayText = "0";
            _model.FirstNumber = 0;
            _model.SecondNumber = 0;
            _operator = null;
        }

        private void OnOperatorClick(object obj)
        {
            _operator = obj.ToString();
            _model.Operator = _operator;
            _isoperatorClick = true;
        }

        private void OnNumberClick(object obj)
        {
            if (_isoperatorClick || DisplayText == "0")
            {
                DisplayText = string.Empty;
            }
            DisplayText += obj?.ToString();
            _isoperatorClick = false;
            if (_operator == null)
            {
                _model.FirstNumber = double.Parse(DisplayText);
            }
            else
            {
                _model.SecondNumber = double.Parse(DisplayText);
            }
        }
    }
}  
