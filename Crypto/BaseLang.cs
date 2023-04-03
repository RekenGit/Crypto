using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crypto
{
    internal class BaseLang
    {
        public string[] symbols;
        public string[] bits;
        public int baseSystem;
        public int bitCount;
        public string errorMessage;
        public bool LetterHeightMatter;
        public BaseLang(string[] _symbols, string[] _bits, int _baseSystem, int _bitCount, string _errorMessage, bool letterHeightMatter)
        {
            symbols = _symbols;
            bits = _bits;
            baseSystem = _baseSystem;
            bitCount = _bitCount;
            errorMessage = _errorMessage;
            LetterHeightMatter = letterHeightMatter;
        }
        private string ErrorMes()
        {
            return "Tylko te znaki: \r\n" + String.Join(" ", symbols).Replace("  ", " oraz spacja");
        }
        //TODO (Tłumaczenie z binarnego etc tu przenieść)
    }
}
