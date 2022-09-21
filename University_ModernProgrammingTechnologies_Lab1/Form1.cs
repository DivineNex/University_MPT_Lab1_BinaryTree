using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace University_ModernProgrammingTechnologies_Lab1
{
    public partial class formMain : Form
    {
        private DBManager dBManager;
        private RadialBearingBinaryTree binaryTree;

        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            InitDBManager();
            InitBinaryTree();
        }

        private void InitDBManager()
        {
            dBManager = new DBManager();
            dBManager.OpenConnection();
        }

        private void InitBinaryTree()
        {
            binaryTree = new RadialBearingBinaryTree();
            binaryTree.BuildBinaryTreeFromDBTable(dBManager.connection, "RadialBearings");
        }
    }
}
