using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WpfApp1
{
    public class Phone : BindableBase
    {
        private string _title;
        private string _model;
        private int _price;

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                RaisePropertyChanged(nameof(Title));
            }
        }

        public string Model { 
            get 
            { 
                return _model;
            }
            set 
            { 
                _model = value;
                RaisePropertyChanged(nameof(Model));
            } 
        }

        public int Price {
            get { return _price; }
            set
            { 
                _price = value;
                RaisePropertyChanged(nameof(Price));
            } 
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) 
                PropertyChanged(this, new PropertyChangedEventArgs(prop)); 
        }
    }
}
