using ObjAtlas.Atlas;
using ObjAtlas.Extensions;
using ObjAtlas.WaveFront.Containers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjAtlas
{
    public partial class frmMain : Form
    {
        private AtlasContainer atlas = null;
        private GroupAtl atlasGroup = null;
        private GroupAtl atlasIgnoreGroup = null;
        private MaterialAtl atlasMaterial = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void mnuFileChooseObj_Click(object sender, EventArgs e)
        {
              //we got the wavefront file
            if (openObjDialog.ShowDialog() == DialogResult.OK)
            {
                //create a new atlas container
                atlas = new AtlasContainer(openObjDialog.FileName);
                
                //parse UV information
                //CreateAtlasData();
            }
        }

        private void tabGeneral_Click(object sender, EventArgs e)
        {

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RedrawMaterialPanel();
        }

        private void treeMaterialAtlas_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag.GetType() == typeof(MaterialAtl))
            {
                //set the atlas group to be the parent of this object
                atlasGroup = (GroupAtl)e.Node.Parent.Tag;
                //store our material
                atlasMaterial = (MaterialAtl)e.Node.Tag;

                //hide atlas buttons
                ToggleAtlasButtons(false);
                ToggleMaterialButtons(true);

                //update screen with material properties
                MaterialAtl at = (MaterialAtl)e.Node.Tag;
                if (at.textureImage == null)
                {
                    picMaterialPreview.Image = null;
                } else
                {
                    //picTabMatPreview.Image = at.textureImage;
                    at.OutputPreviewImage(picMaterialPreview);
                    at.OutputToListBox(lstMaterialProperties);
                }
                trackScaleU.Value = (int)at.targetTextureScale.X;
                trackScaleV.Value = (int)at.targetTextureScale.Y;
            } else if (e.Node.Tag.GetType() == typeof(GroupAtl))
            {
                atlasMaterial = null;

                //show atlas buttons
                ToggleAtlasButtons(true);
                ToggleMaterialButtons(false);
                //get the group and store itlocally
                atlasGroup = (GroupAtl)e.Node.Tag;
                txtAtlasName.Text = atlasGroup.name;
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void RedrawMaterialPanel()
        {
            if (atlas == null)
                return;

            //hide buttons
            ToggleAtlasButtons(false);
            ToggleMaterialButtons(false);

            if (TabControl1.SelectedIndex == 1)
            {
                
                //populate groups that are textureles
                lstMaterialTextureless.Items.Clear();
                foreach (var o in atlas.GetTexturelessMaterials())
                {
                    lstMaterialTextureless.Items.Add(o.name);
                }
            
                //populate groups that are ignored
                lstMaterialIgnored.Items.Clear();
                foreach (var o in atlas.GetIgnoredMaterials())
                {
                    lstMaterialIgnored.Items.Add(o);
                }


                //populate groups that do indeed have textures
                treeMaterialAtlas.Nodes.Clear();
                foreach (var o in atlas.GetAtlasMaterials())
                {
                    TreeNode tn = new TreeNode();
                    tn.Tag = o;
                    tn.Text = o.name;
                    foreach (var cm in o.GetMaterials())
                    {
                        TreeNode cn = new TreeNode();
                        cn.Text = cm.ToString();
                        cn.Tag = cm;
                        tn.Nodes.Add(cn);
                    }
                    treeMaterialAtlas.Nodes.Add(tn);
                }
            }
        }
        private void ToggleAtlasButtons(bool pVisibility)
        {
            btnAddNewAtlas.Visible = pVisibility;
            btnDeleteAtlas.Visible = pVisibility;
            txtAtlasName.Visible = pVisibility;
            btnAtlasRename.Visible = pVisibility;
        }
         private void ToggleMaterialButtons(bool pVisibility)
        {
            btnMoveMaterialDown.Visible = pVisibility;
            btnMoveMaterialUp.Visible = pVisibility;
            btnMoveToIgnored.Visible = pVisibility;
            btnMoveToAtlas.Visible = pVisibility;
            lstMaterialProperties.Visible = pVisibility;
            picMaterialPreview.Visible = pVisibility;
            //cboScaleU.Visible = pVisibility;
            //cboScaleV.Visible = pVisibility;


        }
        private void btnAtlasRename_Click(object sender, EventArgs e)
        {
            if (atlasGroup != null)
            {
                bool result = atlas.ChangeAtlasGroupName(txtAtlasName.Text, atlasGroup);
                if (!result)
                    MessageBox.Show("Invalid group name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result)
                    RedrawMaterialPanel();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnMoveToIgnored_Click(object sender, EventArgs e)
        {
            if (atlasMaterial != null)
            {
                atlas.ChangeAtlasMaterialToIgnored(atlasGroup, atlasMaterial);
                RedrawMaterialPanel();
            }
            atlasMaterial = null;
        }
        private void btnMoveToAtlas_Click(object sender, EventArgs e)
        {
            if (atlasIgnoreGroup != null)
            {
                atlas.ChangeAtlasMaterialFromIgnored(atlasIgnoreGroup, atlasGroup);
                RedrawMaterialPanel();
            }

            atlasIgnoreGroup = null;
        }
        private void lstMaterialIgnored_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMaterialIgnored.SelectedItem != null)
            {
                atlasIgnoreGroup = (GroupAtl)lstMaterialIgnored.SelectedItem;

                MaterialAtl ma = atlasIgnoreGroup.GetMaterials().First();
                ma.OutputPreviewImage(picMaterialPreview);
                ma.OutputToListBox(lstMaterialProperties);
                ToggleMaterialButtons(true);
            }
        }

        private void btnDeleteAtlas_Click(object sender, EventArgs e)
        {
            if (atlasGroup != null)
            {
                if (!atlas.DeleteAtlasGroup(atlasGroup))
                {
                     MessageBox.Show("Error deleting atlas group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                RedrawMaterialPanel();
            }
        }

        private void btnAddNewAtlas_Click(object sender, EventArgs e)
        {
            atlas.AddAtlasGroup("NewAtlasGroup" + DateTime.Now.Millisecond.ToString());
            RedrawMaterialPanel();
        }

        private void btnMoveMaterialUp_Click(object sender, EventArgs e)
        {
            if (atlasGroup != null && atlasMaterial != null)
            {
                int sourceIndex = atlas.GetAtlasGroupIndex(atlasGroup);
                int targetIndex = sourceIndex - 1;

                if (!atlas.SetMaterialToGroupByIndex(sourceIndex, targetIndex, atlasMaterial))
                     MessageBox.Show("Error moving material into new atlas group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RedrawMaterialPanel();
            }
        }

        private void btnMoveMaterialDown_Click(object sender, EventArgs e)
        {
            if (atlasGroup != null && atlasMaterial != null)
            {
                int sourceIndex = atlas.GetAtlasGroupIndex(atlasGroup);
                int targetIndex = sourceIndex + 1;

                if (!atlas.SetMaterialToGroupByIndex(sourceIndex, targetIndex, atlasMaterial))
                     MessageBox.Show("Error moving material into new atlas group", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RedrawMaterialPanel();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (atlasGroup != null)
            {
                atlasGroup.Solve();
                var i = atlasGroup.RenderToImage();
                i.Save("d:\\output.png");
            }*/

        }

        private void trackScaleU_Scroll(object sender, EventArgs e)
        {
            TrackBar s = (TrackBar)sender;
            s.Value = (s.Value / s.SmallChange) * s.SmallChange;
            lblUVScaleUPercentage.Text = s.Value.ToString() + "%";
            if (atlasMaterial != null)
                atlasMaterial.targetTextureScale = new PointF(trackScaleU.Value, trackScaleV.Value);
        }

        private void trackScaleV_Scroll(object sender, EventArgs e)
        {
             TrackBar s = (TrackBar)sender;
             s.Value = (s.Value / s.SmallChange) * s.SmallChange;
             lblUVScaleVPercentage.Text = s.Value.ToString() + "%";
             if (atlasMaterial != null)
                    atlasMaterial.targetTextureScale = new PointF(trackScaleU.Value, trackScaleV.Value);

        }

        private void trackScaleV_ValueChanged(object sender, EventArgs e)
        {
             TrackBar s = (TrackBar)sender;
             lblUVScaleVPercentage.Text = s.Value.ToString() + "%";
        }

        private void trackScaleU_ValueChanged(object sender, EventArgs e)
        {
             TrackBar s = (TrackBar)sender;
             lblUVScaleUPercentage.Text = s.Value.ToString() + "%";
        }

        private void trackCompressionRatio_Scroll(object sender, EventArgs e)
        {
             TrackBar s = (TrackBar)sender;
             lblCompressionRatioPercentage.Text = s.Value.ToString() + "%";
        }

        private void btnSelectDestinationFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                //create a new atlas container
                txtOutputFolder.Text = folderBrowserDialog.SelectedPath + "\\";
            }
        }

        private void txtOutputFilename_Leave(object sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;
            s.Text = s.Text.RemoveMultipleSpaces().RemoveSpecialCharacters().RemoveSpaces();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            //get paths
            string outputDir = txtOutputFolder.Text;
            string outputName = txtOutputFilename.Text;

            //store our options from the form field
            bool flipHorizontally = chkFlipOutputHorizontally.Checked;
            bool flipVertically = chkFlipOutputVertically.Checked;
            bool copyNonAtlas = chkCopyNonAtlas.Checked;
            bool compressOutput = chkCompress.Checked;
            long compressRatio = trackCompressionRatio.Value;

            //go through some basic error checks
            if (atlas == null)
            {
                MessageBox.Show("Please create an atlas before attempting to generate.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (atlas.GetRootFolder().Equals(outputDir, StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Please choose a destination folder that does not contain the original files.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(outputName) || string.IsNullOrWhiteSpace(outputName))
            {
                MessageBox.Show("Please enter in a valid filename.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (outputName.ToLowerInvariant().Contains(".obj") || (outputName.ToLowerInvariant().Contains(".mat")))
            {
                MessageBox.Show("Please do not include the file extension within the filename.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //start outputting data
            lstOutputSummary.Items.Clear();
            lstOutputSummary.Items.Add(string.Format("Files will be outputted with names:"));
            lstOutputSummary.Items.Add(string.Format("   {0}.obj", outputName));
            lstOutputSummary.Items.Add(string.Format("   {0}.mat", outputName));
            lstOutputSummary.Items.Add(string.Format("To the following directory"));
            lstOutputSummary.Items.Add(string.Format("   {0}", outputDir));
            lstOutputSummary.Items.Add("");

            //output status items to screen
            lstOutputSummary.Items.Add(string.Format("Setting atlas options:"));
            lstOutputSummary.Items.Add(string.Format("   Flip vertically ({0})", flipVertically.ToString()));
            lstOutputSummary.Items.Add(string.Format("   Flip horizontally ({0})", flipHorizontally.ToString()));
            lstOutputSummary.Items.Add(string.Format("   Copy non-atlas textures ({0})", copyNonAtlas.ToString()));
            lstOutputSummary.Items.Add(string.Format("   Compress atlas textures ({0})", compressOutput.ToString()));
            if (compressOutput)
                 lstOutputSummary.Items.Add(string.Format("   Compression ratio ({0}%)", compressRatio.ToString()));
           
            
            //configure the renderer
            atlas.renderOption_flipOutputVertically = flipVertically;
            atlas.renderOption_flipOutputHorizontally = flipHorizontally;
            atlas.renderOption_copyNonAtlasImages = copyNonAtlas;
            atlas.renderOption_compressImages = compressOutput;
            atlas.renderOption_compressImagesRatio = compressRatio;

            //generate
            atlas.Generate(outputName, outputDir);
        }

        private void chkFlipOutputVertically_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void exportWithoutAtlasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //we got the wavefront file
            if (saveObjDialog.ShowDialog() == DialogResult.OK)
            {
               
            }
        }

        private void mnuFileOpenConfig_Click(object sender, EventArgs e)
        {

        }

        private void mnuFileSaveConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
