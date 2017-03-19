using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ellipsis.Models;
using Ellipsis.Interfaces;
using System.IO;

namespace Ellipsis.Controls
{
    /// <summary>
    /// Interaction logic for VideoConvertTaskControl.xaml
    /// </summary>
    public partial class VideoConvertTaskControl : UserControl
    {
        public VideoConvertTaskModel Model { get; set; }
        private IData<VideoConvertTaskModel> repo;

        public VideoConvertTaskControl():this(null, null)
        {
            InitializeComponent();
        }

        public VideoConvertTaskControl(VideoConvertTaskModel model, IData<VideoConvertTaskModel> data)
        {
            InitializeComponent();

            repo = data;

            if(model == null)
            {
                Model = new VideoConvertTaskModel();
            }
            else
            {
                Model = model;
            }
            
            this.DataContext = Model;
        }

        public void SetThumbnail(Stream s)
        {
            var imgs = new BitmapImage();
            imgs.BeginInit();
            imgs.StreamSource = s;
            imgs.EndInit();

            this.Thumbnail.Source = imgs;
        }
    }
}
