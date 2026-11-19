using MTHHelper;
using MTHModels;
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
using thinger.DataConvertLib;

namespace MTHProject
{
    public partial class FrmRecipe : Form
    {
        public FrmRecipe(string devPath)
        {
            InitializeComponent();

            //列标题选中色=普通色，避免点击行时 CurrentCell 落在某列导致标题闪烁变色
            DataGridViewHelper.SetHeaderNoHighlight(this.dgv_Main);

            this.lbl_CurrentRecipe.Text = CommonMethods.Device.CurrentRecipe;
            this.txt_RecipeName.Text = CommonMethods.Device.CurrentRecipe;
            RefreshRecipe();
            this.devPath = devPath;
            //句柄创建后再刷新一次，此时 RefreshRecipe 里的行选中逻辑才会生效
            this.Shown += (s, e) =>
            {
                RefreshRecipe();
            };
        }
        private string devPath = string.Empty;
        private static readonly string basePath = @"D:\product\MTHProject\MTHProject\bin\Debug\Recipe";
        private List<RecipeInfo> recipeInfos = new List<RecipeInfo>();
        private void btn_Add_Click(object sender, EventArgs e)
        {
            var recipeInfo = GetRecipeInfo();

            //配方名称为空时，拼接出来的路径会变成目录，写入必然失败
            if (string.IsNullOrWhiteSpace(recipeInfo.RecipeName))
            {
                new FrmMsgBoxWithoutAck("请输入配方名称！", "添加配方").Show();
                return;
            }
            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info != null)
            {
                new FrmMsgBoxWithoutAck("当前配方名称已存在，请检查！", "添加配方").Show();
                return;
            }
            if (recipeInfo.RecipeName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能包含 \\ / : * ? \" < > | 等字符！", "添加配方").Show();
                return;
            }

            bool result = AddRecipe(recipeInfo, out string detail);

            if (result)
            {
                RefreshRecipe();
                new FrmMsgBoxWithoutAck("配方添加成功！", "添加配方").Show();
            }
            else
            {
                MessageBox.Show(detail, "添加配方失败");
            }
        }

        #region 获取配方对象
        private RecipeInfo GetRecipeInfo()
        {
            RecipeInfo recipeInfo = new RecipeInfo();

            recipeInfo.RecipeName = this.txt_RecipeName.Text.Trim();

            recipeInfo.RecipeParams = new List<RecipeParam>()
            {
                this.recipeControl1.RecipeParam,
                this.recipeControl2.RecipeParam,
                this.recipeControl3.RecipeParam,
                this.recipeControl4.RecipeParam,
                this.recipeControl5.RecipeParam,
                this.recipeControl6.RecipeParam,
            };

            return recipeInfo; 
        }
        #endregion

        #region 显示当前配方
        private void SetRecipeInfo(RecipeInfo recipeInfo)
        {
            this.txt_RecipeName.Text = recipeInfo.RecipeName;
            if (recipeInfo.RecipeParams.Count == 6)
            {
                this.recipeControl1.RecipeParam = recipeInfo.RecipeParams[0];
                this.recipeControl2.RecipeParam = recipeInfo.RecipeParams[1];
                this.recipeControl3.RecipeParam = recipeInfo.RecipeParams[2];
                this.recipeControl4.RecipeParam = recipeInfo.RecipeParams[3];
                this.recipeControl5.RecipeParam = recipeInfo.RecipeParams[4];
                this.recipeControl6.RecipeParam = recipeInfo.RecipeParams[5];
            }

        }
        #endregion

        #region 添加配方

        private bool AddRecipe(RecipeInfo recipeInfo, out string detail)
        {
            string path = basePath + "\\" + recipeInfo.RecipeName + ".ini";

            string json = JSONHelper.EntityToJSON(recipeInfo);

            detail = "路径：" + path
                + "\r\n目录存在：" + System.IO.Directory.Exists(basePath)
                + "\r\nJSON 长度：" + json.Length;

            if (string.IsNullOrEmpty(json))
            {
                detail += "\r\n序列化结果为空";
                return false;
            }

            bool result = IniConfigHelper.WriteIniData("配方", "配方数据", json, path);

            detail += "\r\n写入结果：" + result;

            return result;
        }

        #endregion

        #region 更新配方列表

        private void RefreshRecipe()
        {
            recipeInfos = GetAllRecipe();

            this.dgv_Main.Rows.Clear();

            if (recipeInfos.Count > 0)
            {
                for (int i = 0; i < recipeInfos.Count; i++)
                {
                    this.dgv_Main.Rows.Add();
                    this.dgv_Main.Rows[i].Cells[0].Value = (i + 1).ToString();
                    this.dgv_Main.Rows[i].Cells[1].Value = recipeInfos[i].RecipeName;
                }

                //先清掉 Rows.Add 自动设置的 CurrentCell（否则序号列标题会高亮），再选中目标行
                this.dgv_Main.CurrentCell = null;
                this.dgv_Main.ClearSelection();

                //默认选中第一行配方
                this.dgv_Main.Rows[0].Selected = true;
                SetRecipeInfo(this.recipeInfos[0]);
                this.lbl_CurrentRecipe.Text = this.recipeInfos[0].RecipeName;
            }
            else
            {
                this.dgv_Main.CurrentCell = null;
                this.dgv_Main.ClearSelection();
            }
        }

        #endregion

        #region 获取所有配方

        private List<RecipeInfo> GetAllRecipe()
        {
            List<RecipeInfo> recipeInfos = new List<RecipeInfo>();

            if (!Directory.Exists(basePath))
            {
                return recipeInfos;
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(basePath);

            List<FileInfo> fileInfos = directoryInfo.GetFiles("*.ini")
                .OrderByDescending(c => c.LastWriteTime)
                .ToList();

            foreach (var item in fileInfos)
            {
                RecipeInfo recipeInfo = GetRecipe(item.FullName);

                //跳过内容为空或已损坏的配方文件，避免列表里出现 null
                if (recipeInfo != null)
                {
                    recipeInfos.Add(recipeInfo);
                }
            }

            return recipeInfos;
        }

        #endregion

       

        #region 文件对象

        private RecipeInfo GetRecipe(string path)
        {
            return JSONHelper.JSONToEntity<RecipeInfo>(IniConfigHelper.ReadIniData("配方", "配方数据", "", path));
        }

        #endregion

      

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            var recipeInfo = GetRecipeInfo();

            //配方名称为空时，拼接出来的路径会变成目录，写入必然失败
            if (string.IsNullOrWhiteSpace(recipeInfo.RecipeName))
            {
                new FrmMsgBoxWithoutAck("请输入配方名称！", "修改配方").Show();
                return;
            }
            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方名称不存在，无法修改！", "修改配方").Show();
                return;
            }
            if (recipeInfo.RecipeName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
            {
                new FrmMsgBoxWithoutAck("配方名称不能包含 \\ / : * ? \" < > | 等字符！", "修改配方").Show();
                return;
            }

            bool result = AddRecipe(recipeInfo, out string detail);

            if (result)
            {
                RefreshRecipe();
                new FrmMsgBoxWithoutAck("配方修改成功！", "修改配方").Show();
            }
            else
            {
                MessageBox.Show(detail, "配方修改失败");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txt_RecipeName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("配方名称为空，请检查！", "删除配方").Show();
                return;
            }

            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();

            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方名称不存在，无法修改！", "删除配方").Show();
                return;
            }

            DialogResult dialogResult = new FrmMsgBoxWithAck("是否确定要删除该配方？", "删除配方").ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                bool result = DeleteRecipe(this.txt_RecipeName.Text.Trim());

                if (result)
                {
                    RefreshRecipe();
                    new FrmMsgBoxWithoutAck("配方删除成功！", "删除配方").Show();
                }
                else
                {
                    new FrmMsgBoxWithoutAck("配方删除失败！", "删除配方").Show();
                }
            }
        }

        #region 删除配方
        private bool DeleteRecipe(string recipeName)
        {
            try
            {
                File.Delete(basePath + "\\" + recipeName + ".ini");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var recipeInfo = recipeInfos[e.RowIndex];

                SetRecipeInfo(recipeInfo);

                //切换配方时同步更新"当前配方"显示
                this.lbl_CurrentRecipe.Text = recipeInfo.RecipeName;

                //点击行后 DataGridView 会把 CurrentCell 设到该行，导致序号列标题高亮；
                //清掉 CurrentCell 再重新选中当前行，保持行选中且无列标题高亮
                this.dgv_Main.CurrentCell = null;
                this.dgv_Main.ClearSelection();
                this.dgv_Main.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txt_RecipeName.Text.Trim().Length == 0)
            {
                new FrmMsgBoxWithoutAck("配方名称为空，请检查！", "应用配方").Show();
                return;
            }

            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();

            if (info == null)
            {
                new FrmMsgBoxWithoutAck("当前配方名称不存在，无法应用！", "应用配方").Show();
                return;
            }

            if (!CommonMethods.Device.IsConnected)
            {
                new FrmMsgBoxWithoutAck("请检查设备是否连接正常！", "应用配方").Show();
                return;
            }

            if (info.RecipeParams.Count == 6)
            {
                List<short> values = new List<short>();

                //添加温度和湿度的高低限
                for (int i = 0; i < 6; i++)
                {
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempHigh * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].TempLow * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityHigh * 10));
                    values.Add(Convert.ToInt16(info.RecipeParams[i].HumidityLow * 10));
                }

                //添加空闲的地址数值
                for (int i = 0; i < 24; i++)
                {
                    values.Add(0);
                }

                //继续添加报警启用
                for (int i = 0; i < 6; i++)
                {
                    values.Add(info.RecipeParams[i].TempAlarmEnable ? (short)1 : (short)0);
                    values.Add(info.RecipeParams[i].HumidityAlarmEnable ? (short)1 : (short)0);
                }

                bool result = CommonMethods.Modbus.PreSetMultiRegisters(36, ByteArrayLib.GetByteArrayFromShortArray(values.ToArray(), CommonMethods.dataFormat));

                if (result)
                {
                    string recipeName = this.txt_RecipeName.Text.Trim();

                    IniConfigHelper.WriteIniData("配方参数", "当前配方", recipeName, this.devPath);
                    CommonMethods.Device.CurrentRecipe = recipeName;
                    this.lbl_CurrentRecipe.Text = recipeName;
                    new FrmMsgBoxWithoutAck("配方数据写入成功！", "应用配方").Show();
                }
                else
                {
                    new FrmMsgBoxWithoutAck("配方数据写入失败，请检查！", "应用配方").Show();
                }
            }
            else
            {
                new FrmMsgBoxWithoutAck("配方数据不完整，请检查！", "应用配方").Show();
            }
        }
    }
}
