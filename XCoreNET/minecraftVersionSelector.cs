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

        public minecraftVersionSelector()
        {
            InitializeComponent();
        }

        private void setDataView(bool? showInstalled)
        {
            DataTable DataTable = new DataTable();
            DataTable.Columns.Add("版本");
            DataTable.Columns.Add("類型");
            DataTable.Columns.Add("發行 / 安裝日期(?)");
            DataTable.Columns.Add("狀態");

            foreach (var vlm in gb.versionListModels)
            {
                if (vlm.isInstalled == showInstalled || showInstalled == null)
                {
                    if (vlm.type == "release" && chkRelease.Checked || vlm.type == "snapshot" && chkSnapshot.Checked || vlm.type == "loader" && chkLoader.Checked)
                        DataTable.Rows.Add(new string[] {
                            vlm.version,
                            vlm.type,
                            vlm.datetime.ToString("yyyy-MM-dd HH:mm:ss"),
                            (vlm.isInstalled)?"已安裝":"未安裝"
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
            dataGridView1.Columns[3].Width = 60;

            dataGridView1.Columns[2].ToolTipText = "原版程式載入器顯示發行日期；自行安裝之模組載入器則顯示安裝日期。";

            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Descending);

            int width = 0;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                width += col.Width;
            }
            this.Width = width + 76 + 124;
            this.MaximumSize = new Size(this.Width, 350);
            this.MinimumSize = new Size(this.Width, 350);
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
