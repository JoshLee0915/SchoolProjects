using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLParser
{
    // enums that reoresent token types
    public enum tokenType
    {
        err_newLine = 1, err_floatSpace, err_floatExpnt, err_invalid_token, t_assign, t_comma, t_comp_op,
        t_comp_op_lg, t_float_lit, t_int_lit, t_lbrace, t_lparen, t_op, t_div_op, t_rbrace,
        t_rparen, t_id, t_comment, t_int_lit_0, t_const = 26, t_else = 27, t_default = 28,
        t_float = 29, t_for = 30, t_func = 31, t_if = 32, t_int = 33, t_return = 34, t_var = 35
    };

    // A class that represents tokens
    public class Token
    {
        // The type of token found
        public tokenType t_type { get; private set; }
        // The token found
        public string token { get; private set; }
        // The index of the filal char in the token
        public int index { get; private set; }

        /* constructor */
        public Token(tokenType type, string strToken, Hashtable keyWords, int position)
        {
            // store the token type
            t_type = type;
            // store the token represnting the string
            token = strToken;
            // store the index of the token in the file
            index = (strToken.Length > 1) ? position - strToken.Length + 1 : position;

            // check if the token is an ID
            switch (t_type)
            {
                // check if the token is an ID
                case tokenType.t_id:
                    // if the token is an ID check if it is a key word
                    if (keyWords.ContainsKey(strToken))
                        //if so change the type to a keyword
                        t_type = (tokenType)keyWords[strToken];
                    break;
                // check if it is a < > comp op and set the type to a comp_op
                case tokenType.t_comp_op_lg:
                    t_type = tokenType.t_comp_op;
                    break;
                // check if the type is a zero int and if it is set it as an int_lit
                case tokenType.t_int_lit_0:
                    t_type = tokenType.t_int_lit;
                    break;
                // check if it is a div op type and change it into a regular op
                case tokenType.t_div_op:
                    t_type = tokenType.t_op;
                    break;

            }
        }
        // create a string describing the token
        public override string ToString()
        {
            string strType;
            // determin the type of token from the enum
            switch (t_type)
            {
                case tokenType.err_floatExpnt:
                    strType = "Invalid exponit for float_lit: ";
                    break;
                case tokenType.err_floatSpace:
                    strType = "Space expected for float_lit: ";
                    break;
                case tokenType.err_invalid_token:
                    strType = "Invalid token: ";
                    break;
                case tokenType.err_newLine:
                    strType = "Token can not be on its own line: ";
                    break;
                case tokenType.t_assign:
                    strType = "Assign: ";
                    break;
                case tokenType.t_comma:
                    strType = "Comma: ";
                    break;
                case tokenType.t_comp_op:
                    strType = "Comp_op: ";
                    break;
                case tokenType.t_float_lit:
                    strType = "Float_lit";
                    break;
                case tokenType.t_id:
                    strType = "ID: ";
                    break;
                case tokenType.t_int_lit:
                    strType = "Int_lit: ";
                    break;
                case tokenType.t_lbrace:
                    strType = "Lbrace: ";
                    break;
                case tokenType.t_lparen:
                    strType = "Lparen: ";
                    break;
                case tokenType.t_op:
                    strType = "Op: ";
                    break;
                case tokenType.t_rbrace:
                    strType = "Rbrace: ";
                    break;
                case tokenType.t_rparen:
                    strType = "Rparen: ";
                    break;
                default:
                    strType = "Keyword: ";
                    break;
            }
            // return the string discribing the token
            return strType + token + " @ index: " + index;
        }
    }
    // contains methods for lexual anls of a passed file
    public class LexAnlsUtil
    {
        private Hashtable keyWords;         // the table for the keyword lookup
        private List<Hashtable> lexTable;   // the table for the lex anls
        // Constuctor for the lexAnlsUtil 
        public LexAnlsUtil(List<Hashtable> lex_table, Hashtable key_words)
        {
            keyWords = key_words;
            lexTable = lex_table;
        }
        // Take the text and scan it for tokens then return the list of tokens
        public List<Token> scanForTokens(string fileText)
        {
            string token = "";                              // a string of the token being scaned
            int state = 0;                                  // the current state
            int index = 0;                                  // current index of the file
            List<Token> tokenStream = new List<Token>();    // A list of found tokens

            // scan each char in the file and run it through the table
            foreach (char symbol in fileText)
            {
                // look at the current char and move to the next state the table points to
                state = (int)lexTable[state][symbol.ToString()];

                // if not whitespace newline or tab add the symbol to the token string
                if (symbol != '\n' && symbol != '\t' && symbol != ' ')
                    token += symbol;

                // look ahead one char to see if this char is the last one
                if (index + 1 < fileText.Length)
                {
                    // if the next state is null then a token was found
                    int nextCode = (int)lexTable[state][fileText[index + 1].ToString()];
                    if ((int)lexTable[state][fileText[index + 1].ToString()] == -1)
                    {
                        // if not a comment or empty add the token to the list
                        if (state != (int)tokenType.t_comment && token != "")
                            tokenStream.Add(new Token((tokenType)state, token, keyWords, index));

                        // clear the state and token
                        state = 0;
                        token = "";
                    }
                }
                index++;
            }

            return tokenStream;
        }

    }
}
