using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        //public Form4(DataSet ds, String type)
        public Form4(DataSet ds, String type)
        {
            InitializeComponent();
            if (type == "sales")
            {
                SalesReport1 cos = new SalesReport1();
                cos.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cos;
                ds.WriteXml(@"C:\sales.xml", XmlWriteMode.WriteSchema);
            }
            if (type == "staff_sched")
            {
                CalenderVer2Report cos = new CalenderVer2Report();
                cos.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cos;
                ds.WriteXml(@"C:\staff_sched.xml", XmlWriteMode.WriteSchema);
            }
            if (type == "playhouse_report")
            {
                PlayhouseReports cos = new PlayhouseReports();
                cos.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cos;
                ds.WriteXml(@"C:\playhouse_report.xml", XmlWriteMode.WriteSchema);
            }
            if (type == "dog_med")
            {
                DogMedRep cos = new DogMedRep();
                cos.SetDataSource(ds);
                crystalReportViewer1.ReportSource = cos;
                ds.WriteXml(@"C:\dog_med.xml", XmlWriteMode.WriteSchema);
            }
        }
    }
}
