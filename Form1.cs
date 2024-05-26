using part_1;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace TCA_Kurs
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Token> tokens = new List<Token>();
        Token token;
        LowerAnalyzer LoAn;
        UpperAnalyze UpAn;
        string buffer = "";
        char[] separator = new char[] { '>', '<', '*', '=', '+', '-', '/', '(', ')',',' };

        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFD.Reset();
            txbIn.Clear();
            txbOut.Clear();
            openFD.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                txbIn.Text = File.ReadAllText(openFD.FileName);
            }
            btnRun.Enabled = true;


        }
        public void identify()
        {
            if (IsSpecialWord(buffer))
            {
                token = new Token(SpecialWords[buffer]);
            }
            else if (IsSpecialSymbol(buffer[0]))
            {
                token = new Token(SpecialSymbols[buffer[0]]);
                token.Value = buffer[0].ToString();
            }
            else if (int.TryParse(buffer, out int t))//проверка является ли строка числом
            {
                token = new Token(TokenType.LITERAL);
                token.Value = buffer;
            }
            else
            {
                token = new Token(TokenType.ID);
                if (buffer.Length <= 7)
                    token.Value = buffer;
                else
                    throw new Exception("Имя переменной состоит из более 8 символов");
                
            }
            tokens.Add(token);
        }

        static Dictionary<string, TokenType> SpecialWords = new Dictionary<string, TokenType>()
        {
            { "Dim", TokenType.DIM },
            { "as", TokenType.AS },
            { "integer", TokenType.INTEGER },
            { "string", TokenType.STRING},
            { "long", TokenType.LONG },
            { "boolean", TokenType.BOOLEAN },
            { "and", TokenType.AND },
            { "if", TokenType.IF },
            { "then", TokenType.THEN },
            { "end", TokenType.END },
            { "for", TokenType.FOR },
            { "next", TokenType.NEXT },
            { "neterm", TokenType.NETERM },
            { "else", TokenType.ELSE },
            { "or", TokenType.OR },
            { "not", TokenType.NOT},
            {"\n",TokenType.ENDLINE }
        };

        static Dictionary<char, TokenType> SpecialSymbols = new Dictionary<char, TokenType>()
        {
            { '<', TokenType.LESS },
            { '>', TokenType.MORE },
            { '/', TokenType.DIV },
            { '*', TokenType.MULTI },
            { '+', TokenType.PLUS },
            { '-', TokenType.MINUS },
            { '=', TokenType.EQUAL },
            { ',', TokenType.COMM },
            { '(', TokenType.LEFTBRACK },
            { ')', TokenType.RIGHTBRACK }

        };


        public static bool IsSpecialSymbol(char ch)
        {
            return SpecialSymbols.ContainsKey(ch);
        }
        public bool IsSeparator(char ch)
        {
            if (separator.Contains(ch))
                return true;
            return false;
        }
        public bool IsSpace(char ch)
        {
            if (ch == ' ')
                return true;
            return false;
        }
        public static bool IsSpecialWord(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                return false;
            }
            return (SpecialWords.ContainsKey(word));

        }
        private void btnRun_Click(object sender, EventArgs e)
        {
            tokens.Clear();
            txbOut.Clear();
            txbMatrix.Clear();
            txbOPN.Clear();
            try
            {
                string reserve = RefactoringCode(txbIn.Text + Environment.NewLine);
                txbIn.Text = reserve;
             
                if (reserve.Length != 0)
                {
                    for (int i = 0; i < reserve.Length;)
                    {
                        if (Char.IsLetter(reserve[i]))
                        {
                            buffer += reserve[i];
                            i++;
                            if (Char.IsLetter(reserve[i]))
                            {
                                while (Char.IsLetter(reserve[i]))
                                {
                                    buffer += reserve[i];
                                    i++;
                                }
                            }
                            else if (Char.IsDigit(reserve[i]))
                            {
                                while (Char.IsDigit(reserve[i]))
                                {
                                    buffer += reserve[i];
                                    i++;
                                }
                                i -= 1;
                            }

                            else
                                i -= 1;
                            identify();
                            buffer = "";
                        }
                        else if (Char.IsDigit(reserve[i]))
                        {
                            buffer += reserve[i];
                            i++; 
                            if (Char.IsDigit(reserve[i]))
                            {
                                while (Char.IsDigit(reserve[i]))
                                {
                                    buffer += reserve[i];
                                    i++;
                                }
                                i -= 1;
                            }
                            else if (Char.IsLetter(reserve[i]))
                            {
                                buffer = "";
                                MessageBox.Show("Недопустимое объявление");
                                return;
                            }
                            else if (tokens[tokens.Count - 1].Type == TokenType.DIM)
                            {
                                throw new Exception($"Недопустимое объявление");
                            }
                            else
                                i -= 1;
                            identify();
                            buffer = "";
                        }
                        else if (IsSeparator(reserve[i]))
                        {
                            buffer += reserve[i];
                            i++;
                            if (tokens[tokens.Count-1].Type == TokenType.DIM)
                            {
                                throw new Exception($"Недопустимое объявление");
                            }
                            else
                                i -= 1;
                            identify();
                            buffer = "";
                        }
                        else if (reserve[i] == '\n')
                        {
                            buffer += reserve[i];
                            identify();
                            buffer = "";
                        }
                        else if(reserve[i] != ' ' && reserve[i] != '\r')
                        {
                            throw new Exception("Программа содержит недопустимые символы!");
                        }
                        i++;
                    }
                }
                else
                    MessageBox.Show("Строка пустая!");

                for (int i = 0; i < tokens.Count; i++)
                {
                    txbOut.Text += $"{tokens[i]}\r\n";
                }

                buffer = "";
                btnLowerAnalyzer.Enabled = true;

            }
            catch (Exception ex)
            {
                buffer = "";
                MessageBox.Show(ex.Message);
            }
        }

        public List<Token> GetSpisok()
        {
            return tokens;
        }

        private void btnLowerAnalyzer_Click(object sender, EventArgs e)
        {

            txbMatrix.Clear();
            txbOPN.Clear();
            LoAn = new LowerAnalyzer(tokens);
            try
            {
                LoAn.Program();
                MessageBox.Show("Анализатор успешно просканировал код");
                txbOPN.Text = LoAn.polish;
                txbMatrix.Text = LoAn.matrix;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            btnLowerAnalyzer.Enabled = false;

        }

        //private void btnUpperAnalyzer_Click(object sender, EventArgs e)
        //{

        //    txbMatrix.Clear();
        //    txbOPN.Clear();
        //    UpAn = new UpperAnalyze(tokens);
        //    try
        //    {
        //        UpAn.Start();
        //        MessageBox.Show("Анализатор успешно проверил синтаксис программы");
        //        txbOPN.Text += UpAn.polish;
        //        txbMatrix.Text += UpAn.matrix;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

        public string RefactoringCode(string str)
        {
            while (str.Contains("  ")) { str = str.Replace("  ", " "); }
            while (str.Contains(" \r\n")) { str = str.Replace(" \r\n", "\r\n"); }
            return str;
        }
    }


    public enum TokenType
    {
        DIM, ID, INTEGER, LONG, STRING, BOOLEAN, LITERAL, AS,
        PLUS, MINUS, DIV, MULTI, OR, NOT,
        IF, ELSE, THEN, MORE, LESS, AND,
        EQUAL, END, FOR, NEXT, COMM, ENDLINE, NETERM, LEFTBRACK, RIGHTBRACK
    }




}
