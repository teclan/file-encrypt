using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//添加的命名空间
using System.IO;
using System.Collections;
using System.Security.Cryptography; 

namespace removable_device
{
   
    public partial class Form1 : Form
    {
        string str;  // 驱动记录串
        string path="";//当前路径
        int flag = 0;//  0 表示文件夹操作，1 表示文件操作
        bool success = false;// 标记本次操作是否成功结束（主要是用于文件夹加解密）
        public Form1()
        {
            InitializeComponent(); // 窗口初始化
        }

        /*窗口加载时_____________初始化滚动标签,弹出一个提示对话框
         * 
         * 单击“确定”按钮继续，弹出主操作界面
         * 
         * 单击“取消”按钮则退出当前程序
         */
        private void Form1_Load(object sender, EventArgs e)
        {
            label4.Text = "本软件由 Teclan 为您提供，QQ:532651417 ,微信：tbj621 ,E-mail:tbj621@gmail.com ";

            if (MessageBox.Show("在使用本软件之前，请一定要先查看相关说明，否则造成的一切后果请自行负责。具体的说明请再软件主界面点击 “帮助”按钮查看。", "谭炳健  提示您：", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                Application.Exit();
            }
        }

        public void getDiskList()
        {
            // 清 空 驱 动 列 表  控 件 内 容
            RemovableList.Items.Clear();

            // 获 取 磁 盘  信 息
            DriveInfo[] allDrives = DriveInfo.GetDrives();  //检索计算机上的所有逻辑驱动器的驱动器名称
            for (int i = 0; i < allDrives.Length; i++)            {
                
                if (allDrives[i].DriveType.ToString() == "Removable")       //是可移动设备     
                {
                    RemovableList.Items.Add("U盘"+allDrives[i].ToString() + "   [" + (allDrives[i].AvailableFreeSpace / (1024 * 1024*1024*1.0)).ToString("0.00") + "G剩余 共" + (allDrives[i].TotalSize / (1024*1024 * 1024*1.0)).ToString("0.00") + "G]");
    
                }

                if (allDrives[i].DriveType.ToString() == "Fixed")     // 是硬盘   
                {
                   RemovableList.Items.Add("硬盘"+allDrives[i].ToString() + "   [" + (allDrives[i].AvailableFreeSpace / (1024 * 1024*1024*1.0)).ToString("0.00") + "G剩余 共" + (allDrives[i].TotalSize / (1024*1024 * 1024*1.0)).ToString("0.00") + "G]");
                }
            }
        }

        /*
         * 单 击 “扫描驱动” 按 钮 时 执 行 
         */
        private void ScanDrive_Click(object sender, EventArgs e)
        {
            RemovableList.Items.Clear(); //清空驱动列表控件          
            getDiskList();              //获取驱动列表
        }

      /*
       * 获取目录下的所有内容，先获取文件内容，再获取文件夹内容
       */
        public void GetAllDirList(string strBaseDir)
        {
            //清空内容列表
            listBox1.Items.Clear();           
            // 扫描当前目录下的所有文件
            foreach (FileInfo fi in new System.IO.DirectoryInfo(@strBaseDir).GetFiles())
            {
                listBox1.Items.Add(fi.Name.ToString());
            }
            //扫描当前目录下的所有文件夹
            foreach (DirectoryInfo fi in new System.IO.DirectoryInfo(@strBaseDir).GetDirectories())
            {
                listBox1.Items.Add(fi.Name.ToString());
            }
           
        }

        // 单击“返回上一级”按钮时执行，
        // 目录返回至父级目录，根目录时无法再返回上级目录弹出对话框
        private void bt_back_Click(object sender, EventArgs e)
        {              
              try{
                  //获取上级目录路径
                 path = path.Substring(0,path.LastIndexOf("\\"));  
                  //获取路径下的所有内容
                 GetAllDirList(path);  
              }
            catch
              {
                  MessageBox.Show("   当前已是驱动的根目录 ！\n  请选择其他操作或者重新选择驱动!");
            }
        }

        // 单击“加密”按钮执行
        private void bt_encry_Click(object sender, EventArgs e)
        {
            try
            {
                // 先将执行成功标记置为 flase
                success = false;
                //获取当前被选中路径
                path = path + "\\" + listBox1.SelectedItem.ToString();

                if (Directory.Exists(path))//如果这个路径是一个文件夹（目录）
                {
                    if (path.LastIndexOf(".{") >= 0)//搜索关键标识，判断是否已被加密，如果已加密直提示并退出
                    {
                        MessageBox.Show("文件夹已经加密，无需再次加密！");
                        return;
                    }
                  //已加密，则调用加密文件夹方法
                    flag = 0;     // 标记 这是针对文件夹的操作
                    GoEncryFolder();//加密文件夹方法
                }
                else  //被选中的路径是一个文件
                {
                    flag = 1;//标记这是一个文件
                    if (tB_AfterEncry.Text == "")//如果加密后的路径为空
                    {
                        MessageBox.Show("请输入加密后的文件路径");
                    }
                    //创建加密后的路径，防止路径不存在时出现异常
                    Directory.CreateDirectory(@tB_AfterEncry.Text.Substring(0, tB_AfterEncry.Text.LastIndexOf('\\')));

                    if (tB_Key.Text == "" || tB_KeyConfirm.Text == "")
                    {
                        MessageBox.Show("秘钥为空，请输入秘钥 !!!");
                    }

                    if (tB_Key.Text != tB_KeyConfirm.Text)
                    {
                        MessageBox.Show("两次输入的密钥不匹配，请重新输入 !!!");
                        tB_Key.Text = "";
                        tB_KeyConfirm.Text = "";
                    }
                    //获取文件格式，即文件后缀名
                    string suffix = path.Substring(path.LastIndexOf('.'));
                    tB_Suffix.Text = suffix;
                    //被加密文件即是当前被选中文件
                    string myInFileName = path;
                    //拼凑加密后的文件路径,加密后的输出文件即使 加密后的路径拼上文件后缀
                    string myOutFileName = tB_AfterEncry.Text + suffix;
                    //进入文件加密方法
                    GoEncryFile(myInFileName, myOutFileName, tB_Key.Text);
                    //标记此次操作成功
                    success = true;

                }
                //刷新当前目录  
                path = path.Substring(0, path.LastIndexOf("\\"));                         
                GetAllDirList(path);
                if (flag == 0 && success == true)
                    MessageBox.Show("文件夹加密成功！");
                else if (flag == 1 && success == true)
                    MessageBox.Show("文件加密成功！");
            }
            catch
            {
                MessageBox.Show("您未选择任何项！");
            }
        }

        //单击“解密”按钮时执行
        private void bt_decip_Click(object sender, EventArgs e)
        {
            try
            {   //标记成功标识为 false
                success = false;
                //获取当前路径
                path = path + "\\" + listBox1.SelectedItem.ToString();

                if (Directory.Exists(path))//如果是文件夹（目录）
                {
                    if (path.LastIndexOf(".{") < 0)//如果没有加密
                    {
                        MessageBox.Show("此文件夹未加密，您可以直接浏览！");
                        return;
                    }
                    flag = 0;//标志这是文件夹操作
                    GoDecryFolder();//进入文件夹解密方法
                }

                else
                {
                    //标志这是一个文件操作
                    flag = 1;
                    //获得加密文件名
                    string myInFileName = path;
                    if (tB_AfterEncry.Text == "")
                    {
                        MessageBox.Show("请输入解密后的文件路径");
                    }
                    //创建解密后的路径防止出现路径不存在异常
                    Directory.CreateDirectory(@tB_AfterEncry.Text.Substring(0, tB_AfterEncry.Text.LastIndexOf('\\')));

                    if (tB_Key.Text == "")
                    {
                        MessageBox.Show("秘钥为空，请输入秘钥 !!!");
                    }

                    //获取文件后缀
                    string suffix = path.Substring(path.LastIndexOf('.'));
                    tB_Suffix.Text = suffix;
                    //拼凑解密后的文件路径
                    string myOutFileName = tB_AfterEncry.Text + suffix;
                    //进入文件解密方式
                    GoDecryFile(myInFileName, myOutFileName, tB_Key.Text);
                    //标记此次操作成功
                    success = true;

                }

                path = path.Substring(0, path.LastIndexOf("\\"));
                //刷新当前目录           
                GetAllDirList(path);

                if (flag == 0 && success == true)
                    MessageBox.Show("文件夹解密成功！");
                else if (flag == 1 && success == true)
                    MessageBox.Show("文件解密成功！");
            }
            catch
            {
                MessageBox.Show("您未选择任何项！");
            }
        }
        //输入加解密后的路径时后缀自动清除
        private void tB_AfterEncry_TextChanged(object sender, EventArgs e)
        {
            tB_Suffix.Text = "";
        }

        private void bt_Open_Click(object sender, EventArgs e)
        {   
            //标志操作成功标识为 false
            success = false;
            try
            {
                path = path + "\\" + listBox1.SelectedItem.ToString();              
                if (path.IndexOf(".{") > 0)  //对于已加密文件夹不允许直接加密
                {
                    MessageBox.Show("此文件夹已经被加密，请先对其进行解密再访问!");
                }
                else
                {
                    if (File.Exists(path))//是文件
                    {
                        System.Diagnostics.Process.Start(path);//调用系统应用打开文件
                        path = path.Substring(0, path.LastIndexOf('\\') + 1);                       
                    }
                    else if (Directory.Exists(path))//是文件夹则获取当前目录下的所有文件和文件夹
                    {
                        GetAllDirList(path);
                    }
                }
            }
            catch
            {

            }
            }
  
        // 显示 或 隐藏 密码按钮
        private void bt_change_Click(object sender, EventArgs e)
        {
            string key = tB_Key.Text;

            if (tB_Key.PasswordChar == '*')
            {
                tB_Key.PasswordChar = '\0';
                tB_KeyConfirm.PasswordChar = '\0';
                tB_Key.Text = key;
                bt_change.Text = "隐藏";
            }
            else
            {
                tB_Key.PasswordChar = '*';
                tB_KeyConfirm.PasswordChar = '*';
                tB_Key.Text = key;
                bt_change.Text = "显示";
            }
        }

        //定时器实现标签滚动效果
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Left -= 3;

            if (label4.Right < 0)
                label4.Left = panel1.Width;
        }

        //单击“重置”密钥按钮
        private void bt_ResetKey_Click(object sender, EventArgs e)
        {
            tB_Key.Text = "";
            tB_KeyConfirm.Text = "";
        }
        
        // 单击“删除”按钮时执行
        private void bt_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedItem != null)
                {
                    try
                    {
                        path = path + "\\" + listBox1.SelectedItem.ToString();

                        if (File.Exists(path))//是文件
                        {
                            //弹出 选择 对话框
                            if (MessageBox.Show("    确定要删除文件" + path + "?", "删除文件警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                File.Delete(@path);//如果存在则删除                           
                                path = path.Substring(0, path.LastIndexOf('\\'));

                            }
                            else
                            {
                                path = path.Substring(0, path.LastIndexOf('\\'));

                            }

                        }
                        else if (Directory.Exists(path))//是文件夹
                        {
                            //弹出 选择 对话框
                            if (MessageBox.Show("    确定要删除目录" + path + "?", "删除文件夹警告", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                Directory.Delete(@path, true);//不加 true 参数则不能删除非空文件夹                          
                                path = path.Substring(0, path.LastIndexOf('\\'));
                            }
                            else
                            {
                                path = path.Substring(0, path.LastIndexOf('\\'));
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        path = path.Substring(0, path.LastIndexOf('\\'));
                    }

                    //刷新当前目录           
                    GetAllDirList(path);
                }
            }
            catch
            {
                MessageBox.Show("您未选中任何项！");
            }

        }

        // 单击 “打开驱动” 按钮时执行
        private void bt_OpenDisk_Click(object sender, EventArgs e)
        {
            try
            {
                str = RemovableList.SelectedItem.ToString();
                //str = str.Substring(2,3);
                //path = str;
                path = str.Substring(2, 3);
                // MessageBox.Show(path);
                //GetAllDirList(str);
                GetAllDirList(path);
            }
            catch
            {
                MessageBox.Show("您没有选中任何驱动，请单击“扫描驱动”按钮\n并选中需要的驱动后再单击此按钮。");

            }
        }


        // 加密文件夹方法
        void GoEncryFolder()
        { 

            if (tB_AfterEncry.Text == "")
            {
                MessageBox.Show("请输入加密后的文件路径");
                return;
            }           

            // 创建加密后的路径确保不出现路径不存在异常
            Directory.CreateDirectory(@tB_AfterEncry.Text.Substring(0, tB_AfterEncry.Text.LastIndexOf('\\')));
            //配置加密后的路径
            string newPath = tB_AfterEncry.Text +".{2559a1f2-21d7-11d4-bdaf-00c04f60b9f0}";
            if (tB_Key.Text == "" || tB_KeyConfirm.Text == "")
            {
                MessageBox.Show("秘钥为空，请输入秘钥 !!!");                 
                return;

            }

            if (tB_Key.Text != tB_KeyConfirm.Text)
            {
                MessageBox.Show("两次输入的密钥不匹配，请重新输入 !!!");
                tB_Key.Text = "";
                tB_KeyConfirm.Text = "";
                return;
            }
            //确保当前目录下 log.dat 和 log.config 文件不存在
            if(File.Exists("./log.dat"))
            {
                File.Delete("./log.dat");
            }

            if(File.Exists("./log.config"))
            {
                File.Delete("./log.config");
            }
            //创建 log.dat
            FileStream fs = new FileStream("log.dat", FileMode.OpenOrCreate);  
            // 设置默认的加密密钥，用来加密用户的加密密钥
            string defaultKey = "532651417";
            try
            {
            char[] cData = tB_Key.Text.ToCharArray();//将用户的密钥转换成 字符数组
            byte[] bData = new byte[tB_Key.Text.Length];//申请一个与上述字符数字等长的字节数组
            Encoder myEn = Encoding.UTF8.GetEncoder();//设置编码格式为 UTF8
            myEn.GetBytes(cData, 0, cData.Length,bData,0,true);//字符数字转字节数组
            fs.Seek(0, SeekOrigin.Begin);//找到 log.dat 的文件首
            fs.Write(bData, 0, bData.Length);//写入字节数组的内容
            fs.Close();//关闭文件
            GoEncryFile("log.dat","log.config", defaultKey);//使用默认密钥加密 log.dat 得到 log.config
            File.Delete("./log.dat"); //删除明文文件 log.dat   
        
                //重命名文件夹
            FileInfo fi = new FileInfo(path);
           fi.MoveTo(Path.Combine(newPath));
          
                               
            }
            catch
            {
               
            }
            //此次操作成功
            success = true;

        }

        //解密文件夹
        void GoDecryFolder()
        {
           
            if (tB_AfterEncry.Text == "")
            {
                MessageBox.Show("请输入解密后的文件路径");
            }
            //创建解密后的目录防止出现路径不存在异常
            Directory.CreateDirectory(@tB_AfterEncry.Text.Substring(0, tB_AfterEncry.Text.LastIndexOf('\\')));   
            //获取解密后的路径
            string newPath = tB_AfterEncry.Text;
           
            if (tB_Key.Text == "" )
            {
                MessageBox.Show("秘钥为空，请输入秘钥 !!!");
            }           
            try
            {
             string defaultKey = "532651417";//默认解密密钥
             GoDecryFile("log.config", "log.dat", defaultKey);  //使用默认的密钥解密 log.config 得到明文文件夹 log.dat     
             FileStream fs = new FileStream("log.dat", FileMode.Open);//打开 log.dat

             char[] cData = new char[fs.Length];//申请与文件等长的字符数组
             byte[] bData = new byte[fs.Length];//申请与文件等长的字节数组
             fs.Seek(0, SeekOrigin.Begin);//找到文件首
             fs.Read(bData, 0, bData.Length);//将文件读入字节数组
             fs.Close();//关闭文件
             Decoder myDe = Encoding.UTF8.GetDecoder();//配置解码格式 UTF8
             myDe.GetChars(bData, 0, bData.Length, cData, 0); //将字节数组转换成字符数组
               //将字符数组转成字符串
                string Key="";
                for (int i = 0; i < cData.Length; i++)
                    Key += cData[i].ToString();
                //如果用户输入的密码与解密出来的密码不一致，提示并退出
                if(Key != tB_Key.Text)
                {
                    MessageBox.Show("密钥错误");
                    success = false;
                        return;
                }
            
            File.Delete("./log.dat"); //删除明文文件 log.dat           
            //Directory.CreateDirectory(@newPath);

                //重命名文件夹
               FileInfo fi = new FileInfo(path);
                fi.MoveTo(Path.Combine(newPath));            
                
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //标志操作成功
            success = true;

        }

        //加密文件
        void GoEncryFile(String myInFileName,string myOutFileName,string key)
        {
            
            try
            {
                
                //设定初始变量
                byte[] myDESIV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, };
                byte[] myDESKey = { };
                //根据密码设置密钥大小
                string myKeyString = key;
                if (myKeyString.Length == 6)
                {
                    myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], 0x07, 0x08 };

                }
                if (myKeyString.Length == 7)
                {
                    myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], (byte)myKeyString[6], 0x07 };

                }
                if (myKeyString.Length >= 8)
                {
                    myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], (byte)myKeyString[6], (byte)myKeyString[7] };

                }
                //创建输入和输出文件流
                FileStream myInFileStream = new FileStream(myInFileName, FileMode.Open, FileAccess.Read);
                FileStream myOutFileStream = new FileStream(myOutFileName, FileMode.OpenOrCreate, FileAccess.Write);
                myOutFileStream.SetLength(0);
                //每次的中间流
                byte[] inSertData = new byte[100];
                //代表已经加密流的大小
                int completedLength = 0;
                //代表要加密文件总的大小
                long inFileSize = myInFileStream.Length;
                //创建DES对象
                DES myDES = new DESCryptoServiceProvider();
                //创建加密流
                CryptoStream enCrytoStream = new CryptoStream(myOutFileStream, myDES.CreateEncryptor(myDESKey, myDESIV), CryptoStreamMode.Write);
                //从输入文件中读取流，然后加密到输出文件流
                while (completedLength < inFileSize)
                {
                    //每次写入加密文件的数据大小
                    int length = myInFileStream.Read(inSertData, 0, 100);
                    enCrytoStream.Write(inSertData, 0, length);
                    completedLength += length;
                }
                //关闭流
                enCrytoStream.Close();
                myInFileStream.Close();
                myOutFileStream.Close();
                // MessageBox.Show("文件加密操作成功!", "Teclan 提示您：", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           // 标志操作成功
            success = true;
          
        }

        //解密文件
        void GoDecryFile(string myInFileName,string myOutFileName,string key)
        {
             
            try{
                  //设定初始变量
                    byte[] myDESIV = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, };
                    byte[] myDESKey = { };
                    //根据密码设置密钥大小
                    string myKeyString = key;
                    if (myKeyString.Length == 6)
                    {
                        myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], 0x07, 0x08 };

                    }
                    if (myKeyString.Length == 7)
                    {
                        myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], (byte)myKeyString[6], 0x07 };

                    }
                    if (myKeyString.Length >= 8)
                    {
                        myDESKey = new byte[] { (byte)myKeyString[0], (byte)myKeyString[1], (byte)myKeyString[2], (byte)myKeyString[3], (byte)myKeyString[4], (byte)myKeyString[5], (byte)myKeyString[6], (byte)myKeyString[7] };

                    }
                    //创建输入和输出文件流
                    FileStream myInFileStream = new FileStream(myInFileName, FileMode.Open, FileAccess.Read);
                    FileStream myOutFileStream = new FileStream(myOutFileName, FileMode.OpenOrCreate, FileAccess.Write);
                    myOutFileStream.SetLength(0);
                    //每次的中间流
                    byte[] inSertData = new byte[100];
                    //代表已经解密流的大小
                    int completedLength = 0;
                    //代表要解密文件总的大小
                    long inFileSize = myInFileStream.Length;
                    //创建DES对象
                    DES myDES = new DESCryptoServiceProvider();
                    //创建加密流
                    CryptoStream deCrytoStream = new CryptoStream(myOutFileStream, myDES.CreateDecryptor(myDESKey, myDESIV), CryptoStreamMode.Write);
                    //从输入文件中读取流，然后加密到输出文件流
                    while (completedLength < inFileSize)
                    {
                        //每次写入加密文件的数据大小
                        int length = myInFileStream.Read(inSertData, 0, 100);
                        deCrytoStream.Write(inSertData, 0, length);
                        completedLength += length;
                    }
                    //关闭流
                    deCrytoStream.Close();
                    myInFileStream.Close();
                    myOutFileStream.Close();
                    //MessageBox.Show("文件解密操作成功!", "Teclan 提示您：", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            //标志操作成功
            success = true;
        }

        //单击“帮助”时执行
        //弹出 “帮助” 窗口
        private void btn_help_Click(object sender, EventArgs e)
        {
            帮助 f = new 帮助();
            f.Show();
        }



        }


        }
  
