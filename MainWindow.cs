using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Universal_SaveData_Chapter_Tool.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Universal_SaveData_Chapter_Tool
{
    public partial class MainWindow : Form
    {
        string fileName = "SaveDataPaths.txt";

        int MaxPartNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                savedatapathsbox.Items.Clear();
                savedatapathsbox.Items.AddRange(lines);
                savedatapathsbox.SelectedIndex = savedatapathsbox.Items.Count - 1;
            }
        }

        //保存所有路径到文件
        private void SavePaths()
        {
            List<string> items = new List<string>();

            foreach (var item in savedatapathsbox.Items)
            {
                string folderPath = item.ToString();

                // 检查目录是否存在
                if (Directory.Exists(folderPath))
                {
                    items.Add(folderPath);
                }
                else
                {
                    MessageBox.Show($"目前找不到\n \"{folderPath}\" \n,目标文件夹可能丢失或者移动！", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 保存列表到文件
            File.WriteAllLines(fileName, items);
        }

        //关于按钮
        private void aboutbut_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Resources.about,"Thanks!!!",MessageBoxButtons.OK);
        }

        //+按扭 添加路径
        private void addpathbut_Click(object sender, EventArgs e)
        {
            folderDialog.ShowDialog();
            string path = folderDialog.SelectedPath;
            savedatapathsbox.Items.Add(path);
            savedatapathsbox.SelectedIndex = savedatapathsbox.Items.Count - 1;
        }

        // 文件夹拖入逻辑
        private void Folder_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                string filePath = filePaths[0];
                if (Directory.Exists(filePath))
                {
                    if (filePath.Contains(".part"))
                    {
                        MessageBox.Show("不能使用:\n" + filePath + "\n 因为他是文件夹的.part分段文件夹", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        savedatapathsbox.Items.Add(filePath);
                        savedatapathsbox.SelectedIndex = savedatapathsbox.Items.Count - 1;
                    }

                }
            }
        }

        // 文件拖入光标显示
        private void Folder_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (Directory.Exists(filePaths[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

            // 更改鼠标光标为禁止符号
            Cursor.Current = Cursors.No;
        }
        // 删除路径
        private void delpathbut_Click(object sender, EventArgs e)
        {
            savedatapathsbox.Items.Remove(savedatapathsbox.Text);
        }
        // 选择文件的Ctrl+A实现
        private void filelistbox_KeyDown(object sender, KeyEventArgs e)
        {
            // 检查是否按下了 Ctrl+A 快捷键
            if (e.Control && e.KeyCode == Keys.A)
            {
                // 遍历所有项，并设置为选中状态
                for (int i = 0; i < filelistbox.Items.Count; i++)
                {
                    filelistbox.SetItemChecked(i, true);
                }

                // 防止默认的 Ctrl+A 快捷键效果
                e.SuppressKeyPress = true;
            }
        }
        // 全选按钮
        private void selectallbut_Click(object sender, EventArgs e)
        {
            // 遍历所有项，并设置为选中状态
            for (int i = 0; i < filelistbox.Items.Count; i++)
            {
                
                filelistbox.SetItemChecked(i,true);
            }
        }
        // 选中带数字的
        private void selectnumberbut_Click(object sender, EventArgs e)
        {
            int itemCount = filelistbox.Items.Count;
            for (int i = 0; i < itemCount; i++)
            {
                string filePath = filelistbox.Items[i].ToString();
                string fileName = Path.GetFileName(filePath);

                // 使用正则表达式匹配文件名中是否包含数字
                if (Regex.IsMatch(fileName, @"\d"))
                {
                    filelistbox.SetItemChecked(i, true);
                }
                else
                {
                    filelistbox.SetItemChecked(i, false);
                }
            }
        }
        // 保存
        private void savebut_Click(object sender, EventArgs e)
        {
            int nowPartNumber = MaxPartNumber + 1;
            if (Directory.Exists(savedatapathsbox.Text))
            {
                string destinationFolder = savedatapathsbox.Text + ".part" + nowPartNumber;
                string sourceFolder = savedatapathsbox.Text;
                Directory.CreateDirectory(destinationFolder);

                if (Directory.Exists(destinationFolder))
                {

                    foreach (var item in filelistbox.CheckedItems)
                    {
                        string sourceFilePath = Path.Combine(sourceFolder,item.ToString());

                        // 构建目标文件路径
                        string destinationFilePath = Path.Combine(destinationFolder, item.ToString());

                        try
                        {
                            // 移动文件
                            File.Move(sourceFilePath, destinationFilePath);
                        }
                        catch (Exception ex)
                        {
                            // 处理移动文件时的异常
                            MessageBox.Show("发生错误：\n" + ex.Message, "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("操作完成", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("未能找到:", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                savedatapathsbox_SelectedIndexChanged(sender, e);
            }
            else
            {
                MessageBox.Show("请选中路径!", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 刷新列表
        private void UpdateFilelist_Click(object sender, EventArgs e)
        {
            savedatapathsbox_SelectedIndexChanged(sender, e);
        }
        // 加载
        private void loadbut_Click(object sender, EventArgs e)
        {
            string sourceFolder = partslistbox.Text; // 替换为实际的源文件夹路径
            string destinationFolder = savedatapathsbox.Text; // 替换为实际的目标文件夹路径

            if (Directory.Exists(sourceFolder) && Directory.Exists(destinationFolder))
            {
                if (MessageBox.Show("您确定要将文件还原到原始文件夹中吗?\n此操作将覆盖现有文件。\n从 : " + sourceFolder + "\n到 : " + destinationFolder, "Universal SaveData Chapter Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] files = Directory.GetFiles(sourceFolder);

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destinationFilePath = Path.Combine(destinationFolder, fileName);

                        try
                        {
                            // 文件可用，可以进行复制操作
                            File.Copy(file, destinationFilePath, true); // 第三个参数设置为 true，表示允许覆盖同名文件
                        }
                        catch (Exception ex)
                        {
                            // 处理复制文件时的异常
                            MessageBox.Show("复制文件时异常：\n" + ex.Message, "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("操作完成!", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("源文件夹或目标文件夹不存在", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                savedatapathsbox_SelectedIndexChanged(sender, e);
            }
        }
        // 更新
        private void savedatapathsbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SavePaths();
            // 获取文件夹路径
            string folderPath = savedatapathsbox.Text;

            // 确保文件夹存在
            if (Directory.Exists(folderPath))
            {
                filelistbox.Items.Clear();

                // 获取文件夹下的所有文件（仅文件名）
                string[] files = Directory.GetFiles(folderPath);

                filelistbox.BeginUpdate();
                foreach (string file in files)
                {
                    string fileName = Path.GetFileName(file);
                    filelistbox.Items.Add(fileName);
                }
                filelistbox.EndUpdate();
            }
            else
            {
                MessageBox.Show("输入的文件夹路径无效！");
            }

            if (Directory.Exists(folderPath))
            {
                // 获取分页存档 比如 savedata.part1
                string folderName = Path.GetFileName(folderPath);
                string directoryPath = Path.GetDirectoryName(folderPath);

                string pattern = "^" + Regex.Escape(folderName) + "\\.part\\d+$";

                string[] matchingFolders = Directory.GetDirectories(directoryPath, "*", SearchOption.TopDirectoryOnly)
                    .Where(folder => Regex.IsMatch(Path.GetFileName(folder), pattern))
                    .ToArray();
                //目前最大的文件夹值
                MaxPartNumber = matchingFolders.Length;

                partslistbox.Items.Clear();

                if (matchingFolders.Length != 0)
                {
                    partslistbox.Items.AddRange(matchingFolders);
                    partslistbox.SelectedIndex = partslistbox.Items.Count - 1;
                }
            }
        }

        private void delselectfilesbut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否删除选中文件？\n删除将后无法恢复！！！", "Universal SaveData Chapter Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sourceFolder = savedatapathsbox.Text;
                foreach (var item in filelistbox.CheckedItems)
                {
                    string sourceFilePath = Path.Combine(sourceFolder, item.ToString());

                    try
                    {
                        // 删除文件
                        File.Delete(sourceFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("发生错误：\n" + ex.Message, "删除文件时出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                savedatapathsbox_SelectedIndexChanged(sender, e);
            }
        }

        private void delselectpartbut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否删除选中章？\n删除将后无法恢复！！！", "Universal SaveData Chapter Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string sourceFolder = partslistbox.Text;
                try
                {
                    // 删除文件
                    Directory.Delete(sourceFolder);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误：\n" + ex.Message, "删除章时出错", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                savedatapathsbox_SelectedIndexChanged(sender, e);
            }
        }
    }
}
