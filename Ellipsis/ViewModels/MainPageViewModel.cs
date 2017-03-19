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
using Microsoft.Win32;
using System.IO;
using Ellipsis.Services.Helpers;
using NReco.VideoConverter;
using System.Timers;

namespace Ellipsis.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private IData<VideoConvertTaskModel> _dataRepository = null;
        private OpenFileDialog selectVideoFilesDialog = null;

        private ConvertSettings convertSettins;
        private FFMpegConverter ffmpegConverter;

        private int currentTask;

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
            selectVideoFilesDialog = new OpenFileDialog();
            convertSettins = new ConvertSettings();
            ffmpegConverter = new FFMpegConverter();
            currentTask = -1;
            ffmpegConverter.ConvertProgress += FfmpegConverter_ConvertProgress;

            // Customize open file dialog
            InitializeOpenFileDialog();
            initializeSettings();
        }

        private void FfmpegConverter_ConvertProgress(object sender, ConvertProgressEventArgs e)
        {
            if(currentTask != -1)
            {
                var task = _dataRepository.GetAll().Where(x => x.Id == currentTask).FirstOrDefault();
                task.Progress = (int)(e.Processed.TotalSeconds * 100 / e.TotalDuration.TotalSeconds);
            }
        }

        private void initializeSettings()
        {
            this.convertSettins.VideoFrameRate = 15;
            this.convertSettins.SetVideoFrameSize(640, 480);
        }

        private void InitializeOpenFileDialog()
        {
            this.selectVideoFilesDialog.Multiselect = true;
            this.selectVideoFilesDialog.Title = "Select Videos";
            this.selectVideoFilesDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
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


        public async Task Convert()
        {
            // TODO:Implement convert

            foreach(var task in _dataRepository.GetAll())
            {
                try
                {
                    currentTask = task.Id;
                    await Task.Run(async () =>
                    {
                        ffmpegConverter.ConvertMedia(task.Path, null, String.Format(task.Path + ".flv"), Format.flv, convertSettins);
                        await Task.Delay(0);
                    });
                }
                catch(Exception e)
                {
                    // TODO: Handle Exception
                }
            }

            currentTask = -1;

            await Task.Delay(0);
        }

        
        public async Task Add()
        {
            if(this.selectVideoFilesDialog.ShowDialog() == true)
            {
                foreach(string fileName in selectVideoFilesDialog.FileNames)
                {
                    try
                    {
                        FileInfo file = new FileInfo(fileName);
                        var details = file.GetDetails();
                        VideoConvertTaskModel model = new VideoConvertTaskModel()
                        {
                            Id = _dataRepository.GetAll().Count + 1,
                            Title = file.Name,
                            Path = fileName,
                            Duration = details.Keys.Contains("Length") ?details["Length"] : "--:--:--",
                            Size = details["Size"]
                        };
                        //Get video thumbnail
                        ffmpegConverter.GetVideoThumbnail(model.Path, String.Format(Path.GetTempPath() + model.Id + ".jpg"));
                        model.ThumbPath = String.Format(Path.GetTempPath() + model.Id + ".jpg");

                        _dataRepository.Add(model);
                    }
                    catch(Exception e)
                    {
                        // TODO : Handle exceptions
                    }
                }
            }

            await Task.Delay(0);
        }

        public void Clear()
        {
            this.VideoConvertTaskList.Clear();
            _dataRepository.GetAll().Clear();
            RaisePropertyChanged(nameof(VideoConvertTaskList));
        }
    }
}
