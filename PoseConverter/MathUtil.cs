using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace PoseConverter
{
    public static class MathUtil
    {
        public static string STConst;
        public const double DEG2RAD = Math.PI / 180d;
        public const double RAD2DEG = 180d / Math.PI;

        //Static Constructor
        static MathUtil()
        {
            STConst = "[MathUtil]:";
        }

        //Convert angles3 written in [deg] into [rad]
        public static double[] Deg2Rad(double[] angles3)
        {
            if (angles3.Length != 3)
            {
                throw new ArgumentException("Error: angles3 must have 3 elements.");
            }

            var ans = angles3.Select(d => d * DEG2RAD).ToArray();
            return ans;
        }

        //Convert angles3 written in [rad] into [deg]
        public static double[] Rad2Deg(double[] angles3)
        {
            if (angles3.Length != 3)
            {
                throw new ArgumentException("Error: angles3 must have 3 elements.");
            }

            var ans = angles3.Select(d => d * RAD2DEG).ToArray();
            return ans;
        }


        //軸回転の行列

        /// <summary>Z軸回転の3x3回転行列</summary>
        /// <param name="angle">回転角度[rad]</param>
        /// <returns></returns>
        public static Matrix<double> RotZ(double angle)
        {
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);

            var ans = CreateMatrix.DenseOfArray(new double[,]
            {
                {c, -s, 0},
                {s, +c, 0},
                {0, +0, 1},
            });

            return ans;
        }

        /// <summary>Y軸回転の3x3回転行列</summary>
        /// <param name="angle">回転角度[rad]</param>
        /// <returns>回転後の行列</returns>
        public static Matrix<double> RotY(double angle)
        {
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);

            var ans = CreateMatrix.DenseOfArray(new double[,]
            {
                {+c, 0, s},
                {+0, 1, 0},
                {-s, 0, c},
            });

            return ans;
        }

        /// <summary>X軸回転の3x3回転行列</summary>
        /// <param name="angle">回転角度[rad]</param>
        /// <returns>回転後の行列</returns>
        public static Matrix<double> RotX(double angle)
        {
            var c = Math.Cos(angle);
            var s = Math.Sin(angle);

            var ans = CreateMatrix.DenseOfArray(new double[,]
            {
                {1, 0, 0},
                {0, c, -s},
                {0, s, c},
            });

            return ans;
        }

        public static Matrix<double> MakeRotationMatrixFromZyzEuler(double[] oat)
        {
            return MakeRotationMatrixFromZyzEuler(oat[0], oat[1], oat[2]);
        }

        /// <summary>ZYZ-Euler 各(o,a,t)から回転行列(3x3)を返す </summary>
        /// <param name="o">z軸周りの回転角度[rad]</param>
        /// <param name="a">y'軸周りの回転角度[rad]</param>
        /// <param name="t">z''軸周りの回転角度[rad]</param>
        /// <returns>回転行列(3x3)</returns>
        public static Matrix<double> MakeRotationMatrixFromZyzEuler(double o, double a, double t)
        {
            var matO = RotZ(o);
            var matA = RotY(a);
            var matT = RotZ(t);

            var ans = matO.Multiply(matA).Multiply(matT);
            return ans;
        }

        public static Matrix<double> MakeRotationMatrixFromZyxEuler(double[] rpy)
        {
            return MakeRotationMatrixFromZyzEuler(rpy[0], rpy[1], rpy[2]);
        }

        /// <summary>ZYX-Euler 各(o,a,t)から回転行列(3x3)を返す </summary>
        /// <param name="r">z軸周りの回転角度[rad]</param>
        /// <param name="p">y'軸周りの回転角度[rad]</param>
        /// <param name="y">x''軸周りの回転角度[rad]</param>
        /// <remarks>or its Roll-Pitch-Yaw angles.</remarks>
        /// <returns>回転行列(3x3)</returns>
        public static Matrix<double> MakeRotationMatrixFromZyxEuler(double r, double p, double y)
        {
            var matR = RotZ(r);
            var matP = RotY(p);
            var matY = RotX(y);

            var ans = matR.Multiply(matP).Multiply(matY);
            return ans;
        }

        public static List<Vector<double>> GetOAT(Matrix<double> rot33)
        {
            var TOLERANCE = 1E-09;
            var st2 = Math.Sqrt(rot33[0, 2] * rot33[0, 2] + rot33[1, 2] * rot33[1, 2]);
            double a1, o1, t1;
            double a2, o2, t2;

            if (TOLERANCE < Math.Abs(st2))
            {
                var st = st2;
                a1 = Math.Atan2(+st, rot33[2, 2]);
                a2 = Math.Atan2(-st, rot33[2, 2]);

                o1 = Math.Atan2(rot33[1, 2], +rot33[0, 2]);
                o2 = Math.Atan2(rot33[1, 2], -rot33[0, 2]);

                t1 = Math.Atan2(rot33[2, 1], -rot33[2, 0]);
                t2 = Math.Atan2(rot33[2, 1], +rot33[2, 0]);
            }
            else
            {
                //o1+t1=Math.Atan2(rot33[1, 0], rot33[1, 1]) を満たす (o1, t1)の組み合わせは無数にある。
                //ここでは、t1=0 という解を得ることにする。
                o1 = Math.Atan2(rot33[1, 0], rot33[1, 1]);
                a1 = (1d - rot33[2, 2]) * Math.PI / 2d;
                t1 = 0d;

                o2 = double.NaN;
                a2 = double.NaN;
                t2 = double.NaN;
            }

            var ans = new List<Vector<double>>();
            ans.Add(CreateVector.DenseOfArray(new double[] {o1, a1, t1}));
            if (!double.IsNaN(a2) || !double.IsNaN(a2) || !double.IsNaN(t2))
            {
                ans.Add(CreateVector.DenseOfArray(new double[] {o2, a2, t2}));
            }

            return ans;
        }

    }
}