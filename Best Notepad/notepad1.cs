using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Best_Notepad
{
    public partial class notepad1 : Form
    {

        #region fields 
        //ye 3 viriable save k lye lye ha
        private bool isFileAlreadySave;
        private bool isFileDirty;
        private string currentOpenFileName;
       private FontDialog fontdialog = new FontDialog();  //format ma fontcolor ko apply krny k lye
        #endregion

        public notepad1()
        {
            InitializeComponent();
        }
       
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }


      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("All Right Reserved with Hassan ", "About Notepad", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }



      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newFileMaMethod();
        }

        private void newFileMaMethod()
        {
            
            if (isFileDirty)
            {


                DialogResult result = MessageBox.Show("Do you want to save changes ? ", "File Save", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
               
                switch (result)
                {

                    case DialogResult.Yes:
                        savefilemanu();
                        break;

                    case DialogResult.No:

                        break;
                    case DialogResult.Cancel:
                        MessageBox.Show("Develop by Syed Bilal and Hasan Aamir ","Go to New File", MessageBoxButtons.OK);
                       
                        break;
                       
                }

            }

           
            clearScreen();

           
            isFileAlreadySave = false;
            currentOpenFileName = "";

            EnableDisableUndoRedoProcessKaMethog(false);

            messagetoolStripStatusLabel.Text = "New Document is Created ";

        }


       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }





       
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenKlyeMethod(); 
        }

        private void OpenKlyeMethod()
        {
          
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|MSWord Files (*.docx)|*.docx|PHP (*.php)|*.php";

            DialogResult result = openfiledialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(openfiledialog.FileName) == ".txt")

                    mainrichTextBox.LoadFile(openfiledialog.FileName, RichTextBoxStreamType.PlainText);

               
                if (Path.GetExtension(openfiledialog.FileName) == ".php")
                    mainrichTextBox.LoadFile(openfiledialog.FileName, RichTextBoxStreamType.PlainText);



                if (Path.GetExtension(openfiledialog.FileName) == ".rtf")
                    mainrichTextBox.LoadFile(openfiledialog.FileName, RichTextBoxStreamType.RichText);

                this.Text = Path.GetFileName(openfiledialog.FileName) + " - Notepad with Hassan Malik"; //file ka caption ma name dna jo b open kry
               

               
                isFileAlreadySave = true;
                isFileDirty = false;
                currentOpenFileName = openfiledialog.FileName;

                EnableDisableUndoRedoProcessKaMethog(false);

                messagetoolStripStatusLabel.Text = " File is Opened !";

            }

        }


        /// <param name="enable"></param>
        private void EnableDisableUndoRedoProcessKaMethog(bool enable)
        {
            undoToolStripMenuItem.Enabled = enable;
            redoToolStripMenuItem.Enabled = enable;
        }



       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            SaveAsFileKaMethod();

        }

        private void SaveAsFileKaMethod()
        {
            SaveFileDialog savefiledialog = new SaveFileDialog();
            savefiledialog.Filter = "Text Files (*.txt)|*.txt|Rich Text Format (*.rtf)|*.rtf|MSWord Files (*.docx)|*.docx|PHP (*.php)|*.php";
            DialogResult result = savefiledialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetExtension(savefiledialog.FileName) == ".txt")
                    mainrichTextBox.SaveFile(savefiledialog.FileName, RichTextBoxStreamType.PlainText);


                if (Path.GetExtension(savefiledialog.FileName) == ".php")
                    mainrichTextBox.SaveFile(savefiledialog.FileName, RichTextBoxStreamType.PlainText);


                if (Path.GetExtension(savefiledialog.FileName) == ".rtf")
                    mainrichTextBox.SaveFile(savefiledialog.FileName, RichTextBoxStreamType.RichText);


                this.Text = Path.GetFileName(savefiledialog.FileName) + " -Notepad with Hassan Malik";

                isFileAlreadySave = true;
                isFileDirty = false;
                currentOpenFileName = savefiledialog.FileName;

            }
        }




       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savefilemanu();
        }

        private void savefilemanu()
        {
            if (isFileAlreadySave)
            {
               

                if (Path.GetExtension(currentOpenFileName) == ".txt")
                    mainrichTextBox.SaveFile(currentOpenFileName, RichTextBoxStreamType.PlainText);


                if (Path.GetExtension(currentOpenFileName) == ".php")
                    mainrichTextBox.SaveFile(currentOpenFileName, RichTextBoxStreamType.PlainText);


                if (Path.GetExtension(currentOpenFileName) == ".rtf")
                    mainrichTextBox.SaveFile(currentOpenFileName, RichTextBoxStreamType.RichText);
               
                isFileDirty = false;
            }
            else
            {

                if (isFileDirty)
                {
                   
                    SaveAsFileKaMethod();

                }

                else
                {

                    clearScreen();


                }

            }
        }



        
        private void clearScreen()
        {
            mainrichTextBox.Clear(); //phly clear kry dr nichy wala txt ko string m araha ha wo dikhay
            this.Text = "Untitled - Notepad with Hassan Malik";
            isFileDirty = false;
        }


       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            messagetoolStripStatusLabel.Text = " Normal Text File.. ";
             isFileAlreadySave = false;
             isFileDirty = false;
             currentOpenFileName = "";


             if (Control.IsKeyLocked(Keys.CapsLock))
             {
                 capstoolStripStatusLabel.Text = " Caps ON";
             }
             else
             {
                 capstoolStripStatusLabel.Text = " Caps OFF";
             }

        }





       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainrichTextBox_TextChanged(object sender, EventArgs e)
        {
            isFileDirty = true; 
            undoToolStripMenuItem.Enabled = true; 

            toolStripButton7.Enabled = true;
            
            undoToolStripMenuItem1.Enabled = true;
        }


      
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void undoKlyeMethod()
        {

            mainrichTextBox.Undo();
            redoToolStripMenuItem.Enabled = true;
            toolStripButton8.Enabled = true;
            toolStripButton7.Enabled = false;

            
            undoToolStripMenuItem1.Enabled = false;
            redoToolStripMenuItem1.Enabled = true;

            undoToolStripMenuItem.Enabled = false;
           
        }
       
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            redoKlyemethod();
        }

        private void redoKlyemethod()
        {
            mainrichTextBox.Redo();
            redoToolStripMenuItem.Enabled = false;
            toolStripButton8.Enabled = false;
            toolStripButton7.Enabled = true;

           
            undoToolStripMenuItem1.Enabled = true;
            redoToolStripMenuItem1.Enabled = false;

            undoToolStripMenuItem.Enabled = true;
        }

        
        private void label2_Click(object sender, EventArgs e)
        {
            
        }


       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void signOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }



       
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mainrichTextBox.SelectAll();
        }


       
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            mainrichTextBox.SelectedText = DateTime.Now.ToString();

        }

       

        private void boldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Bold);
        }

        private void italicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }
        private void FontKlyeMethod(FontStyle fontstyleVeriable)
        {

            mainrichTextBox.SelectionFont = new Font(mainrichTextBox.SelectionFont, fontstyleVeriable);
        }

        private void underlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void strikethroughToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Strikeout);
        }

        private void normatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Regular);
        }


       
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void formatFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fontKlyeMethod();
        }

        private void fontKlyeMethod()
        {
            fontdialog.ShowColor = true;
            fontdialog.ShowApply = true;

            fontdialog.Apply += new System.EventHandler(fontdialog_apply);

           

            DialogResult result = fontdialog.ShowDialog(); //ye dialogresult khudsy agr na likha jay to uper sy copy krlyn

            if (result == DialogResult.OK)
            {
                if (mainrichTextBox.SelectionLength > 0)
                {
                    mainrichTextBox.SelectionFont = fontdialog.Font;
                    mainrichTextBox.SelectionColor = fontdialog.Color;
                }
                else
                {
                }
            }
            else
            {


            }

        }

        private void fontdialog_apply(object sender, EventArgs e) {

            if (mainrichTextBox.SelectionLength > 0)
            {
                mainrichTextBox.SelectionFont = fontdialog.Font;
                mainrichTextBox.SelectionColor = fontdialog.Color;
            }
        
        }









     
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeTextColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colordialog = new ColorDialog();
            DialogResult result = colordialog.ShowDialog();

            if (result == DialogResult.OK)
            {

                if (mainrichTextBox.SelectionLength > 0)
                {

                    mainrichTextBox.SelectionColor = colordialog.Color;
                
                }
            
            }

        }

        private void newtoolStripButton_Click(object sender, EventArgs e)
        {
            newFileMaMethod();
          //  messagetoolStripStatusLabel.Text = "New Click.. ";
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenKlyeMethod();
            //messagetoolStripStatusLabel.Text = "Open Click.. ";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            savefilemanu();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            SaveAsFileKaMethod();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            redoKlyemethod();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {

            FontKlyeMethod(FontStyle.Bold);
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Strikeout);
        }

        private void toolStripButton12_Click_1(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Strikeout);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            fontKlyeMethod();
        }

        private void mainrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                capstoolStripStatusLabel.Text = " Caps ON";
            }
            else
            {
                capstoolStripStatusLabel.Text = " Caps OFF";
            }

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Refresh();


        }

        private void boldToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            FontKlyeMethod(FontStyle.Bold);
        }

        private void italicToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Italic);
        }

        private void underlineToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Underline);
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontKlyeMethod(FontStyle.Regular);
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            undoKlyeMethod();
        }

        private void redoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            redoKlyemethod();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://allice9554.000webhostapp.com/");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            {


                Clipboard.SetText(mainrichTextBox.SelectedText);
                mainrichTextBox.SelectedText = "";

            }
            //if(mainrichTextBox.SelectionLength >0)
           // mainrichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            mainrichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                mainrichTextBox.SelectedText = Clipboard.GetText();
            }
           // mainrichTextBox.Paste();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            {


                Clipboard.SetText(mainrichTextBox.SelectedText);
                mainrichTextBox.SelectedText = "";

            }
            //mainrichTextBox.Cut();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            mainrichTextBox.Copy();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                mainrichTextBox.SelectedText = Clipboard.GetText();
            }
           // mainrichTextBox.Paste();
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            {


                Clipboard.SetText(mainrichTextBox.SelectedText);
                mainrichTextBox.SelectedText = "";

            }
            //mainrichTextBox.Cut();
        }

        private void toolStripButton15_Click(object sender, EventArgs e)
        {
            if (mainrichTextBox.SelectionLength > 0)
            mainrichTextBox.Copy();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                mainrichTextBox.SelectedText = Clipboard.GetText();
            }
            //mainrichTextBox.Paste();
        }

        private void speachToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
          
        }

        private void speechToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void messagetoolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void calculatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }
    }
}
