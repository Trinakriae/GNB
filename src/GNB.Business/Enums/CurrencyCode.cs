using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Business.Enums
{
    public class CurrencyCode
    {
        private CurrencyCode(string value) { Value = value; }

        public string Value { get; set; }

        public static CurrencyCode EUR { get { return new CurrencyCode("EUR"); } }
        public static CurrencyCode USD { get { return new CurrencyCode("USD"); } }
        public static CurrencyCode CAD { get { return new CurrencyCode("CAD"); } }
    }
}
