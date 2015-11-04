using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TRoschinsky.App.SPWood
{
    public partial class MainForm : Form
    {
        private SPWood spWood;
        private BackgroundWorker bgwConnect;
        private BackgroundWorker bgwGenerateCode;

        public MainForm()
        {
            InitializeComponent();
            bgwConnect = new BackgroundWorker();
            bgwConnect.DoWork += bgwConnect_DoWork;
            bgwConnect.RunWorkerCompleted += bgwConnect_RunWorkerCompleted;
            bgwGenerateCode = new BackgroundWorker();
            bgwGenerateCode.DoWork += bgwGenerateCode_DoWork;
            bgwGenerateCode.RunWorkerCompleted += bgwGenerateCode_RunWorkerCompleted;
        }

        #region BL Connect

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!bgwConnect.IsBusy)
                {
                    bgwConnect.RunWorkerAsync(txtBoxWebUrl.Text);
                    btnConnect.Enabled = false;
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void bgwConnect_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = new SPWood(new Uri(e.Argument.ToString()));
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void bgwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                spWood = e.Result as SPWood;
                if(spWood == null)
                {
                    Exception ex = e.Result as Exception;
                    if (ex != null)
                    {
                        throw ex;
                    }
                    else
                    {
                        throw new Exception("Unknown error.");
                    }
                }

                listViewEntities.Items.Clear();
                foreach (SPWoodEntity entity in spWood.SpwLists)
                {
                    ListViewItem item = new ListViewItem(entity.ListName);
                    item.Tag = entity;
                    item.ImageIndex = entity.ListType;
                    listViewEntities.Items.Add(item);
                }
                btnGetWood.Enabled = listViewEntities.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error connecting to web...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnGetWood.Enabled = listViewEntities.Enabled = false;
            }
            finally
            {
                btnConnect.Enabled = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Visible = false;
            }
        }

        #endregion

        #region Generate Code

        private void btnGetWood_Click(object sender, EventArgs e)
        {
            try
            {

                if (!bgwGenerateCode.IsBusy)
                {
                    btnConnect.Enabled = btnGetWood.Enabled = listViewEntities.Enabled = false;
                    toolStripProgressBar1.Visible = true;
                    toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

                    List<SPWoodEntity> tmpItems = new List<SPWoodEntity>();
                    foreach (ListViewItem item in listViewEntities.Items)
                    {
                        if (item.Selected)
                        {
                            tmpItems.Add(item.Tag as SPWoodEntity);
                        }
                    }

                    Tuple<List<SPWoodEntity>, bool> arguments = new Tuple<List<SPWoodEntity>, bool>(tmpItems, checkBoxIncludeHidden.Checked);
                    bgwGenerateCode.RunWorkerAsync(arguments);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewEntities_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!bgwGenerateCode.IsBusy)
            {
                btnConnect.Enabled = listViewEntities.Enabled = false;
                toolStripProgressBar1.Visible = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

                Tuple<ListViewItem, bool> arguments =
                    new Tuple<System.Windows.Forms.ListViewItem, bool>(listViewEntities.SelectedItems[0], checkBoxIncludeHidden.Checked);
                bgwGenerateCode.RunWorkerAsync(arguments);
            }
        }

        void bgwGenerateCode_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (spWood != null && spWood.IsConnected)
                {
                    Tuple<List<SPWoodEntity>, bool> argsMulti = e.Argument as Tuple<List<SPWoodEntity>, bool>;
                    if (argsMulti != null)
                    {
                        e.Result = spWood.GetCodeProxyClassForLists(argsMulti.Item1.ToArray(), argsMulti.Item2);
                        return;
                    }

                    Tuple<ListViewItem, bool> argsSingle = e.Argument as Tuple<ListViewItem, bool>;
                    if (argsSingle != null)
                    {
                        e.Result = spWood.GetCodeEnumForList(argsSingle.Item1.Tag as SPWoodEntity, argsSingle.Item2);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void bgwGenerateCode_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string code = e.Result as String;
                if (code == null)
                {
                    Exception ex = e.Result as Exception;
                    if (ex != null)
                    {
                        throw ex;
                    }
                    else
                    {
                        throw new Exception("Unknown error.");
                    }
                }
                richTextBoxCode.Text = code;
                richTextBoxCode.BackColor = SystemColors.Control;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error generating code...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBoxCode.BackColor = Color.MistyRose;
            }
            finally
            {
                btnConnect.Enabled = btnGetWood.Enabled = listViewEntities.Enabled = true;
                toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
                toolStripProgressBar1.Visible = false;
            }
        }

        #endregion

        #region Helper

        private void txtBoxWebUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnConnect_Click(null, null);
            }
        }

        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(richTextBoxCode.Text))
            {
                saveFileDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("First generate some code to save it in a file.", "Nothing to save...");
            }
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBoxCode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error saving code...");
            }
        }

        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/roschinsky/SPWood");
                linkLabelAbout.LinkVisited = true;
            }
            catch { }
        }

        #endregion

    }
}
