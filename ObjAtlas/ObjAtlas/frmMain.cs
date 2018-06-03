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
            if (atlasGroup != null)
            {
                atlasGroup.Solve();
                var i = atlasGroup.RenderToImage();
                i.Save("d:\\output.png");
            }
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
    }
}
