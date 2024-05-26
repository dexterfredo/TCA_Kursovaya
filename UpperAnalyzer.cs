using TCA_Kurs;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace part_1
{
    internal class UpperAnalyze
    {
        private Stack<Token> TokenStack = new Stack<Token>();
        private Stack<int> StateStack = new Stack<int>();
        public Token currentLexeme;
        // Form1 form1 = new Form1();
        List<Token> tokens;
        int index = 1;
        int state;

        public UpperAnalyze(List<Token> current)
        {
            tokens = current;
            currentLexeme = tokens[0];
        }

        string IsSpecialWord(Token token)
        {
            string type = "";

            if (token.Type == TokenType.FOR || token.Type == TokenType.NEXT || token.Type == TokenType.AS || token.Type == TokenType.FOR || token.Type == TokenType.DIM || token.Type == TokenType.IF || token.Type == TokenType.ENDLINE
                || token.Type == TokenType.INTEGER || token.Type == TokenType.BOOLEAN || token.Type == TokenType.STRING || token.Type == TokenType.LONG || token.Type == TokenType.AND || token.Type == TokenType.THEN || token.Type == TokenType.END
                || token.Type == TokenType.ELSE || token.Type == TokenType.OR || token.Type == TokenType.NOT)
            {
                type = token.Type.ToString();
            }
            else
                type = token.Value;
            return type;
        }

        bool isEnd = false;

        public void Start()
        {
            StateStack.Push(state);
            while (isEnd != true)
            {
                switch (state)
                {
                    case 0:
                        State0();
                        break;
                    case 1:
                        State1();
                        break;
                    case 2:
                        State2();
                        break;
                    case 3:
                        State3();
                        break;
                    case 4:
                        State4();
                        break;
                    case 5:
                        State5();
                        break;
                    case 6:
                        State6();
                        break;
                    case 7:
                        State7();
                        break;
                    case 8:
                        State8();
                        break;
                    case 9:
                        State9();
                        break;
                    case 10:
                        State10();
                        break;
                    case 11:
                        State11();
                        break;
                    case 12:
                        State12();
                        break;
                    case 13:
                        State13();
                        break;
                    case 14:
                        State14();
                        break;
                    case 15:
                        State15();
                        break;
                    case 16:
                        State16();
                        break;
                    case 17:
                        State17();
                        break;
                    case 18:
                        State18();
                        break;
                    case 19:
                        State19();
                        break;
                    case 20:
                        State20();
                        break;
                    case 21:
                        State21();
                        break;
                    case 22:
                        State22();
                        break;
                    case 23:
                        State23();
                        break;
                    case 24:
                        State24();
                        break;
                    case 25:
                        State25();
                        break;
                    case 26:
                        State26();
                        break;
                    case 27:
                        State27();
                        break;
                    case 28:
                        State28();
                        break;
                    case 29:
                        State29();
                        break;
                    case 30:
                        State30();
                        break;
                    case 31:
                        State31();
                        break;
                    case 32:
                        State32();
                        break;
                    case 33:
                        State33();
                        break;
                    case 34:
                        State34();
                        break;
                    case 35:
                        State35();
                        break;
                    case 36:
                        State36();
                        break;
                    case 37:
                        State37();
                        break;
                    case 38:
                        State38();
                        break;
                    case 39:
                        State39();
                        break;
                    case 40:
                        State40();
                        break;
                    case 41:
                        State41();
                        break;
                    case 42:
                        State42();
                        break;
                    case 43:
                        State43();
                        break;
                    case 44:
                        State44();
                        break;
                    default:
                        break;
                }
            }
        }

        void Shift()
        {
            TokenStack.Push(currentLexeme);
            if (index < tokens.Count)
                currentLexeme = tokens[index++];
        }

        void GoToState(int state)
        {
            StateStack.Push(state);
            this.state = state;
        }

        void Reduce(int num, string neterm)
        {

            for (int i = 0; i < num; i++)
            {
                TokenStack.Pop();
                StateStack.Pop();
            }

            state = StateStack.Peek();
            TokenStack.Push(new Token(TokenType.NETERM, neterm));

        }

        void State0()
        {
            if (TokenStack.Count == 0)
                Shift();
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<программа>":
                                {
                                    isEnd = true;
                                }
                                break;
                            case "<объявление>":
                                if (TokenStack.Count == 1)
                                    GoToState(1);
                                else
                                    GoToState(2);
                                break;
                            case "<описание>":
                                GoToState(2);
                                break;
                        }
                    }
                    break;
                case TokenType.DIM:
                    GoToState(3);
                    break;
                default:
                    throw new Exception($"Ожидалось <программа>, <объявление>,<описание> или DIM, а встретилось {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State1()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<объявление>":
                                Shift();
                                break;
                            case "<тело>":
                                GoToState(4);
                                break;
                            case "<опер>":
                                GoToState(5);
                                break;
                            case "<усл>":
                                GoToState(6);
                                break;
                            case "<присв>":
                                GoToState(7);
                                break;
                        }
                    }
                    break;
                case TokenType.IF:
                    GoToState(8);
                    break;
                case TokenType.ID:
                    GoToState(9);
                    break;
                default:
                    throw new Exception($"Ожидалось <объявление>,<тело>,<опер>, или DIM,<усл>,<присв>,ключевое слово IF или идентификатор а встретилось {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State2()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<описание>":
                                {
                                    if (currentLexeme.Type == TokenType.IF || currentLexeme.Type == TokenType.ID)
                                        Reduce(1, "<объявление>");
                                   else if (currentLexeme.Type == TokenType.DIM)
                                    {
                                        Shift();
                                    }
                                    else throw new Exception($"Ожидалось <объявление>,<описание>, идентификатор или DIM, а встретилось {IsSpecialWord(currentLexeme)}");
                                }
                                break;
                            case "<объявление>":
                                GoToState(10);
                                break;
                        }
                        break;
                    }
                case TokenType.DIM:
                    GoToState(3);
                    break;
                default:
                    throw new Exception($"Ожидалось <объявление>,<описание>,идентификатор или DIM, а встретилось {IsSpecialWord(currentLexeme)}");
            }
        }

        void State3()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.DIM:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<спис перем>":
                                GoToState(11);
                                break;
                        }
                    }
                    break;
                case TokenType.ID:
                    GoToState(12);
                    break;
            default:
                    throw new Exception($"Ожидалось <спис перем>,ключевое слово DIM или идентификатор, а встретилось {IsSpecialWord(TokenStack.Peek())}");
            }
        }
        void State4()
        {
            Reduce(2, "<программа>");
        }

        void State5()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<опер>":
                                {
                                    if (currentLexeme.Type == TokenType.DIM || currentLexeme.Type == TokenType.END )
                                    {
                                        Reduce(1, "<тело>");
                                    }
                                    else if (currentLexeme.Type == TokenType.ELSE || currentLexeme.Type == TokenType.ENDLINE)
                                    {
                                        if (TokenStack.Count == 7 || TokenStack.Count == 2)
                                            Reduce(1, "<тело>");
                                        else
                                            GoToState(13);
                                    }
                                    else if (currentLexeme.Type == TokenType.IF || currentLexeme.Type == TokenType.ID)
                                        Shift();
                                    else
                                        throw new Exception($"Ожидалось <опер>,<тело>,<присв>,<усл>, ключевое слово IF или идентификатор, а встретилось {IsSpecialWord(currentLexeme)}");
                                }
                                break;
                            case "<тело>":
                                GoToState(13);
                                break;
                            case "<присв>":
                                GoToState(7);
                                break;
                            case "<усл>":
                                GoToState(6);
                                break;
                           
                        }
                        break;
                        
                        }
                case TokenType.IF:
                    GoToState(8);
                    break;
                case TokenType.ID:
                    GoToState(9);
                    break;
                default:
                    throw new Exception($"Ожидалось <опер>,<тело>,<присв>,<усл>, ключевое слово IF или идентификатор, а встретилось {IsSpecialWord(currentLexeme)}");
            }
        }

        void State6()
        {
            Reduce(1, "<опер>");
        }

        void State7()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<присв>":
                                
                                Shift();
                               // if (currentLexeme.Type != TokenType.IF)
                                    //throw new Exception($"Ожидалось ключевое слово IF, а встретилось {IsSpecialWord(currentLexeme)}");
                                break;
                        }
                    }
                    break;
                case TokenType.ENDLINE:
                    GoToState(14);
                    break;
                default:
                    throw new Exception($"Ожидалось <присв> или конец строки, а встретилось {IsSpecialWord(TokenStack.Peek())}");
            }
        }
        void State8()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.IF:
                    //Shift();
                    GoToState(15);
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<EXPR>":
                                GoToState(15);
                                break;
                        }
                    }
                    break;
                default:
                    throw new Exception($"Ожидалось <EXPR> или ключевое слово IF, а встретилось {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State9()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.ID:
                    Shift();
                    break;
                case TokenType.EQUAL:
                    GoToState(16);
                    break;
                default:
                    throw new Exception($"Ожидался знак = или идентификатор, а встретился {IsSpecialWord(currentLexeme)}");
            }
        }

        void State10()
        {
            Reduce(2, "<объявление>");
        }
        
        void State11()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<спис перем>":
                                Shift();
                                break;
                        }
                    }
                    break;
                case TokenType.AS:
                   GoToState(17);
                    break;
                default:
                    throw new Exception($"Ожидалось <спис перем> или ключевое слово AS, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }
        void State12()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.ID:
                    {
                        if (currentLexeme.Type == TokenType.AS)
                        {
                            Reduce(1, "<спис перем>");
                        }
                       else if (currentLexeme.Type == TokenType.COMM)
                            Shift();
                        else throw new Exception($"Ожидался идентификатор или запятая,а встретился {IsSpecialWord(currentLexeme)}");
                    }
                    break;
                case TokenType.COMM:
                    GoToState(18);
                    break;
                default:
                    throw new Exception($"Ожидался идентификатор или запятая,а встретился {IsSpecialWord(currentLexeme)}");
            }
        }
    
        void State13()
        {
            Reduce(2, "<тело>");
        }

        void State14()
        {
            Reduce(2, "<опер>");
        }

        public List<Token> record;
        public string polish, polish1;
        public string matrix, matrix1;
        public int indEXPR = 0;
        AlgDeixtra D = new AlgDeixtra();

        void EXPR()
        {
            indEXPR = 0;
            record = new List<Token>();
           
            while (currentLexeme.Type != TokenType.THEN)
            {
                record.Add(currentLexeme);
                Shift();
                indEXPR++;
                StateStack.Push(1); 
               if(currentLexeme.Type == TokenType.ENDLINE)
                    throw new Exception($"Ожидалось <EXPR>, ключевое слово IF или THEN, а встретился {IsSpecialWord(currentLexeme)}");
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

        void State15()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<EXPR>":
                                Shift();
                                break;
                        }
                        break;
                    }
                case TokenType.IF:
                    {
                        if(currentLexeme.Type == TokenType.ENDLINE)
                            throw new Exception($"Ожидалось THEN, а встретился {IsSpecialWord(TokenStack.Peek())}");
                        EXPR();
                        Reduce(indEXPR, "<EXPR>");
                        break;
                    }
                case TokenType.THEN:
                    GoToState(19);
                    break;
                default:
                    throw new Exception($"Ожидалось <EXPR>, ключевое слово IF или THEN, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State16()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.EQUAL:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<операнд>":
                                GoToState(20);
                                break;
                        }
                        break;
                    }
                case TokenType.LITERAL:
                    {
                        GoToState(21);
                        break;
                    }
                case TokenType.ID:
                    GoToState(22);
                    break;
                default:
                    throw new Exception($"Ожидалось <операнд>, знак =, идентификатор или литерал, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State17()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.AS:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<тип>":
                                GoToState(23);
                                break;
                        }
                        break;
                    }
                case TokenType.INTEGER:
                    {
                        GoToState(24);
                        break;
                    }
                case TokenType.LONG:
                    GoToState(25);
                    break;
                case TokenType.STRING:
                    GoToState(26);
                    break;
                case TokenType.BOOLEAN:
                    GoToState(21);
                    break;
                default:
                    throw new Exception($"Ожидалось <тип>, ключевое слово AS или тип переменной, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State18()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.COMM:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<спис перем>":
                                GoToState(28);
                                break;
                        }
                        break;
                    }
                case TokenType.ID:
                    {
                        GoToState(12);
                        break;
                    }
                default:
                    throw new Exception($"Ожидалось <спис перем>, запятая или идентификатор, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State19()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.THEN:
                    Shift();
                    break;
                case TokenType.ENDLINE:
                    {
                        GoToState(29);
                        break;
                    }
                default:
                    throw new Exception($"Ожидалось ключевое слово THEN или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        

        void State20()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<операнд>":
                                {
                                    if (currentLexeme.Type == TokenType.ENDLINE)
                                    {
                                        Reduce(3, "<присв>");
                                    }
                                   else if (currentLexeme.Type == TokenType.PLUS || currentLexeme.Type == TokenType.MINUS|| 
                                        currentLexeme.Type == TokenType.MULTI|| currentLexeme.Type == TokenType.DIV)
                                        Shift();
                                    else throw new Exception($"Ожидалось <операнд>,<знак> или знаки + - * /, а встретился {IsSpecialWord(TokenStack.Peek())}");

                                }
                                break;
                            case "<знак>":
                                GoToState(30);
                                break;
                        }                       
                    }
                    break;
                case TokenType.PLUS:
                    GoToState(31);
                    break;
                case TokenType.MINUS:
                    GoToState(32);
                    break;
                case TokenType.DIV:
                    GoToState(33);
                    break;
                case TokenType.MULTI:
                    GoToState(34);
                    break;
                default:
                    throw new Exception($"Ожидалось <операнд>,<знак> или знаки + - * /, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State21()
        {
            Reduce(1, "<операнд>");
        }
        void State22()
        {
            Reduce(1, "<операнд>");
        }

        void State23()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<тип>":
                                Shift();
                                break;
                        }
                    }
                    break;
                case TokenType.ENDLINE:
                    GoToState(35);
                    break;
                default:
                    throw new Exception($"Ожидалось <тип> или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State24()
        {
            Reduce(1, "<тип>");
        }
        void State25()
        {
            Reduce(1, "<тип>");
        }
        void State26()
        {
            Reduce(1, "<тип>");
        }
        void State27()
        {
            Reduce(1, "<тип>");
        }

        void State28()
        {
            Reduce(3, "<спис перем>");
        }

        void State29()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.ENDLINE:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            
                            case "<тело>":
                                
                                    GoToState(36);
                                
                                    break;
                            case "<опер>":
                                GoToState(5);
                                break;
                            case "<усл>":
                                GoToState(6);
                                break;
                            case "<присв>":
                                GoToState(7);
                                break;
                        }
                    }
                    break;               
                case TokenType.IF:
                    GoToState(8);
                    break;
                case TokenType.ID:
                    GoToState(9);
                    break;
                default:
                    throw new Exception($"Ожидалось <тело>,<опер>,<усл>,<присв>, ключевое слово IF, идентификатор или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State30()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<знак>":
                                Shift();
                                break;
                            case "<операнд>":
                                GoToState(37);
                                break;
                        }
                    }
                    break;
                case TokenType.LITERAL:
                    GoToState(21);
                    break;
                case TokenType.ID:
                    GoToState(22);
                    break;
                default:
                    throw new Exception($"Ожидалось <знак>,<операнд> идентификатор или литерал, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }
        void State31()
        {
            Reduce(1, "<знак>");
        }
        void State32()
        {
            Reduce(1, "<знак>");
        }
        void State33()
        {
            Reduce(1, "<знак>");
        }
        void State34()
        {
            Reduce(1, "<знак>");
        }

        void State35()
        {
            Reduce(5, "<описание>");
        }
        /// <summary>
        /// //////////////////////////////////////////////////
        /// </summary>
        void State36()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<тело>":  
                                if(currentLexeme.Type==TokenType.END)
                                {
                                    StateStack.Push(36);
                                    Reduce(1, "<альт>");
                                }
                                else if(currentLexeme.Type==TokenType.ELSE)
                                Shift();
                                else
                                    throw new Exception($"Ожидалось <тело>,<альт> или ключевое слово ELSE, а встретился {IsSpecialWord(TokenStack.Peek())}");
                                break;
                            case "<альт>":
                                GoToState(38);
                                break;
                        }
                    }
                    break;
                case TokenType.ELSE:
                    GoToState(39);
                    break;
                default:
                    throw new Exception($"Ожидалось <тело>,<альт> или ключевое слово ELSE, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }

        }


        void State37()
        {
            Reduce(5, "<присв>");
        }
        void State38()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<альт>":
                                Shift();
                                break;
                        }
                    }
                    break;
                case TokenType.END:
                    GoToState(40);
                    break;
                default:
                    throw new Exception($"Ожидалось <альт> или ключевое слово END, а встретился {IsSpecialWord(TokenStack.Peek())}");

            }
        }
        void State39()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.ELSE:
                    Shift();
                    break;
                case TokenType.ENDLINE:
                    GoToState(41);
                    break;
                default:
                    throw new Exception($"Ожидалось ключевое слово ELSE или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State40()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.END:
                    Shift();
                    break;
                case TokenType.IF:
                    GoToState(42);
                    break;
                default:
                    throw new Exception($"Ожидалось ключевое слово END или IF, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State41()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.ENDLINE:
                    Shift();
                    break;
                case TokenType.NETERM:
                    {
                        switch (TokenStack.Peek().Value)
                        {
                            case "<тело>":
                                GoToState(43);
                                break;
                            case "<опер>":
                                GoToState(5);
                                break;
                            case "<усл>":
                                GoToState(6);
                                break;
                            case "<присв>":
                                GoToState(7);
                                break;
                        }
                    }
                    break;
                case TokenType.IF:
                    GoToState(8);
                    break;
                case TokenType.ID:
                    GoToState(9);
                    break;
                default:
                    throw new Exception($"Ожидалось <тело>,<опер>,<усл>,<присв>,ключевое слово IF, идентификатор или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }

        void State42()
        {
            switch (TokenStack.Peek().Type)
            {
                case TokenType.IF:
                    Shift();
                    break;
                case TokenType.ENDLINE:
                    GoToState(44);
                    break;
                default:
                    throw new Exception($"Ожидалось ключевое слово IF или конец строки, а встретился {IsSpecialWord(TokenStack.Peek())}");
            }
        }
        void State43()
        {
            Reduce(3, "<альт>");
        }
        void State44()
        {
            Reduce(9, "<усл>");
        }
    }
}
