using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the 'mydbDataSet.item' table. You can move, or remove it, as needed.
            string appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
            string filePath = Path.Combine(appPath, "test.htm");

            string text = "<br><br><h1>A class</h1> <p>is the most powerful data type in C#.</p><p> Like a structure,</br> " +
                       "a class defines the <strong>data</strong> and behavior of the data type. </p>";
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            //System.IO.File.WriteAllText(@"C:\Users\Public\WriteText.txt", text);
            string localPath = new Uri(filePath).LocalPath;
            System.IO.File.WriteAllText(@localPath, text);

            //webBrowser1.Url = new Uri(Path.Combine("file://", filePath));
            webBrowser1.Url = new Uri(Path.Combine(filePath));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.Print();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
