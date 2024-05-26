using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCA_Kurs
{
    internal class AlgDeixtra
    {
        Stack<Token> StackPars = new Stack<Token>();
        Stack<string> stackMatrix = new Stack<string>();
        Token token;
        string op1, op2, strMatrix, result, result2, result3 = "";
        int index = 1;

        int GetPrecedence(Token token)
        {
            switch (token.Type)
            {
                case TokenType.LEFTBRACK:
                    return 0;
                case TokenType.RIGHTBRACK:
                    return 1;
                case TokenType.OR:
                    return 2;
                case TokenType.AND:
                    return 3;
                case TokenType.NOT:
                    return 4;
                case TokenType.LESS:
                    return 5;
                case TokenType.MORE:
                    return 5;
                case TokenType.PLUS:
                    return 6;
                case TokenType.MINUS:
                    return 6;
                case TokenType.MULTI:
                    return 7;
                case TokenType.DIV:
                    return 7;
                default:
                    return -1;
            }
        }

        bool IsPrioritet(Token token, Stack<Token> stack)
        {
            if (stack.Count == 0)
                return true;
            else if (GetPrecedence(token) == 0 || GetPrecedence(token) > GetPrecedence(stack.Peek()))
                return true;
            else
                return false;

        }

        bool CheckOperand(Token token)
        {
            if (token.Type == TokenType.LITERAL || token.Type == TokenType.ID)
                return true;
            else
                return false;
        }


        public string Parsing(List<Token> tokens)
        {
            result = "";
            for (int i = 0; i < tokens.Count;)
            {
                token = tokens[i];
                if (!CheckOperand(token))
                {
                    if (IsPrioritet(token, StackPars))
                        StackPars.Push(token);
                    else
                    {
                        if (token.Type == TokenType.RIGHTBRACK)
                        {
                            while (StackPars.Peek().Type != TokenType.LEFTBRACK)
                            {
                                if (StackPars.Peek().Value != null)
                                    result += $"{StackPars.Pop().Value} ";
                                else
                                    result += $"{StackPars.Pop().Type} ";
                            }
                            StackPars.Pop();
                        }
                        else
                        {
                            while (!IsPrioritet(token, StackPars))
                            {
                                if (StackPars.Peek().Type == TokenType.LEFTBRACK || StackPars.Peek().Type == TokenType.RIGHTBRACK)
                                    throw new Exception($"Ошибка: в выражении несогласованны скобки");
                                if (StackPars.Peek().Value != null)
                                    result += $"{StackPars.Pop().Value} ";
                                else
                                    result += $"{StackPars.Pop().Type} ";
                            }
                            StackPars.Push(token);
                        }
                    }
                }
                else
                    result += $"{token.Value} ";
                i++;
            }
            while (StackPars.Count > 0)
            {
                if (StackPars.Peek().Type == TokenType.LEFTBRACK || StackPars.Peek().Type == TokenType.RIGHTBRACK)
                    throw new Exception($"Ошибка: в выражении несогласованны скобки");
                if (StackPars.Peek().Value != null)
                    result += $"{StackPars.Pop().Value} ";
                else
                    result += $"{StackPars.Pop().Type} ";
            }
            return result;
        }

        public string Matrix(string polish)
        {
            strMatrix = "";
            index = 1;
            polish = polish.Remove(polish.Length - 1);
            string[] tokens = polish.Split(' ','\r');
            for (int i = 0; i < tokens.Length; i++)
            {

                if (CheckOperMatrix(tokens[i]))
                {
                    if (stackMatrix.Count >= 2)
                    {
                        op2 = stackMatrix.Pop();
                        op1 = stackMatrix.Pop();
                    }
                    strMatrix += $"M{index}):{tokens[i]} {op1} {op2} " + Environment.NewLine;
                    stackMatrix.Push($"M{index}");
                    index++;
                }
                else
                    stackMatrix.Push(tokens[i]);
            }

            return strMatrix;
        }

        bool CheckOperMatrix(string token)
        {
            return token == ">" || token == "<" || token == "AND" || token == "+" || token == "-" || token == "*" || token == "/";
        }
    }
}

