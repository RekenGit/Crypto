using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    internal class BaseLang
    {
        string[] symbolList;
        string[] bitList;
        int baseNumber;
        bool letterHeightMatter;
        string errorMessage = null;
        public string ErrorMessage { get { return errorMessage; } }
        public bool LetterHeightMatter { set { letterHeightMatter = value; } }
        public BaseLang(string[] _symbolList, string[] _bitList, int _baseNumber)
        {
            errorMessage = null;
            symbolList = _symbolList;
            bitList = _bitList;
            baseNumber = _baseNumber;
            letterHeightMatter = true;
        }
        public BaseLang() { }
        private void ErrorMes()
        {
            errorMessage = "Tylko te znaki: \r\n" + String.Join(" ", symbolList).Replace("  ", " oraz spacja");
        }
        public bool IsNotNull()
        {
            return symbolList == null ? false : true;
        }
        public string DecryptToBinary(string input)
        {
            string binary="";
            for (int i = 0; i < input.Length; i++)
            {
                string znak = "";
                for (int x = 0; x < baseNumber; x++)
                {
                    if (letterHeightMatter) { if (input[i].ToString().ToUpper() == symbolList[x]) znak = bitList[x]; }
                    else { if (input[i].ToString() == symbolList[x]) znak = bitList[x]; }
                }
                if (znak == "")
                {
                    ErrorMes();
                    return null;
                }
                binary += znak;
            }
            return binary;
        }
        public string EncryptFromBinary(string input)
        {
            string output = "";
            int zera = Convert.ToInt32(Math.Log(baseNumber+0f, 2f));
            if (input == "0") output = symbolList[0];
            else
            {
                int BinLeng = input.Length;
                string RewBin = input;
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
                            for (int x = 0; x < baseNumber; x++) if (znak == bitList[x]) znak = symbolList[x];
                            output = znak + output;
                        }
                    }
                    else
                    {
                        for (int i = zera; i >= 1; i--) znak += RewBin[BinLeng - i];
                        for (int x = 0; x < baseNumber; x++) if (znak == bitList[x]) znak = symbolList[x];
                        output = znak + output;
                    }
                    BinLeng -= zera;
                }
            }
            return output;
        }
    }
}
