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

namespace WpfAppPost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private RichTextBox postRichTextBox;
        private Dictionary<string, List<string>> photoComments = new Dictionary<string, List<string>>();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CommentButton_Click(object sender, RoutedEventArgs e)
        {
            
            string comment = commentTextBox.Text;

            
            StackPanel commentPanel = new StackPanel();

           
            TextBlock commentTextBlock = new TextBlock();
            commentTextBlock.Text = comment;
            commentPanel.Children.Add(commentTextBlock);

            
            postStackPanel.Children.Add(commentPanel);
            MessageBox.Show($"Комментарий: {comment}");

        }

        private void DisplayComments(string currentPhoto)
        {
            
            postRichTextBox.Document.Blocks.Clear();
          
            FlowDocument flowDocument = new FlowDocument();
          
            if (photoComments.ContainsKey(currentPhoto))
            {
                foreach (string comment in photoComments[currentPhoto])
                {
                    Paragraph paragraph = new Paragraph(new Run(comment));
                    flowDocument.Blocks.Add(paragraph);
                }
            }

           
            postRichTextBox.Document = flowDocument;
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            string currentContent = likeButton.Content.ToString();

            if (int.TryParse(currentContent, out int likesCount))
            {
                likesCount++;
                likeButton.Content = likesCount.ToString();
            }
            else
            {
                
                likeButton.Content = "1";
            }
        }

    }
}
