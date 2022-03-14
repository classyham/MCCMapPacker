using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCCMapPacker.Objects;
using MCCMapPacker.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using MCCMapPacker.Window;
using static MCCMapPacker.Objects.Validation;

namespace MCCMapPacker.Forms
{
    public partial class ValidationForm : Form
    {
        GamesToValidate games;

        public MainForm main;

        Validation validation;

        bool bValidationInProgress;
        bool bCloseOnCancel;

        Control control;

        public ValidationForm()
        {
            InitializeComponent();
            control = HashListView;
            
            validation = new Validation();
            validation.MapValidated += UpdateList;
            validation.OnValidationCancelled += OnValidationCancelled;
            validation.OnValidationComplete += OnValidationComplete;
        }

        private void OnValidationComplete(int successcount)
        {
            int amount = validation.GetNumFilesToValidate(games);

            if(successcount == amount)
            {
                MessageBox.Show("All maps successfully validated.");
                return;
            }
            MessageBox.Show(successcount + " maps passed validation. " + (amount-successcount) + " maps failed to validate (Probably modded maps)");
        }

        private void ValidationForm_Load(object sender, EventArgs e)
        {
            SetupCheckboxes();
        }

        public void SetupCheckboxes()
        {
            SetupTags();

            foreach (Control c in this.Controls)
            {
                if (c is CheckBox)
                {
                    ((CheckBox)c).CheckedChanged += EnumCheckedChanged;
                }
            }
        }

        //Don't like this, but it is what it is...
        void SetupTags()
        {
            H1CB.Tag = GamesToValidate.HaloCE;
            H2CCB.Tag = GamesToValidate.Halo2C;
            H2ACB.Tag = GamesToValidate.Halo2A;
            Halo3CB.Tag = GamesToValidate.Halo3;
            ODSTCB.Tag = GamesToValidate.HaloODST;
            ReachCB.Tag = GamesToValidate.HaloReach;
            H4CB.Tag = GamesToValidate.Halo4;
        }

        void EnumCheckedChanged(object sender, EventArgs e)
        {
            var checkbox = (CheckBox)sender;

            var flag = (GamesToValidate)checkbox.Tag;

            if (checkbox.Checked)
            {
                games |= flag;
            }
            else
            {
                games ^= flag;
            }
        }
   
        private async void ValidateButton_Click(object sender, EventArgs e)
        {
            //clear the list
            HashListView.Items.Clear();
            //set progress bar maximum
            ValidationProgress.Maximum = validation.GetNumFilesToValidate(games);
            //disable checkboxes so can't be changed mid validation
            SetCheckboxState(false);
            //validation block
            bValidationInProgress = true;
            await validation.ValidateMaps(games);
            bValidationInProgress = false;
            //set checkboxes enabled again as validation is complete
            SetCheckboxState(true);
        }

        private void OnValidationCancelled()
        {
           if(bCloseOnCancel)
            {
                this.Close();
                main.Show();
            }
        }

        private void SetCheckboxState(bool bState)
        {
                H1CB.Enabled = bState;
                H2ACB.Enabled = bState;
                ReachCB.Enabled = bState;
                H2CCB.Enabled = bState;
                Halo3CB.Enabled = bState;
                ODSTCB.Enabled = bState;
                H4CB.Enabled = bState;
        }

        private void UpdateList(string Mapname, bool passed)
        {
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                ListViewItem lv = new ListViewItem();

                if (passed)
                {
                    lv.Text = Mapname + " - Passed";
                    lv.ForeColor = Color.FromArgb(61, 165, 96);
                }
                else
                {
                    lv.Text = Mapname + " - Failed";
                    lv.ForeColor = Color.FromArgb(236, 65, 69);
                }
                HashListView.Items.Add(lv);
                HashListView.EnsureVisible(HashListView.Items.Count - 1);

                ValidationProgress.Value = HashListView.Items.Count;
            });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(bValidationInProgress)
            {
                validation.CancelValidation();
                bCloseOnCancel = true;
            }
            else
            {
                this.Close();
                main.Show();
            }
        }

        #region Drag
        private void ValidationForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }

        private void HashListView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }

        #endregion

        private void ValidationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.Show();
        }

        private void HashList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            ListBox lb = (ListBox)sender;
            g.DrawString(lb.Items[e.Index].ToString(), e.Font, new SolidBrush(Color.White), new PointF(e.Bounds.X, e.Bounds.Y));
        }

    }

}
