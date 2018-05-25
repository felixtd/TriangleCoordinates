using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CherwellTest
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OnComputeVertices(object sender, RoutedEventArgs e)
		{
			var row = tbY.Text.First().ToRowInt();
			var triangle = new Triangle(int.Parse(tbX.Text), row);

			triangle.ComputeCoordinates();
			this.labelV1.Content = $"Coordinates: {triangle.ToString()}";

			this.tbV1x.Text = triangle.V1.X.ToString();
			this.tbV1y.Text = triangle.V1.Y.ToString();
			this.tbV2x.Text = triangle.V2.X.ToString();
			this.tbV2y.Text = triangle.V2.Y.ToString();
			this.tbV3x.Text = triangle.V3.X.ToString();
			this.tbV3y.Text = triangle.V3.Y.ToString();

			this.labelRowCol.Content = $"Column (X): {triangle.VertexToColumn(triangle.V2)} : Row (Y): {triangle.VertexToRow(triangle.V2).ToRowChar()}";

			if (triangle.VertexToColumn(triangle.V2) == int.Parse(tbX.Text) && triangle.VertexToRow(triangle.V2) == tbY.Text.First().ToRowInt())
			{
				labelSuccess.Content = "Success";
			}
			else
			{
				labelSuccess.Content = "No Match!!";
			}
		}

		//private void OnComputeRowColumn(object sender, RoutedEventArgs e)
		//{
		//	this.tbV1x.Text = string.Empty;
		//	this.tbV1y.Text = string.Empty;
		//	this.tbV3x.Text = string.Empty;
		//	this.tbV3y.Text = string.Empty;

		//	var v2 = new Point(int.Parse(tbV2x.Text), int.Parse(tbV2y.Text));
		//	//this.labelRowCol.Content = $"Column (X): {v2.VertexToColumn(v2.V2)} : Row (Y): {triangle.VertexToRow(triangle.V2)}";
		//}
	}
}
