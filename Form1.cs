using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_SaveData_Chapter_Tool
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        int MaxPartNumber=0;

        // 文件夹拖入
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
                        MessageBox.Show("Cannot Use the Folder:\n" + filePath+"\n It is a .part of folder", "Universal SaveData Chapter Tool",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    else
                    {
                        comboBox2.Items.Add(filePath);
                        comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
                      
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

        // 切换文件夹目录
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = comboBox2.Text;
            SaveComboBoxItems();
        }

        // 按钮添加文件夹
        private void folderBrowser_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            folderBrowserDialog1.ShowNewFolderButton = false;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyDocuments;
            string path = folderBrowserDialog1.SelectedPath;
            comboBox2.Items.Add(path);
            comboBox2.SelectedIndex = comboBox2.Items.Count-1;
        }

        // 删除对应文件夹路径注册
        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Items.Remove(comboBox2.Text);
            comboBox2_SelectedIndexChanged(sender, e);
        }

        // 触发列表选择所有文件还有
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 获取文件夹路径
            string folderPath = textBox1.Text;

            // 确保文件夹存在
            if (Directory.Exists(folderPath))
            {
                // 清空 CheckListBox 中的项目
                checkedListBox1.Items.Clear();

                // 获取文件夹下的所有文件
                string[] files = Directory.GetFiles(folderPath);

                // 将文件添加到 CheckListBox 中
                foreach (string file in files)
                {
                    // 添加文件的完整路径作为 CheckListBox 项的值
                    checkedListBox1.Items.Add(file);
                }
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

                comboBox1.Items.Clear();

                if (matchingFolders.Length != 0)
                {
                    comboBox1.Items.AddRange(matchingFolders);
                    comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
                }
                else
                {
                    MessageBox.Show("Cannot Found Any part of:\n" + folderPath, "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // Ctrl+A of CheckListBox
        private void checkedListBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // 检查是否按下了 Ctrl+A 快捷键
            if (e.Control && e.KeyCode == Keys.A)
            {
                // 遍历所有项，并设置为选中状态
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }

                // 防止默认的 Ctrl+A 快捷键效果
                e.SuppressKeyPress = true;
            }
        }
        // 自动选中包含数字的文件(通常为对应存档)
        private void button4_Click(object sender, EventArgs e)
        {
            int itemCount = checkedListBox1.Items.Count;
            for (int i = 0; i < itemCount; i++)
            {
                string filePath = checkedListBox1.Items[i].ToString();
                string fileName = Path.GetFileName(filePath);

                // 使用正则表达式匹配文件名中是否包含数字
                if (Regex.IsMatch(fileName, @"\d"))
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }
        // 创建新part
        private void button2_Click(object sender, EventArgs e)
        {
            int nowPartNumber = MaxPartNumber + 1;
            if (Directory.Exists(textBox1.Text))
            {
                string destinationFolder = textBox1.Text + ".part" + nowPartNumber;
                Directory.CreateDirectory(destinationFolder);

                if (Directory.Exists(destinationFolder))
                {

                    foreach (var item in checkedListBox1.CheckedItems)
                    {
                        string sourceFilePath = item.ToString();

                        // 构建目标文件路径
                        string destinationFilePath = Path.Combine(destinationFolder, Path.GetFileName(sourceFilePath));

                        try
                        {
                            // 移动文件
                            File.Move(sourceFilePath, destinationFilePath);
                        }
                        catch (Exception ex)
                        {
                            // 处理移动文件时的异常
                            MessageBox.Show("ERROR：" + ex.Message, "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("OK", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Cannot found:", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                textBox1_TextChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Please select a path!", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 复制当前part文件到原文件夹
        private void button3_Click(object sender, EventArgs e)
        {
            string sourceFolder = comboBox1.Text; // 替换为实际的源文件夹路径
            string destinationFolder = textBox1.Text; // 替换为实际的目标文件夹路径

            if (Directory.Exists(sourceFolder) && Directory.Exists(destinationFolder))
            {
                if (MessageBox.Show("Are you sure you want to restore the file to the original folder?\nThis operation will overwrite existing files.\nFrom : " + sourceFolder + "\nTo : " + destinationFolder, "Universal SaveData Chapter Tool", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string[] files = Directory.GetFiles(sourceFolder);

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);
                        string destinationFilePath = Path.Combine(destinationFolder, fileName);

                        try
                        {
                            File.Copy(file, destinationFilePath, true); // 第三个参数设置为 true，表示允许覆盖同名文件
                        }
                        catch (Exception ex)
                        {
                            // 处理复制文件时的异常
                            MessageBox.Show("Copy Error：\n" + ex.Message, "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    MessageBox.Show("Successfully!", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Source folder or destination folder isnot Exists", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                textBox1_TextChanged(sender, e);
            }
        }

        private void SaveComboBoxItems()
        {
            string fileName = "SaveDataPaths.txt"; // 文件名
            List<string> items = new List<string>();

            // 将 ComboBox2(所有目录) 的项添加到列表中
            foreach (var item in comboBox2.Items)
            {
                string folderPath = item.ToString();

                // 检查目录是否存在
                if (Directory.Exists(folderPath))
                {
                    items.Add(folderPath);
                }
                else
                {
                    MessageBox.Show($"Cannot found \"{folderPath}\"", "Universal SaveData Chapter Tool", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // 保存列表到文件
            File.WriteAllLines(fileName, items);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string fileName = "SaveDataPaths.txt";

            if (File.Exists(fileName))
            {
                string[] lines = File.ReadAllLines(fileName);
                comboBox2.Items.Clear();
                comboBox2.Items.AddRange(lines);
                comboBox2.SelectedIndex = comboBox2.Items.Count - 1;
            }
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            string Help = 
@"A.第一次打开（注册游戏存档目录和如何存档）
    1.点击""打开文件夹""（拖动文件夹到本窗口也可以）
    2.选择文件
    3.点击""保存到新Part""
    4.享受吧！
B.多个游戏存档管理？
    1.点击""注册新文件夹路径""(使用""打开文件夹""也可以)
    2.在集合的选择框中选择游戏，即可切换目录
    3.如果需要删除目录记录点击""删除注册的文件夹路径""
    4.体验管理的便携吧！
C.加载存档？
    1.选择完成游戏存档目录之后(在集合中选则)
    2.点击""加载当前选中的Part""旁边的选择框进行选择Part
    3.点击""加载当前选中的Part""
    4.体验存档吧！
D.删除存档?
    1.为了避免删除错误，请自己主动去游戏存档目录
    2.本工具只是存档和加载的工具，没有删除功能
";
            MessageBox.Show(Help,"Help of Universal SaveData Chapter Tool",MessageBoxButtons.OK);
        }
    }
}
