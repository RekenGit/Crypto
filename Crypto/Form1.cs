using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Crypto
{
    public partial class Form1 : Form
    {
        int CheckBox1 = 0, CheckBox2 = 0;
        string Binary, Input;
        bool stop;

        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(0, true);
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control appWindow = (Control)sender;
            double x = (appWindow.Size.Width - 156) / 2;
            int size = Convert.ToInt32(Math.Round(x));
            textBox1.Size = new Size(size, appWindow.Size.Height);
            textBox2.Size = new Size(size, appWindow.Size.Height);
        }
        private void CheckedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox1 = checkedListBox1.SelectedIndex;
            for (int x = 0; x < checkedListBox1.Items.Count; x++) if (CheckBox1 != x) checkedListBox1.SetItemChecked(x, false);
        }
        private void CheckedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckBox2 = checkedListBox2.SelectedIndex;
            for (int x = 0; x < checkedListBox2.Items.Count; x++) if (CheckBox2 != x) checkedListBox2.SetItemChecked(x, false);
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Input = textBox1.Text;
            textBox2.Text = Binary = "";
            stop = false;
            BaseLang firstLang = new BaseLang(), secondLang = new BaseLang();
            switch (CheckBox1) 
            {
                case 0: firstLang = new BaseLang(Bin, 2); break;
                case 1: firstLang = new BaseLang(Oct, 8); break;
                case 2: firstLang = new BaseLang(Cro, 8); break;
                case 3: firstLang = new BaseLang(Cry, 8); break;
                case 4: DecToBin(); break;
                case 5: firstLang = new BaseLang(Hex, 16); break;
                case 6: firstLang = new BaseLang(Geo, 32); break;
                case 7: firstLang = new BaseLang(Tet, 64, false); break;
                case 8: firstLang = new BaseLang(Key, 64); break;
            }
            if (firstLang.IsNotNull())
            {
                Binary = firstLang.DecryptToBinary(Input);
                if (!String.IsNullOrEmpty(firstLang.ErrorMessage)) 
                {
                    textBox2.Text = firstLang.ErrorMessage;
                    stop = true;
                }
            } 
            if (!stop)
            {
                switch (CheckBox2)
                {
                    case 0: textBox2.Text = Binary; break;
                    case 1: secondLang = new BaseLang(Oct, 8); break;
                    case 2: secondLang = new BaseLang(Cro, 8); break;
                    case 3: secondLang = new BaseLang(Cry, 8); break;
                    case 4: BinToDec(); break;
                    case 5: secondLang = new BaseLang(Hex, 16); break;
                    case 6: secondLang = new BaseLang(Geo, 32); break;
                    case 7: secondLang = new BaseLang(Tet, 64); break;
                    case 8: secondLang = new BaseLang(Key, 64); break;
                }
            }
            if (secondLang.IsNotNull()) textBox2.Text = secondLang.EncryptFromBinary(Binary);
        }
        /* 
            (2) Binarny           - Bin
            (8) Octal             - Oct
            (8) Crypto Old        - Cro
            (8) Crypto            - Cry
            (10) Decimal          - Dec
            (16) Hexadecimal      - Hex
            (32) Geohash          - Geo
            (64) Tetrasexagesimal - Tet
            (64) KeyBoard         - Key
        */
        readonly string[] Bin = {"0", "1"};
        readonly string[] Oct = {"0", "1", "2", "3", "4", "5", "6", "7"};
        readonly string[] Cro = {"`", ",", ".", "|", "'", "\"", "!", "-"};
        readonly string[] Cry = {".", ":", ",", ";", "!", "|", "'", "`"};
        readonly string[] Hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
        readonly string[] Geo = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        readonly string[] Tet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m","n", "o", "p", "q", "r", "s","t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3","4", "5", "6", "7", "8", "9", "+", "/"};
        readonly string[] Key = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Z", "Q", "V", "X", "Y", ".", ",", "_", "!", "?", "%", "(", ")", "[", "]", "{", "}", "<", ">", "@", "#", "/", "\\", "*", "+", "-", "=", "^", ":", ";", "\"", "'", " "};
        void DecToBin() 
        {
            int maxNumber = 8, tempNumber = 0;
            int divideCount = Input.Length % maxNumber == 0 ? Input.Length / maxNumber : Convert.ToInt32(Math.Round(Input.Length / maxNumber * 1.0) + 1);
            long[] numbers = new long[divideCount];
            for (int i = 0; i < divideCount; i++)
            {
                if (i == divideCount - 1) numbers[i] = Convert.ToInt64(Input.Substring(tempNumber, Input.Length - maxNumber * (divideCount - 1)));
                else numbers[i] = Convert.ToInt64(Input.Substring(tempNumber, maxNumber));
                tempNumber += maxNumber;
            }
            while (numbers[divideCount - 1] < 1)
            {
                foreach (long item in numbers)
                {

                }
            }

            /*if (Inp.Length <= 10)
            {
                try
                {
                    long liczba = 0;
                    if (Inp == "0") Binary = "0";
                    else liczba = long.Parse(Inp);
                    while (liczba > 0)
                    {
                        if (liczba % 2 == 0) Binary = 0 + Binary;
                        else
                        {
                            liczba--;
                            Binary = 1 + Binary;
                        }
                        liczba /= 2;
                    }
                }
                catch
                {
                    textBox2.Text = "Tylko te znaki: \r\n0 1 2 3 4 5 6 7 8 9"; 
                    stop = true;
                }
            } 
            else
            {
                textBox2.Text = "Liczba może mieć maksymalnie 10 znaków, takie są ograniczenia w systemie dziesiętnym";
                stop = true;
            }*/
        }
        void BinToDec()
        {
            long wynik = 0;
            for (int i = 0; i < Binary.Length; i++)
            {
                if (Binary[i] == '0') wynik *= 2;
                else if (Binary[i] == '1') wynik = wynik * 2 + 1;
                else
                {
                    textBox2.Text += "Tylko znaki: \r\n0 1";
                    stop = true;
                }
            }
            textBox2.Text = wynik.ToString();
        }
    }
}