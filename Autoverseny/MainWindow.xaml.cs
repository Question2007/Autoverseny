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
using System.Windows.Threading;

namespace Autoverseny
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private Random r = new Random();
        private List<Button> autok = new List<Button>();

        private Dictionary<Button, int> rangsorDict = new Dictionary<Button, int>();

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += Timer_Tick;
            autok.Add(ferrari);
            autok.Add(lamborghini);
            autok.Add(bugatti);
            autok.Add(bmw);

            for (int i = 0; i < autok.Count; i++)
            {
                rangsorDict[autok[i]] = 0;
            }

            foreach (var auto in rangsorDict)
            {
                rangsor.ItemsSource = rangsorDict;
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            for (int i = 0; i < autok.Count; i++)
            {
                Mozog(autok[i]);
            }   
        }

        private void Mozog(Button auto)
        {
            double aktualispozicio = Canvas.GetLeft(auto);
            double sebesseg = r.Next(1, 6);
            double ujpozicio = aktualispozicio + sebesseg;
            double celvonal_ertek = Canvas.GetLeft(celvonal) - 85;
            Canvas.SetLeft(auto, ujpozicio);
            if (ujpozicio >= celvonal_ertek)
            {
                timer.Stop();
                MessageBox.Show($"{auto.Content} nyert!");
                elozo_nyertes.Text = $"Előző nyertes: {auto.Content}";
            }

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < autok.Count; i++)
            {
                Canvas.SetLeft(autok[i], 20);
            }
            timer.Start();
        }
    }
}