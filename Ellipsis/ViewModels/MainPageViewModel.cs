using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.MVVM;
using Ellipsis.Controls;
using System.Collections.ObjectModel;

namespace Ellipsis.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<VideoConvertTaskControl> _videoConvertTaskList = null;
        public ObservableCollection<VideoConvertTaskControl> VideoConvertTaskList
        {
            get
            {
                return this._videoConvertTaskList;
            }
            set
            {
                this.VideoConvertTaskList = value;
                RaisePropertyChanged("VideoConvertTaskList");
            }
        }

        public MainPageViewModel()
        {
            _videoConvertTaskList = new ObservableCollection<VideoConvertTaskControl>();
        }
    }
}
