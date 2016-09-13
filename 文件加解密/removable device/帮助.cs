using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace removable_device
{
    public partial class 帮助 : Form
    {
        public 帮助()
        {
            InitializeComponent();
        }

        private void 帮助_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "1、请务必牢记您的加密密钥，软件本身不会记录您的密钥，\n\n"
                               + "   对于单文件的加解密尤其重要,因为对于单文件的加解密程 \n\n"
                               + "   序不会检验您的密钥是否正确，错误的密钥可能会解密出意\n\n"
                               + "   想不到的文件，可能对您的系统造成无法预料的伤害。由此\n\n"
                               + "   造成的一切损失请用户自行承担，并且加解密成功后原文件\n\n"
                               + "   并没有自动删除，这是防止用户误操作，用户请根据需要自\n\n"
                               + "   己删除相应的文件以保证保密性。\n\n"
                               + "2、对于文件夹加解密，请确保加解密后的文件夹与原文件夹在\n\n"
                               + "   同一驱动下，否则文件夹的加解密将不成功，即使程序提示\n\n"
                               + "    您操作成功。\n\n"
                               + "3、特别注意，所有的文件夹加密密钥都是采用同一个密钥，新的\n\n"
                               + "   密钥将覆盖原来的密钥，当前目录下的文件log.config是文件\n\n"
                               + "  夹加密的密钥配置文件，请勿将其删除或修改，否则将导致无\n\n"
                               + "  法解密您已加密的的文件夹。如果不小心将其删除或修改，请\n\n"
                               + "  再设置相同的密钥对任意文件夹进行加密即可对原先的加密文\n\n"
                               + "  件夹进行加密。\n\n"
                               + "4、对于单文件加解密，为保证加密的体验效果，单文件对象不建\n\n"
                               +"   议超过 10 MB，如果您需要加密大文件，请使用文件夹加解密。\n\n"
                               +"   对于文件夹的加解密没有大小要求。\n\n"
                               +"5、欢迎交流，QQ:532651417 E-mail:tbj621@gmail.com\n\n";
        }
    }
}
