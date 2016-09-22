using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ellipsis.MVVM;
using Ellipsis.Controls;
using System.Collections.ObjectModel;
using Ellipsis.Interfaces;
using Ellipsis.Models;
using Ellipsis.Data;

namespace Ellipsis.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IData<VideoConvertTaskModel> _dataRepository = null;

        private ObservableCollection<VideoConvertTaskControl> _videoConvertTaskList = null;

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
            _dataRepository = new DataRepository<VideoConvertTaskModel>();
            _dataRepository.DataChanged += (s) => { load(); };
        }

        private void load()
        {
            this.VideoConvertTaskList.Clear();
            foreach(var model in _dataRepository.GetAll())
            {
                var control = new VideoConvertTaskControl(model, _dataRepository);
                this.VideoConvertTaskList.Add(control);
            }
            RaisePropertyChanged(nameof(VideoConvertTaskList));
        }

        //TODO: Replace with command
        public void Add()
        {
            VideoConvertTaskModel model = new VideoConvertTaskModel()
            {
                Id = 1,
                Title = "Title"
            };
            _dataRepository.Add(model);
        }
    }
}
