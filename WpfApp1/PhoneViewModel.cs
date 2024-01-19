using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WpfApp1
{
    public class PhoneViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;
        public ObservableCollection<Phone> Phones { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(
                    obj =>
                    {
                        Phone phone = new Phone();
                        Phones.Insert(0, phone);
                        SelectedPhone = phone;
                    }));
            }
        }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                RaisePropertyChanged(nameof(selectedPhone));
            }
        }

        public PhoneViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone{Title = "Iphone", Model = "X", Price = 100},
                new Phone{Title = "Samsung", Model = "S23", Price = 1000},
                new Phone{Title = "Xiaomi", Model = "12T", Price = 500}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
