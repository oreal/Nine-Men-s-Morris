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

namespace NappulaEllipsi
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// nappulan color-property
        /// </summary>
        public static readonly DependencyProperty ColorProperty =
       DependencyProperty.Register(
         "Color",
         typeof(Brush), // propertyn tietotyyppi
         typeof(UserControl1), // luokka jossa property sijaitsee
         new FrameworkPropertyMetadata(Brushes.Red,  // propertyn oletusarvo
              FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
              new PropertyChangedCallback(OnValueChanged),  // kutsutaan propertyn arvon muuttumisen jälkeen
              new CoerceValueCallback(MuutaNappulanVaria))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public Brush Color
        {
            get { return (Brush)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaNappulanVaria(DependencyObject element, object value)
        {
            /*int luku = (int)value;
            if (luku < 0) value = 0;

            return luku;*/

            SolidColorBrush vari = (SolidColorBrush)value;
            return vari;
        }

        // Laskuria on muutettu. Päivitetään tieto myös textboxiin
        // parempi olisi bindata textbox tähän propertyyn:
        // {Binding ElementName=IkkunanNimi, Path=Laskuri}
        private static void OnValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            //NappulaEllipsi.UserControl1 o = (NappulaEllipsi.UserControl1)obj;


            UserControl1 o = (UserControl1)obj;
            o.Color = (SolidColorBrush)args.NewValue;
            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }


        public static readonly DependencyProperty OnkoKentallaProperty =
       DependencyProperty.Register(
         "OnkoKentalla",
         typeof(bool), // propertyn tietotyyppi
         typeof(UserControl1), // luokka jossa property sijaitsee
         new FrameworkPropertyMetadata(false,  // propertyn oletusarvo
              FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
              new PropertyChangedCallback(TilaValueChanged),  // kutsutaan propertyn arvon muuttumisen jälkeen
              new CoerceValueCallback(MuutaTilaa))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public bool OnkoKentalla
        {
            get { return (bool)GetValue(OnkoKentallaProperty); }
            set { SetValue(OnkoKentallaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaTilaa(DependencyObject element, object value)
        {
            bool tila = (bool)value;
            return tila;
        }

        // Laskuria on muutettu. Päivitetään tieto myös textboxiin
        // parempi olisi bindata textbox tähän propertyyn:
        // {Binding ElementName=IkkunanNimi, Path=Laskuri}
        private static void TilaValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }


        public static readonly DependencyProperty OnkoPoistettuProperty =
     DependencyProperty.Register(
       "OnkoPoistettu",
       typeof(bool), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(false,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(TilaPoistoValueChanged),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaPoistettuTilaa))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public bool OnkoPoistettu
        {
            get { return (bool)GetValue(OnkoPoistettuProperty); }
            set { SetValue(OnkoPoistettuProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaPoistettuTilaa(DependencyObject element, object value)
        {
            bool tila = (bool)value;
            return tila;
        }

        // Laskuria on muutettu. Päivitetään tieto myös textboxiin
        // parempi olisi bindata textbox tähän propertyyn:
        // {Binding ElementName=IkkunanNimi, Path=Laskuri}
        private static void TilaPoistoValueChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }


        public static readonly DependencyProperty reunaVariProperty =
     DependencyProperty.Register(
      "reunaVari",
      typeof(Brush), // propertyn tietotyyppi
      typeof(UserControl1), // luokka jossa property sijaitsee
      new FrameworkPropertyMetadata(Brushes.Black,  // propertyn oletusarvo
           FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
           new PropertyChangedCallback(reunaVariChanged),  // kutsutaan propertyn arvon muuttumisen jälkeen
           new CoerceValueCallback(MuutaReuananVaria))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public Brush reunaVari
        {
            get { return (Brush)GetValue(reunaVariProperty); }
            set { SetValue(reunaVariProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaReuananVaria(DependencyObject element, object value)
        {
            /*int luku = (int)value;
            if (luku < 0) value = 0;

            return luku;*/

            SolidColorBrush vari = (SolidColorBrush)value;

            return vari;
        }

        // Laskuria on muutettu. Päivitetään tieto myös textboxiin
        // parempi olisi bindata textbox tähän propertyyn:
        // {Binding ElementName=IkkunanNimi, Path=Laskuri}
        private static void reunaVariChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }

        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty PelaajaProperty =
    DependencyProperty.Register(
      "Pelaaja",
      typeof(int), // propertyn tietotyyppi
      typeof(UserControl1), // luokka jossa property sijaitsee
      new FrameworkPropertyMetadata(0,  // propertyn oletusarvo
           FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
           new PropertyChangedCallback(OnValueChanged2),  // kutsutaan propertyn arvon muuttumisen jälkeen
           new CoerceValueCallback(MuutaPelaaja))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public int Pelaaja
        {
            get { return (int)GetValue(PelaajaProperty); }
            set { SetValue(PelaajaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaPelaaja(DependencyObject element, object value)
        {

            int pelaaja = (int)value;
            return pelaaja;
        }

        private static void OnValueChanged2(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            //NappulaEllipsi.UserControl1 o = (NappulaEllipsi.UserControl1)obj;


            UserControl1 o = (UserControl1)obj;
            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }



        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty Naapuri1Property =
        DependencyProperty.Register(
       "Naapuri1",
       typeof(int), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(0,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(OnNaapuriChang),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaNaapuri))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public int Naapuri1
        {
            get { return (int)GetValue(PelaajaProperty); }
            set { SetValue(PelaajaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaNaapuri(DependencyObject element, object value)
        {

            int pelaaja = (int)value;
            return pelaaja;
        }

        private static void OnNaapuriChang(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }

        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty Naapuri2Property =
        DependencyProperty.Register(
       "Naapuri2",
       typeof(int), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(0,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(OnNaapuriChang2),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaNaapuri2))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public int Naapuri2
        {
            get { return (int)GetValue(PelaajaProperty); }
            set { SetValue(PelaajaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaNaapuri2(DependencyObject element, object value)
        {

            int pelaaja = (int)value;
            return pelaaja;
        }

        private static void OnNaapuriChang2(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }

        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty Naapuri3Property =
        DependencyProperty.Register(
       "Naapuri3",
       typeof(int), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(0,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(OnNaapuriChang3),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaNaapuri3))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public int Naapuri3
        {
            get { return (int)GetValue(PelaajaProperty); }
            set { SetValue(PelaajaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaNaapuri3(DependencyObject element, object value)
        {

            int pelaaja = (int)value;
            return pelaaja;
        }

        private static void OnNaapuriChang3(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }

        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty Naapuri4Property =
        DependencyProperty.Register(
       "Naapuri4",
       typeof(int), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(0,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(OnNaapuriChang4),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaNaapuri4))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public int Naapuri4
        {
            get { return (int)GetValue(PelaajaProperty); }
            set { SetValue(PelaajaProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaNaapuri4(DependencyObject element, object value)
        {

            int pelaaja = (int)value;
            return pelaaja;
        }

        private static void OnNaapuriChang4(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }

        // 0= ei pelaajaa, 1= pelaaja1, 2= pelaaja2
        public static readonly DependencyProperty ValittuProperty =
        DependencyProperty.Register(
       "Valittu",
       typeof(bool), // propertyn tietotyyppi
       typeof(UserControl1), // luokka jossa property sijaitsee
       new FrameworkPropertyMetadata(false,  // propertyn oletusarvo
            FrameworkPropertyMetadataOptions.AffectsRender, // vaikuttaa luokan ulkoasuun (textbox päivittyy)
            new PropertyChangedCallback(OnValittuChang),  // kutsutaan propertyn arvon muuttumisen jälkeen
            new CoerceValueCallback(MuutaValittua))); // kutsutaan ennen propertyn arvon muutosta

        // seuraavat tehtävä juuri näin. Ei mitään tarkistuksien lisäämistä
        public bool Valittu
        {
            get { return (bool)GetValue(ValittuProperty); }
            set { SetValue(ValittuProperty, value); }
        }

        // tätä kutsutaan ennen laskurin muuttamista ja voidaan tässä vaiheessa
        // tehdä tarkistuksia ja muuttaa laskuriin asetettavaa arvoa
        private static object MuutaValittua(DependencyObject element, object value)
        {

            bool valittu = (bool)value;
            return valittu;
        }

        private static void OnValittuChang(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            //MainWindow o = (MainWindow)obj;
            UserControl1 o = (UserControl1)obj;


            //o.textBoxLaskuri.Text = (Convert.ToInt16(o.textBoxLaskuri.Text) + 1).ToString();

        }
    }
}

