using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MCCMapPacker.Window;
using MCCMapPacker.Objects;
using Newtonsoft.Json;
using MCCMapPacker.Forms;
using Ionic.Zip;
using System.Net;

namespace MCCMapPacker
{
    public partial class MainForm : Form
    {
        Control control;

        PathsDialogue paths;

        public MainForm()
        {
            InitializeComponent();
            //jack create button for invocation >:D
            control = CreateBtn;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Config.CheckConfig())
            {
                LoadBtn.Enabled = true;
                CreateBtn.Enabled = true;
                ValidateBtn.Enabled = true;
                RestoreMapsBtn.Enabled = true;
                CheckVersion();
            }
            else
            {
                MessageBox.Show("Looks like this is your first time running this(or your config is invalid), please fill out the next window to ensure all files are located.");
                ShowPathsDialog();
                paths.ConfigUpdated += OnConfigUpdated;
            }
        }

        private void OnConfigUpdated(object sender, EventArgs e)
        {
            paths.ConfigUpdated -= OnConfigUpdated;
            LoadBtn.Enabled = true;
            CreateBtn.Enabled = true;
            ValidateBtn.Enabled = true;
            RestoreMapsBtn.Enabled = true;
            CheckVersion();
        }

        #region Drag
        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }
        #endregion

        private void CheckVersion()
        {
            VersionCheck version = new VersionCheck();
            
            if(!version.CheckVersion())
            {
                DialogResult dialogResult = MessageBox.Show("The map hashes are out of date, would you like to check for updates?", "Check for updates" , MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    version.GetUpdate();
                }
                else
                {
                    MessageBox.Show("The tool will not function properly without up to date data. Please ");
                    return;
                }
            }

        }

        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadPack_Click(object sender, EventArgs e)
        {
            SetControlsState(false);
            Loader loader = new Loader();
            loader.LoadComplete += PackLoaded;
            loader.LoadCancelled += LoadCancelled;
            loader.LoadZip();
        }

        private void LoadCancelled(object sender, EventArgs e)
        {
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                SetControlsState(true);
            });
        }

        private void SetControlsState(bool bEnabled)
        {
            CreateBtn.Enabled = bEnabled;
            LoadBtn.Enabled = bEnabled;
            ValidateBtn.Enabled = bEnabled;
            SettingsBtn.Enabled = bEnabled;
            RestoreMapsBtn.Enabled = bEnabled;
            ExitBtn.Enabled = bEnabled;
        }

        private void PackLoaded(object sender, EventArgs e)
        {
            MessageBox.Show("Pack Loaded");
            control.BeginInvoke((MethodInvoker)delegate ()
            {
                SetControlsState(true);
            });

        }

        private void Validate_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This may take some time. A dialog will show once all maps are validated. Are you sure you want to continue?", "Validate Maps", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ValidationForm vForm = new ValidationForm();
                vForm.main = this;
                vForm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void Create_Click(object sender, EventArgs e)
        {
            CreatePackForm createForm = new CreatePackForm();
            createForm.mainForm = this;
            this.Hide();
            createForm.Show();
        }

        private void Settings_Click(object sender, EventArgs e)
        {
            ShowPathsDialog();
        }

        private void ShowPathsDialog()
        {
            paths = new PathsDialogue();
            this.Hide();
            paths.Show();
            paths.mainForm = this;
        }
        
        private async void RestoreMapsBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This will take some time as ALL maps will be restored providing backups are available. If you do not have backups then you will need to validate your files through the store you bought the game from.", "Restore Maps", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                SetControlsState(false);
                Restore res = new Restore();
                await res.RestoreMaps();
                SetControlsState(true);
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
    }
}
