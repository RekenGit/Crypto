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
            BaseLang firstLang = new BaseLang(), secondLang = new BaseLang();
            switch (CheckBox1) 
            {
                case 0: firstLang = new BaseLang(Bin, 2); break;
                case 1: firstLang = new BaseLang(Qua, 4); break;
                case 2: firstLang = new BaseLang(Oct, 8); break;
                case 3: firstLang = new BaseLang(Cro, 8); break;
                case 4: firstLang = new BaseLang(Cry, 8); break;
                case 5: firstLang = new BaseLang(null, 10); break;
                case 6: firstLang = new BaseLang(Hex, 16); break;
                case 7: firstLang = new BaseLang(Duo, 32); break;
                case 8: firstLang = new BaseLang(Geo, 32); break;
                case 9: firstLang = new BaseLang(Tet, 64, false); break;
                case 10: firstLang = new BaseLang(Key, 64); break;
            }
            Binary = firstLang.DecryptToBinary(Input);
            if (!String.IsNullOrEmpty(firstLang.ErrorMessage)) 
            {
                textBox2.Text = firstLang.ErrorMessage;
                return;
            }
            switch (CheckBox2)
            {
                case 0: textBox2.Text = Binary; break;
                case 1: secondLang = new BaseLang(Qua, 4); break;
                case 2: secondLang = new BaseLang(Oct, 8); break;
                case 3: secondLang = new BaseLang(Cro, 8); break;
                case 4: secondLang = new BaseLang(Cry, 8); break;
                case 5: secondLang = new BaseLang(null, 10); break;
                case 6: secondLang = new BaseLang(Hex, 16); break;
                case 7: secondLang = new BaseLang(Duo, 32); break;
                case 8: secondLang = new BaseLang(Geo, 32); break;
                case 9: secondLang = new BaseLang(Tet, 64); break;
                case 10: secondLang = new BaseLang(Key, 64); break;
            }
            textBox2.Text = secondLang.EncryptFromBinary(Binary);
        }
        /* 
            (2) Binary            - Bin
            (4) Quaternary        - Qua
            (8) Octal             - Oct
            (8) Crypto Old        - Cro
            (8) Crypto            - Cry
            (10) Decimal          - Dec
            (16) Hexadecimal      - Hex
            (32) Duotrigesimal    - Duo
            (32) Geohash          - Geo
            (64) Tetrasexagesimal - Tet
            (64) KeyBoard         - Key
        */
        readonly static string[] Bin = {"0", "1"};
        readonly static string[] Qua = {"0", "1", "2", "3"};
        readonly static string[] Oct = {"0", "1", "2", "3", "4", "5", "6", "7"};
        readonly static string[] Cro = {"`", ",", ".", "|", "'", "\"", "!", "-"};
        readonly static string[] Cry = {".", ":", ",", ";", "!", "|", "'", "`"};
        readonly static string[] Hex = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F"};
        readonly static string[] Duo = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "2", "3", "4", "5", "6", "7"};
        readonly static string[] Geo = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "B", "C", "D", "E", "F", "G", "H", "J", "K", "M", "N", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
        readonly static string[] Tet = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S","T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m","n", "o", "p", "q", "r", "s","t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3","4", "5", "6", "7", "8", "9", "+", "/"};
        readonly static string[] Key = {"0", "1", "2", "3", "4", "5", "6", "7", "8", "9","A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "W", "Z", "Q", "V", "X", "Y", ".", ",", "_", "!", "?", "%", "(", ")", "[", "]", "{", "}", "<", ">", "@", "#", "/", "\\", "*", "+", "-", "=", "^", ":", ";", "\"", "'", " "};
    }
}