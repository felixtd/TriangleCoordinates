using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CherwellTest
{
	public class MainWindowViewModel : BindableBase
	{
		#region Member Variables
		private Triangle triangle;
		private int? inputX;
		private char? inputY;

		private int? v1X;
		private int? v1Y;
		private int? v2X;
		private int? v2Y;
		private int? v3X;
		private int? v3Y;

		private string triangleResult;
		private string rowColResult;
		private string success;

		#endregion Member Variables

		#region Construction
		public MainWindowViewModel()
		{
			TriangleResult = "Result...";
			RowColResult = "Result...";

			ComputeVertices = new DelegateCommand(
				() =>
				{
					OnComputeVertices();
				})
				.ObservesProperty(() => InputX)
				.ObservesProperty(() => InputY)
				.ObservesCanExecute(() => CanEnableCompute);
		}

		public bool CanEnableCompute
		{
			get
			{
				if (!InputX.HasValue || !InputY.HasValue)
					return false;

				var c = Char.ToUpper(InputY.Value);
				var test = "ABCDEFG";

				return (InputX.Value > 0 && InputX.Value <= 12) && test.Contains(c);
			}
		}

		public string Explanation
		{
			get
			{
				return string.Format("{0}{1}{2}{3}",
					"Enter column (1 - 12) and row (A - F) and click \"Compute Vertices\".\n",
					"The vertices are then computed for the triangle at that column and row.\n",
					"The computed triangle is then used to compute the row and column and\n",
					"that computed row and column are checked against the user entered values.");
			}
		}

		#endregion Construction

		#region Commands

		public ICommand ComputeVertices { get; private set; }
		
		#endregion Commands

		#region Properties

		public int? InputX
		{
			get { return inputX; }
			set { SetProperty(ref inputX, value); }
		}

		public char? InputY
		{
			get { return inputY; }
			set { SetProperty(ref inputY, value); }
		}

		public int? V1X
		{
			get { return v1X; }
			set { SetProperty(ref v1X, value); }
		}

		public int? V1Y
		{
			get { return v1Y; }
			set { SetProperty(ref v1Y, value); }
		}

		public int? V2X
		{
			get { return v2X; }
			set { SetProperty(ref v2X, value); }
		}

		public int? V2Y
		{
			get { return v2Y; }
			set { SetProperty(ref v2Y, value); }
		}

		public int? V3X
		{
			get { return v3X; }
			set { SetProperty(ref v3X, value); }
		}

		public int? V3Y
		{
			get { return v3Y; }
			set { SetProperty(ref v3Y, value); }
		}

		public string TriangleResult
		{
			get { return triangleResult; }
			set
			{
				SetProperty(ref triangleResult, value);
			}
		}

		public string RowColResult
		{
			get { return rowColResult; }
			set
			{
				SetProperty(ref rowColResult, value);
			}
		}

		public string Success
		{
			get { return success; }
			set
			{
				SetProperty(ref success, value);
			}
		}

		#endregion Properties

		#region Methods

		private void OnComputeVertices()
		{
			var row = InputY.Value.ToRowInt();
			triangle = new Triangle(InputX.Value, row);

			triangle.ComputeCoordinates();
			TriangleResult = $"Coordinates: {triangle.ToString()}";

			V1X = triangle.V1.X;
			V1Y = triangle.V1.Y;
			V2X = triangle.V2.X;
			V2Y = triangle.V2.Y;
			V3X = triangle.V3.X;
			V3Y = triangle.V3.Y;

			RowColResult = $"Column (X): {triangle.VertexToColumn(triangle.V2)} : Row (Y): {triangle.VertexToRow(triangle.V2).ToRowChar()}";

			if (triangle.VertexToColumn(triangle.V2) == InputX && triangle.VertexToRow(triangle.V2) == InputY.Value.ToRowInt())
			{
				Success = "Success";
			}
			else
			{
				Success = "No Match!!";
			}
		}

		#endregion Methods
	}
}
