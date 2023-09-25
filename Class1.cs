using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EventPlanner.Models
{
    public class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
