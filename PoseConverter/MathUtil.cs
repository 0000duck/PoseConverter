using System;
using System.Linq;
using MathNet.Numerics.LinearAlgebra;

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
        public static double[] Uad2Deg(double[] angles3)
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
    }
}