using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.Models;
using System.IO;
using System.ComponentModel;

namespace Ellipsis.Models
{
    public class VideoConvertTaskModel : DataModel, INotifyPropertyChanged 
    {
        public string Title { get; set; }
        public string Size { get; set; }
        public string Duration { get; set; }

        private int _progress;
        public int Progress
        {
            get
            {
                return this._progress;
            }
            set
            {
                this._progress = value;
                NotifyPropertyChanged("Progress");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
