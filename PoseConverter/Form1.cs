using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PoseConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            var checkedRadioButtion = groupBox1.Controls.OfType<RadioButton>().SingleOrDefault(rb => rb.Checked == true);
            Matrix<double> rotMat;

            if (checkedRadioButtion == null)
            {
                MessageBox.Show("Select an item from \"Convert from ...\"", "Error");
                return;
            }

            rotMat = CalcRotationMatrix(checkedRadioButtion);
            UpdateAllFields(rotMat);

            richTextBoxRotationMatrix.Text = rotMat.ToMatrixString();
        }

        private void UpdateAllFields(Matrix<double> rotMat)
        {
            var oatInRad = MathUtil.GetOAT(rotMat).ElementAt(0);
            textBoxZyzRad.Text = String.Format("{0}, {1}, {2}", oatInRad[0], oatInRad[1], oatInRad[2]);

            var oatInDeg = MathUtil.Rad2Deg(oatInRad.ToArray());
            textBoxZyzDeg.Text = String.Format("{0}, {1}, {2}", oatInDeg[0], oatInDeg[1], oatInDeg[2]);
        }

        /// <summary>選択されたラジオボタンに応じて、対応する回転行列を返す </summary>
        /// <param name="checkedRadioButtion"></param>
        /// <returns>回転行列</returns>
        private Matrix<double> CalcRotationMatrix(RadioButton checkedRadioButtion)
        {
            double[] oatInDeg;
            double[] oatInRad;
            Matrix<double> mat;

            switch (checkedRadioButtion.Name)
            {
                case nameof(radioButtonZyzRad):
                    oatInRad = SplitAndParseText(textBoxZyzRad.Text);
                    mat = MathUtil.MakeRotationMatrixFromZyzEuler(oatInRad);
                    return mat;

                case nameof(radioButtonZyzDeg):
                    oatInDeg = SplitAndParseText(textBoxZyzDeg.Text);
                    oatInRad = MathUtil.Deg2Rad(oatInDeg);
                    mat = MathUtil.MakeRotationMatrixFromZyzEuler(oatInRad);
                    return mat;

                case nameof(radioButtonZyxRad):
                    oatInRad = SplitAndParseText(textBoxZyxRad.Text);
                    mat = MathUtil.MakeRotationMatrixFromZyxEuler(oatInRad);
                    return mat;

                case nameof(radioButtonZyxDeg):
                    oatInDeg = SplitAndParseText(textBoxZyxDeg.Text);
                    oatInRad = MathUtil.Deg2Rad(oatInDeg);
                    mat = MathUtil.MakeRotationMatrixFromZyxEuler(oatInRad);
                    return mat;

                default:
                    throw new Exception("Select a item from 'Convert from...'");
            }
        }

        /// <summary>入力されたオイラー角(文字列)をパースしてdouble型の配列として返す。 バリデーションは行っていない。</summary>
        /// <param name="inputtedText"></param>
        /// <returns>double型3要素の配列</returns>
        private double[] SplitAndParseText(string inputtedText)
        {
            var oatString = inputtedText;
            var oatStrArray = oatString.Split(',');
            if (oatStrArray.Length != 3) { throw new ArgumentException("inputtedText must have 2 commas.");}
            var oat = oatStrArray.Select(double.Parse).ToArray();
            return oat;
        }

        enum ConvertFrom
        {
            zyzRad,
            zyzDeg,
            zyxRad,
            zyxDeg,
        }
    }
}
