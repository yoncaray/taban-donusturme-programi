using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabanDonusturme
{
    public partial class frmTabanDonusturme : Form
    {
        public frmTabanDonusturme()
        {
            InitializeComponent();
        }

        private void btnDonustur_Click(object sender, EventArgs e)
        {
            string asilTaban = cmbAsilTaban.Text;
            string donusturulecekTaban = cmbDonusturulecekTaban.Text;
            string sayi = txtSayi.Text;
            string[] dizi = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

            if (cmbAsilTaban.Text == "" || cmbDonusturulecekTaban.Text == "" || txtSayi.Text == "") MessageBox.Show("Lütfen alanları doldurun!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                if (tabanKontrol(sayi, asilTaban, dizi) == true) MessageBox.Show("Sayı " + asilTaban + " tabanında değildir!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    if (donusturulecekTaban == "10") txtSonuc.Text = onluTabanaCevirme(sayi, asilTaban, dizi);
                    else
                    {
                        sayi = onluTabanaCevirme(sayi, asilTaban, dizi);
                        txtSonuc.Text = onluTabandanCevirme(sayi, donusturulecekTaban, dizi);
                    }
                }
            }
                        
        }

        static string onluTabanaCevirme(string sayi, string asilTaban, string[] dizi)
        {
            double toplam = 0;
            int sayac = sayi.Length - 1;
            for (int i = 0; i < sayi.Length; i++)
            {
                int index = Array.IndexOf(dizi, sayi[i].ToString());
                toplam += index * Math.Pow(Convert.ToUInt32(asilTaban), sayac);
                sayac--;
            }
            string sonuc = toplam.ToString();
            return sonuc;
        }
      
        static string onluTabandanCevirme(string sayi, string donusturulecekTaban, string[] dizi)
        {
            int kalan;
            string sonuc = "";
            int yedekSayi = int.Parse(sayi);
            int bolen = int.Parse(donusturulecekTaban);
            while (yedekSayi > 0)
            {
                kalan = yedekSayi % bolen;
                sonuc = dizi[kalan].ToString() + sonuc;
                yedekSayi /= bolen;
            }
            return sonuc;
        }

        static bool tabanKontrol(string sayi, string asilTaban, string[] dizi)
        {
            bool sonuc = false;
            for (int i = 0; i < sayi.Length; i++)
            {
                int index = Array.IndexOf(dizi, sayi[i].ToString());
                if (index >= int.Parse(asilTaban))
                {
                    sonuc = true;
                    break;
                }
            }
            return sonuc;
        }

        private void txtSayi_TextChanged(object sender, EventArgs e)
        {
            txtSayi.Text = txtSayi.Text.ToUpper();
            txtSayi.SelectionStart = txtSayi.Text.Length;
        }
    }
}
