using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Kentta
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {

        private int vuoro;

        private int laskuri = 0;
        private int laskuri2 = 0;

        private bool poistoTilaa { get; set; }
        private bool moveTila = false;

        private bool lisaystila1 = false;
        private bool lisaystila2 = false;

        private Brush kaytossaOlevaVari;
        private Brush kaytossaOlevaVari2;

        private Brush perusReunaVari;
        private Brush valittuReunaVari;

        private Brush kentanNappulanVari;

        private int pelaaja1NappulatLkm;
        private int pelaaja2NappulatLkm;

        private int pelaaja1vNro = 1;
        private int pelaaja2vNro = 2;

        private bool kaikkiNappulatLisattyKentalle = false;


        private string nimi = "Pelaaja1";
        public string Nimi
        {
            get
            {
                return nimi;
            }
            set
            {
                if (value != nimi)
                {
                    nimi = value;
                    onPropertyChanged("Nimi");
                }
            }
        }



        private void onPropertyChanged(string p)
        {
            p1Name.Content = nimi;
            myllypelaaja1 = "Mylly! " + nimi + ", valitse palikka poistettavaksi";
        }


        private string nimi2 = "Pelaaja2";
        public string Nimi2
        {
            get
            {
                return nimi2;
            }
            set
            {
                nimi2 = value;
                onPropertyChanged2(value);
            }
        }

        private void onPropertyChanged2(string value)
        {
            p12Name.Content = value;
            myllypelaaja2 = "Mylly! " + nimi2 + ", valitse palikka poistettavaksi";
        }

        string myllypelaaja2 = "Mylly! Pelaaja2, valitse palikka poistettavaksi";
        string myllypelaaja1 = "Mylly! Pelaaja1, valitse palikka poistettavaksi";

        NappulaEllipsi.UserControl1 hetkellinenTallennus;
        NappulaEllipsi.UserControl1[] et = new NappulaEllipsi.UserControl1[24];

        public UserControl1()
        {
            InitializeComponent();

           

            et[0] = e1;
            et[1] = e2;
            et[2] = e3;
            et[3] = e4;
            et[4] = e5;
            et[5] = e6;
            et[6] = e7;
            et[7] = e8;
            et[8] = e9;
            et[9] = e10;
            et[10] = e11;
            et[11] = e12;
            et[12] = e13;
            et[13] = e14;
            et[14] = e15;
            et[15] = e16;
            et[16] = e17;
            et[17] = e18;
            et[18] = e19;
            et[19] = e20;
            et[20] = e21;
            et[21] = e22;
            et[22] = e23;
            et[23] = e24;

            pelaaja1NappulatLkm = 0;
            pelaaja2NappulatLkm = 0;

            poistoTilaa = false;

            Random rand = new Random();
            double luku = rand.NextDouble();
            if (luku < 0.5) { vuoro = pelaaja1vNro; }
            else { vuoro = pelaaja2vNro; }
            e25.Pelaaja = vuoro;

            getEllipseOutOfFocus();
        }


        /// <summary>
        /// Lasketaan pelaajien kentällä olevat nappulat
        /// </summary>
        private void laskepelaajienNappulat()
        {
            if (kaikkiNappulatLisattyKentalle == true)
            {
                pelaaja1NappulatLkm = 0;
                pelaaja2NappulatLkm = 0;
                for (int i = 0; i < et.Length; i++)
                {
                    if (et[i].Pelaaja == pelaaja1vNro) pelaaja1NappulatLkm++;
                    else if (et[i].Pelaaja == pelaaja2vNro) pelaaja2NappulatLkm++;
                    e26.Pelaaja = pelaaja1NappulatLkm;
                    e27.Pelaaja = pelaaja2NappulatLkm;
                }
            }
        }

        /// <summary>
        /// Asetetaan vuoro seuraavalle pelaajalle
        /// </summary>
        /// <returns></returns>
        public int nextVuoro()
        {
            if (vuoro == pelaaja1vNro) vuoro = pelaaja2vNro;
            else vuoro = pelaaja1vNro;
            return vuoro;
        }

        /// <summary>
        /// palautetaan pelaaja1:n nappuloisen määrä kentalla
        /// </summary>
        /// <returns></returns>
        public int getLaskurinArvo()
        {
            return laskuri;
        }

        /// <summary>
        /// pelaaja2:n kentällä olevat nappula
        /// </summary>
        /// <returns></returns>
        public int getLaskurinArvo2()
        {
            return laskuri2;
        }

        /// <summary>
        /// Asetetaan kaikkien nappuloiden focusable-tila trueksi
        /// </summary>
        public void getEllipse()
        {
            for (int i = 0; i < et.Length; i++)
            {
                et[i].Focusable = true;
            }
        }

        /// <summary>
        /// kaikki nappulat on kohdistettavissa (pelaaja1)
        /// </summary>
        public void getEllipsePelaaja1()
        {
            for (int i = 0; i < et.Length; i++)
            {
                if (et[i].Pelaaja == pelaaja1vNro) et[i].Focusable = true;
            }
        }

        /// <summary>
        /// kaikki nappulat on kohdistettavissa (pelaaja2)
        /// </summary>
        public void getEllipsePelaaja2()
        {
            for (int i = 0; i < et.Length; i++)
            {
                if (et[i].Pelaaja == pelaaja2vNro) et[i].Focusable = true;
            }
        }

        /// <summary>
        /// Kaikki nappulat ei ole kohdistettavissa (pelaaja1)
        /// </summary>
        public void getEllipseOutOfFocusPelaaja1()
        {
            for (int i = 0; i < et.Length; i++)
            {
                if (et[i].Pelaaja == pelaaja1vNro) et[i].Focusable = false;
            }
        }

        /// <summary>
        /// Kaikki nappulat ei ole kohdistettavissa (pelaaja2)
        /// </summary>
        public void getEllipseOutOfFocusPelaaja2()
        {
            for (int i = 0; i < et.Length; i++)
            {
                if (et[i].Pelaaja == pelaaja2vNro) et[i].Focusable = false;
            }
        }


        /// <summary>
        /// kaikki nappulat epäkohdistettavissa
        /// </summary>
        public void getEllipseOutOfFocus()
        {
            for (int i = 0; i < et.Length; i++)
            {
                et[i].Focusable = false;
            }
        }

        /// <summary>
        /// Palautetaan ilmoitustaulun tiedot
        /// </summary>
        /// <returns></returns>
        public string getIlmoitusLabelInfo()
        {
            return ilmoitusLabel.Content.ToString();
        }

        /// <summary>
        /// Lisätään nappula
        /// </summary>
        /// <param name="sender"></param>
        public void addNappula(Ellipse sender)
        {

          /*  Ellipse el = sender;
            sender.Fill = System.Windows.Media.Brushes.Tomato;
            getEllipseOutOfFocus();
            laskuri++;*/
        }


        /// <summary>
        /// Nappulaa painettaessa hiirellä joko lisätään, poistetaan tai muokataan nappuloita riippuen tilanteesta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void e22_MouseDown(object sender, MouseButtonEventArgs e)
        {

            // luodaan kopio siitä nappulasta, jota klikattiin
            NappulaEllipsi.UserControl1 ekopio = (NappulaEllipsi.UserControl1)sender;

           /* if ((ilmoitusLabel.Content.ToString().Contains(Nimi)) && (!(ilmoitusLabel.Content.ToString().Contains("Mylly"))))
            {
            
            }*/
            // jos on mylly (pelaaja1)
            if (ilmoitusLabel.Content.ToString().Equals(myllypelaaja1))
            {
                if (hetkellinenTallennus != null) hetkellinenTallennus.Pelaaja = 0;

                if (ekopio.Pelaaja == pelaaja2vNro && ekopio.OnkoKentalla)
                {
                    // painettu nappula poistuu
                    ekopio.Height = ekopio.Height / 1.5;
                    ekopio.Width = ekopio.Width / 1.5;
                    ekopio.Color = kentanNappulanVari;
                    ekopio.reunaVari = perusReunaVari;
                    poistoTilaa = false;
                    ekopio.OnkoPoistettu = true;
                    ekopio.OnkoKentalla = false;
                    ekopio.Pelaaja = 0;
                    nextVuoro();
                    e25.Pelaaja = vuoro;
                    laskepelaajienNappulat();
                    return;
                }
                else return;
            }

            // jos on mylly (pelaaja2)
            // kaksi lähes identtistä koodinpätkää, mutta tarvitaan, jossa molempia ei voi valita
            if (ilmoitusLabel.Content.ToString().Equals(myllypelaaja2))
            {
                if (hetkellinenTallennus != null) hetkellinenTallennus.Pelaaja = 0;

                if (ekopio.Pelaaja == pelaaja1vNro && ekopio.OnkoKentalla)
                {
                    ekopio.Height = ekopio.Height / 1.5;
                    ekopio.Width = ekopio.Width / 1.5;
                    ekopio.Color = kentanNappulanVari;
                    ekopio.reunaVari = perusReunaVari;
                    poistoTilaa = false;
                    ekopio.OnkoPoistettu = true;
                    ekopio.OnkoKentalla = false;
                    ekopio.Pelaaja = 0;
                    nextVuoro();
                    e25.Pelaaja = vuoro;
                    laskepelaajienNappulat();
                    return;
                }
                else return;
            }

            // jos movetila on päällä 
            if (moveTila)
            {

                if (ilmoitusLabel.Content.ToString().Contains(Nimi2) && ilmoitusLabel.Content.ToString().Contains("siirrä") && ekopio.Pelaaja == 2)
                    ekopio.Focusable = true;
                if (ilmoitusLabel.Content.ToString().Contains(Nimi) && ilmoitusLabel.Content.ToString().Contains("siirrä") && ekopio.Pelaaja == 1)
                    ekopio.Focusable = true;
                // jos nappula on valittavissa, vaihdetaan valittua nappulaa tai alustetaan valittu nappula
                // hetkellinen tallennus poistuu ja tulee uusi hetkellinen tallennus
                if (ekopio.Focusable && ekopio.Background != Brushes.Green && ekopio.Pelaaja != 0)
                {
                    if (hetkellinenTallennus != null)
                    {
                        hetkellinenTallennus.Valittu = false;
                        hetkellinenTallennus.reunaVari = perusReunaVari;
                    }
                    hetkellinenTallennus = ekopio;
                    hetkellinenTallennus.reunaVari = valittuReunaVari;
                    hetkellinenTallennus.Valittu = true;
                }



                // jos valittu nappula ei ole jo pelaajan nappula ja siihen voi siirtää
                if (ekopio.OnkoKentalla == false && ekopio.Background == Brushes.Green && hetkellinenTallennus.Pelaaja == vuoro)
                {

                    moveTila = false;


                    hetkellinenTallennus.Pelaaja = 0;
                    ekopio.Color = hetkellinenTallennus.Color;
                    ekopio.reunaVari = perusReunaVari;
                    ekopio.Height = ekopio.Height * 1.5;
                    ekopio.Width = ekopio.Width * 1.5;
                    ekopio.Pelaaja = vuoro;
                    ekopio.OnkoKentalla = true;
                    ekopio.OnkoPoistettu = false;  // muutetaan nykyinen valittu kentan nappulaksi


                    hetkellinenTallennus.Height = hetkellinenTallennus.Height / 1.5;
                    hetkellinenTallennus.Valittu = false;
                    hetkellinenTallennus.Width = hetkellinenTallennus.Width / 1.5;
                    hetkellinenTallennus.Color = kentanNappulanVari;
                    hetkellinenTallennus.reunaVari = perusReunaVari;
                    hetkellinenTallennus.OnkoKentalla = false;
                    hetkellinenTallennus.OnkoPoistettu = true;
                    if (ilmoitusLabel.Content.ToString().Contains("Mylly")) return;

                    if (ilmoitusLabel.Content.ToString().Contains(Nimi))
                        getEllipseOutOfFocusPelaaja1();
                    else getEllipseOutOfFocusPelaaja2();
                    nextVuoro();

                   
                    return;
                }
                else return; ;
            }
            // poistotila ei ollut käytössä = poistetaan edellinen nappulanvalinta
            if (hetkellinenTallennus != null)
            {
                hetkellinenTallennus.reunaVari = perusReunaVari;
                //hetkellinenTallennus  = null;
            }

            // jos nappuloita on jäljellä
            if (lisaystila1 && laskuri < 9 || lisaystila2 && laskuri2 < 9)
            {
                // jos valittu ei ole jo lisätty nappula ja lisäystila on päällä = lisätään nappula
                if (ekopio.OnkoKentalla == false && ekopio.Focusable == true)
                {
                    //e25.Pelaaja = vuoro;
                    ekopio.Height = ekopio.Height * 1.5;
                    ekopio.Width = ekopio.Width * 1.5;
                    ekopio.OnkoKentalla = true;
                    if (lisaystila1)
                    {
                        laskuri++;
                        ekopio.Color = kaytossaOlevaVari;
                        ekopio.Pelaaja = pelaaja1vNro;
                    }
                    else
                    {
                        laskuri2++;
                        ekopio.Color = kaytossaOlevaVari2;
                        ekopio.Pelaaja = pelaaja2vNro;
                    }
                    getEllipseOutOfFocus();
                    lisaystila1 = false;
                    lisaystila2 = false;

                    if (ilmoitusLabel.Content.ToString().Contains("Mylly")) return;
                    nextVuoro();
                    e25.Pelaaja = vuoro;
                    return;
                }

                // jos valittu nappula on kentällä, mutta sitä ei olla lisäämässä 
                if (ekopio.OnkoKentalla == true)
                {

                    ekopio.reunaVari = valittuReunaVari;
                    hetkellinenTallennus = ekopio;

                }
            }

          
            laskepelaajienNappulat();
        }


        private void Ellipse_Drop(Object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Ellipse"))
            {

                Ellipse a = e.Data.GetData("Ellipse") as Ellipse; // uus Ellipse
                Ellipse ab = (Ellipse)sender;

                try
                {
                    Grid azz = (Grid)a.Parent;
                    azz.Children.Remove(a);
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Jotain vikaa!" + ex);
                    return;
                }

                ab.Fill = a.Fill;
                laskuri++;
            }
        }

        /// <summary>
        /// Kun kaikki nappulat on kentällä
        /// </summary>
        public void KaikkiLisatty()
        {
            kaikkiNappulatLisattyKentalle = true;
            e28.Pelaaja = 0;
        }

        /// <summary>
        /// Asetetaan movetila
        /// </summary>
        public void MoveTila()
        {

            moveTila = true;

            if (vuoro == pelaaja1vNro)
            {
                if (pelaaja1NappulatLkm == 3) e25.OnkoPoistettu = false;
                else e25.OnkoPoistettu = true;
                e25.Pelaaja = pelaaja1vNro;
                //getEllipsePelaaja1();
            }
            else if (vuoro == pelaaja2vNro)
            {
                if (pelaaja2NappulatLkm == 3) e25.OnkoPoistettu = false;
                else e25.OnkoPoistettu = true;
                e25.Pelaaja = pelaaja2vNro;
                //getEllipsePelaaja2();
            }
            else e25.Pelaaja = vuoro;
        }


        /// <summary>
        /// Asetetaan poistotilalle arvo true
        /// </summary>
        public void poistoTila()
        {
            poistoTilaa = true;
        }

        /// <summary>5
        /// Palautetaan väliaikainen nappula
        /// </summary>
        /// <returns></returns>
        public bool hetkellisestiTallennettu()
        {
            return (hetkellinenTallennus != null);
        }

        /// <summary>
        /// palautetaan käytössä oleva väri
        /// </summary>
        /// <param name="vari"></param>
        public void KaytossaOlevaVari(Brush vari)
        {
            kaytossaOlevaVari = vari;
        }


        public void lisaystila2True()
        {
            lisaystila2 = true;
        }

        public void lisaystila1True()
        {
            lisaystila1 = true;
        }



        public void RemoveValittu()
        {
            if (hetkellinenTallennus != null) hetkellinenTallennus.reunaVari = perusReunaVari;
        }

        public int getMyllyTila()
        {
            //if (ilmoitusLabel.Content.ToString().Equals(myllypelaaja1)) return 1;
            //if (ilmoitusLabel.Content.ToString().Equals(myllypelaaja2)) return 2;
            return 0;
        }


        public void KaytossaOlevaVariPelaaja2(Brush varit2)
        {
            kaytossaOlevaVari2 = varit2;
        }

        /// <summary>
        /// Asetetaan pelaajien nimet
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        public void AsetaNimet(string p1, string p2)
        {
            Nimi = p1;
            Nimi2 = p2;
        }


        /// <summary>
        /// Pelaajan vuoro 
        /// </summary>
        /// <returns></returns>
        public int getVuoro()
        {
            return vuoro;
        }


        public void AsetaVarit(Brush variP1, Brush variP2)
        {
            perusReunaVari = Brushes.Black;
            valittuReunaVari = Brushes.SteelBlue;
            kaytossaOlevaVari = variP1;
            kaytossaOlevaVari2 = variP2;
            kentanNappulanVari = Brushes.Black;
            
        }
    }





    // lähde kopsattu netistä : https://msdn.microsoft.com/en-us/library/system.windows.data.imultivalueconverter(v=vs.100).aspx 
    // tehty muutoksia alkuperäiseen
    /// <summary>
    /// Muuttaa merkkijonon tekstiä sen perusteella, onko arvoina true niin, 
    /// että 3x3 taulukossa vierekkäisistä objekteista tulee merkkijono true
    /// == teksti "Valmis rivi", mutten "Peli kesken!"
    /// </summary>
    public class ShowNaapurit : IMultiValueConverter
    {

        public object Convert(Object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush eiVoiSiirtaa = Brushes.Transparent;
            Brush voiSiirtaa = Brushes.Green;

            //Jos eka arvo on true, näytetään kaikki
            if (!(bool)values[0] && (!(bool)values[1])) return voiSiirtaa;
            if ((bool)values[1]) return eiVoiSiirtaa; // itse nappula, pitää olla false tai palautetaan vakio

            bool c2, c3, c4, c5;  // mahdollisia naapureita voi olla 2-4

            c2 = ((bool)values[2]); if (c2) return voiSiirtaa;
            c3 = ((bool)values[3]); if (c3) return voiSiirtaa;  // katsotaan ensin helpot kaksi, nämä ei voi olla null
            try { c4 = ((bool)values[4]); }
            catch (IndexOutOfRangeException ex) { c4 = false; }
            try { c5 = ((bool)values[5]); }
            catch (IndexOutOfRangeException ex) { c5 = false; }

            switch ((string)parameter)
            {
                case "1":
                    if (c4 || c5) return Brushes.Green;

                    break;
                case "2": return eiVoiSiirtaa; //turha; muistutus itselle että keisseja voi lisätä

            }

            return eiVoiSiirtaa;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            Object[] a = new object[2];
            return a;
        }

    }

    /// <summary>
    /// Kentän piirtämiseen 
    /// </summary>
    public class HalfValueConverter : IMultiValueConverter
    {
        #region IMultiValueConverter Members

        public object Convert(object[] values,
                              Type targetType,
                              object parameter,
                              CultureInfo culture)
        {
            if (values == null || values.Length < 2)
            {
                throw new ArgumentException(
                    "HalfValueConverter expects 2 double values to be passed" +
                    " in this order -> totalWidth, width",
                    "values");
            }

            double totalWidth = (double)values[0];
            double width = (double)values[1];
            return (object)((totalWidth - width) / 2);
        }

        public object[] ConvertBack(object value,
                                    Type[] targetTypes,
                                    object parameter,
                                    CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    /// <summary>
    /// Oma canvas-luokka, joka lisää pari propertya avuksi. HalfWidth ja HalfHeight antavat puolitetun todellisen leveyden ja korkeuden ja näihin voi bindata xamlista
    /// </summary>
    public class OwnCanvas : Canvas
    {
        public OwnCanvas()
        {
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            SizeChanged += OwnCanvas_SizeChanged;
        }

        void OwnCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            HalfWidth = ActualWidth / 2;
            HalfHeight = ActualHeight / 2;
        }


        public double HalfWidth
        {
            get { return (double)GetValue(HalfWidthProperty); }
            set { SetValue(HalfWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HalfWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HalfWidthProperty =
            DependencyProperty.Register("HalfWidth", typeof(double), typeof(OwnCanvas), new PropertyMetadata(0.0));


        public double HalfHeight
        {
            get { return (double)GetValue(HalfHeightProperty); }
            set { SetValue(HalfHeightProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HalfHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HalfHeightProperty =
            DependencyProperty.Register("HalfHeight", typeof(double), typeof(OwnCanvas), new PropertyMetadata(0.0));
    }
    // lähde kopsattu netistä : https://msdn.microsoft.com/en-us/library/system.windows.data.imultivalueconverter(v=vs.100).aspx 
    // tehty muutoksia alkuperäiseen
    /// <summary>
    /// Muuttaa merkkijonon tekstiä sen perusteella, onko arvoina true niin, 
    /// että 3x3 taulukossa vierekkäisistä objekteista tulee merkkijono true
    /// == teksti "Valmis rivi", mutten "Peli kesken!"
    /// </summary>
    public class NameConverter : IMultiValueConverter
    {
        int[] myllyt = new int[16];
        int[] myllyt2 = new int[16];

        public object Convert(Object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name = "Pelaaja1";
            string name2 = "Pelaaja2";
            switch ((string)parameter)
            {
                case "FormatLastFirst":
                    int c1 = ((int)values[0]);
                    int c2 = ((int)values[1]);
                    int c3 = ((int)values[2]);
                    int c4 = ((int)values[3]);
                    int c5 = ((int)values[4]);
                    int c6 = ((int)values[5]);
                    int c7 = ((int)values[6]);
                    int c8 = ((int)values[7]);
                    int c9 = ((int)values[8]);
                    int c10 = ((int)values[9]);
                    int c11 = ((int)values[10]);
                    int c12 = ((int)values[11]);
                    int c13 = ((int)values[12]);
                    int c14 = ((int)values[13]);
                    int c15 = ((int)values[14]);
                    int c16 = ((int)values[15]);
                    int c17 = ((int)values[16]);
                    int c18 = ((int)values[17]);
                    int c19 = ((int)values[18]);
                    int c20 = ((int)values[19]);
                    int c21 = ((int)values[20]);
                    int c22 = ((int)values[21]);
                    int c23 = ((int)values[22]);
                    int c24 = ((int)values[23]); // nappulat
                    int c25 = ((int)values[24]); // 
                    int c26 = ((int.Parse(values[25].ToString()))); // pelaaja1NappuloidenLkm
                    int c27 = ((int.Parse(values[26].ToString())));  // pelaaja1NappuloidenLkm
                    int c28 = ((int.Parse(values[27].ToString())));

                    if (values[28] != null && values[29] != null)
                    {
                        string c29 = values[28].ToString(); // nimi1
                        string c30 = values[29].ToString(); // nimi2
                        name = c29;
                        name2 = c30;
                    }

                    string myllypelaaja1 = "Mylly! " + name + ", valitse palikka poistettavaksi";
                    string myllypelaaja2 = "Mylly! " + name2 + ", valitse palikka poistettavaksi";

                    string pelaaja1LisaaNappula = name + ", lisaa nappula";
                    string pelaaja2LisaaNappula = name2 + ", lisaa nappula";

                    // pelaaja1
                    // vaakarivit
                    if ((!(c1 == 1) || !(c2 == 1) || !(c3 == 1))) { myllyt[0] = 0; }
                    if (c1 == 1 && c2 == 1 && c3 == 1 && myllyt[0] == 0) { myllyt[0] = 1; return name = myllypelaaja1; }

                    if ((!(c4 == 1) || !(c5 == 1) || !(c6 == 1)) && myllyt[1] == 1) { myllyt[1] = 0; }
                    if (c4 == 1 && c5 == 1 && c6 == 1 && myllyt[1] == 0) { myllyt[1] = 1; return name = myllypelaaja1; }

                    if ((!(c7 == 1) || !(c8 == 1) || !(c9 == 1)) && myllyt[2] == 1) { myllyt[2] = 0; }
                    if (c7 == 1 && c8 == 1 && c9 == 1 && myllyt[2] == 0) { myllyt[2] = 1; return name = myllypelaaja1; }

                    if (!(c10 == 1) || !(c11 == 1) || !(c12 == 1) && myllyt[3] == 1) { myllyt[3] = 0; }
                    if (c10 == 1 && c11 == 1 && c12 == 1 && myllyt[3] == 0) { myllyt[3] = 1; return name = myllypelaaja1; }

                    if (!(c13 == 1) || !(c14 == 1) || !(c15 == 1) && myllyt[4] == 1) { myllyt[4] = 0; }
                    if (c13 == 1 && c14 == 1 && c15 == 1 && myllyt[4] == 0) { myllyt[4] = 1; return name = myllypelaaja1; }

                    if (!(c16 == 1) || !(c17 == 1) || !(c18 == 1) && myllyt[5] == 1) { myllyt[5] = 0; }
                    if (c16 == 1 && c17 == 1 && c18 == 1 && myllyt[5] == 0) { myllyt[5] = 1; return name = myllypelaaja1; }

                    if (!(c19 == 1) || !(c20 == 1) || !(c21 == 1) && myllyt[6] == 1) { myllyt[6] = 0; }
                    if (c19 == 1 && c20 == 1 && c21 == 1 && myllyt[6] == 0) { myllyt[7] = 1; return name = myllypelaaja1; }

                    if (!(c22 == 1) || !(c23 == 1) || !(c24 == 1) && myllyt[7] == 1) { myllyt[7] = 0; }
                    if (c22 == 1 && c23 == 1 && c24 == 1 && myllyt[7] == 0) { myllyt[7] = 1; return name = myllypelaaja1; }





                    if (!(c1 == 1) || !(c10 == 1) || !(c22 == 1) && myllyt[8] == 1) { myllyt[8] = 0; }
                    if (c1 == 1 && c10 == 1 && c22 == 1 && myllyt[8] == 0) { myllyt[8] = 1; return name = myllypelaaja1; }

                    if (!(c4 == 1) || !(c11 == 1) || !(c19 == 1) && myllyt[9] == 1) { myllyt[9] = 0; }
                    if (c4 == 1 && c11 == 1 && c19 == 1 && myllyt[9] == 0) { myllyt[9] = 1; return name = myllypelaaja1; }

                    if (!(c7 == 1) || !(c12 == 1) || !(c16 == 1) && myllyt[10] == 1) { myllyt[10] = 0; }
                    if (c7 == 1 && c12 == 1 && c16 == 1 && myllyt[10] == 0) { myllyt[10] = 1; return name = myllypelaaja1; }

                    if (!(c2 == 1) || !(c5 == 1) || !(c8 == 1) && myllyt[11] == 1) { myllyt[11] = 0; }
                    if (c2 == 1 && c5 == 1 && c8 == 1 && myllyt[11] == 0) { myllyt[11] = 1; return name = myllypelaaja1; }

                    if (!(c9 == 1) || !(c13 == 1) || !(c18 == 1) && myllyt[12] == 1) { myllyt[12] = 0; }
                    if (c9 == 1 && c13 == 1 && c18 == 1 && myllyt[12] == 0) { myllyt[12] = 1; return name = myllypelaaja1; }

                    if (!(c6 == 1) || !(c14 == 1) || !(c21 == 1) && myllyt[13] == 1) { myllyt[13] = 0; }
                    if (c6 == 1 && c14 == 1 && c21 == 1 && myllyt[13] == 0) { myllyt[13] = 1; return name = myllypelaaja1; }

                    if (!(c3 == 1) || !(c15 == 1) || !(c24 == 1) && myllyt[14] == 1) { myllyt[14] = 0; }
                    if (c3 == 1 && c15 == 1 && c24 == 1 && myllyt[14] == 0) { myllyt[14] = 1; return name = myllypelaaja1; }

                    if (!(c17 == 1) || !(c20 == 1) || !(c23 == 1) && myllyt[15] == 1) { myllyt[15] = 0; }
                    if (c17 == 1 && c20 == 1 && c23 == 1 && myllyt[15] == 0) { myllyt[15] = 1; return name = myllypelaaja1; }



                    //pelaaja 2
                    if (!(c1 == 2) || !(c2 == 2) || !(c3 == 2) && myllyt2[0] == 1) { myllyt2[0] = 0; }
                    if (c1 == 2 && c2 == 2 && c3 == 2 && myllyt2[0] == 0) { myllyt2[0] = 1; return name = myllypelaaja2; }

                    if (!(c4 == 2) || !(c5 == 2) || !(c6 == 2) && myllyt2[1] == 1) { myllyt2[1] = 0; }
                    if (c4 == 2 && c5 == 2 && c6 == 2 && myllyt2[1] == 0) { myllyt2[1] = 1; return name = myllypelaaja2; }

                    if (!(c7 == 2) || !(c8 == 2) || !(c9 == 2) && myllyt2[3] == 1) { myllyt2[3] = 0; }
                    if (c7 == 2 && c8 == 2 && c9 == 2 && myllyt2[2] == 0) { myllyt2[2] = 1; return name = myllypelaaja2; }

                    if (!(c10 == 2) || !(c11 == 2) || !(c12 == 2) && myllyt2[3] == 1) { myllyt2[3] = 0; }
                    if (c10 == 2 && c11 == 2 && c12 == 2 && myllyt2[3] == 0) { myllyt2[3] = 1; return name = myllypelaaja2; }

                    if (!(c13 == 2) || !(c14 == 2) || !(c15 == 2) && myllyt2[4] == 1) { myllyt2[4] = 0; }
                    if (c13 == 2 && c14 == 2 && c15 == 2 && myllyt2[4] == 0) { myllyt2[4] = 1; return name = myllypelaaja2; }

                    if (!(c16 == 2) || !(c17 == 2) || !(c18 == 2) && myllyt2[5] == 1) { myllyt2[5] = 0; }
                    if (c16 == 2 && c17 == 2 && c18 == 2 && myllyt2[5] == 0) { myllyt2[5] = 1; return name = myllypelaaja2; }

                    if (!(c19 == 2) || !(c20 == 2) || !(c21 == 2) && myllyt2[6] == 2) { myllyt2[6] = 0; }
                    if (c19 == 2 && c20 == 2 && c21 == 2 && myllyt2[6] == 0) { myllyt2[6] = 1; return name = myllypelaaja2; }

                    if (!(c22 == 2) || !(c23 == 2) || !(c24 == 2) && myllyt2[7] == 2) { myllyt2[7] = 0; }
                    if (c22 == 2 && c23 == 2 && c24 == 2 && myllyt2[7] == 0) { myllyt2[7] = 1; return name = myllypelaaja2; }


                    // pystyrivit                      
                    if (!(c1 == 2) || !(c10 == 2) || !(c22 == 2) && myllyt2[8] == 1) { myllyt2[8] = 0; }
                    if (c1 == 2 && c10 == 2 && c22 == 2 && myllyt2[8] == 0) { myllyt2[8] = 1; return name = myllypelaaja2; }

                    if (!(c4 == 2) || !(c11 == 2) || !(c19 == 2) && myllyt2[9] == 1) { myllyt2[9] = 0; }
                    if (c4 == 2 && c11 == 2 && c19 == 2 && myllyt2[9] == 0) { myllyt2[9] = 1; return name = myllypelaaja2; }

                    if (!(c7 == 2) || !(c12 == 2) || !(c16 == 2) && myllyt2[10] == 1) { myllyt2[10] = 0; }
                    if (c7 == 2 && c12 == 2 && c16 == 2 && myllyt2[10] == 0) { myllyt2[10] = 1; return name = myllypelaaja2; }

                    if (!(c2 == 2) || !(c5 == 2) || !(c8 == 2) && myllyt2[11] == 1) { myllyt2[11] = 0; }
                    if (c2 == 2 && c5 == 2 && c8 == 2 && myllyt2[11] == 0) { myllyt2[11] = 1; return name = myllypelaaja2; }

                    if (!(c9 == 2) || !(c13 == 2) || !(c18 == 2) && myllyt2[12] == 1) { myllyt2[12] = 0; }
                    if (c9 == 2 && c13 == 2 && c18 == 2 && myllyt2[12] == 0) { myllyt2[12] = 1; return name = myllypelaaja2; }

                    if (!(c6 == 2) || !(c14 == 2) || !(c21 == 2) && myllyt2[13] == 1) { myllyt2[13] = 0; }
                    if (c6 == 2 && c14 == 2 && c21 == 2 && myllyt2[13] == 0) { myllyt2[13] = 1; return name = myllypelaaja2; }

                    if (!(c3 == 2) || !(c15 == 2) || !(c24 == 2) && myllyt2[14] == 1) { myllyt2[14] = 0; }
                    if (c3 == 2 && c15 == 2 && c24 == 2 && myllyt2[14] == 0) { myllyt2[14] = 1; return name = myllypelaaja2; }

                    if (!(c17 == 2) || !(c20 == 2) || !(c23 == 2) && myllyt2[15] == 1) { myllyt2[15] = 0; }
                    if (c17 == 2 && c20 == 2 && c23 == 2 && myllyt2[15] == 0) { myllyt2[15] = 1; return name = myllypelaaja2; }


                    // Voitto pelaajalle 1
                    if (c27 < 3)
                    {
                        
                        return name + " on voittanut pelin! Onneksi olkoon!";
                    }
                    //Voitto pelaajalle 2
                    if (c26 < 3)
                    {
                        

                        return name2 + " on voittanut pelin! Onneksi olkoon!";
                    }

                    // pelaaja 1 siirtovuoro
                    if (c25.Equals(1) && c28 != 0)
                    {
                        return name = name + ", lisää nappula";
                    }

                    // pelaaja 2 siirtovuoro
                    if (c25.Equals(2) && c28 != 0)
                    {
                        return name = name2 + ", lisää nappula";
                    }

                    // pelaaja 1 siirtovuoro
                    if (c25.Equals(1) && c28 == 0)
                    {
                        if (c26 == 3) return name = name + ", siirrä nappulaa mihin tahansa kohtaan!";
                        return name = name + ", siirrä nappulaa";
                    }

                    // pelaaja 1 siirtovuoro
                    if (c25.Equals(2) && c28 == 0)
                    {
                        if (c27 == 3) return name = name2 + ", siirrä nappulaa mihin tahansa kohtaan!";
                        return name = name2 + ", siirrä nappulaa";
                    }

                    return name;
                default:
                    name = "Pelaaja, lisää nappula";
                    break;
            }

            return name;
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            string[] splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }





}

