using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OracleClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }
        //打开数据库连接  
        public bool OpenOracle()
        {
            //从配置文件中获取连接字符串  
            //配置文件需要放在项目目录下的bin\Release中  
            //不做配置连接
            string connString = $"Data Source={txtdatasource.Text};Persist Security Info=True;User ID={txtUid.Text};Pwd={txtpwd.Text};Unicode=True;Pooling=true;Max Pool Size=400;enlist=true;";
            OracleConnection conn = new OracleConnection(connString);
            try
            {
                conn.Open();
                txtResultOrErrMsg.Text = "数据库连接成功";
                //OracleCommand cmd = new OracleCommand();
                return true;
            }
            catch (System.Exception ex)
            {
                txtResultOrErrMsg.Text = $"数据库连接失败，失败原因：{ex.Message}";
                return false;
            }
        }

        public void Close()
        {
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (cmbDataType.Text)
            {
                case "Oracle":
                    this.OpenOracle();
                    break;
                default:
                    break;
            }
        }

        bool IsApp64()
        {
            if (IntPtr.Size == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblbit.Text = this.IsApp64() == true ? "64位" : "32位";
        }
    }
}
