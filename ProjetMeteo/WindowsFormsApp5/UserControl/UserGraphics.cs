using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp5.classe
{
    public partial class UserGraphics : UserControl
    {
        List<int> dataId1 = new List<int>();
        List<int> dataId2 = new List<int>();
        List<int> dataId3 = new List<int>();
        protected Dictionary<string, Series> series = new Dictionary<string, Series>();

        public UserGraphics()
        {
            InitializeComponent();
            series.Add("température", PointsTemp);
            series.Add("humidité", PointsWater);
            series.Add("pression atmosphérique", PointsPressure);
        }


        public void addPoints(string type, float Xpoint, float Ypoint)
        {
            series[type].Points.AddXY(Xpoint, Ypoint);
        }

        public Series PointsTemp { get; } = new Series()
        {
            Name = "Température",
            Color = System.Drawing.Color.DarkRed,
            BorderWidth = 4,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line
        };

        public Series PointsWater { get; } = new Series()
        {
            Name = "Humidité",
            Color = System.Drawing.Color.DarkBlue,
            BorderWidth = 4,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line
        };

        public Series PointsPressure { get; } = new Series()
        {
            Name = "Pression",
            Color = System.Drawing.Color.DarkGreen,
            BorderWidth = 4,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line
        };


        public Series PointsWind { get; } = new Series()
        {
            Name = "Vitesse du vent",
            Color = System.Drawing.Color.DarkGray,
            BorderWidth = 4,
            IsVisibleInLegend = true,
            IsXValueIndexed = false,
            ChartType = SeriesChartType.Line
        };
        public Dictionary<string, Series> Series { get => series; set => series = value; }

        public void AddSeriesToChart(Chart chart, UserGraphics graph)
        {
            foreach (string val in graph.Series.Keys)
            {
                chart.Series.Add(graph.Series[val]);
            }
        }
        public void addDataToSeriesOfGraph(UserGraphics graph, String serie, float now, float Y)
        {
            graph.addPoints(serie, now, Y);
        }


        public void setAxes()
        {
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "{00.00}";
            for (int i = 0; i < chart.Series.Count; i++)
            {
                chart.Series[i].MarkerStyle = MarkerStyle.Square;
                chart.Series[i].MarkerSize = 8;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

       /* public void fillChart()
        {
            foreach (Base elem in Form1.trame)
            {
                if (elem.Id == 1)
                {
                    if(dataId1.Count != 10)
                    {
                        dataId1.Add(((Mesure)elem).DataConvert);
                    }
                    else
                    {
                        dataId1.RemoveAt(0);
                        dataId1.Add(((Mesure)elem).DataConvert);
                    }
                    
                }
                else if (elem.Id == 2)
                {
                    if (dataId2.Count != 10)
                    {
                        dataId2.Add(((Mesure)elem).DataConvert);
                    }
                    else
                    {
                        dataId2.RemoveAt(0);
                        dataId2.Add(((Mesure)elem).DataConvert);
                    }
                }
                else if (elem.Id == 3)
                {
                    if (dataId3.Count != 10)
                    {
                        dataId3.Add(((Mesure)elem).DataConvert);
                    }
                    else
                    {
                        dataId3.RemoveAt(0);
                        dataId3.Add(((Mesure)elem).DataConvert);
                    }
                }
            }
        }*/
    }
}
