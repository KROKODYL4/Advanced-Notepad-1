using System.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;


namespace Notepad
{
    public partial class Form1 : Form
    {
        string file = "";

        private DialogResult Save()
        {
            DialogResult odp = MessageBox.Show("Do you want to save changes", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);
            if (odp == DialogResult.Yes)
                saveToolStripButton_Click(null, null);
            return odp;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (rtbNote.Text != "")
            {
                DialogResult odp = Save();
                if (odp == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced Notepad by Krokodyl4", "Advanced Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void pasteToolStripButton_Click(object sender, EventArgs e)
        {
            rtbNote.Paste();
        }

        private void copyToolStripButton_Click(object sender, EventArgs e)
        {
            rtbNote.Copy();
        }

        private void cutToolStripButton_Click(object sender, EventArgs e)
        {
            rtbNote.Cut();
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.ShowDialog();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (file != "")
            {
                StreamWriter f = new StreamWriter(file);
                f.Write(rtbNote.Text);
                f.Close();
            }
            else saveAs_Click(sender, e);
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file (*txt)|*.txt |All files(*.*)|*.*";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                file = dialog.FileName;
                StreamWriter f = new StreamWriter(file);
                f.Write(rtbNote.Text);
                f.Close();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            if (rtbNote.Text != "")
            {
                DialogResult odp = Save();
                if (odp == DialogResult.Cancel)
                    return;
                file = "";
                rtbNote.Clear();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*txt)|*.txt |All files(*.*)|*.*";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                file = dialog.FileName;
                StreamReader f = new StreamReader(file);
                rtbNote.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            if (rtbNote.Text != "")
            {
                DialogResult odp = Save();
                if (odp == DialogResult.Cancel)
                    return;
                file = "";
                rtbNote.Clear();
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.ShowDialog();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Text file (*txt)|*.txt |All files(*.*)|*.*";
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                file = dialog.FileName;
                StreamWriter f = new StreamWriter(file);
                f.Write(rtbNote.Text);
                f.Close();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (file != "")
            {
                StreamWriter f = new StreamWriter(file);
                f.Write(rtbNote.Text);
                f.Close();
            }
            else saveAs_Click(sender, e);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbNote.Text != "")
            {
                DialogResult odp = Save();
                if (odp == DialogResult.Cancel)
                    return;
                file = "";
                rtbNote.Clear();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text file (*txt)|*.txt |All files(*.*)|*.*";
            dialog.Multiselect = false;
            dialog.ShowDialog();
            if (dialog.FileName != "")
            {
                file = dialog.FileName;
                StreamReader f = new StreamReader(file);
                rtbNote.Text = f.ReadToEnd();
                f.Close();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtbNote.Text != "")
            {
                DialogResult odp = Save();
                if (odp == DialogResult.Cancel)
                    return;
                file = "";
                rtbNote.Clear();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuStrip1.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            shortcutsToolStripMenuItem_Click(null, null);
        }

        private void shortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "   Shortcuts:\n\n" +
                "   Ctrl + N - New File\n" +
                "   Ctrl + O - Open File\n" +
                "   Ctrl + S - Save\n" +
                "   Ctrl + Shift + S - Save As\n" +
                "   Ctrl + P - Print\n" +
                "   Ctrl + C - Copy\n" +
                "   Ctrl + V - Paste\n" +
                "   Ctrl + X - Cut\n" +
                "   Ctrl + Shift + A - About\n" +
                "   Alt + F4 - Exit\n" +
                "   Ctrl + Alt + Shift - This List",
                "Shortcuts",
                MessageBoxButtons.OK,
                MessageBoxIcon.None
                );
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pasteToolStripButton_Click(null, null);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cutToolStripButton_Click(null, null);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            copyToolStripButton_Click(null, null);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Advanced Notepad by Krokodyl4", "Advanced Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton2_Click(null, null);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
