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

namespace Ellipsis.Controls
{
    /// <summary>
    /// Interaction logic for VideoConvertTaskControl.xaml
    /// </summary>
    public partial class VideoConvertTaskControl : UserControl
    {
        public VideoConvertTaskModel Model { get; set; }

        public VideoConvertTaskControl():this(null)
        {
            InitializeComponent();
        }

        public VideoConvertTaskControl(VideoConvertTaskModel model)
        {
            InitializeComponent();

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
    }
}
