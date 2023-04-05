<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        int Zaznaczony1 = 0, Zaznaczony2 = 0, InpLeng = 0;
        string Binary, Inp = "";
        bool stop, upper;
        Control conBox1, conBox2;

        public Form1()
        {
            InitializeComponent();
            checkedListBox1.SetItemChecked(0, true);
            checkedListBox2.SetItemChecked(0, true);
            conBox1 = textBox1;
            conBox2 = textBox2;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            double x = (control.Size.Width - 156) / 2;
            int size = Convert.ToInt32(Math.Round(x));  
            conBox1.Size = new Size(size, control.Size.Height);
            conBox2.Size = new Size(size, control.Size.Height);
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony1 = checkedListBox1.SelectedIndex;
            int Selected = checkedListBox1.Items.Count;
            for (int x = 0; x < Selected; x++) if (Zaznaczony1 != x) checkedListBox1.SetItemChecked(x, false);
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony2 = checkedListBox2.SelectedIndex;
            int Selected = checkedListBox2.Items.Count;
            for (int x = 0; x < Selected; x++) if (Zaznaczony2 != x) checkedListBox2.SetItemChecked(x, false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Inp = textBox1.Text;
            textBox2.Text = Binary = "";
            stop = false;
            upper = true;
            switch (Zaznaczony1) 
            {
                case 0:
                    BinToDec();
                    break;
                case 1:
                    NaBinarny(Oct, B8, "0 1 2 3 4 5 6 7", 8);
                    break;
                case 2:
                    NaBinarny(Cry, B8, "` ,  . | ' \" ! -", 8);
                    break;
                case 3:
                    NaBinarny(CryNew, B8, ". :  , ; ! | ' `", 8);
                    break;
                case 4:
                    DecToBin();
                    break;
                case 5:
                    NaBinarny(Hex, B16, "0 1 2 3 4 5 6 7 8 9 A B C D E F", 16);
                    break;
                case 6:
                    NaBinarny(Geo, B32, "0 1 2 3 4 5 6 7 8 9 B C D E F G H J K M N P Q R S T U V W X Y Z", 32);
                    break;
                case 7:
                    upper = false;
                    NaBinarny(Tet, B64, "A B C D E F G H I J K L M N O P Q R S T U V W X Y Z a b c d e f g h i j k l m n o p q r s t u v w x y z 0 1 2 3 4 5 6 7 8 9 + /", 64);
                    break;
                case 8:
                    NaBinarny(Key, B64, "0 1 2 3 4 5 6 7 8 9 A B C D E F G H I J K L M N O P Q R S T U V W X Y Z . , _ ! ? % [ { ( < > ) } ] @ # * / \\ + - = ^ : ; ' \" oraz spcaja", 64);
                    break;
            }
            if (!stop)
            {
                switch (Zaznaczony2)
                {
                    case 0:
                        textBox2.Text = Binary;
                        break;
                    case 1:
                        ZBinarnego(Oct, B8, 8, 3);
                        break;
                    case 2:
                        ZBinarnego(Cry, B8, 8, 3);
                        break;
                    case 3:
                        ZBinarnego(CryNew, B8, 8, 3);
                        break;
                    case 4:
                        BinToDec();
                        break;
                    case 5:
                        ZBinarnego(Hex, B16, 16, 4);
                        break;
                    case 6:
                        ZBinarnego(Geo, B32, 32, 5);
                        break;
                    case 7:
                        ZBinarnego(Tet, B64, 64, 6);
                        break;
                    case 8:
                        ZBinarnego(Key, B64, 64, 6);
                        break;
                }
            }
        }
        /* 
            (2) Binarny           - Bin
            (8) Octal             - Oct
            (8) Crypto Old        - Cry
            (8) Crypto            - CryNew
            (10) Decimal          - Dec
            (16) Hexadecimal      - Hex
            (32) Geohash          - Geo
            (64) Tetrasexagesimal - Tet
            (64) KeyBoard         - Key
        */
        //Biblioteka znaków
        string[] B8 = {"000", "001", "010", "011", "100", "101", "110", "111"
        };
        string[] B16 = {"0000", "0001", "0010", "0011", "0100", "0101", "0110",
            "0111", "1000", "1001","1010", "1011", "1100", "1101", "1110", "1111"};
        string[] B32 = {"00000", "00001", "00010", "00011", "00100", "00101", "00110",
            "00111", "01000", "01001", "01010", "01011", "01100", "01101", "01110", "01111",
            "10000", "10001", "10010", "10011", "10100", "10101", "10110", "10111", "11000",
            "11001", "11010", "11011", "11100", "11101", "11110", "11111"};
        string[] B64 = {"000000", "000001", "000010", "000011", "000100", "000101", "000110",
            "000111", "001000", "001001","001010", "001011", "001100", "001101", "001110",
            "001111", "010000", "010001", "010010", "010011", "010100", "010101", "010110",
            "010111", "011000", "011001", "011010", "011011", "011100", "011101", "011110",
            "011111", "100000", "100001", "100010", "100011", "100100", "100101", "100110",
            "100111", "101000", "101001", "101010", "101011", "101100", "101101", "101110",
            "101111", "110000", "110001", "110010", "110011", "110100", "110101", "110110",
            "110111", "111000", "111001", "111010", "111011", "111100", "111101", "111110",
            "111111"};
        string[] Oct = {"0", "1", "2", "3", "4", "5", "6", "7"
        };
        string[] Cry = {"`", ",", ".", "|", "'", "\"", "!", "-"
        };
        string[] CryNew = {".", ":", ",", ";", "!", "|", "'", "`"
        };
        string[] Hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "A", "B", "C", "D", "E", "F"};
        string[] Geo = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q",
            "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        string[] Tet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "a", "b",
            "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m","n", "o", "p", "q",
            "r", "s","t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3","4", "5",
            "6", "7", "8", "9", "+", "/"};
        string[] Key = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","A", "B", "C",
            "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S",
            "T", "U", "W", "Z", "Q", "V", "X", "Y", ".", ",", "_", "!", "?", "%", "(",
            ")", "[", "]", "{", "}", "<", ">", "@", "#", "/", "\\", "*", "+", "-", "=",
            "^", ":", ";", "\"", "'", " "};
        //Podstawy
        void NaBinarny(string[] znaki, string[] bin, string error, int ileZnak)
        {
            InpLeng = Inp.Length;
            for (int i = 0; i < InpLeng; i++)
            {
                string znak = "";
                for (int x = 0; x < ileZnak; x++)
                {
                    if (upper == true) { if (Inp[i].ToString().ToUpper() == znaki[x]) znak = bin[x]; }
                    else { if (Inp[i].ToString() == znaki[x]) znak = bin[x]; }
                }
                if (znak == "")
                {
                    textBox2.Text = "Tylko te znaki: \r\n" + error;
                    stop = true;
                    break;
                }
                Binary += znak;
            }
        }
        void ZBinarnego(string[] znaki, string[] bin, int ileZnak, int zera)
        {
            if (Binary == "0") textBox2.Text = znaki[0];
            else
            {
                int BinLeng = Binary.Length;
                string RewBin = Binary, calosc = "";
                while (BinLeng > 0)
                {
                    string znak = "";
                    if (BinLeng < zera)
                    {
                        string FirstBit = "";
                        bool usun = true;
                        for (int i = 0; i < zera - BinLeng; i++) FirstBit = "0" + FirstBit;
                        for (int i = BinLeng; i >= 1; i--)
                        {
                            if (RewBin[BinLeng - i].ToString() == "1") usun = false;
                            znak += RewBin[BinLeng - i];
                        }
                        if (!usun)
                        {
                            znak = FirstBit + znak;
                            for (int x = 0; x < ileZnak; x++) if (znak == bin[x]) znak = znaki[x];
                            calosc = znak + calosc;
                        }
                    }
                    else
                    {
                        for (int i = zera; i >= 1; i--) znak += RewBin[BinLeng - i];
                        for (int x = 0; x < ileZnak; x++) if (znak == bin[x]) znak = znaki[x];
                        calosc = znak + calosc;
                    }
                    BinLeng -= zera;
                }
                textBox2.Text += calosc;
            }
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
        void DecToBin() 
        {
            int maxNumber = 8, tempNumber = 0;
            int divideCount = Inp.Length % maxNumber == 0 ? Inp.Length / maxNumber : Convert.ToInt32(Math.Round(Inp.Length / maxNumber * 1.0) + 1);
            long[] numbers = new long[divideCount];
            for (int i = 0; i < divideCount; i++)
            {
                if (i == divideCount - 1) numbers[i] = Convert.ToInt64(Inp.Substring(tempNumber, Inp.Length - maxNumber * (divideCount - 1)));
                else numbers[i] = Convert.ToInt64(Inp.Substring(tempNumber, maxNumber));
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
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crypto
{
    public partial class Form1 : Form
    {
        int Zaznaczony1 = 0, Zaznaczony2 = 0;
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
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony1 = checkedListBox1.SelectedIndex;
            int Selected = checkedListBox1.Items.Count;
            for (int x = 0; x < Selected; x++) if (Zaznaczony1 != x) checkedListBox1.SetItemChecked(x, false);
        }
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zaznaczony2 = checkedListBox2.SelectedIndex;
            int Selected = checkedListBox2.Items.Count;
            for (int x = 0; x < Selected; x++) if (Zaznaczony2 != x) checkedListBox2.SetItemChecked(x, false);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Input = textBox1.Text;
            textBox2.Text = Binary = "";
            stop = false;
            BaseLang firstLang = new BaseLang(), secondLang = new BaseLang();
            switch (Zaznaczony1) 
            {
                case 0:
                    firstLang = new BaseLang(B2, B2, 2);
                    break;
                case 1:
                    firstLang = new BaseLang(Oct, B8, 8);
                    break;
                case 2:
                    firstLang = new BaseLang(Cry, B8, 8);
                    break;
                case 3:
                    firstLang = new BaseLang(CryNew, B8, 8);
                    break;
                case 4:
                    DecToBin();
                    break;
                case 5:
                    firstLang = new BaseLang(Hex, B16, 16);
                    break;
                case 6:
                    firstLang = new BaseLang(Geo, B32, 32);
                    break;
                case 7:
                    firstLang = new BaseLang(Tet, B64, 64);
                    firstLang.LetterHeightMatter = false;
                    break;
                case 8:
                    firstLang = new BaseLang(Key, B64, 64);
                    break;
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
                switch (Zaznaczony2)
                {
                    case 0:
                        textBox2.Text = Binary;
                        break;
                    case 1:
                        secondLang = new BaseLang(Oct, B8, 8);
                        break;
                    case 2:
                        secondLang = new BaseLang(Cry, B8, 8);
                        break;
                    case 3:
                        secondLang = new BaseLang(CryNew, B8, 8);
                        break;
                    case 4:
                        BinToDec();
                        break;
                    case 5:
                        secondLang = new BaseLang(Hex, B16, 16);
                        break;
                    case 6:
                        secondLang = new BaseLang(Geo, B32, 32);
                        break;
                    case 7:
                        secondLang = new BaseLang(Tet, B64, 64);
                        break;
                    case 8:
                        secondLang = new BaseLang(Key, B64, 64);
                        break;
                }
            }
            if (secondLang.IsNotNull()) textBox2.Text = secondLang.EncryptFromBinary(Binary);
        }
        /* 
            (2) Binarny           - Bin
            (8) Octal             - Oct
            (8) Crypto Old        - Cry
            (8) Crypto            - CryNew
            (10) Decimal          - Dec
            (16) Hexadecimal      - Hex
            (32) Geohash          - Geo
            (64) Tetrasexagesimal - Tet
            (64) KeyBoard         - Key
        */
        string[] B2 = {"0", "1"
        };
        string[] B8 = {"000", "001", "010", "011", "100", "101", "110", "111"
        };
        string[] B16 = {"0000", "0001", "0010", "0011", "0100", "0101", "0110",
            "0111", "1000", "1001","1010", "1011", "1100", "1101", "1110", "1111"};
        string[] B32 = {"00000", "00001", "00010", "00011", "00100", "00101", "00110",
            "00111", "01000", "01001", "01010", "01011", "01100", "01101", "01110", "01111",
            "10000", "10001", "10010", "10011", "10100", "10101", "10110", "10111", "11000",
            "11001", "11010", "11011", "11100", "11101", "11110", "11111"};
        string[] B64 = {"000000", "000001", "000010", "000011", "000100", "000101", "000110",
            "000111", "001000", "001001","001010", "001011", "001100", "001101", "001110",
            "001111", "010000", "010001", "010010", "010011", "010100", "010101", "010110",
            "010111", "011000", "011001", "011010", "011011", "011100", "011101", "011110",
            "011111", "100000", "100001", "100010", "100011", "100100", "100101", "100110",
            "100111", "101000", "101001", "101010", "101011", "101100", "101101", "101110",
            "101111", "110000", "110001", "110010", "110011", "110100", "110101", "110110",
            "110111", "111000", "111001", "111010", "111011", "111100", "111101", "111110",
            "111111"};
        string[] Oct = {"0", "1", "2", "3", "4", "5", "6", "7"
        };
        string[] Cry = {"`", ",", ".", "|", "'", "\"", "!", "-"
        };
        string[] CryNew = {".", ":", ",", ";", "!", "|", "'", "`"
        };
        string[] Hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "A", "B", "C", "D", "E", "F"};
        string[] Geo = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9",
            "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q",
            "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        string[] Tet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
            "N", "O", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "a", "b",
            "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m","n", "o", "p", "q",
            "r", "s","t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3","4", "5",
            "6", "7", "8", "9", "+", "/"};
        string[] Key = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","A", "B", "C",
            "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S",
            "T", "U", "W", "Z", "Q", "V", "X", "Y", ".", ",", "_", "!", "?", "%", "(",
            ")", "[", "]", "{", "}", "<", ">", "@", "#", "/", "\\", "*", "+", "-", "=",
            "^", ":", ";", "\"", "'", " "};
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
>>>>>>> 700e481 (Add class, optimize code, make it more read able)
}