using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace _2212398_Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private List<StudentInfo> LoadJSON(string Path)
        {
            List<StudentInfo> List = new List<StudentInfo>();
            StreamReader r = new StreamReader(Path);
            string json = r.ReadToEnd();

            var array = (JObject)JsonConvert.DeserializeObject(json);
            var students = array["sinh vien"].Children();
            foreach (var item in students)
            {
                string mssv = item["MSSV"].Value<string>();
                string hoten = item["hoten"].Value<string>();
                int tuoi = item["tuoi"].Value<int>();
                double diem = item["diem"].Value<double>();
                bool tongiao = item["tongiao"].Value<bool>();
                StudentInfo info = new StudentInfo(mssv, hoten, tuoi, diem, tongiao);
                List.Add(info);
            }
            return List;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Str = "";
            string Path = "E:/nguyen_ly/2212398_Lab5/2212398_Lab5/JSONExample.json";
            List<StudentInfo> List = LoadJSON(Path);
            for (int i = 0; i < List.Count; i++)
            {
                StudentInfo info = List[i];
                Str += string.Format("Sinh viên {0} có MSSV: {1}, họ tên: {2}, điểm TB {3}\r\n ", i + 1, info.MSSV, info.Hoten, info.Diem);
            }
            MessageBox.Show(Str);
        }
    }
}
