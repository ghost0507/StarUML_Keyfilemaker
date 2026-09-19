using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StarUML_Keyfilemaker
{
    public partial class FormMain : Form
    {

        private static readonly string HostsFileEntry = "dev.staruml-io-astro.pages.dev";

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            Text = Application.ProductName;
            txtName.Text = Environment.UserName;

            Dictionary<string, string> licenseVersions = LicenseVersion.All.ToDictionary(licenseVersion => licenseVersion.Code, licenseVersion => licenseVersion.Description);

            cbLicenseVersion.Items.Clear();
            cbLicenseVersion.DataSource = new BindingSource(licenseVersions, null);
            cbLicenseVersion.DisplayMember = "Value";
            cbLicenseVersion.ValueMember = "Key";
            cbLicenseVersion.DisplayMember = "Text";
            cbLicenseVersion.SelectedIndex = 0;

            Dictionary<string, string> licenseTypes = LicenseType.All.ToDictionary(licenseType => licenseType.Code, licenseType => licenseType.Description); ////Located in 'info.licenseType' variable of the '/src/dialogs/about-dialog.js' file from '/resources/app.asar'

            cbLicenseType.Items.Clear();
            cbLicenseType.DataSource = new BindingSource(licenseTypes, null);
            cbLicenseType.DisplayMember = "Value";
            cbLicenseType.ValueMember = "Key";
            cbLicenseType.DisplayMember = "Text";
            cbLicenseType.SelectedIndex = 0;

            btnPatch.Enabled = !HostsFile.IsHostsFilePatched(HostsFileEntry);
        }


        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                LicenseType licenseType = LicenseType.GetByCode(((KeyValuePair<string, string>)cbLicenseType.SelectedItem).Key);

                LicenseVersion licenseVersion = LicenseVersion.GetByCode(((KeyValuePair<string, string>)cbLicenseVersion.SelectedItem).Key);

                License licenseInfo = Licensing.buildLicenseInfo(txtName.Text, licenseType, licenseVersion);

                saveLicenseFile(licenseInfo, licenseVersion);

            }
            else
            {
                MessageBox.Show("Cannot create license file!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveLicenseFile(License licenseInfo, LicenseVersion licenseVersion)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "StarUML Registration keyfile (*.key)|*.key";
            saveFileDialog.DefaultExt = "key";
            saveFileDialog.InitialDirectory = Licensing.LICENSE_PATH_FOLDER;
            saveFileDialog.FileName = licenseVersion.LicenseFilename;
            saveFileDialog.AddExtension = true;

            DialogResult dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                string licensePath = saveFileDialog.FileName;

                if (Licensing.writeLicenseFile(licenseInfo, licenseVersion, licensePath))
                {
                    MessageBox.Show("StarUML Registration keyfile saved" + licensePath);
                }
            }
        }

        private void btnPatch_Click(object sender, EventArgs e)
        {
            if (HostsFile.PatchHostsFile(HostsFileEntry))
            {
                if (HostsFile.IsHostsFilePatched(HostsFileEntry))
                {
                    btnPatch.Enabled = false;
                    MessageBox.Show("Hosts file has been patched successfully", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Cannot patch hosts file!", Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
