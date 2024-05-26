using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCA_Kurs
{
    public class Token
    {
        public TokenType Type;
        public string Value;
        public Token(TokenType type)
        {
            Type = type;
        }
        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
        public override string ToString()
        {
            return string.Format("{0}, {1}", Type, Value);
        }
    }
}
