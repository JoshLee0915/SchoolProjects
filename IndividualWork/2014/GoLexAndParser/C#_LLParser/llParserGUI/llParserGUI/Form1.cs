using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLParser;

namespace llParserGUI
{
    public partial class Form1 : Form
    {
        // used for the begin and end update
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
        private const int WM_SETREDRAW = 0x0b;

        private int index;
        private bool loaded;
        private string file;
        private LexFileIO fileIO;
        private LexAnlsUtil lexAnls;
        private List<Token> tokens;
        private ParserUtil parser;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            index = 0;
            loaded = false;
            fileIO = new LexFileIO();

            // load the default table
            if (!fileIO.loadTable("lexTable.xml"))
                MessageBox.Show(fileIO.lastExcption.ToString());

            // load the parsing table
            if(!fileIO.loadParseTable("predictSet.xml"))
                MessageBox.Show(fileIO.lastExcption.ToString());

            // load and display the about.txt file
            rtxSrc.Text = fileIO.readTxt("about.txt");

            // set up lexAnls
            lexAnls = new LexAnlsUtil(fileIO.lexTableList, fileIO.keyWords);

            // set up the parser
            parser = new ParserUtil(fileIO.parseTable, fileIO.predictSets, fileIO.syncSets);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            bool parseSucess = false;
            // set the index to 0
            index = 0;
            // check if a src file has alreadt been loaded
            if(loaded)
            {
                // if one is aleart the user that it will be aborted
                if (MessageBox.Show("Do you want to abort current analysis?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    // return back to previus state
                    return;
                }
            }

            // clear the tree view
            tvwParseTree.Nodes.Clear();

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path;
                System.IO.FileInfo fInfo = new System.IO.FileInfo(openFileDialog1.FileName);
                path = fInfo.FullName;

                // read the file
                file = fileIO.readTxt(path);
                // check if the file was read
                if (file == null)
                    MessageBox.Show(fileIO.lastExcption.ToString());
                else
                {
                    // set loaded to true
                    loaded = true;
                    // clear last token stream display
                    rtxTokenStream.Clear();
                    // display the src file
                    rtxSrc.Text = file;

                    // run the anls
                    tokens = lexAnls.scanForTokens(file);
                    // run up the parser
                    parseSucess = parser.parse(tokens);

                    // check if the paring falied or not
                    if (parseSucess == true)
                        tvwParseTree.ForeColor = Color.Black;
                    else
                        tvwParseTree.ForeColor = Color.Red;

                    // display the tree
                    tvwParseTree.Nodes.Add(parser.parseTreeRoot.dislayTree());
                    tvwParseTree.ExpandAll();

                    // look for errors
                    scanForErrs();

                    // display the stack trace
                    rtxStackTrace.Text = parser.stackTrace;
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // stop the program
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int startIndex = 0;     // the starting index of the token
            int length = 0;         // the length of the token

            begainUpdate();         // freeze the rich texbox till all drawing is over

            // check if a file was loaded
            if(!loaded)
            {
                // if not display msg then return
                rtxTokenStream.Text += "*****No File Loaded*****\n";
                return;
            }
            //Check if the index is still in range
            if (index < tokens.Count)
            {
                // clear the src file and redisplay it with no highlights
                rtxSrc.Clear();
                rtxSrc.Text = file;
                SendMessage(rtxSrc.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);

                //rehighlight the erros
                highlightErrors();
                //Display the token
                rtxTokenStream.Text += tokens[index].ToString() + "\n";

                // calc the starting index
                startIndex = tokens[index].index;
                length = tokens[index].token.Length;

                // select the token
                rtxSrc.Select(startIndex, length);

                // highlight green
                rtxSrc.SelectionBackColor = Color.LightGreen;

                //inc index
                index++;
            }
            //display that the end of stream was reached
            else
                rtxTokenStream.Text += "*****End of token stream*****\n";
            
            //scroll to the end
            rtxTokenStream.SelectionStart = rtxTokenStream.Text.Length;
            rtxTokenStream.ScrollToCaret();

            // end the update
            endUpdate();
        }
        // scans the file for errers and displays them
        private void scanForErrs()
        {
            // clear last errors
            rtxErr.Text = "";

            begainUpdate();         // freeze the rich texbox till all drawing is over

            // clear the src file and redisplay it with no highlights
            rtxSrc.Clear();
            rtxSrc.Text = file;
            SendMessage(rtxSrc.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);

            // look for err tokens
            foreach(Token tok in tokens)
            {
                // display the lex errors
                rtxErr.ForeColor = Color.Red;
                if (tok.t_type < tokenType.t_assign)
                    rtxErr.Text += tok.ToString() + "\n";

                rtxErr.SelectionStart = rtxErr.Text.Length;
                rtxErr.ScrollToCaret();
            }

            // dispay the parse errors
            rtxErr.Text += parser.errorLog;
            rtxErr.SelectionStart = rtxErr.Text.Length;
            rtxErr.ScrollToCaret();

            // if no erros found
            if (rtxErr.Text == "")
            {
                rtxErr.ForeColor = Color.Green;
                rtxErr.Text = "No Errors Found\nSUCESS!";
            }
            // Highlight the errors
            else
            {
                rtxErr.Text += "FAILED!\n";
                highlightErrors();
            }

            endUpdate();
        }
        // serches for and highlights errors
        private void highlightErrors()
        {
            // look for err tokens
            foreach (Token tok in tokens)
            {
                if (tok.t_type < tokenType.t_assign)
                {
                    rtxSrc.Select(tok.index, tok.token.Length);
                    // highlight red
                    rtxSrc.SelectionBackColor = Color.Red;
                }

                rtxErr.SelectionStart = rtxErr.Text.Length;
                rtxErr.ScrollToCaret();
            }
        }

        /*Since rich text box lacks these functions add them to allow for smooth drawing on the src Richtexbox */
        private void begainUpdate()
        {
            SendMessage(rtxSrc.Handle, WM_SETREDRAW, (IntPtr)0, IntPtr.Zero);
        }

        private void endUpdate()
        {
            SendMessage(rtxSrc.Handle, WM_SETREDRAW, (IntPtr)1, IntPtr.Zero);
            rtxSrc.Invalidate();
        }
    }
}
