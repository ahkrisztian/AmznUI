using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using AmazonMetaUI.Comments;
using AmazonMetaUI.CreateLinks;
using AmazonMetaUI.Models;
using AmazonMetaUI.HTML;
using AmazonMetaUI.Calculator;

namespace AmazonMetaUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _text;
        private string _commentNumber;
        private string _commentNumber3;
        private string _label;
        private string _commentNumber2;
        private string _commentNumber4;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Label
        {
            get { return _label; }
            set
            {
                _label = value;
                OnPropertyChanged();
            }
        }

        public string CommentNumber
        {
            get { return _commentNumber; }
            set
            {
                _commentNumber = value;
                OnPropertyChanged();
            }
        }

        public string CommentNumber4
        {
            get { return _commentNumber4; }
            set
            {
                _commentNumber4 = value;
                OnPropertyChanged();
            }
        }
        public string CommentNumber2
        {
            get { return _commentNumber2; }
            set
            {
                _commentNumber2 = value;
                OnPropertyChanged();
            }
        }

        public string CommentNumber3
        {
            get { return _commentNumber3; }
            set
            {
                _commentNumber3 = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

        }

        private async void Search_Click(object sender, RoutedEventArgs e)
        {
            await Comments(_textBox.Text);

        }

        async Task Comments(string url)
        {
            var progress = new Progress<string>(value =>
            {
                Label = value;
            });

            await Task.Run(() =>
            {
                CommentNumber3 = $"Number of Comments:{Environment.NewLine} {NumberOfComments.GetNumberOfComments(url, progress)}";
            });

            List<IPageLinkModel> models = new List<IPageLinkModel>();

            await Task.Run(() =>
            {
                models = GetTheUrls.urls(url, progress);
                
            });

            List<string> CommentsAndTitles = new List<string>();

            await Task.Run(() =>
            {
                CommentsAndTitles = Htmls.asynchtml(models, progress).Result;
            });

            var newlink = new CreateLinkList();

            var ToCalculate = newlink.AddLinkModel(CommentsAndTitles);

            Text = newlink.ToString();


            CommentNumber2 =  new CalculateCommentLength(ToCalculate).ToString();

            CommentNumber4 = new CalculateTitleLength(ToCalculate).ToString();

            var searchDuplicate = new SearchDuplicate();

            searchDuplicate.AddDuplicate(ToCalculate);

            CommentNumber = searchDuplicate.ToString();
            

            Text = newlink.ToString();
            Label = "";
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }
    }

    
}
