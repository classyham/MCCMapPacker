using MCCMapPacker.Objects;
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
using MCCMapPacker;
using Newtonsoft.Json;
using MCCMapPacker.Window;

namespace MCCMapPacker
{
    public partial class PathsDialogue : Form
    {
        public MainForm mainForm;

        ConfigData config;

        public PathsDialogue()
        {
            InitializeComponent();
        }

        #region Drag
        private void PathsDialogue_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }
        #endregion

        private void PathsDialogue_Load(object sender, EventArgs e)
        {
            config = Config.LoadConfig();

            if(File.Exists(@"C:\Program Files (x86)\Steam\steamapps\common\Halo The Master Chief Collection\mcclauncher.exe"))
            {
                GamePath.Text = @"C:\Program Files (x86)\Steam\steamapps\common\Halo The Master Chief Collection";
            }
        }
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    if (File.Exists(fbd.SelectedPath + @"\mcclauncher.exe"))
                    {
                        GamePath.Text = fbd.SelectedPath;
                    }
                    else
                    {
                        MessageBox.Show("Directory does not contain mcclauncher.exe");
                    }
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(GamePath.TextLength == 0)
            {
                MessageBox.Show("Game path is empty, without this the software will not work");
                return;
            }
            config.GamePath = GamePath.Text;

            File.WriteAllText(Config.configFile, JsonConvert.SerializeObject(config));

            mainForm.Show();
            this.Close();

        }

        private void PathsDialogue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (GamePath.TextLength == 0)
            {
                MessageBox.Show("Game path is empty, without this the software will not work");
            }
            mainForm.Show();
        }
    }
}
