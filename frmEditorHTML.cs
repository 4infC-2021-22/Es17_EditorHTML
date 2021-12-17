using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using clsFile_ns;

namespace Es17_EditorHTML
{
    public partial class frmEditorHTML : Form
    {
        clsFile fileManager;
        public frmEditorHTML()
        {
            InitializeComponent();
        }
        private void frmEditorHTML_Load(object sender, EventArgs e)
        {
            fileManager = new clsFile();
            this.Text = fileManager.getFilenameRelativo() + " - Editor HTML";
            //scriviTag(nuovo(), 49);
            fileManager.Modificato = false;
            tabControlHTML.SelectedTab = tabPageHTML;
            //
            txtHTML.ContextMenuStrip = contextMenuStrip1;
            contextMenuStrip1.Show();
        }
        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nuovo();
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            nuovo();
        }

        private void tabControlHTML_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == "tabPageWEB")
                webBrowserHTML.DocumentText = txtHTML.Text;
        }

        private void apriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            apri();
        }
         
        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            apri();
        }
        private void apri()
        {
            bool annulla = false;
            string s;
            if (fileManager.Modificato)
            {
                //chiedo se vuole salvare il documento attualmente aperto
                string nomeFile = fileManager.getFilename();
                DialogResult ris;
                ris = MessageBox.Show("Salvare le modifiche a " + 
                    nomeFile, "Editor HTML", 
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ris == DialogResult.Yes)
                    fileManager.salva(txtHTML.Text);
                else if (ris == DialogResult.Cancel)
                    annulla = true;
            }
            if (!annulla)
            {
                s = fileManager.apri();
                if (s != "")
                {
                    txtHTML.Text = s;
                    fileManager.Modificato = false;
                }
                this.Text = fileManager.getFilenameRelativo() + 
                    " - Editor HTML";
            }
        }
        private void nuovo()
        {
            bool annulla = false;
            if (fileManager.Modificato)
            {
                //chiedo se vuole salvare il documento attualmente aperto
                string nomeFile = fileManager.getFilename();
                DialogResult ris;
                ris = MessageBox.Show("Salvare le modifiche a " +
                    nomeFile, "Editor HTML",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (ris == DialogResult.Yes)
                    fileManager.salva(txtHTML.Text);
                else if (ris == DialogResult.Cancel)
                    annulla = true;
            }
            if (!annulla)
            {
                txtHTML.Text = "";
                fileManager.Modificato = false;
                this.Text = "Senza Nome - Editor HTML";
            }
        }

        private void txtHTML_TextChanged(object sender, EventArgs e)
        {
            fileManager.Modificato = true;
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            salva();
        }

        private void salvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salva();
        }

        private void salva()
        {
            fileManager.salva(txtHTML.Text);
        }

        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fileManager.salvaConNome(txtHTML.Text);
        }

        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            taglia();
        }

        private void tagliaToolStripButton_Click(object sender, EventArgs e)
        {
            taglia();
        }

        private void taglia()
        {
            txtHTML.Cut();
        }

        private void copiaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Copy();
        }
        private void copiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHTML.Copy();
        }
        private void incollaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHTML.Paste();
        }

        private void incollaToolStripButton_Click(object sender, EventArgs e)
        {
            txtHTML.Paste();
        }

        private void annullaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtHTML.Undo();
        }

        private void ripristinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //
        }
    }
}
