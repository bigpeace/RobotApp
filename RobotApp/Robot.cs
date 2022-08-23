using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace RobotApp
{
    public partial class Robot : Form
    {
        public Robot()
        {
            InitializeComponent();


        }

        private void Robot_Load(object sender, EventArgs e)
        {
            // 描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(pb_robot.Width, pb_robot.Height);
            // Imageオブジェクト の Graphicsオブジェクトを作成する
            Graphics g = Graphics.FromImage(canvas);

            // 直線で接続する点の配列を作成
            Point[] ps = {
                new Point(240, 60),
                new Point(660, 60),
                new Point(660, 480),
                new Point(240, 480),
                new Point(240, 60)
            };

            // ダッシュ
            Pen LinePen = new Pen(Color.LightSkyBlue, 5);
            LinePen.DashStyle = DashStyle.Dash;

            g.DrawLines(LinePen, ps);

            // 画像ファイルを読み込んで、Imageオブジェクトとして取得する
            Image robotImg = Properties.Resources.agv;
            // 画像をcanvasの座標(240 ,60)の位置に描画する → ここでDBから呼び出すようにする
            g.DrawImage(robotImg, 240 - 30, 60 - 30, robotImg.Width / 3, robotImg.Height / 3);

            // リソースを解放する
            g.Dispose();
            // pb_robotに表示する
            pb_robot.Image = canvas;

        }
    }
}
