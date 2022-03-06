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

namespace MCCMapPacker.Forms
{
    public partial class ValidationForm : Form
    {
        private ConfigData config;

        private StockMapHashes hashes;

        public MainForm main;

        CancellationTokenSource tokensource;
        CancellationToken ct;

        bool bCloseOnCancel;
        bool bValidationInProgress;

        Control VList;
        Control VProg;

        public ValidationForm()
        {
            InitializeComponent();
            VList = HashList;
            VProg = ValidationProgress;
        }

        private void ValidationForm_Load(object sender, EventArgs e)
        {
            config = Config.LoadConfig();

            hashes = JsonConvert.DeserializeObject<StockMapHashes>(File.ReadAllText("StockMaps.Json"));

            tokensource = new CancellationTokenSource();
            ct = tokensource.Token;

            ValidationProgress.Maximum = hashes.CEMaps.Count + hashes.H2AMaps.Count + hashes.H2CMaps.Count + hashes.H3Maps.Count + hashes.H4Maps.Count + hashes.ODSTMaps.Count + hashes.ReachMaps.Count;
        }
        //this function is uggo but i cba to fix it... it's 2am.
        public async Task ValidateMaps()
        {
            if (ReachCB.Checked)
            {
                foreach (MapData map in hashes.ReachMaps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\haloreach\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (H1CB.Checked)
            {
                foreach (MapData map in hashes.CEMaps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\halo1\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (H2CCB.Checked)
            {
                foreach (MapData map in hashes.H2CMaps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\halo2\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (H2ACB.Checked)
            {
                foreach (MapData map in hashes.H2AMaps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\groundhog\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (Halo3CB.Checked)
            {
                foreach (MapData map in hashes.H3Maps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\halo3\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (ODSTCB.Checked)
            {
                foreach (MapData map in hashes.ODSTMaps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\halo3odst\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }

            if (H4CB.Checked)
            {
                foreach (MapData map in hashes.H4Maps)
                {
                    string hash = await CalculateMD5(config.GamePath + @"\halo4\maps\" + map.MapFileName);
                    if (hash == map.MapHash)
                    {
                        UpdateList(map.MapNameUI + " - Passed");
                    }
                    else
                    {
                        UpdateList(map.MapNameUI + " - Failed");
                    }
                }
            }
        }

        private async void ValidateButton_Click(object sender, EventArgs e)
        {
            if(bValidationInProgress)
            {
                return;
            }
            bValidationInProgress = true;
            ClearList();
            //would be nice to be able to pause / cancel this while its running. but tasks make my head spin...
            try
            {
                await ValidateMaps();
                
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine($"{nameof(OperationCanceledException)} thrown with message: {ex.Message}");
            }
            finally
            {
                bValidationInProgress = false;
                tokensource.Dispose();
                SetCheckboxesEnabled();
                if(bCloseOnCancel)
                {
                    this.Close();
                    main.Show();
                }
                
            }
        }

        private async Task<string> CalculateMD5(string filename)
        {
            return await Task.Run(() =>
            {
                if (ct.IsCancellationRequested)
                {
                    // Clean up here, then...
                    ct.ThrowIfCancellationRequested();
                }


                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(filename))
                    {
                        var hash = md5.ComputeHash(stream);
                        return BitConverter.ToString(hash).Replace("-", string.Empty);
                    }
                }
            }, tokensource.Token);

            
        }
        private void SetCheckboxesEnabled()
        {
            VList.BeginInvoke((MethodInvoker)delegate ()
            {
                H1CB.Enabled = true;
                H2ACB.Enabled = true;
                ReachCB.Enabled = true;
                H2CCB.Enabled = true;
                Halo3CB.Enabled = true;
                ODSTCB.Enabled = true;
                H4CB.Enabled = true;

            });
        }
        private void ClearList()
        {
            VList.BeginInvoke((MethodInvoker)delegate ()
            {
                HashList.Items.Clear();
                //piggybacking ftw
                H1CB.Enabled = false;
                H2ACB.Enabled = false;
                ReachCB.Enabled = false;
                H2CCB.Enabled = false;
                Halo3CB.Enabled = false;
                ODSTCB.Enabled = false;
                H4CB.Enabled = false;

            });
            VProg.BeginInvoke((MethodInvoker)delegate ()
            {
                ValidationProgress.Value = 0;
                ValidationProgress.Maximum = Getvalidationcount();
            });
        }

        private void UpdateList(string passInfo)
        {
            VList.BeginInvoke((MethodInvoker)delegate ()
            {
                HashList.Items.Add(passInfo);
                HashList.SelectedIndex = HashList.Items.Count - 1;
                HashList.SelectedIndex = -1;
                
            });
            VProg.BeginInvoke((MethodInvoker)delegate ()
            {
                ValidationProgress.Value++;
            });
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if(bValidationInProgress)
            {
                tokensource.Cancel();
                bCloseOnCancel = true;
            }
            else
            {
                this.Close();
                main.Show();
            }
            

        }

        private int Getvalidationcount()
        {
            int count = 0;

            if(ReachCB.Checked)
            {
                count = count + hashes.ReachMaps.Count;
            }

            if (H1CB.Checked)
            {
                count = count + hashes.CEMaps.Count;
            }

            if (H2ACB.Checked)
            {
                count = count + hashes.H2AMaps.Count;
            }

            if (H2CCB.Checked)
            {
                count = count + hashes.H2CMaps.Count;
            }

            if (Halo3CB.Checked)
            {
                count = count + hashes.H3Maps.Count;
            }

            if (ODSTCB.Checked)
            {
                count = count + hashes.ODSTMaps.Count;
            }

            if (H4CB.Checked)
            {
                count = count + hashes.H4Maps.Count;
            }

            return count;
        }
        #region Drag
        private void ValidationForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draggable.Move(this);
            }
        }

        private void HashList_MouseMove(object sender, MouseEventArgs e)
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
    }

}
