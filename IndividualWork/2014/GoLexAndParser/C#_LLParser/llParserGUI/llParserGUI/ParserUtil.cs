using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LLParser
{
    // enums to represent productions
    // < 50 is terminals >= 50 is nonterminals
    public enum parserSymbols{ assign, comma, comp_op, float_lit, int_lit, lbrace, lparen, op, rbrace,
        rparen, id, t_const, t_else, t_default, t_float, t_for, t_func, t_if, t_int, t_return, t_var, t_EOF,
        program=50, func_def_list, func_def, func_def_tail, parm_list, parm_list_tail, parm_pair, stmt_block, 
        stmt, var_decl, const_decl, id_list, id_list_tail, assign_stmt, for_stmt, for_stmt_tail, if_stmt, 
        if_stmt_tail, else_stmt, else_stmt_tail, condtion, return_stmt, return_stmt_tail, expr, term_tail, 
        term, term_rest, arg_list, arg_list_tail, data_type, EPS, nEnd = 100};

    class ParseNode
    {
        private int index;    // the index of the current chiled in the list
        public bool err { get; set; }    // the node is a parsing error node
        public ParseNode nodeParrent { get; private set; }  // the parrent of the node null if root
        public parserSymbols nodeSymbol { get; private set; } // the symbol of the node
        public Token nodeToken { get; set; } // The token the node represents will be null if nonterminal 
        public List<ParseNode> children { get; private set; }   // the list of children from this node will be 0 if non present
        
        // construtor for root node
        public ParseNode(parserSymbols symbol, Token token = null)
        {
            index = 0;
            err = false;
            // set the parrent to null since it is root
            nodeParrent = null;
            // set the symbol
            nodeSymbol = symbol;
            // set the token. Will be null if nonterminal
            nodeToken = token;
            // intalize the children list
            children = new List<ParseNode>();
        }
        // construtor for child nodes
        public ParseNode(ParseNode parrent, parserSymbols symbol, Token token = null)
        {
            index = 0;
            err = false;
            // set the parrent to null since it is root
            nodeParrent = parrent;
            // set the symbol
            nodeSymbol = symbol;
            // set the token. Will be null if nonterminal
            nodeToken = token;
            // intalize the children list
            children = new List<ParseNode>();
        }
        // check if the node has children
        public bool hasChildren()
        {
            if (children.Count > 0)
                return true;    // contains children if greater than 0
            return false;
        }
        // add nodes
        public void addChild(ParseNode node)
        {
            children.Add(node);
        }
        public void addChild(parserSymbols symbol, Token token = null)
        {
            children.Add(new ParseNode(this, symbol, token));
        }
        // remove children and their children
        public void removeChild(int index)
        {
            if(index < children.Count)
                children.RemoveAt(index);
        }
        public void removeChild(ParseNode node)
        {
            if (node != this)
                children.Remove(node);
        }
        public void removeChild(parserSymbols symbl)
        {
            ParseNode node = getChild(symbl);

            if (node != null)
                children.Remove(node);
        }
        // remove all children
        public void removeAllChildren()
        {
            children.Clear();
        }
        // finds and returns the first child node with matched symbl
        public ParseNode getChild(parserSymbols symbl)
        {
            foreach (ParseNode child in children)
                if (child.nodeSymbol == symbl)
                    return child;

            return null;
        }
        // get the first child
        public ParseNode getFirstChild()
        {
            // check if it has children
            if (hasChildren())
                return children[0];     // return the first child

            return null;                // no child was found
        }
        // get the last child on the list
        public ParseNode getLastChild()
        {
            // check if it has children
            if (hasChildren())
                return children[children.Count-1];     // return the last child

            return null;                                // no child was found
        }
        // get the next child starting from the left most and moving right
        public ParseNode getNextChild()
        {
            // check if the index needs to reset to 0
            if (index >= children.Count)
                index = 0;

            // check if the node has children
            if (hasChildren())
                return children[index++];       // return the child and inc index

            return null;        // no child was found
        }
        // get the next child starting from the left most and moving right and reset to the left if desired
        public ParseNode getNextChild(bool reset)
        {
            // check if we need to start back at the left
            if (reset == true)
                index = 0;
            // check if the index needs to reset to 0
            else if (index >= children.Count)
                index = 0;

            // check if the node has children
            if (hasChildren())
                return children[index++];       // return the child and inc index

            return null;        // no child was found
        }
        // gets the next child returning the parrent when there is no more children
        public ParseNode traverseChildren()
        {
            // check if the node has children
            if (hasChildren() && index < children.Count)
                return children[index++];       // return the child and inc index

            return nodeParrent ?? this;         // no child was found return to the parrent if parent is null this is the root
        }
        public ParseNode getNext(bool reset)
        {
            // check if we need to start back at the left
            if (reset == true)
                index = 0;

            // check if the node has children
            if (hasChildren() && index < children.Count)
                return children[index++];       // return the child and inc index

            return nodeParrent ?? this;         // no child was found return to the parrent if parent is null this is the root
        }
        // reverse the children (done to match with the stack)
        public void reverseChildren()
        {
            children.Reverse();
        }
        public TreeNode dislayTree()
        {
            TreeNode root = new TreeNode(this.nodeSymbol.ToString(), getLeaves().ToArray());

            return root;
        }
        private List<TreeNode> getLeaves()
        {
            List<TreeNode> tChildren = new List<TreeNode>();

            // turn each of the children into leaves
            foreach(ParseNode child in children)
                tChildren.Add(new TreeNode(child.nodeSymbol.ToString(), child.getLeaves().ToArray()));
            
            return tChildren;
        }
    }
    // class to represent terminals
    class Terminal
    {
        public Token token { get; set; }
        public parserSymbols symbols { get; set; }

        public Terminal(Token tkn, parserSymbols symb)
        {
            token = tkn;
            symbols = symb;
        }
    }

    class ParserUtil
    {
        public string errorLog { get; private set; }
        public string stackTrace { get; private set; }
        public Exception lastException { get; private set; }
        public ParseNode parseTreeRoot { get; private set; }
        public List<List<int>> parserTable {get; private set;}
        public List<List<int>> prodctionsTable { get; private set; }
        public List<List<int>> syncTable { get; private set; }
        public Stack<Terminal> terminalsStream { get; private set; }

        public ParserUtil(List<List<int>> pTable, List<List<int>> prodctions, List<List<int>> syncSets)
        {
            errorLog = "";
            stackTrace = "";
            parserTable = pTable;
            prodctionsTable = prodctions;
            syncTable = syncSets;
        }

        // parses the code and return true on sucess and false on failure
        public bool parse(List<Token> tknStream)
        {
            bool sucess = true;
            parserSymbols currSymbol;
            Terminal currToken;
            ParseNode currNode;

            // load the token stream
            terminalsStream = convertTokenStream(new List<Token>(tknStream));

            // clear the error log
            errorLog = "";
            // clear the stack trace
            stackTrace = "";

            int production = -1;
            Stack<Terminal> tokenStream = terminalsStream;

            // push the first production onto the stack
            Stack<parserSymbols> parseStack = new Stack<parserSymbols>();
            // create the root node
            parseTreeRoot = new ParseNode(parserSymbols.program);
            // set the curr node to the root node
            currNode = parseTreeRoot;

            // push the start to the stack
            parseStack.Push(parserSymbols.program);
            stackTrace = "Push: " + parserSymbols.program + "\n";

            currToken = tokenStream.Pop();     // get the first token in the stream

            // enclose in a try block to catch excptions if any occure during parsing
            try
            {
                while (parseStack.Count > 0)
                {
                    currSymbol = parseStack.Pop();          // get the symbol on the stop of the stack

                    stackTrace += "Pop: " + currSymbol + "\n";

                    // this is a node traversal up so just skip it
                    if (currSymbol == parserSymbols.nEnd) { }

                    // check if the currSymbol is a token
                    else if ((int)currSymbol < 50)
                    {
                        // check if the expected Symbol matches the expected one
                        if (currToken.symbols == currSymbol)
                            stackTrace += "Match: " + currToken.symbols + "\n";

                        else
                        {
                            // set the current node to error state
                            currNode.err = true;
                            // push the error onto the stack trace
                            stackTrace += "Error: " + currSymbol + "\n";
                            // record the error to the error log
                            errorLog += "[ERR] Expected " + currSymbol + " instead token " + currToken.token.ToString() + " was found\n";
                            sucess = false;
                        }

                        // check for EOF
                        if (currToken.symbols != parserSymbols.t_EOF)
                        {
                            // add the token to the node before moving on
                            currNode.nodeToken = currToken.token;

                            // get the next token
                            currToken = tokenStream.Pop();
                            stackTrace += "Next Token: " + currToken.symbols + "\n";
                        }
                        else
                            return sucess;

                        currNode = currNode.nodeParrent;    // move up one level

                    }
                    // get the next production to use and check if it is an error
                    else if ((production = getProduction(currSymbol, currToken.symbols)) > -1)
                    {
                        // push the symbol for the end of the production onto the stack
                        // NOTE: nEnd is a dummy symbol used to sync the stack to the traversial of the trees
                        parseStack.Push(parserSymbols.nEnd);
                        stackTrace += "Push: " + parserSymbols.nEnd + "\n";

                        // push the symbols onto the stack
                        foreach (parserSymbols symbol in prodctionsTable[production])
                        {
                            // add the new node
                            currNode.addChild(symbol);

                            // check if it is an epsilon
                            if (symbol != parserSymbols.EPS)
                            {
                                parseStack.Push(symbol);
                                stackTrace += "Push: " + symbol + "\n";
                            }
                            else
                            {
                                parseStack.Push(parserSymbols.nEnd);
                                stackTrace += "Push: " + parserSymbols.nEnd + "\n";
                            }
                        }

                        // reverse the children so it is now left to right
                        currNode.reverseChildren();
                    }
                    // there was an error
                    else
                    {
                        stackTrace += "Error: " + currSymbol + "\n";    // add the error to the stack trace
                        errorLog += "[ERR] Unexpected token : " + currToken.token.ToString();   // log the err
                        sucess = false;                                 // set the sucess flag to false

                        // commence error recovery: Pop items off the stack until a sync token is found
                        while(tokenStream.Count > 0)
                        {
                            currToken = tokenStream.Pop();
                            if (syncTable[(int)currSymbol-50].Contains((int)currToken.symbols))
                            {
                                errorLog += " recovered at: " + currToken.symbols.ToString() + "\n";
                                break;      // a valid sync was found
                            }
                        }

                        // check if any tokens are left in the stream
                        if(tokenStream.Count <= 0)
                        {
                            errorLog += "\n[ERR]Unable to recover\n";    // log that we where unable to recover
                            return false;                           // end
                        }
                    }

                    // move to the next node
                    currNode = currNode.traverseChildren();

                    // move back to the parrent if eps
                    if (currNode.nodeSymbol == parserSymbols.EPS)
                        currNode = currNode.nodeParrent;
                }
            }
            catch (Exception e)
            {
                lastException = e;
                errorLog = "[ERR] " + e.ToString();
                sucess = false;
            }

            return sucess;
        }
        // get the next prodiction based off of the top of the stack
        private int getProduction(parserSymbols currSymbol, parserSymbols currToken)
        {
            int row = (int)currSymbol - 50;
            int clm = (int)currToken;

            if (row < 0)
                return -1;

            return parserTable[row][clm];
        }
        //convert the tokens into correct parser symbols
        private Stack<Terminal> convertTokenStream(List<Token> tokenStream)
        {
            Stack<Terminal> termStream = new Stack<Terminal>();

            // reverse the stream so it can be pushed onto the stack
            tokenStream.Reverse();

            // add eof
            termStream.Push(new Terminal(null, parserSymbols.t_EOF));
            
            foreach(Token t in tokenStream)
            {
                switch(t.t_type)
                {
                    case tokenType.t_float_lit:
                    case tokenType.err_floatExpnt:
                    case tokenType.err_floatSpace:
                        termStream.Push(new Terminal(t, parserSymbols.float_lit));
                        break;
                    case tokenType.t_id:
                    case tokenType.err_invalid_token:
                        termStream.Push(new Terminal(t, parserSymbols.id));
                        break;
                    case tokenType.t_lbrace:
                    case tokenType.err_newLine:
                        termStream.Push(new Terminal(t, parserSymbols.lbrace));
                        break;
                    case tokenType.t_assign:
                        termStream.Push(new Terminal(t, parserSymbols.assign));
                        break;
                    case tokenType.t_comma:
                        termStream.Push(new Terminal(t, parserSymbols.comma));
                        break;
                    case tokenType.t_comp_op:
                        termStream.Push(new Terminal(t, parserSymbols.comp_op));
                        break;
                    case tokenType.t_const:
                        termStream.Push(new Terminal(t, parserSymbols.t_const));
                        break;
                    case tokenType.t_default:
                        termStream.Push(new Terminal(t, parserSymbols.t_default));
                        break;
                    case tokenType.t_else:
                        termStream.Push(new Terminal(t, parserSymbols.t_else));
                        break;
                    case tokenType.t_float:
                        termStream.Push(new Terminal(t, parserSymbols.t_float));
                        break;
                    case tokenType.t_for:
                        termStream.Push(new Terminal(t, parserSymbols.t_for));
                        break;
                    case tokenType.t_func:
                        termStream.Push(new Terminal(t, parserSymbols.t_func));
                        break;
                    case tokenType.t_if:
                        termStream.Push(new Terminal(t, parserSymbols.t_if));
                        break;
                    case tokenType.t_int:
                        termStream.Push(new Terminal(t, parserSymbols.t_int));
                        break;
                    case tokenType.t_int_lit:
                        termStream.Push(new Terminal(t, parserSymbols.int_lit));
                        break;
                    case tokenType.t_lparen:
                        termStream.Push(new Terminal(t, parserSymbols.lparen));
                        break;
                    case tokenType.t_op:
                        termStream.Push(new Terminal(t, parserSymbols.op));
                        break;
                    case tokenType.t_rbrace:
                        termStream.Push(new Terminal(t, parserSymbols.rbrace));
                        break;
                    case tokenType.t_return:
                        termStream.Push(new Terminal(t, parserSymbols.t_return));
                        break;
                    case tokenType.t_rparen:
                        termStream.Push(new Terminal(t, parserSymbols.rparen));
                        break;
                    case tokenType.t_var:
                        termStream.Push(new Terminal(t, parserSymbols.t_var));
                        break;
                }
            }
            return termStream;
        }
    }
}
