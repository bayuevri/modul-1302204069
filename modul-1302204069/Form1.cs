using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modul_1302204069
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, EventArgs e)
        {
            // Mendapatkan angka dari tombol yang ditekan
            Button btn = (Button)sender;
            string stringNumber = btn.Text;

            // Cek jika operator duplikat dan invalid
            if (!isDuplicateOperator(stringNumber) && !isInvalid(stringNumber))
            {
                // Menampilkan tombol yang ditekan
                this.label_calculation.Text += stringNumber;
            }

            // Method untuk mengecek operator ditulis sebagai huruf pertama
            Boolean isInvalid(string num)
            {
                string label = this.label_calculation.Text;
                int length = label.Length;

                return (length == 0 && num.Equals("+"));
            }

            // Method untuk mengecek operator duplikat
            // Contoh: 123 + 32 ++ 232
            Boolean isDuplicateOperator(string num)
            {
                string label = this.label_calculation.Text;
                int length = label.Length;

                if (length > 0 && num.Equals("+"))
                {
                    return getLastChar(label) == '+';
                }

                return false;
            }
        }

        private void btn_calculate_Click(object sender, EventArgs e)
        {
            // Cek jika operator berada di akhir kalimat matematika.
            if (isInvalid()) return;

            // Mengambil teks label
            string stringCalculate = this.label_calculation.Text;

            // Memisahkan tiap angka dengan operator '+'
            string[] stringCalculateSplit = stringCalculate.Split('+');

            // Menjumlahkan tiap angka dari field split
            int calculate = 0;
            for (int i = 0; i < stringCalculateSplit.Length; i++)
            {
                calculate += Convert.ToInt32(stringCalculateSplit[i]);
            }

            // Menampilkan hasil hitung dari field calculate
            this.label_calculation.Text = calculate.ToString();

            // Method untuk mengecek operator berada diakhir kalimat matematika
            // Contoh: 12 +
            Boolean isInvalid()
            {
                return getLastChar(this.label_calculation.Text) == '+';
            }
        }

        private char getLastChar(string text)
        {
            return text[text.Length - 1];
        }
    }
}
