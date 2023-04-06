using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    public class BitList
    {
        public static readonly string[] Bin = {"0", "1"};
        public static readonly string[] Qua = {"00", "01", "10", "11"};
        public static readonly string[] Oct = {"000", "001", "010", "011", "100", "101", "110", "111"};
        public static readonly string[] Hex = {"0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111"};
        public static readonly string[] Duo = {"00000", "00001", "00010", "00011", "00100", "00101", "00110", "00111", "01000", "01001", "01010", "01011", "01100", "01101", "01110", "01111", "10000", "10001", "10010", "10011", "10100", "10101", "10110", "10111", "11000", "11001", "11010", "11011", "11100", "11101", "11110", "11111"};
        public static readonly string[] Tet = {"000000", "000001", "000010", "000011", "000100", "000101", "000110", "000111", "001000", "001001","001010", "001011", "001100", "001101", "001110","001111", "010000", "010001", "010010", "010011", "010100", "010101", "010110", "010111", "011000", "011001", "011010", "011011", "011100", "011101", "011110", "011111", "100000", "100001", "100010", "100011", "100100", "100101", "100110", "100111", "101000", "101001", "101010", "101011", "101100", "101101", "101110", "101111", "110000", "110001", "110010", "110011", "110100", "110101", "110110", "110111", "111000", "111001", "111010", "111011", "111100", "111101", "111110", "111111"};
    }

    internal class BaseLang
    {
        string[] symbolList, bitList;
        int baseNumber;
        bool letterHeightMatter;
        string errorMessage;
        public string ErrorMessage { get { return errorMessage; } }
        public BaseLang() { }
        public BaseLang(string[] _symbolList, int _baseNumber, bool _letterHeightMatter = true)
        {
            symbolList = _symbolList;
            baseNumber = _baseNumber;
            letterHeightMatter = _letterHeightMatter;
            switch (_baseNumber)
            {
                case 2: bitList = BitList.Bin; break;
                case 4: bitList = BitList.Qua; break;
                case 8: bitList = BitList.Oct; break;
                case 16: bitList = BitList.Hex; break;
                case 32: bitList = BitList.Duo; break;
                case 64: bitList = BitList.Tet; break;
            }
            errorMessage = null;
        }
        private void ErrorMes()
        {
            errorMessage = "Tylko te znaki: \r\n" + String.Join(" ", symbolList).Replace("  ", " oraz spacja");
        }
        public string DecryptToBinary(string input)
        {
            string binary = "";
            if (baseNumber == 10)
            {
                try
                {
                    binary = Convert.ToString(Convert.ToInt64(input), 2);
                }
                catch
                {
                    errorMessage = "The decimal number is to long!";
                }
            } 
            else
            {
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
            }
            return binary;
        }
        public string EncryptFromBinary(string input)
        {
            string output = "";
            if (baseNumber == 10)
            {
                try
                {
                    output = Convert.ToInt64(input, 2).ToString();
                }
                catch
                {
                    errorMessage = "The decimal number is to long!";
                }
            }
            else
            {
                int zera = Convert.ToInt32(Math.Log(baseNumber + 0f, 2f));
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
            }
            return output;
        }
    }
}
