using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Todo_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        int i = 0;
        // Create an event handler for the AddTodoButton
        private void AddTodoButton_Click(object sender, RoutedEventArgs e)
        {
            // Store the input text in a variable
            string todoText = TodoInput.Text;

            // Check if the input text is not empty
            if (todoText.Length > 0)
            {
                

                i++;
                // Create a new TextBlock element
                TextBlock todoItem = new TextBlock
                {
                    Text = $"{i}. {todoText}",
                    Margin = new Thickness(10),
                    Foreground = new SolidColorBrush(Colors.White),
                };
                // Add the new TextBlock element to the TodoList
                TodoList.Children.Add(todoItem);

                // Clear the input text
                TodoInput.Text = "";

                // Focus on the input text
                TodoInput.Focus();
            }
            else
            {
                MessageBox.Show("Please enter a todo item.");
            }
            
        }

        // Create an event handler for the enter key
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                // Routing the event to the AddTodoButton_Click event handler
                RoutedEventArgs keyPressEnterEventArgs = new RoutedEventArgs(Button.ClickEvent);
                AddTodoButton_Click(sender, keyPressEnterEventArgs);
            }
        }
    }
}