using Global;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace XCoreNET
{
    public partial class minecraftVersionSelector : Form
    {
        bool? statusFilter = null;

        private void setTranslate()
        {
            this.Text = gb.lang.FORM_TITLE_VERSION_SELECTOR;
            this.Font = new Font(gb.lang.FONT_FAMILY_CHILD, gb.lang.FONT_SIZE_CHILD);

            groupBox1.Text = gb.lang.GROUP_STATUS_FILTER;
            groupBox2.Text = gb.lang.GROUP_VERSION_FILTER;

            radAll.Text = gb.lang.RAD_STATUS_ALL;
            radInstalled.Text = gb.lang.RAD_STATUS_INSTALL;
            radNoInstalled.Text = gb.lang.RAD_STATUS_NON_INSTALL;

            chkRelease.Text = gb.lang.CHK_VERSION_RELEASE;
            chkSnapshot.Text = gb.lang.CHK_VERSION_SNAPSHOT;
            chkLoader.Text = gb.lang.CHK_VERSION_LOADER;
        }

        public minecraftVersionSelector()
        {
            InitializeComponent();
            setTranslate();
        }

        private void setDataView(bool? showInstalled)
        {
            DataTable DataTable = new DataTable();
            DataTable.Columns.Add(gb.lang.GRID_VERSION);
            DataTable.Columns.Add(gb.lang.GRID_TYPE);
            DataTable.Columns.Add(gb.lang.GRID_DATE);
            DataTable.Columns.Add(gb.lang.GRID_STATUS);

            foreach (var vlm in gb.versionListModels)
            {
                if (vlm.isInstalled == showInstalled || showInstalled == null)
                {
                    if (vlm.type == "release" && chkRelease.Checked || vlm.type == "snapshot" && chkSnapshot.Checked || vlm.type == "loader" && chkLoader.Checked)
                        DataTable.Rows.Add(new string[] {
                            vlm.version,
                            vlm.type,
                            vlm.datetime.ToString(gb.lang.GRID_DATE_FORMAT),
                            (vlm.isInstalled)?gb.lang.GRID_INSTALLED:gb.lang.GRID_NON_INSTALLED
                        });
                }
            }

            dataGridView1.DataSource = DataTable;
            dataGridView1.Refresh();
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);

            dataGridView1.ClearSelection();

            int selectIndex = 0;
            string selectValue = null;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(gb.lastVersionID))
                {
                    selectIndex = row.Index;
                    selectValue = row.Cells[0].Value.ToString();
                }
            }

            // 防止結果空集合但仍被設定選擇索引
            if (selectValue != null)
            {
                dataGridView1.Rows[selectIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[selectIndex].Cells[0];
            }
        }

        private void minecraftVersionSelector_Load(object sender, EventArgs e)
        {
            if (gb.versionListModels.Count == 0)
            {
                this.Close();
                return;
            }

            chkRelease.Checked = gb.verOptRelease;
            chkSnapshot.Checked = gb.verOptSnapshot;
            chkLoader.Checked = gb.verOptLoader;

            switch (gb.verStatusFilter)
            {
                case true:
                    radInstalled.Checked = true;
                    radInstalled_Click(sender, e);
                    break;
                case false:
                    radNoInstalled.Checked = true;
                    radNoInstalled_Click(sender, e);
                    break;
                default:
                    radAll.Checked = true;
                    radAll_Click(sender, e);
                    break;
            }

            setDataView(statusFilter);

            dataGridView1.Columns[0].Width = 110;
            dataGridView1.Columns[1].Width = 65;
            dataGridView1.Columns[2].Width = 125;
            dataGridView1.Columns[3].Width = 90;

            dataGridView1.Columns[2].ToolTipText = gb.lang.TOOLTIP_GRID_DATE_INTRO;

            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);

            int width = 0;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                width += col.Width;
            }
            width += 76 + panelMain.Width;

            this.MaximumSize = new Size(width, 350);
            this.MinimumSize = new Size(width, 350);
            this.Width = width;
        }

        private void minecraftVersionSelector_Resize(object sender, EventArgs e)
        {
            Console.WriteLine(this.Width);
        }

        private void radAll_Click(object sender, EventArgs e)
        {
            statusFilter = null;
            setDataView(null);

            gb.verStatusFilter = statusFilter;
            gb.savingSession(false);
        }

        private void radInstalled_Click(object sender, EventArgs e)
        {
            statusFilter = true;
            setDataView(true);

            gb.verStatusFilter = statusFilter;
            gb.savingSession(false);
        }

        private void radNoInstalled_Click(object sender, EventArgs e)
        {
            statusFilter = false;
            setDataView(false);

            gb.verStatusFilter = statusFilter;
            gb.savingSession(false);
        }

        private void chkRelease_Click(object sender, EventArgs e)
        {
            gb.verOptRelease = chkRelease.Checked;
            gb.savingSession(false);

            setDataView(statusFilter);
        }

        private void chkSnapshot_Click(object sender, EventArgs e)
        {
            gb.verOptSnapshot = chkSnapshot.Checked;
            gb.savingSession(false);

            setDataView(statusFilter);
        }

        private void chkLoader_Click(object sender, EventArgs e)
        {
            gb.verOptLoader = chkLoader.Checked;
            gb.savingSession(false);

            setDataView(statusFilter);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                gb.lastVersionID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
