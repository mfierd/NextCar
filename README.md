# TheNextCar
Aplikasi ini merupakan aplikasi untuk prosedur keamanan saat mau menjalankan mobil.

## scope & functionalities
- user dapat menekan button
- terdapat label keterangan kondisi setelah button ditekan

### how does it works?
yang pertama adalah menerapkan prinsip dari MVC (Model-View-Controller) yaitu dengan membuat 2 folder baru terlebih dahulu. folder bernama Model dan Controller.
setelah membuat folder tersebut maka lanjutkan dengan membuat classnya.
didalam folder Model terdapat class Door.cs dan AccuBattery.cs yang berfungsi untuk mengatur dalam permodelan untuk nantinya akan di isi oleh fungsi2.
kemudian didalam folder Controller terdapat class DoorController.cs, AccuBatteryController.cs dan Car.cs. class di folder ini berfungsi untuk memberikan fungsi fungsi dari class yang ada pada folder Model tadi dengan cara mengetikkan tag ```using TheNextCar.Model```.

(bisa dilihat pada file.PNG)

class Car.cs akan menampung fungsi fungsi dari class DoorController.cs dan AccuBatteryController.cs yang nantinya akan di panggil di MainWindow.xml.cs
```csharp
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
using TheNextCar.Controller;
using TheNextCar.Model;

namespace TheNextCar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, OnDoorChanged, OnPowerChanged, OnCarEngineStatusChanged
    {
        private Car nextCar;

        public MainWindow()
        {
            InitializeComponent();

            AccuBatteryController accubatteryController = new AccuBatteryController(this);
            DoorController doorController = new DoorController(this);

            nextCar = new Car(accubatteryController, doorController, this);
        }

        private void OnStartButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleStartEngineButton();
        }

        private void OnDoorOpenButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheDoorButton();
        }

        private void OnLockDoorButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleTheLockDoorButton();
        }

        private void OnAccuButtonClicked(object sender, RoutedEventArgs e)
        {
            this.nextCar.toggleThePowerButton();
        }

        public void carEngineStatusChanged(string value, string message)
        {
            status.Content = message;
            StartButton.Content = value;
        }

        public void doorSecurityChanged(string vale, string message)
        {
            this.LockDoorState.Content = message;
            this.LockDoorButton.Content = vale;
        }

        public void doorStatusChanged(string vale, string message)
        {
            this.DoorOpenState.Content = message;
            this.DoorOpenButton.Content = vale;
        }

        public void onPowerChangedStatus(string value, string message)
        {
            this.AccuState.Content = message;
            this.AccuButton.Content = value;
        }
    }
}

```

#### Latihan
1. gambar class diagram
 (bisa dilihat pada diagram.jpg)
2. DoorController.cs berfungsi untuk memberi fungsi dan logika dari Model Door.cs dan nantinya akan digabung dan bisa dipanggil pada MainWindow.
3.  Model Door.cs berfungsi untuk membuat permodelan atau kerangka dari fungsi button Door dan nanti membutuhkan class DoorController.cs untuk memberi logika/fungsi nya agar dapat bekerja.
4.  interfaces OnDoorChanged berfungsi sebagai interface dari fungsi doorSecurityChanged dan doorStatusChanged agar nantinya bisa memberikan fungsi konfirmasi saat DoorButton ditekan.
