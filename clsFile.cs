using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clsFile_ns
{
    public class clsFile
    {
        //campi privati
        private string filename;
        private bool modificato;
        //property        
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
            }
        }

        public bool Modificato
        {
            get
            {
                return modificato;
            }
            set
            {
                modificato = value;
            }
        }
        //costruttore/i
        public clsFile()
        {
            this.Filename = "";
            this.Modificato = false;
        }
        //metodi privati
        private string leggiFile()
        {
            string testo = "";
            if (this.filename != "")
            {
                StreamReader sr = new StreamReader(this.filename);
                testo = sr.ReadToEnd();
                sr.Close();
                this.modificato = false;
            }
            return testo;
        }

        private void scriviFile(string testo)
        {
            if (this.filename != "")
            {
                StreamWriter sw = new StreamWriter(this.filename, false);
                sw.Write(testo);
                sw.Close();
                this.modificato = false;
            }
        }
        //metodi pubblici
        public string apri()
        {
            string testo = "";
            OpenFileDialog dlgApri = new OpenFileDialog();
            dlgApri.Filter = "Pagina HTML (*.html;*.htm)|" +
                             "*.html;*.htm|Tutti i file (*.*)|*.*";
            dlgApri.FileName = "*.html";
            DialogResult ris = dlgApri.ShowDialog();
            if (ris == DialogResult.OK)
            {
                this.Filename = dlgApri.FileName;
                testo = this.leggiFile();
            }
            return testo;
        }
        public void salvaConNome(string testo)
        {
            SaveFileDialog dlgSalva = new SaveFileDialog();
            dlgSalva.Filter = "Pagina HTML (*.html;*.htm)|" +
                              "*.html;*.htm|Tutti i file (*.*)|*.*";
            dlgSalva.FileName = "*.html";
            DialogResult ris = dlgSalva.ShowDialog();
            if (ris == DialogResult.OK)
            {
                this.Filename = dlgSalva.FileName;
                this.scriviFile(testo);
            }
        }
        public void salva(string testo)
        {
            if (this.modificato)
                if (this.filename != "")
                    scriviFile(testo);
                else
                    salvaConNome(testo);
        }
        public string getFilenameRelativo()
        {
            //estrae il nome del file
            string s = "";
            if (this.filename != "")
            {
                s = Path.GetFileName(this.filename);
                //oppure
                //int pos = this.filename.LastIndexOf('\\');
                //s = this.filename.Substring(pos + 1);
            }
            else
                s = "senza nome";
            return s;
        }
        public string getFilename()
        {
            //ritorna il percorso completo
            string s = "";
            if (this.filename != "")
            {
                s = this.filename;
            }
            else
                s = "senza nome";
            return s;
        }
    }
}
