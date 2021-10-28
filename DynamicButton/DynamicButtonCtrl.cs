using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicButton
{
    public class DynamicButtonCtrl : INotifyPropertyChanged
    {
        static int count = 0;
        public string name { get; set; }

        public DynamicButtonCtrl()
        {
            name = "DynamicButton" + count.ToString();
            count++;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
