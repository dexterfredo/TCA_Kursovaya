using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCA_Kurs
{
    public class LowerAnalyzer
    {

        public Token current;
        List<Token> tokens;
        Form1 form1 = new Form1();
        int index = 1;

        public LowerAnalyzer(List<Token> allTokens)
        {
            tokens = allTokens;
            current = tokens[0];
        }

        public void GetSpisok()
        {
            tokens = form1.GetSpisok();
        }

        private void NextElem()
        {
            if (index < tokens.Count)
            {
                current = tokens[index++];
            }
            else
                return;
        }

        public void Program()
        {
            Declaration();
            Body();
        }
        #region объявление
        public void Declaration()
        {
            Description();
            FirstRule();
        }
        public void Description()
        {
            if (current.Type != TokenType.DIM)
            { throw new Exception($"Ожидался DIM, а встретился {current.Type}"); }
            NextElem();
            ListPerem();
            Type();
            if (current.Type != TokenType.ENDLINE)
            { throw new Exception($"Ожидался перенос строки, а встретился {current.Type}"); }
            NextElem();
        }
        public void FirstRule()
        {
            switch (current.Type)
            {
                case TokenType.IF:
                    break;
                case TokenType.ID:
                    break;
                case TokenType.DIM:
                    Declaration();
                    break;
                default:
                    throw new Exception($"Ожидался IF, ID или DIM, а встретился {current.Type}");
            }
        }
        public void ListPerem()
        {
            if (current.Type != TokenType.ID)
            { throw new Exception($"Ожидалось число, а встретился {current.Type}"); } //обработка ошибки
            NextElem();
            SecondRule();
        }
        public void SecondRule()
        {
            switch (current.Type)
            {
                case TokenType.AS:
                    NextElem();
                    break;
                case TokenType.COMM:
                    NextElem();
                    ListPerem();
                    break;
                default:
                    throw new Exception($"Ожидался AS или запятая, а встретился {current.Type}");
            }

        }
        public void Type()
        {


            if (current.Type != TokenType.INTEGER && current.Type != TokenType.STRING
               && current.Type != TokenType.BOOLEAN && current.Type != TokenType.LONG)
            { throw new Exception($"Ожидался integer, string, boolean, long, а встретился {current.Type}"); }
            NextElem();
        }


        #endregion
        #region Тело
        public void Body()
        {
            Operation();
            ThirdRule();
        }

        public void ThirdRule()
        {
            switch (current.Type)
            {
                case TokenType.ENDLINE:
                    NextElem();
                    break;
                case TokenType.ELSE:
                    break;
                case TokenType.END:
                    break;
                case TokenType.IF:
                    Body();
                    break;
                case TokenType.ID:
                    Body();
                    break;
                default:
                    throw new Exception($"Ожидался перенос, else, end, if или id, а встретился {current.Type}");
            }
        }
        public void Operation()
        {
            switch (current.Type)
            {
                case TokenType.IF:
                    IF();
                    break;
                case TokenType.ID:
                    EQUAL();
                    if (current.Type == TokenType.ENDLINE)
                        NextElem();
                    break;
                default:
                    throw new Exception($"Ожидался if или id, а встретился {current.Type}");
            }
        }
        public void IF()
        {
            if (current.Type != TokenType.IF)
            { throw new Exception($"Ожидался if, а встретился {current.Type}"); }
            NextElem();
            EXPR();
            if (current.Type != TokenType.THEN)
            { throw new Exception($"Ожидался then, а встретился {current.Type}"); }
            NextElem();
            if (current.Type != TokenType.ENDLINE)
            { throw new Exception($"Ожидался перенос строки, а встретился {current.Type}"); }
            NextElem();
            Body();
            ELSE();
            if (current.Type != TokenType.END)
            { throw new Exception($"Ожидался end, а встретился {current.Type}"); }
            NextElem();
             if (current.Type != TokenType.IF)
            { throw new Exception($"Ожидался if, а встретился {current.Type}"); }
            NextElem();
            if (current.Type != TokenType.ENDLINE)
            { throw new Exception($"Ожидался перенос строки, а встретился {current.Type}"); }
            NextElem();

                //throw new Exception($"Количество if и end if не совпадает");
            
        }
        public void ELSE()
        {
            switch (current.Type)
            {
                case TokenType.ELSE:
                    NextElem();
                    if (current.Type != TokenType.ENDLINE)
                    { throw new Exception($"Ожидался перенос строки, а встретился {current.Type}"); }
                    NextElem();
                    Body();
                    break;
                case TokenType.END:
                    break;
                default:
                    throw new Exception($"Ожидался else или end, а встретился {current.Type}");
            }
        }

        public List<Token> record;
        public string polish, polish1;
        public string matrix, matrix1;
        public int indEXPR = 0;
        AlgDeixtra D = new AlgDeixtra();
        public void EXPR()
        {
            if (current.Type != TokenType.ENDLINE)
            {
                record = new List<Token>();
                while (current.Type != TokenType.THEN)
                {
                    record.Add(current);
                    NextElem();
                    indEXPR++;
                    if (current.Type == TokenType.ENDLINE)
                        throw new Exception($"Ожидалось <EXPR>, ключевое слово IF или THEN, а встретился {current.Type}");
                }

                if (polish == null && matrix == null)
                {
                    polish += $"{D.Parsing(record)}\r\n";
                    matrix += $"{D.Matrix(polish)}\r\n";
                }
                else
                {
                    polish1 += $"{D.Parsing(record)}\r\n";
                    matrix1 += $"{D.Matrix(polish1)}\r\n";
                    polish += polish1;
                    matrix += matrix1;
                    polish1 = ""; matrix1 = "";
                }
            }
        }
        public void EQUAL()//присв
        {
            if (current.Type != TokenType.ID)
            { throw new Exception($"Ожидалось число, а встретился {current.Type}"); }
            NextElem();
            if (current.Type != TokenType.EQUAL)
            { throw new Exception($"Ожидался =, а встретился {current.Type}"); }
            NextElem();
            Operand();
            FourthRule();
        }
        public void FourthRule()
        {
            switch (current.Type)
            {
                case TokenType.ENDLINE:
                    NextElem();
                    break;
                case TokenType.PLUS:
                    Sign();
                    Operand();
                    break;
                case TokenType.MINUS:
                    Sign();
                    Operand();
                    break;
                case TokenType.DIV:
                    Sign();
                    Operand();
                    break;
                case TokenType.MULTI:
                    Sign();
                    Operand();
                    break;
                default:
                    throw new Exception($"Ожидался '+', '-', '/', '*' или перенос, а встретился {current.Type}");
            }
        }
        public void Sign()
        {
            if (current.Type != TokenType.PLUS && current.Type != TokenType.MINUS
               && current.Type != TokenType.DIV && current.Type != TokenType.MULTI)
            { throw new Exception($"Ожидался '+', '-', '/', '*', а встретился {current.Type}"); }
            NextElem();
        }
        public void Operand()
        {
            if (current.Type != TokenType.LITERAL && current.Type != TokenType.ID)
            { throw new Exception($"Ожидался идентификатор или число, а встретился {current.Type}"); }
            NextElem();
        }
        #endregion



       
    }
}
