using System;
using System.Drawing;
using System.Windows.Forms;

namespace MTHProject
{
    /// <summary>
    /// DataGridView 通用绘制帮助类
    /// </summary>
    public static class DataGridViewHelper
    {
        /// <summary>
        /// 让列标题不被选中高亮：把列标题的选中配色设成与普通配色相同
        /// </summary>
        public static void SetHeaderNoHighlight(DataGridView dgv)
        {
            if (dgv == null) return;

            DataGridViewCellStyle headerStyle = dgv.ColumnHeadersDefaultCellStyle;
            headerStyle.SelectionBackColor = headerStyle.BackColor;
            headerStyle.SelectionForeColor = headerStyle.ForeColor;
        }

        /// <summary>
        /// 在行头区域绘制行号，供 DataGridView 的 RowPostPaint 事件调用
        /// </summary>
        public static void DgvRowPostPaint(DataGridView dgv, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgv == null || e == null) return;
            if (e.RowIndex < 0 || e.RowIndex >= dgv.Rows.Count) return;
            if (dgv.Rows[e.RowIndex].IsNewRow) return;
            if (!dgv.RowHeadersVisible) return;

            Rectangle headerBounds = new Rectangle(
                e.RowBounds.Left,
                e.RowBounds.Top,
                dgv.RowHeadersWidth,
                e.RowBounds.Height);

            if (headerBounds.Width <= 0 || headerBounds.Height <= 0) return;

            DataGridViewRow row = dgv.Rows[e.RowIndex];
            DataGridViewCellStyle headerStyle = dgv.RowHeadersDefaultCellStyle;

            //选中行使用行头的选中前景色，避免行号与选中背景色混在一起看不清
            Color foreColor;
            if (row.Selected)
            {
                foreColor = headerStyle.SelectionForeColor.IsEmpty
                    ? SystemColors.HighlightText
                    : headerStyle.SelectionForeColor;
            }
            else
            {
                foreColor = headerStyle.ForeColor.IsEmpty
                    ? dgv.ForeColor
                    : headerStyle.ForeColor;
            }

            Font font = headerStyle.Font ?? e.InheritedRowStyle.Font ?? dgv.Font;

            TextRenderer.DrawText(
                e.Graphics,
                (e.RowIndex + 1).ToString(),
                font,
                headerBounds,
                foreColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
        }
    }
}
